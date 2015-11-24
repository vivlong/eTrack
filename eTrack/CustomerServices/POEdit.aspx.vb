Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.VisualBasic.CompilerServices
Imports SysMagic
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Partial Class POEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objServer As clsPO
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strTitle As String = ""

    'Dim objExport As ExportToExcel.ExcelExpor
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub 
    Private intTrxNo As Int64 = ConClass.NewIdValue
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsPO(intUserId)
    End Function
    Public Function NewServerObject(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsPO(strUserId, RoleName, strFunNo)
    End Function
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fldId.Value = -1
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                fldId.Value = intTrxNo
                divTop.Style.Add("display", "none")
                divMiddle1.Style.Add("display", "block")
                divPartialPO.Style.Add("display", "block")
                BindCurrency()
                BindDetailData(objUser.UserId, intTrxNo)
                BindAttach(objUser.UserId, intTrxNo)
                'bylin
                Dim strFunNo As String = (PageFun.GetFunNo(Page)).ToString
                Session("FunNo") = strFunNo
                'New Object 
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                If Session("LoginType") = 0 Then
                    objList.DeletePrivilege = True
                    objList.EditPrivilege = True
                    objList.NewPrivilege = True
                    objList.PrintPrivilege = True
                End If
                objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
                objList.Where = " and TrxNo= " + intTrxNo.ToString
                ''Assign Page Event and Relative Value
                lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
                lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
                lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
                lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
                lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
                txtPage.Text = intPageIndex.ToString()
                txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
                txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
                'Get First Page Data
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                HandlePopupMenu()
                HandleLanguageRelative()
                btnSave.Attributes.Add("OnClick", "SavePODetail('" + objServer.Title + "',2);return false;")
                btnRequestionDate.Attributes.Add("OnClick", "showCalendar(txtRequestionDate,0);return false;")
                btnReceivedDate.Attributes.Add("OnClick", "showCalendar(txtReceivedDate,0);return false;")
                btnShipDateInfo.Attributes.Add("OnClick", "showCalendar(txtShipDate,0);return false;")
                btnIssueDateInfo.Attributes.Add("OnClick", "showCalendar(txtIssueDate2,0);return false;")

                btnETD2.Attributes.Add("OnClick", "showCalendar(txtETD2,0);return false;")
                btnETA2.Attributes.Add("OnClick", "showCalendar(txtETA2,0);return false;")
                btnRequiredDate2.Attributes.Add("OnClick", "showCalendar(txtRequiredDate2,0);return false;")

                KeydownInfoEvent()
                divDate.Style.Add("display", "none")
                txtSupplierAdderss.Attributes.Add("onkeypress", "textCounter(event," + txtSupplierAdderss.ClientID + ",45)")
                txtDescription1.Attributes.Add("onkeypress", "textCounter(event," + txtDescription1.ClientID + ",80)")
                txtSupplierAdderss.Attributes.Add("onkeypress", "textCounter(event," + txtSupplierAdderss.ClientID + ",45)")
                txtShipToAddress.Attributes.Add("onkeypress", "textCounter(event," + txtShipToAddress.ClientID + ",405)")
                btnPortOfLoading2.Attributes.Add("OnClick", "selBindCode(" + txtPortOfLoading2.ClientID + ",'rcsp1','PortCode,PortName','','PortOfLoading Code','PortOfLoading Name');return false;")
                btnPortOfDischarge2.Attributes.Add("OnClick", "selBindCode(" + txtPortOfDischarge2.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
                txtPortOfLoading2.Attributes.Add("onchange", "valiString('" + txtPortOfLoading2.ClientID + "','Port Of Loading Code.','PortCode','rcsp1','');")
                txtPortOfDischarge2.Attributes.Add("onchange", "valiString('" + txtPortOfDischarge2.ClientID + "','Port Of Discharge Code1.','PortCode','rcsp1','');")

            Else
                divTopNav.Style.Add("display", "none")
                SetInitValue(objUser.UserId)
                KeydownEvent()
                'Bind The All Detail
                txtDescription.Attributes.Add("onkeypress", "textCounter(event," + txtDescription.ClientID + ",80)")
                drSupplier.Attributes.Add("onchange", "SupplierSelect(" + drSupplier.ClientID + ")")
                btnIssueDate.Attributes.Add("OnClick", "showCalendar(txtIssueDate,0);return false;")
                chkShipTo.Attributes.Add("onclick", "setDefaultShipTo(" + chkShipTo.ClientID + ");")
                btnSave.Attributes.Add("OnClick", "SavePODetail('" + objServer.Title + "',1);return false;")
                txtPurchaseOrderAmount.Attributes.Add("OnKeyPress", "NumberInput(event,2);")
                btnPortOfLoading.Attributes.Add("OnClick", "selBindCode(" + txtPortOfLoading.ClientID + ",'rcsp1','PortCode,PortName','','PortOfLoading Code','PortOfLoading Name');return false;")
                btnPortOfDischarge.Attributes.Add("OnClick", "selBindCode(" + txtPortOfDischarge.ClientID + ",'rcsp1','PortCode,PortName','','Port Code','Port Name');return false;")
                txtPortOfLoading.Attributes.Add("onchange", "valiString('" + txtPortOfLoading2.ClientID + "','Port Of Loading Code.','PortCode','rcsp1','');")
                txtPortOfDischarge.Attributes.Add("onchange", "valiString('" + txtPortOfDischarge2.ClientID + "','Port Of Discharge Code1.','PortCode','rcsp1','');")
                btnETD.Attributes.Add("OnClick", "showCalendar(txtETD,0);return false;")
                btnETA.Attributes.Add("OnClick", "showCalendar(txtETA,0);return false;")
                btnRequiredDate.Attributes.Add("OnClick", "showCalendar(txtRequiredDate,0);return false;")

            End If

            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            drCountry.Attributes.Add("onchange", "SetCity(" + drCity.ClientID + "," + drCountry.ClientID + ");return false;")
            'drCountry1.Attributes.Add("onchange", "SetCity(" + drCity1.ClientID + "," + drCountry1.ClientID + ");return false;")

            ' drCity.Attributes.Add("onchange", "SetCountry(" + drCity.ClientID + "," + drCountry.ClientID + ");return false;")
            '  drCity1.Attributes.Add("onchange", "SetCountry(" + drCity1.ClientID + "," + drCountry1.ClientID + ");return false;")

        End If
    End Sub
    Private Sub BindCurrency()
        Dim dt As DataTable
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        dt = BaseSelectSrvr.GetData("select currcode,currdescription,* from glex1 where statuscode='use' order by currdescription ", "")
        If dt.Rows.Count > 0 Then
            drPOCurrCode.DataSource = dt
            drPOCurrCode.DataValueField = "currcode"
            drPOCurrCode.DataTextField = "currcode"
            drPOCurrCode.DataBind()
            drPOCurrCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select deliveryType,DeliveryTypeName from rcdl1 where StatusCOde='USE' and isnull(DeliveryTypeName,'')!='' order by DeliveryTypeName ", "")
        If dt.Rows.Count > 0 Then
            drIncoterms2.DataSource = dt
            drIncoterms2.DataValueField = "deliveryType"
            drIncoterms2.DataTextField = "deliveryType"
            drIncoterms2.DataBind()
            drIncoterms2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select CityCode,CityName from rcct1 where statuscode='use' order by CityName ", "")
        If dt.Rows.Count > 0 Then
            drTermCity2.DataSource = dt
            drTermCity2.DataValueField = "CityCode"
            drTermCity2.DataTextField = "CityCode"
            drTermCity2.DataBind()
            drTermCity2.Items.Insert(0, New ListItem(ListItemSelect, ""))
            dt.Clear()
        End If
    End Sub
    'Bind DrowDownList Init for New
    Private Sub SetInitValue(ByVal intUserId As String)
        'control number
        txtPurchaseOrderAmount.Attributes.Add("OnKeypress", "NumberInput(0);")
        objServer = NewServerObject(intUserId)
        Me.Title = "New Purchase Order Information"
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Country
        Dim dt As DataTable
        dt = BaseSelectSrvr.GetData("select CountryCode,CountryName from rccy1 where statuscode='USE' order by CountryName ", "")
        If dt.Rows.Count > 0 Then
            '1
            drCountry.DataSource = dt
            drCountry.DataValueField = "CountryCode"
            drCountry.DataTextField = "CountryName"
            drCountry.DataBind()
            drCountry.Items.Insert(0, New ListItem(ListItemSelect, ""))
            '2
            drCountry1.DataSource = dt
            drCountry1.DataValueField = "CountryCode"
            drCountry1.DataTextField = "CountryName"
            drCountry1.DataBind()
            drCountry1.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select CityCode,CityName from rcct1 where statuscode='use' order by CityName ", "")
        If dt.Rows.Count > 0 Then
            'drCity.DataSource = dt
            'drCity.DataValueField = "CityCode"
            'drCity.DataTextField = "CityName"
            'drCity.DataBind()
            'drCity.Items.Insert(0, New ListItem(ListItemSelect, ""))

            drCity1.DataSource = dt
            drCity1.DataValueField = "CityCode"
            drCity1.DataTextField = "CityName"
            drCity1.DataBind()
            drCity1.Items.Insert(0, New ListItem(ListItemSelect, ""))

            drTermCity.DataSource = dt
            drTermCity.DataValueField = "CityCode"
            drTermCity.DataTextField = "CityCode"
            drTermCity.DataBind()
            drTermCity.Items.Insert(0, New ListItem(ListItemSelect, ""))
            dt.Clear()
        End If
        dt = BaseSelectSrvr.GetData("select currcode,currdescription,* from glex1 where statuscode='use' order by currdescription ", "")
        If dt.Rows.Count > 0 Then
            drCurrency.DataSource = dt
            drCurrency.DataValueField = "currcode"
            drCurrency.DataTextField = "currdescription"
            drCurrency.DataBind()
            drCurrency.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If

        dt = BaseSelectSrvr.GetData("select BusinessPartyCode from Rcbp1 where statuscode='use'  and isnull(BusinessPartyCode,'')<>''order by BusinessPartyCode ", "")
        If dt.Rows.Count > 0 Then
            drSupplier.DataSource = dt
            drSupplier.DataValueField = "BusinessPartyCode"
            drSupplier.DataTextField = "BusinessPartyCode"
            drSupplier.DataBind()
            drSupplier.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select deliveryType,DeliveryTypeName from rcdl1 where StatusCOde='USE' and isnull(DeliveryTypeName,'')!='' order by DeliveryTypeName ", "")
        If dt.Rows.Count > 0 Then
            drIncoTerms.DataSource = dt
            drIncoTerms.DataValueField = "deliveryType"
            drIncoTerms.DataTextField = "DeliveryTypeName"
            drIncoTerms.DataBind()
            drIncoTerms.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        drModeofTransport.Items.Insert(0, New ListItem("Air", "Air"))
        drModeofTransport.Items.Insert(1, New ListItem("Sea", "Sea"))
        drModeofTransport.Items.Insert(2, New ListItem("Road", "Road"))
        drModeofTransport.Items.Insert(2, New ListItem("Rail", "Rail"))
        'bind default ship to 
        dt = BaseSelectSrvr.GetData("select top 1 CompanyName,CountryCode,Fax,ContactName,Address1,Address2,Address3,Address4,CityCode,PostalCode,Telephone,Email,ContactName from saco1 ", "")
        If dt.Rows.Count > 0 Then
            Dim sb As New StringBuilder
            sb.Append("<script language =""javascript"" type=""text/javascript"">")
            sb.Append(" var strCompanyName='" + dt.Rows(0)("CompanyName").ToString.Trim + "';")
            sb.Append(" var strLastName='';")
            sb.Append(" var strAddress1='" + dt.Rows(0)("Address1").ToString.Trim + "';")
            sb.Append(" var strAddress2='" + dt.Rows(0)("Address2").ToString.Trim + "';")
            sb.Append(" var strAddress3='" + dt.Rows(0)("Address3").ToString.Trim + "';")
            sb.Append(" var strAddress4='" + dt.Rows(0)("Address4").ToString.Trim + "';")
            sb.Append(" var strState='';")
            sb.Append(" var strCountry='" + dt.Rows(0)("CountryCode").ToString.Trim + "';")
            sb.Append(" var strFax='" + dt.Rows(0)("Fax").ToString.Trim + "';")
            sb.Append(" var strFirstName='" + dt.Rows(0)("ContactName").ToString.Trim + "';")
            sb.Append(" var strAddress='" + dt.Rows(0)("Address1").ToString.Trim + "';")
            sb.Append(" var strCity='" + dt.Rows(0)("CityCode").ToString.Trim + "';")
            sb.Append(" var strPostalCode='" + dt.Rows(0)("PostalCode").ToString.Trim + "';")
            sb.Append(" var strPhone='" + dt.Rows(0)("Telephone").ToString.Trim + "';")
            sb.Append(" var strEmailAddress='" + dt.Rows(0)("Email").ToString.Trim + "';")
            sb.Append(" var strContactName='" + dt.Rows(0)("ContactName").ToString.Trim + "';")
            sb.Append("</script>")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", sb.ToString)
        End If
        dt.Clear()
    End Sub
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#End Region
#Region "Add PO"
    Private Sub KeydownEvent()
        'ShipToInformation
        setFocusControl(txtCompanyName, txtEmailAddress)
        setFocusControl(txtEmailAddress, txtFirstName)
        setFocusControl(txtFirstName, txtLastName)
        setFocusControl(txtLastName, txtAddress)
        setFocusControl(txtAddress, txtAddress2)
        setFocusControl(txtAddress2, drCountry)
        setFocusControl(drCountry, txtState)
        setFocusControl(txtState, txtPostalCode)
        setFocusControl(txtPostalCode, drCity)
        setFocusControl(drCity, txtPhone)
        setFocusControl(txtPhone, txtFax)
        setFocusControl(txtFax, txtPurchaseOrderNumber)
        'PO Information
        setFocusControl(txtPurchaseOrderNumber, txtPurchaseOrderAmount)
        setFocusControl(txtPurchaseOrderAmount, drCurrency)
        setFocusControl(drCurrency, txtIssueDate)
        setFocusControl(txtIssueDate, drIncoTerms)
        setFocusControl(drIncoTerms, drTermCity)
        setFocusControl(drTermCity, drModeofTransport)
        setFocusControl(drModeofTransport, drSupplier)
        setFocusControl(drSupplier, txtInvoiceNumber)
        'setFocusControl(txtInvoiceNumber, txtDescription)
        setFocusControl(txtInvoiceNumber, Me.txtPortOfLoading)
        setFocusControl(txtPortOfLoading, Me.txtPortOfDischarge)
        setFocusControl(txtPortOfDischarge, Me.txtShipToName)
        setFocusControl(txtShipToName, Me.txtShipToAddress1)
        setFocusControl(txtShipToAddress1, Me.txtShipToAddress2)
        setFocusControl(txtShipToAddress2, Me.txtShipToAddress3)
        setFocusControl(txtShipToAddress3, Me.txtShipToAddress4)
        setFocusControl(txtShipToAddress4, Me.txtShipToEmail)
        setFocusControl(txtShipToEmail, Me.txtShipToPhone2)
        setFocusControl(txtShipToPhone2, Me.txtShipToFax2)
        setFocusControl(txtShipToFax2, Me.txtContactPerson)
        setFocusControl(txtContactPerson, Me.txtDescription)
        'Default ShipToInformation
        setFocusControl(txtCompanyName1, txtFirstName1)
        setFocusControl(txtFirstName1, txtLastName1)
        setFocusControl(txtLastName1, txtAddress1)
        setFocusControl(txtAddress1, txtAddress21)
        setFocusControl(txtAddress21, drCity1)
        setFocusControl(drCity1, txtState1)
        setFocusControl(txtState1, txtPostalCode1)
        setFocusControl(txtPostalCode1, drCountry1)
        setFocusControl(drCountry1, txtPhone1)
        setFocusControl(txtPhone1, txtFax1)
        setFocusControl(txtFax1, txtEmailAddress1)
        'setFocusControl(txtEmailAddress1, txtDescription)
        setFocusControl(txtEmailAddress1, txtPortOfLoading)

        'First Focus Control
        Me.Title = "New PO Information"
        txtCompanyName.Focus()
    End Sub
    Private Sub KeydownInfoEvent()
        'ShipToInformation
        setFocusControl(txtValue, drPOCurrCode)
        setFocusControl(drPOCurrCode, txtIssueDate2)
        setFocusControl(txtIssueDate2, drIncoterms2)
        setFocusControl(drIncoterms2, drTermCity2)
        setFocusControl(drTermCity2, txtShipDate)
        setFocusControl(txtShipDate, drStatus)
        'setFocusControl(drStatus, txtDescription1)
        setFocusControl(drStatus, Me.txtPortOfLoading2)
        setFocusControl(txtPortOfLoading2, Me.txtPortOfDischarge2)
        setFocusControl(txtPortOfDischarge2, Me.txtDescription1)
        'setFocusControl(txtRequestionDate, txtDescription1)
        'setFocusControl(txtDescription1, txtReceivedDate)
        'setFocusControl(txtReceivedDate, txtVendorReceivedDate)
        'PO Information
        setFocusControl(txtSupplierCompanyName, txtSupplierEmail)
        setFocusControl(txtSupplierEmail, txtSupplierAdderss)
        setFocusControl(txtSupplierAdderss, txtSupplierPhone)
        setFocusControl(txtSupplierPhone, txtSupplierFax)
        'Default ShipToInformation
        setFocusControl(txtShipToCompany, txtEmail)
        setFocusControl(txtEmail, txtShipToAddress)
        setFocusControl(txtShipToAddress, txtShipToPhone)
        setFocusControl(txtShipToPhone, txtShipToFax)
        'First Focus Control
        txtCompanyName.Focus()
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Public Function SetInvoiceFocus(ByVal strFlag As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strFlag.Trim <> "" Then
                If strFlag = "1" Then
                    setFocusControl(txtInvoiceNumber, txtCompanyName1)
                Else
                    setFocusControl(txtInvoiceNumber, txtDescription)
                End If
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(txtInvoiceNumber)
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function SetdrCountry(ByVal strCity As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strCity.Trim <> "" Then
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData("select CountryCode from rcct1 where CityCode='" + (strCity) + "'", "")
                If dt.Rows.Count > 0 Then
                    Dim strCountry As String
                    strCountry = dt.Rows(0)("CountryCode").ToString
             
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strCountry
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function SetdrCity(ByVal strCountry As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strCountry.Trim <> "" Then
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData("select CityCode,CityName from rcct1 where statuscode='use' and CountryCode='" + strCountry + "' order by CityName ", "")
                If dt.Rows.Count > 0 Then
                    Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
                    drCity.DataSource = dt
                    drCity.DataValueField = "CityCode"
                    drCity.DataTextField = "CityName"
                    drCity.DataBind()
                    drCity.Items.Insert(0, New ListItem(ListItemSelect, ""))
                    Dim table As String = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        table += "@" + dt.Rows(i)("CityCode") + "|" + dt.Rows(i)("CityName")
                    Next
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + table 'GridViewFun.RenderControl(drCity)
                Else
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + " "
                End If
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function GetSupplierInfo(ByVal strSupplierCode As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strSupplierCode.Trim <> "" Then
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData("select BusinessPartyName,BusinessPartyCode,Address1,Address2,CityCOde,PostalCode,CountryCode,Telephone,Fax,Email from Rcbp1 where BusinessPartyCode='" + strSupplierCode + "'", "")
                If dt.Rows.Count > 0 Then
                    Dim sb As New StringBuilder
                    sb.Append(dt.Rows(0)("BusinessPartyName").ToString + ",")
                    sb.Append(dt.Rows(0)("BusinessPartyCode").ToString + ",")
                    sb.Append(dt.Rows(0)("BusinessPartyCode").ToString + ",")
                    sb.Append(dt.Rows(0)("Address1").ToString + ",")
                    sb.Append(dt.Rows(0)("Address2").ToString + ",")
                    sb.Append(dt.Rows(0)("CityCode").ToString + ",")
                    sb.Append(dt.Rows(0)("CityCode").ToString + ",")
                    sb.Append(dt.Rows(0)("PostalCode").ToString + ",")
                    sb.Append(dt.Rows(0)("CountryCode").ToString + ",")
                    sb.Append(dt.Rows(0)("Telephone").ToString + ",")
                    sb.Append(dt.Rows(0)("Fax").ToString + ",")
                    sb.Append(dt.Rows(0)("Email").ToString + ",")
                    hidSupplier.Value = sb.ToString
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(hidSupplier)
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function SaveData(ByVal strValue As String) As String
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
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As String)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropPO = objServer.GetDetail(intTrxNo)
            If tmpProp.TrxNo > 0 Then
                intTrxNo = GetNewId()
                fldId.Value = tmpProp.TrxNo.ToString()
                'PO info
                drStatus.Items.Insert(0, New ListItem("All", "All"))
                drStatus.Items.Insert(1, New ListItem("Closed", "Closed"))
                drStatus.Items.Insert(2, New ListItem("Draft", "Draft"))
                drStatus.Items.Insert(3, New ListItem("Open", "Open"))
                If tmpProp.PartialPOFlag = "Y" Then
                    drStatus.Items.Insert(4, New ListItem("Partial-Shipped", "Partial-Shipped"))
                Else
                    drStatus.Items.Insert(4, New ListItem("Shipped", "Shipped"))
                End If
                txtValue.Text = tmpProp.POAmt
                drPOCurrCode.Text = tmpProp.POCurrCode
                drIncoterms2.SelectedValue = tmpProp.IncoTerm
                drStatus.Text = tmpProp.POStatus
                txtDescription1.Text = tmpProp.PODescription
                ConvertDate(txtIssueDate2, tmpProp.POIssueDate)
                ConvertDate(txtShipDate, tmpProp.DeliveryDate)
                drTermCity2.SelectedValue = tmpProp.IncoTermCity
                txtPortOfLoading2.Text = tmpProp.PortOfLoadingCode
                txtPortOfDischarge2.text = tmpProp.PortOfDischargeCode
                'Supplier Info'
                txtSupplierCompanyName.Text = tmpProp.SupplierName
                txtSupplierEmail.Text = tmpProp.SupplierEmail
                txtSupplierAdderss.Text = tmpProp.SupplierAddr1
                txtSupplierPhone.Text = tmpProp.SupplierPhone
                txtSupplierFax.Text = tmpProp.SupplierFax
                'Ship To info
                'txtEmail.Text = tmpProp.Email
                'txtShipToCompany.Text = tmpProp.CompanyName
                'txtShipToAddress.Text = tmpProp.Address1
                'txtShipToPhone.Text = tmpProp.Phone
                'txtShipToFax.Text = tmpProp.Fax
                txtEmail.Text = tmpProp.ShipToEmail
                txtShipToCompany.Text = tmpProp.ShipToName
                txtShipToAddress.Text = tmpProp.ShipToAddress
                txtShipToPhone.Text = tmpProp.ShipToPhone
                txtShipToFax.Text = tmpProp.ShipToFax
                ConvertDate(txtETD2, tmpProp.ETD)
                ConvertDate(txtETA2, tmpProp.ETA)
                ConvertDate(txtRequiredDate2, tmpProp.RequiredDate)
                If tmpProp.PartialPOFlag = "N" Then
                    Me.Title = "Purchase No: " + tmpProp.PONo + " (Complete Ship)"
                Else
                    Me.Title = "Purchase No: " + tmpProp.PONo + " (Partial Ship)"
                End If
            Else
                Me.Title = "Purchase No " + tmpProp.PONo
            End If
        End If
    End Sub
#End Region
#Region "Second Tab"
#End Region
#Region "Forth Tab Download"
    Public Function AddSelectedAttach(ByVal strNo As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            BindAttach(objUser.UserId, intTrxNo)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If

    End Function
    Public Function DeleteOneAttach(ByVal strNo As String, ByVal strFileName As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            Dim strAttachPath As String = Server.MapPath("../Doc/Popo1/" + intTrxNo.ToString() + "/")
            If clsAttachFileDirectory.DeleteFile(strAttachPath + Server.HtmlDecode(strFileName)) Then
                BindAttach(objUser.UserId, intTrxNo)
                gvwAttach.DataSource = objAttach.ArrProp
                If objAttach.ArrProp.Count > 1 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
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
        objAttach.GetListInfo(Server.MapPath("../Doc/Popo1/" + intTrxNo.ToString() + "/"), "Popo1")
        gvwAttach.DataSource = objAttach.ArrProp
        gvwAttach.DataBind()
    End Sub
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim tmpPOAttach As clsPropAttach = CType(objAttach.ArrProp(e.Row.RowIndex), clsPropAttach)
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objAttach.Count - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneAttach(""" + Server.HtmlEncode(tmpPOAttach.FileName) + """);return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objAttach.Count - 1 Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedAttach();return false;")
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            Else
                imgInsert.Visible = False
            End If
        End If
    End Sub
#End Region
#Region "LineItem PO"
    Dim popo2Sum As Decimal = 0
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        If Session("LoginType") = 0 Then
            'objList.Where += "  and customercode='" + objUser.UserId + "' "
            objList.DeletePrivilege = True
            objList.EditPrivilege = True
            objList.NewPrivilege = True
        End If
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Popo2", gvwSource, TemplateType.ListPrint, intUserId, "") 'Session("LoginType").ToString
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        popo2Sum = 0
        For i As Integer = 0 To objList.ArrProp.Count - 1
            popo2Sum += objList.ArrProp(i).Sum
        Next
        Me.txtGrandTotal.Text = popo2Sum.ToString
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsLineItemPO(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Popo2"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.Header Then
            For i = 0 To objColumns.Column.Count - 1
                e.Row.Cells(i).Style.Add("word-wrap", "break-word")
            Next
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            'KeyValue 
            Dim intLineItemNo As String = "-1"
            intTrxNo = CType(tmpProp, clsPropLineItemPO).TrxNo
            intLineItemNo = CType(tmpProp, clsPropLineItemPO).LineItemNo
            Dim decSum As Decimal = CType(tmpProp, clsPropLineItemPO).Sum

            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        strFieldName = _ColumnInfo.FieldName
                        If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                            Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                            If dtmTemp <= ConDateTime.MinDate Then
                                e.Row.Cells(i + 1).Text = ""
                            Else
                                e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                            End If
                        End If
                    Case DbType.Date, DbType.Decimal
                        strFieldName = _ColumnInfo.FieldName
                        Dim str As String = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If str <> "" Then
                            Dim dtmTemp As Decimal = Decimal.Parse(str)
                            Dim strWt As Decimal = Decimal.Round(dtmTemp, 3)
                            If strWt <> 0.0 Then
                                e.Row.Cells(i + 1).Text = strWt
                            Else
                                e.Row.Cells(i + 1).Text = ""
                            End If
                        End If
                End Select
                'Trx No 
                If _ColumnInfo.FieldName = "TrxNo" Then
                    If intTrxNo = "" Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
            Next
            'Row(cann) 't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 Then
                imgDelete.Attributes.Add("OnClick", "DeletePOPO2(" + intTrxNo.ToString() + "," + intLineItemNo.ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 Then
                imgEdit.Attributes.Add("OnClick", "EditDetail(" + intTrxNo.ToString() + ",'" + Request("FunNo").ToString + "'," + intLineItemNo.ToString() + ");return false;")
                e.Row.Attributes.Add("ondblclick", "EditDetail(" + intTrxNo.ToString() + ",'" + Request("FunNo").ToString + "'," + intLineItemNo.ToString() + ");return false;")
            Else
                imgEdit.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail();return false;")
            Else
                imgInsert.Visible = False
            End If
            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            If (intTrxNo.ToString <> "") AndAlso objList.PrintPrivilege Then
                imgPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgPrint.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                imgDelete.Visible = False
                imgEdit.Visible = False
                imgPrint.Visible = False
                e.Row.Attributes.Remove("ondblclick")
            Else
                imgPrint.Visible = False
                imgInsert.Visible = False
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
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
        'Add Print MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""PrintDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "PrintRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
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
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub
#End Region
#Region "Edit PO"
    Function SavePOData(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo1 set ")
            sb.Append("POAmt=" + ConvertToInt(strRow(1)))
            sb.Append(",POCurrCode='" + strRow(2) + "'")
            sb.Append(",IncoTerm='" + strRow(3) + "'")
            sb.Append(",IncoTermCity='" + strRow(11) + "'")
            sb.Append(",POStatus='" + strRow(4) + "'")
            sb.Append(",PODescription='" + strRow(5) + "'")
            sb.Append(",POIssueDate='" + StringToDate(strRow(6)) + "'")
            sb.Append(",DeliveryDate='" + StringToDate(strRow(7)) + "'")
            sb.Append(",PortOfLoadingCode='" + strRow(12) + "'")
            sb.Append(",PortOfDischargeCode='" + strRow(13) + "'")
            sb.Append(",ETA='" + StringToDate(strRow(14)) + "'")
            sb.Append(",ETD='" + StringToDate(strRow(15)) + "'")
            sb.Append(",RequiredDate='" + StringToDate(strRow(16)) + "'")
            sb.Append(" where TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Function StringToDate(ByVal strDate As String) As String
        Dim strFormat As String = "dd/MM/yyyy"
        'Dim strFormat As String = "yyyy-MM-dd"
        Dim minDate As DateTime
        Dim provider As New CultureInfo("zh-cn", True)
        If (Operators.CompareString(strFormat, "", True) <> 0) Then
            provider.DateTimeFormat.ShortDatePattern = strFormat
        Else
            provider.DateTimeFormat.ShortDatePattern = ConDateTime.DateFormat
        End If
        If Not DateTime.TryParse(strDate, provider, DateTimeStyles.NoCurrentDateDefault, minDate) Then
            minDate = ConDateTime.MinDate
        End If
        Return minDate.ToString("MM/dd/yyyy")
    End Function
    Function SaveSupplierInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo1 set ")
            sb.Append("SupplierName='" + strRow(1) + "'")
            sb.Append(",SupplierAddr1='" + strRow(2) + "'")
            sb.Append(",SupplierPhone='" + strRow(3) + "'")
            sb.Append(",SupplierFax='" + strRow(4) + "'")
            sb.Append(",SupplierEmail='" + strRow(5) + "'")
            sb.Append(" where  TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Function SaveShipToInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            'sb.Append("update Popo1 set ")
            'sb.Append("CompanyName='" + strRow(1) + "'")
            'sb.Append(",Address1='" + strRow(2) + "'")
            'sb.Append(",Phone='" + strRow(3) + "'")
            'sb.Append(",Fax='" + strRow(4) + "'")
            'sb.Append(",Email='" + strRow(5) + "'")
            'sb.Append(" where  TrxNo=" + Request("Id").ToString())
         
            Dim arrAdd() As String = strRow(2).Split(Chr(10) + Chr(13))
            sb.Append("update Popo1 set ")
            sb.Append("ShipToName='" + strRow(1) + "'")
            If arrAdd.Length > 0 Then
                sb.Append(",ShipToAddress1='" + arrAdd(0).Substring(0, IIf(arrAdd(0).Length > 100, 100, arrAdd(0).Length)) + "'")
            End If
            If arrAdd.Length > 1 Then
                sb.Append(",ShipToAddress2='" + arrAdd(1).Substring(0, IIf(arrAdd(1).Length > 100, 100, arrAdd(1).Length)) + "'")
            End If
            If arrAdd.Length > 2 Then
                sb.Append(",ShipToAddress3='" + arrAdd(2).Substring(0, IIf(arrAdd(2).Length > 100, 100, arrAdd(2).Length)) + "'")
            End If
            If arrAdd.Length > 3 Then
                sb.Append(",ShipToAddress4='" + arrAdd(3).Substring(0, IIf(arrAdd(3).Length > 100, 100, arrAdd(3).Length)) + "'")
            End If
            sb.Append(",ShipToPhone='" + strRow(3) + "'")
            sb.Append(",ShipToFax='" + strRow(4) + "'")
            sb.Append(",ShipToEmail='" + strRow(5) + "'")
            sb.Append(" where  TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function ConvertToInt(ByVal strVal As String) As String
        If IsNumeric(strVal) Then
            Return strVal
        Else
            Return "null"
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
    Public Function DeletePOPO2(ByVal strTrxNo As String, ByVal strLineItemNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not FDeletePOPO2(strTrxNo, strLineItemNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function FDeletePOPO2(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete popo2 where TrxNo=" + strTrxNo + " and LineItemNo=" + strLineItemNo
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
                    objList.Where = " and TrxNo= " + strTrxNo.ToString
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
End Class
