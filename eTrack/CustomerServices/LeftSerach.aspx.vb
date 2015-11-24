Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Partial Class LeftSerach
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strval As String = ""
    Private strfield As String = ""
    Private strcount As Integer = 0
  
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)

        If dtTmp.Rows.Count <= 0 Then
            Response.Write("<script language='javascript'>alert('Not Date Exit.');window.close();</script>")
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "", "<script language='javascript'>strWhere=""" + objList.Where + """;</script>")
            If dtTmp.Rows(0)("jobno") Is DBNull.Value Then
                Response.Write("<script language='javascript'>alert('Not Date Exit.');window.close();</script>")
            ElseIf dtTmp.Rows(0)("modulecode") Is DBNull.Value Then
                Response.Write("<script language='javascript'>alert('Module Is Null.');window.close();</script>")
            Else
                strcount = dtTmp.Rows.Count
                If strcount = 1 Then
                    If strval <> "" Then
                        Dim strModuleCode As String = ""
                        Dim strFunUrl As String = ""
                        Dim strid As String = ""
                        Dim strDBName As String = System.Configuration.ConfigurationManager.AppSettings("InitialCatalog")
                        If strval.Trim <> "" Then
                            strid = dtTmp.Rows(0)("jobno").ToString
                            strModuleCode = dtTmp.Rows(0)("modulecode").ToString
                            Select Case strModuleCode
                                Case "AE", "AI"
                                    strFunUrl = "AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo=" + strid.Trim
                                Case "SE", "SI"
                                    strFunUrl = "SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo=" + strid.Trim
                            End Select
                        End If
                        Response.Write("<script language='javascript'>window.close();window.open('" + strFunUrl + "','','width=770px,height=580px,resizable=0,scrollbars=0,menubar=no,location=no');</script>")
                    End If
                Else
                    dtTmplin = dtTmp
                    objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
                    gvwSource.DataSource = dtTmp
                    gvwSource.DataBind()
                    intPageCount = objList.PageCount
                End If
            End If
        End If

        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsAirSeaQuery(intUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = ConSessionName.AirSeaQuery
        Me.MyGridView = gvwSource
        'Me.CurrentSortField = "JobNo"
        If Session("LoginType") = 0 Then
            Me.CurrentSortField = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
        Else
            Me.CurrentSortField = Session("Database")
        End If
        Me.SortDesc = False
    End Sub

    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        '  btnAdvSearch.Text = CStr(GetGlobalResourceObject("PageList", "AdvSearch"))
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        'Search
        drpSearch.Items.Clear()
        drpSearch.Items.Add(New ListItem("Job No", "JobNo"))
        drpSearch.Items.Add(New ListItem("BL No", "MawbOBLNo"))
        drpSearch.Items.Add(New ListItem("AWB No", "AwbBlNo"))
        drpSearch.Items.Add(New ListItem("Container No", "ContainerNo"))
        drpSearch.Items.Add(New ListItem("Reference No", "CustomerRefNo"))
        'From 
        drpFrom.Items.Clear()
        drpFrom.Items.Add(New ListItem("ETD", "ETD"))
        drpFrom.Items.Add(New ListItem("ETA", "ETA"))
        drpFrom.Items.Add(New ListItem("Origin", "OriginCode"))
        drpFrom.Items.Add(New ListItem("Destination", "DestCode"))
        drpFrom.Attributes.Add("OnChange", "FromChange();")
        'To
        'drpTo.Items.Clear()
        'drpTo.Items.Add(New ListItem("ETD", "ETD"))
        'drpTo.Items.Add(New ListItem("Destination", "DestCode"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim UserId, PageSize, QuerySize As String
            Dim objUser As clsUser = Nothing
            If Session("LoginType") = 3 Then
                '' this part for just directly search so dont need check user ... Add it by Jackie 080904
                UserId = 3
                PageSize = 24
                QuerySize = 0
            Else
                If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                    Return
                End If
                QuerySize = objUser.PagePara.QuerySize
                UserId = objUser.UserId
                PageSize = objUser.PagePara.InfoSize
            End If
            Dim dataBase As String
            If Not (Request("DB") Is Nothing) Then
                dataBase = Request("DB").ToString()
            End If
            'Set Default Value
            SetInitValue(UserId)
            fldCustomerCode.Value = UserId
            'New Object
            objList = NewObjectList(UserId, PageFun.GetFunNo(Page))
            strval = Request("strval").ToString
            strfield = Request("strfield").ToString
            If Session("LoginType") = 0 Then 'customerLogin
                Dim strWhere As String
                strWhere = " and " + SqlRelation.GetStringWhere("a.CustomerCode", UserId, 1)
                'strWhere += " a." + strfield + " like('%" + strfield + "%')"
                strWhere += " and a." + strfield + " like('%" + strval + "%')"

                objList.Where = strWhere
                'objList.OrderBy = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
                fldLoginType.Value = 0
            Else
                Dim strWhere As String
                strWhere = " and a." + strfield + " like('%" + strval + "%')"
                objList.Where = strWhere
                ''objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc) + "," + System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
                fldLoginType.Value = 1
            End If
            'Get First Page Data
            BindSourceData(UserId, 1, PageSize)
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryResult(); return false;}")
            ''javascript:if(event.keyCode==115){showCalendar(txtFrom,0); return false;}
            txtFrom.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryResult(); return false;}")
            txtTo.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryResult(); return false;}")
            btnFrom.Attributes.Add("OnClick", "showCalendar(txtFrom,0);return false;")
            btnTo.Attributes.Add("OnClick", "showCalendar(txtTo,0);return false;")
            btnSearch.Attributes.Add("OnClick", "GetQueryResult();return false;")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnPrint.Visible = False
            btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(QuerySize, GetType(clsAirSeaQuery).AssemblyQualifiedName, TableName, 1, True))
            btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(QuerySize, True))
            If Session("LoginType") = 3 Then
                btnToExcel.Visible = False
            End If
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            Dim i As Integer
            Dim tmpColumn As clsPropColumn
            For i = 0 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                If tmpColumn.FieldName.ToLower() = "attachmentflag" Then
                    e.Row.Cells(i).Width = 10
                    e.Row.Cells(i).Text = "<img alt='pic' src='../Images/Sms/attach.gif' />"
                End If
            Next
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If

            Dim i As Integer
            Dim tmpColumn As clsPropColumn
            For i = 0 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                If tmpColumn.FieldName.ToLower() = "jobno" Then
                    Dim strJobNo As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "JobNo"))
                    Dim strModuleCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ModuleCode"))
                    Dim strDBName As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DBName"))
                    Select Case strModuleCode
                        Case "AE", "AI"
                            Dim strFunUrl As String = "CustomerServices/AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo="
                            Dim strUrl As String = PageFun.GetReferencePage("", strFunUrl + strJobNo, strJobNo, ReferenceTarget.WindowDialog)
                            e.Row.Cells(i).Text = e.Row.Cells(i).Text.Replace(strJobNo, strUrl)
                        Case "SE", "SI"
                            Dim strFunUrl As String = "CustomerServices/SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo="
                            Dim strUrl As String = PageFun.GetReferencePage("", strFunUrl + strJobNo, strJobNo, ReferenceTarget.WindowDialog)
                            e.Row.Cells(i).Text = e.Row.Cells(i).Text.Replace(strJobNo, strUrl)
                    End Select
                    Exit For
                End If
                If tmpColumn.FieldName.ToLower() = "attachmentflag" Then
                    e.Row.Cells(i).Width = 10
                    Dim strAttachmentFlag As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AttachmentFlag"))
                    If strAttachmentFlag = "Y" Then
                        e.Row.Cells(i).Text = "<img alt='pic' src='../Images/Sms/attach.gif' />"
                    End If
                End If
            Next
            If e.Row.RowIndex = dtTmplin.Rows.Count Then
                e.Row.Cells(0).Text = ""
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
            End If


        End If
    End Sub

End Class
