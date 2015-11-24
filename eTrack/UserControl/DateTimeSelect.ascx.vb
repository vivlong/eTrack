
Partial Class DateTimeSelect
    Inherits System.Web.UI.UserControl

#Region "Self Defne Property By lzw"
    Public isFocus As Boolean = False
    Public Property sIsFocus As Boolean
        Get
            Return isFocus
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.txtDateTime.Focus()
            End If
            Return
        End Set
    End Property
    Private includeTime As Boolean = False
    Public Property sIncludeTime As Boolean
        Get
            Return includeTime
        End Get
        Set(ByVal value As Boolean)
            If includeTime = value Then
                Return
            End If
            includeTime = value
        End Set
    End Property
    Private dateValue As String = "0001-01-01"
    Public Property sDateValue As String
        Get
            Return dateValue
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "0001-01-01"
            If dateValue = value Then
                Return
            End If
            ConvertDateTime(txtDateTime, value)
            dateValue = value
        End Set
    End Property
    Public isReadOnly As Boolean = False
    Public Property ReadOnlyNew As Boolean
        Get
            Return isReadOnly
        End Get
        Set(ByVal value As Boolean)
            isReadOnly = value
            readOnlyChange()
        End Set
    End Property
#End Region

    Private Sub readOnlyChange()
        Me.btnOpen.Enabled = (Not ReadOnlyNew)
        Me.txtDateTime.ReadOnly = ReadOnlyNew
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If sIncludeTime Then
                btnOpen.Attributes.Add("OnClick", "WdatePicker({el:'" + txtDateTime.ClientID + "',dateFmt:'dd/MM/yyyy HH:mm'});return false;")
                txtDateTime.Style.Add("width", "110px")
                txtDateTime.MaxLength = 16
            Else
                btnOpen.Attributes.Add("OnClick", "WdatePicker({el:'" + txtDateTime.ClientID + "',dateFmt:'dd/MM/yyyy'});return false;")
                txtDateTime.Style.Add("width", "100px")
                txtDateTime.MaxLength = 10
            End If
            ConvertDateTime(txtDateTime, sDateValue)
        End If
    End Sub
    Private Sub ConvertDateTime(ByRef con As TextBox, ByVal strVal As DateTime)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    con.Text = strVal.ToString("dd/MM/yyyy")
                Else
                    con.Text = strVal.ToString("dd/MM/yyyy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
End Class
