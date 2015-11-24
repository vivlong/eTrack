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
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class CodeTable
    Inherits ListEditPage

    Private strCode As String = ""

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        'intPageIndex = intPage
        'objList.GetListInfo(intPage, intSize)
        'objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.BaseInfo)
        'gvwSource.DataSource = objList.ArrProp
        'gvwSource.DataBind()
        'intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        'Dim blnChemical As Boolean = False
        'If strCode = "CHEMICAL" Then
        '    blnChemical = True
        'End If
        'Return New clsCodeTable(intUserId, strFunNo, strCode, blnChemical)
        Return Nothing
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        'MyBase.OnInit(e)
        'If Not Request("Code") Is Nothing Then
        '    strCode = Request("Code").ToString().ToUpper()
        'End If
        'If strCode = "" Then
        '    strCode = "COUNTRY"
        'End If
        'If strCode = "COUNTRY" Then
        '    'Me.TableName = ConSessionName.Country
        'Else
        '    Me.TableName = ConSessionName.CodeTable
        'End If
        'Me.MyGridView = gvwSource
        'Me.CurrentSortField = "Code_Desc"
        'Me.SortDesc = False
        ' ''If Not Request("Code") Is Nothing Then
        ' ''    strCode = Request("Code").ToString().ToUpper()
        ' ''End If
        ' ''If strCode = "" Then
        ' ''    strCode = "COUNTRY"
        ' ''End If
        'If Me.EditPage.IndexOf("?") < 0 Then
        '    Me.EditPage = Me.EditPage + "?Code=" + strCode
        'Else
        '    Me.EditPage = Me.EditPage + "&Code=" + strCode
        'End If
    End Sub

    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        'btnAdvSearch.Text = CStr(GetGlobalResourceObject("PageList", "AdvSearch"))
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Edit MenuItem
        If objList.EditPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.DeletePrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""DeleteDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "DeleteRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        popupMenu.InnerHtml = strOperate
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
 
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

    End Sub

End Class
