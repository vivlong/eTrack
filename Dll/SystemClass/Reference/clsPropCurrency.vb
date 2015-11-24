Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Currency Info "

    <Serializable()> _
    Public Class clsPropCurrency
        Inherits clsProp
        Private _CurrCode As String = ""
        Private _CurrDescription As String = ""
        Private _LargeCurrName As String = ""
        Private _SmallCurrName As String = ""
        Private _VariancePercent As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        ' 
        Public Property CurrCode() As String
            Set(ByVal value As String)
                If _CurrCode <> value Then
                    _CurrCode = value
                End If
            End Set
            Get
                Return _CurrCode
            End Get
        End Property
        ' 
        Public Property CurrDescription() As String
            Set(ByVal value As String)
                If _CurrDescription <> value Then
                    _CurrDescription = value
                End If
            End Set
            Get
                Return _CurrDescription
            End Get
        End Property
        ' 
        Public Property LargeCurrName() As String
            Set(ByVal value As String)
                If _LargeCurrName <> value Then
                    _LargeCurrName = value
                End If
            End Set
            Get
                Return _LargeCurrName
            End Get
        End Property
        ' 
        Public Property SmallCurrName() As String
            Set(ByVal value As String)
                If _SmallCurrName <> value Then
                    _SmallCurrName = value
                End If
            End Set
            Get
                Return _SmallCurrName
            End Get
        End Property
        ' 
        Public Property VariancePercent() As String
            Set(ByVal value As String)
                If _VariancePercent <> value Then
                    _VariancePercent = value
                End If
            End Set
            Get
                Return _VariancePercent
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
            _CurrCode = ""
            _CurrDescription = ""
            _LargeCurrName = ""
            _SmallCurrName = ""
            _VariancePercent = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
        End Sub

    End Class

#End Region
End Namespace