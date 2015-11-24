Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.Xml
Partial Class FieldSingleSelect
    Inherits System.Web.UI.UserControl
#Region "Self Defne Property By lzw"
    Private name As String = ""
    Private tableName As String = ""
    Private orderBy As String = ""
    Private condition As String = ""
    Private showName As String = ""
    Private numFile As Integer
    Private nameReadOnly As Boolean = False
    Public Property sName As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            If name = value Then
                Return
            End If
            name = value
        End Set
    End Property
    Public Property sTableName As String
        Get
            Return tableName
        End Get
        Set(ByVal value As String)
            If tableName = value Then
                Return
            End If
            tableName = value
        End Set
    End Property
    Public Property sOrderBy As String
        Get
            Return orderBy
        End Get
        Set(ByVal value As String)
            If orderBy = value Then
                Return
            End If
            orderBy = value
        End Set
    End Property
    Public Property sCondition As String
        Get
            Return condition
        End Get
        Set(ByVal value As String)
            If condition = value Then
                Return
            End If
            condition = value
        End Set
    End Property
    Public Property sShowName As String
        Get
            Return showName
        End Get
        Set(ByVal value As String)
            If showName = value Then
                Return
            End If
            showName = value
        End Set
    End Property
    Public Property sNameValue As String
        Get
            Return Me.txtName.Text
        End Get
        Set(ByVal value As String)
            If Me.txtName.Text = value Then
                Return
            End If
            Me.txtName.Text = value
        End Set
    End Property
    Public Property sNameReadOnly As Boolean
        Get
            Return nameReadOnly
        End Get
        Set(ByVal value As Boolean)
            If nameReadOnly = value Then
                Return
            End If
            nameReadOnly = value
        End Set
    End Property

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtName.Text = Me.sNameValue
            txtName.ReadOnly = nameReadOnly
            If nameReadOnly Then
                txtName.Style.Add("background", "#ccc")
            End If
            Dim strSplit As String = "$1$2!^$"
            Dim script As String = String.Format("selSingleModule('{0}" + strSplit + "{1}" + strSplit + "{2}" + strSplit + "{3}" + strSplit + "{4}',{5});" & _
            "return false;", Me.sName, Me.sTableName, Me.sCondition, Me.sOrderBy, Me.sShowName, Me.txtName.ClientID)
            btnOpen.Attributes.Add("OnClick", script)
        End If
    End Sub
End Class
