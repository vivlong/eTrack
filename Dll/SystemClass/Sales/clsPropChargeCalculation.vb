Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of ChargeCalculation Info "

    <Serializable()> _
    Public Class clsPropChargeCalculation
        Inherits clsProp
        Private _TrxNo As String = ""
        Private _AirLineId As String = ""
        Private _ApplyToTable As String = ""
        Private _ChargeTableNo As String = ""
        Private _Description As String = ""
        Private _DestCode As String = ""
        Private _DiscountPercent As String = ""
        Private _EffectiveDate As String = ""
        Private _EstTransitTime As String = ""
        Private _Frequency As String = ""
        Private _JobType As String = ""
        Private _ModuleCode As String = ""
        Private _Note As String = ""
        Private _OriginCode As String = ""
        Private _PartyCode As String = ""
        Private _PartyName As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _QuoteNo As String = ""
        Private _Remark As String = ""
        Private _TableType As String = ""
        Private _ViaPortCode As String = ""
        Private _StandardFlag As String = ""
        Private _UserDefine01 As String = ""
        Private _UserDefine02 As String = ""
        Private _UserDefine03 As String = ""
        Private _UserDefine04 As String = ""
        Private _UserDefine05 As String = ""
        Private _UserDefine06 As String = ""
        Private _UserDefine07 As String = ""
        Private _UserDefine08 As String = ""
        Private _UserDefine09 As String = ""
        Private _UserDefine10 As String = ""
        Private _UserDefine11 As String = ""
        Private _UserDefine12 As String = ""
        Private _UserDefine13 As String = ""
        Private _UserDefine14 As String = ""
        Private _UserDefine15 As String = ""
        Private _UserDefine16 As String = ""
        Private _UpdateDateTime As String = ""
        Private _CreateDateTime As String = ""
        Private _CreateBy As String = ""
        Private _UpdateBy As String = ""
        Private _StatusCode As String = ""
        ' 
        Public Property TrxNo() As String
            Set(ByVal value As String)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property
        ' 
        Public Property AirLineId() As String
            Set(ByVal value As String)
                If _AirLineId <> value Then
                    _AirLineId = value
                End If
            End Set
            Get
                Return _AirLineId
            End Get
        End Property
        ' 
        Public Property ApplyToTable() As String
            Set(ByVal value As String)
                If _ApplyToTable <> value Then
                    _ApplyToTable = value
                End If
            End Set
            Get
                Return _ApplyToTable
            End Get
        End Property
        ' 
        Public Property ChargeTableNo() As String
            Set(ByVal value As String)
                If _ChargeTableNo <> value Then
                    _ChargeTableNo = value
                End If
            End Set
            Get
                Return _ChargeTableNo
            End Get
        End Property
        ' 
        Public Property Description() As String
            Set(ByVal value As String)
                If _Description <> value Then
                    _Description = value
                End If
            End Set
            Get
                Return _Description
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
        Public Property DiscountPercent() As String
            Set(ByVal value As String)
                If _DiscountPercent <> value Then
                    _DiscountPercent = value
                End If
            End Set
            Get
                Return _DiscountPercent
            End Get
        End Property
        ' 
        Public Property EffectiveDate() As String
            Set(ByVal value As String)
                If _EffectiveDate <> value Then
                    _EffectiveDate = value
                End If
            End Set
            Get
                Return _EffectiveDate
            End Get
        End Property
        ' 
        Public Property EstTransitTime() As String
            Set(ByVal value As String)
                If _EstTransitTime <> value Then
                    _EstTransitTime = value
                End If
            End Set
            Get
                Return _EstTransitTime
            End Get
        End Property
        ' 
        Public Property Frequency() As String
            Set(ByVal value As String)
                If _Frequency <> value Then
                    _Frequency = value
                End If
            End Set
            Get
                Return _Frequency
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
        Public Property ModuleCode() As String
            Set(ByVal value As String)
                If _ModuleCode <> value Then
                    _ModuleCode = value
                End If
            End Set
            Get
                Return _ModuleCode
            End Get
        End Property
        ' 
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
        Public Property PartyCode() As String
            Set(ByVal value As String)
                If _PartyCode <> value Then
                    _PartyCode = value
                End If
            End Set
            Get
                Return _PartyCode
            End Get
        End Property
        ' 
        Public Property PartyName() As String
            Set(ByVal value As String)
                If _PartyName <> value Then
                    _PartyName = value
                End If
            End Set
            Get
                Return _PartyName
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
        Public Property QuoteNo() As String
            Set(ByVal value As String)
                If _QuoteNo <> value Then
                    _QuoteNo = value
                End If
            End Set
            Get
                Return _QuoteNo
            End Get
        End Property
        ' 
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
        ' 
        Public Property TableType() As String
            Set(ByVal value As String)
                If _TableType <> value Then
                    _TableType = value
                End If
            End Set
            Get
                Return _TableType
            End Get
        End Property
        ' 
        Public Property ViaPortCode() As String
            Set(ByVal value As String)
                If _ViaPortCode <> value Then
                    _ViaPortCode = value
                End If
            End Set
            Get
                Return _ViaPortCode
            End Get
        End Property
        ' 
        Public Property StandardFlag() As String
            Set(ByVal value As String)
                If _StandardFlag <> value Then
                    _StandardFlag = value
                End If
            End Set
            Get
                Return _StandardFlag
            End Get
        End Property
        ' 
        Public Property UserDefine01() As String
            Set(ByVal value As String)
                If _UserDefine01 <> value Then
                    _UserDefine01 = value
                End If
            End Set
            Get
                Return _UserDefine01
            End Get
        End Property
        ' 
        Public Property UserDefine02() As String
            Set(ByVal value As String)
                If _UserDefine02 <> value Then
                    _UserDefine02 = value
                End If
            End Set
            Get
                Return _UserDefine02
            End Get
        End Property
        ' 
        Public Property UserDefine03() As String
            Set(ByVal value As String)
                If _UserDefine03 <> value Then
                    _UserDefine03 = value
                End If
            End Set
            Get
                Return _UserDefine03
            End Get
        End Property
        ' 
        Public Property UserDefine04() As String
            Set(ByVal value As String)
                If _UserDefine04 <> value Then
                    _UserDefine04 = value
                End If
            End Set
            Get
                Return _UserDefine04
            End Get
        End Property
        ' 
        Public Property UserDefine05() As String
            Set(ByVal value As String)
                If _UserDefine05 <> value Then
                    _UserDefine05 = value
                End If
            End Set
            Get
                Return _UserDefine05
            End Get
        End Property
        ' 
        Public Property UserDefine06() As String
            Set(ByVal value As String)
                If _UserDefine06 <> value Then
                    _UserDefine06 = value
                End If
            End Set
            Get
                Return _UserDefine06
            End Get
        End Property
        ' 
        Public Property UserDefine07() As String
            Set(ByVal value As String)
                If _UserDefine07 <> value Then
                    _UserDefine07 = value
                End If
            End Set
            Get
                Return _UserDefine07
            End Get
        End Property
        ' 
        Public Property UserDefine08() As String
            Set(ByVal value As String)
                If _UserDefine08 <> value Then
                    _UserDefine08 = value
                End If
            End Set
            Get
                Return _UserDefine08
            End Get
        End Property
        ' 
        Public Property UserDefine09() As String
            Set(ByVal value As String)
                If _UserDefine09 <> value Then
                    _UserDefine09 = value
                End If
            End Set
            Get
                Return _UserDefine09
            End Get
        End Property
        ' 
        Public Property UserDefine10() As String
            Set(ByVal value As String)
                If _UserDefine10 <> value Then
                    _UserDefine10 = value
                End If
            End Set
            Get
                Return _UserDefine10
            End Get
        End Property
        ' 
        Public Property UserDefine11() As String
            Set(ByVal value As String)
                If _UserDefine11 <> value Then
                    _UserDefine11 = value
                End If
            End Set
            Get
                Return _UserDefine11
            End Get
        End Property
        ' 
        Public Property UserDefine12() As String
            Set(ByVal value As String)
                If _UserDefine12 <> value Then
                    _UserDefine12 = value
                End If
            End Set
            Get
                Return _UserDefine12
            End Get
        End Property
        ' 
        Public Property UserDefine13() As String
            Set(ByVal value As String)
                If _UserDefine13 <> value Then
                    _UserDefine13 = value
                End If
            End Set
            Get
                Return _UserDefine13
            End Get
        End Property
        ' 
        Public Property UserDefine14() As String
            Set(ByVal value As String)
                If _UserDefine14 <> value Then
                    _UserDefine14 = value
                End If
            End Set
            Get
                Return _UserDefine14
            End Get
        End Property
        ' 
        Public Property UserDefine15() As String
            Set(ByVal value As String)
                If _UserDefine15 <> value Then
                    _UserDefine15 = value
                End If
            End Set
            Get
                Return _UserDefine15
            End Get
        End Property
        ' 
        Public Property UserDefine16() As String
            Set(ByVal value As String)
                If _UserDefine16 <> value Then
                    _UserDefine16 = value
                End If
            End Set
            Get
                Return _UserDefine16
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
            _TrxNo = ""
            _AirLineId = ""
            _ApplyToTable = ""
            _ChargeTableNo = ""
            _Description = ""
            _DestCode = ""
            _DiscountPercent = ""
            _EffectiveDate = ""
            _EstTransitTime = ""
            _Frequency = ""
            _JobType = ""
            _ModuleCode = ""
            _Note = ""
            _OriginCode = ""
            _PartyCode = ""
            _PartyName = ""
            _PortOfDischargeCode = ""
            _PortOfLoadingCode = ""
            _QuoteNo = ""
            _Remark = ""
            _TableType = ""
            _ViaPortCode = ""
            _StandardFlag = ""
            _UserDefine01 = ""
            _UserDefine02 = ""
            _UserDefine03 = ""
            _UserDefine04 = ""
            _UserDefine05 = ""
            _UserDefine06 = ""
            _UserDefine07 = ""
            _UserDefine08 = ""
            _UserDefine09 = ""
            _UserDefine10 = ""
            _UserDefine11 = ""
            _UserDefine12 = ""
            _UserDefine13 = ""
            _UserDefine14 = ""
            _UserDefine15 = ""
            _UserDefine16 = ""
            _UpdateDateTime = ""
            _CreateDateTime = ""
            _CreateBy = ""
            _UpdateBy = ""
            _StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace