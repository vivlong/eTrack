Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class IssueEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsIssue
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strTitle As String = ""
    'Dim objExport As ExportToExcel.ExcelExpor
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub 
    Private intTrxNo As Int64 = ConClass.NewIdValue
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsIssue(intUserId)
    End Function
    Public Function NewServerObject(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsIssue(strUserId, RoleName, strFunNo)
    End Function
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            fldId.Value = -1
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                fldId.Value = intTrxNo
                'bylin
                'New Object 
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
                objList.Where = " and TrxNo= " + intTrxNo.ToString

                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            Else
                divTopNav.Style.Add("display", "none")
                'Bind The All Detail
            End If
            btnSave.Attributes.Add("OnClick", "SaveOmtx2('Issue','" + fldId.Value + "');return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#End Region
#Region "Add PO"
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub

#End Region
#Region "Issue Grid"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsIssue(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Omtx2"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            'Dim Im As New Image
            'Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            'Im.Attributes.Add("OnClick", "AddToSO2();return false;")
            'e.Row.Cells(0).Style.Add("text-align", "center")
            'e.Row.Cells(0).Style.Add("width", "20px")
            'e.Row.Cells(0).Controls.Add(Im)
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Try
                Dim txtDate As TextBox = CType(e.Row.FindControl("txtDate"), TextBox)
                Dim txtPackingQty As TextBox = CType(e.Row.FindControl("txtPackingQty"), TextBox)
                Dim intLineItemNo As Integer = CType(tmpProp, clsPropIssue).LineItemNo
                If txtDate.Text.Trim <> "" Then
                    txtDate.Text = ConvertDate(Date.Parse(txtDate.Text.Trim))
                End If
                If txtPackingQty.Text.Trim = 0 Then
                    txtPackingQty.Text = ""
                End If
                If intLineItemNo = 0 Then
                    'Delete
                    Dim imgDelete As HtmlControls.HtmlAnchor = CType(e.Row.FindControl("Img2"), HtmlControls.HtmlAnchor)
                    imgDelete.Style.Add("display", "none")
                End If
            Catch ex As Exception
            End Try
        End If

        e.Row.Cells(0).Style.Add("width", "10px")
        e.Row.Cells(1).Style.Add("width", "100px")
        e.Row.Cells(2).Style.Add("width", "70px")
        e.Row.Cells(3).Style.Add("width", "250px")

    End Sub

    Protected Sub gvwSource_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.DataBound
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim i As Integer
            For i = 0 To gvwSource.Rows.Count - 1
                '---------------List Control-------------------------------------------------------------------------
                Dim Img2 As HtmlControls.HtmlAnchor = gvwSource.Rows(i).FindControl("Img2")
                Dim hid_TrxNo As HiddenField = gvwSource.Rows(i).FindControl("hid_TrxNo")
                Dim hid_LineItemNo As HiddenField = gvwSource.Rows(i).FindControl("hid_LineItemNo")

                Dim txtDate As TextBox = gvwSource.Rows(i).FindControl("txtDate")                           '------1
                Dim txtPackingQty As TextBox = gvwSource.Rows(i).FindControl("txtPackingQty")               '------2
                Dim txtRemark As TextBox = gvwSource.Rows(i).FindControl("txtRemark")                       '------3

                Dim strTrxNo As String = hid_TrxNo.Value
                Dim strLineitemno As String = hid_LineItemNo.Value
                Dim strTrxNoLineitemno As String = hid_LineItemNo.Value
                'focus
                txtDate.Attributes.Add("OnKeyDown", "FocusControl(event," + txtDate.ClientID + "," + txtPackingQty.ClientID + ");")
                txtPackingQty.Attributes.Add("OnKeyDown", "FocusControl(event," + txtPackingQty.ClientID + "," + txtRemark.ClientID + ");")
                If i < gvwSource.Rows.Count - 1 Then
                    Dim txtNextRemark As TextBox = gvwSource.Rows(i + 1).FindControl("txtDate")
                    txtRemark.Attributes.Add("OnKeyDown", "FocusControl(event," + txtRemark.ClientID + "," + txtNextRemark.ClientID + ");")
                Else
                    txtRemark.Attributes.Add("OnKeyDown", "FocusControl(event," + txtRemark.ClientID + "," + txtDate.ClientID + ");")
                End If
                'Set deleteButton 
                If strLineitemno <> "0" Then
                    Img2.Attributes.Add("onclick", "DeleteData(" + strTrxNo + "," + strLineitemno + ");return false;")
                    'onchange
                    txtDate.Attributes.Add("onchange", "UpdateRecord('" + strTrxNo + "','" + strLineitemno + "','Date'," + txtDate.ClientID + ")") '---1
                    txtPackingQty.Attributes.Add("onchange", "UpdateRecord('" + strTrxNo + "','" + strLineitemno + "','PackingQty'," + txtPackingQty.ClientID + ")") '---2
                    txtRemark.Attributes.Add("onchange", "UpdateRecord('" + strTrxNo + "','" + strLineitemno + "','Remark'," + txtRemark.ClientID + ")") '---3
                Else
                    txtRemark.Attributes.Add("OnKeyDown", "SaveOneRecord('" + fldId.Value + "')")
                End If
            Next
        End If
    End Sub
    Private Function ConvertDate(ByVal strVal As Date) As String
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "1900-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                Return ""
            Else
                Return strVal.ToString("dd/MM/yyyy")
            End If
        Else
            Return ""
        End If
    End Function
    Public Function SaveOneRecord(ByVal strFile As String, ByVal strTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim Flag As Integer = InsertRecord(strFile, strTrxNo)
            If Flag > 0 Then
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList.Where = " and TrxNo= " + fldId.Value
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false."
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        Return ""
    End Function
    Private Function InsertRecord(ByRef strFile As String, ByRef strTrxNo As String) As Integer
        Dim intResult As Integer = -1
        Try
            If strFile.Trim <> "" Then
                Dim strSql As String = " insert into omtx2(TrxNo,Date,PackingQty,Remark,LineItemNo) values(" + strFile + "," + getLineItemNo(strTrxNo) + ")"
                '  Dim strSql As String = " insert into omtx2(TrxNo,Date,Pcs,Remark,LineItemNo) values(" + strFile + "," + getLineItemNo(strTrxNo) + ")"
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            End If
        Catch ex As Exception
            intResult = -1
        End Try
        Return intResult
    End Function

    Private Function getLineItemNo(ByVal strTrxNo As String) As String
        Dim strLineItem As String = ""
        Try
            Dim dt As DataTable
            Dim strSql As String = "select isnull(max(LineItemNo),0)+1 from omtx2 where TrxNo=" + strTrxNo
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt.Rows.Count > 0 Then
                strLineItem = dt.Rows(0)(0).ToString
            End If
        Catch ex As Exception
        End Try
        Return strLineItem
    End Function
    Public Function DeleteData(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not RunDeleteData(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList.Where = " and TrxNo= " + fldId.Value
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function RunDeleteData(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete omtx2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineItemNo
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        Else
            Return False
        End If
    End Function
    Public Function UpdateRecord(ByVal strsql As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal strCurrentControl As String, ByVal strUpdate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intflag As String
            intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
            If intflag > 0 Then
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList.Where = " and TrxNo= " + fldId.Value
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false."
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function
#End Region
End Class
