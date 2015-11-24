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
Imports SysMagic.SystemClass

Partial Class PrintQry
    Inherits System.Web.UI.Page
    Private objList As clsQuery
    Private _TableName As String = ""
    Private _Title As String = ""
    Private _ClassName As String = ""
    Private _SortField As String = ""
    Private _SortDesc As Boolean = False

    'Object Column of Gridview
    Private objColumns As colColumn
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        'base.VerifyRenderingInServerForm(control);
    End Sub
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
    Public Sub CreateExcel(ByVal FileName As String)
        'Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode("Sauk1.Html", System.Text.Encoding.UTF8))
        'Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312")
        'Response.Charset = ""
        'Response.ContentType = "application/pdf"
        'Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter()
        'Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        'gvwHidden.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        'Response.End()

        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
        Response.Charset = "big5"
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        gvwHidden.AllowPaging = False
        gvwHidden.AllowSorting = False
        SubSetInit()
        BindPrintData()
        Dim str As String = GridViewFun.RenderControl(gvwHidden)
        gvwHidden.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Response.End()
    End Sub
    Protected Function BindPrintData() As Boolean
        If objList IsNot Nothing Then
            objColumns = DynamicGridViewFun.GetColumnFromXmlFile(_TableName, gvwHidden, TemplateType.None)
            gvwHidden.DataSource = objList.GetAllList()
            gvwHidden.DataBind()
            If _TableName = "VessualSchedule" Then
                gvwHidden.Columns(0).Visible = False
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub SubSetInit()
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return
        End If
        SetInitValue(objUser)
    End Sub

    Protected Sub gvwHidden_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If objList.IsEmpty Then
                'e.Row.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
        CreateExcel("VessualSchedule")
    End Sub
    Public Sub ConvertDataTableToPDF(ByRef datatable As DataTable, ByVal PDFFilePath As String, ByVal FontPath As String, ByVal FontSize As Double)

    End Sub
End Class