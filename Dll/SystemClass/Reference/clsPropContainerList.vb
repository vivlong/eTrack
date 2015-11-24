Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of TypeSort Info "

    <Serializable()> _
    Public Class clsPropContainerList
        Inherits clsProp
        Private _column1 As String = ""
        Private _column2 As String = ""
        Private _column3 As String = ""
        Private _State As String = ""
        Private _EventDate As DateTime
        Public Property column1() As String
            Set(ByVal value As String)
                If _column1 <> value Then
                    _column1 = value
                End If
            End Set
            Get
                Return _column1
            End Get
        End Property
        ' 
        Public Property column2() As String
            Set(ByVal value As String)
                If _column2 <> value Then
                    _column2 = value
                End If
            End Set
            Get
                Return _column2
            End Get
        End Property
        Public Property column3() As String
            Set(ByVal value As String)
                If _column3 <> value Then
                    _column3 = value
                End If
            End Set
            Get
                Return _column3
            End Get
        End Property
        Public Property State() As String
            Set(ByVal value As String)
                If _State <> value Then
                    _State = value
                End If
            End Set
            Get
                Return _State
            End Get
        End Property
        Public Property EventDate() As DateTime
            Set(ByVal value As DateTime)
                If _EventDate <> value Then
                    _EventDate = value
                End If
            End Set
            Get
                Return _EventDate
            End Get
        End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _column1 = ""
            _column2 = ""
            _column3 = ""
            _State = ""
            _EventDate = ConDateTime.MinDate
        End Sub

    End Class

#End Region
End Namespace