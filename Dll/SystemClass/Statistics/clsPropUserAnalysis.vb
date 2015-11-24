Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Manifest Info "

    <Serializable()> _
    Public Class clsPropUserAnalysis
        Inherits clsProp
        Private _JobNo As String = ""
        Private _JobType As String = ""
        Private _CustomerName As String = ""
        Private _AwbBlNo As String = ""
        Private _ShipmentType As String = ""
        Private _OriginCode As String = ""
        Private _DestCode As String = ""
        Private _JobDate As String = ""
        Private _CreateBy As String = ""
        ' 
        Public Property JobNo() As String
            Set(ByVal value As String)
                If _JobNo <> value Then
                    _JobNo = value
                End If
            End Set
            Get
                Return _JobNo
            End Get
        End Property
        ' 
        Public Property JobType() As String
            Set(ByVal value As String)
                If _JobType <> value Then
                    _JobType = value
                End If
            End Set
            Get
                Return _JobType
            End Get
        End Property
        ' 
        Public Property CustomerName() As String
            Set(ByVal value As String)
                If _CustomerName <> value Then
                    _CustomerName = value
                End If
            End Set
            Get
                Return _CustomerName
            End Get
        End Property
        ' 
        Public Property AwbBlNo() As String
            Set(ByVal value As String)
                If _AwbBlNo <> value Then
                    _AwbBlNo = value
                End If
            End Set
            Get
                Return _AwbBlNo
            End Get
        End Property
        ' 
        Public Property ShipmentType() As String
            Set(ByVal value As String)
                If _ShipmentType <> value Then
                    _ShipmentType = value
                End If
            End Set
            Get
                Return _ShipmentType
            End Get
        End Property
        ' 
        Public Property OriginCode() As String
            Set(ByVal value As String)
                If _OriginCode <> value Then
                    _OriginCode = value
                End If
            End Set
            Get
                Return _OriginCode
            End Get
        End Property
        ' 
        Public Property DestCode() As String
            Set(ByVal value As String)
                If _DestCode <> value Then
                    _DestCode = value
                End If
            End Set
            Get
                Return _DestCode
            End Get
        End Property
        ' 
        Public Property JobDate() As String
            Set(ByVal value As String)
                If _JobDate <> value Then
                    _JobDate = value
                End If
            End Set
            Get
                Return _JobDate
            End Get
        End Property

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

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _JobNo = ""
            _JobType = ""
            _CustomerName = ""
            _AwbBlNo = ""
            _ShipmentType = ""
            _OriginCode = ""
            _DestCode = ""
            _JobDate = ""
            _CreateBy = ""
        End Sub

    End Class

#End Region
End Namespace