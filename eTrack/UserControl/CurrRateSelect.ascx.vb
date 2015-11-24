Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.Xml
Partial Class CurrRateSelect
    Inherits System.Web.UI.UserControl
#Region "Self Defne Property By lzw"
    Private dateType As String = ""
    Private dateValue As String = ""
    Private condition As String = ""
    Private orderBy As String = ""
    Private showCode As String = ""
    Private showName As String = ""
    Private numFile As Integer
    Private codeValue As String = ""
    Private nameValue As String = ""
    Private nameReadOnly As Boolean = False

    Public Property sDateType As String
        Get
            Return dateType
        End Get
        Set(ByVal value As String)
            If dateType = value Then
                Return
            End If
            dateType = value
        End Set
    End Property
    Public Property sDateValue As String
        Get
            Return dateValue
        End Get
        Set(ByVal value As String)
            If dateValue = value Then
                Return
            End If
            dateValue = value
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
            Return codeValue
        End Get
        Set(ByVal value As String)
            If codeValue = value Then
                Return
            End If
            codeValue = value
        End Set
    End Property
    Public Property sNameValue As String
        Get
            Return nameValue
        End Get
        Set(ByVal value As String)
            If nameValue = value Then
                Return
            End If
            nameValue = value
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
            txtCode.Text = Me.sCodeValue
            txtName.Text = Me.sNameValue
            txtName.ReadOnly = nameReadOnly
            If nameReadOnly Then
                txtName.Style.Add("background", "#ccc")
            End If
            Dim strSplit As String = "$1$2!^$"
            Dim script As String = String.Format("selCurrRateModule('" + strSplit + "{0}" + strSplit + "{1}" + strSplit + "{2}" + strSplit + "{3}',{4},{5},{6},'{7}');" & _
            "return false;", Me.sCondition, Me.sOrderBy, Me.sShowCode, Me.sShowName, Me.txtCode.ClientID, Me.txtName.ClientID, Me.sNumFile, "CurrRate")
            btnOpen.Attributes.Add("OnClick", script)
        End If
    End Sub
End Class
