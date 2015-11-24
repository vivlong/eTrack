Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.Xml
Partial Class FieldDoubleSelect
    Inherits System.Web.UI.UserControl
#Region "Self Defne Property By lzw"
    Private code As String = ""
    Private name As String = ""
    Private tableName As String = ""
    Private orderBy As String = ""
    Private condition As String = ""
    Private showCode As String = ""
    Private showName As String = ""
    Private numFile As Integer
    Private nameReadOnly As Boolean = False
    Private isShowCode As Boolean = True
    Private type As String = ""
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
    Public Property sCode As String
        Get
            Return code
        End Get
        Set(ByVal value As String)
            If code = value Then
                Return
            End If
            code = value
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
    Public Property sShowCode As String
        Get
            Return showCode
        End Get
        Set(ByVal value As String)
            If showCode = value Then
                Return
            End If
            showCode = value
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
    Public Property sNumFile As Integer
        Get
            Return numFile
        End Get
        Set(ByVal value As Integer)
            If numFile = value Then
                Return
            End If
            numFile = value
        End Set
    End Property
    Public Property sCodeValue As String
        Get
            Return Me.txtCode.Text
        End Get
        Set(ByVal value As String)
            If Me.txtCode.Text = value Then
                Return
            End If
            Me.txtCode.Text = value
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
    Public Property sIsShowCode As Boolean
        Get
            Return isShowCode
        End Get
        Set(ByVal value As Boolean)
            If isShowCode = value Then
                Return
            End If
            isShowCode = value
        End Set
    End Property
    Public Property sType As String
        Get
            Return type
        End Get
        Set(ByVal value As String)
            If type = value Then
                Return
            End If
            type = value
        End Set
    End Property

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtCode.Text = Me.sCodeValue
            txtName.Text = Me.sNameValue
            txtName.ReadOnly = nameReadOnly
            txtCode.Visible = sIsShowCode
            If nameReadOnly Then
                txtName.Style.Add("background", "#ccc")
            End If
            Dim strSplit As String = "$1$2!^$"
            Dim script As String = String.Format("selDoubleModule('{0} " + strSplit + "{1}" + strSplit + "{2}" + strSplit + "{3}" + strSplit + "{4}" + strSplit + "{5}" + strSplit + "{6}',{7},{8},{9},'{10}');" & _
            "return false;", Me.sCode, Me.sName, Me.sTableName, Me.sCondition, Me.sOrderBy, Me.sShowCode, Me.sShowName, Me.txtCode.ClientID, Me.txtName.ClientID, Me.sNumFile, Me.sType)
            btnOpen.Attributes.Add("OnClick", script)
        End If
    End Sub
End Class
