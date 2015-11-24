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
Partial Class VesselSchedule_VesselSchedule ' TableName:Rcvy1 ZhiWei
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strbGroup As String = "-1"
    Private StrOninit As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.Where += "  and statuscode not in ('cls','del') "
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)
        dtTmplin = dtTmp
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = dtTmp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsVessualSchedule(intUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = ConSessionName.VessualSchedule
        Me.MyGridView = gvwSource
        'Me.CurrentSortField = "JobNo"
        If Session("LoginType") = 0 Then
            Me.CurrentSortField = "PortofDischargeName"
        Else
            Me.CurrentSortField = "PortofDischargeName"
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
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Search
        drDuring.Items.Clear()
        drDuring.Items.Add(New ListItem("1", "1"))
        drDuring.Items.Add(New ListItem("2", "2"))
        drDuring.Items.Add(New ListItem("3", "3"))
        drDuring.Items.Add(New ListItem("4", "4"))
        drDuring.Items.Add(New ListItem("5", "5"))
        drDuring.Items.Insert(0, New ListItem(ListItemSelect, "0"))
        'From 
        'To
        Dim dtRec As DataTable
        Dim strSql As String = "Select distinct PortOfDischargeName from rcvy1" & _
                               " where PortOfDischargeName is not null and PortOfDischargeName<>''"
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drPortOfDischarge.DataSource = dtRec
            drPortOfDischarge.DataTextField = "PortOfDischargeName"
            drPortOfDischarge.DataValueField = "PortOfDischargeName"
            drPortOfDischarge.DataBind()
            drPortOfDischarge.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Session("hid_voyageIDPass") = ""
        StrOninit = "N"
        If Not IsPostBack Then
            StrOninit = "Y"
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            fldCustomerCode.Value = objUser.UserId
            'New Object
            objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            If Session("LoginType") = 0 Then
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.CustomerCode", objUser.UserId, 1)
                objList.Where = "" 'strWhere
                objList.OrderBy = "" 'System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
                fldLoginType.Value = 0
            Else
                objList.OrderBy = "" ''Session("Database")
                fldLoginType.Value = 1
            End If
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Search Event
            btnDepartureDate.Attributes.Add("OnClick", "showCalendar(txtDepartureDate,0);return false;")
            'btnDepartureDate.Attributes.Add("OnBlur", "hidCalendarForm()")
            'btnTo.Attributes.Add("OnClick", "showCalendar(txtTo,0);return false;")
            btnSearch.Attributes.Add("OnClick", "GetVesuslQueryResult();return false;")
            btnClearField.Attributes.Add("OnClick", "ClearField();return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveField();return false;")
            'Assign Page Event and Relative Value
            btnAddField.Attributes.Add("OnClick", "AddField();return false;")
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsVessualSchedule).AssemblyQualifiedName, TableName, 1, True))
            btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            'txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim str As String = StrOninit
        e.Row.Cells(0).Visible = False
        If e.Row.RowType = DataControlRowType.DataRow Then
            'order by 
            If objList.Where <> "" Then
                If strbGroup <> e.Row.Cells(4).Text.Trim Then
                    e.Row.Cells(1).Text = e.Row.Cells(4).Text.Trim
                    strbGroup = e.Row.Cells(4).Text.Trim
                    e.Row.Cells(4).Text = ""
                End If
            End If
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
                If tmpColumn.FieldName.ToLower() = "voyageid" Then
                    Dim strVoyageID As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VoyageID"))
                    Session("hid_voyageIDPass") += "'" + strVoyageID + "'" + ","
                    e.Row.Attributes.Add("ondblclick", "vesselDetail(" + strVoyageID + ");return false;")
                    If e.Row.RowIndex = dtTmplin.Rows.Count Then
                        e.Row.Cells(0).Text = ""
                        e.Row.Cells(1).Text = ""
                        e.Row.Cells(2).Text = ""
                        e.Row.Cells(3).Text = ""
                    End If
                End If
            Next
        End If
    End Sub
End Class
