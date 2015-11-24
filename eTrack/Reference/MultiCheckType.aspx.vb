Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Class MultiCheckType
    Inherits ListEditPage
    Private objServer As clsMultiType
    Dim strMod As String = ""
    Private strSql As String = ""
    Private strSearchCode As String = ""
    Private conField As Integer = 0
    Protected ConfigPath As String
    Protected ExportConfig As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        GetRequestValue()
        intPageIndex = intPage
        objServer = NewServerObject(intUserId)
        objList.GetDataTableInfo(intPage, intSize)
        'Dim NewCol As DataColumn = New DataColumn
        'NewCol.ColumnName = "Select"
        'NewCol.Caption = "Select"
        'NewCol.DataType = System.Type.GetType("System.Boolean")
        'objList.DataTable.Columns.Add(NewCol)
        gvwSource.DataSource = objList.DataTable
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        If conField = 1 Then
            gvwSource.Width = 300
            txtSearch.Width = 220
        End If
        Return True
    End Function
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsMultiType(intUserId)
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsMultiType(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "MultiType"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = ""
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
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst().Replace("EditWidth=", "EditWidth=null").Replace("EditHeight=", "EditHeight=null"))
    End Sub
    Private Sub GetRequestValue()
        If Request("Sql") IsNot Nothing Then
            strSql = Request("Sql").ToString
            strSql = strSql.Replace("%3D", "=")
            If strSql.Trim() <> "" Then
                strSql = strSql.Replace("~~", "@")
                Dim arrSql As String() = strSql.Split("@")
                Dim arrconField As String() = arrSql(0).Split(",")
                conField = arrconField.Length
                If arrSql(2).Trim <> "" Then
                    arrSql(2) = " where " + arrSql(2)
                End If
                strSql = " select distinct " + arrSql(0) + " from " + arrSql(1) + " " + arrSql(2)
            End If
        End If
        If Request("SearchCode") IsNot Nothing Then
            strSearchCode = Request("SearchCode").ToString
        End If
        objList.Query = strSql
    End Sub
    Private Sub BindDrop()
        Dim arrField As String() = strSearchCode.Split("~")
        For Each Str As String In arrField
            If Str.Trim <> "" Then
                Dim arrBind As String() = Str.Split("@")
                drpSearch.Items.Add(New ListItem(arrBind(1), arrBind(0)))
            End If
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
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            ''Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData(" + txtPage.ClientID + ",4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnClose.Attributes.Add("OnClick", "CloseWindow(0);return false;")
            btnOK.Attributes.Add("OnClick", "GetValue();return false;")
            'Language 
            HandleLanguageRelative()
            BindDrop()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If objList.DataTable.Columns.Count > 1 Then
            e.Row.Cells(objList.DataTable.Columns.Count - 1).Style.Add("display", "none")
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            Dim cell As TableCell = New TableCell
            cell.Text = "Select"
            e.Row.Cells.AddAt(0, cell)
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cell As TableCell = New TableCell
            cell.Controls.Add(New CheckBox)
            '  Dim check As CheckBox = New CheckBox
            e.Row.Cells.AddAt(0, cell)

            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                e.Row.Visible = False
            End If
            Dim strItems As String = ""
            For i As Integer = 0 To objList.DataTable.Columns.Count - 1
                strItems += e.Row.Cells(i).Text.Replace("'", "\'") + ","
            Next
            '  e.Row.Attributes.Add("OnClick", "ItemClick('" + strItems + "');return false;")
            'e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            'If e.Row.RowIndex Mod 2 = 0 Then
            '    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            'Else
            '    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            'End If
        End If

    End Sub
End Class
