Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic
 
Partial Class CEL
    Inherits ListEditPage
    Protected ConfigPath As String
    Protected ExportConfig As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        Dim strFun As String = PageFun.GetFunNo(Page)
        intPageIndex = intPage
        Dim dt As DataTable
        Dim clsUser As New clsUser
        dt = clsUser.ListSub(objUser.RoleName, strFun)
        Dim i As Integer
        Dim flag As String = ""
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item(0).ToString = "6" Then
                flag = "Y"
            End If
        Next
        If flag <> "Y" And objUser.UserId <> "sa" And objUser.UserId.ToLower <> "s" Then
            objList.Where += " and a.SiteCode='" + objUser.SiteCode + "' "
        End If
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsCtcl_Rccf(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctcl1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub

    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
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
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
        popupMenu.InnerHtml = strOperate
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set style Config
            ExportConfig = objUser.ExportConfig
            Select Case ExportConfig
                Case "Blue"
                    ConfigPath = "../App_Themes"
                Case "Orange"
                    ConfigPath = "../App_Themes_Orange"
                Case "Smalt"
                    ConfigPath = "../App_Themes_Smalt"
                Case Else
                    ConfigPath = "../App_Themes"
            End Select
            'New Object 
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            hidFunNo.Value = PageFun.GetFunNo(Page)
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Init Search List Field
            InitSearchListField()
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData(" + txtPage.ClientID + ",4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            'btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, False))
            'Language 
            HandleLanguageRelative()
            'Popup Menu 
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim strFun As String = PageFun.GetFunNo(Page)
        Dim _ColumnInfo As clsPropColumn
        e.Row.Cells(0).Style.Add("display", "none")
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim ContainerNo As String = CType(tmpProp, clsPropctcl).ContainerNo.ToString()
            'Popupmenu
            e.Row.Attributes.Add("oncontextmenu", "ShowMenu('" + ContainerNo + "');return false;")
            'Row color
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
            'Handle display value
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Dim strFieldName As String = _ColumnInfo.FieldName
                If _ColumnInfo.FieldType = DbType.Date Or _ColumnInfo.FieldType = DbType.DateTime Then
                    'e.Row.Cells(i).Text
                    If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                        Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If dtmTemp <= ConDateTime.MinDate Then
                            e.Row.Cells(i + 1).Text = ""
                        Else
                            e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                        End If
                    End If
                End If
                If strFieldName.ToLower = "trxno" Or strFieldName.ToLower = "ritrxno" Or strFieldName.ToLower = "rolineitemno" Or strFieldName.ToLower = "sotrxno" Or strFieldName.ToLower = "solineitemno" Then
                    If e.Row.Cells(i + 1).Text.Trim = 0 Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
            Next
            'Row cann't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            imgDelete.Visible = False

            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            imgRestore.Visible = False
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            imgEdit.Visible = False
            e.Row.Attributes.Add("ondblclick", "EditDetail('" + ContainerNo + "','" + strFun + "');return false;")
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            imgInsert.Visible = False
            If e.Row.RowIndex = objList.ArrProp.Count - 1 And objColumns.Column.Count > 0 Then
                For i = 0 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).Text = " "
                Next
            End If
        End If
    End Sub

End Class
