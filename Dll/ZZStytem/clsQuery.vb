Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data

Namespace ZZSystem

    Public MustInherit Class clsQuery
        Inherits clsList
        ' Methods
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            Me._FieldNames = ""
            Me._KeyFieldName = ""
            Me._Select = ""
        End Sub

        Public Overridable Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            strMsg = ""
            Return True
        End Function

        Public Overloads Function GetPageList(ByVal strWhere As String, ByVal intPageIndex As Integer, ByVal intPageSize As Integer, ByVal strQuery As String) As DataTable
            Me.PageIndex = intPageIndex
            Me.PageSize = intPageSize
            Me.Where = strWhere
            Me.Query = strQuery
            Return Me.GetList
        End Function

        Public Overloads Function GetPageList(ByVal strFieldNames As String, ByVal strKeyFieldName As String, ByVal strGroupby As String, ByVal strWhere As String, ByVal intPageIndex As Integer, ByVal intPageSize As Integer) As DataTable
            Me.PageIndex = intPageIndex
            Me.PageSize = intPageSize
            Me._FieldNames = strFieldNames
            Me._KeyFieldName = strKeyFieldName
            Me.Where = strWhere
            Return Me.GetList
        End Function


        ' Properties
        Public Property FieldNames() As String
            Get
                Return Me._FieldNames
            End Get
            Set(ByVal value As String)
                Me._FieldNames = value
            End Set
        End Property

        Public Property KeyFieldName() As String
            Get
                Return Me._KeyFieldName
            End Get
            Set(ByVal value As String)
                Me._KeyFieldName = value
            End Set
        End Property

        Public Property [Select]() As String
            Get
                Return Me._Select
            End Get
            Set(ByVal value As String)
                Me._Select = value
            End Set
        End Property


        ' Fields
        Private _FieldNames As String
        Private _KeyFieldName As String
        Private _Select As String
    End Class
End Namespace

