Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports Ntools
Imports SysMagic

Partial Class StoringOrderEdit
    Inherits ListEditPage
    Private objServer As clsSO
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Protected ConfigPath As String
    Protected ExportConfig As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsSO(intUserId)
    End Function
#End Region
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#Region "First Tab"
    Private Sub ConvertDate(ByRef con As TextBox, ByVal strVal As Date)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            Else
                con.Text = strVal.ToString("dd/MM/yyyy")
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub ConvertDateTime(ByRef con As TextBox, ByVal strVal As DateTime)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    con.Text = strVal.ToString("dd-MMM-yy")
                Else
                    con.Text = strVal.ToString("dd-MMM-yy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal objUser As clsUser)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropSO = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            Me.Title = "Storing Order No : " + tmpProp.StoringOrderNo
            txtOrganization.Text = tmpProp.OrganisationCode
            drDemurrageCode.SelectedValue = tmpProp.DemurrageCode
            txtJobNo.Text = tmpProp.JobNo
            txtVesselName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            ConvertDateTime(txtETA, tmpProp.EtaDate)
            drReturnType.SelectedValue = tmpProp.ReturnType
            txtConsigneeCode.Text = tmpProp.ConsigneeCode
            txtConsigneeName.Text = tmpProp.ConsigneeName
            txtConsigneeAddress1.Text = tmpProp.ConsigneeAddress1
            txtConsigneeAddress2.Text = tmpProp.ConsigneeAddress2
            txtConsigneeAddress3.Text = tmpProp.ConsigneeAddress3
            txtConsigneeAddress4.Text = tmpProp.ConsigneeAddress4
            txtContactPerson.Text = tmpProp.ConsigneeContactPerson
            txtContactNo.Text = tmpProp.ConsigneeContactNo
            txtDepotCode.Text = tmpProp.DepotCode
            txtPortOfLoading.Text = tmpProp.PortOfLoadingCode
            drDetentionCode.SelectedValue = tmpProp.DetentionCode
            ConvertDateTime(txtDetentionStart, tmpProp.DetentionStartDate)
            txtDetentionFreeDay.Text = tmpProp.DetentionFreeDay
            ConvertDateTime(txtDemurrageSD, tmpProp.DemurrageStartDate)
            txtDemurrageFreeDay.Text = tmpProp.DemurrageFreeDay
            txtInstructionTD.Text = tmpProp.InstructionToDepot
            txtTruckerCode.Text = tmpProp.TruckerCode
            txtTruckerName.Text = tmpProp.TruckerName
            ConvertDateTime(txtTruckingCD, tmpProp.CompleteDate)
            txtTruckerRefNo.Text = tmpProp.TruckerRefNo
            txtSON.Text = tmpProp.StoringOrderNo
            txtRefNo.Text = tmpProp.RefNo
        Else
            Me.Title = "New"
            'txtPortOfLoading.Text = objUser.SiteCode
            If objUser.CompNo.Length > 10 Then
                objUser.CompNo = objUser.CompNo.Substring(0, 10)
            End If
            txtOrganization.Text = objUser.CompNo
            If objUser.SiteCode = "SGSIN" Then
                drDetentionCode.SelectedValue = "7D"
                txtDetentionFreeDay.Text = "7"
            End If
            drDetentionCode.Attributes.Add("onchange", "DetentionDefault(" + txtETA.ClientID + "," + drDetentionCode.ClientID + "," + txtDetentionStart.ClientID + "," + txtDetentionFreeDay.ClientID + ")")
            drDemurrageCode.Attributes.Add("onchange", "DetentionDefault(" + txtETA.ClientID + "," + drDemurrageCode.ClientID + "," + txtDemurrageSD.ClientID + "," + txtDemurrageFreeDay.ClientID + ")")
            txtETA.Attributes.Add("onchange", "DetentionDefault(" + txtETA.ClientID + "," + drDetentionCode.ClientID + "," + txtDetentionStart.ClientID + "," + txtDetentionFreeDay.ClientID + ")")
        End If
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Private Sub ControlEvent(ByRef UpperFlag As String)
        setFocusControl(txtOrganization, txtJobNo)
        setFocusControl(txtJobNo, txtVesselName)
        setFocusControl(txtVesselName, txtVoyageNo)
        setFocusControl(txtVoyageNo, txtETA)
        setFocusControl(txtETA, drReturnType)
        setFocusControl(drReturnType, txtConsigneeCode)
        setFocusControl(txtConsigneeCode, txtConsigneeName)
        setFocusControl(txtConsigneeName, txtConsigneeAddress1)
        setFocusControl(txtConsigneeAddress1, txtConsigneeAddress2)
        setFocusControl(txtConsigneeAddress2, txtConsigneeAddress3)
        setFocusControl(txtConsigneeAddress3, txtConsigneeAddress4)
        setFocusControl(txtConsigneeAddress4, txtContactPerson)
        setFocusControl(txtContactPerson, txtContactNo)
        setFocusControl(txtContactNo, txtDepotCode)
        setFocusControl(txtDepotCode, txtPortOfLoading)
        setFocusControl(txtPortOfLoading, drDemurrageCode)
        setFocusControl(drDemurrageCode, txtDemurrageFreeDay)
        setFocusControl(txtDemurrageFreeDay, txtDemurrageSD)
        setFocusControl(txtDemurrageSD, drDetentionCode)
        setFocusControl(drDetentionCode, txtDetentionFreeDay)
        setFocusControl(txtDetentionFreeDay, txtDetentionStart)
        setFocusControl(txtDetentionStart, txtRefNo)
        setFocusControl(txtRefNo, txtInstructionTD)
        setFocusControl(txtInstructionTD, txtTruckerCode)
        setFocusControl(txtTruckerCode, txtTruckerName)
        setFocusControl(txtTruckerName, txtTruckingCD)
        setFocusControl(txtTruckingCD, txtTruckerRefNo)
        'UpperCase
        If UpperFlag = "y" Then
            setUpperCase(txtOrganization)
            setUpperCase(txtJobNo)
            setUpperCase(txtVesselName)
            setUpperCase(txtVoyageNo)
            setUpperCase(txtConsigneeCode)
            setUpperCase(txtConsigneeName)
            setUpperCase(txtConsigneeAddress1)
            setUpperCase(txtConsigneeAddress2)
            setUpperCase(txtConsigneeAddress3)
            setUpperCase(txtConsigneeAddress4)
            setUpperCase(txtContactPerson)
            setUpperCase(txtContactNo)
            setUpperCase(txtDepotCode)
            setUpperCase(txtPortOfLoading)
            setUpperCase(txtRefNo)
            setUpperCase(txtInstructionTD)
            setUpperCase(txtTruckerCode)
            setUpperCase(txtTruckerName)
            setUpperCase(txtTruckerRefNo)
        End If
    End Sub
    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");")
    End Sub
    Public Function SaveData(ByVal strValue As String, ByVal strStoringOrder As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If strValue.Substring(0, strValue.IndexOf("#")) = "-1" Then
                CreateSON()
                strValue = strValue.Replace("Storing@OrderNo", txtSON.Text)
            End If
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave + ConSeparator.Par + txtSON.Text
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId IsNot Nothing Then
                        fldId.Value = objServer.masterId
                    End If
                    Dim intTrxNo As Int64 = GetNewId()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value + ConSeparator.Par + txtSON.Text
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + fldId.Value + ConSeparator.Par + txtSON.Text
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + txtSON.Text
        End If
    End Function
#End Region
#Region "Grid View RO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        If Not (Request("Id") Is Nothing) Then
            intTrxNo = Int64.Parse(Request("Id").ToString())
        End If
        If objList.Where.IndexOf("TrxNo") < 0 Then
            objList.Where = " and a.TrxNo=" + intTrxNo.ToString
        End If
        objList.Query = "ReleaseContainer"
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsSO2(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctso2_DeportIn"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim i As Integer
            e.Row.Cells(0).Width = 20
            Dim _ColumnInfo As clsPropColumn
            If e.Row.RowType = DataControlRowType.Header Then
                Dim Im As New Image
                Im = e.Row.Cells(0).FindControl("imgInsert")
                Im.Attributes.Remove("onclick")
                Im.Attributes.Add("onclick", "ButtonAddToSO2(event,'" + objUser.UpperCase + "')")
                For i = 1 To objColumns.Column.Count - 1
                    e.Row.Cells(i).Attributes.Remove("onclick")
                Next
            ElseIf e.Row.RowType = DataControlRowType.DataRow Then
                Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
                Dim intTrxNo As String = CType(tmpProp, clsPropSO2).TrxNo.ToString
                Dim intLineItemNo As String = CType(tmpProp, clsPropSO2).LineItemNo.ToString
                Dim intContainer As String = CType(tmpProp, clsPropSO2).ContainerNo
                Dim intReleaseFlag As Integer = CType(tmpProp, clsPropSO2).ReceiveFlag
                Dim RvFlag As String = CType(tmpProp, clsPropSO2).RvFlag

                'Row color
                e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
                If e.Row.RowIndex Mod 2 = 0 Then
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
                Else
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
                End If
                'Undelete
                Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
                imgRestore.Visible = False
                'Edit
                Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
                imgEdit.Visible = False
                'Insert
                Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
                imgInsert.Visible = False

                Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image) 'for has received container
                If intReleaseFlag > 0 Then
                    'Delete
                    e.Row.Cells(0).Controls.Clear()
                Else                                                                   'not has been received container
                    'Delete
                    imgDelete.Attributes.Add("onclick", "DeleteDetail(" + intTrxNo.ToString + "123456789" + intLineItemNo + ");return false;")
                    Dim objcontainerno As New TextBox
                    objcontainerno.ID = "txtContainerNo"
                    objcontainerno.Text = e.Row.Cells(1).Text.Replace("&nbsp;", "")
                    objcontainerno.BackColor = Color.AntiqueWhite
                    objcontainerno.BorderStyle = BorderStyle.Solid
                    objcontainerno.BorderWidth = 0
                    objcontainerno.TabIndex = 37
                    e.Row.Cells(1).Style.Add("text-align", "center")
                    e.Row.Cells(1).Style.Add("width", "20px")
                    e.Row.Cells(1).BackColor = Color.AntiqueWhite
                    e.Row.Cells(1).Controls.Add(objcontainerno)
                    Dim txtContainerNo As TextBox = e.Row.Cells(1).FindControl("txtContainerNo")
                    Dim hidLineItemNo As New HiddenField
                    hidLineItemNo.ID = "hidLineItemNo"
                    hidLineItemNo.Value = intLineItemNo
                    e.Row.Cells(1).Controls.Add(hidLineItemNo)
                    If intTrxNo = "-1" Then
                        e.Row.Cells(0).Controls.Clear()
                        txtContainerNo.Attributes.Add("onkeydown", "FocusAddToSO2(event,'" + objUser.UpperCase + "');")
                    Else
                        txtContainerNo.Attributes.Add("onchange", " UpdateCTSO2(" + intTrxNo + "," + intLineItemNo + ",'" + intContainer + "','" + txtContainerNo.ClientID + "');")
                    End If
                End If
                For i = 0 To objColumns.Column.Count - 1
                    _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                    Dim strFieldName As String = _ColumnInfo.FieldName
                    If strFieldName.ToLower <> "state" Then
                        If _ColumnInfo.FieldType = DbType.Date Or _ColumnInfo.FieldType = DbType.DateTime Then
                            'e.Row.Cells(i).Text
                            If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                                Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                                If dtmTemp <= ConDateTime.MinDate Then
                                    e.Row.Cells(i + 1).Text = ""
                                Else
                                    e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                                End If
                            End If
                        End If
                    Else
                        e.Row.Cells(i + 1).Text = ConverState(e.Row.Cells(i + 1).Text)
                    End If
                Next
                If RvFlag <> "Y" Then
                    e.Row.Cells(5).Text = ""
                End If
                If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                    For i = 2 To objColumns.Column.Count - 1
                        e.Row.Cells(i).Text = ""
                    Next
                End If
            End If
        End If
    End Sub
    Function ConverState(ByVal strState As String) As String
        Select Case strState.ToLower.Trim
            Case ""
                Return ""
            Case "sd"
                Return "Panding Survery"
            Case "dm"
                Return "Damage"
            Case "av"
                Return "Available"
            Case "wr"
                Return "Washing Required"
        End Select
        Return ""
    End Function
    Protected Sub gvwSource_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.DataBound
        Dim i As Integer
        For i = 0 To gvwSource.Rows.Count - 2
            If gvwSource.Rows(i).Cells(1).HasControls Then
                'OnKeyDown
                Dim SecCon As TextBox = gvwSource.Rows(i).Cells(1).FindControl(gvwSource.Rows(i).Cells(1).Controls(0).ID)
                'Key Next Row
                For j As Integer = i To gvwSource.Rows.Count - 2
                    If gvwSource.Rows(j + 1).Cells(1).HasControls Then
                        Dim NextRowCon As TextBox = gvwSource.Rows(j + 1).Cells(1).FindControl(gvwSource.Rows(j + 1).Cells(1).Controls(0).ID)
                        SecCon.Attributes.Add("OnKeyDown", "FocusControlRC(event," + SecCon.ClientID + "," + NextRowCon.ClientID + ");")
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Dim str As String = GetJavascriptLanguageConst()
        str = str.Replace("</script>", " var RegTrxNo='" + intTrxNo.ToString + "';</script>")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", str)
    End Sub
    Private Function getLineItemNo(ByVal TrxNo As String) As String
        Dim strLineItemNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(LineItemNo)+1 as LineItemNo from ctso2 where TrxNo=" + TrxNo, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("LineItemNo").ToString.Trim <> "" Then
                        strLineItemNo = dt.Rows(0)("LineItemNo").ToString.Trim
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
    Public Function SO2SaveOne(ByVal strTrxNo As String, ByVal strContainerNo As String, ByVal TruckerName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt As DataTable
        Dim intResult As Integer = -1
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strContainerNo.ToString <> "" Then
                Try
                    Dim strSql As String = "select ContainerNo from rccf1 where ContainerNo='" + strContainerNo + "'"
                    dt = BaseSelectSrvr.GetData(strSql, "")
                    If dt.Rows.Count = 0 Then
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container No " + strContainerNo + " is not found in Container Master." + ConSeparator.Par + Me.intPageCount.ToString
                    End If
                    'check useFlag
                    strSql = "select useFlag from rccf1 where ContainerNo='" + strContainerNo + "' "
                    dt = BaseSelectSrvr.GetData(strSql, "")
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)(0).ToString = "N" Then
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container No " + strContainerNo + " is not in use." + ConSeparator.Par + Me.intPageCount.ToString
                        End If
                    End If
                    'check ctso2 & sitecode
                    strSql = "select ContainerNO,(select StoringOrderNo from ctso1 where trxNo=a.trxno) StoringOrderNo,(select SiteCode from ctso1 where trxNo=a.trxno) SiteCode from ctso2 a where ContainerNO='" + strContainerNo + "' and isnull(ReceiveBatchNo,'')=''"
                    dt = BaseSelectSrvr.GetData(strSql, "")
                    If dt.Rows.Count > 0 Then
                        If dt.Rows.Count = 1 Then
                            If dt.Rows(0)(2).ToString.Trim = objUser.SiteCode Then
                                If dt.Rows(0)(1).ToString.Trim <> "" Then
                                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as this container has already been added to Storing Order " + dt.Rows(0)(1).ToString + "." + ConSeparator.Par + Me.intPageCount.ToString
                                    'Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container No is released under Storing Order: " + dt.Rows(0)(1).ToString + ConSeparator.Par + Me.intPageCount.ToString
                                Else
                                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + "." + ConSeparator.Par + Me.intPageCount.ToString
                                End If
                            End If
                        End If
                        If dt.Rows.Count > 1 Then
                            If dt.Rows(0)(1).ToString.Trim <> "" Then
                                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + " as this container has already been added to Storing Order " + dt.Rows(0)(1).ToString + "." + ConSeparator.Par + Me.intPageCount.ToString
                            Else
                                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Unable to receive Container No " + strContainerNo + "." + ConSeparator.Par + Me.intPageCount.ToString
                            End If
                        End If
                    End If
                    'dt = BaseSelectSrvr.GetData("select * from ctso2 where TrxNo=" + strTrxNo + " and ContainerNO='" + strContainerNo + "'", "")
                    'If dt.Rows.Count < 1 Then
                    strSql = "insert into ctso2(TrxNo,LineItemNo,ContainerNo,TruckerName) values (" + strTrxNo + "," + getLineItemNo(strTrxNo) + ",'" + strContainerNo + "','" + TruckerName + "')"
                    intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                    If intResult > 0 Then
                        Dim strFun As String = PageFun.GetFunNo(Page)
                        'New Object 
                        objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                        intTrxNo = Integer.Parse(strTrxNo)
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + Me.intPageCount.ToString
                    Else
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + intPageCount.ToString
                    End If
                    'Else
                    '    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!" + ConSeparator.Par + intPageCount.ToString
                    'End If
                Catch ex As Exception
                End Try
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + intPageCount.ToString
    End Function
    Public Function CTSO2Update(ByVal strsql As String, ByVal strTrxNo As String, ByVal strValue As String, ByVal conContaienr As String, ByVal oldContaienr As String) As String
        Dim dt, dt3 As DataTable
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If oldContaienr <> strValue Then
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                Dim strSql2 As String = "select ContainerNo from rccf1 where ContainerNo='" + strValue + "'"
                dt3 = BaseSelectSrvr.GetData(strSql2, "")
                If dt3.Rows.Count = 0 Then
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO not exist in Container Master!" + ConSeparator.Par + conContaienr
                End If
                dt = BaseSelectSrvr.GetData("select * from ctso2 where TrxNo=" + fldId.Value + " and ContainerNO='" + strValue + "'", "")
                If dt.Rows.Count < 1 Then
                    Dim intflag As String
                    intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
                    If intflag <> 1 Then
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + conContaienr
                    End If
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "save false." + ConSeparator.Par + conContaienr
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!" + ConSeparator.Par + conContaienr
                End If
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + conContaienr
            End If
        Else
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "" + ConSeparator.Par + conContaienr
        End If

    End Function
    Public Function DeleteCTSO2(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not FDeleteCTSO2(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function FDeleteCTSO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
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
#End Region
#Region "public"
    Private Sub SetInitValue(ByVal UserNo As String, ByRef objUser As clsUser)
        txtUserNo.Text = UserNo
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'drReturnType
        drReturnType.Items.Add(New ListItem("HR - On Hire", "HR"))
        drReturnType.Items.Add(New ListItem("IM - Normal Import", "IM"))
        drReturnType.Items.Add(New ListItem("NC - Non Container Terminal", "NC"))
        drReturnType.Items.Add(New ListItem("NM - Normal Import Empty", "NM"))
        drReturnType.Items.Add(New ListItem("OH - Off Hire", "OH"))
        drReturnType.Items.Add(New ListItem("OT - Others", "OT"))
        drReturnType.Items.Insert(0, New ListItem(ListItemSelect, ""))
        'drDetentionCode
        drDetentionCode.Items.Add(New ListItem("5D", "5D"))
        drDetentionCode.Items.Add(New ListItem("7D", "7D"))
        drDetentionCode.Items.Add(New ListItem("14D", "14D"))
        drDetentionCode.Items.Add(New ListItem("30D", "30D"))
        drDetentionCode.Items.Add(New ListItem("OTH", "OTH"))
        drDetentionCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
        'drDemurrageCode
        If objUser.SiteCode = "SGSIN" Or objUser.SiteCode = "IDJKT" Or objUser.SiteCode = "IDSUB" Or objUser.SiteCode = "IDSRG" Then
            drDemurrageCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
            txtDemurrageFreeDay.ReadOnly = True
            txtDemurrageSD.ReadOnly = True
            btnDemurrageSD.Style.Add("display", "none")
        Else
            drDemurrageCode.Items.Add(New ListItem("5D", "5D"))
            drDemurrageCode.Items.Add(New ListItem("7D", "7D"))
            drDemurrageCode.Items.Add(New ListItem("14D", "14D"))
            drDemurrageCode.Items.Add(New ListItem("30D", "30D"))
            drDemurrageCode.Items.Add(New ListItem("OTH", "OTH"))
            drDemurrageCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        btnClose.Attributes.Add("OnClick", "CloseWindow(0);return false;")
        'btnNew.Attributes.Add("OnClick", "NewDetail(0);return false;")
        txtDetentionFreeDay.Attributes.Add("OnKeyPress", "Number(event);")
        txtDemurrageFreeDay.Attributes.Add("OnKeyPress", "Number(event);")
        drDetentionCode.Attributes.Add("onchange", "DetentionCodeSelect('" + drDetentionCode.ClientID + "'," + txtDetentionFreeDay.ClientID + ")")
        drDemurrageCode.Attributes.Add("onchange", "DetentionCodeSelect('" + drDemurrageCode.ClientID + "'," + txtDemurrageFreeDay.ClientID + ")")
        txtPortOfLoading.Attributes.Add("onchange", "valiString('" + txtPortOfLoading.ClientID + "','Port Of Loading Code.','PortCode','rcsp1','')")
        txtTruckerCode.Attributes.Add("onchange", "valiBindName('" + txtTruckerCode.ClientID + "','" + txtTruckerName.ClientID + "','Trucker Code.','BusinessPartyCode,BusinessPartyName','rcbp1')")
        txtConsigneeCode.Attributes.Add("onchange", "valiMultiName('" + txtConsigneeCode.ClientID + "','Consignee Code.','BusinessPartyCode,BusinessPartyName','rcbp1')")

    End Sub
    Public Function valiString(ByVal strSql As String, ByVal ValiName As String, ByVal ConName As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt IsNot Nothing Then
                Dim intCount As Integer = Int64.Parse(dt.Rows(0)("valcon"))
                If intCount > 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ConName + ConSeparator.Par + ValiName
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ConName + ConSeparator.Par + ValiName
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConName + ConSeparator.Par + ValiName
    End Function
    Public Function valiBindName(ByVal strSql As String, ByVal ValiName As String, ByVal ConCode As String, ByVal ConName As String) As String
        Dim objUser As clsUser = Nothing
        Dim valName As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    valName = dt.Rows(0)(1)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ConCode + ConSeparator.Par + ValiName + ConSeparator.Par + ConName + ConSeparator.Par + valName
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ConCode + ConSeparator.Par + ValiName + ConSeparator.Par + ConName + ConSeparator.Par + valName
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConCode + ConSeparator.Par + ValiName + ConSeparator.Par + ConName + ConSeparator.Par + valName
    End Function
    Public Function valiMultiName(ByVal strSql As String, ByVal ValiName As String, ByVal ConCode As String) As String
        Dim objUser As clsUser = Nothing
        Dim strFields As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    strFields = dt.Rows(0)(1) + "," + dt.Rows(0)(2) + "," + dt.Rows(0)(3) + "," + dt.Rows(0)(4) + "," + dt.Rows(0)(5) + "," + dt.Rows(0)(6) + "," + dt.Rows(0)(7)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ConCode + ConSeparator.Par + ValiName + ConSeparator.Par + strFields
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ConCode + ConSeparator.Par + strFields
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConCode + ConSeparator.Par + ValiName + strFields
    End Function
    Private Sub HidControl(ByVal bol As Boolean)
        If Not bol Then
            btnJobNo.Style.Add("display", "none")
            btnETA.Style.Add("display", "none")
            btnPortOfLoading.Style.Add("display", "none")
            btnConsigneeCode.Style.Add("display", "none")
            btnDepotCode.Style.Add("display", "none")
            btnDetentionStart.Style.Add("display", "none")

            btnDemurrageSD.Style.Add("display", "none")
            btnTruckerCode.Style.Add("display", "none")
            btnTruckingCD.Style.Add("display", "none")
            btnSave.Style.Add("display", "none")
            'btnNew.Style.Add("display", "none")
            btnComputerDC.Style.Add("display", "none")
            btnReceiveContainer.Style.Add("display", "none")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
            hidConfig.Value = objUser.ExportConfig
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
            txtOrganization.Text = objUser.UserId
            fldId.Value = -1
            'Set Default Value
            SetInitValue(objUser.UserId, objUser)
            Dim strFun As String = PageFun.GetFunNo(Page)
            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                fldId.Value = intTrxNo
            Else
                'intTrxNo = getTrxNo()
            End If
            HidControl(objList.EditPrivilege)
            BindDetailData(objUser.UserId, intTrxNo, objUser)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'DateTime Event'
            ControlEvent(objUser.UpperCase)
            btnETA.Attributes.Add("OnClick", "WdatePicker({el:'txtETA',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            txtETA.Attributes.Add("onfocus", "ChangeShortDate('" + txtETA.ClientID + "');return false;")
            txtETA.Attributes.Add("onblur", "ChangeLongDate('" + txtETA.ClientID + "');return false;")

            btnDetentionStart.Attributes.Add("OnClick", "WdatePicker({el:'txtDetentionStart',dateFmt:'dd-MMM-yy'});return false;")
            txtDetentionStart.Attributes.Add("onfocus", "ChangeShortDate('" + txtDetentionStart.ClientID + "');return false;")
            txtDetentionStart.Attributes.Add("onblur", "ChangeLongDate('" + txtDetentionStart.ClientID + "');return false;")

            btnDemurrageSD.Attributes.Add("OnClick", "WdatePicker({el:'txtDemurrageSD',dateFmt:'dd-MMM-yy'});return false;")
            txtDemurrageSD.Attributes.Add("onfocus", "ChangeShortDate('" + txtDemurrageSD.ClientID + "');return false;")
            txtDemurrageSD.Attributes.Add("onblur", "ChangeLongDate('" + txtDemurrageSD.ClientID + "');return false;")

            btnTruckingCD.Attributes.Add("OnClick", "WdatePicker({el:'txtTruckingCD',dateFmt:'dd-MMM-yy'});return false;")
            txtTruckingCD.Attributes.Add("onfocus", "ChangeShortDate('" + txtTruckingCD.ClientID + "');return false;")
            txtTruckingCD.Attributes.Add("onblur", "ChangeLongDate('" + txtTruckingCD.ClientID + "');return false;")

            btnReceiveContainer.Attributes.Add("OnClick", "OpenRC();return false;")
            btnComputerDC.Attributes.Add("OnClick", "return false;")
            btnConsigneeCode.Attributes.Add("OnClick", "selConsigneeCode(" + txtConsigneeCode.ClientID + ");return false;")

            btnPortOfLoading.Attributes.Add("OnClick", "selBindCode(" + txtPortOfLoading.ClientID + ",'rcsp1','PortCode,PortName','','PortOfLoading Code','PortOfLoading Name');return false;")

            Dim strWhere As String
            If objUser.SiteCode = "" Then
                strWhere = " 'and PartyType=\'DP\' "

            Else
                strWhere = " 'and PartyType=\'DP\' and CountryCode=\'" + objUser.SiteCode.Substring(0, 2) + "\' and CityCode=\'" + objUser.SiteCode.Substring(objUser.SiteCode.Length - 3, 3) + "\'' "

            End If
            btnDepotCode.Attributes.Add("OnClick", "selBindCode(" + txtDepotCode.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName'," + strWhere + ",'Depot Type','Depot Name');return false;")
            txtDepotCode.Attributes.Add("onchange", "valiString('" + txtDepotCode.ClientID + "','Depot Code.','BusinessPartyCode','rcbp1'," + strWhere + ")")

            btnTruckerCode.Attributes.Add("OnClick", "BindCodeName(" + txtTruckerCode.ClientID + "," + txtTruckerName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Trucker Code','Trucker Name');return false;")
            btnJobNo.Attributes.Add("OnClick", "return false;")
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            txtInstructionTD.Attributes.Add("onkeydown", "return TxtAreaLength('" + txtInstructionTD.ClientID + "',1000);")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData(" + txtPage.ClientID + ",4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            'Language 
            HandleLanguageRelative()
            '091209
            txtSiteCode.Text = objUser.SiteCode
            btnContainer.Attributes.Add("OnClick", "OpContainer('','ctcl1','ContainerNo as column1,JobNo as column2,PortOfLoadingCode as column3','','Container No,Master Job No,POL','" + txtTruckerName.Text + "');return false;")
        End If
    End Sub
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
    Public Sub CreateSON()
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'CreateOrderNo
            If strDate <> "" Then
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                           "where NumberType  like '%CTSO%' and TrxType ='1'", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim fiePrefix As Object = ReturnfiePrefix(dtReclzw.Rows(0)("Prefix").ToString)
                    Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                    Dim fieSuffix As Object = ReturnfieSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                    txtSON.Text = fiePrefix + fieNextNo + fieSuffix
                End If
            End If
        End If
    End Sub
#End Region
End Class
