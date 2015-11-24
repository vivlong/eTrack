Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.SystemClass
Imports Ntools
Imports SysMagic.ExportExcel
Imports System.Security
Imports System.Collections.Generic
Imports SysMagic

Partial Class _Default
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Private returnValue As String
    Private DataBaseSetting As String = IIf(ConfigurationManager.AppSettings.Item("DataBaseSetting") Is Nothing, _
                                           "", ConfigurationManager.AppSettings.Item("DataBaseSetting").ToString())
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
    Public Function FindSearch(ByVal strValue As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strValue)
        If strRow.Length <> 3 Then
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.UnmatchedParam
        End If
        Dim intType As Integer = GeneralFun.StringToInt(strRow(0))
        Dim strFields As String = strRow(1)
        Dim strSearchValue As String = strRow(2)
        Dim strModuleCode As String
        Dim strJobNo As String
        'System 
        Dim strSql As String
        Dim strUrl As String = ""
        Dim dtRec As DataTable
        Dim strTrxNo As String
        If String.IsNullOrEmpty(DataBaseSetting) Then
            Dim dataBaseSource As String() = ConDbConn.Instance.ReturnDataBaseList()
            If dataBaseSource.Length > 0 Then
                For Each dataBase As String In dataBaseSource
                    drpDatabase.Items.IndexOf(New ListItem(dataBase, dataBase))
                Next
            End If
            'set MutilServer
        Else
            drpDatabase.Items.Add(New ListItem(DataBaseSetting, DataBaseSetting))
        End If
        ConDbConn.Instance.SetDataKey(drpDatabase.SelectedValue)
        If strRow(1) = "ContainerNo" Then
            strSql = "Select a.JobNo,a.JobType,a.ModuleCode from Jmjm1 a left Join jmjt1 b on a.JobType=b.JobType where charindex('" + strSearchValue + ",',isnull(" + strFields + ",'')+',')>0"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count = 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "The " & strFields & " = '" & strSearchValue & "' not exist!"
            Else
                strModuleCode = dtRec.Rows(0).Item("ModuleCode").ToString
                strJobNo = dtRec.Rows(0).Item("JobNo").ToString
            End If
            If dtRec.Rows.Count = 1 Then
                If strModuleCode.ToUpper = "AE" Or strModuleCode.ToUpper = "AI" Then
                    strUrl = "CustomerServices/AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + drpDatabase.SelectedValue + "&JobNo=" + strJobNo + ""
                ElseIf strModuleCode.ToUpper = "SE" Or strModuleCode.ToUpper = "SI" Then
                    strUrl = "CustomerServices/SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + drpDatabase.SelectedValue + "&JobNo=" + strJobNo + ""
                End If
            Else
                strUrl = "CustomerServices/LeftSerach.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + drpDatabase.SelectedValue + "&strval=" + strSearchValue + "&strfield=ContainerNo"
            End If
            ''Get the data from the database
        ElseIf strRow(1) = "OrderNo" Then
            strSql = "Select TrxNo from omtx1   where " & strFields & "='" & strSearchValue & "'"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count = 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "The " & strFields & " = '" & strSearchValue & "' not exist!"
            Else
                strTrxNo = dtRec.Rows(0).Item("TrxNo").ToString
            End If
            strUrl = "CustomerServices/BookingEdit.aspx?Id=" + strTrxNo + "&ModuleCode=4"
        Else
            strSql = "Select a.JobNo,a.JobType,a.ModuleCode from Jmjm1 a left Join jmjt1 b on a.JobType=b.JobType where " & strFields & "='" & strSearchValue & "'"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count = 0 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "The " & strFields & " = '" & strSearchValue & "' not exist!"
            Else
                strModuleCode = dtRec.Rows(0).Item("ModuleCode").ToString
                strJobNo = dtRec.Rows(0).Item("JobNo").ToString
            End If
            If strModuleCode.ToUpper = "AE" Or strModuleCode.ToUpper = "AI" Then
                strUrl = "CustomerServices/AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + drpDatabase.SelectedValue + "&JobNo=" + strJobNo + ""
            ElseIf strModuleCode.ToUpper = "SE" Or strModuleCode.ToUpper = "SI" Then
                strUrl = "CustomerServices/SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + drpDatabase.SelectedValue + "&JobNo=" + strJobNo + ""
            End If
        End If
        'this part for check which login method they use , intType=0 means Customer, intType=1 means Internal , intType=3 means directorly search.
        Session("LoginType") = intType
        If (Request("Redirect") IsNot Nothing) Then
            strUrl = Request("Redirect").ToString().Trim()
            If strUrl = "" Then
                strUrl = "Default.aspx"
            End If
        End If
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strUrl
    End Function
    Public Function JudgeLogin(ByVal strValue As String, ByVal SiteCode As String) As String
        Try
            Dim objUser As New clsUser()
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 6 Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.UnmatchedParam
            End If
            Dim intType As Integer = GeneralFun.StringToInt(strRow(0))
            Dim strUserID As String = strRow(1)
            Dim strPassword As String = strRow(2)
            Dim strLanguage As String = strRow(3)
            Dim strMsg As String = ""
            Dim blnUserName As Boolean = Boolean.Parse(strRow(4))
            'database
            Dim database As String = ""
            If intType = 0 Then
                database = drpDatabase.SelectedValue
            Else
                database = strRow(5)
            End If
            Try
                '////////////////User DataBase As User Select//////////////////////////////////
                ConDbConn.Instance.SetDataKey(database)
                '//////////////////////////////////////////////////////////////////////////////
                'Get Client Ip 
                objUser.IpAddress = GetClientIp()
                objUser.CompNo = getCompanyName()
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 101"
            End Try
            Dim sql As String = String.Format("select count(*) from saus1 where UserID='{0}' and (password='{1}' or password='{2}')", strUserID, strPassword, objUser.Md5Crypt(strPassword))
            Dim dt As New DataTable
            Try
                dt = BaseSelectSrvr.GetData(sql, "")
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 102"
            End Try
            If Not dt Is Nothing AndAlso dt.Rows(0)(0) <> "0" Then
                sql = String.Format("select count(*) from roleperson where lUserID='{0}'", strUserID)
                dt = BaseSelectSrvr.GetData(sql, "")
                Dim RoleFlag As String = dt.Rows(0)(0)
                If RoleFlag = "0" Then
                    sql = String.Format("select AccessRight from saus1 where UserID='{0}'", strUserID)
                    dt = BaseSelectSrvr.GetData(sql, "")
                    If dt.Rows(0)(0).ToString() <> System.DBNull.Value.ToString() Then
                        Dim UserType As String = dt.Rows(0)(0)
                        If UserType = "A" Then
                            Try
                                sql = "select lId from roleinfo where sRoleName='administrator'"
                                dt = BaseSelectSrvr.GetData(sql, "")
                                Dim adminStr As String = dt.Rows(0)(0)
                                sql = String.Format("insert into roleperson(lRoleid,lUserId) values('{0}','{1}')", adminStr, strUserID)
                                dt = BaseSelectSrvr.GetData(sql, "")
                            Catch ex As Exception
                                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 103"
                            End Try
                        End If
                    End If
                End If
            End If
            Try
                If objUser.JudgePassword(strUserID, strPassword, 1, strMsg, ConDbConn._SelectDataBase, intType) Then
                    Try
                        SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, "Exec spi_Track_DefaultField '" + strUserID + "'")
                    Catch
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 104"
                    End Try
                    If SiteCode <> "" Then
                        Try
                            Dim i As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, "update saus1 set sitecode='" + SiteCode + "' where UserID='" + strUserID + "'")
                        Catch ex As Exception
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 105"
                        End Try
                        objUser.SiteCode = SiteCode
                    End If
                    If blnUserName Then
                        Response.Cookies("UserName").Value = strUserID
                        Response.Cookies("UserName").Expires = DateTime.Now.AddDays(365)
                        Response.Cookies("Language").Value = strLanguage
                        Response.Cookies("Language").Expires = DateTime.Now.AddDays(365)
                    Else
                        If Not (Request.Cookies("UserName") Is Nothing) Then
                            Response.Cookies("UserName").Expires = DateTime.Now.AddSeconds(1)
                            Request.Cookies.Remove("UserName")
                            Response.Cookies("Language").Expires = DateTime.Now.AddSeconds(1)
                            Request.Cookies.Remove("Language")
                        End If
                    End If
                    'Session Current User
                    Session(ConSessionName.UserInfo) = objUser
                    'Save Current Language to Session 
                    Session("CurrentLanguage") = strLanguage
                    'this part for check which login method they use , intType=0 means Customer, intType=1 means Internal -- add it by Jackie 080901
                    Session("LoginType") = intType
                    Session("Database") = database
                    'Session("Database") =
                    Dim strUrl As String = "Main.aspx"
                    '--------------------------------------
                    If (Request("Redirect") IsNot Nothing) Then
                        strUrl = Request("Redirect").ToString().Trim()
                        If strUrl = "" Then
                            strUrl = "FirstPage.aspx"
                        End If
                    End If
                    '--------------------------------------
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strUrl
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "error code 106"
            End Try
            dt = Nothing
        Catch ex As Exception
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ex.Message
        End Try
    End Function
    Private Function getCompanyName() As String
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select BusinessPartyCode from saco1", "")
            If dt IsNot Nothing Then
                Return dt.Rows(0)("BusinessPartyCode").ToString.Trim
            End If
        Catch ex As Exception
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ex.Message
        End Try
        Return ""
    End Function
    Private Sub InitShowControl()
        divShipment.Style.Add("display", "none") 'Shipment Tracking
        divSailingSchedule.Style.Add("display", "none") 'Sailing Schedule
        divVesselSchedule.Style.Add("display", "none") 'Vessel Schedule
        If clsInvalid.IsShowByUserFlag("0301") Then
            divShipment.Style.Remove("display") 'Shipment Tracking
        End If
        If clsInvalid.IsShowByUserFlag("0101") Then
            divVesselSchedule.Style.Remove("display") 'Vessel Schedule
        End If
        If clsInvalid.IsShowByUserFlag("0107") Then
            divSailingSchedule.Style.Remove("display") 'Sailing Schedule
        End If
        'Hide Login Screen
        Try
            If ConfigurationManager.AppSettings.Item("DisplayLogin") IsNot Nothing Then
                Dim displayLogin As String = ConfigurationManager.AppSettings.Item("DisplayLogin").ToString
                If displayLogin = "false" Then
                    divLoginInfo.Style.Add("display", "none")
                    divLoginInfo.Style.Remove("background")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SetInitValue()
        If Not (Request.Cookies("UserName") Is Nothing) Then
            txtUserId.Text = CStr(Request.Cookies("UserName").Value)
        End If
        If Not (Request.Cookies("Language") Is Nothing) Then
            drpLanguage.Text = CStr(Request.Cookies("Language").Value)
        End If
        'mulitServer
        If String.IsNullOrEmpty(DataBaseSetting) Then
            Dim dataBaseSource As String() = ConDbConn.Instance.ReturnDataBaseList()
            If dataBaseSource.Length > 0 Then
                For Each dataBase As String In dataBaseSource
                    drpDatabase.Items.Add(New ListItem(dataBase, dataBase))
                Next
            End If
        Else
            Dim dataBaseSource As String() = DataBaseSetting.Split(",")
            If dataBaseSource.Length > 0 Then
                For Each dataBase As String In dataBaseSource
                    If (Not String.IsNullOrEmpty(dataBase)) Then
                        drpDatabase.Items.Add(New ListItem(dataBase, dataBase))
                    End If
                Next
            End If
        End If
        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>set MutilServer>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ConDbConn.Instance.SetDataKey(drpDatabase.SelectedValue)
        'drpSearch
        drpSearch.Items.Clear()
        Dim strSearchDrp As String = ConfigurationManager.AppSettings.Item("drpSearch")
        If strSearchDrp Is Nothing Then
            drpSearch.Items.Add(New ListItem("Order No", "OrderNo"))
            drpSearch.Items.Add(New ListItem("Job No", "JobNo"))
            drpSearch.Items.Add(New ListItem("BL No", "AwbBlNo"))
            drpSearch.Items.Add(New ListItem("AWB No", "AwbBlNo"))
            drpSearch.Items.Add(New ListItem("Container No", "ContainerNo"))
            drpSearch.Items.Add(New ListItem("Reference No", "CustomerRefNo"))
        Else
            Dim arrSearchDrp As String() = strSearchDrp.Split(",")
            For Each strSearchDrp In arrSearchDrp
                Select Case strSearchDrp.Trim.ToUpper
                    Case "ORDER NO"
                        drpSearch.Items.Add(New ListItem("Order No", "OrderNo"))
                    Case "JOB NO"
                        drpSearch.Items.Add(New ListItem("Job No", "JobNo"))
                    Case "BL NO"
                        drpSearch.Items.Add(New ListItem("BL No", "AwbBlNo"))
                    Case "AWB NO"
                        drpSearch.Items.Add(New ListItem("AWB No", "AwbBlNo"))
                    Case "CONTAINER NO"
                        drpSearch.Items.Add(New ListItem("Container No", "ContainerNo"))
                    Case "REFERENCE NO"
                        drpSearch.Items.Add(New ListItem("Reference No", "CustomerRefNo"))
                End Select
            Next
        End If
        'drpTranshipmentTrack
        drpTranshipmentTrack.Items.Clear()
        Dim strTransDrp As String = ConfigurationManager.AppSettings.Item("drpTranshipmentTrack")
        If strTransDrp Is Nothing Then
            drpTranshipmentTrack.Items.Clear()
            drpTranshipmentTrack.Items.Add(New ListItem("House B/L", "BLNo"))
            drpTranshipmentTrack.Items.Add(New ListItem("Container No", "ContainerNo"))
        Else
            Dim arrTransDrp As String() = strTransDrp.Split(",")
            For Each strTransDrp In arrTransDrp
                Select Case strTransDrp.Trim.ToUpper
                    Case "HOUSE B/L"
                        drpTranshipmentTrack.Items.Add(New ListItem("House B/L", "BLNo"))
                    Case "CONTAINER NO"
                        drpTranshipmentTrack.Items.Add(New ListItem("Container No", "ContainerNo"))
                End Select
            Next
        End If
        'drpImportShipment
        drpImportShipment.Items.Clear()
        Dim strImpShpDrp As String = ConfigurationManager.AppSettings.Item("drpImportShipment")
        If strImpShpDrp Is Nothing Then
            drpImportShipment.Items.Add(New ListItem("House B/L", "BLNo"))
            drpImportShipment.Items.Add(New ListItem("Container No", "ContainerNo"))
        Else
            Dim arrImpShpDrp As String() = strImpShpDrp.Split(",")
            For Each strImpShpDrp In arrImpShpDrp
                Select Case strImpShpDrp.Trim.ToUpper
                    Case "HOUSE B/L"
                        drpImportShipment.Items.Add(New ListItem("House B/L", "BLNo"))
                    Case "CONTAINER NO"
                        drpImportShipment.Items.Add(New ListItem("Container No", "ContainerNo"))
                End Select
            Next
        End If
        'drpExportShipment
        drpExportShipment.Items.Clear()
        Dim strExpShpDrp As String = ConfigurationManager.AppSettings.Item("drpExportShipment")
        If strExpShpDrp Is Nothing Then
            drpExportShipment.Items.Add(New ListItem("House B/L", "BLNo"))
            drpExportShipment.Items.Add(New ListItem("Booking RefNo", "BookRefNo"))
        Else
            Dim arrExpShpDrp As String() = strExpShpDrp.Split(",")
            For Each strExpShpDrp In arrExpShpDrp
                Select Case strExpShpDrp.Trim.ToUpper
                    Case "HOUSE B/L"
                        drpExportShipment.Items.Add(New ListItem("House B/L", "BLNo"))
                    Case "BOOKING REFNO"
                        drpExportShipment.Items.Add(New ListItem("Booking RefNo", "BookRefNo"))
                End Select
            Next
        End If
        'Save as Default
        chkUserName.Checked = True
        'Type default
        rdbtnType.Items(1).Selected = True
        Try
            Dim objExport As ExcelExport = New ExcelExport
            objExport.CleanUpTemporaryFiles()
        Catch ex As Exception
        End Try
        'For CTS Logic 100319
        txtUserId.Attributes.Add("onblur", "ShowSite()")
        drSiteCode.Attributes.Add("onfocus", "BindSite()")
        'blind drPort
        Dim scriptPort As String = "select " & _
            " distinct (select PortName from rcsp1 where PortCode=a.PortOfDischargeCode) PortOfDischargeName ,PortOfDischargeCode" & _
            " from sebl1 a" & _
            " where isnull(PortOfDischargeName,'')!=''" & _
            " Order by PortOfDischargeName "
        Try
            Dim dt As DataTable = BaseSelectSrvr.GetData(scriptPort, "")
            If dt IsNot Nothing And dt.Rows.Count > 0 Then
                drPort.DataSource = dt
                drPort.DataTextField = "PortOfDischargeName"
                drPort.DataValueField = "PortOfDischargeCode"
                drPort.DataBind()
                drPort.Items.Insert(0, New ListItem("All", "All"))
                drPort.Items.Insert(0, New ListItem("", ""))
            End If
        Catch ex As Exception
        End Try
        'bind drVesselPort  110331
        Dim dtRec As DataTable
        Dim strSql As String = "Select distinct PortOfDischargeName from rcvy1" & _
                               " where PortOfDischargeName is not null and PortOfDischargeName<>''"
        Try
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drVSPort.DataSource = dtRec
                drVSPort.DataTextField = "PortOfDischargeName"
                drVSPort.DataValueField = "PortOfDischargeName"
                drVSPort.DataBind()
                drVSPort.Items.Insert(0, New ListItem("All", "All"))
                drVSPort.Items.Insert(0, New ListItem("", ""))
            End If
        Catch ex As Exception
        End Try
        dtRec = Nothing
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            txtUserId.Focus()
            SetInitValue()
            InitShowControl()
            txtPassword.Text = "sa"
            txtUserId.Attributes.Add("OnKeyDown", "javascript:FocusControl(event,null," + txtPassword.ClientID + ");")
            txtPassword.Attributes.Add("OnKeyDown", "javascript:FocusControl(event," + txtUserId.ClientID + "," + btnLogin.ClientID + ");")
            txtSearch.Attributes.Add("OnKeyDown", "javascript:FocusControl(event," + txtSearch.ClientID + "," + btnSubmit.ClientID + ");")
            txtSearch.Attributes.Add("OnKeyDown", "javascript:Reset();")
            If (Request("euid") IsNot Nothing And Request("epwd") IsNot Nothing And Request("edb") IsNot Nothing) Then
                RedirectLogin(Request("euid").ToString, Request("epwd").ToString, Request("edb").ToString)
            Else
                btnLogin.Attributes.Add("OnClick", "JudgeLogin();return false;")
            End If
            drpDatabase.Attributes.Add("onchange", "javascript:DataBaseChange(this);return false;")
        End If
    End Sub
    Private Sub RedirectLogin(ByVal euid As String, ByVal epwd As String, ByVal edb As String)
        Dim objUser As New clsUser()
        Dim intType As Integer = 1
        Dim strUserID As String = tool.DesDecrypt(euid)
        Dim strPassword As String = epwd
        Dim strLanguage As String = drpLanguage.SelectedItem.Value
        Dim strMsg As String = ""
        Dim blnUserName As Boolean = chkUserName.Checked
        Dim strDatabase As String = tool.DesDecrypt(edb)
        ''''''''''''''''''''''byzhiwei090615''''''''''''''''''''''''''''''''''''''''''''
        'Get Client Ip 
        objUser.IpAddress = GetClientIp()
        If objUser.JudgePassword(strUserID, strPassword, 1, strMsg, strDatabase, intType) Then
            If blnUserName Then
                Response.Cookies("UserName").Value = strUserID
                Response.Cookies("UserName").Expires = DateTime.Now.AddDays(365)
                Response.Cookies("Language").Value = strLanguage
                Response.Cookies("Language").Expires = DateTime.Now.AddDays(365)
            Else
                If Not (Request.Cookies("UserName") Is Nothing) Then
                    Response.Cookies("UserName").Expires = DateTime.Now.AddSeconds(1)
                    Request.Cookies.Remove("UserName")
                    Response.Cookies("Language").Expires = DateTime.Now.AddSeconds(1)
                    Request.Cookies.Remove("Language")
                End If
            End If
            'Session Current User
            Session(ConSessionName.UserInfo) = objUser
            'Save Current Language to Session 
            Session("CurrentLanguage") = strLanguage
            'this part for check which login method they use , intType=0 means Customer, intType=1 means Internal -- add it by Jackie 080901
            Session("LoginType") = intType
            Session("Database") = strDatabase
            Dim strUrl As String = "Main.aspx"
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language='javascript'>window.location.href='Main.aspx';</script>")
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language='javascript'>alert('Auto Login Fail');window.location.reload;</script>")
        End If
    End Sub
    'Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim objUser As New clsUser()
    '    Dim intType As Integer
    '    If rdbtnType.Items(0).Selected Then
    '        intType = 0
    '    Else
    '        intType = 1
    '    End If
    '    Dim strUserNo As String = txtUserId.Text.Trim()
    '    Dim strPassword As String = txtPassword.Text.Trim()
    '    Dim strMsg As String = ""
    '    Dim intCompanyId As Integer = 0
    '    Dim blnUserName As Boolean = chkUserName.Checked
    '    'Get client Ip
    '    objUser.IpAddress = GetClientIp()
    '    If objUser.JudgePassword(strUserNo, strPassword, intCompanyId, strMsg, drpDatabase.Text, intType) Then
    '        If blnUserName Then
    '            Response.Cookies("UserName").Value = strUserNo
    '            Response.Cookies("UserName").Expires = DateTime.Now.AddDays(365)
    '        Else
    '            If Not (Request.Cookies("UserName") Is Nothing) Then
    '                Response.Cookies("UserName").Expires = DateTime.Now.AddSeconds(1)
    '                Request.Cookies.Remove("UserName")
    '            End If
    '        End If
    '        Session(ConSessionName.UserInfo) = objUser
    '        Session("DisplaySmsHint") = "1"
    '        'Save Current Language to Session 
    '        Session("CurrentLanguage") = drpLanguage.SelectedValue.ToString()
    '        'this part for check which login method they use , intType=0 means Customer, intType=1 means Internal -- add it by Jackie 080901
    '        Session("LoginType") = intType
    '        If Not (Request("Redirect") Is Nothing) Then
    '            Dim strUrl As String = Request("Redirect").ToString().Trim()
    '            If strUrl = "" Then
    '                Response.Redirect("FirstPage.aspx")
    '            Else
    '                Response.Redirect(strUrl)
    '            End If
    '        Else
    '            Response.Redirect("Main.aspx")
    '        End If
    '    Else
    '        txtPassword.Text = ""
    '        ClientScript.RegisterStartupScript(Me.GetType(), "", "<script>window.alert('" + strMsg + "')</script>")
    '    End If
    'End Sub
    Private Function GetClientIp() As String
        Dim IP As String = Request.ServerVariables("Http_X_ForWarded_For")
        If Len(IP) = 0 Then
            IP = Request.ServerVariables("Remote_Addr")
        End If
        If Len(IP) = 0 Then
            IP = Request.UserHostAddress
        End If
        Return IP
    End Function
    Public Function ShowSite(ByVal UserNo As String) As String
        Dim objUser As New clsUser()
        Dim dt As DataTable
        Dim Userid As String = ""
        Dim SiteCode As String = ""
        txtPassword.Focus()
        Try
            Dim strSql As String = "select UserID,SiteCode from saus1 where UserID='" + UserNo + "'"
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    Userid = dt.Rows(0)(0).ToString
                    SiteCode = dt.Rows(0)(1).ToString
                End If
            End If
            '-------------------------------------------------------------
            If Userid <> "" Then
                Dim clsUser As New clsUser
                Dim strRole As String = ""
                If UserNo = "sa" Or UserNo.ToLower = "s" Then
                    objUser.RoleName = "admin"
                Else
                    strSql = "select sRoleName from RoleInfo where lId in (select lRoleId from RolePerson where lUserId='" + UserNo + "')"
                    dt = BaseSelectSrvr.GetData(strSql, "")
                    If dt.Rows.Count > 0 Then
                        strRole += "'" + dt.Rows(0)(0).ToString + "',"
                    End If
                    If strRole.Length > 1 Then
                        strRole = strRole.Substring(0, strRole.Length - 1)
                    End If
                End If
                dt = clsUser.ListSub(strRole, "9999")
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(0).ToString = "8" Then
                        BindSite(UserNo, SiteCode)
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drSiteCode)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ""
    End Function
    Public Sub BindSite(ByVal UserNo As String, ByVal SiteCode As String)
        Try
            Dim strSiteCode As String = ConfigurationManager.AppSettings.Item("SiteCode")
            Dim arrSiteCode As String() = strSiteCode.Split(",")
            For Each strSC As String In arrSiteCode
                If strSC.Trim <> "" Then
                    drSiteCode.Items.Add(New ListItem(strSC, strSC))
                End If
            Next
            drSiteCode.SelectedValue = SiteCode
        Catch ex As Exception
            If (drSiteCode.SelectedValue <> SiteCode) Then
                drSiteCode.Items.Insert(0, New ListItem(SiteCode, SiteCode))
                drSiteCode.SelectedValue = SiteCode
            End If
        End Try
    End Sub
    Public Function SallingCheck(ByVal Pod As String) As String
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + Pod
    End Function
#Region "Default Search"
    'Container No
    Public Function TranshipmentTrack(ByVal containerNo As String) As String
        Try
            If containerNo.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                sbSql.Append("select count(1) from Sibl1 a where a.TranshipmentFlag='Y' ")
                sbSql.Append(String.Format(" and ContainerNo like ('%{0}%') ", containerNo))
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) = 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "ContainerNo" + ConSeparator.Par + containerNo
                    ElseIf Integer.Parse(dt.Rows(0)(0).ToString()) > 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + containerNo
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + containerNo
    End Function
    'Container No
    Public Function ImportShipmentStatus(ByVal containerNo As String) As String
        Try
            If containerNo.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                sbSql.Append("select count(1) from Sibl1 a where 1=1 ")
                sbSql.Append(String.Format(" and ContainerNo like ('%{0}%') ", containerNo))
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) = 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "ContainerNo" + ConSeparator.Par + containerNo
                    ElseIf Integer.Parse(dt.Rows(0)(0).ToString()) > 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + containerNo
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + containerNo
    End Function
    Public Function ExportShipmentStatus(ByVal containerNo As String) As String
        Try
            If containerNo.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                sbSql.Append("select count(1) from Sebl1 a where 1=1 ")
                sbSql.Append(String.Format(" and ContainerNo like ('%{0}%') ", containerNo))
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) = 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "ContainerNo" + ConSeparator.Par + containerNo
                    ElseIf Integer.Parse(dt.Rows(0)(0).ToString()) > 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + containerNo
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + containerNo
    End Function
    'CheckTranshipmentTrack
    Public Function CheckTranshipmentTrack(ByVal fieldName As String, ByVal fileValue As String) As String
        Try
            If fileValue.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                sbSql.Append(String.Format("select count(1) from Sibl1 a where a.TranshipmentFlag='Y' and {0}='{1}'", fieldName, fileValue))
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) = 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + fieldName + ConSeparator.Par + fileValue
                    ElseIf Integer.Parse(dt.Rows(0)(0).ToString()) > 1 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + fieldName + ConSeparator.Par + fileValue
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err
    End Function
    'CheckTranshipmentTrack
    Public Function CheckImportShipment(ByVal fieldName As String, ByVal fileValue As String) As String
        Try
            If fileValue.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                sbSql.Append(String.Format("select count(1) from sibl1 a where 1=1 and {0}='{1}'", fieldName, fileValue))
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + fieldName + ConSeparator.Par + fileValue
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err
    End Function
    Public Function CheckExportShipment(ByVal fieldName As String, ByVal fileValue As String) As String
        Try
            If fileValue.Trim() <> "" Then
                Dim sbSql As New StringBuilder()
                If fieldName.Trim.ToUpper = "BOOKREFNO" Then
                    If fileValue.Length <= 3 Then
                        Return ZZMessage.ConMsgRtn.Err
                    End If
                    Dim strJobNo As String
                    Dim strSeqNo As String
                    strJobNo = Mid(fileValue, 1, fileValue.Length - 3)
                    strSeqNo = Mid(fileValue, fileValue.Length - 2, 3)
                    sbSql.Append(String.Format("select count(1) from sebk1 a where 1=1 and MasterJobNo like '{0}%'and BookingSeqNo= '{1}'", strJobNo, strSeqNo))
                Else
                    sbSql.Append(String.Format("select count(1) from sebl1 a where 1=1 and {0}='{1}'", fieldName, fileValue))
                End If

                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(sbSql.ToString(), "")
                If dt.Rows.Count > 0 Then
                    If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + fieldName + ConSeparator.Par + fileValue
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ZZMessage.ConMsgRtn.Err
    End Function
    'serverChange
    Public Function DataBaseChange(ByVal serverName As String) As String
        Try
            ConDbConn.Instance.SetDataKey(serverName)
            Return ZZMessage.ConMsgRtn.Ok
        Catch ex As Exception
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ex.Message
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ""
    End Function
#End Region
End Class