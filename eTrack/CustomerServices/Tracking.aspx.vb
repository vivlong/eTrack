Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic.ZZMessage
Imports System.Reflection
Imports SysMagic

Partial Class Tracking
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private dtTmplin As DataTable
    Private returnValue As String
    Public strFields As String = ""
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        objList.Where += "  and statuscode not in ('cls','del') "
        If Session("LoginType") = 0 Then
            Dim strWhere As String
            strWhere = SqlRelation.GetStringWhere(" and a.CustomerCode", objUser.UserId, 1)
            objList.Condition1 = strWhere
            objList.DataBase = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
            fldLoginType.Value = 0
        ElseIf Session("LoginType") = 3 Then '20151111
            Dim strWhere As String
            strWhere = SqlRelation.GetStringWhere(" and a.ConsigneeCode", objUser.UserId, 1)
            objList.Condition1 = strWhere
            objList.DataBase = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
            fldLoginType.Value = 3
        ElseIf Session("LoginType") = 2 And objUser.LoginType.ToUpper = "OA" Then 'sclee 20140624
            Dim strWhere As String
            strWhere = SqlRelation.GetStringWhere(" and a.DeliveryAgentCode", objUser.UserId, 1)
            objList.Condition1 = strWhere
            objList.DataBase = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
            fldLoginType.Value = 2
        ElseIf Session("LoginType") = 2 And objUser.LoginType.ToUpper = "WH" Then
            objList.DataBase = Session("Database")
            Session("CustType") = "WH"
            fldLoginType.Value = 2
        Else
            objList.DataBase = Session("Database")
            fldLoginType.Value = 1
        End If
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        'sclee 20140626
        If objUser.LoginType = "WH" Then
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Jmjm1_eTrackWH", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        Else
            objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        End If
        'objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsTracking(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "jmjm1"
        Me.MyGridView = gvwSource
        Me.CurrentSortField = "JobNo"
        Me.SortDesc = False
        Me.ColumnFrom = ColumnFile.Sql
    End Sub
    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        '  btnAdvSearch.Text = CStr(GetGlobalResourceObject("PageList", "AdvSearch"))
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
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.NewPrivilege Then
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
    Private Sub SetInitValue(ByVal intUserId As String)
        'Search
        drpSearch.Items.Clear()
        drpSearch.Items.Add(New ListItem("Job No", "JobNo"))
        drpSearch.Items.Add(New ListItem("MAwb/OBL No", "MawbOBLNo"))
        drpSearch.Items.Add(New ListItem("Awb/BL No", "AwbBlNo"))
        drpSearch.Items.Add(New ListItem("Container No", "ContainerNo"))
        drpSearch.Items.Add(New ListItem("Reference No", "CustomerRefNo"))
        If Session("LoginType") <> 0 Then 'for customer login
            drpSearch.Items.Add(New ListItem("Customer Code", "CustomerCode"))
        End If
        drpSearch.Items.Add(New ListItem("Shipper Name", "ShipperName"))
        drpSearch.Items.Add(New ListItem("Consignee Name", "ConsigneeName"))

        'From 
        drpFrom.Items.Clear()
        drpFrom.Items.Add(New ListItem("ETD", "ETD"))
        drpFrom.Items.Add(New ListItem("ETA", "ETA"))
        drpFrom.Items.Add(New ListItem("Origin", "OriginCode"))
        drpFrom.Items.Add(New ListItem("Destination", "DestCode"))
        drpFrom.Attributes.Add("onchange", "javascript:fromchange();return false")
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
            fldCustomerCode.Value = objUser.UserId
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            If Session("LoginType") = 0 Then
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere(" and a.CustomerCode", objUser.UserId, 1)
            ElseIf Session("LoginType") = 3 Then '20151111
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere(" and a.ConsigneeCode", objUser.UserId, 1)
            End If
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(); return false;}")
            ''javascript:if(event.keyCode==115){showCalendar(txtFrom,0); return false;}
            txtFrom.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(); return false;}")
            txtTo.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(); return false;}")
            btnFrom.Attributes.Add("OnClick", "showCalendar(txtFrom,0);return false;")
            btnTo.Attributes.Add("OnClick", "showCalendar(txtTo,0);return false;")
            btnSearch.Attributes.Add("OnClick", "GetQueryData();return false;")
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsTracking).AssemblyQualifiedName, TableName, 1, True))
            btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))
            btnSearchSebl.Attributes.Add("OnClick", "ShowGvwData('sea');return false;")
            btnSearchAiaw.Attributes.Add("OnClick", "ShowGvwData('air');return false;")

            btnCargoSebl.Attributes.Add("OnClick", "ShowCargoData('sea');return false;")
            btnCargoAiaw.Attributes.Add("OnClick", "ShowCargoData('air');return false;")

            btnMultiGridColumnSet.Attributes.Add("OnClick", "GridColumnSet();return false;")
            'sclee 20140626 hide "custome" if warehouseuser"
            If objUser.LoginType.ToUpper = "WH" Then
                btnMultiGridColumnSet.Visible = False
            Else
                btnMultiGridColumnSet.Visible = True
            End If

            'Language 
            HandleLanguageRelative()
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub
#Region "Tab1"
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Visible = False

        Dim i As Integer
        If e.Row.RowType = DataControlRowType.Header Then
            Dim tmpColumn As clsPropColumn
            For i = 0 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                If tmpColumn.FieldName.ToLower() = "attachmentflag" Then
                    e.Row.Cells(i).Width = 10
                    e.Row.Cells(i).Text = "<img alt='pic' src='../Images/Sms/attach.gif' />"
                End If
            Next
            '---------------HardCode--090904-----------------------------
            If Session("strFiles") IsNot Nothing Then
                strFields = Session("strFiles").ToString
                strFields = strFields.Replace("as N'", "")
                strFields = strFields.Replace("'", "")
            End If

            If strFields.Trim <> "" Then
                Dim arrfiels() As String = strFields.Split(",")
                For Each sinField As String In arrfiels
                    If sinField <> "" Then
                        Dim tc As New TableCell
                        tc.Text = sinField
                        tc.Font.Bold = True
                        e.Row.Cells.Add(tc)
                    End If
                Next
            End If
            '---------------HardCode--090904-----------------------------
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim strJobNo As String = CType(tmpProp, clsPropTracking).JobNo
            Dim strModuleCode As String = CType(tmpProp, clsPropTracking).ModuleCode
            Dim strDBName As String = CType(tmpProp, clsPropTracking).DBName
            '###################################################################################
            '---------------HardCode--090904-----------------------------
            If Session("strFiles") IsNot Nothing Then
                strFields = Session("strFiles").ToString
                strFields = strFields.Replace("as N'", "")
                strFields = strFields.Replace("'", "")
            End If

            If strFields.Trim <> "" Then

                '---------------HardCode--090904-----------------------------
                Dim strSql As String = "select distinct a.statuscode ,b.Bcolor_A,b.Bcolor_G,b.Bcolor_B  from " + strDBName + ".dbo.jmjm3 a left join " & _
                                       "" + strDBName + ".dbo.jmjs1 b on a.statuscode=b.jobstatuscode where a.jobno='" + strJobNo + "'"
                Dim dt As DataTable
                dt = BaseSelectSrvr.GetData(strSql, "")
                Dim arrfiels() As String = strFields.Split(",")
                For Each sinField As String In arrfiels
                    If sinField <> "" Then
                        Dim tc As New TableCell
                        If dt IsNot Nothing Then
                            If dt.Rows.Count > 0 Then
                                If CheckNull(dt.Rows(0)(1)) >= 0 And CheckNull(dt.Rows(0)(2)) >= 0 And CheckNull(dt.Rows(0)(3)) >= 0 Then
                                    tc.BackColor = Color.FromArgb(CheckNull(dt.Rows(0)(1)), CheckNull(dt.Rows(0).Item(2)), CheckNull(dt.Rows(0).Item(3)))
                                End If
                            End If
                        End If
                        e.Row.Cells.Add(tc)
                    End If
                Next
                'For i = objColumns.Column.Count To gvwSource.Columns.Count - 1
                '    If dt IsNot Nothing Then
                '        If dt.Rows.Count > 0 Then
                '            For j As Integer = 0 To dt.Rows.Count - 1
                '                If gvwSource.Columns(i).HeaderText.ToLower = CheckNull(dt.Rows(j)("statuscode")).ToLower Then

                '                    e.Row.Cells(i).BackColor = Color.FromArgb(CheckNull(dt.Rows(j)(1)), CheckNull(dt.Rows(j).Item(2)), CheckNull(dt.Rows(j).Item(3)))
                '                End If
                '            Next
                '        End If
                '    End If
                'Next
            End If
            '###################################################################################
            'Popupmenu
            If strJobNo <> "" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event,'" + strJobNo + "');return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value-------------------------------------
            Dim tmpColumn As clsPropColumn
            For i = 1 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                '------------------------------------------------------------------------------------------------------------------------------------------------------
                Select Case strModuleCode
                    Case "AE", "AI"
                        Dim strFunUrl As String = "CustomerServices/AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo="
                        Dim strUrl As String = GetReferencePage("", strFunUrl + strJobNo, strJobNo, ReferenceTarget.VesselSchedule)
                        If strJobNo.Trim <> "" Then
                            e.Row.Attributes.Add("ondblclick", strUrl)
                        End If
                        'If strJobNo.Trim <> "" Then
                        '    e.Row.Cells(i).Text = e.Row.Cells(i).Text.Replace(strJobNo, strUrl)
                        'End If
                    Case "SE", "SI"
                        Dim strFunUrl As String = "CustomerServices/SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo="
                        Dim strUrl As String = GetReferencePage("", strFunUrl + strJobNo, strJobNo, ReferenceTarget.VesselSchedule)
                        If strJobNo.Trim <> "" Then
                            e.Row.Attributes.Add("ondblclick", strUrl)
                        End If
                End Select
                '------------------------------------------------------------------------------------------------------------------------------------------------------
                If tmpColumn.FieldName.ToLower() = "attachmentflag" Then
                    e.Row.Cells(i).Width = 10
                    Dim strAttachmentFlag As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AttachmentFlag"))
                    If strAttachmentFlag = "Y" Then
                        e.Row.Cells(i).Text = "<img alt='pic' src='../Images/Sms/attach.gif' />"
                    End If
                End If
                '----------------------------------------------------------------------------------------------------------------
                Select Case tmpColumn.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        Dim strFieldName As String = tmpColumn.FieldName
                        Dim strfield As String = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If strfield <> "" Then
                            Dim dtmTemp As DateTime = strfield
                            If dtmTemp <= ConDateTime.MinDate Then
                                e.Row.Cells(i + 1).Text = ""
                            Else
                                e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                            End If
                        End If
                End Select
                'Trx No 
                If tmpColumn.FieldName = "TrxNo" Then
                    If strJobNo <> "" Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
                '----------------------------------------------------------------------------------------------------------------
            Next
            'Row(cann) 't be select-----------------------------------------------------
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 Then 'AndAlso Not tmpProp.IsAdd
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + strJobNo + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            imgRestore.Visible = False
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            imgEdit.Visible = False
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail();return false;")
            Else
                imgInsert.Visible = False
            End If
            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            imgPrint.Visible = False

            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                imgDelete.Visible = False
                imgEdit.Visible = False
                e.Row.Attributes.Remove("ondblclick")
            Else
                imgInsert.Visible = False
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If
    End Sub
    Private Function GetReferencePage(ByVal strPrefix As String, ByVal strPage As String, ByVal strReference As String, ByVal enumTarget As ReferenceTarget) As String
        Return strPrefix + "AirSeaDetail('" + PageFun.GetWaitingPage(strPage, 1) + "',800,600)"
        'Return strPrefix + "<A href=""javascript:AirSeaDetail('" + PageFun.GetWaitingPage(strPage, 1) + "',800,600);"">" + strReference + "</A>"
    End Function

    Private Function CheckNull(ByVal obj As Object) As Integer
        If IsNumeric(obj) Then
            Return Integer.Parse(obj.ToString)
        Else
            Return -1
        End If
    End Function
#End Region
#Region "Tab2"
    Public Function BindGvwData(ByVal objFlag As String, ByVal txtValue As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ""
        End If
        divSource2.Style.Add("display", "block")
        Dim ConMsgRtn As New ZZMessage.ConMsgRtn
        Dim strWhere As String
        Dim strField As String
        If objFlag = "sea" Then
            strField = " b.BlNo"
        Else
            strField = " b.AWBNo"
        End If
        strWhere = " and " + strField + " like '%" + txtValue + "%'"
        Dim strsql As String = ""
        Dim strsql2 As String = ""
        If objFlag = "sea" Then
            strsql = "SELECT JobNo,BLNo,FrtPpCcFlag,vesselName,EtaDate,DestCode," & _
                     "CommodityDescription,TotalPcs,TotalGrossWeight,TotalVolume, " & _
                     "seaexportflag,airexportflag,trxno FROM Sibl1 b WHERE  statuscode<>'DEL' and " & _
                     "transhipmentflag='Y' " + strWhere
            strsql2 = "SELECT BookingNo" & _
                     ",(select top 1 isnull(jobno,'') from aeaw1 where bookingno=a.bookingno) as jobno" & _
                     ",(select top 1 isnull(AWBNo,'') from aeaw1 where bookingno=a.bookingno) as BlAwbNo" & _
                     ",FirstFlightNo as vesselname,FirstFlightDate as etddate" & _
                     ",(select top 1 convert(nvarchar(10),arrivaldatetime,103) as arrivaldate " & _
                     " from aeaw1  where bookingno=a.bookingno) as Etadate, a.DeliveryAgentName,'Ae' as module  " & _
                     "FROM aebk1 a left join Sibl1 b on b.JobNo=a.ImportJobNo " & _
                     "where 1=1  " + strWhere
            If Session("LoginType") = 0 Then
                strsql += "and b.customercode='" + objUser.UserId + "'"
            ElseIf Session("LoginType") = 3 Then '20151111
                strsql += "and b.ConsigneeCode='" + objUser.UserId + "'"
            ElseIf Session("LoginType") = 2 And objUser.LoginType.ToUpper = "OA" Then
                strsql += "and b.DeliveryAgentCode='" + objUser.UserId + "'"
            End If
        Else
            strsql = "select * from Aiaw1 b where TranshipmentFlag='Y' and StatusCode !='DEL' " + strWhere
            'strsql2 = "select * from Aebk1 "
            If Session("LoginType") = 0 Then
                strsql += "and customercode='" + objUser.UserId + "'"
            ElseIf Session("LoginType") = 3 Then '20151111
                strsql += "and b.ConsigneeCode='" + objUser.UserId + "'"
            ElseIf Session("LoginType") = 2 And objUser.LoginType.ToUpper = "OA" Then
                strsql += "and DeliveryAgentCode='" + objUser.UserId + "'"
            End If
        End If
        Dim dt As New DataTable
        dt = BaseSelectSrvr.GetData(strsql, "")
        Dim dt2 As New DataTable
        dt2 = BaseSelectSrvr.GetData(strsql2, "")
        If dt IsNot Nothing Then
            If objFlag = "sea" Then
                objColumns = DynamicGridViewFun.GetColumnFromXmlFile("Sibl1_Transhipment", gvwSourceTS, TemplateType.None)
                'Sebk1_Transhiipment Sibl1_Transhiipment
            Else
                objColumns = DynamicGridViewFun.GetColumnFromXmlFile("Aiaw1_Transhipment", gvwSourceTS, TemplateType.None)
            End If
            gvwSourceTS.DataSource = dt
            gvwSourceTS.DataBind()
            gvwSourceDown.DataSource = dt2
            gvwSourceDown.DataBind()
        End If
        Dim str As String = GridViewFun.RenderControl(gvwSourceTS)
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSourceTS) + ConSeparator.Par + GridViewFun.RenderControl(gvwSourceDown)
    End Function
    Public Function BindDownGridBack(ByVal strJobNo As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strsql As String = " SELECT BookingNo,JobNo,(select top 1 isnull(blno,'') " & _
            " from sebl1 " & _
            " where bookingno=sebk1.bookingno) as BlAwbNo," & _
            " vesselname," & _
            " convert(char(20),EtdDate,20) EtdDate," & _
            " convert(char(20),EtaDate,20) EtaDate," & _
            " DeliveryAgentName," & _
            " 'Se' as [Module]" & _
            " FROM sebk1" & _
            " WHERE importjobno = '" + strJobNo + "' " & _
            " union " & _
            " SELECT BookingNo,(select top 1 isnull(jobno,'') " & _
            " from aeaw1 " & _
            " where bookingno=aebk1.bookingno) as jobno, " & _
            " (select top 1 isnull(AWBNo,'')  " & _
            " from aeaw1 where bookingno=aebk1.bookingno) as BlAwbNo,FirstFlightNo,FirstFlightDate, " & _
            " (select top 1 convert(nvarchar(10),arrivaldatetime,103) as arrivaldate  " & _
            " from aeaw1 " & _
            " where bookingno=aebk1.bookingno) as arrivaldate, DeliveryAgentName,'Ae' " & _
            " FROM Aebk1 " & _
            " WHERE importjobno = '" + strJobNo + "'"
            Dim dt As New DataTable
            'sea
            dt = BaseSelectSrvr.GetData(strsql, "")
            DynamicGridViewFun.GetColumnFromXmlFile("Sebk1_Aebk1_Transhipment", gvwSourceDown, TemplateType.None)
            gvwSourceDown.DataSource = dt
            gvwSourceDown.DataBind()
            Dim str As String = GridViewFun.RenderControl(gvwSourceDown)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSourceDown)
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Protected Sub gvwSourceTS_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells(0).Text = "<a onclick=""javascript:BindDownGrid('" + e.Row.Cells(0).Text.Trim() + """);ruturn false;'>" + e.Row.Cells(0).Text + "</a>"
            'Row color <a onclick=""javascript:BindDownGrid('" + e.Row.Cells(0).Text.Trim() + """);ruturn false;'>" + e.Row.Cells(0).Text + "</a>
            Dim tmpColumn As clsPropColumn
            Dim i As Integer
            For i = 0 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                If tmpColumn.FieldName.ToLower() = "jobno" Then
                    e.Row.Cells(i).Text = "<a onclick=""BindTrackDownGrid('" + e.Row.Cells(0).Text + "')"");ruturn false;'>" + e.Row.Cells(0).Text + "</a>"
                End If
            Next
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
    End Sub
    Protected Sub gvwSourceDown_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
    End Sub
    Public Function ShowCargoDatabac(ByVal objFlag As String, ByVal txtValue As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ""
        End If
        divSource2.Style.Add("display", "block")
        Dim ConMsgRtn As New ZZMessage.ConMsgRtn
        Dim strWhere As String
        Dim strField As String
        If objFlag = "sea" Then
            strField = " BlNo"
        Else
            strField = " AWBNo"
        End If
        strWhere = " and " + strField + " = '" + txtValue + "'"
        Dim strsql As String = ""
        If objFlag = "sea" Then
            strsql = "select top 1 HblNo,VesselCode,PortofLoadingCode,convert(char(20),EtdDate,20) EtdDate,PortofDischargeCode,convert(char(20),EtaDate,20) EtaDate,'' as ArrivedPortOf,DeliveryOrderReadyFlag" & _
                     ",DeliveryOrderReleaseDate,DeliveryOrderReleaseTo,'' as collectByConsignee,ContainerNo,ContainerSealNo from sibl1 where 1=1 " + strWhere
            'Me.CurrentSortField = "JobNo"
            If Session("LoginType") = 0 Then
                strsql += "and customercode='" + objUser.UserId + "'"
            ElseIf Session("LoginType") = 3 Then '20151111
                strsql += "and ConsigneeCode='" + objUser.UserId + "'"
            End If
            'strsql2 = "select * from sebk1 where   StatusCode !='DEL' "
        Else
            'strsql = "select * from Aiaw1 b where TranshipmentFlag='Y' and StatusCode !='DEL' " + strWhere
            ''strsql2 = "select * from Aebk1 "
        End If
        Dim dt As New DataTable
        dt = BaseSelectSrvr.GetData(strsql, "")
        Dim sbCargo As New StringBuilder
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                txtHouseBLNumber.Text = dt.Rows(0)("HblNo").ToString
                txtVslDetails.Text = dt.Rows(0)("VesselCode").ToString
                txtPortOfLoading.Text = dt.Rows(0)("PortofLoadingCode").ToString
                txtETDPOL.Text = ConvertToDate(dt.Rows(0)("EtdDate"))
                txtPortofDischarge.Text = dt.Rows(0)("PortofDischargeCode").ToString
                txtETAPOD.Text = ConvertToDate(dt.Rows(0)("EtaDate"))
                txtCargoArrive.Text = dt.Rows(0)("ArrivedPortOf").ToString
                txtDeliveryOrderready.Text = dt.Rows(0)("DeliveryOrderReadyFlag").ToString
                txtDeliveryOrdercollected.Text = ConvertToDate(dt.Rows(0)("DeliveryOrderReleaseDate")) + " " + dt.Rows(0)("DeliveryOrderReleaseTo").ToString
                txtCargocollectby.Text = dt.Rows(0)("collectByConsignee").ToString
                txtContainerNo.Text = dt.Rows(0)("ContainerNo").ToString
                txtSealNo.Text = dt.Rows(0)("ContainerSealNo").ToString
            Else
                txtHouseBLNumber.Text = ""
                txtVslDetails.Text = ""
                txtPortOfLoading.Text = ""
                txtETDPOL.Text = ""
                txtPortofDischarge.Text = ""
                txtETAPOD.Text = ""
                txtCargoArrive.Text = ""
                txtDeliveryOrderready.Text = ""
                txtDeliveryOrdercollected.Text = ""
                txtCargocollectby.Text = ""
                txtContainerNo.Text = ""
                txtSealNo.Text = ""
            End If
        End If
        Dim sb As New StringBuilder
        sb.Append(ConMsgRtn.Ok + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtHouseBLNumber) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtVslDetails) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtPortOfLoading) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtETDPOL) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtPortofDischarge) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtETAPOD) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtCargoArrive) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtDeliveryOrderready) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtDeliveryOrdercollected) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtCargocollectby) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtContainerNo) + ConSeparator.Par)
        sb.Append(GridViewFun.RenderControl(txtSealNo) + ConSeparator.Par)
        Return sb.ToString
    End Function
    Private Function ConvertToDate(ByVal strobj As Object) As String
        Dim StrForma As String = ""
        If strobj.ToString.Trim <> "" Then
            StrForma = Date.Parse(strobj).ToString("dd/MM/yyyy")
        End If
        Return StrForma
    End Function
    Public Function SetTabVal(ByVal hidVal As String) As String
        Dim ConMsgRtn As New ZZMessage.ConMsgRtn
        hidVal_Tracking.Value = hidVal
        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(hidVal_Tracking)
    End Function

#End Region
#Region "Tab3"

#End Region
End Class
