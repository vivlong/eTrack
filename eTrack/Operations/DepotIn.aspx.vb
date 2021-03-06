﻿Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports Ntools
Imports SysMagic

Partial Class DepotIn
    Inherits ListEditPage
    Protected ConfigPath As String
    Protected ExportConfig As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        Dim strFun As String = PageFun.GetFunNo(Page)
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        End If
        objList.Where += " and a.TrxNo not in (select TrxNo from ctso1 where sitecode!='" + objUser.SiteCode + "')"
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsSO2(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctso2"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Me.CurrentSortField = "TrxNo desc ,lineitemno desc"
        Me.SortDesc = False
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
            If Not (Request("Id") Is Nothing) Then
                Me.Title = "Receive Container : " + Request("Id").ToString
            Else
                Me.Title = "New"
            End If
            'New Object 
            If objUser.RoleName.IndexOf("admin") > -1 Or objUser.RoleName.IndexOf("Administrator") > -1 Or objUser.RoleName.Trim = "Customer" Then
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            Else
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            End If
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
        'e.Row.Cells(0).Style.Add("display", "none")
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim strBatchNo As String = CType(tmpProp, clsPropSO2).ReceiveBatchNo.ToString()
            Dim strTrxNo As String = CType(tmpProp, clsPropSO2).TrxNo.ToString()
            Dim strLineItemNo As String = CType(tmpProp, clsPropSO2).LineItemNo.ToString()
            Dim RvFlag As String = CType(tmpProp, clsPropSO2).RvFlag
            'Popupmenu
            If strBatchNo <> "" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu('" + strTrxNo + "123456789" + strLineItemNo + "');return false;")
            End If
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
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                strFieldName = _ColumnInfo.FieldName
                If strFieldName.ToLower = "state" Then
                    e.Row.Cells(i + 1).Text = tool.showState(e.Row.Cells(i + 1).Text)
                ElseIf _ColumnInfo.FieldType = DbType.Date Or _ColumnInfo.FieldType = DbType.DateTime Then
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
                If strFieldName.ToLower = "receivedate" Then
                    If RvFlag <> "Y" Then
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
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteCTSO2('" + strBatchNo + "');return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail('" + strBatchNo + "');return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgEdit.Attributes.Add("OnClick", "EditDetail('" + strBatchNo + "','" + strFun + "');return false;")

            Else
                imgEdit.Visible = False
            End If
            e.Row.Attributes.Add("ondblclick", "EditDetail('" + strBatchNo + "','" + strFun + "');return false;")
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail(" + ");return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail(" + ");return false;")
            ElseIf tmpProp.IsAdd Then
                e.Row.Visible = False
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                For i = 1 To objColumns.Column.Count - 1
                    e.Row.Cells(i).Text = ""
                Next
            End If
            'If strTrxNo > 0 Then
            '    Dim objUser As clsUser = Nothing
            '    If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            '    End If
            '    Dim dt As DataTable
            '    dt = BaseSelectSrvr.GetData("select sitecode from ctso1 where trxno=" + strTrxNo, "")
            '    Dim SiteCode As String = dt.Rows(0)("sitecode").ToString
            '    If SiteCode.Trim <> objUser.SiteCode.Trim Then
            '        e.Row.Style.Add("display", "none")
            '    End If
            'End If
        End If
    End Sub

    Public Function DeleteCTSO2(ByVal strBatchNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData("select TrxNo from ctso2 where ReceiveBatchNo='" + strBatchNo + "'", "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dtCtcl As DataTable
                        dtCtcl = BaseSelectSrvr.GetData("select TrxNo from ctcl1 where SOTrxNo=" + dt.Rows(i)("TrxNo").ToString, "")
                        If dtCtcl IsNot Nothing Then
                            If dtCtcl.Rows.Count > 0 Then
                                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Some Container under this SO have Receive.." + ConSeparator.Par + Me.intPageCount.ToString
                            End If
                        End If
                    Next
                End If
            End If
            If Not FDeleteCTSO2(strBatchNo, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record." + ConSeparator.Par + Me.intPageCount.ToString
            Else
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + Me.intPageCount.ToString
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + Me.intPageCount.ToString
        End If
    End Function

    Public Function FDeleteCTSO2(ByVal strBatchNo As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete ctso2 where ReceiveBatchNo='" + strBatchNo + "'"
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        Else
            Return False
        End If
    End Function
End Class
