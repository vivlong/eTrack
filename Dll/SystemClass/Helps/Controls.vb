Imports Microsoft.VisualBasic
Imports System.Security
Imports System.IO
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports System.Text
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Namespace SystemClass
    Public Class Controls
        Public Shared _instance As New Controls
        Public Shared ReadOnly Property Instance() As Controls
            Get
                If _instance Is Nothing Then
                    _instance = New Controls
                End If
                Return _instance
            End Get
        End Property
        Public Sub setFocusControl(ByVal objControl As TextBox, ByVal dotlen As Integer)
            If Not objControl.ReadOnly Then
                objControl.Attributes.Add("OnFocus", "NumberFocus(event,this);")
                objControl.Attributes.Add("OnBlur", "NumberBlur(event," + dotlen.ToString() + ",true);")
                objControl.Attributes.Add("OnKeypress", "NumberInput(event," + dotlen.ToString() + ");")
            End If
        End Sub


    End Class
End Namespace