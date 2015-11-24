Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ZZMessage

Class DoubleSelectPage
    Inherits ListEditPage
    Dim strMod As String = ""
    Dim arrPara As String = ""
    Private strTable As String = ""
    Private strOrderBy As String = ""
    Private strCondition As String = ""
    Private strCode As String = ""
    Private strName As String = ""
    Private showCode As String = ""
    Private showName As String = ""
    Private numFile As Integer
    Private type As String = ""

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
        arrPara = Request("arrPara").ToString
        numFile = Request("numFile").ToString
        arrPara = arrPara.Replace("$1$2!^$", "@")
        type = Request("type").ToString
        Dim paraList As String() = arrPara.Split("@")
        If (type = "CurrRate") Then
            objList.Condition1 = paraList(0)
            objList.Where = paraList(1)
            objList.OrderBy = paraList(2)
            showCode = paraList(3)
            showName = paraList(4)
            objList.Condition = "CurrRate"
        ElseIf (type = "DestCode") Then
            strCode = "distinct DestCode"
            strName = "b.CityName"
            objList.TableNames = " sebl1 a" & _
                                 " left join rcct1 b on b.CityCode=a.DestCode"
            objList.Where = " and isnull(DestCode,'')!=''"
            objList.OrderBy = "b.CityName"
            showCode = "Destination Code"
            showName = "Destination Name"
        Else
            strCode = paraList(0)
            strName = paraList(1)
            objList.TableNames = paraList(2)
            objList.Where = paraList(3)
            objList.OrderBy = paraList(4)
            showCode = paraList(5)
            showName = paraList(6)
        End If
        If numFile = 2 Then
            objList.Fields = strCode + " as code," + strName + " as name"
        Else
            objList.Fields = strCode + " as code"
        End If

    End Sub
    Private Sub BindDrop()
        drpSearch.Items.Insert(0, New ListItem(showCode, strCode))
        If numFile = 2 Then
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
            ''New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            ''Get First Page Data
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
            If numFile = 2 Then
                e.Row.Cells(1).Text = showName
            End If
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
