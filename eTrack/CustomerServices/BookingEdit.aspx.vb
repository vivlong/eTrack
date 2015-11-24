Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports Ntools
Imports SysMagic

Partial Class BookingEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objServer As clsBooking
    Private objBooking As clsBooking
    Private objList As clsDimension
    Private objColumns As colColumn
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strModuleCode As String = ""
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
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
        Return New clsBooking(intUserId)
    End Function
    Public Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsBooking(intUserId, RoleName, strFunNo)
    End Function
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
                    con.Text = strVal.ToString("dd/MM/yyyy")
                Else
                    con.Text = strVal.ToString("dd/MM/yyyy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As Int64)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropBooking = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            'Dim str As String = "<script language='javascript'>document.getElementById('fldId').value='" + tmpProp.TrxNo.ToString() + "'; alert(document.getElementById('fldId').value);</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType, "", str)
            fldId.Value = tmpProp.TrxNo.ToString()
            ConvertDate(txtOrderDate, tmpProp.OrderDate)
            If txtOrderDate.Text.Trim = "" Then
                ConvertDate(txtOrderDate, Now.Date)
            End If
            drpCustomerName.Text = tmpProp.CustomerName
            drpContactName.Text = tmpProp.ContactName
            txtShipperName.Text = tmpProp.ShipperName
            txtShipperAddress1.Text = tmpProp.ShipperAddress1
            txtShipperAddress2.Text = tmpProp.ShipperAddress2
            txtShipperAddress3.Text = tmpProp.ShipperAddress3
            txtShipperAddress4.Text = tmpProp.ShipperAddress4
            txtConsignessName.Text = tmpProp.ConsigneeName
            txtConsigneeAddress1.Text = tmpProp.ConsigneeAddress1
            txtConsigneeAddress2.Text = tmpProp.ConsigneeAddress2
            txtConsigneeAddress3.Text = tmpProp.ConsigneeAddress3
            txtConsigneeAddress4.Text = tmpProp.ConsigneeAddress4
            txtOriginCode.Text = tmpProp.OriginCode
            txtOriginName.Text = tmpProp.OriginName
            txtDestCode.Text = tmpProp.DestCode
            txtDestName.Text = tmpProp.DestName
            txtPortOfLoadingCode.Text = tmpProp.PortOfLoadingCode
            txtPortOfLoadingName.Text = tmpProp.PortOfLoadingName
            ConvertDate(txtlblEtdDate, tmpProp.EtdDate)
            txtPortOfDischargeCode.Text = tmpProp.PortOfDischargeCode
            txtPortOfDischargeName.Text = tmpProp.PortOfDischargeName
            ConvertDate(txtlblEtaDate, tmpProp.EtaDate)
            txtVoyageName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            txtCargoType.Text = tmpProp.CargoType
            txtDgFlag.SelectedValue = tmpProp.DgFlag
            txtDeliveryType.Text = tmpProp.DeliveryType
            txtDelivery.Text = tmpProp.DeliveryTypeName
            txtCommodityCode.Text = tmpProp.CommodityCode
            txtCommodityName.Text = tmpProp.CommodityDescription
            txtUomCode.Text = tmpProp.UomCode
            txtGrossWeight.Text = Decimal.Round(GeneralFun.StringToDecimal(tmpProp.GrossWeight.ToString()), 3)
            txtVolume.Text = Decimal.Round(GeneralFun.StringToDecimal(tmpProp.Volume.ToString()), 3)
            txtNoOfContainer1.Text = tmpProp.NoOfContainer1
            txtContainerType1.Text = tmpProp.ContainerType1
            txtNoOfContainer2.Text = tmpProp.NoOfContainer2
            txtContainerType2.Text = tmpProp.ContainerType2
            txtNoOfContainer3.Text = tmpProp.NoOfContainer3
            txtContainerType3.Text = tmpProp.ContainerType3
            txtPickupDateTime.Text = tmpProp.PickupDateTime
            txtCollectFromName.Text = tmpProp.ContainerType1
            ConvertDateTime(txtPickupDateTime, tmpProp.PickupDateTime)
            txtCollectFromName.Text = tmpProp.CollectFromName
            txtCollectFrom.Text = tmpProp.CollectFromName
            txtCargoAddress1.Text = tmpProp.CollectFromAddress1
            txtCargoAddress2.Text = tmpProp.CollectFromAddress2
            txtCargoAddress3.Text = tmpProp.CollectFromAddress3
            txtCargoAddress4.Text = tmpProp.CollectFromAddress4
            txtSpecialInstruction.Text = tmpProp.SpecialInstruction
            txtOrderType.Text = tmpProp.OrderType
            txtOrderNo.Text = tmpProp.OrderNo
            drModule.SelectedValue = tmpProp.ModuleCode
            If tmpProp.OrderNo.Trim <> "" Then
                btnConfirmOrder.Enabled = False
            End If
            txtBooking.Text = tmpProp.BookingNo
            txtJobNo.Text = tmpProp.JobNo
            txtPcs.Text = tmpProp.Pcs
            txtMarkNo.Text = tmpProp.MarkNo
            hid_CustomerCode.Value = tmpProp.CustomerCode
            '090313
            txtAirPortofDepartureCode.Text = tmpProp.AirportDeptCode
            txtAirPortofDepartureName.Text = tmpProp.AirportDeptName
            txtAirPortDestinationCode.Text = tmpProp.AirportDestCode
            txtAirPortDestinationName.Text = tmpProp.AirportDestName
            txtAlirlineID.Text = tmpProp.AirlineId
            txtFlightNo.Text = tmpProp.FlightNo
            txtDeliverTo.Text = tmpProp.DeliverToName
            txtDeliverToAddress1.Text = tmpProp.DeliverToAddress1
            txtDeliverToAddress2.Text = tmpProp.DeliverToAddress2
            txtDeliverToAddress3.Text = tmpProp.DeliverToAddress3
            txtDeliverToAddress4.Text = tmpProp.DeliverToAddress4
            ConvertDateTime(txtCargoDeliverDateTime, tmpProp.DeliverToDateTime)
            txtDescriptionOfGoods1.Text = tmpProp.DescriptionOfGoods1
            txtDescriptionOfGoods2.Text = tmpProp.DescriptionOfGoods2
            txtDescriptionOfGoods3.Text = tmpProp.DescriptionOfGoods3
            txtDescriptionOfGoods4.Text = tmpProp.DescriptionOfGoods4
            ConvertDateTime(txtPickupDateTimeTP, tmpProp.PickupDateTime)
            'Net1786
            txtTelephone.Text = tmpProp.Telephone
            txtPackingQty1.Text = tmpProp.PackingQty1
            txtPackingQty2.Text = tmpProp.PackingQty2
            txtPackingQty3.Text = tmpProp.PackingQty3
            txtPackingQty4.Text = tmpProp.PackingQty4
            txtPackingQty5.Text = tmpProp.PackingQty5
            hidOrderNoBarCode.Value = tmpProp.OrderNoBarCode
            'txtModule.Text = tmpProp.ModuleCode

            If strModuleCode = "1" Then
                Me.Title = "Edit Sea Booking"
            ElseIf strModuleCode = "2" Then
                Me.Title = "Edit Air Booking"
            ElseIf strModuleCode = "3" Then
                Me.Title = "Edit Local Transport"
            End If
            hid_OrderNo.Value = tmpProp.OrderNo
            If tmpProp.OrderNo.Trim = "" Then
                btnPrompt.Enabled = False
                btnScan.Enabled = False
            End If
        Else
            'drpContactName.Items.Add("")
            ConvertDate(txtOrderDate, Now.Date)
            If strModuleCode = "1" Then
                Me.Title = "New Sea Booking"
            ElseIf strModuleCode = "2" Then
                Me.Title = "New Air Booking"
            ElseIf strModuleCode = "3" Then
                Me.Title = "New Local Transport"
            ElseIf strModuleCode = "4" Then
                txtOrderType.Text = "M"
            ElseIf strModuleCode = "5" Then
                txtOrderType.Text = "S"
            ElseIf strModuleCode = "6" Then
                txtOrderType.Text = "F"
            ElseIf strModuleCode = "7" Then
                txtOrderType.Text = "P"
            ElseIf strModuleCode = "8" Then
                txtOrderType.Text = "O"
            ElseIf strModuleCode = "9" Then
                drModule.SelectedValue = "AE"
            End If
            btnPrompt.Enabled = False
            btnScan.Enabled = False
        End If
        btnPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ",'" + hidReports.Value + "');return false;")
    End Sub
    Private Sub KeyUpEvent()
        setUpperCase(drpCustomerName)
        'setUpperCase(drpContactName)
        setUpperCase(txtShipperName)
        setUpperCase(txtConsignessName)
        setUpperCase(txtPcs)
        setUpperCase(txtGrossWeight)
        setUpperCase(txtVolume)
        setUpperCase(txtNoOfContainer1)
        setUpperCase(txtNoOfContainer2)
        setUpperCase(txtNoOfContainer3)
        setUpperCase(txtCollectFromName)
        setUpperCase(txtOrderType)
        setUpperCase(txtOrderNo)
        setUpperCase(txtMarkNo)
        setUpperCase(txtBooking)
        setUpperCase(txtJobNo)
    End Sub
    Private Sub setUpperCase(ByRef FirCon As TextBox)
        FirCon.Attributes.Add("OnBlur", "setToUpperCase(" + FirCon.ClientID + ");")
    End Sub
    Private Sub KeydownEvent()
        setFocusControl(txtOrderDate, drpCustomerName)
        setFocusControl(drpCustomerName, drpContactName)
        If strModuleCode = "3" Then
            setFocusControl(drpContactName, txtCollectFrom)
            setFocusControl(txtCollectFrom, txtShipperAddress1)
        Else
            setFocusControl(drpContactName, txtShipperName)
            setFocusControl(txtShipperName, txtShipperAddress1)
        End If
        setFocusControl(txtShipperAddress1, txtShipperAddress2)
        setFocusControl(txtShipperAddress2, txtShipperAddress3)
        setFocusControl(txtShipperAddress3, txtShipperAddress4)
        If strModuleCode = "3" Then
            setFocusControl(txtShipperAddress4, txtDeliverTo)
            setFocusControl(txtDeliverTo, txtDeliverToAddress1)
            setFocusControl(txtDeliverToAddress1, txtDeliverToAddress2)
            setFocusControl(txtDeliverToAddress2, txtDeliverToAddress3)
            setFocusControl(txtDeliverToAddress3, txtDeliverToAddress4)
            setFocusControl(txtDeliverToAddress4, txtPickupDateTimeTP)
        Else
            setFocusControl(txtShipperAddress4, txtConsignessName)
            setFocusControl(txtConsignessName, txtConsigneeAddress1)
            setFocusControl(txtConsigneeAddress1, txtConsigneeAddress2)
            setFocusControl(txtConsigneeAddress2, txtConsigneeAddress3)
            setFocusControl(txtConsigneeAddress3, txtConsigneeAddress4)
            setFocusControl(txtConsigneeAddress4, txtOriginCode)
        End If

        If strModuleCode = "3" Then
            setFocusControl(txtPickupDateTimeTP, txtCargoDeliverDateTime)
            setFocusControl(txtCargoDeliverDateTime, txtDgFlag)
            setFocusControl(txtDgFlag, txtCargoType)
            setFocusControl(txtCargoType, txtDeliveryType)
        Else
            setFocusControl(txtOriginCode, txtDestCode)
            If strModuleCode = "2" Then
                setFocusControl(txtDestCode, txtAirPortofDepartureCode)
                setFocusControl(txtAirPortofDepartureCode, txtlblEtdDate)
                setFocusControl(txtlblEtdDate, txtAirPortDestinationCode)
                setFocusControl(txtAirPortDestinationCode, txtlblEtaDate)
                setFocusControl(txtlblEtaDate, txtAlirlineID)
                setFocusControl(txtAlirlineID, txtFlightNo)
                setFocusControl(txtFlightNo, txtDeliveryType)
            Else
                setFocusControl(txtDestCode, txtPortOfLoadingCode)
                setFocusControl(txtPortOfLoadingCode, txtlblEtdDate)
                setFocusControl(txtlblEtdDate, txtPortOfDischargeCode)
                setFocusControl(txtPortOfDischargeCode, txtlblEtaDate)
                setFocusControl(txtlblEtaDate, txtVoyageName)
                setFocusControl(txtVoyageName, txtVoyageNo)
                If strModuleCode = "1" Then
                    setFocusControl(txtVoyageNo, txtDgFlag)
                    setFocusControl(txtDgFlag, txtCargoType)
                    setFocusControl(txtCargoType, txtDeliveryType)
                Else
                    setFocusControl(txtVoyageNo, txtDeliveryType)
                End If
            End If
        End If
        setFocusControl(txtDeliveryType, txtCommodityCode)
        setFocusControl(txtCommodityCode, txtCommodityName)
        setFocusControl(txtCommodityName, txtPcs)

        setFocusControl(txtPcs, txtUomCode)
        setFocusControl(txtUomCode, txtGrossWeight)

        setFocusControl(txtGrossWeight, txtVolume)
        If strModuleCode = "1" Then
            setFocusControl(txtVolume, txtNoOfContainer1)
            setFocusControl(txtNoOfContainer1, txtContainerType1)
            setFocusControl(txtContainerType1, txtNoOfContainer2)
            setFocusControl(txtNoOfContainer2, txtContainerType2)
            setFocusControl(txtContainerType2, txtNoOfContainer3)
            setFocusControl(txtNoOfContainer3, txtContainerType3)
            setFocusControl(txtContainerType3, txtPickupDateTime)
            setFocusControl(txtPickupDateTime, txtCollectFromName)
            setFocusControl(txtCollectFromName, txtCargoAddress1)
            setFocusControl(txtCargoAddress1, txtCargoAddress2)
            setFocusControl(txtCargoAddress2, txtCargoAddress3)
            setFocusControl(txtCargoAddress3, txtCargoAddress4)
            setFocusControl(txtCargoAddress4, txtMarkNo)
            setFocusControl(txtMarkNo, txtSpecialInstruction)
        ElseIf strModuleCode = "2" Then
            setFocusControl(txtVolume, txtPickupDateTime)
            setFocusControl(txtPickupDateTime, txtCollectFromName)
            setFocusControl(txtCollectFromName, txtCargoAddress1)
            setFocusControl(txtCargoAddress1, txtCargoAddress2)
            setFocusControl(txtCargoAddress2, txtCargoAddress3)
            setFocusControl(txtCargoAddress3, txtCargoAddress4)
            setFocusControl(txtCargoAddress4, txtMarkNo)
            setFocusControl(txtMarkNo, txtSpecialInstruction)

        ElseIf strModuleCode = "3" Then
            setFocusControl(txtVolume, txtNoOfContainer1)
            setFocusControl(txtNoOfContainer1, txtContainerType1)
            setFocusControl(txtContainerType1, txtNoOfContainer2)
            setFocusControl(txtNoOfContainer2, txtContainerType2)
            setFocusControl(txtContainerType2, txtNoOfContainer3)
            setFocusControl(txtNoOfContainer3, txtContainerType3)
            setFocusControl(txtContainerType3, txtDescriptionOfGoods1)
            setFocusControl(txtDescriptionOfGoods1, txtDescriptionOfGoods2)
            setFocusControl(txtDescriptionOfGoods2, txtDescriptionOfGoods3)
            setFocusControl(txtDescriptionOfGoods3, txtDescriptionOfGoods4)
            setFocusControl(txtDescriptionOfGoods4, txtMarkNo)
            setFocusControl(txtMarkNo, txtSpecialInstruction)
        ElseIf strModuleCode = "4" Then
            setFocusControl(txtOrderDate, drModule)
            setFocusControl(drModule, drpCustomerName)
            setFocusControl(drpCustomerName, drpContactName)
            setFocusControl(drpContactName, txtTelephone)
            setFocusControl(txtTelephone, txtDestCode)
            setFocusControl(txtDestCode, txtCargoType)
            setFocusControl(txtCargoType, txtCommodityCode)
            setFocusControl(txtCommodityCode, txtCommodityName)
            setFocusControl(txtCommodityName, txtPcs)
            setFocusControl(txtPcs, txtGrossWeight)
            'setFocusControl(txtUomCode, txtGrossWeight)

            setFocusControl(txtGrossWeight, txtVolume)
            setFocusControl(txtVolume, txtMarkNo)
            setFocusControl(txtMarkNo, txtSpecialInstruction)
            setFocusControl(txtOrderType, txtOrderNo)
            setFocusControl(txtOrderNo, txtPackingQty1)
            setFocusControl(txtPackingQty1, txtPackingQty2)
            setFocusControl(txtPackingQty2, txtPackingQty3)
            setFocusControl(txtPackingQty3, txtPackingQty4)
            setFocusControl(txtPackingQty4, txtPackingQty5)
        ElseIf strModuleCode = "5" Or strModuleCode = "6" Or strModuleCode = "7" Or strModuleCode = "8" Or strModuleCode = "9" Then
            setFocusControl(txtOrderDate, drModule)
            setFocusControl(drModule, drpCustomerName)
            setFocusControl(drpCustomerName, drpContactName)
            setFocusControl(drpContactName, txtTelephone)
            setFocusControl(txtTelephone, txtDestCode)
            setFocusControl(txtDestCode, txtCargoType)
            setFocusControl(txtCargoType, txtCommodityCode)
            setFocusControl(txtCommodityCode, txtCommodityName)
            setFocusControl(txtCommodityName, txtPcs)
            setFocusControl(txtPcs, txtGrossWeight)
            'setFocusControl(txtUomCode, txtGrossWeight)

            setFocusControl(txtGrossWeight, txtVolume)
            setFocusControl(txtVolume, txtMarkNo)
            setFocusControl(txtMarkNo, txtSpecialInstruction)
            setFocusControl(txtOrderType, txtOrderNo)
            setFocusControl(txtOrderNo, txtPackingQty1)
            setFocusControl(txtPackingQty1, txtPackingQty2)
            setFocusControl(txtPackingQty2, txtPackingQty3)
            setFocusControl(txtPackingQty3, txtPackingQty4)
            setFocusControl(txtPackingQty4, txtPackingQty5)
        End If
        'setFocusControl(txtOrderType, txtMarkNo)
        'First Focus Control 
        txtOrderDate.Focus()
    End Sub
    Public Function BindDropDown(ByVal strCode As String, ByVal strName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        hid_CustomerCode.Value = strCode
        If strCode = "" Then
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par
        End If
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not Bindbylzw(strCode) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drpContactName) + ConSeparator.Par + GridViewFun.RenderControl(btnContactName) + ConSeparator.Par + GridViewFun.RenderControl(hid_CustomerCode)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function Bindbylzw(ByVal strCode As String) As Boolean
        Dim strSql As String
        Dim dtReclzw As DataTable
        strSql = "select top 1 ContactName from Rcbp3 where BusinessPartyCode='" + strCode + "' order by ContactName Asc"
        dtReclzw = BaseSelectSrvr.GetData(strSql, "")
        If dtReclzw.Rows.Count > 0 Then
            If dtReclzw.Rows(0)("ContactName") IsNot Nothing Then
                drpContactName.Text = dtReclzw.Rows(0)("ContactName").ToString
            End If
            btnContactName.Attributes.Add("OnClick", "selBindContactName(" + drpContactName.ClientID + ",'Rcbp3',' distinct BusinessPartyCode,ContactName',' and BusinessPartyCode=\'" + strCode + "\'','Contact Code','Contact Name');return false;")
            drpContactName.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selBindContactName(" + drpContactName.ClientID + ",'Rcbp3',' distinct BusinessPartyCode,ContactName',' and BusinessPartyCode=\'" + hid_CustomerCode.Value + "\'','Contact Code','Contact Name');}return false;")
            Return True
        Else
            btnContactName.Attributes.Add("OnClick", "selBindContactName(" + drpContactName.ClientID + ",'Rcbp3',' distinct BusinessPartyCode,ContactName',' and BusinessPartyCode=\'" + strCode + "\'','Contact Code','Contact Name');return false;")
            drpContactName.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selBindContactName(" + drpContactName.ClientID + ",'Rcbp3',' distinct BusinessPartyCode,ContactName',' and BusinessPartyCode=\'" + hid_CustomerCode.Value + "\'','Contact Code','Contact Name');}return false;")
            drpContactName.Text = ""
            Return True
        End If
        Return True
    End Function
    Public Function SaveData(ByVal strValue As String, ByVal strBooking As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'add by danny 
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow(41) <> "" Then
                Dim strOrderNoBarCode As String = getOrderNoBarCode(strRow(41))
                Dim arrOrderNoBarCode() As String = GeneralFun.GetPar(strOrderNoBarCode)
                If strRow(72) <> "" Then
                    strValue = strValue.Replace(strRow(72), arrOrderNoBarCode(0))
                ElseIf strRow(71) <> "" Then
                    Dim replaceStr As String = ConSeparator.Col + strRow(71) + ConSeparator.Col
                    strValue = strValue.Replace(replaceStr, replaceStr + arrOrderNoBarCode(0))
                End If

            End If
            '''''''''''''''''''''''''
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId IsNot Nothing Then
                        fldId.Value = objServer.masterId
                    End If
                    ' Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg

                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Successfully" + ConSeparator.Par + fldId.Value
                Else
                    ' Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg

                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function ValueAdd(ByVal strSql As String, ByVal msg As String) As String
        Dim dt As DataTable
        If drpCustomerName.Text.Trim <> "" Then
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt.Rows.Count = 1 Then
                If dt.Rows(0)("count").ToString <> "0" Then
                    msg = ""
                End If
            End If
        End If
        Return msg
    End Function
#Region "Create ConfirmOrder "
    Private Function ReturnNextNo(ByVal Sanm1TrxNo As String, ByVal fieNextNo As String, ByVal fieCycle As String) As String
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim strYear As String = Now.Date.Year.ToString
        Dim strNextNo As String = ""
        Try
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
        Catch ex As Exception
        End Try
        Return strNextNo
    End Function
    Private Function ReturnfiePreSuffix(ByVal fiePreSuffix As String) As String
        Dim strOrderDate As String = txtOrderDate.Text.Trim
        Dim strPrefix As String = ""
        If (fiePreSuffix <> "") Then
            Dim arrfiePrefix As String() = fiePreSuffix.Split(",")
            For Each strEach As String In arrfiePrefix
                If (strEach <> "") Then
                    Select Case strEach 'dd/mm/yyyy
                        Case "YY"
                            strPrefix += strOrderDate.Substring(strOrderDate.Length - 2, 2)
                        Case "MM"
                            strPrefix += strOrderDate.Substring(3, 2)
                        Case "Y"
                            strPrefix += strOrderDate.Substring(strOrderDate.Length - 1, 1)
                        Case "M"
                            If (Integer.Parse(strOrderDate.Substring(4, 6)) < 10) Then
                                strPrefix += strOrderDate.Substring(5, 6)
                            Else
                                Select Case strOrderDate.Substring(4, 6)
                                    Case "10"
                                        strPrefix += "O"
                                    Case "11"
                                        strPrefix += "N"
                                    Case "12"
                                        strPrefix += "D"
                                End Select
                            End If
                        Case "DD"
                            strPrefix += strOrderDate.Substring(0, 2)
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
    Public Function SaveConfirmData(ByVal strValue As String, ByVal strBooking As String, ByVal strOrderType As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId IsNot Nothing Then
                        fldId.Value = objServer.masterId
                    Else
                        objServer.masterId = fldId.Value
                    End If
                    Dim strRow As String() = GeneralFun.GetCol(strValue)
                    'CreateOrderNo
                    Dim strOrderNo As String = ""
                    If txtOrderDate.Text.Trim <> "" Then
                        Dim dtReclzw As DataTable
                        dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                                   "where NumberType  like '%omtx%' and isnull(TrxType,'')='" + strOrderType + "'", "")
                        If dtReclzw.Rows.Count > 0 Then
                            Dim fiePrefix As Object = ReturnfiePreSuffix(dtReclzw.Rows(0)("Prefix").ToString)
                            Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                            Dim fieSuffix As Object = ReturnfiePreSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                            strOrderNo = fiePrefix + fieNextNo + fieSuffix
                        Else
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Next Order No not found in Numbering System." + ConSeparator.Par + fldId.Value
                        End If
                    End If
                    Dim strOrderNoBarCode As String = getOrderNoBarCode(strOrderNo)
                    Dim arrOrderNoBarCode() As String = GeneralFun.GetPar(strOrderNoBarCode)
                    If strOrderNo <> "" And fldId.Value IsNot Nothing Then ' arrOrderNoBarCode(0)
                        Dim strSql As String = "Update omtx1 set OrderNo='" + strOrderNo + "',OrderNoBarCode=N'" + arrOrderNoBarCode(0) + "' where TrxNo=" + objServer.masterId
                        SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                        btnConfirmOrder.Enabled = False
                    End If
                    btnScan.Enabled = True
                    btnPrompt.Enabled = True
                    'CreateOrderNo
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + fldId.Value + ConSeparator.Par + strOrderNo + ConSeparator.Par + GridViewFun.RenderControl(btnConfirmOrder) + ConSeparator.Par + GridViewFun.RenderControl(btnPrompt) + ConSeparator.Par + strOrderNoBarCode + ConSeparator.Par + GridViewFun.RenderControl(btnScan)
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + fldId.Value
                End If

            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    'Public Function CheckOrderType(ByVal strValue As String) As String
    '    Dim objUser As clsUser = Nothing
    '    Dim strMsg As String = ""
    '    If PageFun.GetCurrentUserInfo(Page, objUser) Then
    '        Try
    '            Dim dtReclzw As DataTable
    '            Dim strSql As String = "select count(*) from sanm1 where NumberType  like '%omtx%' and isnull(TrxType,'')='" + strValue + "'"
    '            dtReclzw = BaseSelectSrvr.GetData(strSql, "")
    '            If dtReclzw.Rows.Count > 0 Then
    '                If dtReclzw.Rows(0)(0).ToString <> 0 Then
    '                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
    '                End If
    '            End If
    '            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Next Order No not found in Numbering System."
    '        Catch ex As Exception
    '            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    '        End Try
    '    Else
    '        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    '    End If
    'End Function
#End Region
#Region "Check Data (Origin,DestCode,Loading,Discharge,Delivery,Commodity)"
    Public Function CheckValue(ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strTable As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If CheckBefore(strFieldName, strFieldVal, strTable) Then

                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid Customer Name"
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function CheckDoubleVal(ByVal strFieldCode As String, ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strType As String, ByVal strTable As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""

        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            Dim def As String = CheckDoubleBefore(strFieldCode, strFieldName, strFieldVal, strType, strTable)
            If def.Trim <> "" Then
                Select Case strType
                    Case "Origin"
                        txtOriginName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divOrigin" + ConSeparator.Par + GridViewFun.RenderControl(txtOriginName) + ConSeparator.Par + "divOrigin1"
                    Case "DestCode"
                        txtDestName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDestCode" + ConSeparator.Par + GridViewFun.RenderControl(txtDestName) + "&nbsp" + ConSeparator.Par + "divDestCode1"
                    Case "Loading"
                        txtPortOfLoadingName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divLoading" + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfLoadingName) + ConSeparator.Par + "divLoading1"
                    Case "Discharge"
                        txtPortOfDischargeName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDischarge" + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfDischargeName) + ConSeparator.Par + "divDischarge1"
                    Case "Delivery"
                        txtDelivery.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDelivery" + ConSeparator.Par + GridViewFun.RenderControl(txtDelivery) + ConSeparator.Par + "divDelivery1"
                    Case "Commodity"
                        txtCommodityName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divCommodity" + ConSeparator.Par + def + ConSeparator.Par + "divCommodity1"
                    Case "AirPortofDeparture"
                        txtAirPortofDepartureName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divtxtAirPortofDeparture" + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortofDepartureName) + ConSeparator.Par + "div_txtAirPortofDeparture1"
                    Case "AirPortDestination"
                        txtAirPortDestinationName.Text = def
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divAirPortDestinationName" + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortDestinationName) + ConSeparator.Par + "div1AirPortDestination1"
                    Case "Voyage"
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divVoyage" + ConSeparator.Par + "" + ConSeparator.Par + "divVoyage"
                    Case "Uom"
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divUom" + ConSeparator.Par + "" + ConSeparator.Par + "divUom"

                End Select
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
            Else
                If hid_CheckVal.Value.Trim = "" Then
                    Select Case strType
                        Case "Origin"
                            txtOriginName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divOrigin" + ConSeparator.Par + GridViewFun.RenderControl(txtOriginName) + ConSeparator.Par + "divOrigin1"
                        Case "DestCode"
                            txtDestName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDestCode" + ConSeparator.Par + GridViewFun.RenderControl(txtDestName) + "&nbsp" + ConSeparator.Par + "divDestCode1"
                        Case "Loading"
                            txtPortOfLoadingName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divLoading" + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfLoadingName) + ConSeparator.Par + "divLoading1"
                        Case "Discharge"
                            txtPortOfDischargeName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDischarge" + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfDischargeName) + ConSeparator.Par + "divDischarge1"
                        Case "Delivery"
                            txtDelivery.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDelivery" + ConSeparator.Par + GridViewFun.RenderControl(txtDelivery) + ConSeparator.Par + "divDelivery1"
                        Case "Commodity"
                            txtCommodityName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divCommodity" + ConSeparator.Par + GridViewFun.RenderControl(txtCommodityName) + ConSeparator.Par + "divCommodity1"
                        Case "AirPortofDeparture"
                            txtAirPortofDepartureName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divtxtAirPortofDeparture" + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortofDepartureName) + ConSeparator.Par + "div_txtAirPortofDeparture1"
                        Case "AirPortDestination"
                            txtAirPortDestinationName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divAirPortDestinationName" + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortDestinationName) + ConSeparator.Par + "div1AirPortDestination1"
                        Case "Voyage"
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divVoyage" + ConSeparator.Par + "" + ConSeparator.Par + "divVoyage"
                        Case "Uom"
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divUom" + ConSeparator.Par + "" + ConSeparator.Par + "divUom"
                    End Select
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
                Else 'Invalid Input
                    Select Case strType
                        Case "Origin"
                            txtOriginName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divOrigin1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtOriginName) + ConSeparator.Par
                        Case "DestCode"
                            txtDestName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDestCode1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtDestName) + "&nbsp" + ConSeparator.Par
                        Case "Loading"
                            txtPortOfLoadingName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divLoading1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfLoadingName) + ConSeparator.Par
                        Case "Discharge"
                            txtPortOfDischargeName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDischarge1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtPortOfDischargeName) + ConSeparator.Par
                        Case "Delivery"
                            txtDelivery.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divDelivery1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtDelivery) + ConSeparator.Par
                        Case "Commodity"
                            txtCommodityName.Text = ""

                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "divCommodity1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtCommodityName) + ConSeparator.Par
                        Case "AirPortofDeparture"
                            txtAirPortofDepartureName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "div_txtAirPortofDeparture1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortofDepartureName) + ConSeparator.Par
                        Case "AirPortDestination"
                            txtAirPortDestinationName.Text = ""
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "div1AirPortDestination1" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + GridViewFun.RenderControl(txtAirPortDestinationName) + ConSeparator.Par
                        Case "Voyage"
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + "Voyage" + ConSeparator.Par
                        Case "Uom"
                            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "" + ConSeparator.Par + hid_CheckVal.Value + ConSeparator.Par + "Uom" + ConSeparator.Par
                    End Select
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ConSeparator.Par + hid_CheckVal.Value
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function CheckDoubleBefore(ByVal strFieldCode As String, ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strType As String, ByVal strTable As String) As String
        Dim def As String = ""
        If strFieldVal.Trim <> "" Then
            Dim dtReclzw As DataTable
            dtReclzw = BaseSelectSrvr.GetData("select " + strFieldName + " from " + strTable + " where " + strFieldCode + "='" + strFieldVal + "'", "")
            If dtReclzw.Rows.Count > 0 Then
                If strFieldName.ToLower = "a.voyageno" Then
                    strFieldName = "VoyageNo"
                End If
                Dim strName As String = dtReclzw.Rows(0)(strFieldName)
                def = strName
            Else
                Select Case strType
                    Case "Origin"
                        hid_CheckVal.Value += "Invalid Origin Code" + vbNewLine
                    Case "DestCode"
                        hid_CheckVal.Value += "Invalid Dest Code" + vbNewLine
                    Case "Loading"
                        hid_CheckVal.Value += "Invalid Loading Code" + vbNewLine
                    Case "Discharge"
                        hid_CheckVal.Value += "Invalid Discharge Code" + vbNewLine
                    Case "Delivery"
                        hid_CheckVal.Value += "Invalid Delivery Type" + vbNewLine
                    Case "Commodity"
                        hid_CheckVal.Value += "Invalid Commodity Code" + vbNewLine
                    Case "AirPortofDeparture"
                        hid_CheckVal.Value += "Invalid AirPort of Departure Code" + vbNewLine
                    Case "AirPortDestination"
                        hid_CheckVal.Value += "Invalid AirPort of Destination Code" + vbNewLine
                    Case "Voyage"
                        hid_CheckVal.Value += "Invalid Voyage Name" + vbNewLine
                    Case "Uom"
                        hid_CheckVal.Value += "Invalid Packing" + vbNewLine
                End Select
                Dim str As String = GridViewFun.RenderControl(hid_CheckVal)
            End If
        End If
        Return def
    End Function
    Private Function CheckBefore(ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strTable As String) As Boolean
        Dim def As Boolean = False
        Dim dtReclzw As DataTable
        dtReclzw = BaseSelectSrvr.GetData("select * from " + strTable + " where " + strFieldName + "='" + strFieldVal + "'", "")
        If dtReclzw.Rows.Count > 0 Then
            def = True
        End If
        Return def
    End Function
#End Region
#Region "Send Email"
    Public Function SendData(ByVal strValue As String, ByVal strSasr2 As String, ByVal strId As String, ByVal intType As String) As String  '' for this function need first save the data then second send the email.
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    Dim intTrxNo As Int64 = GetNewId()
                    BindAttach(objUser.UserId, intTrxNo)
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
            Dim tmpProp As clsPropBooking = objServer.GetDetail(strId)
            Dim strUserName As String
            strUserName = CStr(Request.Cookies("UserName").Value)
            If objServer.SendEmail(tmpProp, strUserName, False, True, Int64.Parse(intType), Session("FunNo")) Then
                ''Return "Send the request Successful!"
                Dim returnMessage As String
                If Int64.Parse(intType) = 0 Then
                    returnMessage = "Send the request Successful!"
                ElseIf Int64.Parse(intType) = 1 Then
                    returnMessage = "Send to tester Successful!"
                ElseIf Int64.Parse(intType) = 2 Then
                    returnMessage = "Send to complete by Successful!"
                Else
                    returnMessage = "Send Successful!"
                End If
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + returnMessage
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + "Unable to send the email. bcos the email problem , pls check it."
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
#End Region
#End Region
#Region "Second Tab"
    Protected Function BindSourceData(ByVal intUserId As String, ByVal strTrxNo As String) As Boolean
        Dim strSql_omtx3 As String = "select LineItemNo,Pcs" & _
",GrossWeight as Weight" & _
",Length as Length" & _
",Height as Height" & _
",width as width" & _
",Pcs*Length*Width*Height as Volume" & _
" From omtx3" & _
        " where TrxNo=" + strTrxNo
        Dim dtTmp As DataTable = BaseSelectSrvr.GetData(strSql_omtx3, "")
        If dtTmp.Rows.Count = 0 Then
            strSql_omtx3 = "select LineItemNo, Pcs,GrossWeight as Weight,Length,Height,width,Height as Volume From omtx3 where TrxNo=-2"
            dtTmp = BaseSelectSrvr.GetData(strSql_omtx3, "")
            dtTmp.Rows.Add(dtTmp.NewRow())
            gvwDimension.DataSource = dtTmp
            gvwDimension.DataBind()
            gvwDimension.Rows(0).Visible = False
        Else
            gvwDimension.DataSource = dtTmp
            gvwDimension.DataBind()
        End If
        If strTrxNo > 0 Then
            Dim dtReclzw As DataTable
            Dim strSql As String = "select sum(pcs) as pcs,sum(GrossWeight) as weight ,sum(Pcs*Length*Width*Height) as volumn from omtx3 where TrxNo=" + strTrxNo
            dtReclzw = BaseSelectSrvr.GetData(strSql, "")
            If dtReclzw.Rows.Count > 0 Then
                Dim strfile As Boolean = False
                For i As Integer = 0 To dtReclzw.Rows.Count
                    If dtReclzw.Rows(0)(i) IsNot System.DBNull.Value Then
                        strfile = True
                    End If
                Next
                If strfile = True Then
                    If (dtReclzw.Rows(0)("pcs")) Is System.DBNull.Value Then
                        txtTotalPcs.Text = 0
                    Else
                        txtTotalPcs.Text = Convert.ToInt64(dtReclzw.Rows(0)("pcs"))
                    End If

                    If (dtReclzw.Rows(0)("Weight")) Is System.DBNull.Value Then
                        txtTotalWeight.Text = Math.Round(0, 4)
                    Else
                        txtTotalWeight.Text = Math.Round(Convert.ToDouble(dtReclzw.Rows(0)("Weight")), 4)
                    End If
                    If dtReclzw.Rows(0)("Volumn") Is System.DBNull.Value Then
                        txtTotalVolumn.Text = Math.Round(0, 4)
                    Else
                        If drDimension.SelectedItem.Value = 0 Then
                            txtTotalVolumn.Text = Math.Round(Double.Parse(dtReclzw.Rows(0)("Volumn").ToString) / (10 ^ 6), 3)
                        Else
                            txtTotalVolumn.Text = Math.Round(Double.Parse(dtReclzw.Rows(0)("Volumn").ToString) * 6000 / ((10 ^ 6) * 366))
                        End If
                    End If
                End If
            Else
                txtTotalPcs.Text = 0
                txtTotalWeight.Text = 0
                txtTotalVolumn.Text = 0
            End If
            Return True
        End If

    End Function
    Public Function DimensionUpdate(ByVal strsql As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intflag As String
            intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
            If intflag <> 1 Then
                BindSourceData(objUser.UserId, intTrxNo)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwDimension)
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If

        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    'DimensionSaveOne 090330 
    Public Function DimensionSaveOne(ByVal intTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        fldId.Value = intTrxNo
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData("select max(lineitemno)+1 from omtx3 where TrxNo=" + intTrxNo + " ", "")
            Dim strLineItemNo As String = dt.Rows(0)(0).ToString
            If strLineItemNo.Trim = "" Then
                strLineItemNo = "1"
            End If
            If dt.Rows.Count > 0 Then
                Dim strSql As String = "insert into omtx3(TrxNo,LineItemNo) values(" + intTrxNo + "," + strLineItemNo + ")"
                Dim Flag As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                BindSourceData(objUser.UserId, intTrxNo)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwDimension)
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function DeleteOmtx3Data(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            Dim objDeleteOmtx3 As New clsDimension(objUser.UserId)
            If Not objDeleteOmtx3.DeleteOmtx3(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                'Omtx3 Details...
                BindSourceData(objUser.UserId, strTrxNo)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwDimension)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Protected Sub gvwDimension_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim olabel As Label

        Dim objUser As clsUser = Nothing
        Dim UserLogin As Boolean = GetCurrentUserInfo(Page, objUser)
        If UserLogin = True Then
            objBooking = NewObjectList(objUser.UserId, objUser.RoleName, Session("BookingFunNo"))
            If objBooking.EditPrivilege = False Then
                UserLogin = False
            End If
            If objBooking.NewPrivilege = True And Request("Id") Is Nothing Then
                UserLogin = True
            End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            Dim Im As New Image
            Im.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            If UserLogin = True Then

                Im.Attributes.Add("OnClick", "AddToDimension();return false;")
                e.Row.Cells(0).Controls.Add(Im)
            Else
                Im.Style.Add("display", "none")
            End If
            e.Row.Cells(0).Style.Add("text-align", "center")
            e.Row.Cells(0).Style.Add("width", "20px")

        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            olabel = e.Row.Cells(0).FindControl("lblNo")
            olabel.Text = Convert.ToString(e.Row.RowIndex + 1)
        End If
    End Sub
    Protected Sub gvwDimension_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwDimension.DataBound
        Dim i As Integer
        Dim j As Integer = gvwDimension.Rows.Count

        Dim objUser As clsUser = Nothing
        Dim UserLogin As Boolean = GetCurrentUserInfo(Page, objUser)
        If UserLogin = True Then
            objBooking = NewObjectList(objUser.UserId, objUser.RoleName, Session("BookingFunNo"))
            If objBooking.EditPrivilege = False Then
                UserLogin = False
            End If
            If objBooking.NewPrivilege = True And Request("Id") Is Nothing Then
                UserLogin = True
            End If
        End If
        For i = 0 To gvwDimension.Rows.Count - 1
            Dim txtPcs As TextBox = gvwDimension.Rows(i).FindControl("txtPcs")
            Dim txtWeight As TextBox = gvwDimension.Rows(i).FindControl("txtWeight")
            Dim txtLength As TextBox = gvwDimension.Rows(i).FindControl("txtLength")
            Dim txtWidth As TextBox = gvwDimension.Rows(i).FindControl("txtWidth")
            Dim txtHeight As TextBox = gvwDimension.Rows(i).FindControl("txtHeight")
            Dim txtVolume As Label = gvwDimension.Rows(i).FindControl("txtVolume")



            Dim Img2 As HtmlControls.HtmlAnchor = gvwDimension.Rows(i).FindControl("Img2")
            Dim hid_LineItemNo As HiddenField = gvwDimension.Rows(i).FindControl("hid_LineItemNo")
            Dim intLineitemno As String = hid_LineItemNo.Value
            'Set deleteButton
            If fldId.Value <> "-1" Then

                Dim strTrxNo As String = fldId.Value
                If UserLogin = True Then
                    Img2.Attributes.Add("onclick", "DeleteClickOmtx3(" + strTrxNo + "," + intLineitemno + ");return false;")
                Else
                    Img2.Style.Add("display", "none")
                End If
                If txtPcs.Text.Trim <> "" Then
                    Dim str As Integer = CInt(txtPcs.Text)
                    txtPcs.Text = str
                End If
                If txtWeight.Text.Trim <> "" Then
                    txtWeight.Text = Decimal.Round(GeneralFun.StringToDecimal(txtWeight.Text.Trim), 1)
                End If
                If txtLength.Text.Trim <> "" Then
                    txtLength.Text = Decimal.Round(GeneralFun.StringToDecimal(txtLength.Text.Trim), 1)
                End If
                If txtWidth.Text.Trim <> "" Then
                    txtWidth.Text = Decimal.Round(GeneralFun.StringToDecimal(txtWidth.Text.Trim), 1)
                End If
                If txtHeight.Text.Trim <> "" Then
                    txtHeight.Text = Decimal.Round(GeneralFun.StringToDecimal(txtHeight.Text.Trim), 1)
                End If
                If txtVolume.Text.Trim <> "" Then
                    txtVolume.Text = CLng(txtVolume.Text)
                End If
                If UserLogin = True Then
                    'NumberFocus
                    txtPcs.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                    txtWeight.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                    txtLength.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                    txtWidth.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                    txtHeight.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                    'NumberBlur
                    txtPcs.Attributes.Add("OnBlur", "NumberBlurBooking(event,0,true);UpdateDimension(" + strTrxNo + "," + intLineitemno + ",'Pcs','" + txtPcs.ClientID + "');GetTotalValue();")
                    txtWeight.Attributes.Add("OnBlur", "NumberBlurBooking(event,1,true);UpdateDimension(" + strTrxNo + "," + intLineitemno + ",'GrossWeight','" + txtWeight.ClientID + "');GetTotalValue();")
                    txtLength.Attributes.Add("OnBlur", "NumberBlurBooking(event,1,true);UpdateDimension(" + strTrxNo + "," + intLineitemno + ",'Length','" + txtLength.ClientID + "');GetTotalValue();")
                    txtWidth.Attributes.Add("OnBlur", "NumberBlurBooking(event,1,true);UpdateDimension(" + strTrxNo + "," + intLineitemno + ",'Width','" + txtWidth.ClientID + "');GetTotalValue();")
                    txtHeight.Attributes.Add("OnBlur", "NumberBlurBooking(event,1,true);UpdateDimension(" + strTrxNo + "," + intLineitemno + ",'Height','" + txtHeight.ClientID + "');GetTotalValue();")
                    ''NumberInput
                    txtPcs.Attributes.Add("OnKeypress", "NumberInput(event,0);")
                    txtWeight.Attributes.Add("OnKeypress", "NumberInput(event,1);")
                    txtLength.Attributes.Add("OnKeypress", "NumberInput(event,1);")
                    txtWidth.Attributes.Add("OnKeypress", "NumberInput(event,1);")
                    txtHeight.Attributes.Add("OnKeypress", "NumberInput(event,1);")
                Else
                    txtPcs.ReadOnly = True
                    txtWeight.ReadOnly = True
                    txtLength.ReadOnly = True
                    txtWidth.ReadOnly = True
                    txtHeight.ReadOnly = True

                End If
                If txtVolume.Text.Trim = "" Then
                    txtVolume.Text = 0
                End If
                If i = 0 Then
                Else
                    Dim txtHeightLast As TextBox = gvwDimension.Rows(i - 1).FindControl("txtHeight")
                    txtPcs.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtHeightLast.ClientID + "," + txtWeight.ClientID + ");")
                End If
                'first pcs Focus set
                txtPcs.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + drDimension.ClientID + "," + txtWeight.ClientID + ");")

                txtWeight.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtPcs.ClientID + "," + txtLength.ClientID + ");")
                txtLength.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtWeight.ClientID + "," + txtWidth.ClientID + ");")
                txtWidth.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtLength.ClientID + "," + txtHeight.ClientID + ");")
                If i < gvwDimension.Rows.Count - 1 Then
                    Dim txtPcsNext As TextBox = gvwDimension.Rows(i + 1).FindControl("txtPcs")
                    txtHeight.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtWidth.ClientID + "," + txtPcsNext.ClientID + ");")
                Else
                    txtHeight.Attributes.Add("OnKeyUp", "FocusControlDimension(event," + txtWidth.ClientID + "," + txtPcs.ClientID + ");")
                End If
            End If
        Next
    End Sub
#End Region
#Region "Third Tab"
    Public Function GetNewBookingAttach() As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = GetNewId()
            BindAttach(objUser.UserId, intTrxNo)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + intTrxNo.ToString()
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function AddSelectedAttach(ByVal strNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strSql As String
        Dim intResult As Integer
        Dim dtRec As DataTable

        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            BindAttach(objUser.UserId, intTrxNo)
            strSql = "Select AttachmentFlag from omtx1 Where TrxNo=" & intTrxNo.ToString & ""
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                strSql = "Update omtx1 set AttachmentFlag='Y' Where TrxNo=" + intTrxNo.ToString + ""
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach)
                End If
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function DeleteOneAttach(ByVal strNo As String, ByVal strFileName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strSql As String
        Dim intResult As Integer
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            Dim strAttachPath As String = Server.MapPath("../Doc/omtx1/" + intTrxNo.ToString() + "/")
            'special word
            If strFileName.IndexOf("%26") Then
                strFileName = strFileName.Replace("%26", "&")
            End If
            If strFileName.IndexOf("%2B") Then
                strFileName = strFileName.Replace("%2B", "+")
            End If
            If strFileName.IndexOf("%3D") Then
                strFileName = strFileName.Replace("%3D", "=")
            End If

            If strFileName.IndexOf("%25") Then
                strFileName = strFileName.Replace("%25", "%")
            End If
            If strFileName.IndexOf("%23") Then
                strFileName = strFileName.Replace("%23", "#")
            End If
            If clsAttachFileDirectory.DeleteFile(strAttachPath + Server.HtmlDecode(strFileName)) Then
                BindAttach(objUser.UserId, intTrxNo)
                gvwAttach.DataSource = objAttach.ArrProp
                If objAttach.ArrProp.Count > 1 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
                    strSql = "Update omtx1 set AttachmentFlag='N' Where TrxNo=" + intTrxNo.ToString + ""
                    intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "N" + ConSeparator.Par + "N"
                End If
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Sub BindAttach(ByVal intUserId As String, ByVal intTrxNo As Int64)
        objAttach = New clsAttach(intUserId, intTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Doc/omtx1/" + intTrxNo.ToString() + "/"), "omtx1")
        gvwAttach.DataSource = objAttach.ArrProp
        gvwAttach.DataBind()
    End Sub
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim objUser As clsUser = Nothing
        Dim UserLogin As Boolean = GetCurrentUserInfo(Page, objUser)
        If UserLogin = True Then
            objBooking = NewObjectList(objUser.UserId, objUser.RoleName, Session("BookingFunNo"))
            If objBooking.EditPrivilege = False Then
                UserLogin = False
            End If
            If objBooking.NewPrivilege = True And Request("Id") Is Nothing Then
                UserLogin = True
            End If
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim tmpBookingAttach As clsPropAttach = CType(objAttach.ArrProp(e.Row.RowIndex), clsPropAttach)
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objAttach.Count - 1 And UserLogin = True Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneAttach(""" + Server.HtmlEncode(tmpBookingAttach.FileName) + """);return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objAttach.Count - 1 And UserLogin = True Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedAttach();return false;")
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objAttach.Count - 1 And UserLogin = False Then
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            End If
        End If
    End Sub
#End Region
#Region "public"
    Private Sub SetInitValue(ByVal intUserId As String)
        divline_Packing.Style.Add("display", "none")
        divline_Telephone.Style.Add("display", "none")
        divline_Module.Style.Add("display", "none")

        'set control hid
        If strModuleCode = "1" Then
            lblEtaDate.Text = "ETA"
            lblEtdDate.Text = "ETD"
            divlblAlirline.Style.Add("display", "none")
            div_lblAirPortofDestination.Style.Add("display", "none")
            div_lblAirPortofDeparture.Style.Add("display", "none")
            ''TP090325
            divline_CollectFrom.Style.Add("display", "none")
            divline_DeliverTo.Style.Add("display", "none")
            divline_PickupDateTimeTP.Style.Add("display", "none")
            divline_CargoDeliverDateTime.Style.Add("display", "none")
            divline_CargoDescriptionAddress.Style.Add("display", "none")
            divline_DeliverToAddress.Style.Add("display", "none")
        ElseIf strModuleCode = "2" Then
            divhid_DgFlag.Style.Add("display", "none")
            lblEtaDate.Text = "Arrival Date"
            lblEtdDate.Text = "Flight Date"
            divlblVoyageNo.Style.Add("display", "none")
            divlblNoOfContainer1.Style.Add("display", "none")
            div_lblPortOfDischargeCode.Style.Add("display", "none")
            div_lblPortOfLoadingCode.Style.Add("display", "none")
            ''TP090325
            divline_CollectFrom.Style.Add("display", "none")
            divline_DeliverTo.Style.Add("display", "none")
            divline_PickupDateTimeTP.Style.Add("display", "none")
            divline_CargoDeliverDateTime.Style.Add("display", "none")
            divline_CargoDescriptionAddress.Style.Add("display", "none")
            divline_DeliverToAddress.Style.Add("display", "none")
        ElseIf strModuleCode = "3" Then
            divline_OriginCode.Style.Add("display", "none")
            divline_DestCode.Style.Add("display", "none")
            div_lblPortOfLoadingCode.Style.Add("display", "none")
            div_lblAirPortofDeparture.Style.Add("display", "none")
            div_lblPortOfDischargeCode.Style.Add("display", "none")
            div_lblAirPortofDestination.Style.Add("display", "none")
            divlblVoyageNo.Style.Add("display", "none")
            divlblAlirline.Style.Add("display", "none")
            divline_PickupAddress.Style.Add("display", "none")
            divline_PickupDateTime.Style.Add("display", "none")
            divline_ShipperName.Style.Add("display", "none")
            divline_ConsignessName.Style.Add("display", "none")
            divline_EtaDate.Style.Add("display", "none")
            divline_EtdDate.Style.Add("display", "none")
            divline_CargoAddress.Style.Add("display", "none")
            divline_ConsigneeAddress.Style.Add("display", "none")
        Else
            divline_ShipperName.Style.Add("display", "none")
            divline_CollectFrom.Style.Add("display", "none")
            divline_ShipperAddress.Style.Add("display", "none")
            divline_ConsignessName.Style.Add("display", "none")
            divline_DeliverTo.Style.Add("display", "none")
            divline_ConsigneeAddress.Style.Add("display", "none")
            divline_DeliverToAddress.Style.Add("display", "none")
            divline_PickupDateTimeTP.Style.Add("display", "none")
            divline_CargoDeliverDateTime.Style.Add("display", "none")
            divline_OriginCode.Style.Add("display", "none")
            div_lblPortOfLoadingCode.Style.Add("display", "none")
            div_lblAirPortofDeparture.Style.Add("display", "none")
            divline_EtdDate.Style.Add("display", "none")
            div_lblPortOfDischargeCode.Style.Add("display", "none")
            div_lblAirPortofDestination.Style.Add("display", "none")
            divline_EtaDate.Style.Add("display", "none")
            divlblVoyageNo.Style.Add("display", "none")
            divlblAlirline.Style.Add("display", "none")
            divline_DeliveryType.Style.Add("display", "none")
            divline_PickupDateTime.Style.Add("display", "none")
            divline_PickupAddress.Style.Add("display", "none")
            divline_CargoAddress.Style.Add("display", "none")
            divline_CargoDescriptionAddress.Style.Add("display", "none")
            divlblNoOfContainer1.Style.Add("display", "none")
            divline_Booking.Style.Add("display", "none")
            'lblCommodityCode.Style.Add("width", "115px")
            'lblCargoType.Style.Add("width", "120px")
            'txtCommodityCode.Style.Add("width", "50px")
            'txtCommodityName.Style.Add("width", "235px")

            divline_Packing.Style.Remove("display")
            divline_Telephone.Style.Remove("display")
            divline_Module.Style.Add("display", "inline")
            divline_CargoType.Style.Add("display", "none")
            lbPacking.Style.Add("display", "none")
            txtUomCode.Style.Add("display", "none")
            btnUom.Style.Add("display", "none")
            lblCargoType.CssClass = "lbl"
            lblCommodityCode.CssClass = "lbl"
            txtCommodityCode.Style.Add("width", "48px")
            drpCustomerName.CssClass = "txt2"
            txtDestName.Style.Add("width", "347px")
            lblCommodityCode.Style.Add("width", "115px")
            txtCommodityName.CssClass = "TextBox"
            txtCommodityName.Style.Add("width", "347px")
            lblMarkNo.Style.Add("width", "120px")
            txtMarkNo.CssClass = "TextBox txt2"
            lblSpecialInstruction.Style.Add("width", "120px")
            txtSpecialInstruction.Style.Add("width", "398px")
            lblOrderNo.Style.Add("width", "120px")
            txtOrderNo.Style.Add("width", "209px")
            lblPcs.Style.Add("margin-left", "126px")
            txtPcs.Style.Add("margin-left", "126px")
            lblPacking1.Style.Add("margin-left", "124px")
            txtPackingQty1.Style.Add("margin-left", "124px")
            lblPcs.Style.Add("width", "107px")
            txtPcs.Style.Add("margin-right", "0px")
            lblGrossWeight.Style.Add("margin-right", "10px")
            txtGrossWeight.Style.Add("margin-right", "10px")

        End If
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim strwhere As String = ""
        If Request("Id") = Nothing Then
            strwhere = ""
        End If
        Dim strSql As String = "select ContainerType from Rcco1"
        Dim dt As DataTable
        dt = BaseSelectSrvr.GetData(strSql, "")
        If dt.Rows.Count > 0 Then
            txtContainerType1.DataSource = dt
            txtContainerType1.DataValueField = "ContainerType"
            txtContainerType1.DataTextField = "ContainerType"
            txtContainerType1.DataBind()
            txtContainerType1.Items.Insert(0, New ListItem("", ""))

            txtContainerType2.DataSource = dt
            txtContainerType2.DataValueField = "ContainerType"
            txtContainerType2.DataTextField = "ContainerType"
            txtContainerType2.DataBind()
            txtContainerType2.Items.Insert(0, New ListItem("", ""))
            txtContainerType3.DataSource = dt
            txtContainerType3.DataValueField = "ContainerType"
            txtContainerType3.DataTextField = "ContainerType"
            txtContainerType3.DataBind()
            txtContainerType3.Items.Insert(0, New ListItem("", ""))
        End If
        '100517
        btnPrompt.Attributes.Add("OnClick", "OpenRemark();return false;")
        btnScan.Attributes.Add("OnClick", "OpenScan();return false;")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            'add booking readonly
            Dim Guest As String = ""
            Dim User As Object
            Dim UserLogin As Boolean = False
            'If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            '    Return
            'End If
            If Not GetCurrentUserInfo(Page, objUser) = True Then
                User = Guest
                UserLogin = False
            Else
                User = objUser.UserId
                UserLogin = True
            End If
            If UserLogin = True Then
                Dim strSql As String
                Dim dt As DataTable
                strSql = "Select a.sFunNo from functioninfo a where sFunName='Booking'"
                dt = BaseSelectSrvr.GetData(strSql, "")
                If dt.Rows.Count <> 0 Then
                    Session("BookingFunNo") = dt.Rows(0).Item("sFunNo").ToString
                End If

                objBooking = NewObjectList(objUser.UserId, objUser.RoleName, Session("BookingFunNo"))
                If objBooking.EditPrivilege = False Then
                    UserLogin = False
                End If
                If objBooking.NewPrivilege = True And Request("Id") Is Nothing Then
                    UserLogin = True
                End If
            End If
            hidReports.Value = ""
            ' getAttchment(objUser.UserId, 0)
            getAttchment(User, 0)

            If Request("ModuleCode") IsNot Nothing Then
                strModuleCode = Request("ModuleCode").ToString
                If strModuleCode = "1" Then
                    hid_moduleCode.Value = "SE"
                ElseIf strModuleCode = "2" Then
                    hid_moduleCode.Value = "AE"
                ElseIf strModuleCode = "3" Then
                    hid_moduleCode.Value = "TP"
                Else
                    divMiddle11.Style.Clear()
                    txtOrderNo.ReadOnly = False
                    divMiddle11.Style.Add("width", "100%")
                    divMiddle11.Style.Add("display", "block")
                    divMiddle12.Style.Add("display", "block")
                    divMiddle11.Style.Add("padding-left", "10px")
                    divMiddle12.Style.Add("padding-left", "11px")
                End If
            End If
            fldId.Value = -1
            'Set Default Value
            'SetInitValue(objUser.UserId)
            'hidUserNo.Value = objUser.UserId
            SetInitValue(User)
            hidUserNo.Value = User
            hid_OrderNo.Value = ""
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                fldId.Value = intTrxNo
                BindSourceData(User, intTrxNo)
                ' BindSourceData(objUser.UserId, intTrxNo)
            Else
                BindSourceData(User, intTrxNo)
            End If
            'BindDetailData(objUser.UserId, intTrxNo)
            BindDetailData(User, intTrxNo)
            'DateTime Event'And objList.EditPrivilege = True
            If UserLogin = True Then
                btnOrderDate.Attributes.Add("OnClick", "showCalendar(txtOrderDate,0);return false;")
                btnlblEtdDate.Attributes.Add("OnClick", "showCalendar(txtlblEtdDate,0);return false;")
                btnlblEtaDate.Attributes.Add("OnClick", "showCalendar(txtlblEtaDate,0);return false;")
                '090325.net836
                btnPickupDateTimeTP.Attributes.Add("OnClick", "showCalendar(txtPickupDateTimeTP,0);return false;")
                btnCargoDeliverDateTime.Attributes.Add("OnClick", "showCalendar(txtCargoDeliverDateTime,0);return false;")
                'F4 Search
                drpCustomerName.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selBindCode(" + hid_CustomerCode.ClientID + "," + drpCustomerName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Customer Code','Customer Name');}return false;")
                txtDestCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtDestCode.ClientID + "," + txtDestName.ClientID + ",'Rcct1','CityCode,CityName','','Destination Code','Destination' );return false;}return false;")
                txtCommodityCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtCommodityCode.ClientID + "," + txtCommodityName.ClientID + ",'Rccm1','CommodityCode,CommodityDescription','','Commodity Code','Commodity Name');}return false;")
                txtOriginCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtOriginCode.ClientID + "," + txtOriginName.ClientID + ",'Rcct1','CityCode,CityName','','Origin Code','Origin Name');}return false;")
                txtDestCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtDestCode.ClientID + "," + txtDestName.ClientID + ",'Rcct1','CityCode,CityName','','Destination Code','Destination' );}return false;")
                txtPortOfLoadingCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtPortOfLoadingCode.ClientID + "," + txtPortOfLoadingName.ClientID + ",'Rcsp1','PortCode,PortName','','PortOfLoading Code','PortOfLoading Name' );}return false;")
                txtPortOfDischargeCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtPortOfDischargeCode.ClientID + "," + txtPortOfDischargeName.ClientID + ",'Rcsp1','PortCode,PortName','','PortOfDischarge Code','PortOfDischarge Name' );}return false;")
                txtVoyageName.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtVoyageNo.ClientID + "," + txtVoyageName.ClientID + ",'rcvy1 a left join rcvs1 b on b.VesselCode=a.VesselCode ','distinct a.VoyageNo,b.VesselName','and isnull(b.VesselCode,\'\')<>\'\' and isnull(a.VoyageNo,\'\')<>\'\'','Voyage Code','Voyage Name');}return false;")
                txtDeliveryType.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selCN(" + txtDeliveryType.ClientID + "," + txtDelivery.ClientID + ",'Rcdl1','DeliveryType,DeliveryTypeName','','Delivery Type','Delivery Name');}return false;")
                txtUomCode.Attributes.Add("OnKeyUp", "if(event.keyCode==115){selBindCode(" + txtUomCode.ClientID + "," + hid_UomCode.ClientID + ",'rcum1','UomCode,UomDescription','','Uom Code','UomName');}return false;")

                btnCustomerName.Attributes.Add("OnClick", "selBindCode(" + hid_CustomerCode.ClientID + "," + drpCustomerName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Customer Code','Customer Name');return false;")
                btnOrigin.Attributes.Add("OnClick", "selCN(" + txtOriginCode.ClientID + "," + txtOriginName.ClientID + ",'Rcct1','CityCode,CityName','','Origin Code','Origin Name');return false;")
                btnDestCode.Attributes.Add("OnClick", "selCN(" + txtDestCode.ClientID + "," + txtDestName.ClientID + ",'Rcct1','CityCode,CityName','','Destination Code','Destination' );return false;")
                btnPortOfLoading.Attributes.Add("OnClick", "selCN(" + txtPortOfLoadingCode.ClientID + "," + txtPortOfLoadingName.ClientID + ",'Rcsp1','PortCode,PortName','','PortOfLoading Code','PortOfLoading Name' );return false;")
                '<090313
                btnAirPortofDeparture.Attributes.Add("OnClick", "selCN(" + txtAirPortofDepartureCode.ClientID + "," + txtAirPortofDepartureName.ClientID + ",'rcap1','AirportCode,AirportName','','AirDeparture Code','AirPort Departure' );return false;")
                btnAirDestinationDestination.Attributes.Add("OnClick", "selCN(" + txtAirPortDestinationCode.ClientID + "," + txtAirPortDestinationName.ClientID + ",'rcap1','AirportCode,AirportName','','AirDestination Code','AirPort Destination' );return false;")
                btnAlirlineID.Attributes.Add("OnClick", "selBindCode(" + hid_AlirlineID.ClientID + "," + txtAlirlineID.ClientID + ",'rcal1','airlineCode,airlineid','','Airline Code','Airline ID');return false;")
                txtAirPortofDepartureCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtAirPortofDepartureCode.ClientID + ",'AirportCode','AirportName','AirPortofDeparture','rcap1');return false;")
                txtAirPortDestinationCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtAirPortDestinationCode.ClientID + ",'AirportCode','AirportName','AirPortDestination','rcap1');return false;")
                '090313>

                btnPortOfDischargeName.Attributes.Add("OnClick", "selCN(" + txtPortOfDischargeCode.ClientID + "," + txtPortOfDischargeName.ClientID + ",'Rcsp1','PortCode,PortName','','PortOfDischarge Code','PortOfDischarge Name' );return false;")

                btnVoyageName.Attributes.Add("OnClick", "selCN(" + txtVoyageNo.ClientID + "," + txtVoyageName.ClientID + ",'rcvy1 a left join rcvs1 b on b.VesselCode=a.VesselCode ','distinct a.VoyageNo,b.VesselName','and isnull(b.VesselCode,\'\')<>\'\' and isnull(a.VoyageNo,\'\')<>\'\'','Voyage Code','Voyage Name');return false;")

                'select  airlineid  from rcal1 

                btnDelivery.Attributes.Add("OnClick", "selCN(" + txtDeliveryType.ClientID + "," + txtDelivery.ClientID + ",'Rcdl1','DeliveryType,DeliveryTypeName','','Delivery Type','Delivery Name');return false;")


                btnCommodity.Attributes.Add("OnClick", "selCN(" + txtCommodityCode.ClientID + "," + txtCommodityName.ClientID + ",'Rccm1','CommodityCode,CommodityDescription','','Commodity Code','Commodity Name');return false;")
                btnUom.Attributes.Add("OnClick", "selBindCode(" + txtUomCode.ClientID + "," + hid_UomCode.ClientID + ",'rcum1','UomCode,UomDescription','','Uom Code','UomName');return false;")
                btnPickupDateTime.Attributes.Add("OnClick", "showCalendar(txtPickupDateTime,0);return false;")
                'Button Event 
                btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
                btnSave.Attributes.Add("OnClick", "SaveBookingDetail('" + objServer.Title + "',2);return false;")
                btnConfirmOrder.Attributes.Add("OnClick", "ConfirmSaveBooking('" + objServer.Title + "',3);return false;")
                'CheckValue
                drpCustomerName.Attributes.Add("OnBlur", "CheckValue('drpCustomerName','BusinessPartyName','rcbp1');return false;")

                txtOriginCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtOriginCode.ClientID + ",'CityCode','CityName','Origin','Rcct1');return false;")
                txtDestCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtDestCode.ClientID + ",'CityCode','CityName','DestCode','Rcct1');return false;")
                txtPortOfLoadingCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtPortOfLoadingCode.ClientID + ",'PortCode','PortName','Loading','Rcsp1');return false;")
                txtPortOfDischargeCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtPortOfDischargeCode.ClientID + ",'PortCode','PortName','Discharge','Rcsp1');return false;")
                txtDeliveryType.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtDeliveryType.ClientID + ",'DeliveryType','DeliveryTypeName','Delivery','Rcdl1');return false;")
                txtCommodityCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtCommodityCode.ClientID + ",'CommodityCode','CommodityDescription','Commodity','Rccm1');return false;")
                'by lzw 090610
                txtVoyageName.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtVoyageName.ClientID + ",'b.VesselName','a.VoyageNo','Voyage','rcvy1 a left join rcvs1 b on b.VesselCode=a.VesselCode');return false;")
                txtUomCode.Attributes.Add("OnBlur", "CheckDoubleValue(" + txtUomCode.ClientID + ",'UomCode','UomDescription','Uom','rcum1');return false;")
                'change in/cm-090318
                drDimension.Attributes.Add("onchange", "GetTotalValue();return false;")
                KeydownEvent()
                KeyUpEvent()
                '  BindAttach(objUser.UserId, intTrxNo)And objList.EditPrivilege = True

            End If
            BindAttach(User, intTrxNo)
            If UserLogin = True Then

                btnSend0.Attributes.Add("OnClick", "SendDetail(" + intTrxNo.ToString() + ",0);return false;")
                'btnRefresh.Attributes.Add("OnClick", "return false;")
                btnContactName.Attributes.Add("OnClick", "selBindContactName(" + drpContactName.ClientID + ",'Rcbp3',' distinct BusinessPartyCode,ContactName',' and BusinessPartyCode=\'" + hid_CustomerCode.Value + "\'','Contact Code','Contact Name');return false;")
                '100517
                'txtOrderType.Attributes.Add("onBlur", "CheckOrderType(" + txtOrderNo.ClientID + "," + txtOrderType.ClientID + ");return false;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "", "<script language='javascript'>var TabNo=1;</script>")
                txtOrderNo.Attributes.Add("onchange", "getOrderNoBarCode(" + txtOrderNo.ClientID + "); return false;")
                'txtVolume
                txtVolume.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
                txtVolume.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
                txtVolume.Attributes.Add("OnKeypress", "NumberInput(event,4);")
                'txtGrossWeight
                txtGrossWeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
                txtGrossWeight.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
                txtGrossWeight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
                btnUpdate.Attributes.Add("OnClick", "UpdateTotal(" + txtTotalPcs.ClientID + "," + txtTotalWeight.ClientID + "," + txtTotalVolumn.ClientID + ");return false;")

            End If
            btnUpdate.Style.Add("display", "none")
            btnPrompt.Style.Add("display", "none")
            'show issue button or no
            Try
                Dim strIssue As String = ConfigurationManager.AppSettings.Item("showIssue")
                If strIssue = "y" Then
                    btnPrompt.Style.Remove("display")
                End If
            Catch ex As Exception

            End Try
            ' Dim Edit As Boolean = IIf(UserLogin = False, True, objList.EditPrivilege = False)Or objList.EditPrivilege = False 
            If UserLogin = False Then
                btnUpdate.Style.Add("display", "none")
                btnSave.Style.Add("display", "none")
                ' btnPrint.Style.Add("display", "none")

                txtOrderDate.ReadOnly = True
                drpCustomerName.ReadOnly = True
                drpContactName.ReadOnly = True
                txtTelephone.ReadOnly = True
                txtDestCode.ReadOnly = True
                txtDestName.ReadOnly = True
                txtCommodityCode.ReadOnly = True
                txtCommodityName.ReadOnly = True
                txtPcs.ReadOnly = True
                txtGrossWeight.ReadOnly = True
                txtVolume.ReadOnly = True
                txtMarkNo.ReadOnly = True
                txtSpecialInstruction.ReadOnly = True
                txtOrderType.ReadOnly = True
                txtOrderNo.ReadOnly = True
                txtPackingQty1.ReadOnly = True
                txtPackingQty2.ReadOnly = True
                txtPackingQty3.ReadOnly = True
                txtPackingQty4.ReadOnly = True
                txtPackingQty5.ReadOnly = True

                btnOrderDate.Style.Add("display", "none")
                btnCustomerName.Style.Add("display", "none")
                btnContactName.Style.Add("display", "none")
                btnCommodity.Style.Add("display", "none")
                'btnScan.Style.Add("display", "none")
                btnDestCode.Style.Add("display", "none")
                divline_CommodityCode.Style.Value = ""
                drModule.Enabled = False
                txtCargoType.Enabled = False
                a1.Attributes.Remove("OnClick")
                a2.Attributes.Remove("OnClick")
                a3.Attributes.Remove("OnClick")

                a1.Attributes.Add("OnClick", "showDiv(1);")
                a2.Attributes.Add("OnClick", "showDiv(2);")
                a3.Attributes.Add("OnClick", "showDiv(3);")
                btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
                drDimension.Attributes.Add("onchange", "GetTotalValue();return false;")
                ' lblCargoType.CssClass = "lblRead"
                'lblCommodityCode.Style.Value = "width:50px;"
                'lblPcs.Style.Value = "margin-left:70px;"
                'lblCommodityCode.Style.Value = "width:50px;"
                'lblCommodityCode.Style.Value = "width:50px;"
                'lblCommodityCode.Style.Value = "width:50px;"
                '  .ReadOnly = True
                'a2.Style.Add("display", "none")
                ' a3.Style.Add("display", "none")
            End If
        End If
    End Sub
    Private Function getTrxNo() As String
        Dim strTrxNo As String = ""
        Dim dtReclzw As DataTable
        dtReclzw = BaseSelectSrvr.GetData("select max(TrxNo) as TrxNo from omtx1", "")
        strTrxNo = dtReclzw.Rows(0)("TrxNo")
        Return strTrxNo
    End Function
#End Region
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Private Sub getAttchment(ByVal intUserId As String, ByVal intTrxNo As Int64)
        objAttach = New clsAttach(intUserId, intTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Report/CustomerServices/omtx/"), "")
        Dim arr As ArrayList = objAttach.ArrProp
        If arr.Count = 2 Then
            Dim tmpProp As clsProp = arr(0)
            hidReports.Value += CType(tmpProp, clsPropAttach).FileName.Replace(".rpt", "")
        Else
            For i As Integer = 0 To arr.Count - 2
                Dim tmpProp As clsProp = arr(i)
                hidReports.Value += CType(tmpProp, clsPropAttach).FileName.Replace(".rpt", "") + ","
            Next
        End If

    End Sub
    Public Function getOrderNoBarCode(ByVal input As String) As String
        Dim strFlag As String = "n"
        If input.Trim <> "" Then
            strFlag = "y"
        Else
            strFlag = "n"
        End If
        Try
            Dim endchar As Char
            Dim total As Int64 = 104
            Dim tmp As Integer
            For i As Int16 = 1 To input.Length
                tmp = Asc(input.Substring(i - 1, 1))
                If tmp >= 32 Then
                    total += (tmp - 32) * i
                Else
                    total += (tmp + 64) * i
                End If
            Next
            Dim endAsc As Integer = total Mod 103
            If endAsc >= 95 Then
                Select Case endAsc
                    Case 95
                        endchar = "Ã"
                    Case 96
                        endchar = "Ä"
                    Case 97
                        endchar = "Å"
                    Case 98
                        endchar = "Æ"
                    Case 99
                        endchar = "Ç"
                    Case 100
                        endchar = "È"
                    Case 101
                        endchar = "É"
                    Case 102
                        endchar = "Ê"
                End Select
            Else
                endAsc += 32
                endchar = Chr(endAsc)
            End If
            Return "Ì" & input & endchar.ToString() & "Î" + ConSeparator.Par + strFlag
        Catch ex As Exception
            Return "" + ConSeparator.Par + strFlag
        Finally
        End Try
    End Function
    'UpdateTotal 100521 
    Public Function UpdateTotal(ByRef Pcs As String, ByRef Weight As String, ByRef Volume As String, ByVal strTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = "update omtx1 set Pcs=" + Pcs + ",GrossWeight=" + Weight + ",Volume=" + Volume + " where TrxNo=" + strTrxNo
                Dim Flag As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + Pcs + ConSeparator.Par + Weight + ConSeparator.Par + Volume
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.Err + "Update Successfully"
            End Try
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
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
    Sub getFunNo()

    End Sub 
End Class
