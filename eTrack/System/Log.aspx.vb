Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.ExportExcel
Imports SysMagic.SystemClass

Partial Class Log
    Inherits QueryPage

    Private Sub SetInitValue(ByVal intUserId As String)
        txtQDate.Text = ConDateTime.CurrentDateFirstDay.ToString(ConDateTime.DateFormat)
        txtZDate.Text = DateTime.Now.ToString(ConDateTime.DateFormat)
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
            'Date button click event
            btnQDate.Attributes.Add("OnClick", "showCalendar(txtQDate,0);return false;")
            btnZDate.Attributes.Add("OnClick", "showCalendar(txtZDate,0);return false;")
            'Rusult button click event
            ' btnOk.Attributes.Add("OnClick", "return GetQueryResult();")
            'Result not Display
            divResult.Style.Add("display", "none")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            'btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsLogQuery).AssemblyQualifiedName, TableName, 1, True))
            'btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))
            'btnReturn.Attributes.Add("OnClick", "return HideQueryResult();")
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            txtQDate.Focus()
        End If
    End Sub

#Region " Result Event "

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        ' Me.TableName = ConSessionName.LogQuery
        Me.MyGridView = gvwSource
        Me.CurrentSortField = "dOperateDate"
        Me.SortDesc = True
    End Sub

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        ' Return New clsLogQuery(intUserId)
        Return Nothing
    End Function

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        If objList IsNot Nothing Then
            objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
            gvwSource.DataSource = objList.GetPageList(intPageIndex, intSize)
            gvwSource.DataBind()
            intPageCount = objList.PageCount
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If objList.IsEmpty Then
                e.Row.Visible = False
            Else
                'Mouse Event
                e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
                If e.Row.RowIndex Mod 2 = 0 Then
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
                Else
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
                End If
            End If
        End If
    End Sub

#End Region

End Class