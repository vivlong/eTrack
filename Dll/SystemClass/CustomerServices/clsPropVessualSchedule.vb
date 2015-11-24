Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class of Property VessualSchedule "

    <Serializable()> _
    Public Class clsPropVessualSchedule
        Inherits clsProp
        'From rcvy
        Private _VoyageID As String
        Private _VoyageNo As String
        Private _ShippinglineCode As String
        Private _UcrNo As String
        Private _Ata As DateTime
        Private _Eta As DateTime
        Private _Etd As DateTime
        Private _Note As String
        Private _PortOfDischargeCode As String
        Private _PortOfDischargeName As String
        Private _PortOfLoadingCode As String
        Private _VesselCode As String
        Private _Remark As String
        Private _StatusCode As String

        Property VoyageID() As String
            Get
                Return _VoyageID
            End Get
            Set(ByVal value As String)
                _VoyageID = value
            End Set
        End Property

        Property VoyageNo() As String
            Get
                Return _VoyageNo
            End Get
            Set(ByVal value As String)
                _VoyageNo = value
            End Set
        End Property

        Property ShippinglineCode() As String
            Get
                Return _ShippinglineCode
            End Get
            Set(ByVal value As String)
                _ShippinglineCode = value
            End Set
        End Property

        Property UcrNo() As String
            Get
                Return _UcrNo
            End Get
            Set(ByVal value As String)
                _UcrNo = value
            End Set
        End Property

        Property Ata() As DateTime
            Get
                Return _Ata
            End Get
            Set(ByVal value As DateTime)
                _Ata = value
            End Set
        End Property

        Property Eta() As DateTime
            Get
                Return _Eta
            End Get
            Set(ByVal value As DateTime)
                _Eta = value
            End Set
        End Property

        Property ETD() As DateTime
            Get
                Return _Etd
            End Get
            Set(ByVal value As DateTime)
                _Etd = value
            End Set
        End Property

        Property Note() As String
            Get
                Return _Note
            End Get
            Set(ByVal value As String)
                _Note = value
            End Set
        End Property

        Property PortOfDischargeCode() As String
            Get
                Return _PortOfDischargeCode
            End Get
            Set(ByVal value As String)
                _PortOfDischargeCode = value
            End Set
        End Property

        Property PortOfDischargeName() As String
            Get
                Return _PortOfDischargeName
            End Get
            Set(ByVal value As String)
                _PortOfDischargeName = value
            End Set
        End Property
        Property PortOfLoadingCode() As String
            Get
                Return _PortOfLoadingCode
            End Get
            Set(ByVal value As String)
                _PortOfLoadingCode = value
            End Set
        End Property

        Property VesselCode() As String
            Get
                Return _VesselCode
            End Get
            Set(ByVal value As String)
                _VesselCode = value
            End Set
        End Property

        Property Remark() As String
            Get
                Return _Remark
            End Get
            Set(ByVal value As String)
                _Remark = value
            End Set
        End Property

        Property StatusCode() As String
            Get
                Return _StatusCode
            End Get
            Set(ByVal value As String)
                _StatusCode = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _VoyageID = ""
            _VoyageNo = ""
            _ShippinglineCode = ""
            _UcrNo = ""
            _Ata = ConDateTime.MinDate
            _Eta = ConDateTime.MinDate
            _Etd = ConDateTime.MinDate
            _Note = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _VesselCode = ""
            _Remark = ""
            _StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace
