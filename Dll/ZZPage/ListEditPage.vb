Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Threading
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml
Imports SysMagic.SystemClass
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.IO
Imports SysMagic.ExportExcel

Namespace ZZPage
    Public MustInherit Class ListEditPage
        Inherits LanguagePage
        Implements ICallbackEventHandler
        ' Methods
        Protected MustOverride Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean

        Public Function DeleteOneData(ByVal strKeyValue As String, ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String) As String
            Dim strMsg As String = ""
            Dim objUser As clsUser = Nothing
            If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                If IsNumeric(strKeyValue) Then
                    Me.objList.CurrentProp = Me.objList.GetDetail(Long.Parse(strKeyValue))
                Else
                    Me.objList.CurrentProp = Me.objList.GetDetail(strKeyValue)
                End If

                If Me.objList.Delete(strMsg) Then
                    Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    Me.objList.Query = strQuery
                    Me.objList.Where = strWhere
                    Me.CurrentSortField = strSortField
                    Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                    Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
                    Me.intPageIndex = Short.Parse(strPage)
                    Me.BindSourceData(objUser.UserId, Me.intPageIndex, objUser.PagePara.InfoSize)
                    Return String.Concat(New String() {ConMsgRtn.Ok, ConSeparator.Par, strMsg, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, GridViewFun.RenderControl(Me._MyGridView)})
                End If
                Return String.Concat(New String() {ConMsgRtn.Err, ConSeparator.Par, strMsg, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, ""})
            End If
            Return String.Concat(New String() {ConMsgRtn.NoLogin, ConSeparator.Par, ConMsgInfo.NoLogin, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, ""})
        End Function

        Public Function GetCallbackResult() As String Implements ICallbackEventHandler.GetCallbackResult
            Dim par As String() = GeneralFun.GetPar(Me.returnValue)
            If (par.Length = 1) Then
                Return Conversions.ToString(Me.GetType.GetMethod(par(0)).Invoke(Me, Nothing))
            End If
            Dim parameters As Object() = New Object(((par.Length - 2) + 1) - 1) {}
            Dim num3 As Integer = (par.Length - 2)
            Dim i As Integer = 0
            Do While (i <= num3)
                parameters(i) = par((i + 1))
                i += 1
            Loop
            Return Conversions.ToString(Me.GetType.GetMethod(par(0)).Invoke(Me, parameters))
        End Function

        Protected Overrides Function GetOtherJavascriptLanguageConst() As String
            Dim str2 As String = ""
            Dim str3 As String = ChrW(13) & ChrW(10)
            If Me.EditPage Is Nothing Then
                Me.EditPage = "null"
                Me.EditWidth = "-1"
                Me.EditHeight = "-1"
            End If
            str2 = String.Concat(New String() {str2, str3, "var EditPage=""", Me.EditPage, """;"})
            str2 = String.Concat(New String() {str2, str3, "var EditWidth=", Me.EditWidth, ";"})
            str2 = String.Concat(New String() {str2, str3, "var EditHeight=", Me.EditHeight, ";"})
            str2 = String.Concat(New String() {str2, str3, "var TableName=""", Me.TableName, """;"})
            str2 = String.Concat(New String() {str2, str3, "var strQuery=""", Me.objList.Query, """;"})
            str2 = String.Concat(New String() {str2, str3, "var strWhere=""", Me.objList.Where, """;"})
            str2 = String.Concat(New String() {str2, str3, "var SortField=""", Me.CurrentSortField, """;"})
            str2 = String.Concat(New String() {str2, str3, "var strHidCon1=""", 1, """;"})
            str2 = String.Concat(New String() {str2, str3, "var strHidCon2=""", 1, """;"})
            str2 = String.Concat(New String() {str2, str3, "var strHidCon3=""", 1, """;"})
            str2 = String.Concat(New String() {str2, str3, "var MutiTab=""", "", """;"})
            Return String.Concat(New String() {str2, str3, "var SortDesc=", GeneralFun.BoolAsIntString(Me.SortDesc), ";"})
        End Function

        Public Function GetPageData(ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String, ByVal strCondition As String) As String
            Dim objUser As clsUser = Nothing
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                Dim oju As String = objUser.UserId 'by lzw 090616
                Dim pf As String = PageFun.GetFunNo(Me.Page)
                Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                Me.objList.Query = strQuery
                Me.objList.Where = strWhere
                Me.objList.Condition = strCondition
                Me.CurrentSortField = strSortField
                Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
                Me.intPageIndex = Short.Parse(strPage)
                Me.BindSourceData(objUser.UserId, Me.intPageIndex, objUser.PagePara.InfoSize)
                GetPage(objUser, strPage, strQuery, strWhere, strSortField, strSortDesc)
                Return (Me.intPageCount.ToString & ConSeparator.Par & GridViewFun.RenderControl(Me._MyGridView))
            End If
            Return (Me.intPageCount.ToString & ConSeparator.Par)
        End Function
        Private Sub GetPage(ByVal objUser As clsUser, ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String)

        End Sub


        Protected Sub gvwSource_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If ((Not Me.objColumns Is Nothing) AndAlso (e.Row.RowType = DataControlRowType.Header)) Then
                Dim num2 As Integer = (Me.objColumns.Column.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    Dim column As clsPropColumn = DirectCast(Me.objColumns.Column.Item(i), clsPropColumn)
                    If (column.SortField <> "") Then
                        If (Me.CurrentSortField.IndexOf(column.SortField) >= 0) Then
                            e.Row.Cells.Item((i + 1)).Attributes.Add("OnClick", String.Concat(New String() {"GetSortPageData(""", column.SortField, """,", GeneralFun.BoolAsIntString(Not Me.SortDesc), ");return false;"}))
                            If (column.HeaderImageUrl = "") Then
                                Dim child As New Label
                                child.Text = column.FieldTitle
                                e.Row.Cells.Item((i + 1)).Controls.Add(child)
                            End If
                            e.Row.Cells.Item((i + 1)).Controls.Add(GridViewFun.GetSortImage(Me.SortDesc))
                        Else
                            e.Row.Cells.Item((i + 1)).Attributes.Add("OnClick", ("GetSortPageData(""" & column.SortField & """,0);return false;"))
                        End If
                    End If
                    If (IIf((((i = 0) AndAlso Me.objList.NewPrivilege) AndAlso Me.InsertImg), 1, 0) <> 0) Then
                        Dim image As New Image
                        image.ID = "imgInsert"
                        image.AlternateText = "Add"
                        image.ImageUrl = "~/Images/Edit/ed_Insert.gif"
                        image.CssClass = "delImg"
                        image.Attributes.Add("OnClick", "InsertDetail();return false;")
                        e.Row.Cells.Item(i).Controls.Add(image)
                    End If
                    i += 1
                Loop
            End If
        End Sub
        '100315 for judge rolename
        Protected MustOverride Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv

        Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements ICallbackEventHandler.RaiseCallbackEvent
            Me.returnValue = eventArgument
        End Sub
        Public Shared Sub CreateDirectory(ByVal strDirectory As String)
            Try
                If Not Directory.Exists(strDirectory) Then
                    Directory.CreateDirectory(strDirectory)
                End If
            Catch ex As Exception
            End Try
        End Sub
        Public Function ServerExportExcel(ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String) As String
            Try
                Dim strAttachPath As String = Server.MapPath("Print/Temp")
                clsAttachFileDirectory.DeleteAllFile(strAttachPath)
            Catch ex As Exception

            End Try
            Dim LoginType As String = HttpContext.Current.Session.Item("LoginType")
            '<090819 ByZhiWei
            Try
                CreateDirectory(Server.MapPath("../Print/Temp"))
                Dim dirInfo As New DirectoryInfo(Server.MapPath("../Print/Temp"))
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                For Each di As FileInfo In files
                    di.Delete()
                Next
            Catch ex As Exception
            End Try
            '>
            Dim str As String
            Try
                Dim export As New ExcelExport
                export.CleanUpTemporaryFiles()
                Dim objUser As clsUser = Nothing
                If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                    Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    Me.objList.Query = strQuery
                    Me.objList.Where = strWhere
                    Me.CurrentSortField = strSortField
                    Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                    Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)

                    If (Me.ColumnFrom = ColumnFile.Sql) Then
                        Me.objColumns = DynamicGridViewFun.GetColumnExport(Me.TableName, objUser.UserId, False, Me.objList.FieldPrefix, LoginType)
                    Else
                        Me.objColumns = DynamicGridViewFun.GetColumnFromXmlFile(Me.TableName, False)
                    End If
                    Dim str2 As String = export.TransformDataTableToExcel(Me.objList.GetAllList, Me.objColumns)
                    Dim str3 As String = (HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\")
                    Return ("..\" & str2.Substring(str3.Length)).Replace("\", "/")
                End If
                str = ""
            Catch exception1 As ThreadAbortException
                ProjectData.SetProjectError(exception1)
                Dim exception As ThreadAbortException = exception1
                str = ""
                ProjectData.ClearProjectError()
                Return str
                ProjectData.ClearProjectError()
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                str = ""
                ProjectData.ClearProjectError()
                Return str
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function
        Public Function ServerExportEM(ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String, ByVal MutiTab As String, ByVal strCondition As String) As String
            Try
                Dim strAttachPath As String = Server.MapPath("Print/Temp")
                clsAttachFileDirectory.DeleteAllFile(strAttachPath)
            Catch ex As Exception
            End Try
            Dim LoginType As String = HttpContext.Current.Session.Item("LoginType")

            '<090819 ByZhiWei
            Try
                CreateDirectory(Server.MapPath("../Print/Temp"))
                Dim dirInfo As New DirectoryInfo(Server.MapPath("../Print/Temp"))
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                For Each di As FileInfo In files
                    di.Delete()
                Next
            Catch ex As Exception
            End Try
            '>
            Dim str As String
            Try
                Dim export As New ExcelExport
                export.CleanUpTemporaryFiles()
                Dim objUser As clsUser = Nothing
                If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                    Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    Me.objList.Query = strQuery
                    Me.objList.Where = strWhere
                    Me.CurrentSortField = strSortField
                    Me.objList.Condition = strCondition
                    Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                    Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)

                    If (Me.ColumnFrom = ColumnFile.Sql) Then
                        Me.objColumns = DynamicGridViewFun.GetColumnExport(MutiTab, objUser.UserId, False, Me.objList.FieldPrefix, LoginType)
                    Else
                        Me.objColumns = DynamicGridViewFun.GetColumnFromXmlFile(MutiTab, False)
                    End If

                    Dim str2 As String = export.TransformDataTableToExcel(Me.objList.GetAllList, Me.objColumns)
                    Dim str3 As String = (HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\")
                    Return ("..\" & str2.Substring(str3.Length)).Replace("\", "/")
                End If
                str = ""
            Catch exception1 As ThreadAbortException
                ProjectData.SetProjectError(exception1)
                Dim exception As ThreadAbortException = exception1
                str = ""
                ProjectData.ClearProjectError()
                Return str
                ProjectData.ClearProjectError()
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                str = ""
                ProjectData.ClearProjectError()
                Return str
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function
        Protected Overridable Sub SetTableName()
            Dim filename As String = HttpContext.Current.Server.MapPath("../XML/EditPage.xml")
            Dim document As New XmlDocument
            document.Load(filename)
            Dim childNodes As XmlNodeList = document.SelectSingleNode("Page").ChildNodes
            Dim num3 As Integer = (childNodes.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num3)
                Dim node As XmlNode = childNodes.ItemOf(i)
                If (node.NodeType.ToString <> "Comment") Then
                    Dim element As XmlElement = DirectCast(node, XmlElement)
                    If (element.Name = Me._TableName) Then
                        Dim num4 As Integer = (element.ChildNodes.Count - 1)
                        Dim j As Integer = 0
                        Do While (j <= num4)
                            Dim node2 As XmlNode = element.ChildNodes.ItemOf(j)
                            Select Case node2.Name
                                Case "Name"
                                    Me._EditPage = node2.InnerText
                                    Exit Select
                                Case "Width"
                                    Me._EditWidth = node2.InnerText
                                    Exit Select
                                Case "Height"
                                    Me._EditHeight = node2.InnerText
                                    Exit Select
                            End Select
                            j += 1
                        Loop
                        Exit Do
                    End If
                End If
                i += 1
            Loop
        End Sub

        Public Function UndeleteOneData(ByVal strKeyValue As String, ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String) As String
            Dim intId As Long = Short.Parse(strKeyValue)
            Dim strMsg As String = ""
            Dim objUser As clsUser = Nothing
            If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                Me.objList.CurrentProp = Me.objList.GetDetail(intId)
                If Me.objList.Restore(strMsg) Then
                    Me.objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                    Me.objList.Query = strQuery
                    Me.objList.Where = strWhere
                    Me.CurrentSortField = strSortField
                    Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                    Me.intPageIndex = Short.Parse(strPage)
                    Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
                    Me.BindSourceData(objUser.UserId, Me.intPageIndex, objUser.PagePara.InfoSize)
                    Return String.Concat(New String() {ConMsgRtn.Ok, ConSeparator.Par, strMsg, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, GridViewFun.RenderControl(Me._MyGridView)})
                End If
                Return String.Concat(New String() {ConMsgRtn.Err, ConSeparator.Par, strMsg, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, ""})
            End If
            Return String.Concat(New String() {ConMsgRtn.NoLogin, ConSeparator.Par, ConMsgInfo.NoLogin, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, ""})
        End Function
        Public Function BindFromGridSet(ByVal objCol As clsDynamicSqlColumn, ByVal strWhere As String) As DataTable
            Dim sql As String = ""
            Dim col As String = ""
            For i As Integer = 0 To objCol.Column.Count - 1
                col += objCol.Column(i).FieldName + ","
            Next
            col = col.Trim(",")
            sql = "select " + col + " from " + objCol.TableName + " where 1=1 " + strWhere
            Dim dt As DataTable = BaseSelectSrvr.GetData(sql, "")
            ' If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
            '   End If
            Return dt

        End Function

        ' Properties
        Protected Property ColumnFrom() As ColumnFile
            Get
                Return Me._ColumnFrom
            End Get
            Set(ByVal value As ColumnFile)
                Me._ColumnFrom = value
            End Set
        End Property

        Protected Property CurrentSortField() As String
            Get
                Return Me._SortField
            End Get
            Set(ByVal value As String)
                Me._SortField = value
            End Set
        End Property

        Protected Property EditHeight() As String
            Get
                Return Me._EditHeight
            End Get
            Set(ByVal value As String)
                Me._EditHeight = value
            End Set
        End Property

        Protected Property EditPage() As String
            Get
                Return Me._EditPage
            End Get
            Set(ByVal value As String)
                Me._EditPage = value
            End Set
        End Property

        Protected Property EditWidth() As String
            Get
                Return Me._EditWidth
            End Get
            Set(ByVal value As String)
                Me._EditWidth = value
            End Set
        End Property

        Protected Property InsertImg() As Boolean
            Get
                Return Me._InsertImg
            End Get
            Set(ByVal value As Boolean)
                Me._InsertImg = value
            End Set
        End Property

        Protected Property MyGridView() As GridView
            Get
                Return Me._MyGridView
            End Get
            Set(ByVal value As GridView)
                If (Not Me._MyGridView Is Nothing) Then
                    RemoveHandler Me._MyGridView.RowCreated, New GridViewRowEventHandler(AddressOf Me.gvwSource_RowCreated)
                End If
                Me._MyGridView = value
                AddHandler Me._MyGridView.RowCreated, New GridViewRowEventHandler(AddressOf Me.gvwSource_RowCreated)
            End Set
        End Property

        Protected Property SortDesc() As Boolean
            Get
                Return Me._SortDesc
            End Get
            Set(ByVal value As Boolean)
                Me._SortDesc = value
            End Set
        End Property

        Protected Property TableName() As String
            Get
                Return Me._TableName
            End Get
            Set(ByVal value As String)
                Me._TableName = value
                Me.SetTableName()
            End Set
        End Property
        ' Fields
        Private _ColumnFrom As ColumnFile
        Private _EditHeight As String
        Private _EditPage As String
        Private _EditWidth As String
        Private _InsertImg As Boolean = True
        Private _MyGridView As GridView
        Private _SortDesc As Boolean = False
        Private _SortField As String = ""
        Private _TableName As String
        Public intPageCount As Integer = 1
        Public intPageIndex As Integer = 1
        Public objColumns As colColumn
        Public objList As clsBaseSrv
        Private returnValue As String
    End Class
End Namespace

