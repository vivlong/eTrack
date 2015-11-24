Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ZZSystem
    <OptionText()> _
    Public Class RoleInfoTemplate
        Implements ITemplate
        ' Methods
        Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
            Dim child As New Image
            child.ID = "imgInsert"
            child.AlternateText = "Add"
            child.ImageUrl = "~/Images/Edit/ed_Insert.gif"
            child.CssClass = "delImg"
            container.Controls.Add(child)
            child = New Image
            child.ID = "imgEdit"
            child.AlternateText = "Edit"
            child.ImageUrl = "~/Images/Edit/ed_Edit.gif"
            child.CssClass = "delImg"
            container.Controls.Add(child)
            child = New Image
            child.ID = "imgDelete"
            child.AlternateText = "Delete"
            child.ImageUrl = "~/Images/Edit/ed_Delete.gif"
            child.CssClass = "delImg"
            container.Controls.Add(child)
            child = New Image
            child.ID = "imgRestore"
            child.AlternateText = "Restore"
            child.ImageUrl = "~/Images/Edit/ed_Restore.gif"
            child.CssClass = "delImg"
            container.Controls.Add(child)
            child = New Image
            child.ID = "imgSetting"
            child.AlternateText = "Role Access Setting"
            child.ImageUrl = "~/Images/Edit/ed_Set.gif"
            child.CssClass = "delImg"
            container.Controls.Add(child)
        End Sub

    End Class
End Namespace

