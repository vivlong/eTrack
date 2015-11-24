Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Partial Class LogDelete
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private returnValue As String

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return Nothing
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Public Function LogDelete(ByVal strValue As String) As String
        Return Nothing
    End Function

    Private Sub SetInitValue(ByVal intUserId As String)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
 
    End Sub

End Class