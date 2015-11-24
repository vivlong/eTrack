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
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic

Partial Class Manifest
    Inherits ListEditPage
    Dim strMod As String = ""
    Private strhidVal As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.Where += "  and statuscode not in ('cls','del') "
        strhidVal = Session("hidVal")
        Dim strSess As String = Session("hidVal_Manifest")
        If strSess = 1 Then
            If Session("LoginType") = 0 Then
                objList.Where += "  and customercode='" + objUser.UserId + "' "
            End If
            objList.Query = "Sebl1_Manifest"
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Sebl1_Manifest", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        ElseIf strSess = 2 Then
            If Session("LoginType") = 0 Then
                objList.Where += "  and actualshippercode='" + objUser.UserId + "' "
            End If
            objList.Query = "Aeaw1_Manifest"
            objList.GetListInfo(intPage, intSize)
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Aeaw1_Manifest", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        End If
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsManifest(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Sebl1_Manifest"
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
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        drpSearch1.Items.Insert(0, New ListItem(ListItemSelect, ""))
        drpSearch2.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Dim strSql1 As String = "  select sFieldName,(select top 1 sEnglishTitle from GridSet a where a.sFieldName=b.sFieldName) as sEnglishTitle" & _
        " ,(select top 1 sFieldType from GridSet a where a.sTableName=b.sTableName) as sFieldType " & _
        " from GridSet_Person b  where sTableName='Sebl1_Manifest' and bFieldVisible=1 order by sEnglishTitle"
        Dim strSql2 As String = "  select sFieldName,(select top 1 sEnglishTitle from GridSet a where a.sFieldName=b.sFieldName) as sEnglishTitle" & _
        " ,(select top 1 sFieldType from GridSet a where a.sTableName=b.sTableName) as sFieldType " & _
        " from GridSet_Person b  where sTableName='Aeaw1_Manifest' and bFieldVisible=1 order by sEnglishTitle "
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        dt1 = BaseSelectSrvr.GetData(strSql1, "")
        dt2 = BaseSelectSrvr.GetData(strSql2, "")
        'amfq1
        If dt1.Rows.Count <= 0 Then
            strSql1 = " select sFieldName,sEnglishTitle,sFieldType from GridSet where sTableName='Sebl1_Manifest' order by sEnglishTitle"
            dt1 = BaseSelectSrvr.GetData(strSql1, "")
        End If
        Dim FieldTitle1 As String
        Dim FieldName1 As String
        Dim strType1 As String
        Dim i As Integer
        For i = 0 To dt1.Rows.Count - 1
            FieldTitle1 = dt1.Rows(i)("sEnglishTitle").ToString.Trim
            FieldName1 = dt1.Rows(i)("sFieldName").ToString.Trim
            strType1 = dt1.Rows(i)("sFieldName").ToString.Trim
            Select Case strType1
                Case "nvarchar"
                    drpSearch1.Items.Insert(i + 1, New ListItem(FieldTitle1, FieldName1 + ",0"))
                Case Else
                    drpSearch1.Items.Insert(i + 1, New ListItem(FieldTitle1, FieldName1 + ",1"))
            End Select
        Next i
        'smfq1
        If dt2.Rows.Count <= 0 Then
            strSql2 = " select sFieldName,sEnglishTitle,sFieldType from GridSet where sTableName='Aeaw1_Manifest' order by sEnglishTitle"
            dt2 = BaseSelectSrvr.GetData(strSql2, "")
        End If
        Dim FieldTitle2 As String
        Dim FieldName2 As String
        Dim strType2 As String
        For i = 0 To dt2.Rows.Count - 1
            FieldTitle2 = dt2.Rows(i)("sEnglishTitle").ToString.Trim
            FieldName2 = dt2.Rows(i)("sFieldName").ToString.Trim
            strType2 = dt2.Rows(i)("sFieldName").ToString.Trim
            Select Case strType2
                Case "nvarchar"
                    drpSearch2.Items.Insert(i + 1, New ListItem(FieldTitle2, FieldName2 + ",0"))
                Case Else
                    drpSearch2.Items.Insert(i + 1, New ListItem(FieldTitle2, FieldName2 + ",1"))
            End Select
        Next i
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
            Session("hidVal_Manifest") = "1"
            divdrpSearch1.Style.Clear()
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'objList.Where =
            'Get First Page Data
            Dim dtRight As DataTable = clsUser.ListSub(objUser.RoleName, PageFun.GetFunNo(Page))
            Dim hidArr As Boolean() = {True, True}
            Dim objArr As Label() = {FindControl("a1"), FindControl("a2")}
            Dim drpArr As HtmlControls.HtmlGenericControl() = {divdrpSearch1, divdrpSearch2}
            Dim tabName As String() = {"Sebl1_Manifest", "Aeaw1_Manifest"}
            For i As Integer = 0 To dtRight.Rows.Count - 1
                Dim RightNo As String = dtRight.Rows(i)(0).ToString
                Select Case RightNo
                    Case "4"
                        hidArr(0) = False
                    Case "5"
                        hidArr(1) = False
                End Select
            Next
            Dim FirstTabFlag As Boolean = False
            For i As Integer = 0 To hidArr.Length - 1
                If hidArr(i) = False Then
                    objArr(i).CssClass = "f12c navNml noSep"
                    If FirstTabFlag = False Then
                        objArr(i).Style.Clear()
                        objArr(i).CssClass = "f12e navNml navOn"
                        drpArr(i).Style.Value = "display: block;"
                        ClientScript.RegisterStartupScript(Me.GetType(), "var", "<script>TableName='" + tabName(i) + "';</script>")
                        Session("hidVal_Manifest") = (i + 1).ToString
                        BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                        FirstTabFlag = True
                    End If
                Else
                    objArr(i).Style.Add("display", "none")
                    drpArr(i).Style.Value = "display: none;"
                End If
            Next
            ' BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
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
    Public Function SetTabVal(ByVal hidVal As String) As String
        Dim ConMsgRtn As New ZZMessage.ConMsgRtn
        Session("hidVal_Manifest") = hidVal
        hidVal_Manifest.Value = hidVal
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(hidVal_Manifest)
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        'e.Row.Cells(0).Visible = False
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            Dim strAwbNo As String = ""
            If objList.Query = "Sebl1_Manifest" Then
                strAwbNo = CType(tmpProp, clsPropManifest).TrxNo
            ElseIf objList.Query = "Aeaw1_Manifest" Then
                strAwbNo = CType(tmpProp, clsPropManifest).AwbNo
            End If

            'Popupmenu
            e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event,'" + strAwbNo.ToString() + "');return false;")
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        strFieldName = _ColumnInfo.FieldName
                        If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing) <> "" Then
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
                'Trx No 
                If _ColumnInfo.FieldName = "strAwbNo" Then
                    If strAwbNo <= 0 Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
            Next
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
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            imgInsert.Visible = False

            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            If objList.Query = "Sebl1_Manifest" Then
                imgPrint.Attributes.Add("OnClick", "PrintCrystalReport('rptSebl12-2l.rpt','{vw_sebl1.Trx No}','" + strAwbNo + "','Int');return false;")
            ElseIf objList.Query = "Aeaw1_Manifest" Then
                imgPrint.Attributes.Add("OnClick", "PrintCrystalReport('rptAeaw15.rpt','{vw_aeaw1.Awb No}','" + strAwbNo + "','Char');return false;")
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                imgPrint.Visible = False
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If

    End Sub
End Class
