Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Class TypeSort
    Inherits ListEditPage
    Dim strMod As String = ""
    Private strTable As String = ""
    Private strOrder As String = ""
    Private strwhere As String = ""
    Private strCode As String = ""
    Private strName As String = ""
    Private showCode As String = ""
    Private showName As String = ""
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        GetRequestValue()
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsTypeSort(strUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "TypeSort"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "AirlineCode"
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


    Private Sub GetRequestValue()
        strTable = Request("table").ToString
        Dim arrfields As String() = Request("fields").ToString.Split(",")
        strCode = arrfields(0)
        strOrder = arrfields(0).Replace("distinct", "")
        strName = arrfields(1)
        strwhere = Request("where").ToString
        If strwhere.Trim <> "" Then
            strwhere = strwhere
        End If
        If Request("showCode") IsNot Nothing Then
            showCode = Request("showCode").ToString
        End If
        If Request("showName") IsNot Nothing Then
            showName = Request("showName").ToString
        End If
        objList.Fields = Request("fields").ToString.Replace(",", " as code,") + " as name"
        objList.TableNames = Request("table").ToString
        objList.Where = strwhere
        If showCode = "Contact Code" Or showCode = "Airline Code" Then
            strOrder = strName
        Else
            strOrder = strCode
        End If
        strOrder = strOrder.Replace("distinct", "")
        strOrder = strOrder.Replace("a.", "")
        objList.OrderBy = strOrder
    End Sub
    Private Sub BindDrop()
        If showCode = "Contact Code" Or showCode = "Airline Code" Then
            drpSearch.Items.Insert(0, New ListItem(showName, strName))
        Else
            drpSearch.Items.Insert(0, New ListItem(showCode, strCode))
            drpSearch.Items.Insert(1, New ListItem(showName, strName))
        End If
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

            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            ''Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            btnClose.Attributes.Add("OnClick", "CloseWindow(0);return false;")
            'Language 
            HandleLanguageRelative()
            BindDrop()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = showCode
            e.Row.Cells(1).Text = showName
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                e.Row.Visible = False
            End If
            e.Row.Attributes.Add("OnClick", "ItemClick('" + e.Row.Cells(0).Text.Replace("'", "\'") + "','" + e.Row.Cells(1).Text.Replace("'", "\'") + "');return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
        End If

    End Sub

End Class
