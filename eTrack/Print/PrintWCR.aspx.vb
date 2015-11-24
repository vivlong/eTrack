Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections
Imports System.Xml
Imports System.Reflection
Imports SysMagic.ZZSystem
Imports SysMagic.ExportExcel
Imports SysMagic.SystemClass

Partial Class PrintWCR
    Inherits System.Web.UI.Page

    Private objList As clsQuery
    Private _TableName As String = ""
    Private _Title As String = ""
    Private _ClassName As String = ""
    Private _SortField As String = ""
    Private _SortDesc As Boolean = False

    'Object Column of Gridview
    Private objColumns As colColumn

    Private Sub SetInitValue(ByVal objUser As clsUser)
        _TableName = Request.QueryString("TableName").ToString()
        _ClassName = Request.QueryString("ClassName").ToString()
        If Request.QueryString("Title") IsNot Nothing Then
            _Title = Request.QueryString("Title").ToString()
        End If
        If Request.QueryString("SortField") IsNot Nothing Then
            _SortField = Request.QueryString("SortField").ToString()
        End If
        If Request.QueryString("SortDesc") IsNot Nothing Then
            _SortDesc = GeneralFun.IntStringAsBool(Request.QueryString("SortDesc").ToString())
        End If
        'Create object of Query
        Dim tyType As Type = Type.GetType(_ClassName)
        Dim obj As Object = Activator.CreateInstance(tyType, objUser.UserId)
        objList = CType(obj, clsQuery)
        If Request.QueryString("Query") IsNot Nothing Then
            objList.Query = Request.QueryString("Query").ToString()
        End If
        If Request.QueryString("Where") IsNot Nothing Then
            objList.Where = Request.QueryString("Where").ToString()
        End If
        If Request.QueryString("Condition") IsNot Nothing Then
            Dim strMsg As String = ""
            objList.DecodeQueryCondition(Request.QueryString("Condition").ToString(), strMsg)
        End If
        'Set other value 
        lblTitle.Text = _Title
        lblCompName.Text = "【" + objUser.PartCompanyName + "】"
        lblTime.Text = DateTime.Now.ToString()
        Title = _Title
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set init value
            SetInitValue(objUser)
            'Bind Data
            BindPrintData()
            'Button Event 
            btnPrint.Attributes.Add("OnClick", "Print();return false;")
            btnPrintPreview.Attributes.Add("OnClick", "PrintPreview();return false;")
            btnPageSetup.Attributes.Add("OnClick", "PageSetup();return false;")
        End If
    End Sub

    Protected Function BindPrintData() As Boolean
        Dim gvwHidden As GridView = New GridView()
        gvwHidden.AutoGenerateColumns = False
        gvwHidden.EnableViewState = False
        gvwHidden.BorderWidth = New Unit(0, UnitType.Pixel)
        gvwHidden.CellPadding = 0
        AddHandler gvwHidden.RowDataBound, AddressOf gvwHidden_RowDataBound
        AddHandler gvwHidden.RowCreated, AddressOf gvwHidden_RowCreated
        Dim fontsize As Integer = CInt(System.Configuration.ConfigurationManager.AppSettings("fontsize"))
        If objList IsNot Nothing Then
            objColumns = DynamicGridViewFun.GetColumnFromXmlFile(_TableName, gvwHidden, TemplateType.None)
            gvwHidden.DataSource = objList.GetAllList()
            gvwHidden.DataBind()

            Dim strResultBody As String
            Dim str As String = GridViewFun.RenderControl(gvwHidden)
            strResultBody = Replace(GridViewFun.RenderControl(gvwHidden), "<th scope=""col"">", "<th scope=""col"" align=""center"" style=""font-size:" & fontsize & "pt; font-weight: bold"">")
            strResultBody = Replace(strResultBody, "<th scope=""col"">", "<td scope=""col"" align=""center"" style=""font-size:" & fontsize & "pt;"">")
            strResultBody = Replace(strResultBody, "<td align=""left"" style=""", "<td align=""center"" style=""font-size:" & fontsize & "pt;")
            strResultBody = Replace(strResultBody, "<td align=""right"" style=""", "<td align=""center"" style=""font-size:" & fontsize & "pt;")
            divResult.InnerHtml = strResultBody
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub gvwHidden_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If objList.IsEmpty Then
                e.Row.Visible = False
            Else
                If e.Row.Cells(0).Text.Trim = "TOTAL" Then

                    For i As Integer = 0 To e.Row.Cells.Count - 1
                        e.Row.Cells(i).Font.Bold = True
                    Next
                End If
                e.Row.Cells(0).Style.Add("text-align", "left")
                For i As Integer = 1 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).Style.Add("text-align", "center")
                Next
            End If
        End If
    End Sub

    Protected Sub gvwHidden_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            Dim header As TableCellCollection = e.Row.Cells
            header.Clear()
            header.Add(New TableHeaderCell())
            header(0).Attributes.Add("rowspan", "3")
            header(0).Text = "PORT"
            header(0).CssClass = "celCenter"

            header.Add(New TableHeaderCell())
            header(1).Attributes.Add("colspan", "10")
            header(1).Text = "THESE ARE EMPTY CNTRS IDLE IN DEPOT</tr><tr>"
            header(1).CssClass = "celCenter"

            header.Add(New TableHeaderCell())
            header(2).Attributes.Add("colspan", "2")
            header(2).CssClass = "Header"
            header(2).Text = "OVER 15 DAYS"

            header.Add(New TableHeaderCell())
            header(3).Attributes.Add("colspan", "2")
            header(3).CssClass = "Header"
            header(3).Text = "OVER 20 DAYS"

            header.Add(New TableHeaderCell())
            header(4).Attributes.Add("colspan", "2")
            header(4).CssClass = "Header"
            header(4).Text = "OVER 30 DAYS"

            header.Add(New TableHeaderCell())
            header(5).Attributes.Add("colspan", "2")
            header(5).CssClass = "Header"
            header(5).Text = "OVER 40 DAYS"

            header.Add(New TableHeaderCell())
            header(6).Attributes.Add("colspan", "2")
            header(6).CssClass = "Header"
            header(6).Text = "50 DAYS & ABOVE</tr><tr>"

            '1_Over 15 Days
            header.Add(New TableHeaderCell())
            header(7).Text = "20GP"
            header(7).CssClass = "Header"

            header.Add(New TableHeaderCell())
            header(8).Text = "40HC"
            header(8).CssClass = "Header"

            '2_Over 20 Days
            header.Add(New TableHeaderCell())
            header(9).Text = "20GP"
            header(9).CssClass = "Header"

            header.Add(New TableHeaderCell())
            header(10).Text = "40HC"
            header(10).CssClass = "Header"

            '3_Over 30 Days
            header.Add(New TableHeaderCell())
            header(11).Text = "20GP"
            header(11).CssClass = "Header"

            header.Add(New TableHeaderCell())
            header(12).Text = "40HC"
            header(12).CssClass = "Header"

            '4_Over 40 Days
            header.Add(New TableHeaderCell())
            header(13).Text = "20GP"
            header(13).CssClass = "Header"

            header.Add(New TableHeaderCell())
            header(14).Text = "40HC"
            header(14).CssClass = "Header"

            '5_Over 50 Days
            header.Add(New TableHeaderCell())
            header(15).Text = "20GP"
            header(15).CssClass = "Header"

            header.Add(New TableHeaderCell())
            header(16).Text = "40HC"
            header(16).CssClass = "Header"
        End If
    End Sub
End Class