Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class CELEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Protected ConfigPath As String
    Protected ExportConfig As String
    Private objServer As clsctcl
    Private returnValue As String

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Dim arrParam As String() = GeneralFun.GetPar(returnValue)
        Select Case arrParam.Length
            Case 1
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, Nothing))
            Case Else
                Dim arrObject(arrParam.Length - 2) As Object
                Dim i As Integer
                For i = 0 To arrParam.Length - 2
                    arrObject(i) = arrParam(i + 1)
                Next
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, arrObject))
        End Select
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsctcl(intUserId)
    End Function

    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");return false;")
    End Sub

    Public Function SaveData(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

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

    Private Sub BindDetailData(ByVal intUserId As String, ByVal intId As Int64)
        objServer = NewServerObject(intUserId)
        If intId >= 0 Then
            Dim tmpProp As clsPropctcl = objServer.GetDetail(intId)
            fldId.Value = tmpProp.TrxNo.ToString()
            txtContainerNo.Text = tmpProp.ContainerNo
            txtEquipmentType.Text = tmpProp.EquipmentType
            txtSiteCode.Text = tmpProp.SiteCode
            txtEventPortCode.Text = tmpProp.EventPortCode
            drEventCode.SelectedValue = tmpProp.EventCode
            drState.Text = tmpProp.State
            ConvertDateTime(txtEventDate, tmpProp.EventDate)
            txtJobNo.Text = tmpProp.JobNo
            txtShipperCode.Text = tmpProp.ShipperCode
            txtShipperName.Text = tmpProp.ShipperName
            txtPortOfLoading.Text = tmpProp.PortOfLoadingCode
            txtFinalDestination.Text = tmpProp.PortOfDischargeCode
            txtVesselName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            txtConsigneeCode.Text = tmpProp.ConsigneeCode
            txtConsigneeName.Text = tmpProp.ConsigneeName
            txtDepotCode.Text = tmpProp.DepotCode
            txtTruckerName.Text = tmpProp.TruckerName
            txtVehicleNo.Text = tmpProp.VehicleNo
            txtSealNo.Text = tmpProp.SealNo
            drDGFlag.SelectedValue = tmpProp.DGFlag
            txtDriverPassNo.Text = tmpProp.DriverPassNo
            txtDetentionCharge.Text = tmpProp.ActualDetentionCharge
            txtComputedDetentionCharge.Text = tmpProp.ComputedDetentionCharge
            txtSurveyRemarks.Text = tmpProp.SurveyRemarks
            txtRemarks.Text = tmpProp.Remarks
            Me.Title = "Container Event Log Detail"
        Else
            If Request("ContainerNo") IsNot Nothing Then
                txtContainerNo.Text = Request("ContainerNo").ToString
            End If
            Me.Title = "New"
        End If
        txtContainerNo.ReadOnly = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
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
            Dim intId As Int64 = ConClass.NewIdValue
            If Not (Request("Id") Is Nothing) Then
                intId = Int64.Parse(Request("Id").ToString())
                fldId.Value = intId
            Else
                fldId.Value = -1
            End If
            'SetInitControl
            SetInitControl(intId, objUser, objUser.UpperCase)
            ''Bind Detail Data
            BindDetailData(objUser.UserId, intId)
        End If
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

    Private Sub SetInitControl(ByRef intId As Int64, ByRef objUser As clsUser, ByRef UpperFlag As String)
        If UpperFlag = "y" Then
            setUpperCase(txtContainerNo)
            setUpperCase(txtEquipmentType)
            setUpperCase(txtSiteCode)
            setUpperCase(txtEventPortCode)
            setUpperCase(txtJobNo)
            setUpperCase(txtShipperCode)
            setUpperCase(txtShipperName)
            setUpperCase(txtPortOfLoading)
            setUpperCase(txtFinalDestination)
            setUpperCase(txtVesselName)
            setUpperCase(txtVoyageNo)
            setUpperCase(txtConsigneeCode)
            setUpperCase(txtConsigneeName)
            setUpperCase(txtDepotCode)
            setUpperCase(txtTruckerName)
            setUpperCase(txtVehicleNo)
            setUpperCase(txtSealNo)
            setUpperCase(txtDriverPassNo)
            setUpperCase(txtSurveyRemarks)
            setUpperCase(txtRemarks)
            txtDetentionCharge.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtDetentionCharge.Attributes.Add("OnBlur", "NumberBlur(2,true);")
            txtDetentionCharge.Attributes.Add("OnKeypress", "NumberInput(event,2);")

            txtComputedDetentionCharge.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtComputedDetentionCharge.Attributes.Add("OnBlur", "NumberBlur(2,true);")
            txtComputedDetentionCharge.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        End If

        txtSurveyRemarks.Attributes.Add("onpropertychange", "textLimit(event," + txtSurveyRemarks.ClientID + ",255)")
        txtRemarks.Attributes.Add("onpropertychange", "textLimit(event," + txtRemarks.ClientID + ",255)")
        'event
        txtUserId.Text = objUser.UserId
        btnEquipmentType.Attributes.Add("OnClick", "selBindCode(" + txtEquipmentType.ClientID + ",'rcco1','ContainerType,ContainerDescription','','Equipment Type','Equipment Name');return false;")
        txtEquipmentType.Attributes.Add("onchange", "valiString('" + txtEquipmentType.ClientID + "','Equipment Type','ContainerType','rcco1','')")
        btnSiteCode.Attributes.Add("OnClick", "selBindCode(" + txtSiteCode.ClientID + ",'rcsp1','PortCode,PortName','','Site Code','Site Name');return false;")
        txtSiteCode.Attributes.Add("onchange", "valiString('" + txtSiteCode.ClientID + "','Site Code','PortCode','rcsp1','')")

        btnEventPortCode.Attributes.Add("OnClick", "selBindCode(" + txtEventPortCode.ClientID + ",'rcsp1','PortCode,PortName','','Event Port Code','Event Port Name');return false;")
        txtEventPortCode.Attributes.Add("onchange", "valiString('" + txtEventPortCode.ClientID + "','Event Port Code','PortCode','rcsp1','')")


        btnShipperCode.Attributes.Add("OnClick", "BindCodeName(" + txtShipperCode.ClientID + "," + txtShipperName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Shipper Code','Shipper Name');return false;")
        txtShipperCode.Attributes.Add("onchange", "valiBindName('" + txtShipperCode.ClientID + "','" + txtShipperName.ClientID + "','Shipper Code','BusinessPartyCode,BusinessPartyName','rcbp1')")
        btnPortOfLoading.Attributes.Add("OnClick", "selBindCode(" + txtPortOfLoading.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        txtPortOfLoading.Attributes.Add("onchange", "valiString('" + txtPortOfLoading.ClientID + "','Port Of Loading','PortCode','rcsp1','')")
        btnFinalDestination.Attributes.Add("OnClick", "selBindCode(" + txtFinalDestination.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        txtFinalDestination.Attributes.Add("onchange", "valiString('" + txtFinalDestination.ClientID + "','Final Destination','PortCode','rcsp1','')")

        btnConsigneeCode.Attributes.Add("OnClick", "BindCodeName(" + txtConsigneeCode.ClientID + "," + txtConsigneeName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Consignee Code','Consignee Name');return false;")
        'txtConsigneeCode.Attributes.Add("onchange", "valiString('" + txtConsigneeCode.ClientID + "','Consignee Code','BusinessPartyCode','rcbp1','')")
        txtConsigneeCode.Attributes.Add("onchange", "valiBindName('" + txtConsigneeCode.ClientID + "','" + txtConsigneeName.ClientID + "','Consignee Code','BusinessPartyCode,BusinessPartyName','rcbp1')")

        Dim strWhere As String = "" ' " 'and PartyType=\'DP\' and CountryCode=\'" + objUser.SiteCode.Substring(0, 2) + "\' and CityCode=\'" + objUser.SiteCode.Substring(objUser.SiteCode.Length - 3, 3) + "\'' "
        btnDepotCode.Attributes.Add("OnClick", "selBindCode(" + txtDepotCode.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','" + strWhere + "','Depot Type','Depot Name');return false;")
        txtDepotCode.Attributes.Add("onchange", "valiString('" + txtDepotCode.ClientID + "','Depot Code','BusinessPartyCode','rcbp1','" + strWhere + "')")
        'binddropdownlist
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'drEvent
        drEventCode.Items.Add(New ListItem("Depot Out", "Depot Out"))
        drEventCode.Items.Add(New ListItem("Gate In", "Gate In"))
        drEventCode.Items.Add(New ListItem("Box Load", "Box Load"))
        drEventCode.Items.Add(New ListItem("Box Disch", "Box Disch"))
        drEventCode.Items.Add(New ListItem("Gate Out", "Gate Out"))
        drEventCode.Items.Add(New ListItem("Depot In", "Depot In"))
        drEventCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
        drEventCode.Attributes.Add("onchange", "ShowState(" + drEventCode.ClientID + ")")
        'EventDate
        btnEventDate.Attributes.Add("OnClick", "WdatePicker({el:'txtEventDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
        txtEventDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtEventDate.ClientID + "');return false;")
        txtEventDate.Attributes.Add("onblur", "ChangeLongDate('" + txtEventDate.ClientID + "');return false;")
        'drDGFlag
        drDGFlag.Items.Add(New ListItem("Y", "Y"))
        drDGFlag.Items.Add(New ListItem("N", "N"))
        drDGFlag.Items.Insert(0, New ListItem(ListItemSelect, ""))
        If Request("Type") Is Nothing OrElse Request("Type").ToString() = "" Then
            'Button Event
            'btnBook.Style.Add("display", "none")
            btnSave.Attributes.Add("onclick", "SaveDetail('Container Event Log',0);return false;")
            'btnNew.Attributes.Add("onclick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnClose.Attributes.Add("OnClick", "blChanged=true;CloseWindow(0);return false;")
            'KeyDown Event
            setFocusControl(txtContainerNo, txtEquipmentType)
            setFocusControl(txtEquipmentType, txtSiteCode)
            setFocusControl(txtSiteCode, txtEventPortCode)
            setFocusControl(txtEventPortCode, drEventCode)
            setFocusControl(drEventCode, drState)
            setFocusControl(drState, txtEventDate)
            setFocusControl(txtEventDate, txtJobNo)
            setFocusControl(txtJobNo, txtShipperCode)
            setFocusControl(txtShipperCode, txtShipperName)
            setFocusControl(txtShipperName, txtPortOfLoading)
            setFocusControl(txtPortOfLoading, txtFinalDestination)
            setFocusControl(txtFinalDestination, txtVesselName)
            setFocusControl(txtVesselName, txtVoyageNo)
            setFocusControl(txtVoyageNo, txtConsigneeCode)
            setFocusControl(txtConsigneeCode, txtConsigneeName)
            setFocusControl(txtConsigneeName, txtDepotCode)
            setFocusControl(txtDepotCode, txtTruckerName)
            setFocusControl(txtTruckerName, txtVehicleNo)
            setFocusControl(txtVehicleNo, txtSealNo)
            setFocusControl(txtSealNo, drDGFlag)
            setFocusControl(drDGFlag, txtDriverPassNo)
            setFocusControl(txtDriverPassNo, txtDetentionCharge)
            setFocusControl(txtDetentionCharge, txtComputedDetentionCharge)
            setFocusControl(txtComputedDetentionCharge, txtSurveyRemarks)
            '    'txtExternalLength
            '    txtExternalLength.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            '    txtExternalLength.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            '    txtExternalLength.Attributes.Add("OnKeypress", "NumberInput(event,0);")
        Else
            'Button Event
            'btnBook.Style.Add("display", "none")
            btnSave.Style.Add("display", "none")
            'btnNew.Style.Add("display", "none")
            btnClose.Attributes.Add("OnClick", "window.close();return false;")
        End If
    End Sub

    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub

    Public Function GetContainerType(ByVal ContainerType As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strResult As String = GetDetailAsString(ContainerType)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strResult
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Public Function GetDetailAsString(ByVal ContdainerType As String) As String
        Dim tmpTable As DataTable = BaseSelectSrvr.GetData("select * from rcco1 where ContainerType='" + ContdainerType + "'", "")
        Dim strResult As String = ""
        If tmpTable.Rows.Count > 0 Then
            strResult = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalLength"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalBreadth"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalHeight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalLength"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalBreadth"), DbType.String))

            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalHeight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Material"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Capacity"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Tare_Weight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Max_g_Weight"), DbType.String))

            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("MaxPayload"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Ext_Coat"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Approvals"), DbType.String))
        End If
        Return strResult
    End Function
End Class