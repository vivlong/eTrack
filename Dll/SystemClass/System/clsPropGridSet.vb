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
    Public Class clsPropGridSet
        Inherits clsProp

        Private _sTableName As String = ""
        Private _sFieldName As String = ""
        Private _sSortField As String = ""
        Private _sFieldType As String = ""
        Private _bSetting As String = ""
        Private _bFieldVisible As String = ""
        Private _lFieldOrder As String = ""
        Private _lFieldWidth As String = ""
        Private _sChineseTitle As String = ""
        Private _sEnglishTitle As String = ""
        Private _sChineseFormat As String = ""
        Private _sEnglishFormat As String = ""
        Private _sHeaderImageUrl As String = ""
        ' 
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
        Public Property sSortField() As String
            Set(ByVal value As String)
                If _sSortField <> value Then
                    _sSortField = value
                End If
            End Set
            Get
                Return _sSortField
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
        Public Property bSetting() As String
            Set(ByVal value As String)
                If _bSetting <> value Then
                    _bSetting = value
                End If
            End Set
            Get
                Return _bSetting
            End Get
        End Property
        Public Property bFieldVisible() As String
            Set(ByVal value As String)
                If _bFieldVisible <> value Then
                    _bFieldVisible = value
                End If
            End Set
            Get
                Return _bFieldVisible
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
        Public Property lFieldWidth() As String
            Set(ByVal value As String)
                If _lFieldWidth <> value Then
                    _lFieldWidth = value
                End If
            End Set
            Get
                Return _lFieldWidth
            End Get
        End Property
        Public Property sChineseTitle() As String
            Set(ByVal value As String)
                If _sChineseTitle <> value Then
                    _sChineseTitle = value
                End If
            End Set
            Get
                Return _sChineseTitle
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
        Public Property sChineseFormat() As String
            Set(ByVal value As String)
                If _sChineseFormat <> value Then
                    _sChineseFormat = value
                End If
            End Set
            Get
                Return _sChineseFormat
            End Get
        End Property
        Public Property sEnglishFormat() As String
            Set(ByVal value As String)
                If _sEnglishFormat <> value Then
                    _sEnglishFormat = value
                End If
            End Set
            Get
                Return _sEnglishFormat
            End Get
        End Property
        Public Property sHeaderImageUrl() As String
            Set(ByVal value As String)
                If _sHeaderImageUrl <> value Then
                    _sHeaderImageUrl = value
                End If
            End Set
            Get
                Return _sHeaderImageUrl
            End Get
        End Property


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            '_sFunNo = strId
            _sTableName = strId
            _sFieldName = ""
            _sSortField = ""
            _sFieldType = ""
            _bSetting = ""
            _bFieldVisible = ""
            _lFieldOrder = ""
            _lFieldWidth = ""
            _sChineseTitle = ""
            _sEnglishTitle = ""
            _sChineseFormat = ""
            _sEnglishFormat = ""
            _sHeaderImageUrl = ""
        End Sub
    End Class



#End Region
End Namespace