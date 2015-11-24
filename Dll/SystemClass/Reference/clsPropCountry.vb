Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass
#Region " Class Property of Country Info "

    <Serializable()> _
    Public Class clsPropCountry
        Inherits clsProp
        Private _CountryCode As String = ""
        Private _CountryName As String = ""
        Private _Idd As String = ""
        Private _RegionCode As String = ""
        Private _ZoneCode As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
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
        Public Property CountryName() As String
            Set(ByVal value As String)
                If _CountryName <> value Then
                    _CountryName = value
                End If
            End Set
            Get
                Return _CountryName
            End Get
        End Property
        ' 
        Public Property Idd() As String
            Set(ByVal value As String)
                If _Idd <> value Then
                    _Idd = value
                End If
            End Set
            Get
                Return _Idd
            End Get
        End Property
        ' 
        Public Property RegionCode() As String
            Set(ByVal value As String)
                If _RegionCode <> value Then
                    _RegionCode = value
                End If
            End Set
            Get
                Return _RegionCode
            End Get
        End Property
        ' 
        Public Property ZoneCode() As String
            Set(ByVal value As String)
                If _ZoneCode <> value Then
                    _ZoneCode = value
                End If
            End Set
            Get
                Return _ZoneCode
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
            _CountryCode = ""
            _CountryName = ""
            _Idd = ""
            _RegionCode = ""
            _ZoneCode = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
        End Sub
    End Class

#End Region

End Namespace