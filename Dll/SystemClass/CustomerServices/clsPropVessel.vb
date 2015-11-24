Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class of Property VessualSchedule_Sebl1 "

    <Serializable()> _
    Public Class clsPropVessualSchedule_Sebl1
        Inherits clsProp
        'From rcvy
        Private _EtdDate As DateTime
        Private _VesselVoyage As String
        Private _ShippinglineName As String
        Private _PortOfDischargeCode As String
        Private _EtaDate As DateTime
        Property EtdDate() As DateTime
            Get
                Return _EtdDate
            End Get
            Set(ByVal value As DateTime)
                _EtdDate = _EtdDate
            End Set
        End Property

        Property VesselVoyage() As String
            Get
                Return _VesselVoyage
            End Get
            Set(ByVal value As String)
                _VesselVoyage = value
            End Set
        End Property


        Property ShippinglineName() As String
            Get
                Return _ShippinglineName
            End Get
            Set(ByVal value As String)
                _ShippinglineName = value
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

        Property EtaDate() As DateTime
            Get
                Return _EtaDate
            End Get
            Set(ByVal value As DateTime)
                _EtaDate = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _EtdDate = ConDateTime.MinDate
            _VesselVoyage = ""
            _ShippinglineName = ""
            _PortOfDischargeCode = ""
            _EtaDate = ConDateTime.MinDate
        End Sub

    End Class

#End Region
End Namespace
