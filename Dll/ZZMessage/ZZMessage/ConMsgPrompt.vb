Imports System
Imports System.Web.Configuration

Namespace ZZMessage
    Public Class ConMsgPrompt
        ' Properties
        Public Shared ReadOnly Property AuditPrompt As String
            Get
                If (IIf(((ConMsgPrompt._AuditPrompt Is Nothing) OrElse (ConMsgPrompt._AuditPrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._AuditPrompt = WebConfigurationManager.AppSettings.Item("AuditPrompt").ToString.Trim
                End If
                Return ConMsgPrompt._AuditPrompt
            End Get
        End Property

        Public Shared ReadOnly Property DeletePrompt As String
            Get
                If (IIf(((ConMsgPrompt._DeletePrompt Is Nothing) OrElse (ConMsgPrompt._DeletePrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._DeletePrompt = WebConfigurationManager.AppSettings.Item("DeletePrompt").ToString.Trim
                End If
                Return ConMsgPrompt._DeletePrompt
            End Get
        End Property

        Public Shared ReadOnly Property NotifyPrompt As String
            Get
                If (IIf(((ConMsgPrompt._NotifyPrompt Is Nothing) OrElse (ConMsgPrompt._NotifyPrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._NotifyPrompt = WebConfigurationManager.AppSettings.Item("NotifyPrompt").ToString.Trim
                End If
                Return ConMsgPrompt._NotifyPrompt
            End Get
        End Property

        Public Shared ReadOnly Property RestorePrompt As String
            Get
                If (IIf(((ConMsgPrompt._RestorePrompt Is Nothing) OrElse (ConMsgPrompt._RestorePrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._RestorePrompt = WebConfigurationManager.AppSettings.Item("RestorePrompt").ToString.Trim
                End If
                Return ConMsgPrompt._RestorePrompt
            End Get
        End Property

        Public Shared ReadOnly Property SavePrompt As String
            Get
                If (IIf(((ConMsgPrompt._SavePrompt Is Nothing) OrElse (ConMsgPrompt._SavePrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._SavePrompt = WebConfigurationManager.AppSettings.Item("SavePrompt").ToString.Trim
                End If
                Return ConMsgPrompt._SavePrompt
            End Get
        End Property

        Public Shared ReadOnly Property SubDeletePrompt As String
            Get
                If (IIf(((ConMsgPrompt._SubDeletePrompt Is Nothing) OrElse (ConMsgPrompt._SubDeletePrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._SubDeletePrompt = WebConfigurationManager.AppSettings.Item("SubDeletePrompt").ToString.Trim
                End If
                Return ConMsgPrompt._SubDeletePrompt
            End Get
        End Property

        Public Shared ReadOnly Property SuccessPrompt As String
            Get
                If (IIf(((ConMsgPrompt._SuccessPrompt Is Nothing) OrElse (ConMsgPrompt._SuccessPrompt = String.Empty)), 1, 0) <> 0) Then
                    ConMsgPrompt._SuccessPrompt = WebConfigurationManager.AppSettings.Item("SuccessPrompt").ToString.Trim
                End If
                Return ConMsgPrompt._SuccessPrompt
            End Get
        End Property


        ' Fields
        Private Shared _AuditPrompt As String
        Private Shared _DeletePrompt As String
        Private Shared _NotifyPrompt As String
        Private Shared _RestorePrompt As String
        Private Shared _SavePrompt As String
        Private Shared _SubDeletePrompt As String
        Private Shared _SuccessPrompt As String
    End Class
End Namespace
