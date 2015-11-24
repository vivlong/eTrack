Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Namespace ZZSystem

    Public Class clsPropColumn
        ' Properties
        Public Property Align() As HorizontalAlign
            Get
                Return Me._Align
            End Get
            Set(ByVal value As HorizontalAlign)
                Me._Align = value
            End Set
        End Property

        Public Property FieldName() As String
            Get
                Return Me._FieldName
            End Get
            Set(ByVal value As String)
                Me._FieldName = value
            End Set
        End Property

        Public Property FieldTitle() As String
            Get
                Return Me._FieldTitle
            End Get
            Set(ByVal value As String)
                Me._FieldTitle = value
            End Set
        End Property

        Public Property FieldType() As DbType
            Get
                Return Me._FieldType
            End Get
            Set(ByVal value As DbType)
                Me._FieldType = value
            End Set
        End Property

        Public Property FixedDigital() As Integer
            Get
                Return Me._FixedDigital
            End Get
            Set(ByVal value As Integer)
                Me._FixedDigital = value
            End Set
        End Property

        Public Property Format() As String
            Get
                Return Me._Format
            End Get
            Set(ByVal value As String)
                Me._Format = value
            End Set
        End Property

        Public Property HeaderImageUrl() As String
            Get
                Return Me._HeaderImageUrl
            End Get
            Set(ByVal value As String)
                Me._HeaderImageUrl = value
            End Set
        End Property

        Public Property Level() As Integer
            Get
                Return Me._Level
            End Get
            Set(ByVal value As Integer)
                Me._Level = value
            End Set
        End Property

        Public Property Position() As Integer
            Get
                Return Me._Position
            End Get
            Set(ByVal value As Integer)
                Me._Position = value
            End Set
        End Property

        Public Property SortField() As String
            Get
                Return Me._SortField
            End Get
            Set(ByVal value As String)
                Me._SortField = value
            End Set
        End Property

        Public Property TailZeroDelete() As Boolean
            Get
                Return Me._TailZeroDelete
            End Get
            Set(ByVal value As Boolean)
                Me._TailZeroDelete = value
            End Set
        End Property

        Public Property Visible() As Boolean
            Get
                Return Me._Visible
            End Get
            Set(ByVal value As Boolean)
                Me._Visible = value
            End Set
        End Property

        Public Property Width() As Decimal
            Get
                Return Me._Width
            End Get
            Set(ByVal value As Decimal)
                Me._Width = value
            End Set
        End Property


        ' Fields
        Private _Align As HorizontalAlign = HorizontalAlign.Left
        Private _FieldName As String = ""
        Private _FieldTitle As String = ""
        Private _FieldType As DbType
        Private _FixedDigital As Integer = 0
        Private _Format As String = ""
        Private _HeaderImageUrl As String = ""
        Private _Level As Integer = 1
        Private _Position As Integer
        Private _SortField As String = ""
        Private _TailZeroDelete As Boolean = False
        Private _Visible As Boolean
        Private _Width As Decimal = New Decimal
    End Class
End Namespace

