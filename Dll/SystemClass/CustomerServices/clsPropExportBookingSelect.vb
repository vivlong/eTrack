Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class of Property ExportBookingSelect "

    <Serializable()> _
    Public Class clsPropExportBookingSelect
        Inherits clsProp

        Private _VoyageID As String = ""
        Private _VoyageNo As String = ""
        Private _VesselCode As String = ""
        Private _VesselName As String = ""
        Private _ShippinglineCode As String = ""
        Private _UcrNo As String = ""
        Private _AttachmentFlag As String = ""
        Private _Ata As DateTime
        Private _Eta As DateTime
        Private _Etd As DateTime
        Private _Note As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PrintFlag As String = ""
        Private _Remark As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime

        Public Property VoyageID() As String
            Set(ByVal value As String)
                If _VoyageID <> value Then
                    _VoyageID = value
                End If
            End Set
            Get
                Return _VoyageID
            End Get
        End Property

        Public Property VoyageNo() As String
            Set(ByVal value As String)
                If _VoyageNo <> value Then
                    _VoyageNo = value
                End If
            End Set
            Get
                Return _VoyageNo
            End Get
        End Property

        Public Property VesselCode() As String
            Set(ByVal value As String)
                If _VesselCode <> value Then
                    _VesselCode = value
                End If
            End Set
            Get
                Return _VesselCode
            End Get
        End Property

        Public Property VesselName() As String
            Set(ByVal value As String)
                If _VesselName <> value Then
                    _VesselName = value
                End If
            End Set
            Get
                Return _VesselName
            End Get
        End Property

        Public Property ShippinglineCode() As String
            Set(ByVal value As String)
                If _ShippinglineCode <> value Then
                    _ShippinglineCode = value
                End If
            End Set
            Get
                Return _ShippinglineCode
            End Get
        End Property

        Public Property UcrNo() As String
            Set(ByVal value As String)
                If _UcrNo <> value Then
                    _UcrNo = value
                End If
            End Set
            Get
                Return _UcrNo
            End Get
        End Property

        Public Property AttachmentFlag() As String
            Set(ByVal value As String)
                If _AttachmentFlag <> value Then
                    _AttachmentFlag = value
                End If
            End Set
            Get
                Return _AttachmentFlag
            End Get
        End Property

        Public Property Ata() As DateTime
            Set(ByVal value As DateTime)
                If _Ata <> value Then
                    _Ata = value
                End If
            End Set
            Get
                Return _Ata
            End Get
        End Property

        Public Property Eta() As DateTime
            Set(ByVal value As DateTime)
                If _Eta <> value Then
                    _Eta = value
                End If
            End Set
            Get
                Return _Eta
            End Get
        End Property

        Public Property Etd() As DateTime
            Set(ByVal value As DateTime)
                If _Etd <> value Then
                    _Etd = value
                End If
            End Set
            Get
                Return _Etd
            End Get
        End Property

        Public Property Note() As String
            Set(ByVal value As String)
                If _Note <> value Then
                    _Note = value
                End If
            End Set
            Get
                Return _Note
            End Get
        End Property

        Public Property PortOfDischargeCode() As String
            Set(ByVal value As String)
                If _PortOfDischargeCode <> value Then
                    _PortOfDischargeCode = value
                End If
            End Set
            Get
                Return _PortOfDischargeCode
            End Get
        End Property

        Public Property PortOfDischargeName() As String
            Set(ByVal value As String)
                If _PortOfDischargeName <> value Then
                    _PortOfDischargeName = value
                End If
            End Set
            Get
                Return _PortOfDischargeName
            End Get
        End Property

        Public Property PortOfLoadingCode() As String
            Set(ByVal value As String)
                If _PortOfLoadingCode <> value Then
                    _PortOfLoadingCode = value
                End If
            End Set
            Get
                Return _PortOfLoadingCode
            End Get
        End Property

        Public Property PrintFlag() As String
            Set(ByVal value As String)
                If _PrintFlag <> value Then
                    _PrintFlag = value
                End If
            End Set
            Get
                Return _PrintFlag
            End Get
        End Property

        Public Property Remark() As String
            Set(ByVal value As String)
                If _Remark <> value Then
                    _Remark = value
                End If
            End Set
            Get
                Return _Remark
            End Get
        End Property

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

        Public Property CreateDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _CreateDateTime <> value Then
                    _CreateDateTime = value
                End If
            End Set
            Get
                Return _CreateDateTime
            End Get
        End Property

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

        Public Property UpdateDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _UpdateDateTime <> value Then
                    _UpdateDateTime = value
                End If
            End Set
            Get
                Return _UpdateDateTime
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _VoyageID = intId
            _VoyageNo = ""
            _VesselCode = ""
            _VesselName = ""
            _ShippinglineCode = ""
            _UcrNo = ""
            _AttachmentFlag = ""
            _Ata = ConDateTime.MinDate
            _Eta = ConDateTime.MinDate
            _Etd = ConDateTime.MinDate
            _Note = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _PrintFlag = ""
            _Remark = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
        End Sub

    End Class

#End Region
End Namespace
