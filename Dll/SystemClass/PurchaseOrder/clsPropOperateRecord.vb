Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of PO Info "

    <Serializable()> _
    Public Class clsPropOperateRecord
        Inherits clsProp
        Private _lUserId As String = ""
        Private _dOperateDate As DateTime
        Private _sRemark As String = ""
        Private _sIPAddress As String = ""
        Private _sUserName As String = ""
        ' 
        Public Property lUserId() As String
            Set(ByVal value As String)
                If _lUserId <> value Then
                    _lUserId = value
                End If
            End Set
            Get
                Return _lUserId
            End Get
        End Property
        ' 
        Public Property dOperateDate() As DateTime
            Set(ByVal value As DateTime)
                If _dOperateDate <> value Then
                    _dOperateDate = value
                End If
            End Set
            Get
                Return _dOperateDate
            End Get
        End Property
        ' 
        Public Property sRemark() As String
            Set(ByVal value As String)
                If _sRemark <> value Then
                    _sRemark = value
                End If
            End Set
            Get
                Return _sRemark
            End Get
        End Property
        ' 
        Public Property sIPAddress() As String
            Set(ByVal value As String)
                If _sIPAddress <> value Then
                    _sIPAddress = value
                End If
            End Set
            Get
                Return _sIPAddress
            End Get
        End Property
        ' 
        Public Property sUserName() As String
            Set(ByVal value As String)
                If _sUserName <> value Then
                    _sUserName = value
                End If
            End Set
            Get
                Return _sUserName
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _lUserId = intId
            _dOperateDate = ConDateTime.MinDate
            _sRemark = ""
            _sIPAddress = ""
            _sUserName = ""
        End Sub

    End Class

#End Region
End Namespace