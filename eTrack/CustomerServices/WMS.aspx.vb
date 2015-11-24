Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic.ZZMessage
Imports SysMagic

Partial Class WMS_WMS
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private returnValue As String
    Private strhidVal As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        PageFun.GetCurrentUserInfo(Page, objUser)

        Dim strWhere As String
        strWhere = SqlRelation.GetStringWhere("a.CustomerCode", drCustomerCode.Text, 1)
        '  objList.Where += "  and statuscode not in ('cls','del') "
        If Session("LoginType") = 0 Then
            objList.Where += " and " + strWhere
        End If
        intPageIndex = intPage
        If objList.Condition = "" Or objList.Condition = "impm1_Balance" Then
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("impm1_Balance", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
            gvwSource.DataSource = objList.ArrProp
            gvwSource.DataBind()
        ElseIf objList.Condition = "Impm1_Movement" Then
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Impm1_Movement", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
            gvwSource.DataSource = objList.ArrProp
            gvwSource.DataBind()
        ElseIf objList.Condition = "Impm1_Inventory1" Then
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Impm1_Inventory1", gvwSource, TemplateType.ListPrint, intUserId, "DynamicCE")
            gvwSource.DataSource = objList.ArrProp
            gvwSource.DataBind()
        ElseIf objList.Condition = "Impm1_Detail" Then
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Impm1_Detail", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
            gvwSource.DataSource = objList.ArrProp
            gvwSource.DataBind()
        End If
        intPageCount = objList.PageCount
        Return True
    End Function

    Public Overloads Function GetCallbackResult() As String
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

    Public Overloads Sub RaiseCallbackEvent(ByVal eventArgument As String)
        returnValue = eventArgument
    End Sub

    Public Function CustomerChange(ByVal CustomerCode As String, ByVal CustomerName As String, ByVal type As String) As String
        Dim objUser As clsUser = Nothing
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim strSql As String = ""
        If type = "Bal" Then
            strSql = "select distinct productcode from impm1 where customercode='" + CustomerCode.Trim + "' and productcode!='' "
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            Dim ConMsgRtn As New ZZMessage.ConMsgRtn
            If CustomerCode = "" Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par
            End If
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                If Not dt.Rows.Count < 0 Then
                    drProductCode.DataSource = dt
                    drProductCode.DataTextField = "productcode"
                    drProductCode.DataValueField = "productcode"
                    drProductCode.DataBind()
                    drProductCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
                    lblCustomerName.Text = CustomerName
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drProductCode) + ConSeparator.Par + GridViewFun.RenderControl(lblCustomerName) + ConSeparator.Par + type
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
            End If
        ElseIf type = "Mov" Then
            strSql = "select distinct productcode from impm1 where customercode='" + CustomerCode.Trim + "' and productcode!='' "
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            Dim ConMsgRtn As New ZZMessage.ConMsgRtn
            If CustomerCode = "" Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par
            End If
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                If Not dt.Rows.Count < 0 Then
                    drProductCode1.DataSource = dt
                    drProductCode1.DataTextField = "productcode"
                    drProductCode1.DataValueField = "productcode"
                    drProductCode1.DataBind()
                    drProductCode1.Items.Insert(0, New ListItem(ListItemSelect, ""))
                    txtCustomerName1.Text = CustomerName
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drProductCode1) + ConSeparator.Par + GridViewFun.RenderControl(txtCustomerName1) + ConSeparator.Par + type
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
            End If
        Else
            strSql = "select distinct ProductCode,(select top 1 ProductName from impr1 where ProductCode=a.ProductCode ) ProductName from impm1 a" & _
                                   " where ProductCode !='' and CustomerCode='" + CustomerCode.Trim + "'"
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            Dim ConMsgRtn As New ZZMessage.ConMsgRtn
            If CustomerCode = "" Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par
            End If
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                If Not dt.Rows.Count < 0 Then
                    drProductCode2.DataSource = dt
                    drProductCode2.DataTextField = "productcode"
                    drProductCode2.DataValueField = "productcode"
                    drProductCode2.DataBind()
                    drProductCode2.Items.Insert(0, New ListItem(ListItemSelect, ""))
                    txtCustomerName2.Text = CustomerName
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drProductCode2) + ConSeparator.Par + GridViewFun.RenderControl(txtCustomerName2) + ConSeparator.Par + type
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Invalid CustomerCode"
            End If
        End If
    End Function

    Public Function SetDropValue(ByVal str As String, ByVal type As String) As String
        If type = "drCustomerCode2" Then
            txtCustomerName2.Text = str
            Return type + ConSeparator.Par + GridViewFun.RenderControl(txtCustomerName2)
        ElseIf type = "drWarehouseCode2" Then
            txtWarehouseName2.Text = str
            Return type + ConSeparator.Par + GridViewFun.RenderControl(txtWarehouseName2)
        ElseIf type = "drDimensionFlag" Then
            hidDimensionFlag.Value = str
            Session("hidDimensionFlag") = str
            Return type + ConSeparator.Par + GridViewFun.RenderControl(hidDimensionFlag)
        Else
            txtProductCode2.Text = str
            Return type + ConSeparator.Par + GridViewFun.RenderControl(txtProductCode2)
        End If
    End Function

    Public Function SetDateValue(ByVal str As String, ByVal type As String) As String
        If type = "1" Then
            Session("txtDateFrom") = str
            Return ""
        Else
            Session("txtDateTo") = str
            Return ""
        End If
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsWMS(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        If Session("LoginType") = 0 Then
            Me.CurrentSortField = "ProductCode"
        Else
            Me.CurrentSortField = "ProductCode"
        End If
        Me.CurrentSortField = "ProductCode"
        Me.SortDesc = False
        '--------------------------------------------
        Dim objUser As clsUser = Nothing
        PageFun.GetCurrentUserInfo(Page, objUser)
        '--------------------------------------------
        objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
    End Sub

    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearchBal.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        btnSearchMov.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim dtRec As DataTable
        'bind Tab1
        Dim strSql As String = "select distinct CustomerCode," & _
                               " (select top 1 BusinessPartyName from rcbp1 where rcbp1.BusinessPartyCode=impr1.CustomerCode ) as CustomerName from impr1" & _
                               " where CustomerCode !=''  "
        If Session("LoginType") <> 0 Then
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drCustomerCode.DataSource = dtRec
                drCustomerCode.DataTextField = "CustomerCode"
                drCustomerCode.DataValueField = "CustomerName"
                drCustomerCode.DataBind()
                drCustomerCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
            End If
            drProductCode.Items.Insert(0, New ListItem("", ""))
            'bind Tab2
            strSql = "select distinct CustomerCode , (select top 1 BusinessPartyName from rcbp1 where BusinessPartyCode=a.CustomerCode ) as CustomerName from impm1 a " & _
                      "where  CustomerCode !='' "
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drCustomerCode1.DataSource = dtRec
                drCustomerCode1.DataTextField = "CustomerCode"
                drCustomerCode1.DataValueField = "CustomerName"
                drCustomerCode1.DataBind()
                drCustomerCode1.Items.Insert(0, New ListItem(ListItemSelect, ""))
            End If
            drProductCode1.Items.Insert(0, New ListItem("", ""))
            'bind Tab3
            strSql = "select distinct CustomerCode , (select top 1 BusinessPartyName from rcbp1 where BusinessPartyCode=a.CustomerCode ) as CustomerName from impm1 a " & _
                      "where  CustomerCode !='' "
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drCustomerCode2.DataSource = dtRec
                drCustomerCode2.DataTextField = "CustomerCode"
                drCustomerCode2.DataValueField = "CustomerName"
                drCustomerCode2.DataBind()
                drCustomerCode2.Items.Insert(0, New ListItem(ListItemSelect, ""))
            Else
                drCustomerCode2.Items.Insert(0, New ListItem("", ""))
            End If
        Else
            drCustomerCode.Items.Insert(0, New ListItem(intUserId, intUserId))
            drCustomerCode1.Items.Insert(0, New ListItem(intUserId, intUserId))
            drCustomerCode2.Items.Insert(0, New ListItem(intUserId, intUserId))
            dtRec = BaseSelectSrvr.GetData("select top 1 BusinessPartyName from rcbp1 where BusinessPartyCode='" + intUserId + "'", "")
            If dtRec.Rows.Count > 0 Then
                lblCustomerName.Text = dtRec.Rows(0)("BusinessPartyName").ToString
            End If
            strSql = "select distinct CustomerCode , (select top 1 BusinessPartyName from rcbp1 where BusinessPartyCode=a.CustomerCode ) as CustomerName from impm1 a " & _
                     "where  a.CustomerCode ='" + intUserId + "'"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                txtCustomerName1.Text = dtRec.Rows(0)("CustomerName").ToString
            End If
            dtRec = BaseSelectSrvr.GetData("select distinct CustomerCode , CustomerName from impm1 where CustomerCode='" + intUserId + "'", "")
            If dtRec.Rows.Count > 0 Then
                txtCustomerName2.Text = dtRec.Rows(0)("CustomerName").ToString
            End If

            strSql = "select distinct ProductCode from impm1" & _
                                   " where CustomerCode ='" + intUserId + "'"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drProductCode.DataSource = dtRec
                drProductCode.DataTextField = "ProductCode"
                drProductCode.DataValueField = "ProductCode"
                drProductCode.DataBind()
                drProductCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
            Else
                drProductCode.Items.Insert(0, New ListItem("", ""))
            End If
            'bind Tab2
            dtRec = BaseSelectSrvr.GetData("select top 1 CustomerName from Impm1 where CustomerCode='" + intUserId + "'", "")
            If dtRec.Rows.Count > 0 Then
                drCustomerCode1.Text = dtRec.Rows(0)("CustomerName").ToString
            End If
            strSql = "select distinct ProductCode from impm1" & _
                     " where CustomerCode ='" + intUserId + "'"
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                drProductCode1.DataSource = dtRec
                drProductCode1.DataTextField = "ProductCode"
                drProductCode1.DataValueField = "ProductCode"
                drProductCode1.DataBind()
                drProductCode1.Items.Insert(0, New ListItem(ListItemSelect, ""))
            Else
                drProductCode1.Items.Insert(0, New ListItem("", ""))
            End If
        End If
        'bind Tab3
        strSql = "select distinct ProductCode,(select top 1 ProductName from impr1 where ProductCode=a.ProductCode ) ProductName from impm1 a" & _
                               " where ProductCode !='' and CustomerCode='" + intUserId + "'"
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drProductCode2.DataSource = dtRec
            drProductCode2.DataTextField = "ProductCode"
            drProductCode2.DataValueField = "ProductName"
            drProductCode2.DataBind()
            drProductCode2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drProductCode.Items.Insert(0, New ListItem("", ""))
        End If

        strSql = "select distinct Warehousecode,(select top 1 WarehouseName from whwh1 b where a.WarehouseCode=b.WarehouseCode ) WarehouseName from impm1 a" & _
                               " where  a.Warehousecode !=''  "
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drWarehouseCode2.DataSource = dtRec
            drWarehouseCode2.DataTextField = "Warehousecode"
            drWarehouseCode2.DataValueField = "WarehouseName"
            drWarehouseCode2.DataBind()
            drWarehouseCode2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drWarehouseCode2.Items.Insert(0, New ListItem("", ""))
        End If
        drDimensionFlag.Items.Add(New ListItem("Packing", "Packing"))
        drDimensionFlag.Items.Add(New ListItem("Whole", "Whole"))
        drDimensionFlag.Items.Add(New ListItem("Loose", "Loose"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("hidDimensionFlag") = "Packing"
            Session("txtDateFrom") = ""
            Session("txtDateTo") = ""
            objList.Condition = "Bal"
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            txtAsonDate.Text = Now.Date.ToString("dd/MM/yyyy")
            'Set Default Value
            SetInitValue(objUser.UserId)
            fldCustomerCode.Value = objUser.UserId
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            'If Session("LoginType") = 0 Then
            Dim strWhere As String

            strWhere = SqlRelation.GetStringWhere("a.CustomerCode", drCustomerCode.Text, 1)
            If Session("LoginType") = 0 Then
                objList.Where = " and " + strWhere
            Else
                objList.Where = "" 'strWhere
            End If
            objList.OrderBy = "" 'System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
            fldLoginType.Value = 0
            gvwSource.Style.Add("display", "none")
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            btnAsonDate.Attributes.Add("OnClick", "showCalendar(txtAsonDate,0);return false;")
            btnMovenMentDateFrom.Attributes.Add("OnClick", "showCalendar(txtMovenMentDateFrom,0);return false;")
            btnMovenMentDateTo.Attributes.Add("OnClick", "showCalendar(txtMovenMentDateTo,0);return false;")
            btnDateFrom.Attributes.Add("OnClick", "showCalendar(txtDateFrom,0);return false;")
            btnDateTo.Attributes.Add("OnClick", "showCalendar(txtDateTo,0);return false;")

            btnSearchBal.Attributes.Add("OnClick", "TableName='impm1_Balance';GetQueryData(" + hid_val.Value + ");return false;")
            btnSummary.Attributes.Add("OnClick", "TableName='impm1_Balance';FunSummary();GetQueryData(" + hid_val.Value + ");return false;")
            btnSearchMov.Attributes.Add("OnClick", "TableName='Impm1_Movement';GetQueryData(" + hid_val.Value + ");return false;")
            btnSearchInv.Attributes.Add("OnClick", "TableName='Impm1_Inventory1';GetQueryData(" + hid_val.Value + ");return false;")
            btnDetail.Attributes.Add("OnClick", "TableName='Impm1_Detail';GetQueryData(" + hid_val.Value + ");return false;")

            'btnDetails.Attributes.Add("OnClick", "showDetail();return false;")
            btnClearField.Attributes.Add("OnClick", "ClearField(" + hid_val.ClientID + ");return false;")
            btnClearField1.Attributes.Add("OnClick", "ClearField(" + hid_val.ClientID + ");return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveField(" + hid_val.ClientID + ");return false;")
            btnRemove1.Attributes.Add("OnClick", "RemoveField(" + hid_val.ClientID + ");return false;")
            'Assign Page Event and Relative Value
            '  btnAddField.Attributes.Add("OnClick", "AddField(" + hid_val.ClientID + ");return false;")
            btnAddField.Attributes.Add("OnClick", "SelMultiType(""" + drProductCodeField.ClientID + """);return false;")

            'btnAddField1.Attributes.Add("OnClick", "AddField(" + drProductCode.ClientID + ");return false;")
            btnAddField1.Attributes.Add("OnClick", "SelMultiType(""" + drProductCodeField1.ClientID + """);return false;")
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            drCustomerCode.Attributes.Add("onchange", "CustomerCodechange('Bal'," + drCustomerCode.ClientID + "," + drProductCode.ClientID + ")")
            drCustomerCode1.Attributes.Add("onchange", "CustomerCodechange('Mov'," + drCustomerCode1.ClientID + "," + drProductCode1.ClientID + ")")
            drCustomerCode2.Attributes.Add("onchange", "CustomerCodechange('Inv'," + drCustomerCode2.ClientID + "," + drProductCode2.ClientID + ")")
            'drCustomerCode2.Attributes.Add("onchange", "SetDropValue(" + drCustomerCode2.ClientID + ",'drCustomerCode2')")


            drProductCode2.Attributes.Add("onchange", "SetDropValue(" + drProductCode2.ClientID + ",'drProductCode2')")
            drWarehouseCode2.Attributes.Add("onchange", "SetDropValue(" + drWarehouseCode2.ClientID + ",'drWarehouseCode2')")
            drDimensionFlag.Attributes.Add("onchange", "SetDropValue(" + drDimensionFlag.ClientID + ",'drDimensionFlag')")
            'btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelMulti(objUser.PagePara.InfoSize, False))
            HandlePopupMenu()
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            'txtSearch.Focus()
            btnMultiGridColumnSet.Attributes.Add("OnClick", "GridColumnSet();return false;")
            btnMultiGridColumnSet1.Attributes.Add("OnClick", "GridColumnSet();return false;")
            'date
            txtDateFrom.Attributes.Add("onpropertychange", "SetDateValue(" + txtDateFrom.ClientID + ",'1')")
            txtDateTo.Attributes.Add("onpropertychange", "SetDateValue(" + txtDateTo.ClientID + ",'2')")
            'btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsVessualSchedule).AssemblyQualifiedName, TableName, 1, True))
            'btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))

            'a2.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        strhidVal = Session("hidDimensionFlag")
        e.Row.Cells(0).Style.Add("display", "none")
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.Header Then
            If objList.Query = "Impm1_Inventory1" Then
                For i = 0 To objColumns.Column.Count - 1
                    e.Row.Cells(i + 1).Attributes.Remove("onclick")
                Next
                'e.Row.Cells(5).Text = "P/O[In]" + vbNewLine + "INV[Out]"
                'e.Row.Cells(6).Text = "Ref[In]" + vbNewLine + " P/K[Out]"
            End If
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim strMovementDate As String
            strMovementDate = CType(tmpProp, clsPropWMS).MovementDate
            Dim BatchNo As String
            BatchNo = CType(tmpProp, clsPropWMS).BatchNo
            'Popupmenu
            If objList.Query = "Impm1_Movement" Or objList.Query = "Impm1_Detail" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event,1);return false;")
            End If
            Dim strDateFrom As String = ""
            Dim strDateTo As String = ""
            If Session("txtDateFrom") IsNot Nothing Then
                strDateFrom = Session("txtDateFrom").ToString
                strDateFrom = strDateFrom.Replace("/", "@")
            End If
            If Session("txtDateTo") IsNot Nothing Then
                strDateTo = Session("txtDateTo").ToString
                strDateTo = strDateTo.Replace("/", "@")
            End If

            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                If objList.Query = "Impm1_Inventory1" Then
                    If _ColumnInfo.FieldName.ToLower() = "productcode" Then
                        e.Row.Cells(i + 1).Text = "<A href=""javascript:var strRe =WindowDialog('../loading.aspx?tourl=CustomerServices/Inventory2.aspx?" & _
                        "productcode=" + e.Row.Cells(i + 1).Text.Trim & _
                        "&BrandName=" + e.Row.Cells(i + 3).Text.Trim & _
                        "&DimensionFlag=" + strhidVal.Trim & _
                        "&BatchNo=" + BatchNo & _
                        "&DateFrom=" + strDateFrom & _
                        "&DateTo=" + strDateTo & _
                        "',650,400);""> " + e.Row.Cells(i + 1).Text + "</A>"
                    End If
                End If
                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        Dim strFieldName As String = _ColumnInfo.FieldName
                        Dim strfield As String = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If strfield <> "" Then
                            Dim dtmTemp As DateTime = strfield
                            If dtmTemp <= ConDateTime.MinDate Then
                                e.Row.Cells(i + 1).Text = ""
                            Else
                                e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                            End If
                        End If
                End Select
            Next
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 And objColumns.Column.Count > 0 Then
                For i = 0 To objColumns.Column.Count - 1
                    e.Row.Cells(i).Text = ""
                Next
            End If
        End If
    End Sub

    Public Function SetTabVal(ByVal hidVal As String) As String
        Dim ConMsgRtn As New ZZMessage.ConMsgRtn
        hid_val.Value = hidVal
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(hid_val)
    End Function

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
        popupMenu.InnerHtml = strOperate
    End Sub
End Class
