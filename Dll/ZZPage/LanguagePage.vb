Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Web.UI

Namespace ZZPage
    Public Class LanguagePage
        Inherits Page
        ' Methods

        Public _ENCList As List(Of WeakReference) = New List(Of WeakReference)

        <DebuggerNonUserCode()> _
        Public Sub New()
            _ENCList.Add(New WeakReference(Me))
        End Sub

        Public Function GetJavascriptLanguageConst() As String
            Dim str4 As String = "<script language =""javascript"" type=""text/javascript"">"
            Dim str3 As String = "</script>"
            Dim str6 As String = ChrW(13) & ChrW(10)
            Dim str5 As String = str4
            str5 = String.Concat(New String() {str5, str6, "var SaveUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "SaveUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var DeleteUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "DeleteUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var GetUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "GetUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var NewUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "NewUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var AuditUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "AuditUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var NotifyUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "NotifyUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var RestoreUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "RestoreUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var PrintUnexpectedError=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "PrintUnexpectedError")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var ConfirmSave=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "ConfirmSave")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var ConfirmDelete=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "ConfirmDelete")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var ConfirmRestore=""", Conversions.ToString(Me.GetGlobalResourceObject("Message", "ConfirmRestore")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var PageTitle=""", Conversions.ToString(Me.GetGlobalResourceObject("PageList", "Page")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var PageSeparator=""", Conversions.ToString(Me.GetGlobalResourceObject("PageList", "PageSeparator")), """;"})
            str5 = String.Concat(New String() {str5, str6, "var CannotExceedLastPage=""", Conversions.ToString(Me.GetGlobalResourceObject("PageList", "CannotExceedLastPage")), """;"})
            Dim otherJavascriptLanguageConst As String = Me.GetOtherJavascriptLanguageConst
            If (otherJavascriptLanguageConst <> "") Then
                str5 = (str5 & str6 & otherJavascriptLanguageConst)
            End If
            Return (str5 & str6 & str3)
        End Function

        Protected Overridable Function GetOtherJavascriptLanguageConst() As String
            Return ""
        End Function

        Protected Overrides Sub InitializeCulture()
            MyBase.InitializeCulture()
            If Not Information.IsNothing(RuntimeHelpers.GetObjectValue(Me.Session.Item("CurrentLanguage"))) Then
                Me._CurrentLanguage = Conversions.ToString(Me.Session.Item("CurrentLanguage"))
            Else
                Me._CurrentLanguage = "English"
            End If
            Dim str As String = ""
            If (Me._CurrentLanguage.ToLower = "english") Then
                str = "en-us"
            Else
                str = "zh-cn"
            End If
            If Not String.IsNullOrEmpty(str) Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo(str)
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(str)
            End If
        End Sub

        ' Fields
        Private _CurrentLanguage As String
    End Class
End Namespace

