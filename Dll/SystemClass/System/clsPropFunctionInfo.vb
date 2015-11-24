Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of FunctionInfo"

    <Serializable()> _
    Public Class clsPropFunctionInfo
        Inherits clsProp

        Private _sFunNo As String = ""
        Private _sFunName As String = ""
        Private _sFunUrl As String = ""
        Private _sImage As String = ""
        Private _sParentNo As String = ""
        Private _lType As Integer
        Private _UserFlag As String = ""

        ' 
        Public Property sFunNo() As String
            Set(ByVal value As String)
                If _sFunNo <> value Then
                    _sFunNo = value
                End If
            End Set
            Get
                Return _sFunNo
            End Get
        End Property
        ' 
        Public Property sFunName() As String
            Set(ByVal value As String)
                If _sFunName <> value Then
                    _sFunName = value
                End If
            End Set
            Get
                Return _sFunName
            End Get
        End Property
        ' 
        Public Property sFunUrl() As String
            Set(ByVal value As String)
                If _sFunUrl <> value Then
                    _sFunUrl = value
                End If
            End Set
            Get
                Return _sFunUrl
            End Get
        End Property
        ' 
        Public Property sImage() As String
            Set(ByVal value As String)
                If _sImage <> value Then
                    _sImage = value
                End If
            End Set
            Get
                Return _sImage
            End Get
        End Property
        ' 
        Public Property sParentNo() As String
            Set(ByVal value As String)
                If _sParentNo <> value Then
                    _sParentNo = value
                End If
            End Set
            Get
                Return _sParentNo
            End Get
        End Property
        ' 
        Public Property lType() As Integer
            Set(ByVal value As Integer)
                If _lType <> value Then
                    _lType = value
                End If
            End Set
            Get
                Return _lType
            End Get
        End Property
        ' 
        Public Property UserFlag() As String
            Set(ByVal value As String)
                If _UserFlag <> value Then
                    _UserFlag = value
                End If
            End Set
            Get
                Return _UserFlag
            End Get
        End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _sFunNo = strId
            _sFunName = ""
            _sFunUrl = ""
            _sImage = ""
            _sParentNo = ""
            _lType = -1
            _UserFlag = ""
        End Sub
    End Class



#End Region
End Namespace