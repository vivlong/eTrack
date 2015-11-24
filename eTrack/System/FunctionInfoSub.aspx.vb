Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Imports SysMagic

Partial Class FunctionInfoSub
    Inherits ListEditPage
    Private objServer As clsFunctionInfoSub
    Private RvFlag As String = "N"
    Private PubReceiveBatchNo As String = ""
    Protected ConfigPath As String
    Protected ExportConfig As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub  'Inherits System.Web.UI.Page
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsFunctionInfoSub(intUserId)
    End Function
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            hidBatchNo.Value = ""
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            If Not (Request("Id") Is Nothing) Then
                hidBatchNo.Value = Request("Id").ToString
                Me.Title += " : " + hidBatchNo.Value
                ' RvFlag = checkReceive(hidBatchNo.Value, RvFlag)
            Else
                'CreateReceiveBatchNo()
            End If

            Dim strFun As String = PageFun.GetFunNo(Page)
            objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'DateTime Event'
            ' btnSave.Attributes.Add("OnClick", "RceiveContainer();return false;")
            'btnCancel.Attributes.Add("OnClick", "CloseWindow(0);return false;")

            'btnReceivedDate.Attributes.Add("OnClick", "showCalendar(txtReceivedDate,0);return false;")
            '  btnReceivedDate.Attributes.Add("OnClick", "WdatePicker({el:'txtReceivedDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            '    txtReceivedDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtReceivedDate.ClientID + "');return false;")
            '  txtReceivedDate.Attributes.Add("onblur", "ChangeLongDate('" + txtReceivedDate.ClientID + "');return false;")
            'Language 
            HandleLanguageRelative()
            If RvFlag = "Y" Then
                btnSave.Attributes.Add("OnClick", "return false;")
            End If
        End If
    End Sub
    'Function checkReceive(ByVal BatchNo As String, ByVal RvVal As String) As String
    '    Dim dt As DataTable
    '    Try
    '        dt = BaseSelectSrvr.GetData("select RvFlag from ctso2 where ReceiveBatchNo ='" + BatchNo + "'", "")
    '        If dt.Rows.Count > 0 Then
    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                If (dt.Rows(0)(0).ToString = "Y") Then
    '                    Return "Y"
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Return "N"
    'End Function

#Region "Grid View FunctionInfoSub"

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)
        objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
        intPageIndex = intPage
        objList.Where = ""
        objList.GetListInfo(intPage, 0)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsFunctionInfoSub(intUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "FI"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "sFunNo"
        Me.SortDesc = True
    End Sub

    Private Sub HandleLanguageRelative()
        'Dim strReg As String = GetJavascriptLanguageConst().Replace("EditWidth=", "EditWidth=null").Replace("EditHeight=", "EditHeight=null")
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", strReg)
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If RvFlag = "Y" Then
            e.Row.Cells(0).Style.Add("display", "none")
        End If

        If e.Row.RowType = DataControlRowType.Header Then

            'Dim Im As New Image
            'Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            'Im.Attributes.Add("OnClick", "AddToSO2();return false;")
            'e.Row.Cells(0).Style.Add("text-align", "center")
            'e.Row.Cells(0).Style.Add("width", "20px")
            'e.Row.Cells(0).Controls.Add(Im)

        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim intTrxNo As String = CType(tmpProp, clsPropFunctionInfoSub).sFunNo.ToString

            If intTrxNo = "-1" Then
                e.Row.Cells(0).Controls.Clear()

            End If
            If RvFlag = "Y" Then
                If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                    e.Row.Style.Add("display", "none")
                End If
            End If
        End If
    End Sub

    Protected Sub gvwSource_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.DataBound
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim i As Integer
            'Dim intReceiveFlag As Integer
            Dim backcolor As Color = System.Drawing.Color.FromArgb(230, 239, 248)
            For i = 0 To gvwSource.Rows.Count - 1
                '    '---------------List Control-------------------------------------------------------------------------
                Dim Img2 As HtmlControls.HtmlAnchor = gvwSource.Rows(i).FindControl("Img2")
                '------1
                ' Dim HidContainerNo As HiddenField = gvwSource.Rows(i).FindControl("HidContainerNo")
                Dim hid_sFunNo As HiddenField = gvwSource.Rows(i).FindControl("hid_sFunNo")
                Dim hid_lSubId As HiddenField = gvwSource.Rows(i).FindControl("hid_lSubId")
                '    Dim strReceiveFlag As HiddenField = gvwSource.Rows(i).FindControl("HidReceiveFlag")

                Dim txtsFunNo As TextBox = gvwSource.Rows(i).FindControl("txtsFunNo")
                Dim txtlSubId As TextBox = gvwSource.Rows(i).FindControl("txtlSubId")             '------3
                Dim txtsCode As TextBox = gvwSource.Rows(i).FindControl("txtsCode")                 '------4
                Dim txtsName As TextBox = gvwSource.Rows(i).FindControl("txtsName") '------5
                Dim txtbFlag As TextBox = gvwSource.Rows(i).FindControl("txtbFlag")         '------6
                Dim txtSubType As TextBox = gvwSource.Rows(i).FindControl("txtSubType")  
                Dim strsFunNo As String = txtsFunNo.Text
                Dim strlSubId As String = txtlSubId.Text
                Dim strsCode As String = txtsCode.Text
                Dim strsName As String = txtsName.Text
                Dim strbFlag As String = txtbFlag.Text
                Dim strSubType As String = txtSubType.Text
                If i Mod 2 = 1 Then
                    txtsFunNo.BackColor = backcolor
                    txtlSubId.BackColor = backcolor
                    txtsCode.BackColor = backcolor
                    txtsName.BackColor = backcolor
                    txtbFlag.BackColor = backcolor
                    txtSubType.BackColor = backcolor
                End If

                '    Dim strTrxNoLineitemno As String = hid_LineItemNo.Value
                '    Dim strContainer As String = HidContainerNo.Value
                '    If txtContainerType.Text.Trim = "" Then
                '        txtContainerType.Text = "EMPTY"
                '    End If
                '    If intReceiveFlag > 0 Then
                '        txtContainerNo.ReadOnly = True
                '        txtContainerType.ReadOnly = True
                '        txtTruckerName.ReadOnly = True
                '        txtVehicleNo.ReadOnly = True
                '        txtCollectionRemarks.ReadOnly = True
                '        txtSurveyRemarks.ReadOnly = True
                '        txtDetentionChg.ReadOnly = True
                '    End If
                '    'Set deleteButton
                If gvwSource.Rows(i).Cells(0).Controls.Count <> 0 Then
                    If fldId.Value <> "-1" Then
                        Img2.Attributes.Add("onclick", "DeleteFI(" + strsFunNo + ",'" + strlSubId + "');return false;")
                        '            'ForUpdate 

                        ' txtsFunNo.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','" + strlSubId + "','sFunNo'," + txtsFunNo.ClientID + ",'" + strContainer + "')") '---1
                        ' txtlSubId.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','""','lSubId'," + txtlSubId.ClientID + ",'""')") '---3
                        txtsCode.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','" + strlSubId + "','sCode'," + txtsCode.ClientID + ")") '---5
                        txtsName.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','" + strlSubId + "','sName'," + txtsName.ClientID + ")") '---6
                        txtbFlag.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','" + strlSubId + "','bFlag'," + txtbFlag.ClientID + ")") '---7
                        txtSubType.Attributes.Add("onchange", "UpdateValue('" + strsFunNo + "','" + strlSubId + "','SubType'," + txtSubType.ClientID + ")") '---10
                      
                    End If
                Else
                    '        txtState.Style.Add("display", "none")
                    '        txtContainerType.Style.Add("display", "none")
                    If RvFlag <> "Y" Then
                        Dim Im As New Image
                        Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
                        Im.Attributes.Add("OnClick", "AddToFI();return false;")
                        gvwSource.Rows(i).Cells(0).Style.Add("text-align", "center")
                        gvwSource.Rows(i).Cells(0).Style.Add("width", "20px")
                        gvwSource.Rows(i).Cells(0).Controls.Add(Im)
                    End If
                End If
                txtsFunNo.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtsFunNo.ClientID + "," + txtlSubId.ClientID + ");")
                txtlSubId.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtsFunNo.ClientID + "," + txtsCode.ClientID + ");")
                txtsCode.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtlSubId.ClientID + "," + txtsName.ClientID + ");")
                txtsName.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtsCode.ClientID + "," + txtbFlag.ClientID + ");")
                txtbFlag.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtsName.ClientID + "," + txtSubType.ClientID + ");")
                txtSubType.Attributes.Add("OnKeyUp", "FocusControlSO(event," + txtbFlag.ClientID + "," + txtSubType.ClientID + ");")
                If txtsFunNo.Text <> "-1" Then
                    txtsFunNo.ReadOnly = True
                End If

            Next
        End If
    End Sub


    Private Function UpdateFI(ByRef strFile As String, ByRef strWhere As String) As Integer
        Dim intResult As Integer = -1
        Try
            If strFile.Trim <> "" Then
                Dim strSql As String = " update Function set " + strFile + " where 1=1 " + strWhere
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            End If
        Catch ex As Exception
            intResult = -1
        End Try
        Return intResult
    End Function

    Public Function FIUpdate(ByVal strsql As String, ByVal strsFunNo As String, ByVal strlSubId As String, ByVal strCurrentControl As String, ByVal strUpdate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        'Dim dt, dt2 As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then

            If strsql <> "" Then

                Dim intflag As String
                strsql = " update FunctionInfoSub set " + strsql + " where sFunNo='" + strsFunNo + "' and lSubId='" + strlSubId + "'"
                intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
                If intflag = 1 Then
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + strCurrentControl '+ ConSeparator.Par + strContainerNO
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + strCurrentControl   ' + ConSeparator.Par + strContainerNO
                End If

            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + strCurrentControl
    End Function


    Public Function DeleteFI(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not FDeleteFI(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Private Function FDeleteFI(ByVal strsFunNo As String, ByVal strlSubId As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete FunctionInfoSub where sFunNo='" + strsFunNo + "' and lSubId='" + strlSubId + "'"
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
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


    Public Function InsertFIS(ByVal strFields As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim intResult As Integer = -1
        If strFields <> "" Then
            Dim arr As String() = strFields.Split("#")

            For Each strs As String In arr
                If strs.Length > 3 Then
                    Dim strFie As String() = strs.Split(",")
                    Dim strsFunNo As String = strFie(0)
                    Dim strlSubId As String = strFie(1)
                    Dim strsCode As String = strFie(2)
                    Dim strsName As String = strFie(3)
                    Dim strbFlag As Boolean = strFie(4)
                    Dim strSubType As String = strFie(5)
                    Dim dt As DataTable
                    If strsFunNo = "" Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "sFunNo is mandatory." + ConSeparator.Par + ""

                    End If
                    dt = BaseSelectSrvr.GetData("select lSubId,sCode from FunctionInfoSub where sFunNo='" + strsFunNo + "' and lSubId='" + strlSubId + "'", "")
                    If dt.Rows.Count <> 0 Then
                        'Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as Storing Order has not been created for this container." + ConSeparator.Par + ""
                        ' Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "sFunNo " + strsFunNo + " already exist." + ConSeparator.Par + ""
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "This sFunNo already exist."
                    Else
                    End If
                    Dim param(5) As SqlParameter
                    Try
                        param(0) = New SqlParameter("@sFunNo", SqlDbType.NVarChar, 10)
                        param(1) = New SqlParameter("@lSubId", SqlDbType.Int)
                        param(2) = New SqlParameter("@sCode", SqlDbType.NVarChar, 20)
                        param(3) = New SqlParameter("@sName", SqlDbType.NVarChar, 50)
                        param(4) = New SqlParameter("@bFlag", SqlDbType.Bit)
                        param(5) = New SqlParameter("@SubType", SqlDbType.NVarChar, 1)

                        param(0).Value = strsFunNo
                        param(1).Value = strlSubId
                        param(2).Value = strsCode
                        param(3).Value = strsName
                        param(4).Value = strbFlag
                        param(5).Value = strSubType

                        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_Track_FunctionInfoSub", param)
                        'intResult = 1
                    Catch ex As Exception
                        intResult = -1
                    End Try

                End If
            Next
            'If ConRelease = "" And ConDate = "" Then
            If intResult <> -1 Then

                'Dim strFun As String = PageFun.GetFunNo(Page)
                'objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
                ' BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
                ' Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success"
            Else

                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save False"
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function

#End Region


End Class
