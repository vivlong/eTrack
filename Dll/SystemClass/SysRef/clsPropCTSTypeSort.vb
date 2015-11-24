Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of CTSTypeSort Info "

    <Serializable()> _
    Public Class clsPropCTSTypeSort
        Inherits clsProp
        Private _Code As String = ""
        Private _Name As String = ""

        Public Property Code() As String
            Set(ByVal value As String)
                If _Code <> value Then
                    _Code = value
                End If
            End Set
            Get
                Return _Code
            End Get
        End Property
        ' 
        Public Property Name() As String
            Set(ByVal value As String)
                If _Name <> value Then
                    _Name = value
                End If
            End Set
            Get
                Return _Name
            End Get
        End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _Code = ""
            _Name = ""
        End Sub

    End Class

#End Region
End Namespace