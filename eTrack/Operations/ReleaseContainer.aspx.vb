Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Imports SysMagic

Partial Class ReceiveContainer
    Inherits ListEditPage
    Private objServer As clsRO2
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Private intLineItemNo As Int64 = -1
    Private QtyFlag As String = "Y"
    Private QtyBotton As String = "Y"
    Protected ConfigPath As String
    Protected ExportConfig As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsRO2(intUserId)
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsRO2(strUserId, RoleName, strFunNo)
    End Function

    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function

#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set style Config
            ExportConfig = objUser.ExportConfig
            Select Case ExportConfig
                Case "Blue"
                    ConfigPath = "../App_Themes"
                Case "Orange"
                    ConfigPath = "../App_Themes_Orange"
                Case "Smalt"
                    ConfigPath = "../App_Themes_Smalt"
                Case Else
                    ConfigPath = "../App_Themes"
            End Select
            hidTruckerName.Value = ""
            hidEquipmentType.Value = ""
            If Not (Request("intTrxNo") Is Nothing) Then
                fldId.Value = Request("intTrxNo").ToString
            End If
            If Not (Request("LineItemNo") Is Nothing) Then
                intLineItemNo = Request("LineItemNo").ToString
                hidLineItemNo.Value = intLineItemNo
            End If
            If Not (Request("TruckerName") Is Nothing) Then
                hidTruckerName.Value = Request("TruckerName").ToString
            End If
            If Not (Request("RequipType") Is Nothing) Then
                hidEquipmentType.Value = Request("RequipType").ToString
            End If
            If Not (Request("OrderNo") Is Nothing) Then
                Me.Title = "Release Container : " + Request("OrderNo").ToString + " / " + Request("RequipType").ToString
            Else
                Me.Title = "Release Container : New"
            End If
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'DateTime Event'
            btnReleaseContainer.Attributes.Add("OnClick", "ReleaseContainer();return false;")
            btnCancel.Attributes.Add("OnClick", "CloseWindow(0);return false;")
            btnReleaseDate.Attributes.Add("OnClick", "WdatePicker({el:'txtReleaseDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            txtReleaseDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtReleaseDate.ClientID + "');return false;")
            txtReleaseDate.Attributes.Add("onblur", "ChangeLongDate('" + txtReleaseDate.ClientID + "');return false;")
            'Language 
            HandleLanguageRelative()
            txtReleaseDate.Text = DateTime.Now.ToString("dd-MMM-yy HH:mm")
        End If
    End Sub
#End Region

#Region "Grid View RO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)

        intPageIndex = intPage
        objList.Where = " and a.TrxNo=" + fldId.Value.ToString
        If Not (Request("LineItemNo") Is Nothing) Then
            intLineItemNo = Request("LineItemNo").ToString
        End If
        objList.Where += " and a.LineItemNo=" + intLineItemNo.ToString
        objList.GetListInfo(intPage, 0)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctso2"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub

    Private Sub HandleLanguageRelative()
        Dim str As String = GetJavascriptLanguageConst()
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", str)
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            Dim Im As New Image
            Im.ID = "ImgAdd"
            Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            Im.Attributes.Add("OnClick", "AddToRO2();return false;")
            e.Row.Cells(0).Style.Add("text-align", "center")
            e.Row.Cells(0).Style.Add("width", "20px")
            e.Row.Cells(0).Controls.Add(Im)
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim intTrxNo As String = CType(tmpProp, clsPropRO2).TrxNo.ToString
            Dim intReleaseFlag As Integer = CType(tmpProp, clsPropRO2).ReleaseFlag
            Dim Qty As Integer = CType(tmpProp, clsPropRO2).Qty
            'If Qty <= objList.ArrProp.Count - 1 Then
            If Qty <> -1 Then
                If Qty <= objList.ArrProp.Count - 1 Then
                    QtyFlag = "N"
                End If
                If Qty = objList.ArrProp.Count - 2 Then
                    QtyBotton = "N"
                End If
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                If QtyFlag = "N" Then
                    e.Row.Style.Add("display", "none")
                End If
            End If
            If intReleaseFlag > 0 Then
                'Delete
                Dim imgDelete As HtmlControls.HtmlAnchor = CType(e.Row.FindControl("Img2"), HtmlControls.HtmlAnchor)
                imgDelete.Style.Add("display", "none")
            End If
            If intTrxNo = "-1" Then
                e.Row.Cells(0).Controls.Clear()
            End If
        End If
    End Sub

    Protected Sub gvwSource_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.DataBound
        Dim objUser As clsUser = Nothing
        Dim sUpperFlag As Integer = 0
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim i As Integer
            For i = 0 To gvwSource.Rows.Count - 1
                If gvwSource.Rows(i).Cells(0).Controls.Count <> 0 Then
                    Dim strReleaseFlag As HiddenField = gvwSource.Rows(i).FindControl("HidReleaseFlag")
                    Dim intReleaseFlag As Integer = Integer.Parse(strReleaseFlag.Value)
                    Dim strContainerNo As HiddenField = gvwSource.Rows(i).FindControl("HidContainerNo")
                    Dim Img2 As HtmlControls.HtmlAnchor = gvwSource.Rows(i).FindControl("Img2")
                    Dim txtReleaseDate As TextBox = gvwSource.Rows(i).FindControl("txtReleaseDate")
                    If QtyFlag = "N" And gvwSource.HeaderRow.Cells(0).Controls.Count > 0 Then
                        gvwSource.HeaderRow.Cells(0).Controls.Clear()
                    End If
                    txtReleaseDate.ReadOnly = True
                    If txtReleaseDate.Text <> "" Then
                        Dim dtmTemp As DateTime = DateTime.Parse(txtReleaseDate.Text)
                        If dtmTemp <= ConDateTime.MinDate Then
                            txtReleaseDate.Text = ""
                        Else
                            txtReleaseDate.Text = dtmTemp.ToString("dd/MM/yyy HH:mm")
                        End If
                    End If
                    'Set deleteButton
                    If fldId.Value <> "-1" Then
                        Img2.Attributes.Add("onclick", "DeleteCTRO2('" + strContainerNo.Value + "');return false;")
                        For j As Integer = 1 To gvwSource.Columns.Count - 1
                            Dim strID As String = gvwSource.Rows(i).Cells(j).Controls(1).ClientID
                            Dim strFields As String = strID.Substring(strID.IndexOf("txt") + 3, strID.Length - strID.IndexOf("txt") - 3)
                            Dim firCon As TextBox = gvwSource.Rows(i).Cells(j).FindControl(gvwSource.Rows(i).Cells(j).Controls(1).ID)
                            If intReleaseFlag > 0 Then
                                firCon.ReadOnly = True
                            Else
                                'OnKeyUp
                                firCon.Attributes.Add("OnKeyUp", "getOldValue('" + strID + "');")
                                'OnFocus
                                firCon.Attributes.Add("OnFocus", "UpdateValue('" + strID + "','" + (i + 1).ToString + "','" + strFields + "')")
                                'OnBlur
                                If objUser.UpperCase = "y" Then
                                    sUpperFlag += 1
                                    firCon.Attributes.Add("OnBlur", "setToUpperCase(" + firCon.ClientID + ");focusAt(event,'" + strID + "','" + strContainerNo.Value + "','" + objUser.UpperCase + "');")
                                Else
                                    firCon.Attributes.Add("OnBlur", "focusAt(event,'" + strID + "','" + strContainerNo.Value + "','" + objUser.UpperCase + "');")
                                End If
                            End If
                        Next
                    End If

                Else
                    Dim intLast As Integer = gvwSource.Columns.Count - 1
                    Dim firCon As TextBox = gvwSource.Rows(i).Cells(intLast).FindControl(gvwSource.Rows(i).Cells(intLast).Controls(1).ID)
                    firCon.Attributes.Add("OnKeyDown", "EnterAddCtro2('" + objUser.UpperCase + "');")
                    Dim txtReleaseDate As TextBox = gvwSource.Rows(i).FindControl("txtReleaseDate")
                    txtReleaseDate.Text = ""
                    txtReleaseDate.ReadOnly = True
                End If
                'OnKeyDown
                For j As Integer = 1 To gvwSource.Columns.Count - 1
                    Dim firCon As TextBox = gvwSource.Rows(i).Cells(j).FindControl(gvwSource.Rows(i).Cells(j).Controls(1).ID)

                    If j < gvwSource.Columns.Count - 1 Then
                        'Key In One Row
                        Dim SecCon As TextBox = gvwSource.Rows(i).Cells(j + 1).FindControl(gvwSource.Rows(i).Cells(j + 1).Controls(1).ID)
                        firCon.Attributes.Add("OnKeyDown", "FocusControlRC(event," + firCon.ClientID + "," + SecCon.ClientID + ");")
                        'Key Next Row
                        If j = gvwSource.Columns.Count - 2 And i < gvwSource.Rows.Count - 1 Then
                            Dim NextRowCon As TextBox = gvwSource.Rows(i + 1).Cells(1).FindControl(gvwSource.Rows(i + 1).Cells(1).Controls(1).ID)
                            If objUser.UpperCase = "y" Then

                                SecCon.Attributes.Add("OnKeyDown", "FocusControlRemark(event," + SecCon.ClientID + "," + NextRowCon.ClientID + ");")
                            End If
                            If i = gvwSource.Rows.Count - 2 Then
                                If QtyFlag = "N" Then
                                    SecCon.Attributes.Remove("OnKeyDown")
                                End If
                            End If
                        End If
                        If i = gvwSource.Rows.Count - 1 Then
                            If j > 2 And objUser.UpperCase = "y" Then
                                firCon.Attributes.Add("onblur", "setToUpperCase(" + firCon.ClientID + ");")
                                SecCon.Attributes.Add("OnBlur", "setToUpperCase(" + SecCon.ClientID + ");")
                            End If
                        End If
                    End If
                Next
                If i = gvwSource.Rows.Count - 1 Then
                    Dim firCon As TextBox = gvwSource.Rows(i).Cells(1).FindControl(gvwSource.Rows(i).Cells(1).Controls(1).ID)
                    Dim SecCon As TextBox = gvwSource.Rows(i).Cells(2).FindControl(gvwSource.Rows(i).Cells(2).Controls(1).ID)
                    Dim TirCon As TextBox = gvwSource.Rows(i).Cells(3).FindControl(gvwSource.Rows(i).Cells(3).Controls(1).ID)
                    Dim ConContainerType As TextBox = gvwSource.Rows(i).Cells(8).FindControl(gvwSource.Rows(i).Cells(8).Controls(1).ID)
                    If firCon.ClientID.IndexOf("ContainerNo") >= 0 Then
                        firCon.Attributes.Add("onblur", "CheckContainerNo(event," + firCon.ClientID + ",'" + TirCon.ClientID + "','" + ConContainerType.ClientID + "','" + objUser.UpperCase + "');")
                    End If
                End If
            Next
        End If
    End Sub

    Function CheckContainerNo(ByVal strContainerNo As String, ByVal SenondCon As String, ByVal objContainerNo As String, ByVal ContainerType As String, ByVal strTrxNo As String, ByVal strLineitemno As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intResult As Integer
            Dim ds As DataSet = Nothing
            Dim InsertFlag As String = ""
            Dim msg As String = ""
            Dim valContainerType As String = ""
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                Dim param(6) As SqlParameter
                Try
                    param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                    param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                    param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                    param(3) = New SqlParameter("@InsertFlag", SqlDbType.NVarChar, 1)
                    param(3).Direction = ParameterDirection.Output
                    param(4) = New SqlParameter("@msg", SqlDbType.NVarChar, 200)
                    param(4).Direction = ParameterDirection.Output
                    param(5) = New SqlParameter("@ContainerType", SqlDbType.NVarChar, 5)
                    param(5).Direction = ParameterDirection.Output
                    param(6) = New SqlParameter("@SiteCode", SqlDbType.NVarChar)

                    param(0).Value = strTrxNo
                    param(1).Value = strLineitemno
                    param(2).Value = strContainerNo
                    param(6).Value = objUser.SiteCode
                    ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_Release", param)
                Catch ex As Exception
                    intResult = -1
                End Try
                If ds IsNot Nothing Then
                    InsertFlag = param(3).Value
                    msg = param(4).Value.ToString
                    If InsertFlag = "y" Then
                        valContainerType = param(5).Value.ToString
                        If (valContainerType <> hidEquipmentType.Value) Then
                            Return "1" + ConSeparator.Par + SenondCon + ConSeparator.Par + "Container Type is invalid." + ConSeparator.Par + objContainerNo + ConSeparator.Par + ContainerType
                        End If
                        Return "0" + ConSeparator.Par + SenondCon + ConSeparator.Par + "" + ConSeparator.Par + objContainerNo + ConSeparator.Par + ContainerType
                    Else
                        Return "1" + ConSeparator.Par + SenondCon + ConSeparator.Par + msg + ConSeparator.Par + objContainerNo + ConSeparator.Par + ContainerType
                    End If
                End If
            End If
        End If
        Return "1" + ConSeparator.Par + SenondCon + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + objContainerNo + ConSeparator.Par + ContainerType
    End Function

    Public Function RO2SaveOne(ByVal strFile As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal strContainerNO As String, ByVal TruckerName As String, ByVal VehicleNo As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        End If
        Dim strMsg As String = ""
        If TruckerName.Trim = "" Then
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Trucker Name is mandatory."
        End If
        If VehicleNo.Trim = "" Then
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Vehicle No is mandatory."
        End If
        Dim Flag As Integer = InsertRC(strFile)
        If Flag > 0 Then
            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
        Else
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false."
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function

    Private Function InsertRC(ByRef strFile As String) As Integer
        Dim intResult As Integer = -1
        Try
            If strFile.Trim <> "" Then
                Dim strSql As String = "insert into ctro2(TrxNo,LineItemNo,ContainerNo,TruckerName,VehicleNo,SealNo,DGFlag,DriverPassNo,EquipmentType,ReleaseRemarks) values " + strFile
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            End If
        Catch ex As Exception
            intResult = -1
        End Try
        Return intResult
    End Function

    Public Function CTRO2Update(ByVal strsql As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal strContainerNO As String, ByVal strCurrentControl As String, ByVal strUpdate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt, dt2, dt3 As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strContainerNO.ToString <> "" Then
                strsql = strsql.Replace("ContainerType", "EquipmentType")
                If strCurrentControl.IndexOf("txtContainerNo") > 0 Then
                    dt3 = BaseSelectSrvr.GetData("select ContainerNo from rccf1 where ContainerNo='" + strUpdate + "'", "")
                    If dt3.Rows.Count = 0 Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO not exist in Container Master!" + ConSeparator.Par + strCurrentControl
                    End If
                End If

                If strCurrentControl.IndexOf("TruckerName") > 0 Then
                    If strUpdate.Trim = "" Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Trucker Name is mandatory." + ConSeparator.Par + strCurrentControl
                    End If
                End If
                If strCurrentControl.IndexOf("VehicleNo") > 0 Then
                    If strUpdate.Trim = "" Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Vehicle No is mandatory." + ConSeparator.Par + strCurrentControl
                    End If
                End If

                If strCurrentControl.IndexOf("DGFlag") > 0 Then
                    If strUpdate.Trim <> "" And strUpdate.Trim <> "N" And strUpdate.Trim <> "Y" Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Please enter either 'Y' or 'N' for DG Flag." + ConSeparator.Par + strCurrentControl
                    End If
                End If

                dt = BaseSelectSrvr.GetData("select * from ctro2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineitemno + " and ContainerNO='" + strContainerNO + "'", "")
                dt2 = BaseSelectSrvr.GetData("select * from ctro2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineitemno + " and ContainerNO='" + strUpdate + "'", "")
                If dt.Rows.Count <= 1 Then
                    If dt.Rows.Count = 1 And strCurrentControl.IndexOf("txtContainerNo") > 0 And dt2.Rows.Count = 1 Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!" + ConSeparator.Par + strCurrentControl
                    End If
                    Dim intflag As String
                    intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
                    If intflag = 1 Then
                        'New Object 
                        objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + strCurrentControl
                    Else
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + strCurrentControl
                    End If
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!" + ConSeparator.Par + strCurrentControl
                End If
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + strCurrentControl
    End Function

    Public Function DeleteCTRO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByVal strContainerNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not FDeleteCTRO2(strTrxNo, strLineItemNo, strContainerNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                'New Object 
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                'Omtx3 Details...
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function FDeleteCTRO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByVal strContainerNo As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        Dim intResult As Integer
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try

                Dim param(2) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                param(0).Value = strTrxNo
                param(1).Value = strLineItemNo
                param(2).Value = strContainerNo
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_ctro2", param)
                If intResult > 0 Then
                    'New Object 
                    objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
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

    Public Function InsertCTCE(ByVal strFields As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        End If
        Dim intResult As Integer = -1
        If strFields <> "" Then
            Dim arr As String() = strFields.Split("#")
            Dim ds As DataSet = Nothing
            Dim InsertFlag As String = ""
            Dim ConRelease As String = ""
            Dim ConDate As String = ""
            Dim ReleaseDate As Date = GeneralFun.StringToDate("1890-01-01")
            For Each strs As String In arr
                If strs.Length > 4 Then
                    strs = strs.Substring(0, strs.Length - 1)
                    Dim strFie As String() = strs.Split(",")
                    Dim strTrxNO As String = strFie(0)
                    Dim strLineItemNo As String = strFie(1)
                    Dim strContainerNo As String = strFie(2)
                    Dim strReleaseDate As String = strFie(3)
                    Dim param(8) As SqlParameter
                    Try
                        param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                        param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                        param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                        param(3) = New SqlParameter("@ReleaseDate", SqlDbType.DateTime)
                        param(4) = New SqlParameter("@InsertFlag", SqlDbType.NVarChar, 1)
                        param(4).Direction = ParameterDirection.Output
                        param(5) = New SqlParameter("@ConRelease", SqlDbType.NVarChar, 13)
                        param(5).Direction = ParameterDirection.Output
                        param(6) = New SqlParameter("@ConDate", SqlDbType.NVarChar, 13)
                        param(6).Direction = ParameterDirection.Output
                        param(7) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)
                        param(8) = New SqlParameter("@logSiteCode", SqlDbType.NVarChar)
                        param(0).Value = strTrxNO
                        param(1).Value = strLineItemNo
                        param(2).Value = strContainerNo
                        param(3).Value = GeneralFun.StringToDate(strReleaseDate)
                        ReleaseDate = GeneralFun.StringToDate(strReleaseDate)
                        param(7).Value = objUser.UserId
                        param(8).Value = objUser.SiteCode
                        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctcl1_Release", param)
                    Catch ex As Exception
                        intResult = -2
                    End Try
                    InsertFlag = param(4).Value.ToString
                    If param(5).Value.ToString <> "" Then
                        If InsertFlag <> "r" Then
                            ConRelease += param(5).Value.ToString + vbNewLine
                        End If
                    End If
                    If param(6).Value.ToString <> "" Then
                        If InsertFlag <> "r" Then
                            ConDate += param(6).Value.ToString + vbNewLine
                        End If
                    End If
                End If
            Next
            'If ConRelease = "" And ConDate = "" Then
            If ConDate = "" And ConRelease = "" And intResult <> -2 Then
                'Try
                '    Dim intResult2 As Integer
                '    intResult2 = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure())
                'Catch ex As Exception
                'End Try
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success"
            Else
                If ConRelease <> "" Then
                    ConRelease = "Containers (listed below) last event is not Depot In. Please Depot In this container before release." + vbNewLine + ConRelease
                End If
                If ConDate <> "" Then
                    ConDate = "Containers (listed below) Release Date must be later than " + ReleaseDate.ToString("dd-MMM-yyyy HH:mm") + "." + vbNewLine + ConDate
                    'ConRelease = ConRelease + vbNewLine + ConDate
                End If
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConRelease + ConDate
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function

#End Region

End Class
