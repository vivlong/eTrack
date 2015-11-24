Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of GridSet"

    <Serializable()> _
    Public Class clsPropGridSetEdit
        Inherits clsProp

        Private _sTableName As String = ""

        Private _bAdded As Boolean = False
        Private _bFieldVisibleByUser As Boolean = False
        Private _sFieldName As String = ""
        Private _sFieldType As String = ""
        Private _lFieldOrder As String = ""
        Private _sEnglishTitle As String = ""

        Public Property sTableName() As String
            Set(ByVal value As String)
                If _sTableName <> value Then
                    _sTableName = value
                End If
            End Set
            Get
                Return _sTableName
            End Get
        End Property

        Public Property bAdded() As Boolean
            Set(ByVal value As Boolean)
                If _bAdded <> value Then
                    _bAdded = value
                End If
            End Set
            Get
                Return _bAdded
            End Get
        End Property
        Public Property bFieldVisibleByUser() As Boolean
            Set(ByVal value As Boolean)
                If _bFieldVisibleByUser <> value Then
                    _bFieldVisibleByUser = value
                End If
            End Set
            Get
                Return _bFieldVisibleByUser
            End Get
        End Property
        Public Property sFieldName() As String
            Set(ByVal value As String)
                If _sFieldName <> value Then
                    _sFieldName = value
                End If
            End Set
            Get
                Return _sFieldName
            End Get
        End Property
        Public Property sFieldType() As String
            Set(ByVal value As String)
                If _sFieldType <> value Then
                    _sFieldType = value
                End If
            End Set
            Get
                Return _sFieldType
            End Get
        End Property
        Public Property lFieldOrder() As String
            Set(ByVal value As String)
                If _lFieldOrder <> value Then
                    _lFieldOrder = value
                End If
            End Set
            Get
                Return _lFieldOrder
            End Get
        End Property
        Public Property sEnglishTitle() As String
            Set(ByVal value As String)
                If _sEnglishTitle <> value Then
                    _sEnglishTitle = value
                End If
            End Set
            Get
                Return _sEnglishTitle
            End Get
        End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _sTableName = ""

            _bAdded = False
            _bFieldVisibleByUser = False
            _sFieldName = strId
            _sFieldType = ""
            _lFieldOrder = ""
            _sEnglishTitle = ""
        End Sub
    End Class



#End Region
End Namespace