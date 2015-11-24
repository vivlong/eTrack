Imports System.Web.UI.WebControls
Imports System.Text

Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Imports SysMagic

Partial Class GridSet
    Inherits ListEditPage
    Private objServer As clsGridSet
    Private RvFlag As String = "N"
    Private PubReceiveBatchNo As String = ""
    Protected ConfigPath As String
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub  'Inherits System.Web.UI.Page
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsGridSet(intUserId)
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            hidBatchNo.Value = ""
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            Dim strFun As String = PageFun.GetFunNo(Page)
            objList = NewObjectList(objUser.UserId, objUser.RoleName, strFun)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            HandleLanguageRelative()
            InitSearchListField()
            'Assign Search Event
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(); return false;}")
            btnSearch.Attributes.Add("OnClick", "GetQueryData();return false;")
            ''Assign Page Event and Relative Value
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")

            '  HandlePopupMenu()
        End If
    End Sub
    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        ' popupMenu.InnerHtml = strOperate
    End Sub
#Region "Grid View GridSet"
    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        'btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        'btnAdvSearch.Text = CStr(GetGlobalResourceObject("PageList", "AdvSearch"))
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub
    Private Sub InitSearchListField()
        drpSearch.Items.Insert(0, New ListItem("Field Name", "sFieldName"))
        drpSearch.Items.Insert(0, New ListItem("Table Name", "sTableName"))
    End Sub
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.None, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsGridSet(intUserId, RoleName, strFunNo)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "GridSet"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "sTableName"
        Me.SortDesc = True
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
            For i As Integer = 0 To gvwSource.Columns.Count - 1
                e.Row.Cells(i).Controls.Clear()
            Next
        End If
        If e.Row.RowType = DataControlRowType.Header AndAlso e.Row.RowIndex > 0 Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim objUser As clsUser = Nothing
            PageFun.GetCurrentUserInfo(Page, objUser)
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If (objList.NewPrivilege Or objUser.UserId = "sa" Or objUser.UserId.ToLower = "s") AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail(" + ");return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail(" + ");return false;")
            Else
                ' imgInsert.Visible = False
            End If

        End If
    End Sub

    Public Function UpdateGridSet(ByRef sTableName As String, ByRef sFieldName As String, ByRef Field As String, ByRef Value As String) As Integer
        Dim intResult As Integer = -1
        Value = IIf(Value = "", "null", Value)
        Try
            If sTableName.Trim <> "" And sFieldName.Trim <> "" Then
                Dim strSql As String = String.Format(" update GridSet set {0}='{1}' where sTableName='{2}' and sFieldName='{3}' ", Field, Value, sTableName, sFieldName)
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
            End If
        Catch ex As Exception
            intResult = -1
        End Try
        Return intResult
    End Function

    Public Function FIUpdate(ByVal strsql As String, ByVal strTrxNo As String, ByVal strLineitemno As String, ByVal strContainerNO As String, ByVal strCurrentControl As String, ByVal strUpdate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        'Dim dt, dt2 As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strsql <> "" Then
                Dim intflag As String
                strsql = " update GridSet set " + strsql + " where sTableName='" + strTrxNo + "' and sFieldName='" + strLineitemno + "'"
                intflag = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strsql)
                If intflag = 1 Then
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + strCurrentControl '+ ConSeparator.Par + strContainerNO
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false." + ConSeparator.Par + strCurrentControl   ' + ConSeparator.Par + strContainerNO
                End If

            End If
        End If
        Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut + ConSeparator.Par + strCurrentControl + ConSeparator.Par + strContainerNO
    End Function

    Public Function DeleteFI(ByVal sTableName As String, ByVal sFieldName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not FDeleteFI(sTableName, sFieldName, "") Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Private Function FDeleteFI(ByVal sTableName As String, ByVal sFieldName As String, ByRef strMsg As String) As Boolean
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Try
                Dim strSql As String = " delete GridSet where sTableName=" + sTableName + " and sFieldName='" + sFieldName + "'"
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
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
#End Region


End Class
