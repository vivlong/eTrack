Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Airline Info "

    <Serializable()> _
    Public Class clsPropPort
        Inherits clsProp
        Private _PortCode As String = ""
        Private _PortName As String = ""
        Private _CountryCode As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        ' 
        Public Property PortCode() As String
            Set(ByVal value As String)
                If _PortCode <> value Then
                    _PortCode = value
                End If
            End Set
            Get
                Return _PortCode
            End Get
        End Property
        ' 
        Public Property PortName() As String
            Set(ByVal value As String)
                If _PortName <> value Then
                    _PortName = value
                End If
            End Set
            Get
                Return _PortName
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


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _PortCode = ""
            _PortName = ""
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