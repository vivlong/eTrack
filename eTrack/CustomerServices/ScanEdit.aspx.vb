Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class ScanEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsScan
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strTitle As String = ""
    'Dim objExport As ExportToExcel.ExcelExpor
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub 
    Private strOrderNo As String = ConClass.NewIdValue.ToString
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsScan(intUserId)
    End Function
    Public Function NewServerObject(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsScan(strUserId, RoleName, strFunNo)
    End Function
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            fldId.Value = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            'If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            '    Return
            'End If
            Dim Guest As String = ""
            Dim User As Object
            Dim UserLogin As Boolean = False
            Dim Role As String = ""
            Dim info As Integer = 0
            If Not GetCurrentUserInfo(Page, objUser) = True Then
                User = Guest
                UserLogin = False
                Role = ""
                info = 0
            Else
                User = objUser.UserId
                UserLogin = True
                Role = objUser.RoleName
                info = objUser.PagePara.InfoSize
            End If
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                strOrderNo = Request("Id").ToString()
                fldId.Value = strOrderNo
                'bylin
                'New Object 
                'objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList = NewObjectList(User, Role, PageFun.GetFunNo(Page))
                objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
                objList.Query = " and Type= 1"
                'BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                BindSourceData(User, 1, info)
            Else
                divTopNav.Style.Add("display", "none")
                'Bind The All Detail
            End If
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
#Region "Scan Grid"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        'If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        '    Return False
        'End If
        Dim Guest As String = ""
        Dim User As Object
        Dim UserLogin As Boolean = False
        Dim Role As String = ""
        Dim info As Integer = 0
        If Not GetCurrentUserInfo(Page, objUser) = True Then
            User = Guest
            UserLogin = False
            Role = ""
            info = 0
        Else
            User = objUser.UserId
            UserLogin = True
            Role = objUser.RoleName
            info = objUser.PagePara.InfoSize
        End If

        intPageIndex = intPage
        objList.Query += " and OrderNo= '" + fldId.Value + "'"
        objList.GetListInfo(intPage, intSize)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsScan(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
    MyBase.OnInit(e)
        Me.TableName = "Omtx2"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "SortNo"
        Me.SortDesc = True
    End Sub
    Public Overloads Function GetPageData(ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String) As String
        Dim objUser As clsUser = Nothing
        Dim Guest As String = ""
        Dim User As Object
        Dim UserLogin As Boolean = False
        Dim Role As String = ""
        Dim info As Integer = 0
        If Not GetCurrentUserInfo(Page, objUser) = True Then
            User = Guest
            UserLogin = False
            Role = ""
            info = 0
        Else
            User = objUser.UserId
            UserLogin = True
            Role = objUser.RoleName
            info = objUser.PagePara.InfoSize
        End If
        '  If GetCurrentUserInfo(Page, objUser) Then
        ' Dim oju As String = objUser.UserId 'by lzw 090616
        Dim oju As String = User
        Dim pf As String = PageFun.GetFunNo(Me.Page)
        Me.objList = NewObjectList(User, Role, PageFun.GetFunNo(Page))
        ' Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
        Me.objList.Query = strQuery
        Me.objList.Where = strWhere
        Me.CurrentSortField = strSortField
        Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
        Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
        Me.intPageIndex = Short.Parse(strPage)
        Me.BindSourceData(User, Me.intPageIndex, info)
'  Me.BindSourceData(objUser.UserId, Me.intPageIndex, objUser.PagePara.InfoSize)
        Return (Me.intPageCount.ToString & ConSeparator.Par & GridViewFun.RenderControl(MyGridView))
        'End If
        ' Return (Me.intPageCount.ToString & ConSeparator.Par)
    End Function

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Try
                If e.Row.Cells(5).Text <> "" And e.Row.Cells(5).Text <> ConDateTime.MinDate Then
                    e.Row.Cells(5).Text = ConvertDate(DateTime.Parse(e.Row.Cells(5).Text.Trim))
                End If
                If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                    For i As Integer = 0 To e.Row.Cells.Count - 1
                        e.Row.Cells(i).Text = ""

                    Next
                End If
            Catch ex As Exception
            End Try
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
    'add by danny
    Public Function GetCurrentUserInfo(ByVal pgCurrent As Page, ByRef objUser As clsUser) As Boolean
        Dim strPage As String = pgCurrent.Request.RawUrl
        If HttpContext.Current.Session(ConSessionName.UserInfo) Is Nothing Then
            ' pgCurrent.Response.Redirect(("../Default.aspx?Redirect=" + strPage))
            'pgCurrent.Response.Redirect(("Default.aspx?Redirect=" + strPage))
            Return False
        Else
            objUser = CType(HttpContext.Current.Session(ConSessionName.UserInfo), clsUser)
            HttpContext.Current.Session(ConSessionName.UserInfo) = objUser
            Return True
        End If
    End Function

End Class
