Imports System
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic.ZZMessage

Partial Class Inventory2
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private returnValue As String
    Private strhidVal As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile("Impm1_Inventory2", gvwSource, TemplateType.ListPrint, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Public Overloads Sub RaiseCallbackEvent(ByVal eventArgument As String)
        returnValue = eventArgument
    End Sub
 
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsInventory(strUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "Inventory"
        Me.MyGridView = gvwSource
        Me.CurrentSortField = "ProductCode Desc"
        Me.SortDesc = False
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

    Private Sub SetInitValue(ByVal intUserId As String, ByVal userName As String)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
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
            'Set Default Value  
            SetInitValue(objUser.UserId, objUser.UserId)
            'New Object 
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            'If Session("LoginType") = 0 Then
            Dim strwhere As String = ""
            If Request("productcode") IsNot Nothing Then
                If Request("productcode").ToString().Trim() <> "" Then
                    strwhere += " and a.ProductCode = '" + Request("productcode").ToString().Trim() + "'"
                End If
            End If
            If Request("BatchNo") IsNot Nothing Then
                strwhere += " and isnull(a.BatchNo,'') = '" + Request("BatchNo").ToString().Trim() + "'"
            End If
            If Request("DateFrom") IsNot Nothing Then
                If Request("DateFrom").ToString.Trim <> "" Then
                    strwhere += " and Convert(varchar(10), a.movementdate, 20) >='" + ConvertDate(Request("DateFrom").ToString.Replace("@", "/").Trim) + "' "
                End If
            End If
            If Request("DateTo") IsNot Nothing Then
                If Request("DateTo").ToString.Trim <> "" Then
                    strwhere += " and Convert(varchar(10), a.movementdate, 20) <='" + ConvertDate(Request("DateTo").ToString.Replace("@", "/").Trim) + "' "
                End If
            End If
            If Request("DimensionFlag") IsNot Nothing Then
                If Request("DimensionFlag").ToString().Trim() <> "" Then
                    objList.Condition = Request("DimensionFlag").ToString().Trim()
                End If
            End If
            objList.Where = strwhere
            objList.OrderBy = "" 'System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting")
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            'Language 
            HandleLanguageRelative()
            'Set First Focused Control
            'txtSearch.Focus() 
        End If
    End Sub
    Private Function ConvertDate(ByVal strVal As String) As String
        If strVal.Length = 10 Then
            Return strVal.Substring(6, 4) + "-" + strVal.Substring(3, 2) + "-" + strVal.Substring(0, 2)
        Else
            Return ""
        End If
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Style.Add("display", "none")
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn

        If e.Row.RowType = DataControlRowType.Header Then
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                If _ColumnInfo.FieldName.ToLower = "opening" Then
                    e.Row.Cells(i + 1).Visible = "false"
                End If
                e.Row.Cells(i + 1).Attributes.Remove("onclick")
            Next
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'Popupmenu
            If objList.Query = "Impm1_Movement" Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event,1);return false;")
            End If
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                If _ColumnInfo.FieldName.ToLower() = "stockout" Then
                    If IsNumeric(e.Row.Cells(i + 1).Text) Then
                        If Integer.Parse(e.Row.Cells(i + 1).Text) < 0 Then
                            e.Row.Cells(i + 1).Text = -Integer.Parse(e.Row.Cells(i + 1).Text)
                        End If
                    End If
                End If
                Dim str1 As String = _ColumnInfo.FieldName.ToLower
                If _ColumnInfo.FieldName.ToLower = "movementdate" Then
                    Select Case _ColumnInfo.FieldType
                        'DateTime
                        Case DbType.Date, DbType.DateTime
                            strFieldName = _ColumnInfo.FieldName
                            Dim str As String = CType(tmpProp, clsPropWMS).MovementDate.ToString
                            If str <> "" Then
                                Dim dtmTemp As DateTime = CType(tmpProp, clsPropWMS).MovementDate
                                If dtmTemp <= ConDateTime.MinDate Then
                                    e.Row.Cells(i + 1).Text = ""
                                Else
                                    e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                                End If
                            End If
                    End Select
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
End Class
