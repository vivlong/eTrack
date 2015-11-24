Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class Company
    Inherits ListEditPage

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.BaseInfo)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsCompany(strUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = ConSessionName.Company
        Me.MyGridView = gvwSource
        Me.CurrentSortField = "CompanyCode"
        Me.SortDesc = False
    End Sub
    Private Sub InitSearchListField()
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        For i = 0 To objColumns.Column.Count - 1
            _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
            Select Case _ColumnInfo.FieldType
                Case DbType.String
                    drpSearch.Items.Add(New ListItem(_ColumnInfo.FieldTitle, _ColumnInfo.FieldName + ",0"))
                Case Else
                    drpSearch.Items.Add(New ListItem(_ColumnInfo.FieldTitle, _ColumnInfo.FieldName + ",1"))
            End Select
            drpSearch.SelectedValue = CurrentSortField
        Next
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
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            InitSearchListField()
            'Assign Search Event
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData(" + txtPage.ClientID + ",4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(0);")
            'Language 
            HandleLanguageRelative()
            'Popup Menu 
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lz As Integer
            For lz = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(lz).Attributes.Add("style", "word-break :break-all ; word-wrap:break-word; border-color:#E6EEF7;")
            Next
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim i As Integer
            'KeyValue 
            Dim intId As Int64 = CType(tmpProp, clsPropCompany).Id
            'Popupmenu
            If intId > 0 Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(" + intId.ToString() + ");return false;")
            End If
            'Row Color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            If tmpProp.IsDeleted = 1 Then
                e.Row.ForeColor = ConColor.Deleted
            Else
                e.Row.ForeColor = ConColor.Normal
            End If
            'Row cann't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege And tmpProp.IsDeleted = 0 And Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intId.ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete;
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail(" + intId.ToString() + ");return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit;
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege And tmpProp.IsDeleted = 0 And Not tmpProp.IsAdd Then
                imgEdit.Attributes.Add("OnClick", "EditDetail(" + intId.ToString() + ");return false;")
                e.Row.Attributes.Add("ondblclick", "EditDetail(" + intId.ToString() + ");return false;")
            Else
                imgEdit.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege And tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail(" + ");return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail(" + ");return false;")
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                e.Row.Cells(1).Text = ""
            End If
        End If
        e.Row.Cells(0).Style.Add("display", "none")
    End Sub

End Class
