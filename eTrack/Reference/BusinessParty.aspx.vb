Imports System
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic

Partial Class BusinessParty
    Inherits ListEditPage
    Dim strMod As String = ""

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.Where += "  and statuscode not in ('cls','del') "
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("rcbp1", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsBusinessParty(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "rcbp1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "BusinessPartyCode"
        Me.SortDesc = True
    End Sub

    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Edit MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""DeleteDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "DeleteRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Print MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""PrintDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "PrintRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
        popupMenu.InnerHtml = strOperate
    End Sub

    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        btnAdvSearch.Text = CStr(GetGlobalResourceObject("PageList", "AdvSearch"))
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
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
            'bylin
            Dim strFunNo As String = (PageFun.GetFunNo(Page)).ToString
            '-----byRoot
            Session("FunNo") = strFunNo
            '-----End
            'New Object 
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'objList.Where =
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Init Search List Field
            InitSearchListField()
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            btnAdvSearch.Attributes.Add("OnClick", "OpenAdvSearch('" + TableName + "'," + GeneralFun.BoolAsIntString(objList.FieldPrefix) + ");return false;")
            ''Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.InfoSize, False))
            'Language 
            HandleLanguageRelative()
            'Popup Menu 
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Visible = False
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            'KeyValue 
            Dim strBusinessPartyCode As String
            strBusinessPartyCode = CType(tmpProp, clsPropBusinessParty).BusinessPartyCode

            'Popupmenu
            If strBusinessPartyCode <> "" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event," + strBusinessPartyCode.ToString() + ");return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        Dim strFieldName As String = _ColumnInfo.FieldName
                        Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If dtmTemp <= ConDateTime.MinDate Then
                            e.Row.Cells(i + 1).Text = ""
                        Else
                            e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                        End If
                End Select
            Next
            'Row(cann) 't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDetail('" + strBusinessPartyCode + "');return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail('" + strBusinessPartyCode + "');return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgEdit.Attributes.Add("OnClick", "EditDetail('" + strBusinessPartyCode + "');return false;")
                e.Row.Attributes.Add("ondblclick", "EditDetail('" + strBusinessPartyCode + "');return false;")
            Else
                imgEdit.Visible = False
            End If
            e.Row.Attributes.Add("ondblclick", "EditDetail('" + strBusinessPartyCode + "');return false;")
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail();return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail();return false;")
            Else
                imgInsert.Visible = False
            End If
            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            If (strBusinessPartyCode <> "") AndAlso objList.PrintPrivilege Then
                imgPrint.Attributes.Add("OnClick", "PrintDetail('" + strBusinessPartyCode + "');return false;")
            Else
                imgPrint.Visible = False
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If
    End Sub
End Class
