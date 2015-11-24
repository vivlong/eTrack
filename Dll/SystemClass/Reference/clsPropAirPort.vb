Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of AirPort Info "
    <Serializable()> _
    Public Class clsPropAirPort
        Inherits clsProp
        Private _AirportCode As String = ""
        Private _AirportName As String = ""
        Private _CountryCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _StatusCode As String = ""
        ' 
        Public Property AirportCode() As String
            Set(ByVal value As String)
                If _AirportCode <> value Then
                    _AirportCode = value
                End If
            End Set
            Get
                Return _AirportCode
            End Get
        End Property
        ' 
        Public Property AirportName() As String
            Set(ByVal value As String)
                If _AirportName <> value Then
                    _AirportName = value
                End If
            End Set
            Get
                Return _AirportName
            End Get
        End Property
        ' 
        Public Property CountryCode() As String
            Set(ByVal value As String)
                If _CountryCode <> value Then
                    _CountryCode = value
                End If
            End Set
            Get
                Return _CountryCode
            End Get
        End Property
        ' 
        Public Property CreateBy() As String
            Set(ByVal value As String)
                If _CreateBy <> value Then
                    _CreateBy = value
                End If
            End Set
            Get
                Return _CreateBy
            End Get
        End Property
        ' 
        Public Property CreateDateTime() As String
            Set(ByVal value As String)
                If _CreateDateTime <> value Then
                    _CreateDateTime = value
                End If
            End Set
            Get
                Return _CreateDateTime
            End Get
        End Property
        ' 
        Public Property UpdateBy() As String
            Set(ByVal value As String)
                If _UpdateBy <> value Then
                    _UpdateBy = value
                End If
            End Set
            Get
                Return _UpdateBy
            End Get
        End Property
        ' 
        Public Property UpdateDateTime() As String
            Set(ByVal value As String)
                If _UpdateDateTime <> value Then
                    _UpdateDateTime = value
                End If
            End Set
            Get
                Return _UpdateDateTime
            End Get
        End Property
        ' 
        Public Property StatusCode() As String
            Set(ByVal value As String)
                If _StatusCode <> value Then
                    _StatusCode = value
                End If
            End Set
            Get
                Return _StatusCode
            End Get
        End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _AirportCode = ""
            _AirportName = ""
            _CountryCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace