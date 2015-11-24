Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic

Partial Class Booking
    Inherits ListEditPage
    Private objAttach As clsAttach
    Dim strMod As String = ""
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.Where += "  and statuscode not in ('cls','del') "
        If Session("LoginType") = 0 Then
            objList.Where += "  and customercode='" + objUser.UserId + "' "
        End If
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp ' BindFromGridSet(objColumns, objList.Where) '
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
  
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsBooking(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Omtx1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "TrxNo"
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
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">" + CStr(GetGlobalResourceObject("Common", "EditColumn")) + "</div> " + strReturn
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
            If _ColumnInfo.FieldName.Trim = "BalancePcsTotal" Then
                _ColumnInfo.FieldName = "BalancePcs"
            End If
            Select Case _ColumnInfo.FieldType
                Case DbType.String
                    drpSearch.Items.Add(New ListItem(_ColumnInfo.FieldTitle, _ColumnInfo.FieldName + ",0"))
                Case Else
                    drpSearch.Items.Add(New ListItem(_ColumnInfo.FieldTitle, _ColumnInfo.FieldName + ",1"))
            End Select
            drpSearch.SelectedValue = CurrentSortField
        Next
    End Sub

    '//set Tab Role
    Private Sub setTabRole(ByVal objUser As clsUser)
        Try
            If objUser.UserId <> "" Then
                Dim dt As DataTable
                Dim clsUser As New clsUser
                dt = clsUser.ListSub(objUser.RoleName, PageFun.GetFunNo(Page))
                Dim i As Integer
                For i = dt.Rows.Count - 1 To 1 Step -1
                    Dim SubId As String = Integer.Parse(dt.Rows(i)(0).ToString)
                    If SubId >= 8 Then
                        'For k As Integer = 8 To 0 Step -1
                        '    Dim lbl1 As Label = FindControl("a" + (k + 1).ToString)
                        '    lbl1.CssClass = "f12c navNml noSep"
                        'Next
                        For k As Integer = 9 To 0 Step -1
                            Dim lbl1 As Label = FindControl("a" + (k + 1).ToString)
                            lbl1.CssClass = "f12c navNml noSep"
                        Next
                        Dim lbl As New Label
                        Select Case SubId
                            Case "8"
                                lbl = FindControl("a4")
                            Case "9"
                                lbl = FindControl("a5")
                            Case "10"
                                lbl = FindControl("a6")
                            Case "11"
                                lbl = FindControl("a7")
                            Case "12"
                                lbl = FindControl("a8")
                            Case "13"
                                lbl = FindControl("a9")
                            Case "14"
                                lbl = FindControl("a2")
                            Case "15"
                                lbl = FindControl("a3")
                            Case "16"
                                lbl = FindControl("a1")
                            Case "17"
                                lbl = FindControl("a10")
                        End Select
                        lbl.CssClass = "f12c navNml noSep"
                        'Tab control
                        If dt.Rows(i).Item(0).ToString = "16" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and modulecode in ('SE','SI','SF') "
                        ElseIf dt.Rows(i).Item(0).ToString = "15" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and modulecode in ('TP') "
                        ElseIf dt.Rows(i).Item(0).ToString = "14" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and modulecode in ('AE','AI','AF') "
                        ElseIf dt.Rows(i).Item(0).ToString = "13" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and modulecode ='AE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "12" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and OrderType not in ('M','S','F','P') and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "11" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and OrderType ='P' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "10" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and OrderType ='F' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "9" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and OrderType ='S' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "8" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and OrderType ='M' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "
                        ElseIf dt.Rows(i).Item(0).ToString = "17" Then
                            lbl.Style.Clear()
                            lbl.CssClass = "f12e navNml navOn"
                            objList.Where = " and (OrderType in ('M','S','F','P') or modulecode = 'AE') and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' "

                        End If
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
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
            hidReports.Value = ""
            BindAttach(objUser.UserId, 0)

            'New Object 
            'If objUser.RoleName.IndexOf("admin") > -1 Or objUser.RoleName.IndexOf("Administrator") > -1 Or objUser.RoleName.Trim = "Customer" Then
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            '//set Tab Role
            setTabRole(objUser)
            'Get First Page Data
            'BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Init Search List Field
            InitSearchListField()
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryDataBook(); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryDataBook();return false;")
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
            btnGridColumnSet.Attributes.Add("OnClick", "GridColumnSet();return false;")
            'GridColumnSet()
            'Language 
            HandleLanguageRelative()
            'Popup Menu 
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        'e.Row.Cells(0).Style.Add("width", "800px")
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            'KeyValue 
            Dim intTrxNo As Integer
            Dim strModuleCode As String
            'strChangeClass=cls
            Dim strOrderNo As String
            strOrderNo = CType(tmpProp, clsPropBooking).OrderNo
            intTrxNo = CType(tmpProp, clsPropBooking).TrxNo
            strModuleCode = CType(tmpProp, clsPropBooking).ModuleCode
            'Popupmenu
            If intTrxNo > 0 Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event," + intTrxNo.ToString() + ");return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                If _ColumnInfo.FieldName <> "PickupdateTime" Then
                    Select Case _ColumnInfo.FieldType
                        'DateTime
                        Case DbType.Date, DbType.DateTime
                            strFieldName = _ColumnInfo.FieldName
                            If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                                Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                                If dtmTemp <= ConDateTime.MinDate Then
                                    e.Row.Cells(i + 1).Text = ""
                                Else
                                    e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                                End If
                            End If
                        Case DbType.Date, DbType.Decimal
                            strFieldName = _ColumnInfo.FieldName
                            Dim str As String = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                            If str <> "" Then
                                Dim dtmTemp As Decimal = Decimal.Parse(str)
                                Dim strWt As Decimal = Decimal.Round(dtmTemp, 3)
                                If strWt <> 0.0 Then
                                    e.Row.Cells(i + 1).Text = strWt
                                Else
                                    e.Row.Cells(i + 1).Text = ""
                                End If
                            End If
                    End Select
                Else
                    Select Case _ColumnInfo.FieldType
                        'DateTime
                        Case DbType.Date, DbType.DateTime
                            strFieldName = _ColumnInfo.FieldName
                            Dim str As String = CType(tmpProp, clsPropBooking).PickupDateTime.ToString
                            If str <> "" Then
                                Dim dtmTemp As DateTime = CType(tmpProp, clsPropBooking).PickupDateTime
                                If dtmTemp <= ConDateTime.MinDate Then
                                    e.Row.Cells(i + 1).Text = ""
                                Else
                                    e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy HH:mm")
                                End If
                            End If
                    End Select
                End If
                'Trx No 
                If _ColumnInfo.FieldName = "TrxNo" Then
                    If intTrxNo <= 0 Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
            Next
            'Row(cann) 't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 Then 'AndAlso Not tmpProp.IsAdd
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            imgRestore.Visible = False
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 Then
                imgEdit.Attributes.Add("OnClick", "EditDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgEdit.Visible = False
            End If
            e.Row.Attributes.Add("ondblclick", "EditDetail(" + intTrxNo.ToString() + ");return false;")
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail();return false;")
            Else
                imgInsert.Visible = False
            End If
            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            If (intTrxNo > 0) AndAlso objList.PrintPrivilege Then
                imgPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ",'" + hidReports.Value + "');return false;")
            Else
                imgPrint.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                imgDelete.Visible = False
                imgEdit.Visible = False
                e.Row.Attributes.Remove("ondblclick")
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                For i = 1 To objColumns.Column.Count
                    e.Row.Cells(i).Text = ""
                Next
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If
    End Sub

    Private Sub BindAttach(ByVal intUserId As String, ByVal intTrxNo As Int64)
        objAttach = New clsAttach(intUserId, intTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Report/CustomerServices/omtx/"), "")
        Dim arr As ArrayList = objAttach.ArrProp
        If arr.Count = 2 Then
            Dim tmpProp As clsProp = arr(0)
            hidReports.Value += CType(tmpProp, clsPropAttach).FileName.Replace(".rpt", "")
        Else
            For i As Integer = 0 To arr.Count - 2
                Dim tmpProp As clsProp = arr(i)
                hidReports.Value += CType(tmpProp, clsPropAttach).FileName.Replace(".rpt", "") + ","
            Next
        End If

    End Sub

    Protected Sub gvwSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.SelectedIndexChanged

    End Sub
End Class
