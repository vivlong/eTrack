Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Event Info "
    <Serializable()> _
    Public Class clsPropEvent
        Inherits clsProp
        Private _TrxNo As Integer
        Private _POLine As Integer
        Private _LineItemNo As Integer
        Private _EventLineNo As String = ""
        Private _EventDate As DateTime
        Private _EventTitle As String = ""
        Private _Comments As String = ""
        Private _CreateDate As DateTime
        Private _EnteredBy As String = ""
        ' 
        Public Property TrxNo() As Integer
            Set(ByVal value As Integer)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property
        ' 
        Public Property POLine() As Integer
            Set(ByVal value As Integer)
                If _POLine <> value Then
                    _POLine = value
                End If
            End Set
            Get
                Return _POLine
            End Get
        End Property
        ' 
        Public Property LineItemNo() As Integer
            Set(ByVal value As Integer)
                If _LineItemNo <> value Then
                    _LineItemNo = value
                End If
            End Set
            Get
                Return _LineItemNo
            End Get
        End Property
        ' 
        Public Property EventLineNo() As String
            Set(ByVal value As String)
                If _EventLineNo <> value Then
                    _EventLineNo = value
                End If
            End Set
            Get
                Return _EventLineNo
            End Get
        End Property
        ' 
        Public Property EventDate() As DateTime
            Set(ByVal value As DateTime)
                If _EventDate <> value Then
                    _EventDate = value
                End If
            End Set
            Get
                Return _EventDate
            End Get
        End Property
        ' 
        Public Property EventTitle() As String
            Set(ByVal value As String)
                If _EventTitle <> value Then
                    _EventTitle = value
                End If
            End Set
            Get
                Return _EventTitle
            End Get
        End Property
        ' 
        Public Property Comments() As String
            Set(ByVal value As String)
                If _Comments <> value Then
                    _Comments = value
                End If
            End Set
            Get
                Return _Comments
            End Get
        End Property
        ' 
        Public Property CreateDate() As DateTime
            Set(ByVal value As DateTime)
                If _CreateDate <> value Then
                    _CreateDate = value
                End If
            End Set
            Get
                Return _CreateDate
            End Get
        End Property
        ' 
        Public Property EnteredBy() As String
            Set(ByVal value As String)
                If _EnteredBy <> value Then
                    _EnteredBy = value
                End If
            End Set
            Get
                Return _EnteredBy
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _POLine = 0
            _LineItemNo = 0
            _EventLineNo = ""
            _EventDate = ConDateTime.MinDate
            _EventTitle = ""
            _Comments = ""
            _CreateDate = ConDateTime.MinDate
            _EnteredBy = ""
        End Sub
    End Class
#End Region
End Namespace