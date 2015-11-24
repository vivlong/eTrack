Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace ZZSystem

    Public Class clsProp
        ' Methods
        Public Sub New(ByVal intId As String)
            Me._Id = intId
            Me._No = 0
            Me._IsDeleted = 0
            Me._IsAdd = True
        End Sub


        ' Properties
        Public Property Id() As String
            Get
                Return Me._Id
            End Get
            Set(ByVal value As String)
                Me._Id = value
            End Set
        End Property

        Public Property IsAdd() As Boolean
            Get
                Return Me._IsAdd
            End Get
            Set(ByVal value As Boolean)
                Me._IsAdd = value
            End Set
        End Property

        Public Property IsDeleted() As Integer
            Get
                Return Me._IsDeleted
            End Get
            Set(ByVal value As Integer)
                Me._IsDeleted = value
            End Set
        End Property

        Public Property Key() As String
            Get
                Return Me._Key
            End Get
            Set(ByVal value As String)
                Me._Key = value
            End Set
        End Property

        Public Property No() As Integer
            Get
                Return Me._No
            End Get
            Set(ByVal value As Integer)
                Me._No = value
            End Set
        End Property

        Public Property UserId() As String
            Get
                Return Me._UserId
            End Get
            Set(ByVal value As String)
                Me._UserId = value
            End Set
        End Property


        ' Fields
        Private _Id As String
        Private _IsAdd As Boolean
        Private _IsDeleted As Integer
        Private _Key As String
        Private _No As Integer
        Private _UserId As String
    End Class
End Namespace

