Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of SaleActivity Info "

    <Serializable()> _
    Public Class clsPropSaleActivity
        Inherits clsProp
        Private _TrxNo As String = ""
        Private _SalesmanCode As String = ""
        Private _ContactName As String = ""
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _DateTime As String = ""
        Private _Fax As String = ""
        Private _Telephone As String = ""
        Private _Remark As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
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
        Public Property SalesmanCode() As String
            Set(ByVal value As String)
                If _SalesmanCode <> value Then
                    _SalesmanCode = value
                End If
            End Set
            Get
                Return _SalesmanCode
            End Get
        End Property
        ' 
        Public Property ContactName() As String
            Set(ByVal value As String)
                If _ContactName <> value Then
                    _ContactName = value
                End If
            End Set
            Get
                Return _ContactName
            End Get
        End Property
        ' 
        Public Property CustomerCode() As String
            Set(ByVal value As String)
                If _CustomerCode <> value Then
                    _CustomerCode = value
                End If
            End Set
            Get
                Return _CustomerCode
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
        Public Property DateTime() As String
            Set(ByVal value As String)
                If _DateTime <> value Then
                    _DateTime = value
                End If
            End Set
            Get
                Return _DateTime
            End Get
        End Property
        ' 
        Public Property Fax() As String
            Set(ByVal value As String)
                If _Fax <> value Then
                    _Fax = value
                End If
            End Set
            Get
                Return _Fax
            End Get
        End Property
        ' 
        Public Property Telephone() As String
            Set(ByVal value As String)
                If _Telephone <> value Then
                    _Telephone = value
                End If
            End Set
            Get
                Return _Telephone
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
            _TrxNo = ""
            _SalesmanCode = ""
            _ContactName = ""
            _CustomerCode = ""
            _CustomerName = ""
            _DateTime = ""
            _Fax = ""
            _Telephone = ""
            _Remark = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
        End Sub

    End Class

#End Region
End Namespace