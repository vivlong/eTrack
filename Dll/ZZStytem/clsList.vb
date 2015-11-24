Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data

Namespace ZZSystem

    Public MustInherit Class clsList
        ' Methods
        Public Sub New(ByVal intUserId As String)
            Me._UserId = intUserId
            Me._Query = ""
            Me._Where = ""
            Me._PageCount = 0
            Me._IsEmpty = False
        End Sub

        Private Function AddNoColumnToDataTable(ByVal dt As DataTable) As DataTable
            Dim column As New DataColumn("lNo", GetType(Integer))
            dt.Columns.Add(column)
            Dim num2 As Integer = (dt.Rows.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                dt.Rows.Item(i).Item("lNo") = ((((Me._PageIndex - 1) * Me._PageSize) + i) + 1)
                i += 1
            Loop
            Return dt
        End Function

        Public Overridable Function AddTotalRecord(ByVal dt As DataTable) As DataTable
            Return dt
        End Function

        Public Function GetAllList() As DataTable
            Return Me.AddTotalRecord(Me.GetPageList(1, 0))
        End Function

        Public Overridable Function GetGroupList() As DataTable
            Return New DataTable
        End Function

        Protected MustOverride Function GetList() As DataTable

        Public Function GetPageList(ByVal intPageIndex As Integer, ByVal intPageSize As Integer) As DataTable
            Me._PageIndex = intPageIndex
            Me._PageSize = intPageSize
            Return Me.AddNoColumnToDataTable(Me.HandleReturnValue(Me.GetList))
        End Function

        Public Function GetPageList(ByVal intPageIndex As Integer, ByVal intPageSize As Integer, ByVal strQuery As String) As DataTable
            Me._Query = strQuery
            Me._PageIndex = intPageIndex
            Me._PageSize = intPageSize
            Return Me.AddNoColumnToDataTable(Me.HandleReturnValue(Me.GetList))
        End Function

        Protected Overridable Function HandleReturnValue(ByVal dt As DataTable) As DataTable
            Return dt
        End Function


        ' Properties
        Public Property IsEmpty() As Boolean
            Get
                Return Me._IsEmpty
            End Get
            Set(ByVal value As Boolean)
                Me._IsEmpty = value
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
                If (value = 0) Then
                    Me._PageCount = 1
                Else
                    Me._PageCount = value
                End If
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

        ' Fields
        Private _IsEmpty As Boolean
        Private _OrderBy As String
        Private _PageCount As Integer
        Private _PageIndex As Integer
        Private _PageSize As Integer
        Private _Query As String
        Private _RecordCount As Integer
        Private _UserId As String
        Private _Where As String
        Private _DataBase As String 'add by lzw
        Private _Condition As String 'add by lzw
    End Class
End Namespace

