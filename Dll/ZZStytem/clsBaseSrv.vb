Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage

Namespace ZZSystem

    Public MustInherit Class clsBaseSrv
        ' Methods
        Public Sub New(ByVal intUserId As String)
            Me._ConnectionString = ConDbConn.ConnectionString
            Me._UserId = intUserId
            Me._Query = ""
            Me._Where = ""
            Me._State = EditState.Insert
            Me._PageCount = 0
            Me._DataBase = ""
            Me._Condition = ""
            Me._Condition1 = ""
            Me._Condition2 = ""
            Me._Fields = ""
            Me._TableNames = ""
            Me.DataTable = Nothing
        End Sub

        Public Sub New(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
            Me._ConnectionString = ConDbConn.ConnectionString
            Me._UserId = strUserId
            Me._Query = ""
            Me._OrderBy = ""
            Me._Where = ""
            Me._DataBase = ""
            Me._Condition = ""
            Me._Condition1 = ""
            Me._Condition2 = ""
            Me._Fields = ""
            Me._TableNames = ""
            Me._State = EditState.Browse
            Me._PageCount = 0
            Me._FunNo = strFunNo
            If RoleName.IndexOf("admin") > -1 Or RoleName.IndexOf("Administrator") > -1 Or RoleName.IndexOf("Customer") > -1 Then
                Me._Privilege = New clsPrivilege(strUserId, RoleName, strFunNo)
            Else
                Me._Privilege = New clsPrivilege(strUserId, strFunNo)
            End If
            Me._NewPrivilege = Me._Privilege.GetPrivilege(ConPrivilegeName.Add)
            Me._EditPrivilege = Me._Privilege.GetPrivilege(ConPrivilegeName.Edit)
            Me._DeletePrivilege = Me._Privilege.GetPrivilege(ConPrivilegeName.Delete)
            Me._RestorePrivilege = Me._Privilege.GetPrivilege(ConPrivilegeName.Restore)
            Me._PrintPrivilege = Me._Privilege.GetPrivilege(ConPrivilegeName.Print)
        End Sub

        Public Function Delete(ByRef strMsg As String) As Boolean
            strMsg = ""
            'If Me.DeletePrivilege Then
            Dim flag2 As Boolean
            Dim conn As New SqlConnection(Me._ConnectionString)
            conn.Open()
            Dim trans As SqlTransaction = conn.BeginTransaction
            If Me.DeleteData(conn, trans, strMsg) Then
                Try
                    trans.Commit()
                    If (Operators.CompareString(strMsg, "", True) = 0) Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralDeleteSuccess, Me._Title)
                    End If
                    Me._State = EditState.Edit
                    Me.DeleteSuccess()
                    Return True
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim ex As Exception = exception1
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralDeleteFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(ex))
                    flag2 = False
                    ProjectData.ClearProjectError()
                    Return flag2
                    ProjectData.ClearProjectError()
                End Try
                Return flag2
            End If
            Try
                trans.Rollback()
                If (Operators.CompareString(strMsg, "", True) = 0) Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralDeleteFailure, Me._Title)
                End If
                Return False
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralDeleteFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(exception2))
                flag2 = False
                ProjectData.ClearProjectError()
                Return flag2
                ProjectData.ClearProjectError()
            End Try
            Return flag2
            'End If
            strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralDeleteFailure, Me._Title, ZZMessage.ConMsgInfo.CannotDelete)
            Return False
        End Function

        Protected Overridable Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overridable Sub DeleteSuccess()
        End Sub

        Public Function GetAllList() As DataTable
            Me._PageIndex = 1
            Me._PageSize = 0
            Return Me.GetList
        End Function

        Public MustOverride Function GetDetail(ByVal intId As Long) As clsProp

        Public MustOverride Function GetDetail(ByVal strKey As String) As clsProp

        Public Function GetItemById(ByVal intId As Long) As clsProp
            Dim num2 As Integer = (Me._colProp.ArrProp.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Dim prop2 As clsProp = DirectCast(Me._colProp.ArrProp.Item(i), clsProp)
                If (prop2.Id = intId) Then
                    Me._CurrentProp = prop2
                    Return Me._CurrentProp
                End If
                i += 1
            Loop
            Me._CurrentProp = DirectCast(Me._colProp.ArrProp.Item((Me._colProp.ArrProp.Count - 1)), clsProp)
            Return Me._CurrentProp
        End Function

        Protected MustOverride Function GetList() As DataTable

        Public Sub GetListInfo(ByVal intPageIndex As Integer, ByVal intPageSize As Integer)
            Me._PageIndex = intPageIndex
            Me._PageSize = intPageSize
            Me._colProp.AddTableToArray(Me.GetList, ((intPageIndex - 1) * intPageSize), Me._UserId)
        End Sub

        Public Sub GetListInfo(ByVal intPageIndex As Integer, ByVal intPageSize As Integer, ByVal strQuery As String)
            Me._PageIndex = intPageIndex
            Me._PageSize = intPageSize
            Me._Query = strQuery
            Me._colProp.AddTableToArray(Me.GetList, ((intPageIndex - 1) * intPageSize), Me._UserId)
        End Sub
        'bylzw 091117 For CTS MultiType
        Public Sub GetDataTableInfo(ByVal intPageIndex As Integer, ByVal intPageSize As Integer)
            Me._PageIndex = intPageIndex
            Me._PageSize = intPageSize
            Me.DataTable = Me.GetList
        End Sub

        Protected Overridable Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overridable Sub InsertSuccess()
        End Sub

        Protected Overridable Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        Public MustOverride Function ModifyCurrent(ByVal strValue As String) As Boolean

        Public Function OtherPrivilege(ByVal strName As String) As Boolean
            Return Me._Privilege.GetPrivilege(strName)
        End Function

        Public Function Restore(ByRef strMsg As String) As Boolean
            strMsg = ""
            If Me.RestorePrivilege Then
                Dim flag2 As Boolean
                Dim conn As New SqlConnection(Me._ConnectionString)
                conn.Open()
                Dim trans As SqlTransaction = conn.BeginTransaction
                If Me.RestoreData(conn, trans, strMsg) Then
                    Try
                        trans.Commit()
                        If (Operators.CompareString(strMsg, "", True) = 0) Then
                            strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralRestoreSuccess, Me._Title)
                        End If
                        Me._State = EditState.Edit
                        Me.RestoreSuccess()
                        Return True
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim ex As Exception = exception1
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralRestoreFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(ex))
                        flag2 = False
                        ProjectData.ClearProjectError()
                        Return flag2
                        ProjectData.ClearProjectError()
                    End Try
                    Return flag2
                End If
                Try
                    trans.Rollback()
                    If (Operators.CompareString(strMsg, "", True) = 0) Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralRestoreFailure, Me._Title)
                    End If
                    Return False
                Catch exception3 As Exception
                    ProjectData.SetProjectError(exception3)
                    Dim exception2 As Exception = exception3
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralRestoreFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(exception2))
                    flag2 = False
                    ProjectData.ClearProjectError()
                    Return flag2
                    ProjectData.ClearProjectError()
                End Try
                Return flag2
            End If
            strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralRestoreFailure, Me._Title, ZZMessage.ConMsgInfo.CannotRestore)
            Return False
        End Function

        Protected Overridable Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overridable Sub RestoreSuccess()
        End Sub

        Public Function Save(ByRef strMsg As String) As Boolean
            strMsg = ""
            If ((Me._State = EditState.Insert) Or (Me._State = EditState.Edit)) Then
                Dim flag2 As Boolean
                If Not Me.IsCanSave(strMsg) Then
                    Return False
                End If
                Dim conn As New SqlConnection(Me._ConnectionString)
                conn.Open()
                Dim trans As SqlTransaction = conn.BeginTransaction
                If Me.SaveData(conn, trans, strMsg) Then
                    Try
                        trans.Commit()
                        If (Operators.CompareString(strMsg, "", True) = 0) Then
                            strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveSuccess, Me._Title)
                        End If
                        Me.SaveSuccess()
                        Me._State = EditState.Edit
                        Return True
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim ex As Exception = exception1
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(ex))
                        flag2 = False
                        ProjectData.ClearProjectError()
                        Return flag2
                        ProjectData.ClearProjectError()
                    End Try
                    Return flag2
                End If
                Try
                    trans.Rollback()
                    If (Operators.CompareString(strMsg, "", True) = 0) Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveFailure, Me._Title)
                    End If
                    Return False
                Catch exception3 As Exception
                    ProjectData.SetProjectError(exception3)
                    Dim exception2 As Exception = exception3
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveFailure, Me._Title, ZZMessage.clsMessage.GetErrorMessage(exception2))
                    flag2 = False
                    ProjectData.ClearProjectError()
                    Return flag2
                    ProjectData.ClearProjectError()
                End Try
                Return flag2
            End If
            If (Me._State = EditState.Browse) Then
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveFailure, Me._Title, ZZMessage.ConMsgInfo.InBrowseState)
                Return False
            End If
            strMsg = ZZMessage.clsMessage.GetFormatMessage(ZZMessage.ConMsgInfo.GeneralSaveFailure, Me._Title, ZZMessage.ConMsgInfo.InOtherState)
            Return False
        End Function

        Private Function SaveData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            If (Me._State = EditState.Insert) Then
                Return Me.InsertData(conn, trans, strMsg)
            End If
            If (Me._State = EditState.Edit) Then
                Return Me.UpdateData(conn, trans, strMsg)
            End If
            Return True
        End Function

        Private Sub SaveSuccess()
            If (Me._State = EditState.Insert) Then
                Me.InsertSuccess()
            ElseIf (Me._State = EditState.Edit) Then
                Me.UpdateSuccess()
            End If
        End Sub

        Protected Overridable Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overridable Sub UpdateSuccess()
        End Sub


        ' Properties
        Public Property ArrProp() As ArrayList
            Get
                Return Me._colProp.ArrProp
            End Get
            Set(ByVal value As ArrayList)
                If (value Is Nothing) Then
                    Me._colProp.ArrProp.Clear()
                    Me._colProp.IsEmpty = True
                Else
                    Me._colProp.ArrProp = value
                End If
            End Set
        End Property

        Protected Property colProp() As colclsProp
            Get
                Return Me._colProp
            End Get
            Set(ByVal value As colclsProp)
                Me._colProp = value
            End Set
        End Property

        Public Property ConnectionString() As Object
            Get
                Return Me._ConnectionString
            End Get
            Set(ByVal value As Object)
                Me._ConnectionString = value
            End Set
        End Property

        Public Property CurrentProp() As clsProp
            Get
                Return Me._CurrentProp
            End Get
            Set(ByVal value As clsProp)
                Me._CurrentProp = value
            End Set
        End Property

        Public Property DeletePrivilege() As Boolean
            Get
                Return Me._DeletePrivilege
            End Get
            Set(ByVal value As Boolean)
                Me._DeletePrivilege = value
            End Set
        End Property

        Public Property EditPrivilege() As Boolean
            Get
                Return Me._EditPrivilege
            End Get
            Set(ByVal value As Boolean)
                Me._EditPrivilege = value
            End Set
        End Property

        Public ReadOnly Property FieldPrefix() As Boolean
            Get
                Return Me._colProp.HavePrefix
            End Get
        End Property

        Public Property FunNo() As String
            Get
                Return Me._FunNo
            End Get
            Set(ByVal value As String)
                Me._FunNo = value
            End Set
        End Property

        Public Property NewPrivilege() As Boolean
            Get
                Return Me._NewPrivilege
            End Get
            Set(ByVal value As Boolean)
                Me._NewPrivilege = value
            End Set
        End Property

        Public Property OrderBy() As String
            Get
                Return Me._OrderBy
            End Get
            Set(ByVal value As String)
                Me._OrderBy = value
            End Set
        End Property

        Public Property PageCount() As Integer
            Get
                Return Me._PageCount
            End Get
            Set(ByVal value As Integer)
                Me._PageCount = value
            End Set
        End Property

        Public Property PageIndex() As Integer
            Get
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Public Property PrintPrivilege() As Boolean
            Get
                Return Me._PrintPrivilege
            End Get
            Set(ByVal value As Boolean)
                Me._PrintPrivilege = value
            End Set
        End Property

        Public Property Query() As String
            Get
                Return Me._Query
            End Get
            Set(ByVal value As String)
                Me._Query = value
            End Set
        End Property

        Public Property RecordCount() As Integer
            Get
                Return Me._RecordCount
            End Get
            Set(ByVal value As Integer)
                Me._RecordCount = value
            End Set
        End Property

        Public Property RestorePrivilege() As Boolean
            Get
                Return Me._RestorePrivilege
            End Get
            Set(ByVal value As Boolean)
                Me._RestorePrivilege = value
            End Set
        End Property

        Public Property State() As EditState
            Get
                Return Me._State
            End Get
            Set(ByVal value As EditState)
                Me._State = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return Me._Title
            End Get
            Set(ByVal value As String)
                Me._Title = value
            End Set
        End Property

        Public ReadOnly Property UserId() As String
            Get
                Return Me._UserId
            End Get
        End Property

        Public Property Where() As String
            Get
                Return Me._Where
            End Get
            Set(ByVal value As String)
                Me._Where = value
            End Set
        End Property

        Public Property DataBase() As String
            Get
                Return Me._DataBase
            End Get
            Set(ByVal value As String)
                Me._DataBase = value
            End Set
        End Property

        Public Property Condition() As String
            Get
                Return Me._Condition
            End Get
            Set(ByVal value As String)
                Me._Condition = value
            End Set
        End Property
        Public Property Condition1() As String
            Get
                Return Me._Condition1
            End Get
            Set(ByVal value As String)
                Me._Condition1 = value
            End Set
        End Property
        Public Property Condition2() As String
            Get
                Return Me._Condition2
            End Get
            Set(ByVal value As String)
                Me._Condition2 = value
            End Set
        End Property

        Public Property Fields() As String
            Get
                Return Me._Fields
            End Get
            Set(ByVal value As String)
                Me._Fields = value
            End Set
        End Property
        Public Property TableNames() As String
            Get
                Return Me._TableNames
            End Get
            Set(ByVal value As String)
                Me._TableNames = value
            End Set
        End Property
        Public Property DataTable() As DataTable
            Get
                Return Me._DataTable
            End Get
            Set(ByVal value As DataTable)
                Me._DataTable = value
            End Set
        End Property
        ' Fields
        Private _colProp As colclsProp
        Private _ConnectionString As String
        Private _CurrentProp As clsProp
        Private _DeletePrivilege As Boolean
        Private _EditPrivilege As Boolean
        Private _FunNo As String
        Private _NewPrivilege As Boolean
        Private _OrderBy As String
        Private _PageCount As Integer
        Private _PageIndex As Integer
        Private _PageSize As Integer
        Private _PrintPrivilege As Boolean
        Private _Privilege As clsPrivilege
        Private _Query As String
        Private _RecordCount As Integer
        Private _RestorePrivilege As Boolean
        Private _State As EditState
        Private _Title As String
        Private _UserId As String
        Private _Where As String
        Private _DataBase As String
        Private _Condition As String
        Private _Condition1 As String
        Private _Condition2 As String
        Private _Fields As String
        Private _TableNames As String
        Private _DataTable As DataTable
    End Class
End Namespace

