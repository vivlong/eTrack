Imports System
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Collections
Imports System.Xml
Imports System.Reflection
Imports SysMagic.ZZSystem
Imports SysMagic.ExportExcel
Imports SysMagic.SystemClass

Partial Class PrintCPC
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
                    e.Row.Cells(0).Style.Add("text-align", "center")
                    For i As Integer = 0 To e.Row.Cells.Count - 1
                        e.Row.Cells(i).Font.Bold = True
                    Next
                Else
                    e.Row.Cells(0).Style.Add("text-align", "left")
                End If
                For i As Integer = 1 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).Style.Add("text-align", "center")
                Next
            End If
        End If
    End Sub

    Protected Overloads Sub gvwHidden_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            Dim header As TableCellCollection = e.Row.Cells
            header.Clear()
            header.Add(New TableHeaderCell())
            header(0).Text = "POD"
            header.Add(New TableHeaderCell())

            header(1).Text = "CONTAINER No"

            header.Add(New TableHeaderCell())

            header(2).Text = "SIZE"

            header.Add(New TableHeaderCell())

            header(3).Text = "ETA"

            header.Add(New TableHeaderCell())

            header(4).Text = "VESSEL"

            header.Add(New TableHeaderCell())

            header(5).Text = "VOY"

            header.Add(New TableHeaderCell())

            header(6).Text = "CONSIGNEE"
            'FULL LADEN INBOUND
            header.Add(New TableHeaderCell())
            header(7).Text = "IDLE DAYS"
            header(7).CssClass = "Header"

        End If
    End Sub
End Class