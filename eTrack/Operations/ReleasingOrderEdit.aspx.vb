Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports Ntools
Imports SysMagic

Partial Class ReleasingOrder
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsRO
    Private objColumns As colColumn
    Private returnValue As String
    Private strModuleCode As String = ""
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Private intLineItemNo As Int64 = ConClass.NewIdValue
    Protected ConfigPath As String
    Protected ExportConfig As String
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
        Return New clsRO(intUserId)
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
                    con.Text = strVal.ToString("dd-MMM-yy")
                Else
                    con.Text = strVal.ToString("dd-MMM-yy")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub GetROReleaseDate(ByRef strVal As DateTime, ByVal DetentionFreeDay As Integer)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                txtROReleaseDate.Text = ""
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    strVal = strVal.AddDays(-DetentionFreeDay + 1)
                    txtROReleaseDate.Text = strVal.ToString("dd-MMM-yy")
                Else
                    strVal = strVal.AddDays(-DetentionFreeDay + 1)
                    txtROReleaseDate.Text = strVal.ToString("dd-MMM-yy")
                End If
            End If
        Else
            txtROReleaseDate.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNO As Int64, ByVal intLineItemNo As Int64)
        objServer = NewServerObject(intUserId)
        fsPreCool.Style.Add("display", "none")
        If intLineItemNo >= 0 Then
            Dim tmpProp As clsPropRO = objServer.GetDetail(intTrxNO, intLineItemNo)
            If tmpProp.TrxNo <= 0 Then
                intLineItemNo = GetNewId()
                tmpProp.TrxNo = intLineItemNo
            End If
            txtReleasingIN.Text = tmpProp.ReleasingInstructionNo
            txtShipperCode.Text = tmpProp.ShipperCode
            txtShipperName.Text = tmpProp.ShipperName
            txtEquipmentType.Text = tmpProp.EquipmentType
            ConvertDateTime(txtROReleaseDate, tmpProp.ROReleaseDate)
            txtQty.Text = tmpProp.Qty
            txtDepotCode.Text = tmpProp.DepotCode
            txtInstructionTD.Text = tmpProp.InstructionToDepot
            txtTruckerCode.Text = tmpProp.TruckerCode
            txtTruckerName.Text = tmpProp.TruckerName
            ConvertDateTime(txtDateCollection, tmpProp.CollectionDate)
            drPreCoolFlag.SelectedValue = tmpProp.PreCoolFlag
            drPreSetSign.SelectedValue = tmpProp.PreSetSign
            txtPreSetTemp.Text = tmpProp.PreSetTemperature
            drPreSetType.SelectedValue = tmpProp.PreSetType
            txtCommodity.Text = tmpProp.Commodity
            drVoltage.Text = tmpProp.VoltageCode
            txtRON.Text = tmpProp.ReleasingOrderNo
            Me.Title = "Releasing Order : " + tmpProp.ReleasingOrderNo
            If tmpProp.EquipmentType.ToLower = "reefer" Then
                fsPreCool.Style.Add("display", "block")
            End If
        Else
            Me.Title = "New"
        End If
        txtReleasingIN.ReadOnly = True
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Private Sub ControlEvent(ByVal flag As Integer, ByRef UpperFlag As String)
        setFocusControl(txtShipperCode, txtShipperName)
        setFocusControl(txtShipperName, txtEquipmentType)
        setFocusControl(txtEquipmentType, txtROReleaseDate)
        setFocusControl(txtROReleaseDate, txtQty)
        If flag >= 0 Then
            setFocusControl(txtQty, txtReleaseQty)
            setFocusControl(txtReleaseQty, txtDepotCode)
        Else
            setFocusControl(txtQty, txtDepotCode)
        End If
        setFocusControl(txtDepotCode, txtInstructionTD)
        setFocusControl(txtTruckerCode, txtTruckerName)
        setFocusControl(drPreCoolFlag, drPreSetSign)
        setFocusControl(drPreSetSign, txtPreSetTemp)
        setFocusControl(txtPreSetTemp, drPreSetType)
        setFocusControl(drPreSetType, txtCommodity)
        setFocusControl(txtCommodity, drVoltage)
        'UpperCase
        If UpperFlag = "y" Then
            setUpperCase(txtShipperCode)
            setUpperCase(txtShipperName)
            setUpperCase(txtEquipmentType)
            setUpperCase(txtDepotCode)
            setUpperCase(txtTruckerCode)
            setUpperCase(txtCommodity)
            setUpperCase(txtTruckerName)
            setUpperCase(txtInstructionTD)
        End If
    End Sub
    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");")
    End Sub
    Private Function Bindbylzw(ByVal strCode As String) As Boolean
        Dim strSql As String
        Dim dtReclzw As DataTable
        strSql = "select top 1 ContactName from Rcbp3 where BusinessPartyCode='" + strCode + "' order by ContactName Asc"
        dtReclzw = BaseSelectSrvr.GetData(strSql, "")
        Return True
    End Function
    Public Function SaveData(ByVal strValue As String, ByVal strReleasingOrder As String) As String
        If Not (Request("TrxNo") Is Nothing) Then
            HidTrxNo.Value = Request("TrxNo").ToString()
            intTrxNo = Int64.Parse(Request("TrxNo").ToString())
            HidLineItemNo.Value = getLineItemNo(Request("TrxNo").ToString())
        End If
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If strValue.Substring(0, strValue.IndexOf("#")) = "-1" Then
                CreateRON()
            End If
            strValue = strValue.Replace("Releasing@OrderNo", txtRON.Text)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId IsNot Nothing Then
                        HidLineItemNo.Value = objServer.masterId
                    End If
                    Dim intLineItemNo As Int64 = GetNewId()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + HidTrxNo.Value
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(HidLineItemNo)
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
#End Region
#Region "public"
    Private Sub SetInitValue(ByVal intUserId As String, ByVal objUser As clsUser)
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        btnClose.Attributes.Add("OnClick", "CloseWindow(0);return false;")
        'btnNew.Attributes.Add("OnClick", "NewDetail(0);return false;")
        'drPreCoolFlag
        drPreCoolFlag.Items.Add(New ListItem("N", "N"))
        drPreCoolFlag.Items.Add(New ListItem("Y", "Y"))
        drPreCoolFlag.Items.Insert(0, New ListItem(ListItemSelect, ""))
        'drPreSetSign
        drPreSetSign.Items.Add(New ListItem("+", "+"))
        drPreSetSign.Items.Add(New ListItem("-", "-"))
        'drPreSetType
        drPreSetType.Items.Add(New ListItem("C", "C"))
        drPreSetType.Items.Add(New ListItem("F", "F"))
        'drVoltage
        drVoltage.Items.Add(New ListItem("0", "0"))
        drVoltage.Items.Add(New ListItem("220", "220"))
        drVoltage.Items.Add(New ListItem("440", "440"))
        If Not (Request("ContainerList") Is Nothing) Then
            If Request("ContainerList").ToString() <> "" Then
                Dim arrContainerList As String() = Request("ContainerList").ToString().Split(",")
                txtReleaseQty.Text = arrContainerList.Length
            Else
                txtReleaseQty.Text = 0
            End If
            txtReleaseQty.ReadOnly = True
        End If
        txtInstructionTD.Attributes.Add("onpropertychange", "textLimit(event," + txtInstructionTD.ClientID + ",1000)")
        txtQty.Attributes.Add("OnKeyPress", "Number(event);")
        txtPreSetTemp.Attributes.Add("OnKeyPress", "FloatNum('" + txtPreSetTemp.ClientID + "',event)")
        btnShipperCode.Attributes.Add("OnClick", "BindCodeName(" + txtShipperCode.ClientID + "," + txtShipperName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Shipper Code','Shipper Name');return false;")
        btnEquipmentType.Attributes.Add("OnClick", "selBindCode(" + txtEquipmentType.ClientID + ",'rcco1','ContainerType,ContainerDescription','','Equipment Type','Equipment Name');return false;")
        Dim strWhere As String = " 'and PartyType=\'DP\' and CountryCode=\'" + objUser.SiteCode.Substring(0, 2) + "\' and CityCode=\'" + objUser.SiteCode.Substring(objUser.SiteCode.Length - 3, 3) + "\'' "
        btnDepotCode.Attributes.Add("OnClick", "selBindCode(" + txtDepotCode.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName'," + strWhere + ",'Depot Type','Depot Name');return false;")
        btnTruckerCode.Attributes.Add("OnClick", "BindCodeName(" + txtTruckerCode.ClientID + "," + txtTruckerName.ClientID + ",'rcbp1','BusinessPartyCode,BusinessPartyName','','Trucker Code','Trucker Name');return false;")
        txtShipperCode.Attributes.Add("onchange", "valiBindName('" + txtShipperCode.ClientID + "','" + txtShipperName.ClientID + "','Shipper Code','BusinessPartyCode,BusinessPartyName','rcbp1')")
        txtEquipmentType.Attributes.Add("onchange", "valiString('" + txtEquipmentType.ClientID + "','Equipment Type.','ContainerType','rcco1','')")
        txtDepotCode.Attributes.Add("onchange", "valiString('" + txtDepotCode.ClientID + "','Depot Code.','BusinessPartyCode','rcbp1'," + strWhere + ")")
        txtTruckerCode.Attributes.Add("onchange", "valiBindName('" + txtTruckerCode.ClientID + "','" + txtTruckerName.ClientID + "','Trucker Code','BusinessPartyCode,BusinessPartyName','rcbp1')")
        If HidTrxNo.Value <> -1 Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData("select EtaDate,DetentionFreeDay from ctri1 where TrxNo= " + HidTrxNo.Value, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("EtaDate").ToString <> "" Then
                        If dt.Rows(0)("DetentionFreeDay").ToString <> "" Then
                            GetROReleaseDate(dt.Rows(0)("EtaDate"), Integer.Parse(dt.Rows(0)("DetentionFreeDay")))
                        End If
                    End If
                End If
            End If
        End If
        txtDateCollection.ReadOnly = True
        btnDateCollection.Style.Add("display", "none")
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
    Private Function getLineItemNo(ByVal strTrxNo As String) As String
        Dim strLineItemNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(LineItemNo)+1 as TrxNo from ctro1 where TrxNo=" + strTrxNo, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("TrxNo").ToString.Trim <> "" Then
                        strLineItemNo = dt.Rows(0)("TrxNo").ToString.Trim
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
            HidTrxNo.Value = -1
            HidEditState.Value = -1
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                intLineItemNo = Int64.Parse(Request("Id").ToString())
                HidLineItemNo.Value = intLineItemNo
                HidEditState.Value = intLineItemNo
            Else
                HidLineItemNo.Value = getLineItemNo(Request("TrxNo").ToString())
            End If
            If Not (Request("RIN") Is Nothing) Then
                txtReleasingIN.Text = Request("RIN").ToString()

            End If
            If Not (Request("TrxNo") Is Nothing) Then
                HidTrxNo.Value = Request("TrxNo").ToString()
                intTrxNo = Int64.Parse(Request("TrxNo").ToString())
                If txtReleasingIN.Text = "" Then
                    txtReleasingIN.Text = GetReleasingIN(intTrxNo.ToString)
                End If
            End If
            SetInitValue(objUser.UserId, objUser)
            BindDetailData(objUser.UserId, intTrxNo, intLineItemNo)
            ControlEvent(intLineItemNo, objUser.UpperCase)
            btnDateCollection.Attributes.Add("OnClick", "return false;")
            btnROReleaseDate.Attributes.Add("OnClick", "WdatePicker({el:'txtROReleaseDate',dateFmt:'dd-MMM-yy'});return false;")
            btnDateCollection.Attributes.Add("OnClick", "WdatePicker({el:'txtDateCollection',dateFmt:'dd-MMM-yy'});return false;")
            txtROReleaseDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtROReleaseDate.ClientID + "');return false;")
            txtROReleaseDate.Attributes.Add("onblur", "ChangeLongDate('" + txtROReleaseDate.ClientID + "');return false;")
            txtDateCollection.Attributes.Add("onfocus", "ChangeShortDate('" + txtDateCollection.ClientID + "');return false;")
            txtDateCollection.Attributes.Add("onblur", "ChangeLongDate('" + txtDateCollection.ClientID + "');return false;")
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnUpdateRON.Attributes.Add("onclick", "updateRON('" + objUser.UpperCase + "'); return false;")
            btnITD.Attributes.Add("onclick", "InsertITD(" + txtInstructionTD.ClientID + "); return false;")
        End If
    End Sub
    Function GetReleasingIN(ByVal TrxNo As String) As String
        If TrxNo <> "" Then
            Try
                Dim dt As DataTable = BaseSelectSrvr.GetData("select ReleasingInstructionNo from ctri1 where TrxNo=" + TrxNo, "")
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(0)
                End If
            Catch ex As Exception

            End Try
        End If
        Return ""
    End Function
    Public Function updateRON(ByVal RON As String, ByVal TrxNO As String, ByVal LineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim valName As String = ""
        Dim intValue As Integer
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim dt As datatable
                dt = BaseSelectSrvr.GetData("select count(*) from ctro1 where ReleasingOrderNo='" + RON + "' and (TrxNo!=" + TrxNO + " or LineItemNo !=" + LineItemNo + ")", "")
                If Integer.Parse(dt.Rows(0)(0)) > 0 Then
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "" + ConSeparator.Par + "The Releasing Order No has exist."
                End If
                Dim strSql As String = "update ctro1 set ReleasingOrderNo='" + RON + "' where TrxNo=" + TrxNO + " and LineItemNo=" + LineItemNo
                intValue = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            Catch ex As Exception
            End Try
            If intValue = 1 Then
                Me.Title = "Releasing Order :" + RON
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + RON + ConSeparator.Par + txtRON.Text
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save False." + ConSeparator.Par + txtRON.Text
            End If
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "" + ConSeparator.Par + txtRON.Text
    End Function
#End Region
#Region "Create No "
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
    Public Sub CreateRON()
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'CreateOrderNo
            If strDate <> "" Then
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                           "where NumberType  like '%CTRO%'", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim fiePrefix As Object = ReturnfiePrefix(dtReclzw.Rows(0)("Prefix").ToString)
                    Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                    Dim fieSuffix As Object = ReturnfieSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                    txtRON.Text = fiePrefix + fieNextNo + fieSuffix
                End If
            End If
        End If
    End Sub
#End Region
End Class
