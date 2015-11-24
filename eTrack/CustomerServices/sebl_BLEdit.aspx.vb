Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports Ntools
Imports System.Data.SqlClient
Imports SysMagic

Partial Class sebl_BLEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objServer As clsQua
    Private objSebl2 As clsSebl2_BL
    Private returnValue As String
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
        Return New clsQua(intUserId)
    End Function

    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
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
                    con.Text = strVal.ToString("dd/MM/yyyy")
                Else
                    con.Text = strVal.ToString("dd/MM/yyyy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal objuser As clsUser, ByVal intTrxNo As Int64)
        objServer = NewServerObject(objuser.UserId)
        hidReports.Value = ""

        getAttchment(objuser.UserId, 0)

        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropQua = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            fldId.Value = tmpProp.TrxNo.ToString()
            txtBookingNo.Text = tmpProp.BookingNo
            txtBlNo.Text = tmpProp.BlNo
            drShipmentType.SelectedValue = tmpProp.ShipmentType
            txtOBlNo.Text = tmpProp.OBlNo
            hidCustomerCode.Value = tmpProp.CustomerCode
            txtCustomerName.Text = tmpProp.CustomerName
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
            txtNotifyName.Text = tmpProp.NotifyName
            txtNotifyAddress1.Text = tmpProp.NotifyAddress1
            txtNotifyAddress2.Text = tmpProp.NotifyAddress2
            txtNotifyAddress3.Text = tmpProp.NotifyAddress3
            txtNotifyAddress4.Text = tmpProp.NotifyAddress4
            txtDeliveryAgentName.Text = tmpProp.DeliveryAgentName
            txtDeliveryAgentAddress1.Text = tmpProp.DeliveryAgentAddress1
            txtDeliveryAgentAddress2.Text = tmpProp.DeliveryAgentAddress2
            txtDeliveryAgentAddress3.Text = tmpProp.DeliveryAgentAddress3
            txtDeliveryAgentAddress4.Text = tmpProp.DeliveryAgentAddress4
            drCargoType.SelectedValue = tmpProp.CargoType
            drDestCargoType.SelectedValue = tmpProp.DestCargoType
            txtCargoClass.Text = tmpProp.CargoClass
            txtCommodityCode.Text = tmpProp.CommodityCode
            txtCommodityDescription.Text = tmpProp.CommodityDescription
            txtOriginCode.Text = tmpProp.OriginCode
            txtDestCode.Text = tmpProp.DestCode
            txtDestName.Text = tmpProp.DestName
            txtPlaceOfReceipt.Text = tmpProp.PlaceOfReceipt
            txtPortOfLoadingName.Text = tmpProp.PortOfLoadingName

            ETDSelect.sDateValue = tmpProp.EtdDate
            'ConvertDateTime(txtEtdDate, tmpProp.EtdDate)
            txtPortOfDischargeCode.Text = tmpProp.PortOfDischargeCode
            txtPortOfDischargeName.Text = tmpProp.PortOfDischargeName
            ETASelect.sDateValue = tmpProp.EtaDate
            txtPlaceOfDelivery.Text = tmpProp.PlaceOfDelivery
            txtVesselName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            txtShippingLineCode.Text = tmpProp.ShippinglineCode
            txtShippingDescription.Text = tmpProp.ShippingDescription
            drFreight.SelectedValue = tmpProp.FrtPpCcFlag
            drBlSurrenderFlag.SelectedValue = tmpProp.BlSurrenderFlag
            txtNoOfOriginBl.Text = tmpProp.NoOfOriginBl
            txtBlIssuePlace.Text = tmpProp.BlIssuePlace

            BlIssueSelect.sDateValue = tmpProp.BlIssueDate
            LadenSelect.sDateValue = tmpProp.LadenDate
            txtIssueBy.Text = tmpProp.SignBy
            txtTotalPcsInWord.Text = tmpProp.TotalPcsInWord
            txtPrepaidAt.Text = tmpProp.PpAt
            txtPayableAt.Text = tmpProp.PayableAt
            txtJobNo.Text = tmpProp.JobNo
            txtCreateBy.Text = tmpProp.CreateBy
            CeateDateSelect.sDateValue = tmpProp.CreateDateTime
            txtOriginName.Text = tmpProp.OriginDescription
            btnPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ",'" + hidReports.Value + "');return false;")
        Else
            txtCustomerName.Text = objuser.UserName
            CeateDateSelect.sDateValue = Now.Date
        End If

        Me.Title = "B/L Entry"
    End Sub
    Private Sub KeyUpEvent()

        setUpperCase(txtShipperName)
        setUpperCase(txtConsignessName)

        setUpperCase(txtJobNo)
    End Sub
    Private Sub setUpperCase(ByRef FirCon As TextBox)
        FirCon.Attributes.Add("OnBlur", "setToUpperCase(" + FirCon.ClientID + ");")
    End Sub
    Private Sub KeydownEvent()
        setFocusControl(Nothing, txtBookingNo, txtBlNo)
        setFocusControl(txtBookingNo, txtBlNo, drShipmentType)
        setFocusControl(txtBlNo, drShipmentType, txtOBlNo)
        setFocusControl(drShipmentType, txtOBlNo, txtCustomerName)
        setFocusControl(txtOBlNo, txtCustomerName, txtShipperName)
        setFocusControl(txtCustomerName, txtShipperName, txtShipperAddress1)
        setFocusControl(txtShipperName, txtShipperAddress1, txtShipperAddress2)
        setFocusControl(txtShipperAddress1, txtShipperAddress2, txtShipperAddress3)
        setFocusControl(txtShipperAddress2, txtShipperAddress3, txtShipperAddress4)
        setFocusControl(txtShipperAddress3, txtShipperAddress4, txtConsignessName)
        setFocusControl(txtShipperAddress4, txtConsignessName, txtConsigneeAddress1)
        setFocusControl(txtConsignessName, txtConsigneeAddress1, txtConsigneeAddress2)
        setFocusControl(txtConsigneeAddress1, txtConsigneeAddress2, txtConsigneeAddress3)
        setFocusControl(txtConsigneeAddress2, txtConsigneeAddress3, txtConsigneeAddress4)
        setFocusControl(txtConsigneeAddress3, txtConsigneeAddress4, txtNotifyName)
        setFocusControl(txtConsigneeAddress4, txtNotifyName, txtNotifyAddress1)
        setFocusControl(txtNotifyName, txtNotifyAddress1, txtNotifyAddress2)
        setFocusControl(txtNotifyAddress1, txtNotifyAddress2, txtNotifyAddress3)
        setFocusControl(txtNotifyAddress2, txtNotifyAddress3, txtNotifyAddress4)
        setFocusControl(txtNotifyAddress3, txtNotifyAddress4, txtDeliveryAgentName)
        setFocusControl(txtNotifyAddress4, txtDeliveryAgentName, txtDeliveryAgentAddress1)
        setFocusControl(txtDeliveryAgentName, txtDeliveryAgentAddress1, txtDeliveryAgentAddress2)
        setFocusControl(txtDeliveryAgentAddress1, txtDeliveryAgentAddress2, txtDeliveryAgentAddress3)
        setFocusControl(txtDeliveryAgentAddress2, txtDeliveryAgentAddress3, txtDeliveryAgentAddress4)
        setFocusControl(txtDeliveryAgentAddress3, txtDeliveryAgentAddress4, drCargoType)
        setFocusControl(txtDeliveryAgentAddress4, drCargoType, drDestCargoType)
        setFocusControl(drCargoType, drDestCargoType, txtCargoClass)
        setFocusControl(drDestCargoType, txtCargoClass, txtCommodityCode)
        setFocusControl(txtCargoClass, txtCommodityCode, txtCommodityDescription)
        setFocusControl(txtCommodityCode, txtCommodityDescription, txtOriginCode)
        setFocusControl(txtCommodityDescription, txtOriginCode, txtOriginName)
        setFocusControl(txtOriginCode, txtOriginName, txtDestCode)
        setFocusControl(txtOriginName, txtDestCode, txtDestName)
        setFocusControl(txtDestCode, txtDestName, txtPlaceOfReceipt)
        setFocusControl(txtDestName, txtPlaceOfReceipt, txtPortOfLoadingName)

        setFocusControl(txtPlaceOfReceipt, txtPortOfLoadingName, ETDSelect.Controls.Item(0))
        setFocusControl(txtPortOfLoadingName, ETDSelect.Controls.Item(0), txtPortOfDischargeCode)
        setFocusControl(ETDSelect.Controls.Item(0), txtPortOfDischargeCode, txtPortOfDischargeName)
        setFocusControl(txtPortOfDischargeCode, txtPortOfDischargeName, ETASelect.Controls.Item(0))
        setFocusControl(txtPortOfDischargeName, ETASelect.Controls.Item(0), txtPlaceOfDelivery)

        setFocusControl(ETASelect.Controls.Item(0), txtPlaceOfDelivery, txtVesselName)
        setFocusControl(txtPlaceOfDelivery, txtVesselName, txtVoyageNo)
        setFocusControl(txtVesselName, txtVoyageNo, txtShippingLineCode)
        setFocusControl(txtVoyageNo, txtShippingLineCode, txtShippingDescription)
        setFocusControl(txtShippingLineCode, txtShippingDescription, drFreight)
        setFocusControl(txtShippingDescription, drFreight, drBlSurrenderFlag)
        setFocusControl(drFreight, drBlSurrenderFlag, txtNoOfOriginBl)
        setFocusControl(drBlSurrenderFlag, txtNoOfOriginBl, txtBlIssuePlace)

        setFocusControl(txtNoOfOriginBl, txtBlIssuePlace, BlIssueSelect.Controls.Item(0))
        setFocusControl(txtBlIssuePlace, BlIssueSelect.Controls.Item(0), LadenSelect.Controls.Item(0))
        setFocusControl(BlIssueSelect.Controls.Item(0), LadenSelect.Controls.Item(0), txtIssueBy)

        setFocusControl(LadenSelect.Controls.Item(0), txtIssueBy, txtTotalPcsInWord)
        setFocusControl(txtIssueBy, txtTotalPcsInWord, txtPrepaidAt)
        setFocusControl(txtTotalPcsInWord, txtPrepaidAt, txtPayableAt)
        setFocusControl(txtPrepaidAt, txtPayableAt, txtJobNo)
        setFocusControl(txtPayableAt, txtJobNo, txtCreateBy)
        setFocusControl(txtJobNo, txtCreateBy, CeateDateSelect.Controls.Item(0))
    End Sub
    Private Sub KeydownEventDiv2()
        setFocusControl(Nothing, txtContainerNo, txtSealNo)
        setFocusControl(txtContainerNo, txtSealNo, drpContainerType)
        setFocusControl(txtSealNo, drpContainerType, txtVolume)
        setFocusControl(drpContainerType, txtVolume, txtUomCode)
        setFocusControl(txtVolume, txtUomCode, txtPcs)
        setFocusControl(txtUomCode, txtPcs, txtGrossWeight)
        setFocusControl(txtPcs, txtGrossWeight, txtMark)

    End Sub
    Public Function SaveData(ByVal strValue As String, ByVal strBooking As String) As String
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
                    End If
                    Dim intTrxNo As Int64 = GetNewId()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

#Region "Check Data (Origin,DestCode,Loading,Discharge,Delivery,Commodity)"
    Public Function CheckVal(ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strTable As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If CheckBefore(strFieldName, strFieldVal, strTable) Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "" + ConSeparator.Par + "" + ConSeparator.Par + "" + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
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

    Public Function CheckFieldVal(ByVal strFieldCode As String, ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strType As String, ByVal strTable As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            Try
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select " + strFieldName + " from " + strTable + " where " + strFieldCode + "='" + strFieldVal + "'", "")
                If dtReclzw.Rows.Count > 0 Then
                    If strFieldName.ToLower = "a.voyageno" Then
                        strFieldName = "VoyageNo"
                    End If
                    Dim strName As String = dtReclzw.Rows(0)(strFieldName)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strName
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid  " + ConSeparator.Par + strType + vbNewLine
                End If
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End Try
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function
    Public Function CheckFieldValSp(ByVal strFieldCode As String, ByVal strFieldName As String, ByVal strFieldVal As String, ByVal strType As String, ByVal strTable As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            Try
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select " + strFieldName + " from " + strTable + " where " + strFieldCode + "='" + strFieldVal + "'", "")
                Dim dtRecCou As DataTable
                dtRecCou = BaseSelectSrvr.GetData("select Count(*) from " + strTable + "", "")
                If CInt(dtRecCou.Rows(0)(0)) = 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
                ElseIf dtReclzw.Rows.Count > 0 Then
                    Dim strName As String = dtReclzw.Rows(0)(strFieldName)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strName
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid  " + ConSeparator.Par + strType + vbNewLine
                End If
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End Try
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function
#End Region
#Region "public"
    Private Sub SetInitValue(ByVal intUserId As String)
        Dim tmpTable As DataTable = BaseSelectSrvr.GetData("select * from rcco1", "")
        drpContainerType.DataSource = tmpTable
        drpContainerType.DataTextField = "ContainerType"
        drpContainerType.DataValueField = "ContainerType"
        drpContainerType.DataBind()

        btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
        btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        txtOBlNo.ReadOnly = True
        'bind button for open page
        btnCustomerCode.Attributes.Add("OnClick", "selCN(" + hidCustomerCode.ClientID + "," + txtCustomerName.ClientID + ",'Rcbp1','BusinessPartyCode,BusinessPartyName','','Customer Code','Customer Name');return false;")
        btnCommodity.Attributes.Add("OnClick", "selCN(" + txtCommodityCode.ClientID + "," + txtCommodityDescription.ClientID + ",'Rccm1','CommodityCode,CommodityDescription','','Commodity Code','Commodity Description');return false;")
        btnOrigin.Attributes.Add("OnClick", "selCN(" + txtOriginCode.ClientID + "," + txtOriginName.ClientID + ",'Rcct1','CityCode,CityName','','Origin Code','Origin Name');return false;")
        btnDest.Attributes.Add("OnClick", "selCN(" + txtDestCode.ClientID + "," + txtDestName.ClientID + ",'Rcct1','CityCode,CityName','','Destination Code','Destination' );return false;")
        btnPortOfDischarge.Attributes.Add("OnClick", "selCN(" + txtPortOfDischargeCode.ClientID + "," + txtPortOfDischargeName.ClientID + ",'Rcsp1','PortCode,PortName','','PortOfDischarge Code','PortOfDischarge Name' );return false;")
        btnVessel.Attributes.Add("OnClick", "selFix(" + txtVoyageNo.ClientID + "," + txtVoyageNo.ClientID + ",'rcvy1 a left join rcvs1 b on b.VesselCode=a.VesselCode ','distinct a.VoyageNo,b.VesselName','and isnull(b.VesselCode,\'\')<>\'\' and isnull(a.VoyageNo,\'\')<>\'\'','Voyage Code','Voyage Name');return false;")
        btnShippingDescription.Attributes.Add("OnClick", "selCN(" + txtShippingLineCode.ClientID + "," + txtShippingDescription.ClientID + ",'rcsl1','ShippingLineCode,ShippingLineName','','ShippingLine Code','ShippingLine Name' );return false;")
        'Check Code Availability
        txtCommodityCode.Attributes.Add("onChange", "CheckFieldVal(" + txtCommodityCode.ClientID + ",'CommodityCode','CommodityDescription','Commodity Code','Rccm1');return false;")
        txtOriginCode.Attributes.Add("onChange", "CheckFieldVal(" + txtOriginCode.ClientID + ",'CityCode','CityName','Origin Code','Rcct1');return false;")
        txtDestCode.Attributes.Add("onChange", "CheckFieldVal(" + txtDestCode.ClientID + ",'CityCode','CityName','Dest Code','Rcct1');return false;")
        txtPortOfDischargeCode.Attributes.Add("onChange", "CheckFieldVal(" + txtPortOfDischargeCode.ClientID + ",'PortCode','PortName','Port Of Discharge Code','Rcsp1');return false;")
        txtShippingLineCode.Attributes.Add("onChange", "CheckFieldVal(" + txtShippingLineCode.ClientID + ",'ShippingLineCode','ShippingLineName','Shipping Line Code','rcsl1');return false;")
        'add by danny 
        txtContainerNo.Attributes.Add("onChange", "CheckFieldValSp(" + txtContainerNo.ClientID + ",'ContainerNo','ContainerNo','Container No','rccf1');return false;")
        txtVolume.Attributes.Add("OnKeypress", "NumberInput(event,4);")
        txtPcs.Attributes.Add("OnKeypress", "NumberInput(event,0);")
        txtGrossWeight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
        btnNew.Attributes.Add("OnClick", "ClearDiv2Detail();return false;")
        btnNew.Style.Add("status", "false")
        btnNew.Style.Add("display", "none")
        'btnSave.Attributes.Add("OnClick", "SaveDiv2Detail('" + objServer.Title + "',1);return false;")

        txtMark.Attributes.Add("OnKeyDown", "InputEnter(event," + txtMark.ID + "," + txtDescription.ID + ");")
        txtDescription.Attributes.Add("OnKeyDown", "InputEnter(event," + txtDescription.ID + ",null);")

        ' txtDescription.Attributes.Add("onpaste", "limit20Row(" + txtDescription.ID + ");")
        ' txtMark.Attributes.Add("onpaste", "limit20Row(" + txtMark.ID + ");")
        txtDescription.Attributes.Add("onpaste", "return false;")
        txtMark.Attributes.Add("onpaste", "return false;")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            fldId.Value = -1
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                HidTrxNo.Value = Request("Id")
                fldId.Value = intTrxNo
            End If
            BindDetailData(objUser, intTrxNo)
            'bind GridPageFun.GetFunNo(Page)
            objList = NewObjectList(objUser.UserId, objUser.RoleName, Session("FunNo"))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Set Default Value
            SetInitValue(objUser.UserId)
            'DateTime Event'
            KeydownEvent()
            KeydownEventDiv2()
            KeyUpEvent()
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "", "<script language='javascript'>var TabNo=1;</script>")

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
    Private Sub setFocusControl(ByRef Prev As WebControl, ByRef Curr As WebControl, ByRef Next1 As WebControl)
        If Prev IsNot Nothing Then
            Curr.Attributes.Add("OnKeyDown", "FocusControl(event," + Prev.ClientID + "," + Next1.ClientID + ");")
        Else
            Curr.Attributes.Add("OnKeyDown", "FocusControl(event,null," + Next1.ClientID + ");")
        End If

    End Sub
#Region "Tab 2 "
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsSebl2_BL(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        If objList.Where.Trim = "" Then
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
            End If
            objList.Where += " and a.TrxNo=" + intTrxNo.ToString
        End If

        objList.GetListInfo(intPage, intSize) 'GetDetail(intTrxNo)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("sebl2_BL", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString) 'Session("LoginType").ToString
        gvwSource.DataSource = objList.ArrProp
        'Dim columns() As String = getColumnNames(objColumns)
        'gvwSource.DataKeyNames = columns
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Public Function getColumnNames(ByVal table As ZZSystem.clsDynamicSqlColumn) As String()

        Dim s As String = String.Empty
        For Each c As ZZSystem.clsPropColumn In table.Column
            s += c.FieldName + ","
        Next
        Return s.TrimEnd(",").Split(",")
    End Function
    'add by danny 2010.7.6
    'Public Function LoadDiv2(ByVal strValue As String, ByVal strT As String) As Boolean
    '    Dim ArrValue() As String = GeneralFun.GetCol(strValue)
    '    Dim strTrxNo As String = ArrValue(0)
    '    Dim strLineItemNo As String = ArrValue(1)
    '    If strTrxNo <> "" And strLineItemNo <> "" Then
    '        Dim seblDt As DataTable = GetSebl2List(" and TrxNo='" + strTrxNo + "' and LineItemNo='" + strLineItemNo + "' ")

    '        ListBox1.DataSource = seblDt
    '        ListBox1.DataTextField = "GoodsDescription"
    '        ListBox1.DataValueField = "ID"
    '        ListBox1.DataBind()
    '        Return True
    '    Else
    '        Return False
    '    End If

    '    ' Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value

    'End Function
    'Private Function GetSebl2List(ByVal where As String) As DataTable
    '    Dim ds As DataSet
    '    Dim dt As DataTable
    '    Try
    '        Dim param(1) As SqlParameter

    '        param(0) = New SqlParameter("@MaxInt", SqlDbType.Int)
    '        param(0).Value = 20

    '        param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
    '        param(1).Value = where

    '        'param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
    '        'param(2).Value = Query

    '        'param(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
    '        'param(3).Value = OrderBy

    '        'param(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
    '        'param(4).Value = PageIndex

    '        'param(5) = New SqlParameter("@PageSize", SqlDbType.Int)
    '        'param(5).Value = PageSize

    '        'param(6) = New SqlParameter("@PageCount", SqlDbType.Int)
    '        'param(6).Direction = ParameterDirection.Output

    '        'param(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
    '        'param(7).Direction = ParameterDirection.Output

    '        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_track_sebl2_line_list", param)
    '        'If PageSize = 0 Then
    '        '    'Total Page Count
    '        '    PageCount = 1
    '        '    'Total Record Count
    '        '    RecordCount = ds.Tables(0).Rows.Count
    '        '    dt = ds.Tables(0)
    '        'Else
    '        '    'Total Page Count
    '        '    PageCount = Integer.Parse(param(6).Value.ToString())
    '        '    'Total Record Count
    '        '    RecordCount = Integer.Parse(param(7).Value.ToString())
    '        dt = ds.Tables(0)
    '        'End If
    '        'Sebl2Table = dt
    '        Return dt
    '    Catch
    '        Return New DataTable()
    '    End Try
    'End Function
    Public Function SaveDiv2Data(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByVal strlGoodsDescriptionList As String, ByVal strMarkNoList As String, ByVal strContainerNo As String, ByVal strSealNo As String, ByVal strContainerType As String, ByVal strVolume As String, ByVal strUomCode As String, ByVal strPcs As String, ByVal strGrossWeight As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""

        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim arrGoodsDescription() As String = GeneralFun.GetCol(strlGoodsDescriptionList)
            Dim arrMarkNo() As String = GeneralFun.GetCol(strMarkNoList)
            Dim Param(48) As SqlParameter
            If strLineItemNo = "" Or strLineItemNo = "-1" Then
                strLineItemNo = "0"
            End If
            Param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
            Param(0).Value = CInt(strTrxNo)
            Param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
            Param(1).Value = CInt(strLineItemNo)
            Param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
            Param(2).Value = strContainerNo
            Param(3) = New SqlParameter("@SealNo", SqlDbType.NVarChar, 30)
            Param(3).Value = strSealNo
            Param(4) = New SqlParameter("@ContainerType", SqlDbType.NVarChar, 5)
            Param(4).Value = strContainerType
            Param(5) = New SqlParameter("@Volume", SqlDbType.Decimal, 13, 4)
            Param(5).Value = Decimal.Parse(strVolume.PadRight(1, "0"))
            Param(6) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 3)
            Param(6).Value = strUomCode
            Param(7) = New SqlParameter("@Pcs", SqlDbType.Int)
            Param(7).Value = CInt(strPcs.PadRight(1, "0"))
            Param(8) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 13, 4)
            Param(8).Value = Decimal.Parse(strGrossWeight.PadRight(1, "0"))
            For i As Integer = 1 To 20
                Param(i + 8) = New SqlParameter("@GoodsDescription" + i.ToString.PadLeft(2, "0"), SqlDbType.NVarChar, 50)
                Param(i + 28) = New SqlParameter("@MarkNo" + i.ToString.PadLeft(2, "0"), SqlDbType.NVarChar, 25)
                If arrGoodsDescription.Length >= i Then
                    Param(i + 8).Value = arrGoodsDescription(i - 1).Replace("'", "''").Trim
                Else
                    Param(i + 8).Value = ""
                End If
                If arrMarkNo.Length >= i Then
                    Param(i + 28).Value = arrMarkNo(i - 1).Replace("'", "''").Trim
                Else
                    Param(i + 28).Value = ""
                End If
            Next
            Dim result As Integer = 0
            If strTrxNo <> "" Then

                If strLineItemNo.Trim = "" Or strLineItemNo.Trim = "0" Then
                    result = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_track_Sebl2", Param)
                Else
                    result = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_Track_sebl2", Param)

                End If


            End If

            If result > 0 Then
                objList = NewObjectList(objUser.UserId, objUser.RoleName, Session("FunNo"))
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)

                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
            End If
        Else
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
        End If
    End Function
    Public Function DeleteDiv2Detail(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""

        If PageFun.GetCurrentUserInfo(Page, objUser) Then

            Dim Param(1) As SqlParameter
            If strLineItemNo = "" Or strLineItemNo = "-1" Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Delete false" + ConSeparator.Par + GridViewFun.RenderControl(fldId)
            End If
            Param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
            Param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
            Param(0).Value = CInt(strTrxNo)
            Param(1).Value = CInt(strLineItemNo)

            Dim result As Integer = 0
            If strTrxNo <> "" Then

                result = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_track_Sebl2_List", Param)
            End If

            If result > 0 Then
                objList = NewObjectList(objUser.UserId, objUser.RoleName, Session("FunNo"))
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)

                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Delete false" + ConSeparator.Par + GridViewFun.RenderControl(fldId)
            End If
        Else
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Delete false" + ConSeparator.Par + GridViewFun.RenderControl(fldId)
        End If
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim intLineItemNo As String = CType(tmpProp, clsPropSebl2_BL).LineItemNo.ToString()

            'Popupmenu
            If intTrxNo > 0 Then
                'e.Row.Attributes.Add("oncontextmenu", "ShowMenu('" + intLineItemNo + "');return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "Sebl2RowMouseOut(this,1,'" + intLineItemNo.ToString + "')")
            Else
                e.Row.Attributes.Add("onMouseOut", "Sebl2RowMouseOut(this,0,'" + intLineItemNo.ToString + "')")
            End If

            If tmpProp.IsDeleted = 1 Then
                e.Row.ForeColor = ConColor.Deleted
            Else
                e.Row.ForeColor = ConColor.Normal
            End If
            Dim strContainerList As String = ""
            If strContainerList.Trim <> "" Then
                strContainerList = strContainerList.Substring(0, strContainerList.Length - 1)
            End If
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Dim strFieldName As String = _ColumnInfo.FieldName
                'Get containerlist

                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime

                        Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If dtmTemp <= ConDateTime.MinDate Then
                            e.Row.Cells(i + 1).Text = ""
                        Else
                            e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyyy")
                        End If
                End Select
            Next
            'Row cann't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDiv2Detail('" + intTrxNo.ToString + "','" + intLineItemNo + "');return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            imgRestore.Visible = False

            Dim strDescription As String = ""
            Dim strMarkNo As String = ""
            Dim ObjTm As Object = CType(tmpProp, clsPropSebl2_BL)
            Dim ObjTmType As Type = ObjTm.GetType
            For l As Integer = 1 To 20

                strDescription += ObjTmType.GetProperty("GoodsDescription" + l.ToString.PadLeft(2, "0")).GetValue(ObjTm, Nothing) + ConSeparator.Col
                strMarkNo += ObjTmType.GetProperty("MarkNo" + l.ToString.PadLeft(2, "0")).GetValue(ObjTm, Nothing) + ConSeparator.Col

            Next
            strDescription = strDescription.Trim(ConSeparator.Col)
            strMarkNo = strMarkNo.Trim(ConSeparator.Col)
            Dim otherVaule As String = ""

            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).ContainerNo.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).SealNo.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).ContainerType.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).Volume.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).UomCode.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).Pcs.ToString() + "'"
            otherVaule += ",'" + CType(tmpProp, clsPropSebl2_BL).GrossWeight.ToString() + "'"

            ' e.Row.Attributes.Add("OnClick", "getValue('" + intTrxNo.ToString + "','" + intLineItemNo.ToString + "','" + strDescription + "','" + strMarkNo + "');return false;")

            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            imgEdit.Visible = False
            If Not objList.EditPrivilege Then
                e.Row.Attributes.Add("ondblclick", "return false;")
            Else
                If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                    ' imgEdit.Attributes.Add("OnClick", "getValue('" + intTrxNo.ToString + "','" + intLineItemNo.ToString + "','" + strDescription + "','" + strMarkNo + "');return false;")
                    imgEdit.Visible = False
                    If e.Row.RowIndex Mod 2 = 0 Then
                        e.Row.Attributes.Add("OnClick", "Sebl2RowSelected(this,1);getValue('" + intTrxNo.ToString + "','" + intLineItemNo.ToString + "','" + strDescription + "','" + strMarkNo + "'" + otherVaule + ");return false;")

                    Else
                        e.Row.Attributes.Add("OnClick", "Sebl2RowSelected(this,0);getValue('" + intTrxNo.ToString + "','" + intLineItemNo.ToString + "','" + strDescription + "','" + strMarkNo + "'" + otherVaule + ");return false;")

                    End If
                Else
                End If
            End If

            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            imgInsert.Visible = False
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                'imgInsert.Attributes.Add("OnClick", "InsertDetail(0);return false;")
                'e.Row.Attributes.Add("ondblclick", "InsertDetail(0);return false;")
            ElseIf tmpProp.IsAdd Then
                e.Row.Visible = False
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                For i = 1 To objColumns.Column.Count - 1
                    e.Row.Cells(i).Text = ""
                    e.Row.Attributes.Remove("OnClick")
                Next
            End If
            'add by danny
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            imgInsert.Visible = False
            imgRestore.Visible = False
            imgPrint.Visible = False
        End If
    End Sub
    Protected Sub gvwSource_RowDataBound_old(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        Dim strFun As String = PageFun.GetFunNo(Page)
        If strFun <> "1001" Then
            objList.EditPrivilege = False
        End If
        If Not objList.EditPrivilege Then
            e.Row.Cells(0).Style.Add("display", "none")
        End If
        If strFun = "1002" Then
            If e.Row.RowType = DataControlRowType.Header Then
                For i = 0 To objColumns.Column.Count - 1
                    If e.Row.Cells(i + 1).Text.ToLower.IndexOf("shipper code") >= 0 Or e.Row.Cells(i + 1).Text.ToLower.IndexOf("shipper name") >= 0 Then
                        e.Row.Cells(i + 1).Style.Add("display", "none")
                    End If
                Next
            End If
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim intLineItemNo As String = CType(tmpProp, clsPropSebl2_BL).LineItemNo.ToString()

            'Popupmenu
            If intTrxNo > 0 Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu('" + intLineItemNo + "');return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If

            If tmpProp.IsDeleted = 1 Then
                e.Row.ForeColor = ConColor.Deleted
            Else
                e.Row.ForeColor = ConColor.Normal
            End If
            'Handle display value
            Dim strContainerList As String = ""
            Dim ReleaseQty As Int64 = 0
            Dim dt As DataTable
            Dim strSql As String = "select distinct containerno from ctcl1 where RITrxNo=" + intTrxNo.ToString + " and ROLineItemNo=" + intLineItemNo
            Try
                dt = BaseSelectSrvr.GetData(strSql, "")
                If dt IsNot Nothing Then
                    ReleaseQty = dt.Rows.Count
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows.Count > 0 Then
                            strContainerList += dt.Rows(j)(0) + ","
                        End If
                    Next
                End If
                dt = Nothing
            Catch ex As Exception
            End Try
            If strContainerList.Trim <> "" Then
                strContainerList = strContainerList.Substring(0, strContainerList.Length - 1)
            End If
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Dim strFieldName As String = _ColumnInfo.FieldName
                'Get containerlist

                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime

                        Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If dtmTemp <= ConDateTime.MinDate Then
                            e.Row.Cells(i + 1).Text = ""
                        Else
                            e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyyy")
                        End If
                End Select
            Next
            'Row cann't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intTrxNo.ToString + "123456789" + intLineItemNo + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail(" + intTrxNo + ");return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If Not objList.EditPrivilege Then
                e.Row.Attributes.Add("ondblclick", "return false;")
            Else
                If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                    imgEdit.Attributes.Add("OnClick", "return false;")
                    e.Row.Attributes.Add("ondblclick", "return false;")
                Else
                    imgEdit.Visible = False
                End If
            End If
            '  e.Row.Attributes.Add("ondblclick", "EditList(" + intTrxNo.ToString() + ");return false;")
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail(0);return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail(0);return false;")
            ElseIf tmpProp.IsAdd Then
                e.Row.Visible = False
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                For i = 1 To objColumns.Column.Count - 1
                    e.Row.Cells(i).Text = ""
                    e.Row.Attributes.Remove("ondblclick")
                Next
            End If
            ' SelectCell()
            'Dim strLineItemNo, strTrxNo As String

            'strTrxNo = Request("Id")
            'strLineItemNo = "0"
            'If strTrxNo <> "" Then
            '    For k As Integer = 0 To e.Row.Cells.Count - 1

            '        If gvwSource.Columns(k).HeaderText = "LineItemNo" Then
            '            strLineItemNo = e.Row.Cells(k).Text
            '        End If
            '        If gvwSource.Columns(k).HeaderText = "TrxNo" Then
            '            If e.Row.Cells(k).Text <> "" Then
            '                strTrxNo = e.Row.Cells(k).Text
            '            End If

            '        End If
            '        e.Row.Attributes.Add("OnClick", "SelectRow('" + strTrxNo + "','" + strLineItemNo + "');return false;")
            '        'If Regex.IsMatch(gvwSource.Columns(k).HeaderText, ".{1,20}\d{2}") = True Then
            '        '    Dim Index As String = getLastNum(gvwSource.Columns(k).HeaderText)
            '        '    ' GridView1.DataKeys[row]["name"].ToString();
            '        '    ' Dim a As String = gvwSource.DataKeys(0)("TrxNo").ToString()
            '        '    Try
            '        '        Dim DataStr1 As String = gvwSource.DataKeys(e.Row.RowIndex)("GoodsDescription" + Index).ToString()
            '        '        Dim DataStr2 As String = gvwSource.DataKeys(e.Row.RowIndex)("MarkNo" + Index).ToString()
            '        '        e.Row.Cells(k).Attributes.Add("OnClick", "SelectCell('" + strTrxNo + "','" + strLineItemNo + "','" + Index + "', '" + DataStr1 + "','" + DataStr2 + "');return false;")

            '        '    Catch ex As Exception
            '        '        e.Row.Cells(k).Attributes.Add("OnClick", "return false;")

            '        '    End Try
            '        '    ' e.Row.Cells("GoodsDescription" + Index).Text(+ConSeparator.Par + e.Row.Cells("MarkNo" + Index).Text)


            '        'End If

            '    Next
            'End If

        End If
    End Sub
    Private Function getLastNum(ByVal ColumnText As String) As String
        Dim con As String = Regex.Match(ColumnText, "\d{1,5}$").Value
        Return con
    End Function
#End Region
    Private Sub getAttchment(ByVal intUserId As String, ByVal intTrxNo As Int64)
        objAttach = New clsAttach(intUserId, intTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Report/CustomerServices/sebl/"), "")
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

End Class
