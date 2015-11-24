Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of FunctionInfoSub"

    <Serializable()> _
    Public Class clsPropFunctionInfoSub
        Inherits clsProp

        Private _sFunNo As String = ""
        Private _lSubId As Integer
        Private _sCode As String = ""
        Private _sImage As String = ""
        Private _sName As String = ""
        Private _bFlag As String = ""
        Private _SubType As String = ""
        'Private _UserFlag As String = ""

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
        Public Property lSubId() As Integer
            Set(ByVal value As Integer)
                If _lSubId <> value Then
                    _lSubId = value
                End If
            End Set
            Get
                Return _lSubId
            End Get
        End Property
        Public Property sCode() As String
            Set(ByVal value As String)
                If _sCode <> value Then
                    _sCode = value
                End If
            End Set
            Get
                Return _sCode
            End Get
        End Property
        Public Property sName() As String
            Set(ByVal value As String)
                If _sName <> value Then
                    _sName = value
                End If
            End Set
            Get
                Return _sName
            End Get
        End Property
        Public Property bFlag() As String
            Set(ByVal value As String)
                If _bFlag <> value Then
                    _bFlag = value
                End If
            End Set
            Get
                Return _bFlag
            End Get
        End Property
        Public Property SubType() As String
            Set(ByVal value As String)
                If _SubType <> value Then
                    _SubType = value
                End If
            End Set
            Get
                Return _SubType
            End Get
        End Property

        '' 
        'Public Property UserFlag() As String
        '    Set(ByVal value As String)
        '        If _UserFlag <> value Then
        '            _UserFlag = value
        '        End If
        '    End Set
        '    Get
        '        Return _UserFlag
        '    End Get
        'End Property

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _sFunNo = strId
            _lSubId = 0
            _sCode = ""
            _sName = ""
            _bFlag = ""
            _SubType = ""
        End Sub
    End Class



#End Region
End Namespace