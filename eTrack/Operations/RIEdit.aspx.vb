Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports Ntools
Imports SysMagic

Partial Class RIEdit
    Inherits ListEditPage
    Private objServer As clsRI
    'Dim objExport As ExportToExcel.ExcelExport
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Protected ConfigPath As String
    Protected ExportConfig As String
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
    Private Sub SetInitValue(ByVal UserId As String, ByRef objUser As clsUser)
        txtUserId.Text = UserId
        hidNewTrxNo.Value = getTrxNo()
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim strwhere As String = ""
        If Request("Id") = Nothing Then
            strwhere = ""
        End If
        drReleaseType.Items.Add(New ListItem("EL - Export Laden", "EL"))
        drReleaseType.Items.Add(New ListItem("EM - Export Empty", "EM"))
        drReleaseType.Items.Add(New ListItem("FH - Off Hire", "FH"))
        drReleaseType.Items.Add(New ListItem("HO - Hire Out", "HO"))
        drReleaseType.Items.Add(New ListItem("NC - Non Container Terminal", "NC"))
        drReleaseType.Items.Add(New ListItem("OT - Others", "OT"))
        drReleaseType.Items.Insert(0, New ListItem(ListItemSelect, ""))
        drReleaseType.Style.Remove("display")
        'BindCode
        btnReleasingDC.Attributes.Add("OnClick", "selBindCode(" + txtReleasingDC.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnPortOfLoading.Attributes.Add("OnClick", "selBindCode(" + txtPortOfLoading.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnProtOfDischarge1.Attributes.Add("OnClick", "selBindCode(" + txtProtOfDischarge1.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnProtOfDischarge2.Attributes.Add("OnClick", "selBindCode(" + txtProtOfDischarge2.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnProtOfDischarge3.Attributes.Add("OnClick", "selBindCode(" + txtProtOfDischarge3.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnFinalDestination.Attributes.Add("OnClick", "selBindCode(" + txtFinalDestination.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
        btnClose.Attributes.Add("OnClick", "blChanged=true;CloseWindow(0);return false;")
        'btnNew.Attributes.Add("OnClick", "NewDetail(0);return false;")
        'drDetentionCode
        If objUser.SiteCode = "SGSIN" Then
            drDetentionCode.Items.Add(New ListItem("5D", "5D"))
            drDetentionCode.Items.Add(New ListItem("7D", "7D"))
            drDetentionCode.Items.Add(New ListItem("14D", "14D"))
            drDetentionCode.Items.Add(New ListItem("30D", "30D"))
            drDetentionCode.Items.Add(New ListItem("OTH", "OTH"))
        Else
            txtFreePeriod.ReadOnly = True
        End If
        drDetentionCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
    End Sub
    Private Sub HidControl(ByVal bol As Boolean, ByRef UpperFlag As String)
        'UpperCase
        If UpperFlag = "y" Then
            setUpperCase(txtMasterJobNo)
            setUpperCase(txtVesselName)
            setUpperCase(txtVoyageNo)
            setUpperCase(txtReleasingDC)
            setUpperCase(txtPortOfLoading)
            setUpperCase(txtProtOfDischarge1)
            setUpperCase(txtProtOfDischarge2)
            setUpperCase(txtProtOfDischarge3)
            setUpperCase(txtFinalDestination)
        End If
        btnMasterJobNo.Style.Add("display", "none")
        If Not bol Then  'Deport Out
            btnETA.Style.Add("display", "none")
            btnReleasingDC.Style.Add("display", "none")
            btnPortOfLoading.Style.Add("display", "none")
            btnProtOfDischarge1.Style.Add("display", "none")
            btnProtOfDischarge2.Style.Add("display", "none")
            btnProtOfDischarge3.Style.Add("display", "none")
            btnFinalDestination.Style.Add("display", "none")
            btnSave.Style.Add("display", "none")
            'btnNew.Style.Add("display", "none")
            'lblBlank.Visible = True
            'control'enable&readonly
            txtVoyageNo.ReadOnly = True
            txtOrganization.ReadOnly = True
            txtMasterJobNo.ReadOnly = True
            txtVesselName.ReadOnly = True
            txtETA.ReadOnly = True
            drReleaseType.Style.Add("display", "none")
            txtReleaseType.Style.Remove("display")
            txtReleaseType.Style.Add("pandding-left", "0px")
            txtReleaseType.ReadOnly = True
            txtReleasingDC.ReadOnly = True
            txtPortOfLoading.ReadOnly = True
            txtProtOfDischarge1.ReadOnly = True
            txtProtOfDischarge2.ReadOnly = True
            txtProtOfDischarge3.ReadOnly = True
            txtFinalDestination.ReadOnly = True
            drDetentionCode.Style.Add("display", "none")
            txtDetentionCode.Style.Remove("display")
            txtFreePeriod.ReadOnly = True
        Else
            drReleaseType.Style.Remove("display")
            txtReleaseType.Style.Add("display", "none")
            drDetentionCode.Style.Remove("display")
            txtDetentionCode.Style.Add("display", "none")
            If UpperFlag = "y" Then
                txtReleasingDC.Attributes.Add("onchange", "valiString('" + txtReleasingDC.ClientID + "','Releasing Dest Code.','PortCode','rcsp1','');")
                txtPortOfLoading.Attributes.Add("onchange", "valiString('" + txtPortOfLoading.ClientID + "','Port Of Loading Code.','PortCode','rcsp1','');")
                txtProtOfDischarge1.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge1.ClientID + "','Port Of Discharge Code1.','PortCode','rcsp1','');")
                txtProtOfDischarge2.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge2.ClientID + "','Port Of Discharge Code2.','PortCode','rcsp1','');")
                txtProtOfDischarge3.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge3.ClientID + "','Port Of Discharge Code3.','PortCode','rcsp1','');")
                txtFinalDestination.Attributes.Add("onchange", "valiString('" + txtFinalDestination.ClientID + "','Final Destination Code.','PortCode','rcsp1','');")
            Else
                txtReleasingDC.Attributes.Add("onchange", "valiString('" + txtReleasingDC.ClientID + "','Releasing Dest Code.','PortCode','rcsp1','');")
                txtPortOfLoading.Attributes.Add("onchange", "valiString('" + txtPortOfLoading.ClientID + "','Port Of Loading Code.','PortCode','rcsp1','');")
                txtProtOfDischarge1.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge1.ClientID + "','Port Of Discharge Code1.','PortCode','rcsp1','');")
                txtProtOfDischarge2.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge2.ClientID + "','Port Of Discharge Code2.','PortCode','rcsp1','');")
                txtProtOfDischarge3.Attributes.Add("onchange", "valiString('" + txtProtOfDischarge3.ClientID + "','Port Of Discharge Code3.','PortCode','rcsp1','');")
                txtFinalDestination.Attributes.Add("onchange", "valiString('" + txtFinalDestination.ClientID + "','Final Destination Code.','PortCode','rcsp1','');")
            End If
            'lblBlank.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Session("InsertRIData") = ""
            Session("min") = "1"
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
            txtOrganization.ReadOnly = True
            hidTrxNo.Value = -1
            'Set Default Value
            Dim strFun As String = PageFun.GetFunNo(Page)

            SetInitValue(objUser.UserId, objUser)

            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                hidTrxNo.Value = intTrxNo
                'Assign Page Event and Relative Value
                lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false;")
                lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false;")
                lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false;")
                lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false;")
                lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false;")
                txtPage.Text = intPageIndex.ToString()
                txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData(" + txtPage.ClientID + ",4); return false;}")
                txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            Else
                'intTrxNo = getTrxNo()
            End If

            HidControl(objList.EditPrivilege, objUser.UpperCase)
            BindDetailData(objUser.UserId, intTrxNo, objUser)
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            objServer = NewServerObject(objUser.UserId)
            ControlEvent()
            btnETA.Attributes.Add("OnClick", "WdatePicker({el:'txtETA',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            txtETA.Attributes.Add("onfocus", "ChangeShortDate('" + txtETA.ClientID + "');return false;")
            txtETA.Attributes.Add("onblur", "ChangeLongDate('" + txtETA.ClientID + "');return false;")
            btnMasterJobNo.Attributes.Add("OnClick", "return false;")
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            'txtSiteCode
            txtSiteCode.Text = objUser.SiteCode
            'Language 
            HandleLanguageRelative()
            HandlePopupMenu()
        End If
        'btnNew.Attributes.Add("display", "none")
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
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal objUser As clsUser)
        Dim dt As DataTable
        'Only allow Admin access right to modify PortOfLoadingCode in Releasing Instruction
        Dim strsql As String = "select sRoleName from RoleInfo where lId in (select lRoleId from RolePerson where lUserId='" + objUser.UserId.ToString + "')"
        Try
            dt = BaseSelectSrvr.GetData(strsql, "")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString.Trim <> "Manager" Then
                    txtPortOfLoading.ReadOnly = True
                    btnPortOfLoading.Style.Add("display", "none")
                End If
            End If
        Catch ex As Exception

        End Try


        objServer = NewServerObject(intUserId)
        txtFreePeriod.Attributes.Add("OnKeyPress", "Number(event);")
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropRI = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo <= 0 Then
                intTrxNo = GetNewId()
                tmpProp.TrxNo = intTrxNo
            End If
            txtRIN.Text = tmpProp.ReleasingInstructionNo
            txtOrganization.Text = tmpProp.OrganisationCode
            txtMasterJobNo.Text = tmpProp.MasterJobNo
            txtVesselName.Text = tmpProp.VesselName
            txtVoyageNo.Text = tmpProp.VoyageNo
            ConvertDateTime(txtETA, tmpProp.EtaDate)
            drReleaseType.SelectedValue = tmpProp.ReleaseType
            txtReleaseType.Text = drReleaseType.SelectedItem.Text
            txtReleasingDC.Text = tmpProp.ReleasingDestinationCode
            txtPortOfLoading.Text = tmpProp.PortOfLoadingCode
            txtProtOfDischarge1.Text = tmpProp.FirstViaPortCode
            txtProtOfDischarge2.Text = tmpProp.SecondViaPortCode
            txtProtOfDischarge3.Text = tmpProp.ThirdViaPortCode
            txtFinalDestination.Text = tmpProp.PortOfDischargeCode
            drDetentionCode.SelectedValue = tmpProp.DetentionCode
            txtDetentionCode.Text = drDetentionCode.SelectedItem.Text
            txtFreePeriod.Text = tmpProp.DetentionFreeDay
            If PageFun.GetFunNo(Page) <> "1001" Then
                Me.Title = "Depot Out "
                a1.Text = "Releasing Instruction : " + tmpProp.ReleasingInstructionNo
            Else
                Me.Title = "Releasing Instruction : " + tmpProp.ReleasingInstructionNo
                a1.Style.Add("display", "none")
            End If
            Dim sb As New StringBuilder
            Dim strFields As String = "(JobNo,RITrxNo,VesselName,VoyageNo,PortOfLoadingCode,PortOfDischargeCode)"
            Dim strValue As String = "('" + tmpProp.MasterJobNo + "'," + intTrxNo.ToString + ",'" + tmpProp.VesselName + "','" + tmpProp.VoyageNo + "','" + tmpProp.PortOfLoadingCode + "','" + tmpProp.PortOfDischargeCode + "')"
            Session("InsertRIData") = strFields + "#" + strValue
        Else
            Me.Title = "New"
            dt = BaseSelectSrvr.GetData("select SiteCode from Person where lUserId=" + intUserId, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    dt.Rows(0)("SiteCode").ToString()
                    txtPortOfLoading.Text = dt.Rows(0)("SiteCode").ToString()
                End If
            End If
            If objUser.CompNo.Length > 10 Then
                objUser.CompNo = objUser.CompNo.Substring(0, 10)
            End If
            txtOrganization.Text = objUser.CompNo
            If objUser.SiteCode = "SGSIN" Then
                drDetentionCode.SelectedValue = "7D"
                txtFreePeriod.Text = "7"
            End If
            txtETA.Text = DateTime.Now.ToString("dd-MMM-yy HH:mm")
        End If
        drDetentionCode.Attributes.Add("onchange", "DetentionCodeSelect('" + drDetentionCode.ClientID + "')")
        dt = Nothing
    End Sub
    Private Sub ControlEvent()
        'setFocusControl
        setFocusControl(txtOrganization, txtMasterJobNo)
        setFocusControl(txtMasterJobNo, txtVesselName)
        setFocusControl(txtVesselName, txtVoyageNo)
        setFocusControl(txtVoyageNo, txtETA)
        setFocusControl(txtETA, drReleaseType)
        setFocusControl(drReleaseType, txtReleasingDC)
        setFocusControl(txtReleasingDC, txtPortOfLoading)
        setFocusControl(txtPortOfLoading, txtProtOfDischarge1)
        setFocusControl(txtProtOfDischarge1, txtProtOfDischarge2)
        setFocusControl(txtProtOfDischarge2, txtProtOfDischarge3)
        setFocusControl(txtProtOfDischarge3, txtFinalDestination)
        setFocusControl(txtFinalDestination, drDetentionCode)
        setFocusControl(drDetentionCode, txtFreePeriod)

    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");return false;")
    End Sub
    Public Function SaveData(ByVal strValue As String, ByVal strRI As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If strValue.Substring(0, strValue.IndexOf("#")) = "-1" Then
                CreateRIN()
            End If
            strValue = strValue.Replace("Releasing@InstructionNo", txtRIN.Text)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId IsNot Nothing Then
                        hidTrxNo.Value = objServer.masterId
                    End If
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + GridViewFun.RenderControl(hidTrxNo) + ConSeparator.Par + txtRIN.Text
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(hidTrxNo) + ConSeparator.Par + txtRIN.Text
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
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
#Region "Grid View RO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)
        intPageIndex = intPage
        If objList.Where.Trim = "" Then
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
            End If
            If intTrxNo = "-1" Then
                intTrxNo = "-11"
            End If
            objList.Where += " and a.TrxNo=" + intTrxNo.ToString
        Else
            hidTrxNo.Value = objList.Where.Substring(objList.Where.LastIndexOf("=") + 1)
        End If
        If objList.Where.IndexOf("1=1") < 0 Then
            objList.Where = "1=1" + objList.Where
        End If
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("ctro1", gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsRO(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctro1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "LineItemNo"
        Me.SortDesc = True
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
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
            Dim intLineItemNo As String = CType(tmpProp, clsPropRO).LineItemNo.ToString()
            Dim strOrderNo As String = CType(tmpProp, clsPropRO).ReleasingOrderNo.ToString
            Dim strEquipType As String = CType(tmpProp, clsPropRO).EquipmentType.Replace("'", "\'").ToString
            Dim strTruckerName As String = CType(tmpProp, clsPropRO).TruckerName
            intTrxNo = hidTrxNo.Value
            'Popupmenu
            If intTrxNo > 0 Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu('" + intLineItemNo + "#" + txtRIN.Text + "#" + intTrxNo.ToString + "','" + strOrderNo + "');return false;")
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
                If strFun = "1002" Then
                    If strFieldName.ToLower = "shippercode" Then
                        e.Row.Cells(i + 1).Style.Add("display", "none")
                    End If
                    If strFieldName.ToLower = "shippername" Then
                        e.Row.Cells(i + 1).Style.Add("display", "none")
                    End If
                End If
                If strFieldName.ToLower = "containerlist" Then
                    e.Row.Cells(i + 1).Text = strContainerList
                End If
                If strFieldName.ToLower = "intcontainerno" Then
                    e.Row.Cells(i + 1).Text = ReleaseQty
                End If

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
                e.Row.Attributes.Add("ondblclick", "OpReleaseContainer(" + intLineItemNo + "," + intTrxNo.ToString + ",'" + strOrderNo + "','" + strEquipType + "','" + strTruckerName + "');return false;")
            Else
                If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                    imgEdit.Attributes.Add("OnClick", "EditDetail(" + intLineItemNo + ",'" + strContainerList + "','" + txtRIN.Text + "'," + intTrxNo.ToString + ");return false;")
                    e.Row.Attributes.Add("ondblclick", "EditDetail(" + intLineItemNo + ",'" + strContainerList + "','" + txtRIN.Text + "'," + intTrxNo.ToString + ");return false;")
                Else
                    imgEdit.Visible = False
                End If
            End If
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
    Public Sub CreateRIN()
        Dim strDate As String = Now.Date.ToString("dd/MM/yyyy")
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            'CreateOrderNo
            If strDate <> "" Then
                Dim dtReclzw As DataTable
                dtReclzw = BaseSelectSrvr.GetData("select top 1 TrxNo, Cycle,Prefix,NextNo ,Suffix from sanm1 " & _
                           "where NumberType  like '%CTRI%'", "")
                If dtReclzw.Rows.Count > 0 Then
                    Dim fiePrefix As Object = ReturnfiePrefix(dtReclzw.Rows(0)("Prefix").ToString)
                    Dim fieNextNo As Object = ReturnNextNo(dtReclzw.Rows(0)("TrxNo").ToString, dtReclzw.Rows(0)("NextNo").ToString, dtReclzw.Rows(0)("Cycle").ToString)
                    Dim fieSuffix As Object = ReturnfieSuffix(dtReclzw.Rows(0)("Suffix").ToString)
                    txtRIN.Text = fiePrefix + fieNextNo + fieSuffix
                End If
            End If
        End If
    End Sub
#End Region
End Class