Imports SysMagic.ExportExcel
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Threading
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SysMagic.SystemClass
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.IO

Namespace ZZPage
    Public MustInherit Class QueryPage
        Inherits LanguagePage
        Implements ICallbackEventHandler
        ' Methods
        Protected Overridable Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
            Me.intPageIndex = intPage
            If (Not Me.objList Is Nothing) Then
                Dim myGridView As GridView = Me.MyGridView
                Me.MyGridView = myGridView
                Me.objColumns = DynamicGridViewFun.GetColumnFromXmlFile(Me.TableName, myGridView, TemplateType.None)
                Me.MyGridView.DataSource = Me.objList.GetPageList(Me.intPageIndex, intSize)
                Me.MyGridView.DataBind()
                Me.intPageCount = Me.objList.PageCount
                Return True
            End If
            Return False
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
            str2 = ((str2 & str3 & "var strQuery="""";") & str3 & "var strWhere="""";")
            str2 = String.Concat(New String() {str2, str3, "var SortField=""", Me.CurrentSortField, """;"})
            Return String.Concat(New String() {str2, str3, "var SortDesc=", GeneralFun.BoolAsIntString(Me.SortDesc), ";"})
        End Function

        Public Function GetPageData(ByVal strPage As String, ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String, ByVal strCondition As String) As String
            Dim objUser As clsUser = Nothing
            If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                Me.objList = DirectCast(Me.NewObjectList(objUser.UserId, PageFun.GetFunNo(Me.Page)), clsQuery)
                Me.objList.Query = strQuery
                Me.objList.Where = strWhere
                Dim strMsg As String = ""
                If Not Me.objList.DecodeQueryCondition(strCondition, strMsg) Then
                    If (strMsg = "") Then
                        strMsg = ConMsgInfo.UnmatchedParam
                    End If
                    Return (ConMsgRtn.Err & ConSeparator.Par & strMsg)
                End If
                Me.CurrentSortField = strSortField
                Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
                Me.intPageIndex = Short.Parse(strPage)
                Me.BindSourceData(objUser.UserId, Me.intPageIndex, objUser.PagePara.InfoSize)
                If Not Me._MyRepeater Is Nothing Then
                    Return String.Concat(New String() {ConMsgRtn.Ok, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, GridViewFun.RenderControl(Me._MyRepeater), ConSeparator.Par, Me.GetResultTitle})
                Else
                    Return String.Concat(New String() {ConMsgRtn.Ok, ConSeparator.Par, Me.intPageCount.ToString, ConSeparator.Par, GridViewFun.RenderControl(Me._MyGridView), ConSeparator.Par, Me.GetResultTitle})
                End If
            End If
            Return (ConMsgRtn.TimeOut & ConSeparator.Par & ConMsgInfo.TimeOut)
        End Function
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Protected Overridable Function GetResultTitle() As String
            Return Conversions.ToString(Me.GetLocalResourceObject("lblResultTitle.Text"))
        End Function

        Protected Sub gvwSource_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If ((Not Me.objColumns Is Nothing) AndAlso (e.Row.RowType = DataControlRowType.Header)) Then
                Dim num2 As Integer = (Me.objColumns.Column.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    Dim column As clsPropColumn = DirectCast(Me.objColumns.Column.Item(i), clsPropColumn)
                    If (column.SortField <> "") Then
                        If (Me.CurrentSortField.IndexOf(column.SortField) >= 0) Then
                            e.Row.Cells.Item(i).Attributes.Add("OnClick", String.Concat(New String() {"GetSortPageData(""", column.SortField, """,", GeneralFun.BoolAsIntString(Not Me.SortDesc), ");return false;"}))
                            If (column.HeaderImageUrl = "") Then
                                Dim child As New Label
                                child.Text = column.FieldTitle
                                e.Row.Cells.Item(i).Controls.Add(child)
                            End If
                            e.Row.Cells.Item(i).Controls.Add(GridViewFun.GetSortImage(Me.SortDesc))
                        Else
                            e.Row.Cells.Item(i).Attributes.Add("OnClick", ("GetSortPageData(""" & column.SortField & """,0);return false;"))
                        End If
                    End If
                    i += 1
                Loop
            End If
        End Sub

        Protected MustOverride Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList

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

        Public Function ServerExportExcel(ByVal strQuery As String, ByVal strWhere As String, ByVal strSortField As String, ByVal strSortDesc As String, ByVal strCondition As String) As String
            Dim str As String
            Try
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
                Dim export As New ExcelExport
                export.CleanUpTemporaryFiles()
                Dim objUser As clsUser = Nothing
                If PageFun.GetCurrentUserInfo(Me.Page, objUser) Then
                    Me.objList = DirectCast(Me.NewObjectList(objUser.UserId, PageFun.GetFunNo(Me.Page)), clsQuery)
                    Me.objList.Query = strQuery
                    Me.objList.Where = strWhere
                    Dim strMsg As String = ""
                    If strCondition <> "" Then
                        If Not Me.objList.DecodeQueryCondition(strCondition, strMsg) Then
                            Return ""
                        End If
                    End If
                    Me.CurrentSortField = strSortField
                    Me.SortDesc = GeneralFun.IntStringAsBool(strSortDesc)
                    Me.objList.OrderBy = SqlRelation.GetOrderString(strSortField, Me.SortDesc)
                    Me.objColumns = DynamicGridViewFun.GetColumnFromXmlFile(Me.TableName, False)
                    Dim str2 As String = export.TransformDataTableToExcel(Me.objList.GetAllList, Me.objColumns)
                    Dim str4 As String = (HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\")
                    Return ("..\" & str2.Substring(str4.Length)).Replace("\", "/")
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


        ' Properties
        Protected Property CurrentSortField() As String
            Get
                Return Me._SortField
            End Get
            Set(ByVal value As String)
                Me._SortField = value
            End Set
        End Property
        Protected Property MyRepeater() As Repeater
            Get
                Return Me._MyRepeater
            End Get
            Set(ByVal value As Repeater)
                'If (Not Me._MyGridView Is Nothing) Then
                '    RemoveHandler Me._MyRepeater.RowCreated, New GridViewRowEventHandler(AddressOf Me.gvwSource_RowCreated)
                'End If
                Me._MyRepeater = value
                ' AddHandler Me._MyRepeater.RowCreated, New GridViewRowEventHandler(AddressOf Me.gvwSource_RowCreated)
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
            End Set
        End Property


        ' Fields
        Private _MyRepeater As Repeater
        Private _MyGridView As GridView
        Private _SortDesc As Boolean = False
        Private _SortField As String = ""
        Private _TableName As String
        Public intPageCount As Integer = 1
        Public intPageIndex As Integer = 1
        Public objColumns As colColumn
        Public objList As clsQuery
        Private returnValue As String
    End Class
End Namespace

