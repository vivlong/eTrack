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

Partial Class UserAnalysis
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Dim strMod As String = ""
    Private strhidVal As String
    Private returnValue As String
    Public Overloads Function GetCallbackResult() As String
        Dim arrParam As String() = GeneralFun.GetPar(returnValue)
        Select Case arrParam.Length
            Case 1
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, Nothing))
            Case Else
                Dim arrObject(arrParam.Length - 2) As Object
                Dim i As Integer
                For i = 0 To arrParam.Length - 2
                    arrObject(i) = arrParam(i + 1)
                Next
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, arrObject))
        End Select
    End Function

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Jmjm1_Verification", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsUserAnalysis(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Jmjm1_Verification"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "JobNo"
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

        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub InitSearchListField()
        'Date090328
        Dim theYear As New ArrayList
        Dim theMonth As New ArrayList
        Dim strMonth As String
        Dim i As Integer
        For i = 2008 To 2020
            theYear.Add(i.ToString())
        Next
        For i = 1 To 12
            strMonth = i.ToString
            If i < 10 Then
                strMonth = "0" + i.ToString
            End If
            theMonth.Add(strMonth)
        Next
        drYear.DataSource = theYear
        drYear.DataBind()
        drMonth.DataSource = theMonth
        drMonth.DataBind()
        drYear.Text = Now.Year.ToString
        Dim strM As String = Now.Month.ToString
        If Integer.Parse(strM) < 10 Then
            strM = "0" + strM
        End If
        drMonth.Text = strM
        'drpType1
        drpType1.Items.Add(New ListItem("Booking", "Booking"))
        drpType1.Items.Add(New ListItem("Job", "Job"))
        drpType1.Items.Add(New ListItem("Invoice", "Invoice"))
        'drpType1
        drpType2.Items.Add(New ListItem("Air", "Air"))
        drpType2.Items.Add(New ListItem("Sea", "Sea"))
        drpType2.Items.Add(New ListItem("Transport", "Transport"))
        'drShow
        drShow.Items.Add(New ListItem("Job Without Billing", "1"))
        drShow.Items.Add(New ListItem("Job With Payment But No Invoice", "2"))
        drShow.Items.Add(New ListItem("Job Without Accrual Cost", "3"))
        drShow.Items.Add(New ListItem("Transhipment without Export Job", "4"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            '-----End
            'New Object 
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            Session("hidVal_UserAnalysis") = "1"
            gvwSource.Style.Add("display", "none")

            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'objList.Where =
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Init Search List Field
            InitSearchListField()
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryDatalin(" + txtSearch.ClientID + "); return false;}")
            btnSearch.Attributes.Add("OnClick", "return false;")
            ''Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")

            drpType1.Attributes.Add("onchange", "DropDownBind(" + drpType1.ClientID + ");return false;")
            drShow.Attributes.Add("onchange", "Showcb(" + drShow.ClientID + ");return false;")

            btnDateFrom.Attributes.Add("OnClick", "showCalendar(txtDateFrom,0);return false;")
            btnDateTo.Attributes.Add("OnClick", "showCalendar(txtDateTo,0);return false;")

            btnQuery.Attributes.Add("OnClick", "GetQueryData(" + hid_val.Value + ");return false;") '
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
        Session("hidVal_UserAnalysis") = hidVal
        InitSearchListField()
        hidVal_UserAnalysis.Value = hidVal
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(hidVal_UserAnalysis)
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Visible = False
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            Dim strAwbNo As String
            strAwbNo = CType(tmpProp, clsPropUserAnalysis).JobNo
            'Popupmenu
            If strAwbNo > "" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event,'" + strAwbNo.ToString() + "');return false;")
            End If
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
            'e.Row.Attributes.Add("ondblclick", "EditDetail(" + intAwbNo.ToString() + ");return false;")
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
            imgPrint.Visible = False
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If

    End Sub
    'Bind DrowDown Data 
    Public Function BindDrowDown(ByVal strTrxNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        drpType2.Items.Clear()
        If strTrxNo = "Booking" Then
            'drpType1
            drpType2.Items.Add(New ListItem("Air", "Air"))
            drpType2.Items.Add(New ListItem("Sea", "Sea"))
            drpType2.Items.Add(New ListItem("Transport", "Transport"))
        Else
            'drpType2
            drpType2.Items.Clear()
            drpType2.Items.Add(New ListItem("All", "All"))
            drpType2.Items.Add(New ListItem("Air Export", "Air Export"))
            drpType2.Items.Add(New ListItem("Air Import", "Air Import"))
            drpType2.Items.Add(New ListItem("Sea Export", "Sea Export"))
            drpType2.Items.Add(New ListItem("Sea Import", "Sea Import"))
            drpType2.Items.Add(New ListItem("Transport", "Transport"))
            drpType2.Items.Add(New ListItem("Miscellaneous", "Miscellaneous"))
        End If
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drpType2)
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    'Bind DrowDown Data 
    Public Function ShowCheckBox(ByVal strFlag As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        drpType2.Items.Clear()
        If strFlag = "Booking" Then
            'drpType1
            drpType2.Items.Add(New ListItem("Air", "Air"))
            drpType2.Items.Add(New ListItem("Sea", "Sea"))
            drpType2.Items.Add(New ListItem("Transport", "Transport"))
        Else
            'drpType2
            drpType2.Items.Clear()
            drpType2.Items.Add(New ListItem("All", "All"))
            drpType2.Items.Add(New ListItem("Air Export", "Air Export"))
            drpType2.Items.Add(New ListItem("Air Import", "Air Import"))
            drpType2.Items.Add(New ListItem("Sea Export", "Sea Export"))
            drpType2.Items.Add(New ListItem("Sea Import", "Sea Import"))
            drpType2.Items.Add(New ListItem("Transport", "Transport"))
            drpType2.Items.Add(New ListItem("Miscellaneous", "Miscellaneous"))
        End If
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(drpType2)
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
End Class
