Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of RI Info "

    <Serializable()> _
    Public Class clsPropRI
        Inherits clsProp
        Private _TrxNo As Int64
        Private _ReleasingInstructionNo As String = ""
        Private _OrganisationCode As String = ""
        Private _MasterJobNo As String = ""
        Private _VesselName As String = ""
        Private _VoyageNo As String = ""
        Private _EtaDate As DateTime
        Private _ReleaseType As String = ""
        Private _ReleasingDestinationCode As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _FirstViaPortCode As String = ""
        Private _SecondViaPortCode As String = ""
        Private _ThirdViaPortCode As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _DetentionCode As String = ""
        Private _DetentionFreeDay As String = ""
        Private _SiteCode As String = ""
        Private _WorkStation As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _ROReleaseDate As DateTime
        Private _UserNo As String = ""
        ' 
        Public Property TrxNo() As Integer
            Set(ByVal value As Integer)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property
        ' 
        Public Property ReleasingInstructionNo() As String
            Set(ByVal value As String)
                If _ReleasingInstructionNo <> value Then
                    _ReleasingInstructionNo = value
                End If
            End Set
            Get
                Return _ReleasingInstructionNo
            End Get
        End Property
        ' 
        Public Property OrganisationCode() As String
            Set(ByVal value As String)
                If _OrganisationCode <> value Then
                    _OrganisationCode = value
                End If
            End Set
            Get
                Return _OrganisationCode
            End Get
        End Property
        ' 
        Public Property MasterJobNo() As String
            Set(ByVal value As String)
                If _MasterJobNo <> value Then
                    _MasterJobNo = value
                End If
            End Set
            Get
                Return _MasterJobNo
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
        Public Property EtaDate() As DateTime
            Set(ByVal value As DateTime)
                If _EtaDate <> value Then
                    _EtaDate = value
                End If
            End Set
            Get
                Return _EtaDate
            End Get
        End Property
        ' 
        Public Property ReleaseType() As String
            Set(ByVal value As String)
                If _ReleaseType <> value Then
                    _ReleaseType = value
                End If
            End Set
            Get
                Return _ReleaseType
            End Get
        End Property
        ' 
        Public Property ReleasingDestinationCode() As String
            Set(ByVal value As String)
                If _ReleasingDestinationCode <> value Then
                    _ReleasingDestinationCode = value
                End If
            End Set
            Get
                Return _ReleasingDestinationCode
            End Get
        End Property
        ' 
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
        ' 
        Public Property FirstViaPortCode() As String
            Set(ByVal value As String)
                If _FirstViaPortCode <> value Then
                    _FirstViaPortCode = value
                End If
            End Set
            Get
                Return _FirstViaPortCode
            End Get
        End Property
        ' 
        Public Property SecondViaPortCode() As String
            Set(ByVal value As String)
                If _SecondViaPortCode <> value Then
                    _SecondViaPortCode = value
                End If
            End Set
            Get
                Return _SecondViaPortCode
            End Get
        End Property
        ' 
        Public Property ThirdViaPortCode() As String
            Set(ByVal value As String)
                If _ThirdViaPortCode <> value Then
                    _ThirdViaPortCode = value
                End If
            End Set
            Get
                Return _ThirdViaPortCode
            End Get
        End Property
        ' 
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
        ' 
        Public Property DetentionCode() As String
            Set(ByVal value As String)
                If _DetentionCode <> value Then
                    _DetentionCode = value
                End If
            End Set
            Get
                Return _DetentionCode
            End Get
        End Property
        ' 
        Public Property DetentionFreeDay() As String
            Set(ByVal value As String)
                If _DetentionFreeDay <> value Then
                    _DetentionFreeDay = value
                End If
            End Set
            Get
                Return _DetentionFreeDay
            End Get
        End Property
        ' 
        Public Property SiteCode() As String
            Set(ByVal value As String)
                If _SiteCode <> value Then
                    _SiteCode = value
                End If
            End Set
            Get
                Return _SiteCode
            End Get
        End Property
        ' 
        Public Property WorkStation() As String
            Set(ByVal value As String)
                If _WorkStation <> value Then
                    _WorkStation = value
                End If
            End Set
            Get
                Return _WorkStation
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

        Public Property ROReleaseDate() As DateTime
            Set(ByVal value As DateTime)
                If _ROReleaseDate <> value Then
                    _ROReleaseDate = value
                End If
            End Set
            Get
                Return _ROReleaseDate
            End Get
        End Property
        Public Property UserNo() As String
            Set(ByVal value As String)
                If _UserNo <> value Then
                    _UserNo = value
                End If
            End Set
            Get
                Return _UserNo
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _ReleasingInstructionNo = ""
            _OrganisationCode = ""
            _MasterJobNo = ""
            _VesselName = ""
            _VoyageNo = ""
            _EtaDate = ConDateTime.MinDate
            _ReleaseType = ""
            _ReleasingDestinationCode = ""
            _PortOfLoadingCode = ""
            _FirstViaPortCode = ""
            _SecondViaPortCode = ""
            _ThirdViaPortCode = ""
            _PortOfDischargeCode = ""
            _DetentionCode = ""
            _DetentionFreeDay = ""
            _SiteCode = ""
            _WorkStation = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _ROReleaseDate = ConDateTime.MinDate
            _UserNo = ""
        End Sub
    End Class



#End Region
End Namespace