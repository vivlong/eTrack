Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports Ntools
Imports SysMagic

Partial Class ExportBookingEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objServer As clsExportBooking
    Private objBooking As clsExportBooking
    Private objList As clsDimension
    Private objColumns As colColumn
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strModuleCode As String = ""
    Private intTrxNo As Int64 = ConClass.NewIdValue
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
        Return New clsExportBooking(intUserId)
    End Function
    Public Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsExportBooking(intUserId, RoleName, strFunNo)
    End Function
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal objUser As clsUser)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropExportBooking = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            txtTrxNo.Text = tmpProp.TrxNo.ToString()
            fldId.Value = tmpProp.TrxNo.ToString()
            BookingDateTimeSelect.sDateValue = tmpProp.BookingDateTime
            ContactNameSelect.sNameValue = tmpProp.ContactName
            TelephoneSelect.sNameValue = tmpProp.ContactTelephone
            txtBookingNo.Text = tmpProp.BookingNo
            txtCustomerName.Text = tmpProp.BookingCustomerName
            VesselSelect.sCodeValue = tmpProp.VesselCode
            VesselSelect.sNameValue = tmpProp.VesselName
            txtVoyage.Text = tmpProp.VoyageNo
            ETDSelect.sDateValue = tmpProp.EtdDate
            ETASelect.sDateValue = tmpProp.EtaDate
            PortofDischargeSelect.sCodeValue = tmpProp.PortOfDischargeCode
            PortofDischargeSelect.sNameValue = tmpProp.PortOfDischargeName
            DestSelect.sCodeValue = tmpProp.DestCode
            DestSelect.sNameValue = tmpProp.DestName
            drpCargoType.SelectedValue = tmpProp.CargoType
            drpDgFlag.SelectedValue = tmpProp.DgFlag
            CommoditySelect.sCodeValue = tmpProp.CommodityCode
            CommoditySelect.sNameValue = tmpProp.CommodityDescription
            txtPcs.Text = tmpProp.TotalPcs
            txtGrossWeight.Text = tmpProp.TotalGrossWeight
            txtVolume.Text = tmpProp.TotalVolume
            txtFooter1.Text = tmpProp.Footer1
            'Net1786
            Me.Title = "Edit Vessel"
        Else
            BookingDateTimeSelect.sDateValue = Now
            If (objUser.LoginType = "cu") Then
                txtCustomerName.Text = objUser.UserName
                txtCustomerName.ReadOnly = True
            End If
            Me.Title = "New Vessel"
        End If
        btnPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ",'" + hidReports.Value + "');return false;")
    End Sub
    Private Sub KeyUpEvent()
        'setUpperCase(txtGrossWeight)
        'setUpperCase(txtVolume)
    End Sub
    Private Sub setUpperCase(ByRef FirCon As TextBox)
        FirCon.Attributes.Add("OnBlur", "setToUpperCase(" + FirCon.ClientID + ");")
    End Sub
    Private Function Bindbylzw(ByVal strCode As String) As Boolean
        Dim strSql As String
        Dim dtReclzw As DataTable
        strSql = "select top 1 ContactName from Rcbp3 where BusinessPartyCode='" + strCode + "' order by ContactName Asc"
        dtReclzw = BaseSelectSrvr.GetData(strSql, "")
        Return True
    End Function
    Public Function SaveData(ByVal strValue As String, ByVal strBookingNo As String) As String
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
                    If strBookingNo.Trim() = "" Then
                        strBookingNo = CreateBookingNo()
                        If strBookingNo <> "" And objServer.masterId IsNot Nothing Then
                            Dim strSql As String = "Update sebk1 set BookingNo='" + strBookingNo + "' where TrxNo=" + objServer.masterId
                            SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                        End If
                    End If
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Successfully" + ConSeparator.Par + fldId.Value + ConSeparator.Par + strBookingNo
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId) + ConSeparator.Par + CreateBookingNo()
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
#Region "public"
    Private Sub SetControlInit()
        'CloseDateTimeSelect
        BookingDateTimeSelect.sIncludeTime = True
        'PortOfDischarge
        PortofDischargeSelect.sNumFile = 2
        PortofDischargeSelect.sCode = "PortCode"
        PortofDischargeSelect.sName = "PortName"
        PortofDischargeSelect.sTableName = "Rcsp1"
        PortofDischargeSelect.sOrderBy = "PortName"
        PortofDischargeSelect.sShowCode = "PortOfDischarge Code"
        PortofDischargeSelect.sShowName = "PortOfDischarge Name"
        'Dest
        DestSelect.sNumFile = 2
        DestSelect.sCode = "DestCode"
        DestSelect.sName = "CityName"
        DestSelect.sTableName = "sebl1"
        DestSelect.sType = "DestCode"
        DestSelect.sOrderBy = "CityCode"
        DestSelect.sShowCode = "City Code"
        DestSelect.sShowName = "Destination Code"
        DestSelect.sNameReadOnly = True
        'DestSe
        'ContactNameSelect
        ContactNameSelect.sName = "ContactName"
        ContactNameSelect.sTableName = "Rcbp3"
        ContactNameSelect.sShowName = "Contact Name"
        'TelephoneSelect
        TelephoneSelect.sName = "Telephone1"
        TelephoneSelect.sTableName = "Rcbp1"
        TelephoneSelect.sCondition = "" ' isnull(Telephone1,'''') !='''' 
        TelephoneSelect.sShowName = "Telephone"
        'CommoditySelect
        CommoditySelect.sNumFile = 2
        CommoditySelect.sCode = "CommodityCode"
        CommoditySelect.sName = "CommodityDescription"
        CommoditySelect.sTableName = "Rccm1"
        CommoditySelect.sOrderBy = "CommodityCode"
        CommoditySelect.sShowCode = "Commodity Code"
        CommoditySelect.sShowName = "Commodity Name"
        'VesselSelect
        VesselSelect.sNameReadOnly = True
        VesselSelect.sNumFile = 2
        VesselSelect.sCode = "VoyageNo"
        VesselSelect.sName = "VesselCode"
        VesselSelect.sTableName = "rcvy1"
        VesselSelect.sOrderBy = "VoyageNo"
        VesselSelect.sShowCode = "Vessel Code"
        VesselSelect.sShowName = "Vessel Name"
        'Focus
        SystemClass.Controls.Instance.setFocusControl(txtPcs, 0)
        SystemClass.Controls.Instance.setFocusControl(txtGrossWeight, 4)
        SystemClass.Controls.Instance.setFocusControl(txtVolume, 4)
    End Sub
    Private Sub setPCSControl(ByVal trxNo As String)
        'if sebk2 has more than two records then disable the PCS ， GrossWeight and Volumn Control
        Dim ds As DataTable = BaseSelectSrvr.GetData("select count(1) from sebk2 where TrxNo =" + trxNo, "")
        If ds.Rows.Count > 0 Then
            If Integer.Parse(ds.Rows(0)(0)) > 1 Then
                txtPcs.ReadOnly = True
                txtGrossWeight.ReadOnly = True
                txtVolume.ReadOnly = True
                txtPcs.Style.Add("background", "#ccc")
                txtGrossWeight.Style.Add("background", "#ccc")
                txtVolume.Style.Add("background", "#ccc")
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            'add booking readonly
            Dim Guest As String = ""
            Dim UserLogin As Boolean = False

            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            SetControlInit()
            hidReports.Value = ""
            fldId.Value = -1
            hidUserNo.Value = objUser.UserId
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                fldId.Value = intTrxNo
                setPCSControl(fldId.Value)
            Else
                If Not (Request("seblTrxNo") Is Nothing) Then
                    hidSeblTrxNo.Value = Request("seblTrxNo").ToString
                    InitBindNew(hidSeblTrxNo.Value)
                End If
                txtTrxNo.Text = "New"
            End If
            BindDetailData(objUser.UserId, intTrxNo, objUser)
            'Button Event 
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            btnSave.Attributes.Add("OnClick", "SaveBookingDetail('" + objServer.Title + "',2);return false;")
            'SetFocus
            KeydownEvent()
        End If
    End Sub
    Private Sub KeydownEvent()
        setFocusControl(BookingDateTimeSelect.Controls.Item(0), txtBookingNo)
        setFocusControl(txtBookingNo, txtCustomerName)
        setFocusControl(txtCustomerName, ContactNameSelect.Controls.Item(1))
        setFocusControl(ContactNameSelect.Controls.Item(1), TelephoneSelect.Controls.Item(1))
        setFocusControl(TelephoneSelect.Controls.Item(1), VesselSelect.Controls.Item(1))
        setFocusControl(VesselSelect.Controls.Item(1), txtVoyage)
        setFocusControl(txtVoyage, ETDSelect.Controls.Item(0))
        setFocusControl(ETDSelect.Controls.Item(0), ETASelect.Controls.Item(0))

        setFocusControl(ETASelect.Controls.Item(0), PortofDischargeSelect.Controls.Item(1))
        setFocusControl(PortofDischargeSelect.Controls.Item(1), PortofDischargeSelect.Controls.Item(3))
        setFocusControl(PortofDischargeSelect.Controls.Item(3), DestSelect.Controls.Item(1))
        'setFocusControl(DestSelect.Controls.Item(1), drpCargoType)
        'setFocusControl(drpCargoType, drpDgFlag)
        setFocusControl(DestSelect.Controls.Item(1), CommoditySelect.Controls.Item(1))
        setFocusControl(CommoditySelect.Controls.Item(1), CommoditySelect.Controls.Item(3))
        setFocusControl(CommoditySelect.Controls.Item(3), txtPcs)
        setFocusControl(txtPcs, txtGrossWeight)
        setFocusControl(txtGrossWeight, txtVolume)
        setFocusControl(txtVolume, txtFooter1)

        BookingDateTimeSelect.Controls.Item(0).Focus()
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Private Sub InitBindNew(ByVal seblTrxNo As String)
        If seblTrxNo.Length > 0 Then
            Dim strSql As String = "select VesselCode," & _
                "(select  top 1  VesselName from rcvs1 where a.VesselCode =rcvs1.VesselCode) VesselName," & _
                "VoyageNo," & _
                "convert(char(10),EtdDate,20) as EtdDate," & _
                "convert(char(10),EtaDate,20) as EtaDate," & _
                "PortofDischargeCode," & _
                "PortofDischargeName," & _
                "MasterJobNo," & _
                "DestCode," & _
                "OriginCode," & _
                "(select CityName from rcct1 b where b.CityCode=a.DestCode) DestName" & _
            " from sebl1 a where TrxNo=" + seblTrxNo
            Dim dt As DataTable
            Try
                dt = BaseSelectSrvr.GetData(strSql, "")
                If dt.Rows.Count > 0 Then
                    VesselSelect.sCodeValue = dt.Rows(0)("VesselCode").ToString()
                    VesselSelect.sNameValue = dt.Rows(0)("VesselName").ToString()
                    txtVoyage.Text = dt.Rows(0)("VoyageNo").ToString()
                    ETDSelect.sDateValue = GeneralFun.StringToDate(dt.Rows(0)("EtdDate").ToString())
                    ETASelect.sDateValue = GeneralFun.StringToDate(dt.Rows(0)("EtaDate").ToString())
                    PortofDischargeSelect.sCodeValue = dt.Rows(0)("PortofDischargeCode").ToString()
                    PortofDischargeSelect.sNameValue = dt.Rows(0)("PortofDischargeName").ToString()
                    DestSelect.sCodeValue = dt.Rows(0)("DestCode").ToString()
                    DestSelect.sNameValue = dt.Rows(0)("DestName").ToString()
                    hidOriginCode.Value = dt.Rows(0)("OriginCode").ToString()
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
#End Region
#Region "CreateNumber"
    Private Function CreateBookingNo() As String
        'Dim UcaseReg As Object 'Create BookingNo for Sebk1
        Dim m_strPullFrom As String = ""
        Dim m_strJobSeqNo As String = ""
        Dim jobDate As Date = Now.Date
        CreateBookingNo = ""
        Dim strSQL As String
        Dim m_SQlCommandText As String
        Dim dtRec, dtRec2 As DataTable
        Dim mdtRec_index, mdtRec2_index As Integer
        Dim m_strPrefix1 As String
        Dim m_strPrefix2 As String
        Dim m_strPrefix3 As String
        Dim m_strPrefix4 As String
        Dim m_strPrefix5 As String
        Dim m_strUpdateNextField As String
        Dim strShipmentType As String
        Dim m_strDestCode As String
        Dim intMonth As Short
        Dim intJobDateType As Short
        Dim strBookingNo As String = ""
        Dim intYear As Short
        intJobDateType = 0
        m_strDestCode = UCase(DestSelect.sCodeValue)
        strShipmentType = "H"
        On Error GoTo ErrorHandler
        Dim strArr() As String
        Dim intI As Short
        m_SQlCommandText = "Select * From Sanm1 Where NumberType = 'Sebk' And (JobType = '' Or JobType Is Null) Order By JobType Desc"
        dtRec = BaseSelectSrvr.GetData(m_SQlCommandText, "")
        mdtRec_index = 0
        If Not dtRec Is Nothing Then
            If dtRec.Rows.Count > 0 Then
                If IsDBNull(dtRec.Rows(mdtRec_index).Item("Cycle")) Then
                    Return "Sea Parameter File From Cycle Not Found"
                End If
                If tool.CheckNull(dtRec.Rows(mdtRec_index).Item("Cycle"), 0).ToString.ToUpper = "C" Then 'Cycle = Continuous
                    m_strPullFrom = "NextNo"
                    m_strJobSeqNo = tool.CheckNull(dtRec.Rows(mdtRec_index).Item("NextNo"))
                ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("Cycle"), 0).ToString.ToUpper = "M" Then  'Cycle = Month
                    If tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "JCD" Then
                        intMonth = Month(tool.CheckNull(jobDate, 2))
                        intYear = Year(tool.CheckNull(jobDate, 2))
                    ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "ETA" Then
                        intJobDateType = 1
                        intMonth = Month(tool.CheckNull(ETASelect.sDateValue, 2))
                        intYear = Year(tool.CheckNull(ETASelect.sDateValue, 2))
                    ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "ETD" Then
                        intJobDateType = 2
                        intMonth = Month(tool.CheckNull(ETDSelect.sDateValue, 2))
                        intYear = Year(tool.CheckNull(ETDSelect.sDateValue, 2))
                    Else
                        Return "Sea Parameter File - Date Type Not Found in Numbering System"
                    End If
                    m_SQlCommandText = "Select * From Sanm2 Where TrxNo = " & tool.CheckNull(dtRec.Rows(mdtRec_index).Item("TrxNo")) & " And Year = '" & intYear & "'"
                    dtRec2 = BaseSelectSrvr.GetData(m_SQlCommandText, "")
                    If Not dtRec2 Is Nothing Then
                        If dtRec2.Rows.Count > 0 Then
                            Select Case intMonth
                                Case 1
                                    m_strPullFrom = "Mth01NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth01NextNo"))
                                Case 2
                                    m_strPullFrom = "Mth02NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth02NextNo"))
                                Case 3
                                    m_strPullFrom = "Mth03NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth03NextNo"))
                                Case 4
                                    m_strPullFrom = "Mth04NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth04NextNo"))
                                Case 5
                                    m_strPullFrom = "Mth05NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth05NextNo"))
                                Case 6
                                    m_strPullFrom = "Mth06NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth06NextNo"))
                                Case 7
                                    m_strPullFrom = "Mth07NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth07NextNo"))
                                Case 8
                                    m_strPullFrom = "Mth08NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth08NextNo"))
                                Case 9
                                    m_strPullFrom = "Mth09NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth09NextNo"))
                                Case 10
                                    m_strPullFrom = "Mth10NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth10NextNo"))
                                Case 11
                                    m_strPullFrom = "Mth11NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth11NextNo"))
                                Case 12
                                    m_strPullFrom = "Mth12NextNo"
                                    m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("Mth12NextNo"))
                            End Select
                        Else
                            Return "Sea Parameter File - Next Job No Mth Not Found in Numbering System"
                            Exit Function
                        End If
                    End If
                ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("Cycle"), 0).ToString.ToUpper = "Y" Then  'Job No flag = Year
                    If tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "JCD" Then
                        intYear = Year(tool.CheckNull(jobDate, 2))
                    ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "ETA" Then
                        intJobDateType = 1
                        intYear = Year(tool.CheckNull(ETASelect.sDateValue, 2))
                    ElseIf tool.CheckNull(dtRec.Rows(mdtRec_index).Item("DateType")) = "ETD" Then
                        intJobDateType = 2
                        intYear = Year(tool.CheckNull(ETDSelect.sDateValue, 2))
                    End If
                    m_SQlCommandText = "Select YearNextNo From Sanm2 Where TrxNo = " & tool.CheckNull(dtRec.Rows(mdtRec_index).Item("TrxNo")) & " And Year = '" & intYear & "'"
                    dtRec2 = BaseSelectSrvr.GetData(m_SQlCommandText, "")
                    If Not dtRec2 Is Nothing Then
                        If dtRec2.Rows.Count > 0 Then
                            m_strPullFrom = "YearNextNo"
                            m_strJobSeqNo = tool.CheckNull(dtRec2.Rows(mdtRec2_index).Item("YearNextNo"))
                        Else
                            Return "Sea Parameter File - Year Next No Not Found in Numbering System"
                            Exit Function
                        End If
                    End If
                End If
                '****************************************************************************
                strBookingNo = ""
                If Len(Trim(tool.CheckNull(dtRec.Rows(mdtRec_index).Item("prefix")))) > 0 Then
                    strArr = Split(dtRec.Rows(mdtRec_index).Item("prefix"), ",")
                    For intI = 0 To UBound(strArr)
                        strBookingNo = strBookingNo & ReturnPrefix(strArr(intI), intJobDateType, strShipmentType)
                    Next intI
                End If
                strBookingNo = strBookingNo & m_strJobSeqNo ' & "00"
                If Len(Trim(tool.CheckNull(dtRec.Rows(mdtRec_index).Item("Suffix")))) > 0 Then
                    Erase strArr
                    strArr = Split(dtRec.Rows(mdtRec_index).Item("Suffix"), ",")
                    For intI = 0 To UBound(strArr)
                        strBookingNo = strBookingNo & ReturnPrefix(strArr(intI), intJobDateType, strShipmentType)
                    Next intI
                End If
                CreateBookingNo = strBookingNo
                m_strUpdateNextField = tool.CheckUpdateFieldLength(m_strJobSeqNo)
                If tool.CheckNull(dtRec.Rows(mdtRec_index).Item("Cycle"), 0).ToString.ToUpper = "C" Then 'Cycle = Continuous
                    m_SQlCommandText = "Update Sanm1 Set " & m_strPullFrom & " = '" & tool.SQLSafe(m_strUpdateNextField) & "' Where TrxNo = " & tool.CheckNull(dtRec.Rows(mdtRec_index).Item("TrxNo")) 'Add 1 For Next Job No
                Else
                    m_SQlCommandText = "Update Sanm2 Set " & m_strPullFrom & " = '" & tool.SQLSafe(m_strUpdateNextField) & "' Where TrxNo = " & tool.CheckNull(dtRec.Rows(mdtRec_index).Item("TrxNo")) & " And Year = '" & intYear & "'" 'Add 1 For Next Job No
                End If
                Dim i As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, m_SQlCommandText)
            End If
        End If
        Exit Function
ErrorHandler:
        Return strBookingNo
    End Function

    Private Function ReturnPrefix(ByRef RecPrefix As String, ByRef intJobDateType As Short, Optional ByRef strShipmentType As String = "") As String
        Dim jobDate As Date = Now.Date
        ReturnPrefix = ""
        Dim intMth As Short
        If RecPrefix = "DST" Then 'If Prefix1 is Destination
            ReturnPrefix = DestSelect.sCodeValue
        ElseIf RecPrefix = "ORG" Then  'If Prefix1 is Origin
            ReturnPrefix = hidOriginCode.Value
        ElseIf RecPrefix = "Y" Then
            If intJobDateType = 0 Then
                ReturnPrefix = Strings.Right(Format(tool.CheckNull(jobDate, 2), "yy"), 1)
            ElseIf intJobDateType = 1 Then
                ReturnPrefix = Strings.Right(Format(tool.CheckNull(ETASelect.sDateValue, 2), "yy"), 1)
            ElseIf intJobDateType = 2 Then
                ReturnPrefix = Strings.Right(Format(tool.CheckNull(ETDSelect.sDateValue, 2), "yy"), 1)
            End If
        ElseIf RecPrefix = "YY" Then  'If Prefix1 is Year
            If intJobDateType = 0 Then
                ReturnPrefix = Format(tool.CheckNull(jobDate, 2), "yy")
            ElseIf intJobDateType = 1 Then
                ReturnPrefix = Format(tool.CheckNull(ETASelect.sDateValue, 2), "yy")
            ElseIf intJobDateType = 2 Then
                ReturnPrefix = Format(tool.CheckNull(ETDSelect.sDateValue, 2), "yy")
            End If
        ElseIf RecPrefix = "M" Then
            If intJobDateType = 0 Then
                intMth = tool.CheckNull(Format(tool.CheckNull(jobDate, 2), "MM"), 1)
            ElseIf intJobDateType = 1 Then
                intMth = tool.CheckNull(Format(tool.CheckNull(ETASelect.sDateValue, 2), "MM"), 1)
            ElseIf intJobDateType = 2 Then
                intMth = tool.CheckNull(Format(tool.CheckNull(ETDSelect.sDateValue, 2), "MM"), 1)
            End If
            If intMth = 10 Then
                ReturnPrefix = "O"
            ElseIf intMth = 11 Then
                ReturnPrefix = "N"
            ElseIf intMth = 12 Then
                ReturnPrefix = "D"
            Else
                ReturnPrefix = Trim(CStr(intMth))
            End If
        ElseIf RecPrefix = "MM" Then  'If Prefix1 is Month
            If intJobDateType = 0 Then
                ReturnPrefix = Format(tool.CheckNull(jobDate, 2), "MM")
            ElseIf intJobDateType = 1 Then
                ReturnPrefix = Format(tool.CheckNull(ETASelect.sDateValue, 2), "MM")
            ElseIf intJobDateType = 2 Then
                ReturnPrefix = Format(tool.CheckNull(ETDSelect.sDateValue, 2), "MM")
            End If
        ElseIf RecPrefix = "DD" Then  'If Prefix1 is Date
            If intJobDateType = 0 Then
                ReturnPrefix = Format(tool.CheckNull(jobDate, 2), "dd")
            ElseIf intJobDateType = 1 Then
                ReturnPrefix = Format(tool.CheckNull(ETASelect.sDateValue, 2), "dd")
            ElseIf intJobDateType = 2 Then
                ReturnPrefix = Format(tool.CheckNull(ETDSelect.sDateValue, 2), "dd")
            End If
        ElseIf RecPrefix = "S" Then  'If Prefix1 is Shipment Type
            ReturnPrefix = "H"
        ElseIf Strings.Left(RecPrefix, 1) = "F" Then
            ReturnPrefix = Mid(RecPrefix, 2)
        ElseIf RecPrefix = "NN" Then
            ReturnPrefix = "00"
        ElseIf RecPrefix = "N" Then
            '"N" will replace job format type setting in Sepa1
            If strShipmentType = "M" Or strShipmentType = "H" Then
                ReturnPrefix = "0"
            ElseIf strShipmentType = "D" Then
                ReturnPrefix = "Z"
            End If
        End If
        Exit Function
        Return Err.Description
    End Function
#End Region

End Class
