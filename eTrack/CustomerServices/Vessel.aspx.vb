Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel

Partial Class Vessel
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strbGroup As String = "-1"
    Private StrOninit As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)
        Dim Existbl As Boolean = False
        dtTmplin = dtTmp
        Dim dv As DataView = dtTmp.DefaultView
        For i As Integer = 0 To dv.ToTable.Columns.Count - 1
            If dv.ToTable.Columns(i).ColumnName = "PortofDischargeName" Then
                Existbl = True
            End If
        Next
        If Existbl = True Then
            rpSource.DataSource = dv.ToTable(True, "PortofDischargeName")
        Else
            rpSource.DataSource = dv.ToTable
        End If
        rpSource.DataBind()
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsVessualSchedule_Sebl1(intUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "VesselSchedule_Sibl1"
        '   Me.MyGridView = rpSource
        Me.MyRepeater = rpSource
        'Me.CurrentSortField = "JobNo"
        If Session("LoginType") = 0 Then
            Me.CurrentSortField = "PortofDischargeName"
        Else
            Me.CurrentSortField = "PortofDischargeName"
        End If
        Me.SortDesc = False

    End Sub

    Private Sub HandleLanguageRelative()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Search
        drDuring.Items.Clear()
        drDuring.Items.Add(New ListItem("1", "1"))
        drDuring.Items.Add(New ListItem("2", "2"))
        drDuring.Items.Add(New ListItem("3", "3"))
        drDuring.Items.Add(New ListItem("4", "4"))
        drDuring.Items.Add(New ListItem("5", "5"))
        drDuring.Items.Insert(0, New ListItem(ListItemSelect, "0"))
        'From 
        'To
        Dim dtRec As DataTable
        Dim strSql As String = "Select distinct PortOfDischargeName from Sebl1" & _
                               " where PortOfDischargeName is not null and PortOfDischargeName<>''"
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drPortOfDischarge.DataSource = dtRec
            drPortOfDischarge.DataTextField = "PortOfDischargeName"
            drPortOfDischarge.DataValueField = "PortOfDischargeName"
            drPortOfDischarge.DataBind()
            drPortOfDischarge.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        StrOninit = "N"
        If Not IsPostBack Then
            StrOninit = "Y"
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                If Not PageFun.GetCurrentUserInfo(Page, objUser, "unNeedValid") Then
                End If
            End If

            'Set Default Value
            SetInitValue(objUser.UserId)
            fldCustomerCode.Value = objUser.UserId
            'New Object
            objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            If Session("LoginType") = 0 Then
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.CustomerCode", objUser.UserId, 1)
                objList.Where = "" 'strWhere
                objList.OrderBy = "" 'System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
                fldLoginType.Value = 0
            ElseIf Session("LoginType") = 3 Then '20151111
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.ConsigneeCode", objUser.UserId, 1)
                objList.Where = ""
                objList.OrderBy = ""
                fldLoginType.Value = 3
            Else
                objList.OrderBy = "" ''Session("Database")
                fldLoginType.Value = 1
            End If
            If Request("port") IsNot Nothing Then
                If Request("port").ToString() <> "" Then
                    Dim port As String = Request("port").ToString()
                    divVesselSearch.Style.Add("display", "none")
                    If port.ToLower() <> "all" Then
                        objList.Where = " and PortofDischargeName='" + Request("port").ToString() + "'"
                    End If
                    Try
                        drPortOfDischarge.SelectedValue = Request("port").ToString()
                    Catch ex As Exception
                    End Try
                End If
            End If
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Search Event
            btnDepartureDate.Attributes.Add("OnClick", "showCalendar(txtDepartureDate,0);return false;")
            'btnDepartureDate.Attributes.Add("OnBlur", "hidCalendarForm()")
            'btnTo.Attributes.Add("OnClick", "showCalendar(txtTo,0);return false;")
            btnSearch.Attributes.Add("OnClick", "GetVesuslQueryResult();return false;")
            btnClearField.Attributes.Add("OnClick", "ClearField();return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveField();return false;")
            'Assign Page Event and Relative Value
            btnAddField.Attributes.Add("OnClick", "AddField();return false;")
            'btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(objUser.PagePara.QuerySize, GetType(clsVessualSchedule).AssemblyQualifiedName, TableName, 1, True))
            'btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            btnPrint.Attributes.Add("OnClick", "Print();return false;")
            btnPrintPreview.Attributes.Add("OnClick", "PrintPreview();return false;")
            btnPageSetup.Attributes.Add("OnClick", "PageSetup();return false;")
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim str As String = StrOninit
        If e.Row.RowType = DataControlRowType.DataRow Then
            'order by 
            If objList.Where <> "" Then
                If strbGroup <> e.Row.Cells(4).Text.Trim Then
                    e.Row.Cells(1).Text = e.Row.Cells(4).Text.Trim
                    strbGroup = e.Row.Cells(4).Text.Trim
                    e.Row.Cells(4).Text = ""
                End If
            End If
            'Dim DepartureDate As String = e.Row.Cells(0).Text.Replace("&nbsp;", "")
            'Dim VesselVoyage As String = e.Row.Cells(1).Text.Replace("&nbsp;", "")

            'Dim Carrier As String = e.Row.Cells(2).Text.Replace("&nbsp;", "")
            'Dim PortOfDischarge As String = e.Row.Cells(3).Text.Replace("&nbsp;", "")
            'Dim ArrivalDate As String = e.Row.Cells(4).Text.Replace("&nbsp;", "")
            'Dim DestETA As String = e.Row.Cells(5).Text.Replace("&nbsp;", "")
            'Dim paramete As String = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", "$$$$", DepartureDate, VesselVoyage, Carrier, PortOfDischarge, ArrivalDate, DestETA)
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim i As Integer
            'e.Row.Attributes.Add("ondblclick", "ShowVesselDetail('" + paramete + "');return false;")
            For i = 0 To objColumns.Column.Count - 1
                If e.Row.RowIndex = dtTmplin.Rows.Count Then
                    e.Row.Cells(0).Text = ""
                    e.Row.Cells(1).Text = ""
                    e.Row.Cells(2).Text = ""
                    e.Row.Cells(3).Text = ""
                End If
            Next
        End If
    End Sub

    Protected Sub rpSource_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpSource.ItemDataBound
        Dim lblPOD As New Label
        lblPOD = e.Item.FindControl("lblPOD")
        Dim gvwSource As GridView = e.Item.FindControl("gvwSource")
        Dim dv As DataView = dtTmplin.DefaultView
        With dv
            .RowFilter = "PortofDischargeName = '" + DvRowFilter(lblPOD.Text) + "'"
            .Sort = "PortofDischargeName DESC"
        End With
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = dv
        gvwSource.DataBind()
    End Sub
    Private Function DvRowFilter(ByVal rowFilter As String) As String

        Return rowFilter.Replace("[", "[[ ").Replace("]", " ]]").Replace("*", "[*]").Replace("%", "[%]").Replace("[[ ", "[[]").Replace(" ]]", "[]]").Replace("'", "''")

    End Function
End Class
