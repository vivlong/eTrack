Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace ZZSystem

    Public Class clsFunProp
        ' Properties
        Public Property FunName() As String
            Get
                Return Me._FunName
            End Get
            Set(ByVal value As String)
                Me._FunName = value
            End Set
        End Property

        Public Property FunNo() As String
            Get
                Return Me._FunNo
            End Get
            Set(ByVal value As String)
                Me._FunNo = value
            End Set
        End Property

        Public Property FunUrl() As String
            Get
                Return Me._FunUrl
            End Get
            Set(ByVal value As String)
                Me._FunUrl = value
            End Set
        End Property

        Public Property Image() As String
            Get
                Return Me._Image
            End Get
            Set(ByVal value As String)
                Me._Image = value
            End Set
        End Property

        Public Property MenuNo() As String
            Get
                Return Me._MenuNo
            End Get
            Set(ByVal value As String)
                Me._MenuNo = value
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

        Public Property ParentNo() As String
            Get
                Return Me._ParentNo
            End Get
            Set(ByVal value As String)
                Me._ParentNo = value
            End Set
        End Property

        Public Property Type() As Integer
            Get
                Return Me._Type
            End Get
            Set(ByVal value As Integer)
                Me._Type = value
            End Set
        End Property


        ' Fields
        Private _FunName As String
        Private _FunNo As String
        Private _FunUrl As String
        Private _Image As String
        Private _MenuNo As String
        Private _No As Integer
        Private _ParentNo As String
        Private _Type As Integer
    End Class
End Namespace

