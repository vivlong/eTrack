Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace ZZSystem

    Public Class clsMenuProp
        ' Properties
        Public Property Image() As String
            Get
                Return Me._Image
            End Get
            Set(ByVal value As String)
                Me._Image = value
            End Set
        End Property

        Public Property MenuName() As String
            Get
                Return Me._MenuName
            End Get
            Set(ByVal value As String)
                Me._MenuName = value
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


        ' Fields
        Private _Image As String
        Private _MenuName As String
        Private _MenuNo As String
        Private _No As Integer
    End Class
End Namespace

