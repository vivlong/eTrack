Imports System
Imports System.Configuration

Namespace SystemClass

#Region " Class of Session Name "

    Public Class ConSessionName
        Public Shared UserInfo As String = "UserInfo"
        Public Shared AirSeaQuery As String = "AirSeaQuery"
        Public Shared VessualSchedule As String = "VessualSchedule"
        Public Shared Booking As String = "Booking"
        Public Shared Company As String = "Company"
        Public Shared WMS As String = "WMS"
        Public Shared BusinessParty As String = "BusinessParty"
        Public Shared Airline As String = "Airline"
        Public Shared ShippingLine As String = "ShippingLine"
        Public Shared AirPort As String = "AirPort"
        Public Shared Port As String = "Port"
        Public Shared Country As String = "Country"
        Public Shared ContainerType As String = "ContainerType"
        Public Shared Currency As String = "Currency"
        Public Shared Inventory As String = "Inventory"
    End Class

#End Region

#Region " Class Const of Error Code "

    Public Class ConErrorCode
        Public Shared NotAllowPrice As Integer = 1001
        Public Shared NotAllowMoney As Integer = 1002
        Public Shared NotAllowPriceAndMoney As Integer = 1003
        Public Shared NotAllowDate As Integer = 1004
    End Class

#End Region

#Region " Class Const of List Size "

    Public Class MasterListSize
        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("MasterWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("MasterHeight"))
                End If
                Return _Height
            End Get
        End Property

    End Class

    Public Class InfoListSize
        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("InfoWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("InfoHeight"))
                End If
                Return _Height
            End Get
        End Property
    End Class

    Public Class SourceDestinationSize
        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("MultiWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("MultiHeight"))
                End If
                Return _Height
            End Get
        End Property
    End Class

    Public Class BarcodeEditSize
        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("BarcodeWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("BarcodeHeight"))
                End If
                Return _Height
            End Get
        End Property
    End Class

    Public Class CustEditSize
        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("CustEditWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("CustEditHeight"))
                End If
                Return _Height
            End Get
        End Property
    End Class

    Public Class FactEditSize

        Private Shared _Width As Integer = 0
        Private Shared _Height As Integer = 0

        Public Shared ReadOnly Property Width() As Integer
            Get
                If _Width = 0 Then
                    _Width = Integer.Parse(ConfigurationManager.AppSettings("FactEditWidth"))
                End If
                Return _Width
            End Get
        End Property

        Public Shared ReadOnly Property Height() As Integer
            Get
                If _Height = 0 Then
                    _Height = Integer.Parse(ConfigurationManager.AppSettings("FactEditHeight"))
                End If
                Return _Height
            End Get
        End Property

    End Class

#End Region
End Namespace
