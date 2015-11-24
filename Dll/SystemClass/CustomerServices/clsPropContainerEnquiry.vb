Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class of Property Container Enquiry "

    <Serializable()> _
    Public Class clsPropContainerEnquiry
        Inherits clsProp
        'From rcvy
        Private _TableName As String
        Private _TrxNo As Integer
        Private _LineItemNo As Integer
        Private _ContainerNo As String
        Private _Owner As String
        Private _CntrReturnDate As DateTime
        Private _CntrRemark As String
        Private _CntrReturnType As String
        Private _CntrTransferDate As DateTime
        Private _DOReleaseDate As DateTime
        Private _FinalDestDate As DateTime
        Private _HODate As DateTime
        Private _PickupDate As DateTime
        Private _ShipmentDate As String
        Private _EtaDate As DateTime
        Private _EtdDate As DateTime
        Private _CargoStatusCode As String
        Private _DischargeDate As DateTime
        Private _RccfContainer As String = ""

        Property TableName() As String
            Get
                Return _TableName
            End Get
            Set(ByVal value As String)
                _TableName = value
            End Set
        End Property
        Property RccfContainer() As String
            Get
                Return _RccfContainer
            End Get
            Set(ByVal value As String)
                _RccfContainer = value
            End Set
        End Property

        Property Owner() As String
            Get
                Return _Owner
            End Get
            Set(ByVal value As String)
                _Owner = value
            End Set
        End Property

        Property ContainerNo() As String
            Get
                Return _ContainerNo
            End Get
            Set(ByVal value As String)
                _ContainerNo = value
            End Set
        End Property

        Property TrxNo() As Integer
            Get
                Return _TrxNo
            End Get
            Set(ByVal value As Integer)
                _TrxNo = value
            End Set
        End Property

        Property LineItemNo() As Integer
            Get
                Return _LineItemNo
            End Get
            Set(ByVal value As Integer)
                _LineItemNo = value
            End Set
        End Property

        Property CntrReturnDate() As DateTime
            Get
                Return _CntrReturnDate
            End Get
            Set(ByVal value As DateTime)
                _CntrReturnDate = value
            End Set
        End Property

        Property CntrRemark() As String
            Get
                Return _CntrRemark
            End Get
            Set(ByVal value As String)
                _CntrRemark = value
            End Set
        End Property

        Property CntrReturnType() As String
            Get
                Return _CntrReturnType
            End Get
            Set(ByVal value As String)
                _CntrReturnType = value
            End Set
        End Property

        Property CargoStatusCode() As String
            Get
                Return _CargoStatusCode
            End Get
            Set(ByVal value As String)
                _CargoStatusCode = value
            End Set
        End Property

        Property CntrTransferDate() As DateTime
            Get
                Return _CntrTransferDate
            End Get
            Set(ByVal value As DateTime)
                _CntrTransferDate = value
            End Set
        End Property
        Property DOReleaseDate() As DateTime
            Get
                Return _DOReleaseDate
            End Get
            Set(ByVal value As DateTime)
                _DOReleaseDate = value
            End Set
        End Property
        Property FinalDestDate() As DateTime
            Get
                Return _FinalDestDate
            End Get
            Set(ByVal value As DateTime)
                _FinalDestDate = value
            End Set
        End Property
        Property PickupDate() As DateTime
            Get
                Return _PickupDate
            End Get
            Set(ByVal value As DateTime)
                _PickupDate = value
            End Set
        End Property
        Property HODate() As DateTime
            Get
                Return _HODate
            End Get
            Set(ByVal value As DateTime)
                _HODate = value
            End Set
        End Property
        Property DischargeDate() As DateTime
            Get
                Return _DischargeDate
            End Get
            Set(ByVal value As DateTime)
                _DischargeDate = value
            End Set
        End Property

        Property EtaDate() As DateTime
            Get
                Return _EtaDate
            End Get
            Set(ByVal value As DateTime)
                _EtaDate = value
            End Set
        End Property

        Property EtdDate() As DateTime
            Get
                Return _EtdDate
            End Get
            Set(ByVal value As DateTime)
                _EtdDate = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            '_VoyageID = ""
            '_VoyageNo = ""
            '_ShippinglineCode = ""
            '_UcrNo = ""
            '_Ata = ConDateTime.MinDate
            '_Eta = ConDateTime.MinDate
            '_Etd = ConDateTime.MinDate
            '_Note = ""
            '_PortOfDischargeCode = ""
            '_PortOfDischargeName = ""
            '_PortOfLoadingCode = ""
            '_VesselCode = ""
            '_Remark = ""
            '_StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace
