Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class LineItemPOEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objPopo1 As clsPO
    Private objServer As clsLineItemPO
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
    Private intLineItemNo As Int64 = ConClass.NewIdValue
#Region "Inhead"
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsLineItemPO(intUserId)
    End Function
    Public Function NewServerObject(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsLineItemPO(strUserId, RoleName, strFunNo)
    End Function
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            fldId.Value = -1
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                intLineItemNo = Request("LineItemNo").ToString()
                fldLineItemNo.Value = Request("LineItemNo").ToString()
                fldId.Value = intTrxNo
                divTop.Style.Add("display", "none")
                divMiddle1.Style.Add("display", "block")
                divPartialPO.Style.Add("display", "block")
                SetInitValue1(objUser.UserId)
                BindDetailData(objUser.UserId, intTrxNo, intLineItemNo)
                BindAttach(objUser.UserId, intTrxNo.ToString + "#" + intLineItemNo.ToString)
                'bylin
                Dim strFunNo As String = (PageFun.GetFunNo(Page)).ToString
                '-----byRoot
                Session("FunNo") = strFunNo
                '-----End
                'New Object 
                objList = NewObjectList(objUser.UserId, objUser.RoleName, strFunNo)
                If Session("LoginType") = 0 Then
                    objList.DeletePrivilege = True
                    objList.EditPrivilege = True
                    objList.NewPrivilege = True
                End If
                objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
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
                btnSave.Attributes.Add("OnClick", "SaveLineItemPODetail('" + objServer.Title + "',2);return false;")
                btnDateRequested2.Attributes.Add("OnClick", "showCalendar(txtDateRequested2,0);return false;")
                btnLatestDeliveryDate2.Attributes.Add("OnClick", "showCalendar(txtLatestDeliveryDate2,0);return false;")
                btnDateRequiredatSite2.Attributes.Add("OnClick", "showCalendar(txtDateRequiredatSite2,0);return false;")
                btnEstimatedTimeofArrival2.Attributes.Add("OnClick", "showCalendar(txtEstimatedTimeofArrival2,0);return false;")
                KeydownInforEvent()
            Else
                If Not (Request("strPoTrxNo") Is Nothing) Then
                    fldPoTrxNo.Value = Request("strPoTrxNo").ToString
                End If
                getLineItemNo()
                divTopNav.Style.Add("display", "none")
                SetInitValue(objUser.UserId)
                KeydownEvent()
                'Bind The All Detail
                btnIssueDate.Attributes.Add("OnClick", "showCalendar(txtLastestDeliveryDate,0);return false;")
                btnDateRequested.Attributes.Add("OnClick", "showCalendar(txtDateRequested,0);return false;")
                btnSave.Attributes.Add("OnClick", "SaveLineItemPODetail('" + objServer.Title + "',1);return false;")
                txtDescription.Attributes.Add("onkeypress", "textCounter(event," + txtDescription.ClientID + ",80)")
            End If
            txtLineItemNumber.Enabled = False
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    'Bind DrowDownList Init for New
    Private Sub SetInitValue(ByVal intUserId As String)
        txtGrossWeight.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtNetWeight.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtUnitPrice.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtInsuranceValue.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtLength.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtWidth.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtHeight.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtWeight.Attributes.Add("OnKeypress", "NumberInput(event,2);")
        txtQuantity.Attributes.Add("OnKeypress", "NumberInput(event,2);")

        objServer = NewServerObject(intUserId)
        Me.Title = "New LineItem"
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Country
        Dim dt As DataTable
        dt = BaseSelectSrvr.GetData("select distinct ProductCode from impr1 where isnull(ProductCode,'')!='' order by ProductCode ", "")
        If dt.Rows.Count > 0 Then
            '1
            drPartNumber.DataSource = dt
            drPartNumber.DataValueField = "ProductCode"
            drPartNumber.DataTextField = "ProductCode"
            drPartNumber.DataBind()
            drPartNumber.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select distinct UomCode from Rcum1 where isnull(UomCode,'')!='' order by UomCode ", "")
        If dt.Rows.Count > 0 Then
            drWeight.DataSource = dt
            drWeight.DataValueField = "UomCode"
            drWeight.DataTextField = "UomCode"
            drWeight.DataBind()
            drWeight.Items.Insert(0, New ListItem(ListItemSelect, ""))

            drQuantity.DataSource = dt
            drQuantity.DataValueField = "UomCode"
            drQuantity.DataTextField = "UomCode"
            drQuantity.DataBind()
            drQuantity.Items.Insert(0, New ListItem(ListItemSelect, ""))

            drUnitofMeasurement.DataSource = dt
            drUnitofMeasurement.DataValueField = "UomCode"
            drUnitofMeasurement.DataTextField = "UomCode"
            drUnitofMeasurement.DataBind()
            drUnitofMeasurement.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select distinct CurrCOde,CurrDescription from glex1 where isnull(CurrCOde,'')!='' order by CurrDescription ", "")
        If dt.Rows.Count > 0 Then
            drCurrency.DataSource = dt
            drCurrency.DataValueField = "currcode"
            drCurrency.DataTextField = "currcode"
            drCurrency.DataBind()
            drCurrency.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        '
        drStatus.Items.Insert(0, New ListItem("On Order", "On Order"))
        drStatus.Items.Insert(0, New ListItem("Shipped", "Shipped"))
        drStatus.Items.Insert(0, New ListItem(ListItemSelect, ""))
        'drModeofTransport
        drModeofTransport.Items.Insert(0, New ListItem("Air", "Air"))
        drModeofTransport.Items.Insert(1, New ListItem("Sea", "Sea"))
        drModeofTransport.Items.Insert(2, New ListItem("Road", "Road"))
        drModeofTransport.Items.Insert(3, New ListItem("Rail", "Rail"))
        'bind default ship to 
        dt = BaseSelectSrvr.GetData("select top 1 CompanyName,Address1,CountryCode,Fax,ContactName,Address1,Address2,CityCode,PostalCode,Telephone,Email from saco1 ", "")
        If dt.Rows.Count > 0 Then
            Dim sb As New StringBuilder
            sb.Append("<script language =""javascript"" type=""text/javascript"">")
            sb.Append(" var strCompanyName='" + dt.Rows(0)("CompanyName").ToString.Trim + "';")
            sb.Append(" var strLastName='';")
            sb.Append(" var strAddress2='" + dt.Rows(0)("Address2").ToString.Trim + "';")
            sb.Append(" var strState='';")
            sb.Append(" var strCountry='" + dt.Rows(0)("CountryCode").ToString.Trim + "';")
            sb.Append(" var strFax='" + dt.Rows(0)("Fax").ToString.Trim + "';")
            sb.Append(" var strFirstName='" + dt.Rows(0)("ContactName").ToString.Trim + "';")
            sb.Append(" var strAddress='" + dt.Rows(0)("Address1").ToString.Trim + "';")
            sb.Append(" var strCity='" + dt.Rows(0)("CityCode").ToString.Trim + "';")
            sb.Append(" var strPostalCode='" + dt.Rows(0)("PostalCode").ToString.Trim + "';")
            sb.Append(" var strPhone='" + dt.Rows(0)("Telephone").ToString.Trim + "';")
            sb.Append(" var strEmailAddress='" + dt.Rows(0)("Email").ToString.Trim + "';")
            sb.Append("</script>")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", sb.ToString)
        End If
        'clear dt
        dt = Nothing
    End Sub
    Private Sub SetInitValue1(ByVal intUserId As String)
        objServer = NewServerObject(intUserId)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Country
        Dim dt As DataTable
        dt = BaseSelectSrvr.GetData("select distinct CurrCOde,CurrDescription from glex1 where isnull(CurrCOde,'')!='' order by CurrDescription ", "")
        If dt.Rows.Count > 0 Then
            drCurrency1.DataSource = dt
            drCurrency1.DataValueField = "currcode"
            drCurrency1.DataTextField = "currcode"
            drCurrency1.DataBind()
            drCurrency1.Items.Insert(0, New ListItem(ListItemSelect, -1))
        End If
        dt = BaseSelectSrvr.GetData("select CityCode,CityName from rcct1 where statuscode='use' order by CityName ", "")
        If dt.Rows.Count > 0 Then
            drCity2.DataSource = dt
            drCity2.DataValueField = "CityCode"
            drCity2.DataTextField = "CityName"
            drCity2.DataBind()
            drCity2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        dt = BaseSelectSrvr.GetData("select CountryCode,CountryName from rccy1 where statuscode='USE' order by CountryName ", "")
        If dt.Rows.Count > 0 Then
            drCountry2.DataSource = dt
            drCountry2.DataValueField = "CountryCode"
            drCountry2.DataTextField = "CountryName"
            drCountry2.DataBind()
            drCountry2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        drStatus2.Items.Insert(0, New ListItem("On Order", "On Order"))
        drStatus2.Items.Insert(0, New ListItem("Shipped", "Shipped"))
        drStatus2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        'clear dt
        dt = Nothing
    End Sub
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#End Region
#Region "Add LineItemPO"
    Private Sub getLineItemNo()
        Dim strPoTrxNo As String
        Dim dt As DataTable = BaseSelectSrvr.GetData("select max(LineItemNo) as LineItemNo from Popo2 where TrxNo=" + Request("strPoTrxNo").ToString(), "")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("LineItemNo").ToString <> "" Then
                strPoTrxNo = Integer.Parse(dt.Rows(0)("LineItemNo").ToString) + 1
            Else
                strPoTrxNo = "1"
            End If
        Else
            strPoTrxNo = "1"
        End If
        txtLineItemNumber.Text = strPoTrxNo
    End Sub
    Private Sub KeydownEvent()
        'Item Information
        setFocusControl(txtLineItemNumber, drPartNumber)
        setFocusControl(drPartNumber, txtPartDescription)
        setFocusControl(txtPartDescription, txtHarmonizeCode)
        setFocusControl(txtHarmonizeCode, txtHarmonizeDescription)
        setFocusControl(txtHarmonizeDescription, txtUnitPrice)
        setFocusControl(txtUnitPrice, drCurrency)
        setFocusControl(drCurrency, txtSupplierPartNumber)
        setFocusControl(txtSupplierPartNumber, txtQuantity)
        setFocusControl(txtQuantity, txtNetWeight)
        setFocusControl(txtNetWeight, txtGrossWeight)
        setFocusControl(txtGrossWeight, txtTagNumber)
        setFocusControl(txtTagNumber, txtInsuranceValue)
        ''Shipping Information
        setFocusControl(txtInsuranceValue, txtDateRequested)
        setFocusControl(txtDateRequested, txtLastestDeliveryDate)
        setFocusControl(txtLastestDeliveryDate, drModeofTransport)
        setFocusControl(drModeofTransport, drStatus)
        setFocusControl(drStatus, drUnitofMeasurement)
        'Package Information
        setFocusControl(drUnitofMeasurement, txtLength)
        setFocusControl(txtLength, txtWidth)
        setFocusControl(txtWidth, txtHeight)

        setFocusControl(txtHeight, txtWeight)
        setFocusControl(txtWeight, txtDescription)
        ''First Focus Control
        Me.Title = "New LineItem"
        txtLineItemNumber.Focus()
    End Sub
    Private Sub KeydownInforEvent()
        'Item Information
        setFocusControl(txtPartNumber2, txtTagNumber2)
        setFocusControl(txtTagNumber2, txtItemDescription1)
        setFocusControl(txtItemDescription1, txtQuatityOrdered2)
        setFocusControl(txtQuatityOrdered2, txtSupplierPartNumber2)
        setFocusControl(txtSupplierPartNumber2, txtUnitPrice2)
        setFocusControl(txtUnitPrice2, drCurrency1)
        setFocusControl(drCurrency1, txtUnitPrice2)
        setFocusControl(txtUnitPrice2, txtHarmonizedCode2)
        setFocusControl(txtHarmonizedCode2, txtDescription2)
        'setFocusControl(txtDescription2, rbHazardous1)
        ''Shipping Information
        setFocusControl(txtInsuranceValue2, txtDateRequested2)
        setFocusControl(txtDateRequested2, txtLatestDeliveryDate2)
        setFocusControl(txtLatestDeliveryDate2, drStatus2)

        'setFocusControl(txtLatestDeliveryDate2, txtDateRequiredatSite2)
        'setFocusControl(txtDateRequiredatSite2, txtEstimatedTimeofArrival2)
        'setFocusControl(txtEstimatedTimeofArrival2, drStatus2)
        'Package Information
        setFocusControl(txtUnitofMeasurement2, txtLength2)
        setFocusControl(txtLength2, txtWidth2)
        setFocusControl(txtWidth2, txtHeight2)
        setFocusControl(txtHeight2, txtWeight2)
        ''Shipped To Information
        setFocusControl(txtCompanyName2, txtName2)
        setFocusControl(txtName2, txtAddress1)
        setFocusControl(txtAddress1, txtAddress2)
        setFocusControl(txtAddress2, drCity2)
        setFocusControl(drCity2, txtState2)
        setFocusControl(txtState2, txtPostal2)
        setFocusControl(txtPostal2, drCountry2)
        setFocusControl(drCountry2, txtPhone2)
        setFocusControl(txtPhone2, txtFax2)
        setFocusControl(txtFax2, txtEmail)
        ''First Focus Control
        Me.Title = "New LineItem"
        txtLineItemNumber.Focus()
    End Sub

    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
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
    Private Sub ConvertDateTime(ByRef con As TextBox, ByVal strVal As DateTime)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As String, ByVal IntLineItem As String)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropLineItemPO = objServer.GetDetail(intTrxNo, IntLineItem)
            objPopo1 = New clsPO(intUserId)
            Dim tmpPropPopo1 As clsPropPO = objPopo1.GetDetail(intTrxNo)
            If tmpProp.TrxNo > 0 Then
                intTrxNo = GetNewId()
                fldId.Value = tmpProp.TrxNo.ToString()
                'Item Info
                txtPartNumber2.Text = tmpProp.PartNo
                txtItemDescription1.Text = tmpProp.PartDesc
                txtSupplierPartNumber2.Text = tmpProp.SupplierPartNo
                drCurrency1.SelectedValue = tmpProp.CurrCode
                txtUnitPrice2.Text = tmpProp.UnitPrice
                txtHarmonizedCode2.Text = tmpProp.HarmonizeCode
                txtDescription2.Text = tmpProp.HarmonizeDesc
                rbHazardous1.SelectedValue = tmpProp.HazardousFlag
                txtTagNumber2.Text = tmpProp.TagNo
                txtQuatityOrdered2.Text = tmpProp.QtyOrdered
                'Shipping Info
                txtInsuranceValue2.Text = tmpProp.InsuranceValue
                ConvertDate(txtDateRequested2, tmpProp.DateRequested)
                ConvertDate(txtLatestDeliveryDate2, tmpProp.LatestDeliveryDate)
                ConvertDate(txtDateRequiredatSite2, tmpProp.DateRequestedAtSite)
                ConvertDate(txtEstimatedTimeofArrival2, tmpProp.TimeOfArrival)
                drStatus2.SelectedValue = tmpProp.ShippingStatus
                'Package info
                txtUnitofMeasurement2.Text = tmpProp.UOM
                txtLength2.Text = tmpProp.Length
                txtWidth2.Text = tmpProp.Width
                txtHeight2.Text = tmpProp.Height
                txtWeight2.Text = tmpProp.Width
                'Ship to Info
                txtCompanyName2.Text = tmpPropPopo1.CompanyName
                txtName2.Text = tmpPropPopo1.ContactFirstName
                txtAddress1.Text = tmpPropPopo1.Address1
                txtAddress2.Text = tmpPropPopo1.Address2
                drCity2.SelectedValue = tmpPropPopo1.City
                txtState2.Text = tmpPropPopo1.State
                txtPostal2.Text = tmpPropPopo1.PostalCode
                drCountry2.SelectedValue = tmpPropPopo1.Country
                txtPhone2.Text = tmpPropPopo1.Phone
                txtFax2.Text = tmpPropPopo1.Fax
                txtEmail.Text = tmpPropPopo1.Email
                Me.Title = "Purchase No " + tmpProp.TrxNo.ToString
            Else
                Me.Title = "Purchase No " + tmpProp.TrxNo.ToString
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
            BindAttach(objUser.UserId, strNo)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function DeleteOneAttach(ByVal strNo As String, ByVal strFileName As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strAttachPath As String = Server.MapPath("../Doc/Popo2/" + strNo + "/")
            If clsAttachFileDirectory.DeleteFile(strAttachPath + Server.HtmlDecode(strFileName)) Then
                BindAttach(objUser.UserId, strNo)
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
    Private Sub BindAttach(ByVal strUserId As String, ByVal strTrxNo As String)
        objAttach = New clsAttach(strUserId, strTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Doc/Popo2/" + strTrxNo + "/"), "Popo2")
        gvwAttach.DataSource = objAttach.ArrProp
        gvwAttach.DataBind()
    End Sub
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Attributes.Remove("oncontextmenu")
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
            If e.Row.RowIndex < objAttach.Count - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneAttach(""" + Server.HtmlEncode(tmpBookingAttach.FileName) + """);return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objAttach.Count - 1 Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedAttach('../Doc/Popo2/');return false;")
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            Else
                imgInsert.Visible = False
            End If
        End If
    End Sub
#End Region
#Region "Event PO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        If Session("LoginType") = 0 Then
            'objList.Where += "  and customercode='" + objUser.UserId + "' "
            objList.DeletePrivilege = True
            objList.EditPrivilege = True
            objList.NewPrivilege = True
        End If
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Popo3", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
 
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsEvent(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Event"
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
            Dim intTrxNo As String
            intTrxNo = CType(tmpProp, clsPropEvent).TrxNo
            intLineItemNo = CType(tmpProp, clsPropEvent).LineItemNo
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
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intTrxNo.ToString() + "," + intLineItemNo.ToString() + ");return false;")
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
            imgPrint.Visible = False

            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                imgDelete.Visible = False
                imgEdit.Visible = False
                e.Row.Attributes.Remove("ondblclick")
            Else
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
    Function SaveLineData(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("PartNo='" + strRow(1) + "'")
            sb.Append(",PartDesc='" + strRow(2) + "'")
            sb.Append(",SupplierPartNo='" + strRow(3) + "'")
            sb.Append(",CurrCode='" + strRow(4) + "'")
            sb.Append(",UnitPrice='" + strRow(5) + "'")
            sb.Append(",HarmonizeCode='" + strRow(6) + "'")
            sb.Append(",HarmonizeDesc='" + strRow(7) + "'")
            sb.Append(",HazardousFlag='" + strRow(8) + "'")
            sb.Append(",TagNo='" + strRow(9) + "'")
            sb.Append(",QtyOrdered='" + strRow(10) + "'")
            sb.Append(" where TrxNo=" + Request("Id").ToString() + " and LineItemNo=" + Request("LineItemNo").ToString())
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
    Function SaveShippingInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("InsuranceValue='" + strRow(1) + "'")
            sb.Append(",DateRequested='" + GeneralFun.StringToDate(strRow(2)) + "'")
            sb.Append(",LatestDeliveryDate='" + GeneralFun.StringToDate(strRow(3)) + "'")
            sb.Append(",DateRequestedAtSite='" + GeneralFun.StringToDate(strRow(4)) + "'")
            sb.Append(",TimeOfArrival='" + GeneralFun.StringToDate(strRow(5)) + "'")
            sb.Append(",ShippingStatus='" + strRow(6) + "'")
            sb.Append("where  TrxNo=" + Request("Id").ToString())
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
    Function SavePackageInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("UOM='" + ConvertToInt(strRow(1)) + "'")
            sb.Append(",Length=" + ConvertToInt(strRow(2)))
            sb.Append(",Width=" + ConvertToInt(strRow(3)))
            sb.Append(",Height=" + ConvertToInt(strRow(4)))
            sb.Append(",Weight=" + ConvertToInt(strRow(5)))
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
            sb.Append("update Popo1 set ")
            sb.Append("CompanyName='" + strRow(1) + "'")
            sb.Append(",ContactFirstName='" + strRow(2) + "'")
            sb.Append(",Address1='" + strRow(3) + "'")
            sb.Append(",Address2='" + strRow(4) + "'")
            sb.Append(",City='" + strRow(5) + "'")
            sb.Append(",State='" + strRow(6) + "'")
            sb.Append(",PostalCode='" + strRow(7) + "'")
            sb.Append(",Country='" + strRow(8) + "'")
            sb.Append(",Phone='" + strRow(9) + "'")
            sb.Append(",Fax='" + strRow(10) + "'")
            sb.Append(",Email='" + strRow(11) + "'")
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
    Private Function ConvertToDate(ByVal strVal As String) As String
        If IsDate(strVal) Then
            Return "'" + strVal + "'"
        Else
            Return "null"
        End If
    End Function
#End Region
End Class
