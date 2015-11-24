Imports System
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic

Partial Class EventTitle
    Inherits ListEditPage
    Dim strMod As String = ""

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        gvwSource.DataSource = GetDataTalble()
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    'Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsBaseSrv
    '    Return New clsEventTitle(intUserId, strFunNo)
    'End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsEventTitle(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "rcal1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "EventTitleCode"
        Me.SortDesc = True
    End Sub

    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
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
            ' If objUser.RoleName.IndexOf("admin") > -1 Or objUser.RoleName.IndexOf("Administrator") > -1 Or objUser.RoleName.Trim = "Customer" Then
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            'Else
            '    objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            'End If
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'objList.Where =
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Init Search List Field 
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")

            btnAdd.Attributes.Add("OnClick", "AddTitle(" + txtSearch.ClientID + ");return false;")

            ''Assign Page Event and Relative Value
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
            'Popup Menu 
            HandlePopupMenu()
            'Set First Focused Control
            txtSearch.Focus()
        End If
    End Sub
    Private Function ConvertDateTime(ByVal strVal As DateTime) As String
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                Return ""
            Else
                Return strVal.ToString("dd/MM/yyyy")
            End If
        Else
            Return ""
        End If
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Dim i As Integer
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value

            'Row(cann) 't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If
    End Sub

    Public Function AddTitle(ByVal title As String) As String
        If IsMutil(title) Then
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "The Title :" + title + " have Exists"
        End If
        Dim msg As String = "save failed"
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "please relogin."
        End If
        Try
            Dim sql As String = String.Format("insert into poev1(Title,CreateBy,CreateDateTime) values('{0}','{1}',getDate())", title, objUser.UserId)
            Dim ret As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sql)
            gvwSource.DataSource = GetDataTalble()
            gvwSource.DataBind()
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
        Catch ex As Exception
            msg = ex.Message
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + msg
    End Function
    '删除
    Public Function DeleteTitle(ByVal trxNo As String) As String
        Dim msg As String = "Delete failed"
        Try
            Dim sql As String = String.Format("Delete poev1 where TrxNo={0}", trxNo)
            Dim ret As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sql)
            gvwSource.DataSource = GetDataTalble()
            gvwSource.DataBind()
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
        Catch ex As Exception
            msg = ex.Message
        End Try
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + msg
    End Function
    Private Function GetDataTalble() As DataTable
        Dim Sql As String = "select * from poev1 order by TrxNo Desc"
        Dim dt As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, Sql)
        If dt IsNot Nothing Then
            Dim tab As DataTable = dt.Tables(0)
            gvwSource.DataSource = tab
            gvwSource.DataBind()
            Return tab
        End If
        Return Nothing
    End Function
    Private Function IsMutil(ByVal title As String) As Boolean
        Dim Sql As String = String.Format("select count(1) from poev1 where title='{0}'", title)
        Dim dt As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, Sql)
        If dt IsNot Nothing Then
            If Integer.Parse(dt.Tables(0).Rows(0)(0)) > 0 Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
