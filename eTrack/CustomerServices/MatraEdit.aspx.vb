Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class MatraEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsMatra
    Private returnValue As String
    Private strRfqNo As String = ConClass.NewIdValue
    Private m_intRowCount As Integer

    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsMatra(intUserId)
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
    Private Sub BindDetailData(ByVal intUserId As String, ByVal strRfqNo As String)
        objServer = NewServerObject(intUserId)
        If Len(strRfqNo) >= 0 Then
            Dim tmpProp As clsPropMatra = objServer.GetDetail(strRfqNo)
            If Len(tmpProp.RfqNo) > 0 Then
                strRfqNo = GetNewId()
                fldId.Value = tmpProp.RfqNo.ToString()
                txtRFQNo.Text = tmpProp.RfqNo
                txtPartNo.Text = tmpProp.PartNo
                txtSerialNo.Text = tmpProp.SerialNo
                txtCreateBy.Text = tmpProp.CreateBy
                ConvertDate(txtCreateAt, tmpProp.CreateDateTime)
                txtStatus.Text = tmpProp.Status
                ConvertDate(txtMtoNotification, tmpProp.MtoNotificationDate)
                txtLocalMto.Text = tmpProp.LocalMtoCode
                txtLocalMtoName.Text = GetName("Rcbp1", "BusinessPartyCode", "BusinessPartyName", txtLocalMto.Text, "AND PartyType='MTO' AND StatusCode<>'DEL'")
                txtPickupFrom.Text = tmpProp.PickupFrom
                ConvertDate(txtPickupDate, tmpProp.PickupDate)
                txtShipTo.Text = tmpProp.ShipTo
                ConvertDate(txtShipDate, tmpProp.ShipDate)
                txtConsignmentNote.Text = tmpProp.ConsignNoteRefNo
                txtMtoRep.Text = tmpProp.MtoRep
                txtMtoRepName.Text = GetName("Rcbp1", "BusinessPartyCode", "BusinessPartyName", txtMtoRep.Text, "AND PartyType='REP' AND StatusCode<>'DEL'")
                txtMro.Text = tmpProp.Mro
                txtMroName.Text = GetName("Rcbp1", "BusinessPartyCode", "BusinessPartyName", txtMro.Text, "AND PartyType='MRO' AND StatusCode<>'DEL'")
                txtCommodity.Text = tmpProp.CommodityDescription
                txtQty.Text = tmpProp.Qty
                txtUom.Text = tmpProp.UomCode
                txtGrossWeight.Text = tmpProp.GrossWeight
                txtChargeWeight.Text = tmpProp.ChargeWeight
                txtMAwbOrOBlNo.Text = tmpProp.MawbOblNo
                txtHAwbOrHBlNo.Text = tmpProp.HawbHblNo
                txtFltOrVoyNo.Text = tmpProp.FlightOrVoyageNo
                txtAirportDeptOrPol.Text = tmpProp.OriginName
                txtAirportDestOrPod.Text = tmpProp.DestName
                ConvertDate(txtEta, tmpProp.Eta)
                ConvertDate(txtEtd, tmpProp.Etd)
                txtFinalPlaceOfDelivery.Text = tmpProp.PlaceOfDelivery
                ConvertDate(txtDestEta, tmpProp.PlaceOfDeliveryEta)

                ConvertDate(txtConsignmentDate, tmpProp.ConsignmentDate)
                txtDriverName1.Text = tmpProp.DriverName1
                txtDriverName2.Text = tmpProp.DriverName2
                txtDriverName3.Text = tmpProp.DriverName3
                txtDriveric1.Text = tmpProp.Driveric1
                txtDriveric2.Text = tmpProp.Driveric2
                txtDriveric3.Text = tmpProp.Driveric3
                ConvertDate(txtDateReceivedFromMto, tmpProp.DateReceivedFromMto)
                ConvertDate(txtDateDeliveredToMro, tmpProp.DateDeliveredToMro)
                ConvertDate(txtDateReceivedFromMtoRep, tmpProp.DateReceivedFromMtoRep)
                ConvertDate(txtDateDeliveredToMtoRep, tmpProp.DateDeliveredToMtoRep)
                ConvertDate(txtTearDownInspectionDate, tmpProp.TearDownInspectionDate)
                txtQuotationRefNo.Text = tmpProp.QuotationRefNo

                Me.Title = "Rfq No: " + tmpProp.RfqNo
            Else
                Me.Title = "Rfq No " + tmpProp.RfqNo
            End If
        End If
    End Sub

    Private Function GetName(ByVal strTable As String, ByVal strCodeField As String, ByVal strNameField As String, ByVal strCodeValue As String, ByVal strWhere As String) As String
        Dim strSQL As String = "SELECT " & strNameField & " FROM " & strTable & " WHERE " & strCodeField & "='" & strCodeValue & "' " & strWhere
        Dim ds As DataSet
        If Len(strCodeValue) = 0 Then GetName = "" : Exit Function
        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSQL)
        If ds.Tables(0).Rows.Count > 0 Then
            GetName = ds.Tables(0).Rows(0).Item(0).ToString
        Else
            GetName = ""
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            fldId.Value = ""
            Dim objUser As clsUser = Nothing
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            objServer = NewServerObject(objUser.UserId)
            If Not (Request("Id") Is Nothing) Then
                txtRFQNo.ReadOnly = True
                strRfqNo = Request("Id").ToString
                fldId.Value = strRfqNo
                BindDetailData(objUser.UserId, strRfqNo)
                BindJmar2(objUser.UserId)
            Else
                txtRFQNo.Text = ""
                txtRFQNo.ReadOnly = False
                txtStatus.Text = "Open"
                txtCreateBy.Text = objUser.UserName
                txtCreateAt.Text = Format(Now(), "dd/MM/yyyy")
                TextBoxAttributes()
                BindJmar2(objUser.UserId)
            End If
            'btnMtoNotification.Attributes.Add("OnClick", "showCalendar(txtMtoNotification,0);return false;")
            'btnPickupDate.Attributes.Add("OnClick", "showCalendar(txtPickupDate,0);return false;")
            'btnShipDate.Attributes.Add("OnClick", "showCalendar(txtShipDate,0);return false;")

            'btnEta.Attributes.Add("OnClick", "showCalendar(txtEta,0);return false;")
            'btnEtd.Attributes.Add("OnClick", "showCalendar(txtEtd,0);return false;")
            'btnDestEta.Attributes.Add("OnClick", "showCalendar(txtDestEta,0);return false;")
            'btnConsignmentDate.Attributes.Add("OnClick", "showCalendar(txtConsignmentDate,0);return false;")
            'btnDateReceivedFromMto.Attributes.Add("OnClick", "showCalendar(txtDateReceivedFromMto,0);return false;")
            'btnDateDeliveredToMro.Attributes.Add("OnClick", "showCalendar(txtDateDeliveredToMro,0);return false;")

            'btnDateReceivedFromMtoRep.Attributes.Add("OnClick", "showCalendar(txtDateReceivedFromMtoRep,0);return false;")
            'btnDateReceivedFromMto.Attributes.Add("OnClick", "showCalendar(txtDateReceivedFromMto,0);return false;")
            'btnDateDeliveredToMtoRep.Attributes.Add("OnClick", "showCalendar(txtDateDeliveredToMtoRep,0);return false;")
            'btnTearDownInspectionDate.Attributes.Add("OnClick", "showCalendar(txtTearDownInspectionDate,0);return false;")

            btnMtoNotification.Attributes.Add("OnClick", "WdatePicker({el:'txtMtoNotification',dateFmt:'dd/MM/yyyy'});return false;")
            btnPickupDate.Attributes.Add("OnClick", "WdatePicker({el:'txtPickupDate',dateFmt:'dd/MM/yyyy'});return false;")
            btnShipDate.Attributes.Add("OnClick", "WdatePicker({el:'txtShipDate',dateFmt:'dd/MM/yyyy'});return false;")

            btnEta.Attributes.Add("OnClick", "WdatePicker({el:'txtEta',dateFmt:'dd/MM/yyyy'});return false;")
            btnEtd.Attributes.Add("OnClick", "WdatePicker({el:'txtEtd',dateFmt:'dd/MM/yyyy'});return false;")
            btnDestEta.Attributes.Add("OnClick", "WdatePicker({el:'txtDestEta',dateFmt:'dd/MM/yyyy'});return false;")
            btnConsignmentDate.Attributes.Add("OnClick", "WdatePicker({el:'txtConsignmentDate',dateFmt:'dd/MM/yyyy'});return false;")

            btnDateReceivedFromMto.Attributes.Add("OnClick", "WdatePicker({el:'txtDateReceivedFromMto',dateFmt:'dd/MM/yyyy'});return false;")
            btnDateDeliveredToMro.Attributes.Add("OnClick", "WdatePicker({el:'txtDateDeliveredToMro',dateFmt:'dd/MM/yyyy'});return false;")

            btnDateReceivedFromMtoRep.Attributes.Add("OnClick", "WdatePicker({el:'txtDateReceivedFromMtoRep',dateFmt:'dd/MM/yyyy'});return false;")
            btnDateReceivedFromMto.Attributes.Add("OnClick", "WdatePicker({el:'txtDateReceivedFromMto',dateFmt:'dd/MM/yyyy'});return false;")
            btnDateDeliveredToMtoRep.Attributes.Add("OnClick", "WdatePicker({el:'txtDateDeliveredToMtoRep',dateFmt:'dd/MM/yyyy'});return false;")
            btnTearDownInspectionDate.Attributes.Add("OnClick", "WdatePicker({el:'txtTearDownInspectionDate',dateFmt:'dd/MM/yyyy'});return false;")

            btnCloseJob.Attributes.Add("OnClick", "CloseJob();return false;")
            btnSave.Attributes.Add("OnClick", "SaveJob('" + objServer.Title + "',2);return false;")
            btnExit.Attributes.Add("OnClick", "CloseWindow();return false;")
            btnAddStatus.Attributes.Add("OnClick", "InsertJmar2();return false;")
            btnLocalMto.Attributes.Add("OnClick", "selBindCode(" + txtLocalMto.ClientID + "," + txtLocalMtoName.ClientID + ",'Rcbp1','BusinessPartyCode,BusinessPartyName','AND PartyType=\'MTO\' AND StatusCode<>\'DEL\'','LOCAL MTO Code','LOCAL MTO Name');return false;")
            btnMtoRep.Attributes.Add("OnClick", "selBindCode(" + txtMtoRep.ClientID + "," + txtMtoRepName.ClientID + ",'Rcbp1','BusinessPartyCode,BusinessPartyName','AND PartyType=\'REP\' AND StatusCode<>\'DEL\'','MTO REP Code','MTO REP Name');return false;")
            btnMro.Attributes.Add("OnClick", "selBindCode(" + txtMro.ClientID + "," + txtMroName.ClientID + ",'Rcbp1','BusinessPartyCode,BusinessPartyName','AND PartyType=\'MRO\' AND StatusCode<>\'DEL\'','MRO Code','MRO Name');return false;")
            btnUom.Attributes.Add("OnClick", "selBindCode(" + txtUom.ClientID + ",'','Rcum1','UomCode,UomDescription','AND StatusCode<>\'DEL\'','Uom Code','Uom Description');return false;")

            txtLocalMto.Attributes.Add("OnBlur", "CheckValid('Rcbp1','BusinessPartyCode'," + txtLocalMto.ClientID + ",'AND PartyType=\'MTO\' AND StatusCode<>\'DEL\'','Invalid LOCAL MTO Code.');return false;")
            txtMtoRep.Attributes.Add("OnBlur", "CheckValid('Rcbp1','BusinessPartyCode'," + txtMtoRep.ClientID + ",'AND PartyType=\'REP\' AND StatusCode<>\'DEL\'','Invalid MTO REP Code.');return false;")
            txtMro.Attributes.Add("OnBlur", "CheckValid('Rcbp1','BusinessPartyCode'," + txtMro.ClientID + ",'AND PartyType=\'MRO\' AND StatusCode<>\'DEL\'','Invalid MRO Code.');return false;")
            txtUom.Attributes.Add("OnBlur", "CheckValid('Rcum1','UomCode'," + txtUom.ClientID + ",'AND StatusCode<>\'DEL\'','Invalid UOM Code.');return false;")

            If txtStatus.Text = "Close" Then
                DisabledFields()
            Else
                EnabledFields(objUser.UserId)
            End If

        End If
    End Sub

    Protected Sub EnabledFields(ByVal strUserId As String)
        Dim strSQL As String = "SELECT sRoleName FROM RoleInfo WHERE lId IN (SELECT lRoleId FROM RolePerson WHERE lUserId='" & strUserId & "')"
        Dim ds As DataSet
        Dim i As Integer
        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSQL)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item(0).ToString = "Matra" Then
                txtMtoNotification.ReadOnly = False
                txtLocalMto.ReadOnly = False
                txtLocalMtoName.ReadOnly = False
                txtConsignmentDate.ReadOnly = False
                txtPickupFrom.ReadOnly = False
                txtPickupDate.ReadOnly = False
                txtShipTo.ReadOnly = False
                txtShipDate.ReadOnly = False
                txtConsignmentNote.ReadOnly = False
                'txtMtoRep.ReadOnly = False
                txtMtoRepName.ReadOnly = False
                'txtMro.ReadOnly = False
                txtMroName.ReadOnly = False
                btnMtoNotification.Enabled = True
                btnPickupDate.Enabled = True
                btnShipDate.Enabled = True
                btnLocalMto.Enabled = True
                btnConsignmentDate.Enabled = True
                btnMtoRep.Enabled = True
                btnMro.Enabled = True
            ElseIf ds.Tables(0).Rows(i).Item(0).ToString = "Mto" Then
                txtDriverName1.ReadOnly = False
                txtDriverName2.ReadOnly = False
                txtDriverName3.ReadOnly = False
                txtDriveric1.ReadOnly = False
                txtDriveric2.ReadOnly = False
                txtDriveric3.ReadOnly = False
                txtCommodity.ReadOnly = False
                txtQty.ReadOnly = False
                txtUom.ReadOnly = False
                txtGrossWeight.ReadOnly = False
                txtChargeWeight.ReadOnly = False
                txtMAwbOrOBlNo.ReadOnly = False
                txtHAwbOrHBlNo.ReadOnly = False
                txtFltOrVoyNo.ReadOnly = False
                txtAirportDeptOrPol.ReadOnly = False
                txtEtd.ReadOnly = False
                txtAirportDestOrPod.ReadOnly = False
                txtEta.ReadOnly = False
                txtFinalPlaceOfDelivery.ReadOnly = False
                txtDestEta.ReadOnly = False
                btnUom.Enabled = True
                btnEtd.Enabled = True
                btnEta.Enabled = True
                btnDestEta.Enabled = True
            End If
        Next
        txtPartNo.ReadOnly = False
        txtSerialNo.ReadOnly = False
        txtMro.ReadOnly = False
        txtMroName.ReadOnly = False
        txtMtoRep.ReadOnly = False
        btnCloseJob.Enabled = True
        btnAddStatus.Enabled = True

        txtDateReceivedFromMto.ReadOnly = False
        btnDateReceivedFromMto.Enabled = True
        txtDateDeliveredToMro.ReadOnly = False
        btnDateDeliveredToMro.Enabled = True
        txtDateReceivedFromMtoRep.ReadOnly = False
        btnDateReceivedFromMtoRep.Enabled = True
        txtDateDeliveredToMtoRep.ReadOnly = False
        btnDateDeliveredToMtoRep.Enabled = True
        txtTearDownInspectionDate.ReadOnly = False
        btnTearDownInspectionDate.Enabled = True
        txtQuotationRefNo.ReadOnly = False
    End Sub

    Protected Sub DisabledFields()
        'Common
        txtPartNo.ReadOnly = True
        txtSerialNo.ReadOnly = True
        txtMro.ReadOnly = True
        txtMroName.ReadOnly = True
        txtMtoRep.ReadOnly = True
        btnCloseJob.Enabled = False
        btnAddStatus.Enabled = False

        txtDateReceivedFromMto.ReadOnly = True
        txtDateDeliveredToMro.ReadOnly = True
        txtDateReceivedFromMtoRep.ReadOnly = True
        txtDateDeliveredToMtoRep.ReadOnly = True
        txtTearDownInspectionDate.ReadOnly = True
        txtQuotationRefNo.ReadOnly = True

        btnDateReceivedFromMto.Enabled = False
        btnDateDeliveredToMro.Enabled = False
        btnDateReceivedFromMtoRep.Enabled = False
        btnDateDeliveredToMtoRep.Enabled = False
        btnTearDownInspectionDate.Enabled = False

        'Matra
        txtMtoNotification.ReadOnly = True
        txtLocalMto.ReadOnly = True
        txtLocalMtoName.ReadOnly = True
        txtConsignmentDate.ReadOnly = True
        txtPickupFrom.ReadOnly = True
        txtPickupDate.ReadOnly = True
        txtShipTo.ReadOnly = True
        txtShipDate.ReadOnly = True
        txtConsignmentNote.ReadOnly = True
        'txtMtoRep.ReadOnly = True
        txtMtoRepName.ReadOnly = True
        'txtMro.ReadOnly = True
        txtMroName.ReadOnly = True
        btnMtoNotification.Enabled = False
        btnPickupDate.Enabled = False
        btnShipDate.Enabled = False
        btnLocalMto.Enabled = False
        btnConsignmentDate.Enabled = False
        btnMtoRep.Enabled = False
        btnMro.Enabled = False

        'Mto 
        txtDriverName1.ReadOnly = True
        txtDriverName2.ReadOnly = True
        txtDriverName3.ReadOnly = True
        txtDriveric1.ReadOnly = True
        txtDriveric2.ReadOnly = True
        txtDriveric3.ReadOnly = True
        txtCommodity.ReadOnly = True
        txtQty.ReadOnly = True
        txtUom.ReadOnly = True
        txtGrossWeight.ReadOnly = True
        txtChargeWeight.ReadOnly = True
        txtMAwbOrOBlNo.ReadOnly = True
        txtHAwbOrHBlNo.ReadOnly = True
        txtFltOrVoyNo.ReadOnly = True
        txtAirportDeptOrPol.ReadOnly = True
        txtEtd.ReadOnly = True
        txtAirportDestOrPod.ReadOnly = True
        txtEta.ReadOnly = True
        txtFinalPlaceOfDelivery.ReadOnly = True
        txtDestEta.ReadOnly = True
        btnUom.Enabled = False
        btnEta.Enabled = False
        btnEtd.Enabled = False
        btnDestEta.Enabled = False
    End Sub

    Protected Sub TextBoxAttributes()
        txtRFQNo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtRFQNo.Attributes.Add("OnBlur", "CheckRfqNo();return false;")
        txtPartNo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtSerialNo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtMtoNotification.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtLocalMto.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtConsignmentDate.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")

        txtPickupFrom.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtPickupDate.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtShipTo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtShipDate.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtConsignmentNote.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtMtoRep.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtMro.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtCommodity.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtQty.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtUom.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")

        txtGrossWeight.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtChargeWeight.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtMAwbOrOBlNo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtHAwbOrHBlNo.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtFltOrVoyNo.Attributes.Add("OnChange", "ChangeStatus();return false;")
        txtAirportDeptOrPol.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtAirportDestOrPod.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtEtd.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtEta.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtFinalPlaceOfDelivery.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
        txtDestEta.Attributes.Add("OnKeyUp", "ChangeStatus();return false;")
    End Sub

    Public Function CheckValid(ByVal strTable As String, ByVal strFieldName As String, ByVal strValue As String, ByVal strWhere As String, ByVal strErrMessage As String) As String
        If Len(strValue) = 0 Then Return ZZMessage.ConMsgRtn.Ok + "" : Exit Function
        Dim strSQL As String = "SELECT * FROM " & strTable & " WHERE " & strFieldName & "='" & strValue & "' " & strWhere
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSQL)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ZZMessage.ConMsgRtn.Ok + ""
        Else
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strErrMessage
        End If
    End Function

    Public Function SaveData(ByVal strValue As String, ByVal strMatra As String) As String
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

    Public Function CheckRfqNo(ByVal strRfqNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim dt As DataTable
        Dim strMsg As String = ""
        Dim strSQL As String = "SELECT * FROM Jmar1 WHERE RfqNo='" & strRfqNo & "'"
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            dt = BaseSelectSrvr.GetData(strSQL, "")
            If dt.Rows.Count > 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Rfq No already exist."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function CloseJob(ByVal strRfqNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim strSQL As String = "Update Jmar1 SET Status='Close' WHERE RfqNo='" & strRfqNo & "'"
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intResult As Integer
            intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSQL)
            If intResult > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Close"
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "In-Progress"
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Visible = False      'EditColumn
        e.Row.Cells(6).Visible = False    'LineItemNo
        Dim i As Integer

        If e.Row.RowType = DataControlRowType.DataRow Then
            '    Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            '    Dim strChangeClass As String = ""
            '    Dim strPriority As String = ""
            '    'KeyValue 
            '    Dim intTrxNo As String
            '    intTrxNo = CType(tmpProp, clsPropMatra).RfqNo

            '    'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            '    'Handle display value
            For i = 0 To gvwSource.Columns.Count - 1
                Select Case i
                    'DateTime
                    Case 0, 3
                        If e.Row.Cells(i + 1).Text <> "" Then
                            Dim dtmTemp As DateTime = GeneralFun.StringToDate(e.Row.Cells(i + 1).Text)
                            If dtmTemp <= ConDateTime.MinDate Then
                                e.Row.Cells(i + 1).Text = ""
                            Else
                                e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                            End If
                        End If
                End Select
            Next
            'Delete

            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex <> m_intRowCount - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteJmar2('" + fldId.Value.ToString() + "'," + e.Row.Cells(6).Text.ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            ''Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If e.Row.RowIndex <> m_intRowCount - 1 Then
                imgEdit.Attributes.Add("OnClick", "EditJmar2('" + fldId.Value.ToString() + "'," + e.Row.Cells(6).Text.ToString() + ");return false;")
                e.Row.Attributes.Add("ondblclick", "EditJmar2('" + fldId.Value.ToString() + "'," + e.Row.Cells(6).Text.ToString + ");return false;")
            Else
                imgEdit.Visible = False
            End If
            ''Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = m_intRowCount - 1 Then
                imgInsert.Attributes.Add("OnClick", "InsertJmar2();return false;")
            Else
                imgInsert.Visible = False
            End If

        ElseIf e.Row.RowType = DataControlRowType.Header Then
            Dim im As New Image
            im.ImageUrl = "../Images/Edit/ed_Insert.gif"
            im.CssClass = "delImg"
            e.Row.Cells(0).Controls.Add(im)
        End If
    End Sub

    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        'do nothing
    End Function

    Protected Sub BindJmar2(ByVal strUserId As String)
        Dim strSQL As String = "SELECT StatusDate,StatusCode,StatusDesc,ActivityDate, UpdateBy, LineItemNo FROM Jmar2 a WHERE RfqNo = '" & txtRFQNo.Text & "'"
        Dim dt As DataTable = BaseSelectSrvr.GetData(strSQL, "")
        'If dt.Rows.Count = 0 Then
        '    dt.Rows.Add(dt.NewRow())
        '    gvwSource.DataSource = dt
        '    gvwSource.DataBind()
        '    'gvwSource.Rows(0).Visible = False
        'Else
        '    gvwSource.DataSource = dt
        '    gvwSource.DataBind()
        'End If
        dt.Rows.Add(dt.NewRow())
        m_intRowCount = dt.Rows.Count
        gvwSource.DataSource = dt
        gvwSource.DataBind()
        gvwSource.Rows(m_intRowCount - 1).Visible = False   'set the new row disappear
    End Sub

    Public Function RefreshGrid(ByVal strRfqNo As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            txtRFQNo.Text = strRfqNo.ToString
            BindJmar2(objUser.UserId)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsBooking(strUserId, RoleName, strFunNo)
    End Function

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then

        End If
        EnabledFields(objUser.UserId)
        txtRFQNo.ReadOnly = False
        txtRFQNo.Text = ""
        txtStatus.Text = "Open"
        txtCreateBy.Text = objUser.UserName
        txtCreateAt.Text = Format(Now(), "dd/MM/yyyy")
        txtPartNo.Text = ""
        txtSerialNo.Text = ""
        txtMtoNotification.Text = ""
        txtLocalMto.Text = ""
        txtConsignmentDate.Text = ""
        txtPickupFrom.Text = ""
        txtPickupDate.Text = ""
        txtShipTo.Text = ""
        txtShipDate.Text = ""
        txtConsignmentNote.Text = ""
        txtMtoRep.Text = ""
        txtMro.Text = ""
        txtDriverName1.Text = ""
        txtDriverName2.Text = ""
        txtDriverName3.Text = ""
        txtDriveric1.Text = ""
        txtDriveric2.Text = ""
        txtDriveric3.Text = ""
        txtCommodity.Text = ""
        txtQty.Text = ""
        txtUom.Text = ""
        txtGrossWeight.Text = ""
        txtChargeWeight.Text = ""
        txtMAwbOrOBlNo.Text = ""
        txtHAwbOrHBlNo.Text = ""
        txtFltOrVoyNo.Text = ""
        txtAirportDeptOrPol.Text = ""
        txtAirportDestOrPod.Text = ""
        txtEtd.Text = ""
        txtEta.Text = ""
        txtFinalPlaceOfDelivery.Text = ""
        txtDestEta.Text = ""
        txtMroName.Text = ""
        txtLocalMtoName.Text = ""
        txtMtoRepName.Text = ""

        txtDateReceivedFromMto.Text = ""
        txtDateDeliveredToMro.Text = ""
        txtDateReceivedFromMtoRep.Text = ""
        txtDateDeliveredToMtoRep.Text = ""
        txtTearDownInspectionDate.Text = ""
        txtQuotationRefNo.Text = ""

        fldId.Value = ""
        TextBoxAttributes()
        BindJmar2(objUser.UserId)
    End Sub
End Class
