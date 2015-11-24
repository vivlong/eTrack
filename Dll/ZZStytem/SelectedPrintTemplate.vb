Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Namespace ZZSystem
    <OptionText()> _
    Public Class SelectedPrintTemplate
        Implements ITemplate
        ' Methods
        Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
            Dim child As New HtmlInputCheckBox
            child.ID = "chkSelect"
            container.Controls.Add(child)
        End Sub

    End Class
End Namespace

