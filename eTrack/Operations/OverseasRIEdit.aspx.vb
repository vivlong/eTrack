Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports System.Data.SqlClient
Imports Ntools
Imports SysMagic

Partial Class OverseasRIEdit
    Inherits ListEditPage
    Private objServer As clsRI
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsRI(intUserId)
    End Function
#End Region
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#Region "public"
    Private Sub SetInitValue(ByVal intUserId As String)
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim strwhere As String = ""
        If Request("Id") = Nothing Then
            strwhere = ""
        End If
        'btnETA
        btnETA.Attributes.Add("OnClick", "WdatePicker({el:'txtETA',dateFmt:'dd-MMM-yy HH:mm'});return false;")
        txtETA.Attributes.Add("onfocus", "ChangeShortDate('" + txtETA.ClientID + "');return false;")
        txtETA.Attributes.Add("onblur", "ChangeLongDate('" + txtETA.ClientID + "');return false;")
        'btnReleaseDate
        btnReleaseDate.Attributes.Add("OnClick", "WdatePicker({el:'txtReleaseDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
        txtReleaseDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtReleaseDate.ClientID + "');return false;")
        txtReleaseDate.Attributes.Add("onblur", "ChangeLongDate('" + txtReleaseDate.ClientID + "');return false;")
        'btnJobNo
        btnJobNo.Attributes.Add("OnClick", "return false;")
        btnJobNo.Style.Add("display", "none")
        btnPortOfDischarge.Attributes.Add("OnClick", "selBindCode(" + txtPortOfDischarge.ClientID + ",'rcsp1','PortCode,PortName','','Port Of Discharge Code','Port Of Discharge Name');return false;")
        btnCancel.Attributes.Add("OnClick", "showCancel();return false;")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Session("TrxNo_Oversea") = "-1"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If

            txtOrganization.ReadOnly = True
            hidTrxNo.Value = -1
            'Set Default Value
            Dim strFun As String = PageFun.GetFunNo(Page)
            SetInitValue(objUser.UserId)
            objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
            'Get First Page Data
            BindDetailData(objUser.UserId, intTrxNo, objUser)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            objServer = NewServerObject(objUser.UserId)
            KeydownEvent()
            btnRelease.Attributes.Add("OnClick", "CreateEvent('" + objServer.Title + "',1);return false;")
            'Language 
            HandleLanguageRelative()
            HandlePopupMenu()
            a1.Style.Add("display", "none")
            txtPortOfDischarge.Attributes.Add("onchange", "valiString('" + txtPortOfDischarge.ClientID + "','Prot Of Discharge','PortCode','rcsp1','')")
        End If
    End Sub
    Private Function getTrxNo() As String
        Dim strTrxNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(TrxNo)+1 as TrxNo from ctri1", "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("TrxNo").ToString.Trim <> "" Then
                        strTrxNo = dt.Rows(0)("TrxNo").ToString.Trim
                    End If
                End If
            End If
            If strTrxNo <> "" Then
                Return strTrxNo
            Else
                Return "1"
            End If
        Catch ex As Exception
            Return "1"
        End Try
    End Function
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
#End Region
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
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal ObjUser As clsUser)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropRI = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            txtJobNo.Text = tmpProp.MasterJobNo
            txtVesselName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            ConvertDateTime(txtETA, tmpProp.EtaDate)
            txtPortOfDischarge.Text = tmpProp.PortOfDischargeCode
            ConvertDateTime(txtReleaseDate, tmpProp.EtaDate)
            Me.Title = "Releasing Instruction :" + tmpProp.ReleasingInstructionNo
        Else
            Me.Title = "New"
            txtOrganization.Text = objUser.CompNo
        End If
    End Sub
    Private Sub KeydownEvent()
        setFocusControl(txtOrganization, txtJobNo)
        setFocusControl(txtJobNo, txtVesselName)
        setFocusControl(txtVesselName, txtVoyageNo)
        setFocusControl(txtVoyageNo, txtETA)
        setFocusControl(txtETA, txtPortOfDischarge)
        setFocusControl(txtPortOfDischarge, txtReleaseDate)
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
        FirCon.Attributes.Add("onchange", "UpdateFlag='Y';")
    End Sub
    Public Function SaveRIDetail(ByVal strValue As String, ByVal RIN As String, ByVal RON As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            Dim tmpId As Int64 = Int64.Parse(strRow(0))
            Dim strField As String = ""
            If tmpId < 0 Then
                If RIN = "" Then
                    RIN = CreateRIN("CTRI")
                    'If RIN.Length > 10 Then
                    '    RIN = RIN.Substring(RIN.Length - 10)
                    'End If
                End If
                If RON.Trim = "" Then
                    RON = CreateRIN("CTRO")
                    'If RON.Length > 10 Then
                    '    RON = RON.Substring(RON.Length - 10)
                    'End If
                End If
                If InsertRI(RIN, strRow, RON) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "RI Info Save Success" + ConSeparator.Par + RIN + ConSeparator.Par + RON + ConSeparator.Par + intTrxNo.ToString
                End If
                'External Flag
                'WR Flag
            Else
                If UpdteRI(RIN, strRow, RON, tmpId) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "RI Info Save Success" + ConSeparator.Par + RIN + ConSeparator.Par + RON + ConSeparator.Par + intTrxNo.ToString
                End If
            End If
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "RI Info Save false." + ConSeparator.Par + RIN + ConSeparator.Par + RON + ConSeparator.Par + intTrxNo.ToString
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + RIN + ConSeparator.Par + RON + ConSeparator.Par + intTrxNo.ToString
        End If
    End Function
    Private Function UpdteRI(ByRef RINo As String, ByRef strRow As String(), ByRef RON As String, ByRef tmpId As String) As Boolean
        Try
            Dim param(8) As SqlParameter
            param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
            param(1) = New SqlParameter("@MasterJobNo", SqlDbType.NVarChar, 40)
            param(2) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
            param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
            param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
            param(5) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 10)
            param(6) = New SqlParameter("@ReleasingInstructionNo", SqlDbType.NVarChar, 20)
            param(7) = New SqlParameter("@TrxNO", SqlDbType.Int)
            param(7).Direction = ParameterDirection.Output
            param(8) = New SqlParameter("@ReleasingOrderNo", SqlDbType.NVarChar, 10)

            param(0).Value = strRow(1) 'OrganisationCode
            param(1).Value = strRow(2) 'MasterJobNo
            param(2).Value = strRow(3) 'VesselName
            param(3).Value = strRow(4) 'VoyageNo
            param(4).Value = GeneralFun.StringToDate(strRow(5)) 'EtaDate
            param(5).Value = strRow(6) 'PortOfDischargeCode
            param(6).Value = RINo      'ReleasingInstructionNo
            param(7).Value = tmpId     'TrxNO
            param(8).Value = RON
            Dim intResult As Integer
            intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_ctri1_Overseas", param)
            If intResult > 0 Then
                intTrxNo = tmpId
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function InsertRI(ByRef RINo As String, ByRef strRow As String(), ByRef RON As String) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        End If
        Try
            Dim param(10) As SqlParameter
            param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
            param(1) = New SqlParameter("@MasterJobNo", SqlDbType.NVarChar, 40)
            param(2) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
            param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
            param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
            param(5) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 10)
            param(6) = New SqlParameter("@ReleasingInstructionNo", SqlDbType.NVarChar, 20)
            param(7) = New SqlParameter("@TrxNO", SqlDbType.Int)
            param(7).Direction = ParameterDirection.Output
            param(8) = New SqlParameter("@ReleasingOrderNo", SqlDbType.NVarChar, 20)
            param(9) = New SqlParameter("@SiteCode", SqlDbType.NVarChar, 10)
            param(10) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)

            param(0).Value = strRow(1) 'OrganisationCode
            param(1).Value = strRow(2) 'MasterJobNo
            param(2).Value = strRow(3) 'VesselName
            param(3).Value = strRow(4) 'VoyageNo
            param(4).Value = GeneralFun.StringToDate(strRow(5)) 'EtaDate
            param(5).Value = strRow(6) 'PortOfDischargeCode
            param(6).Value = RINo      'ReleasingInstructionNo
            param(7).Value = ""        'TrxNO
            param(8).Value = RON
            param(9).Value = objUser.SiteCode
            param(10).Value = objUser.UserId
            Dim intResult As Integer
            intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctri1_Overseas", param)
            If intResult > 0 Then
                intTrxNo = Int64.Parse(param(7).Value.ToString())
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function SaveCtro2(ByVal strContainerNO As String, ByVal strTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt As DataTable
        Dim intResult As Integer = -1
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strContainerNO.ToString <> "" Then
                Dim strSql2 As String = "select ContainerType from rccf1 where ContainerNo='" + strContainerNO + "'"
                Dim strTankType As String
                dt = BaseSelectSrvr.GetData(strSql2, "")
                If dt.Rows.Count = 0 Then
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO not exist in Container Master!"
                Else
                    strTankType = dt.Rows(0)("ContainerType")
                End If
                Dim strLineItemNo As String = "1"
                dt = BaseSelectSrvr.GetData("select * from ctro2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineItemNo + " and ContainerNO='" + strContainerNO + "'", "")
                If dt.Rows.Count < 1 Then
                    '---------------------------------------
                    Dim param(3) As SqlParameter
                    param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                    param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                    param(2) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                    param(3) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar, 5)
                    param(0).Value = strTrxNo 'TrxNo
                    param(1).Value = strLineItemNo 'LineItemNo
                    param(2).Value = strContainerNO 'ContainerNO
                    param(3).Value = strTankType 'TankType
                    Try
                        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctro2_Overseas", param)
                    Catch ex As Exception
                    End Try
                    '---------------------------------------
                    If intResult > 0 Then
                        Session("TrxNo_Oversea") = strTrxNo
                        intTrxNo = Int64.Parse(strTrxNo)
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
                    Else
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false."
                    End If
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!"
                End If
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function
    Private Function getLineItemNo(ByVal TrxNo As String) As String
        Dim strLineItemNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(LineItemNo) as LineItemNo from ctro1 where TrxNo=" + TrxNo, "")
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
    Public Function DeleteCTRO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByVal ContainerNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not FDeleteCTRO2(strTrxNo, strLineItemNo, ContainerNo) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record." + ConSeparator.Par
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par
        End If
    End Function
    Public Function CancleFun(ByVal strTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Session("TrxNo_Oversea") = "-1"
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function FDeleteCTRO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef ContainerNo As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete ctro2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineItemNo + " and ContainerNo='" + ContainerNo + "'"
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    intTrxNo = strTrxNo
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If

    End Function
    Public Function CTRO2Update(ByVal strsql As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal conContainer As String, ByVal UpdteValue As String, ByVal OldValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim dt As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strSql2 As String = "select ContainerNo from rccf1 where ContainerNo='" + UpdteValue + "'"
            dt = BaseSelectSrvr.GetData(strSql2, "")
            If dt.Rows.Count = 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO  not exist in Container Master!" + ConSeparator.Par + conContainer + ConSeparator.Par + OldValue
            End If
            dt = BaseSelectSrvr.GetData("select * from ctro2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineitemno + " and ContainerNO='" + UpdteValue + "'", "")
            If dt.Rows.Count >= 1 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!" + ConSeparator.Par + conContainer + ConSeparator.Par + OldValue
            End If
            Dim intflag As String = ""
            Try
                intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
            Catch ex As Exception

            End Try

            If intflag = 1 Then
                intTrxNo = strTrxNo
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + conContainer + ConSeparator.Par + OldValue
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + conContainer + ConSeparator.Par + OldValue
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + conContainer + ConSeparator.Par + OldValue
    End Function
    Public Function InsertCTCE(ByVal strFields As String) As String
        Dim objUser As clsUser = Nothing
        Dim intResult As Integer = -1
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strFields <> "" Then
                Dim arr As String() = strFields.Split("#")
                Dim ds As DataSet = Nothing
                Dim InsertFlag As String = ""
                Dim ConRelease As String = ""
                Dim ConDate As String = ""
                For Each strs As String In arr
                    If strs.Length > 3 Then
                        Dim strFie As String() = strs.Split(",")
                        Dim strTrxNO As String = strFie(0)
                        Dim strLineItemNo As String = strFie(1)
                        Dim strContainerNo As String = strFie(2)
                        Dim strReceivedDate As String = GeneralFun.StringToDate(strFie(3))
                        Dim param(7) As SqlParameter
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
                            param(0).Value = strTrxNO
                            param(1).Value = strLineItemNo
                            param(2).Value = strContainerNo
                            param(3).Value = strReceivedDate
                            param(7).Value = objUser.UserId
                            ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_ctcl1_Overseas", param)
                            intTrxNo = Integer.Parse(strTrxNO)
                        Catch ex As Exception
                            intResult = -1
                        End Try
                        InsertFlag = param(4).Value.ToString
                        If param(5).Value.ToString <> "" Then
                            ConRelease += param(5).Value.ToString + vbNewLine
                        End If
                        If param(6).Value.ToString <> "" Then
                            ConDate += param(6).Value.ToString + vbNewLine
                        End If
                    End If
                Next
                If ConRelease = "" And ConDate = "" Then

                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
                Else
                    If ConRelease <> "" Then
                        ConRelease = "Below Container should do Depot In first." + vbNewLine + ConRelease
                    End If
                    If ConDate <> "" Then
                        ConDate = "Below Container's Release Date must be Later." + vbNewLine + ConDate
                        ConRelease = ConRelease + vbNewLine + ConDate
                    End If
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ConRelease
                End If
            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ""
    End Function
#End Region
#Region "Grid View RO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)
        intPageIndex = intPage
        objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
        objList.Where += " and a.TrxNo=" + Session("TrxNo_Oversea").ToString
        'Set Default Value
        objList.GetListInfo(intPage, 0)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsOverSeas(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctro2_OverSea"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub
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
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Attributes.Remove("onclick")
            Dim Im As Image = e.Row.Cells(0).FindControl("imgInsert")
            Im.Attributes.Add("OnClick", "AddToRO2();return false;")
            Im.Attributes.Add("onfocus", " FocusSave(event,'Releasing Instruction');")
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim strLineItemNo As String = CType(tmpProp, clsPropRO2).LineItemNo.ToString()
            Dim strContainerNo As String = CType(tmpProp, clsPropRO2).ContainerNo
            Dim strTrxNo As String = CType(tmpProp, clsPropRO2).TrxNo.ToString
            Dim ReleaseFlag As Integer = CType(tmpProp, clsPropRO2).ReleaseFlag

            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            imgRestore.Visible = False

            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            imgEdit.Visible = False
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            imgInsert.Visible = False
            Dim objcontainerno As New TextBox
            objcontainerno.ID = "txtContainerNo"
            objcontainerno.Text = e.Row.Cells(1).Text.Replace("&nbsp;", "")
            objcontainerno.BackColor = Color.AntiqueWhite
            objcontainerno.BorderStyle = BorderStyle.Solid
            objcontainerno.BorderWidth = 0
            objcontainerno.MaxLength = 13
            objcontainerno.TabIndex = 100
            e.Row.Cells(1).Style.Add("text-align", "center")
            e.Row.Cells(1).Style.Add("width", "20px")
            e.Row.Cells(1).BackColor = Color.AntiqueWhite
            e.Row.Cells(1).Controls.Add(objcontainerno)
            Dim txtContainerNo As TextBox = e.Row.Cells(1).FindControl("txtContainerNo")
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If strTrxNo <> "-1" And ReleaseFlag = 0 Then
                imgDelete.Attributes.Add("onclick", "DeleteCTRO2('" + strTrxNo + "','" + strLineItemNo + "','" + strContainerNo + "');return false;")
                txtContainerNo.Attributes.Add("onblur", "UpdateCTRO2('" + strTrxNo + "','" + strLineItemNo + "','" + strContainerNo + "','" + txtContainerNo.ClientID + "');")
                Dim objTrxNo As New HiddenField
                objTrxNo.ID = "hidTrxNo"
                objTrxNo.Value = strTrxNo
                Dim objLineItemNo As New HiddenField
                objLineItemNo.ID = "hidLineItemNo"
                objLineItemNo.Value = strLineItemNo
                e.Row.Cells(1).Controls.Add(objTrxNo)
                e.Row.Cells(1).Controls.Add(objLineItemNo)
            Else
                If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                    txtContainerNo.Attributes.Add("onkeydown", " SaveCtro2(event,'Releasing Instruction');")
                    txtContainerNo.Attributes.Add("onfocus", " FocusSave(event,'Releasing Instruction');")
                Else
                    txtContainerNo.ReadOnly = True
                End If
                imgDelete.Visible = False
            End If
        End If
    End Sub
    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Edit MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""DeleteDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "DeleteRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
        popupMenu.InnerHtml = strOperate
    End Sub
    Private Sub HandleLanguageRelative()
        Dim strReg As String = GetJavascriptLanguageConst().Replace("EditWidth=", "EditWidth=null").Replace("EditHeight=", "EditHeight=null")
        strReg = strReg.Replace("</script>", " var RegTrxNo='" + intTrxNo.ToString + "';</script>")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", strReg)
    End Sub
#End Region
#Region "Create RINNo "
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
    Private Function CreateRIN(ByVal NumberType As String) As String
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'CreateOrderNo
            If strDate <> "" Then
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                           "where NumberType  like '%" + NumberType + "%'", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim fiePrefix As Object = ReturnfiePrefix(dtReclzw.Rows(0)("Prefix").ToString)
                    Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                    Dim fieSuffix As Object = ReturnfieSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                    Return fiePrefix + fieNextNo + fieSuffix
                End If
            End If
        End If
        Return ""
    End Function

#End Region
End Class