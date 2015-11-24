Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel

Partial Class WCR
    Inherits QueryPage

    Private Sub SetInitValue(ByVal intUserId As String)

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            'Rusult button click event
            btnOk.Attributes.Add("OnClick", "ReturnResult();return false;")
            'Result not Display
            divResult.Style.Add("display", "none")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData(" + txtPage.ClientID + ",4);return false}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(0)")
            btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsWCR).AssemblyQualifiedName, TableName, 3, True))
            btnReturn.Attributes.Add("OnClick", "return HideQueryResult()")
            'bind date
            txtAsOfDate.Text = DateTime.Now.ToString("dd-MMM-yy")
            btnAsOfDate.Attributes.Add("OnClick", "WdatePicker({el:'txtAsOfDate',dateFmt:'dd-MMM-yy'});return false")
            txtAsOfDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtAsOfDate.ClientID + "');return false")
            txtAsOfDate.Attributes.Add("onblur", "ChangeLongDate('" + txtAsOfDate.ClientID + "');return false")
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            btnOk.Focus()
        End If
    End Sub

#Region " Result Event "

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "WCR"
        Me.MyGridView = gvwSource
        Me.CurrentSortField = "Port"
        Me.SortDesc = False
    End Sub

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsWCR(intUserId)
    End Function
    Private Sub ExcelData(ByVal uid As String)
        Session("arrbylzw") = Nothing
        Session("uid") = Nothing
        Session("arrbylzw") = objList.GetPageList(1, 0)
        Session("uid") = uid
    End Sub
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        If objList IsNot Nothing Then
            objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
            gvwSource.DataSource = objList.GetPageList(intPageIndex, intSize)
            gvwSource.DataBind()
            intPageCount = objList.PageCount
            ExcelData(intUserId)
            Return True
        Else
            Return False
        End If
    End Function

    Protected Overrides Function GetResultTitle() As String
        Return "Weekly Container ldle Report"
    End Function

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If objList.IsEmpty Then
                e.Row.Visible = False
            Else
                If e.Row.Cells(0).Text.Trim = "TOTAL" Then
                    'e.Row.Cells(0).Style.Add("text-align", "center")
                    For i As Integer = 0 To gvwSource.Columns.Count - 1
                        e.Row.Cells(i).Font.Bold = True
                    Next
                End If
                e.Row.Cells(0).Style.Add("text-align", "left")
                'Mouse Event
                e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
                If e.Row.RowIndex Mod 2 = 0 Then
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
                Else
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
                End If
                For i As Integer = 1 To gvwSource.Columns.Count - 1
                    e.Row.Cells(i).Style.Add("text-align", "center")
                Next
            End If
        End If
    End Sub

#End Region
    Protected Overloads Sub gvwSource_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            Dim header As TableCellCollection = e.Row.Cells
            header.Clear()
            header.Add(New TableHeaderCell())
            header(0).Attributes.Add("rowspan", "3")
            header(0).Text = "PORT"
            header(0).CssClass = "Header"
            header.Add(New TableHeaderCell())
            header(1).Attributes.Add("colspan", "10")
            header(1).Text = "THESE ARE EMPTY CNTRS IDLE IN DEPOT</tr><tr>"
            header(1).CssClass = "Header"

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

    Protected Sub btnToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        CreateExcel_DataSetArraylist("Daily Container Status")
    End Sub
    Public Sub CreateExcel_DataSetArraylist(ByVal FileName As String)
        If Session("uid") IsNot Nothing Then
            Dim dt As DataTable = Session("arrbylzw")
            If dt IsNot Nothing Then
                If dt.Columns("lNo") IsNot Nothing Then
                    dt.Columns.Remove("lNo")
                End If
                Dim uid As String = Session("uid").ToString
                Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode("DailyContainerStatus.xls", System.Text.Encoding.UTF8))
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312")
                Response.Charset = ""
                Response.ContentType = "/vnd.xls"
                Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter()
                Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
                Dim gv As GridView = New GridView()
                gv.EnableViewState = False
                gv.BorderWidth = New Unit(1, UnitType.Pixel)
                gv.CellPadding = 1

                AddHandler gv.RowDataBound, AddressOf gv_RowDataBound
                AddHandler gv.RowCreated, AddressOf gvwSource_RowCreated
                objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gv, TemplateType.None, Integer.Parse(uid), Session("LoginType").ToString)
                gv.DataSource = dt
                gv.DataBind()
                gv.RenderControl(htmlWrite)
                Response.Write(stringWrite.ToString())
                Response.End()
            End If

        End If
    End Sub
    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(0).Text.Trim = "TOTAL" Then
                e.Row.Cells(0).Style.Add("text-align", "center")
                For i As Integer = 0 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).Font.Bold = True
                Next
            Else
                e.Row.Cells(0).Style.Add("text-align", "left")
            End If
        End If
    End Sub
    Public Sub CreateExcel_DataSet(ByVal ds As DataSet, ByVal FileName As String)
        Dim resp As HttpResponse
        resp = Page.Response
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312")
        resp.ContentType = "application/ms-excel"
        resp.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls")
        Me.EnableViewState = False
        Dim colHeaders As String = "", Is_item As String = ""
        Dim i As Integer = 0
        Dim dt As DataTable = ds.Tables(0)
        Dim myRow As DataRow() = dt.Select("")
        For i = 0 To dt.Columns.Count
            colHeaders &= dt.Columns(i).Caption.ToString & "\t"
        Next
        colHeaders += "\n"
        resp.Write(colHeaders)

        For Each row As DataRow In myRow
            For i = 0 To dt.Columns.Count
                Is_item += row(i).ToString() + "\t"
            Next
            Is_item += "\n"
            resp.Write(Is_item)
            Is_item = ""
        Next
        resp.End()
    End Sub
End Class