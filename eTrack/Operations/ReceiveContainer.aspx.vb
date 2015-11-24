Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Imports Ntools
Imports SysMagic

Partial Class ReceiveContainer
    Inherits ListEditPage
    Private objServer As clsSO2
    Private RvFlag As String = "N"
    Private PubReceiveBatchNo As String = ""
    Protected ConfigPath As String
    Protected ExportConfig As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsSO2(intUserId)
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsSO2(strUserId, RoleName, strFunNo)
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
            If Not (Request("Id") Is Nothing) Then
                hidBatchNo.Value = Request("Id").ToString
                Me.Title += " : " + hidBatchNo.Value
                RvFlag = checkReceive(hidBatchNo.Value, RvFlag)
            Else
                'CreateReceiveBatchNo()
            End If
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'DateTime Event'
            btnSave.Attributes.Add("OnClick", "RceiveContainer();return false;")
            'btnCancel.Attributes.Add("OnClick", "CloseWindow(0);return false;")
            btnPrintReceipt.Attributes.Add("OnClick", "return false;")
            'btnReceivedDate.Attributes.Add("OnClick", "showCalendar(txtReceivedDate,0);return false;")
            btnReceivedDate.Attributes.Add("OnClick", "WdatePicker({el:'txtReceivedDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            txtReceivedDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtReceivedDate.ClientID + "');return false;")
            txtReceivedDate.Attributes.Add("onblur", "ChangeLongDate('" + txtReceivedDate.ClientID + "');return false;")
            'Language 
            HandleLanguageRelative()
            If RvFlag = "Y" Then
                btnSave.Attributes.Add("OnClick", "return false;")
            End If
        End If
    End Sub
    Function checkReceive(ByVal BatchNo As String, ByVal RvVal As String) As String
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select RvFlag from ctso2 where ReceiveBatchNo ='" + BatchNo + "'", "")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If (dt.Rows(0)(0).ToString = "Y") Then
                        Return "Y"
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
        Return "N"
    End Function

#Region "Grid View RO"

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)
        objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
        intPageIndex = intPage
        objList.Query = "ReleaseContainer"
        If PubReceiveBatchNo = "" Then
            objList.Where = " and isnull(a.ReceiveBatchNo,'')='" + hidBatchNo.Value + "' and isnull(a.ReceiveBatchNo,'')!='' "
        Else
            objList.Where = " and isnull(a.ReceiveBatchNo,'')='" + PubReceiveBatchNo + "' and isnull(a.ReceiveBatchNo,'')!='' "
        End If
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
        'Dim strReg As String = GetJavascriptLanguageConst().Replace("EditWidth=", "EditWidth=null").Replace("EditHeight=", "EditHeight=null")
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", strReg)
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If RvFlag = "Y" Then
            e.Row.Cells(0).Style.Add("display", "none")
        End If
        If e.Row.RowType = DataControlRowType.Header Then

            Dim Im As New Image
            Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            Im.Attributes.Add("OnClick", "AddToSO2();return false;")
            e.Row.Cells(0).Style.Add("text-align", "center")
            e.Row.Cells(0).Style.Add("width", "20px")
            e.Row.Cells(0).Controls.Add(Im)

        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim intTrxNo As String = CType(tmpProp, clsPropSO2).TrxNo.ToString
            Dim intReceiveFlag As Integer = CType(tmpProp, clsPropSO2).ReceiveFlag
            If intReceiveFlag > 0 Then
                'Delete
                Dim imgDelete As HtmlControls.HtmlAnchor = CType(e.Row.FindControl("Img2"), HtmlControls.HtmlAnchor)
                imgDelete.Style.Add("display", "none")
            End If
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
            Dim intReceiveFlag As Integer
            For i = 0 To gvwSource.Rows.Count - 1
                '---------------List Control-------------------------------------------------------------------------
                Dim Img2 As HtmlControls.HtmlAnchor = gvwSource.Rows(i).FindControl("Img2")
                Dim txtContainerNo As TextBox = gvwSource.Rows(i).FindControl("txtContainerNo")             '------1
                Dim HidContainerNo As HiddenField = gvwSource.Rows(i).FindControl("HidContainerNo")
                Dim hid_TrxNo As HiddenField = gvwSource.Rows(i).FindControl("hid_TrxNo")
                Dim hid_LineItemNo As HiddenField = gvwSource.Rows(i).FindControl("hid_LineItemNo")
                Dim strReceiveFlag As HiddenField = gvwSource.Rows(i).FindControl("HidReceiveFlag")
                intReceiveFlag = Integer.Parse(strReceiveFlag.Value)
                Dim lblPOD As TextBox = gvwSource.Rows(i).FindControl("lblPOD")                             '------2
                Dim txtTruckerName As TextBox = gvwSource.Rows(i).FindControl("txtTruckerName")             '------3
                Dim txtVehicleNo As TextBox = gvwSource.Rows(i).FindControl("txtVehicleNo")                 '------4
                Dim txtCollectionRemarks As TextBox = gvwSource.Rows(i).FindControl("txtCollectionRemarks") '------5
                Dim txtSurveyRemarks As TextBox = gvwSource.Rows(i).FindControl("txtSurveyRemarks")         '------6
                Dim txtDetentionChg As TextBox = gvwSource.Rows(i).FindControl("txtDetentionChg")           '------7
                Dim txtCDC As TextBox = gvwSource.Rows(i).FindControl("txtCDC")                             '------8
                Dim txtState As Label = gvwSource.Rows(i).FindControl("txtState")                         '------9
                Dim drState As DropDownList = gvwSource.Rows(i).FindControl("drState")                      '------9
                Dim txtContainerType As TextBox = gvwSource.Rows(i).FindControl("txtContainerType")         '------10
                Dim drContainerType As DropDownList = gvwSource.Rows(i).FindControl("drContainerType")      '------10
                Dim strTrxNo As String = hid_TrxNo.Value
                Dim strLineitemno As String = hid_LineItemNo.Value
                Dim strTrxNoLineitemno As String = hid_LineItemNo.Value
                Dim strContainer As String = HidContainerNo.Value
                If txtContainerType.Text.Trim = "" Then
                    txtContainerType.Text = "EMPTY"
                End If
                If intReceiveFlag > 0 Then
                    txtContainerNo.ReadOnly = True
                    txtContainerType.ReadOnly = True
                    txtTruckerName.ReadOnly = True
                    txtVehicleNo.ReadOnly = True
                    txtCollectionRemarks.ReadOnly = True
                    txtSurveyRemarks.ReadOnly = True
                    txtDetentionChg.ReadOnly = True
                End If
                'Set deleteButton
                If gvwSource.Rows(i).Cells(0).Controls.Count <> 0 Then
                    If fldId.Value <> "-1" Then
                        Img2.Attributes.Add("onclick", "DeleteCTSO2(" + strTrxNo + "," + strLineitemno + ");return false;")
                        'ForUpdate 
                        If intReceiveFlag > 0 Then  'For DropDownList  Show TextBox Hide DropDownList
                            drState.Style.Add("display", "none")
                            drContainerType.Style.Add("display", "none")
                        Else ' Show DropDownList Hide TextBox
                            txtState.Style.Add("display", "none")
                            txtContainerType.Style.Add("display", "none")
                            drState.Attributes.Add("onchange", "DropDownUpdate(" + drState.ClientID + ",'State')")
                            drContainerType.Attributes.Add("onchange", "DropDownUpdate(" + drContainerType.ClientID + ",'ContainerType')")
                            'txtState
                            If txtState.Text.Trim = "" Then
                                txtState.Text = "Available"
                                drState.SelectedValue = "AV"
                            Else
                                drState.SelectedValue = txtState.Text
                            End If
                            'txtContainerType
                            If txtContainerType.Text.Trim = "" Then
                                txtContainerType.Text = "Empty"
                                drContainerType.SelectedValue = "MT"
                            Else
                                drContainerType.SelectedValue = txtContainerType.Text
                            End If
                        End If
                        txtContainerType.Text = tool.showContainerName(txtContainerType.Text)
                        txtState.Text = tool.showState(txtState.Text)
                        'onchange
                        txtContainerNo.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','ContainerNo'," + txtContainerNo.ClientID + ",'" + strContainer + "')") '---1
                        txtTruckerName.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','TruckerName'," + txtTruckerName.ClientID + ",'" + strContainer + "')") '---3
                        txtVehicleNo.Attributes.Add("onchange", "if(this.value==''){alert('Vehicle No is mandatory.'); this.focus(); return false;}UpdateValue('" + strTrxNo + "','" + strLineitemno + "','VehicleNo'," + txtVehicleNo.ClientID + ",'" + strContainer + "')") '---4
                        txtCollectionRemarks.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','CollectionRemarks'," + txtCollectionRemarks.ClientID + ",'" + strContainer + "')") '---5
                        txtSurveyRemarks.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','SurveyRemarks'," + txtSurveyRemarks.ClientID + ",'" + strContainer + "')") '---6
                        txtDetentionChg.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','ActualDetentionCharge'," + txtDetentionChg.ClientID + ",'" + strContainer + "')") '---7
                        txtContainerType.Attributes.Add("onchange", "UpdateValue('" + strTrxNo + "','" + strLineitemno + "','ContainerType'," + txtContainerType.ClientID + ",'" + strContainer + "')") '---10
                    End If
                Else
                    txtState.Style.Add("display", "none")
                    txtContainerType.Style.Add("display", "none")
                    If RvFlag <> "Y" Then
                        drContainerType.Attributes.Add("OnKeyDown", "EnterAddCtso2()")
                    End If
                End If
                txtContainerNo.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtContainerNo.ClientID + "," + txtTruckerName.ClientID + ");")
                txtTruckerName.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtTruckerName.ClientID + "," + txtVehicleNo.ClientID + ");")
                txtVehicleNo.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtVehicleNo.ClientID + "," + txtCollectionRemarks.ClientID + ");")
                txtCollectionRemarks.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtCollectionRemarks.ClientID + "," + txtSurveyRemarks.ClientID + ");")
                txtSurveyRemarks.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtSurveyRemarks.ClientID + "," + txtDetentionChg.ClientID + ");")
                txtDetentionChg.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtDetentionChg.ClientID + "," + txtCDC.ClientID + ");")
                If intReceiveFlag > 0 Then 'for dropdown
                    txtCDC.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtCDC.ClientID + "," + txtContainerType.ClientID + ");")
                Else
                    txtCDC.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtCDC.ClientID + "," + drState.ClientID + ");")
                    drState.Attributes.Add("OnKeyDown", "FocusControlSO(event," + drState.ClientID + "," + drContainerType.ClientID + ");")
                End If
                If i < gvwSource.Rows.Count - 1 Then
                    Dim txtNextContainerNo As TextBox = gvwSource.Rows(i + 1).FindControl("txtContainerNo")
                    If intReceiveFlag > 0 Then
                        txtContainerType.Attributes.Add("OnKeyDown", "FocusControlSO(event," + txtContainerType.ClientID + "," + txtNextContainerNo.ClientID + ");")
                    Else
                        drContainerType.Attributes.Add("OnKeyDown", "FocusControlSO(event," + drContainerType.ClientID + "," + txtNextContainerNo.ClientID + ");")
                    End If
                    If i = gvwSource.Rows.Count - 2 Then
                        If RvFlag = "Y" Then
                            txtContainerType.Attributes.Add("OnKeyDown", "return false;")
                        End If
                    End If
                Else
                    If RvFlag <> "Y" Then
                        txtContainerNo.Attributes.Add("OnKeyDown", "CheckContainerNo(event," + txtContainerNo.ClientID + "," + txtTruckerName.ClientID + "," + lblPOD.ClientID + ",'" + objUser.UpperCase + "');")
                    End If
                End If
                txtDetentionChg.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
                txtDetentionChg.Attributes.Add("OnBlur", "NumberBlur(2,true);")
                txtDetentionChg.Attributes.Add("OnKeypress", "NumberInput(event,2);")
                If objUser.UpperCase = "y" Then
                    setUpperCase(txtContainerNo)
                    setUpperCase(txtTruckerName)
                    setUpperCase(txtVehicleNo)
                    setUpperCase(txtCollectionRemarks)
                    setUpperCase(txtSurveyRemarks)
                End If
            Next
        End If
    End Sub

    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");")
    End Sub

    Public Function DropDownUpdate(ByRef TrxNo As String, ByRef LineItemNo As String, ByRef Value As String, ByRef sField As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strFile As String = sField + " ='" + Value + "' "
            Dim strWhere As String = " and TrxNo=" + TrxNo + " and LineItemNO=" + LineItemNo
            Dim Flag As Integer = UpdateSO2(strFile, strWhere)
            If Flag > 0 Then
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false"
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function

    Public Function SO2SaveOne(ByVal strContainerNo As String, ByVal strFile As String, ByVal ReceiveBatchNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            dt = BaseSelectSrvr.GetData("select TrxNo,LineItemNo from ctso2 where ContainerNO='" + strContainerNo + "' and isnull(ReceiveBatchNo,'')='' and TrxNo in (select TrxNo from ctso1 where SiteCode='" + objUser.SiteCode + "') ", "")
            If dt.Rows.Count = 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as Storing Order has not been created for this container." + ConSeparator.Par + ""
            Else
                Dim strLineItemNo, strTrxNo, strWhere As String
                strTrxNo = dt.Rows(0)("TrxNo").ToString
                If strTrxNo = "" Then
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as Storing Order has not been created for this container." + ConSeparator.Par + ""
                End If
                strLineItemNo = dt.Rows(0)("LineItemNo").ToString
                strWhere = " and TrxNo=" + strTrxNo
                strWhere += " and LineItemNo=" + strLineItemNo
                If ReceiveBatchNo = "" Then
                    CreateReceiveBatchNo()
                    ReceiveBatchNo = hidBatchNo.Value
                End If
                PubReceiveBatchNo = ReceiveBatchNo
                strFile = strFile.Replace("ReceiveBatchNo", "ReceiveBatchNo='" + ReceiveBatchNo + "'")
                Dim Flag As Integer = UpdateSO2(strFile, strWhere)
                If Flag > 0 Then
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + ReceiveBatchNo
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + ""
                End If
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + ""
        Return ""
    End Function

    Private Function UpdateSO2(ByRef strFile As String, ByRef strWhere As String) As Integer
        Dim intResult As Integer = -1
        Try
            If strFile.Trim <> "" Then
                Dim strSql As String = " update ctso2 set " + strFile + " where 1=1 " + strWhere
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            End If
        Catch ex As Exception
            intResult = -1
        End Try
        Return intResult
    End Function

    Public Function CTSO2Update(ByVal strsql As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal strContainerNO As String, ByVal strCurrentControl As String, ByVal strUpdate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt, dt2 As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strContainerNO.ToString <> "" Then
                If strCurrentControl.IndexOf("txtContainerNo") > 0 And strContainerNO = strUpdate Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "" + ConSeparator.Par + "" + ConSeparator.Par + ""
                End If
                dt = BaseSelectSrvr.GetData("select * from ctso2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineitemno + " and ContainerNO='" + strContainerNO + "'", "")
                dt2 = BaseSelectSrvr.GetData("select * from ctso2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineitemno + " and ContainerNO='" + strUpdate + "'", "")
                If dt.Rows.Count <= 1 Then
                    If dt.Rows.Count = 1 And strCurrentControl.IndexOf("txtContainerNo") > 0 And dt2.Rows.Count = 1 Then
                        Dim strSql2 As String = "select ContainerNo from rccf1 where ContainerNo='" + strUpdate + "'"
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNO + " as this container has already been added to Releasing Order " + dt.Rows(0)("ReceiveDate").ToString + "." + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
                    End If
                    If strCurrentControl.IndexOf("txtContainerNo") > 0 Then
                        dt = BaseSelectSrvr.GetData("select * from ctso2 where ContainerNO='" + strUpdate + "' and isnull(ReceiveBatchNo,'')='' and TrxNo!=-1 ", "")
                        If dt.Rows.Count = 0 Then
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNO + " as Storing Order has not been created for this container." + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
                        End If
                    End If
                    Dim intflag As String
                    intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
                    If intflag = 1 Then
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
                    Else
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
                    End If
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container No is mandatory." + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
                End If
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
    End Function

    'Private Function InsertSO2(ByRef TrxNo As String, ByVal LineItemNo As String, ByVal ReceiveBatchNo As String, ByVal ContainerNo As String) As Integer
    '    Dim intResult As Integer = -1
    '    Try
    '        Dim param(3) As SqlParameter
    '        param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
    '        param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
    '        param(2) = New SqlParameter("@ReceiveBatchNo", SqlDbType.NVarChar, 20)
    '        param(3) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
    '        param(0).Value = TrxNo
    '        param(1).Value = LineItemNo
    '        param(2).Value = hidBatchNo.Value
    '        param(3).Value = ContainerNo
    '        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctso2", param)
    '    Catch ex As Exception
    '        intResult = -1
    '        Return False
    '    End Try
    '    Return intResult
    'End Function

    Public Function DeleteCTSO2(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not FDeleteCTSO2(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Private Function FDeleteCTSO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete ctso2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineItemNo
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

    Private Function getLineItemNo(ByVal strTrxNo As String) As String
        Dim strLineItemNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(LineItemNo)+1 as LineItemNo from ctso2 where TrxNo=" + strTrxNo, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("LineItemNo").ToString.Trim <> "" Then
                        strLineItemNo = dt.Rows(0)("LineItemNo").ToString.Trim
                    Else
                        strLineItemNo = 1
                    End If
                End If
            End If
            If strLineItemNo <> "" Then
                Return strLineItemNo
            Else
                Return "1"
            End If
        Catch ex As Exception
            Return "1"
        End Try
    End Function

    Public Function InsertCTCE(ByVal strFields As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim intResult As Integer = -1
        If strFields <> "" Then
            Dim arr As String() = strFields.Split("#")
            Dim ds As DataSet = Nothing
            Dim InsertFlag As String = ""
            Dim ConRelease As String = ""
            Dim ConDate As String = ""
            Dim strReceivedDate As Date
            For Each strs As String In arr
                If strs.Length > 3 Then
                    Dim strFie As String() = strs.Split(",")
                    Dim strTrxNO As String = strFie(0)
                    Dim strLineItemNo As String = strFie(1)
                    Dim strContainerNo As String = strFie(2)
                    strReceivedDate = GeneralFun.StringToDate(strFie(3))
                    Dim param(9) As SqlParameter
                    Try
                        param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                        param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                        param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                        param(3) = New SqlParameter("@ReceiveDate", SqlDbType.DateTime)
                        param(4) = New SqlParameter("@InsertFlag", SqlDbType.NVarChar, 1)
                        param(4).Direction = ParameterDirection.Output
                        param(5) = New SqlParameter("@ConRelease", SqlDbType.NVarChar, 13)
                        param(5).Direction = ParameterDirection.Output
                        param(6) = New SqlParameter("@ConDate", SqlDbType.NVarChar, 13)
                        param(6).Direction = ParameterDirection.Output
                        param(7) = New SqlParameter("@SiteCode", SqlDbType.NVarChar, 5)
                        param(8) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)
                        param(9) = New SqlParameter("@CompanyNo", SqlDbType.NVarChar, 64)
                        param(0).Value = strTrxNO
                        param(1).Value = strLineItemNo
                        param(2).Value = strContainerNo
                        param(3).Value = strReceivedDate.ToString
                        param(7).Value = objUser.SiteCode
                        param(8).Value = objUser.UserId
                        param(8).Value = objUser.UserId
                        param(9).Value = objUser.CompNo
                        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctcl1_Receive", param)
                        intResult = 1
                    Catch ex As Exception
                        intResult = -1
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
            If ConDate = "" And ConRelease = "" Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success"
            Else
                If ConRelease <> "" Then
                    ConRelease = "Unable to receive containers (listed below) as they have not been Gate Out." + vbNewLine + ConRelease
                End If
                If ConDate <> "" Then
                    ConDate = "Unable to receive containers (listed below) as Receive Date must be later than the Release Date " + strReceivedDate.ToString("dd-MMM-yyyy HH:mm") + "." + vbNewLine + ConDate
                    'ConRelease = ConRelease + vbNewLine + ConDate
                End If
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConRelease + ConDate
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function

    Function CheckContainerNo(ByVal strContainerNo As String, ByVal ConTruckerName As String, ByVal ConContainerNo As String, ByVal conPOL As String, ByVal ReceivedDate As String) As String
        Dim objUser As clsUser = Nothing
        Dim TrxNo As String = ""
        Dim LineItemNo As String = ""
        Dim strsql As String = " "
        Dim intResult As Integer = -1
        Dim InsertFlag As String = ""
        Dim AddFlag As String = "N"
        Dim i As Integer
        'Dim ds As DataSet
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData("select TrxNo,LineItemNo,ContainerNo from ctso2 where ContainerNo='" + strContainerNo + "' and isnull(ReceiveBatchNo,'')=''", "")
            If dt.Rows.Count = 0 Then
                Return "1" + ConSeparator.Par + ConTruckerName + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as Storing Order has not been created for this container." + ConSeparator.Par + ConContainerNo + ConSeparator.Par + "" + ConSeparator.Par + ""
            Else
                For i = 0 To dt.Rows.Count - 1
                    TrxNo = dt.Rows(i)("TrxNo").ToString
                    LineItemNo = dt.Rows(i)("LineItemNo").ToString
                    strsql = " select SiteCode from ctso1 where SiteCode='" + objUser.SiteCode + "'  and TrxNo=" + TrxNo
                    Dim dtM As DataTable = BaseSelectSrvr.GetData(strsql, "")
                    If dtM.Rows.Count > 0 Then
                        AddFlag = "Y"
                        Exit For
                    End If
                Next
                If AddFlag = "N" Then
                    Return "1" + ConSeparator.Par + ConTruckerName + ConSeparator.Par + "Container No " + strContainerNo + " has a different Port Code as user. Please check Container Event Log for details." + ConSeparator.Par + ConContainerNo + ConSeparator.Par + "" + ConSeparator.Par + ""
                End If
                'If dt.Rows.Count = 0 Then
                'Else
                '    TrxNo = dt.Rows(0)("TrxNo").ToString
                '    dt = BaseSelectSrvr.GetData("select LineItemNo,ContainerNo from ctso2 where ContainerNo='" + strContainerNo + "' and isnull(ReceiveBatchNo,'')=''", "")
                '    LineItemNo = dt.Rows(0)("LineItemNo").ToString
                'End If
            End If
            strsql = "select TruckerName from ctso2 where ContainerNo='" + strContainerNo + "' and TrxNo=" + TrxNo
            dt = BaseSelectSrvr.GetData(strsql, "")
            If dt.Rows.Count > 0 Then
                Dim TruckerName As String = dt.Rows(0)(0).ToString
                Dim PortOfLoadingCode As String = ""
                'Dim addWhere As String = " SOTrxNo=" + TrxNo + " and SOLineItemNo=" + LineItemNo
                strsql = "select PortOfLoadingCode from ctso1 where TrxNo=" + TrxNo
                dt = BaseSelectSrvr.GetData(strsql, "")
                If dt.Rows.Count > 0 Then
                    PortOfLoadingCode = dt.Rows(0)(0).ToString
                End If
                Return "0" + ConSeparator.Par + ConTruckerName + ConSeparator.Par + TruckerName + ConSeparator.Par + ConContainerNo + ConSeparator.Par + conPOL + ConSeparator.Par + PortOfLoadingCode
            End If
        End If
        Return "1" + ConSeparator.Par + ConTruckerName + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + ConContainerNo + ConSeparator.Par + conPOL + ConSeparator.Par + ""
    End Function

#End Region

#Region "Create ConfirmOrder "
    Private Function ReturnNextNo(ByVal Sanm1TrxNo As String, ByVal fieNextNo As String, ByVal fieCycle As String) As String
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim strYear As String = Now.Date.Year.ToString
        Dim strNextNo As String = ""
        Select Case fieCycle
            Case "C"
                strNextNo = fieNextNo
                Dim newfieNextNo As Integer = Integer.Parse(fieNextNo) + 1
                Dim intDiff As Integer = fieNextNo.Length - newfieNextNo.ToString.Length
                Dim i As Integer
                Dim strZero As String = ""
                For i = 0 To intDiff - 1
                    strZero += "0"
                Next
                fieNextNo = strZero + newfieNextNo.ToString
                Dim strSql As String = " update sanm1 set NextNo ='" + fieNextNo + "'  where TrxNo=" + Sanm1TrxNo
                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            Case "M"
                Dim dtReclzw As DataTable
                Dim MthField As String = "Mth" + tool.addZero(Integer.Parse(Now.Date.Month.ToString)) + "NextNo"
                dtReclzw = BaseSelectSrvr.GetData("select top 1 " + MthField + " from sanm2 where TrxNo=" + Sanm1TrxNo + "  and Year= " + strYear, "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim strMth As String = dtReclzw.Rows(0)(MthField).ToString
                    strNextNo = strMth
                    Dim newMth As Integer = Integer.Parse(dtReclzw.Rows(0)(MthField)) + 1
                    Dim intDiff As Integer = strMth.Length - newMth.ToString.Length
                    Dim i As Integer
                    Dim strZero As String = ""
                    For i = 0 To intDiff - 1
                        strZero += "0"
                    Next
                    strMth = strZero + newMth.ToString
                    Dim strSql As String = " update sanm2 set " + MthField + "='" + strMth + "'  where TrxNo=" + Sanm1TrxNo + "  and Year= " + strYear
                    SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                End If
            Case "Y"
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 YearNextNo " & _
                " from sanm2 where TrxNo=" + Sanm1TrxNo + "  and Year= " + strYear + "", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim YearNextNo As String = dtReclzw.Rows(0)("YearNextNo").ToString
                    strNextNo = YearNextNo
                    Dim newYearNextNo As Integer = Integer.Parse(YearNextNo) + 1
                    Dim intDiff As Integer = YearNextNo.Length - newYearNextNo.ToString.Length
                    Dim i As Integer
                    Dim strZero As String = ""
                    For i = 0 To intDiff - 1
                        strZero += "0"
                    Next
                    YearNextNo = strZero + newYearNextNo.ToString
                    Dim strSql As String = " update sanm2 set YearNextNo='" + YearNextNo + "' where TrxNo=" + Sanm1TrxNo + "  and Year= " + strYear
                    SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                End If
        End Select
        Return strNextNo
    End Function
    Private Function ReturnfiePrefix(ByVal fiePreSuffix As String) As String
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim strPrefix As String = ""
        If (fiePreSuffix <> "") Then
            Dim arrfiePrefix As String() = fiePreSuffix.Split(",")
            For Each strEach As String In arrfiePrefix
                If (strEach <> "") Then
                    Select Case strEach 'dd/mm/yyyy
                        Case "YY"
                            strPrefix += strDate.Substring(strDate.Length - 2, 2)
                        Case "MM"
                            strPrefix += strDate.Substring(3, 2)
                        Case "Y"
                            strPrefix += strDate.Substring(strDate.Length - 1, 1)
                        Case "M"
                            If (Integer.Parse(strDate.Substring(4, 6)) < 10) Then
                                strPrefix += strDate.Substring(5, 6)
                            Else
                                Select Case strDate.Substring(4, 6)
                                    Case "10"
                                        strPrefix += "O"
                                    Case "11"
                                        strPrefix += "N"
                                    Case "12"
                                        strPrefix += "D"
                                End Select
                            End If
                        Case "DD"
                            strPrefix += strDate.Substring(0, 2)
                        Case "NN"
                            strPrefix += "00"
                        Case "N"
                            strPrefix += "0"
                        Case Else
                            If strEach.IndexOf("F") >= 0 Then
                                strPrefix += strEach.Substring(1, strEach.Length - 1)
                                Dim objUser As clsUser = Nothing
                                Dim strSite As String = ""
                                PageFun.GetCurrentUserInfo(Page, objUser)
                                If objUser.SiteCode <> "" Then
                                    strPrefix += objUser.SiteCode.Substring(2, 3)
                                End If
                            End If
                    End Select
                End If
            Next
        End If
        Return strPrefix
    End Function
    Private Function ReturnfieSuffix(ByVal fiePreSuffix As String) As String
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim strPrefix As String = ""
        If (fiePreSuffix <> "") Then
            Dim arrfiePrefix As String() = fiePreSuffix.Split(",")
            For Each strEach As String In arrfiePrefix
                If (strEach <> "") Then
                    Select Case strEach 'dd/mm/yyyy
                        Case "YY"
                            strPrefix += strDate.Substring(strDate.Length - 2, 2)
                        Case "MM"
                            strPrefix += strDate.Substring(3, 2)
                        Case "Y"
                            strPrefix += strDate.Substring(strDate.Length - 1, 1)
                        Case "M"
                            If (Integer.Parse(strDate.Substring(4, 6)) < 10) Then
                                strPrefix += strDate.Substring(5, 6)
                            Else
                                Select Case strDate.Substring(4, 6)
                                    Case "10"
                                        strPrefix += "O"
                                    Case "11"
                                        strPrefix += "N"
                                    Case "12"
                                        strPrefix += "D"
                                End Select
                            End If
                        Case "DD"
                            strPrefix += strDate.Substring(0, 2)
                        Case "NN"
                            strPrefix += "00"
                        Case "N"
                            strPrefix += "0"
                        Case Else
                            If strEach.IndexOf("F") >= 0 Then
                                strPrefix += strEach.Substring(1, strEach.Length - 1)
                            End If
                    End Select
                End If
            Next
        End If
        Return strPrefix
    End Function
    Public Sub CreateReceiveBatchNo()
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'CreateOrderNo
            If strDate <> "" Then
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                           "where NumberType  like '%CTSO%' and TrxType ='2'", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim fiePrefix As Object = ReturnfiePrefix(dtReclzw.Rows(0)("Prefix").ToString)
                    Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                    Dim fieSuffix As Object = ReturnfieSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                    hidBatchNo.Value = fiePrefix + fieNextNo + fieSuffix
                    'If hidBatchNo.Value.Length > 10 Then
                    '    hidBatchNo.Value = hidBatchNo.Value.Substring(hidBatchNo.Value.Length - 10)
                    'End If
                End If
            End If
        End If
    End Sub
#End Region

End Class
