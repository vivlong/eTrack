Imports SysMagic.SystemClass
Class FirstPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            If Request("Redirect") Is Nothing Then
                Dim objUser As clsUser = CType(Session(ConSessionName.UserInfo), clsUser)
                If objUser IsNot Nothing Then
                    If objUser.NavigatePage <> "" Then
                        Response.Redirect(objUser.NavigatePage)
                    End If
                Else
                    Response.Write("<script>window.close();alert('You haven\'t log on yet or your session has time out, please log on again.');window.open('loading.aspx?tourl=Default.aspx','_parent');</script>")
                End If
            End If
        End If
    End Sub
End Class