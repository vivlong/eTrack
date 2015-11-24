Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace ZZSystem

    Public Class clsPrivilegeProp
        ' Methods
        Public Sub New(ByVal strName As String, ByVal blExist As Boolean)
            Me._Name = strName
            Me._Exist = blExist
        End Sub


        ' Properties
        Public Property Exist() As Boolean
            Get
                Return Me._Exist
            End Get
            Set(ByVal value As Boolean)
                Me._Exist = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return Me._Name
            End Get
            Set(ByVal value As String)
                Me._Name = value
            End Set
        End Property


        ' Fields
        Private _Exist As Boolean
        Private _Name As String
    End Class
End Namespace

