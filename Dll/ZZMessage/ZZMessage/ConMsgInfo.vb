Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web

Namespace ZZMessage
    Public Class ConMsgInfo
        ' Properties
        Public Shared ReadOnly Property BindDataErr As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "BindDataErr"))
            End Get
        End Property

        Public Shared ReadOnly Property CalculateUtilRateFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "CalculateUtilRateFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property CalculateUtilRateSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "CalculateUtilRateSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property CannotDelete As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "CannotDelete"))
            End Get
        End Property

        Public Shared ReadOnly Property CannotRestore As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "CannotRestore"))
            End Get
        End Property

        Public Shared ReadOnly Property ConfirmExitSystem As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "ConfirmExitSystem"))
            End Get
        End Property

        Public Shared ReadOnly Property ConfirmLogout As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "ConfirmLogout"))
            End Get
        End Property

        Public Shared ReadOnly Property CurrentCannotSave As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "CurrentCannotSave"))
            End Get
        End Property

        Public Shared ReadOnly Property DeleteAction As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "DeleteAction"))
            End Get
        End Property

        Public Shared ReadOnly Property DetailSaveFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "DetailSaveFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property DirtyData As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "DirtyData"))
            End Get
        End Property

        Public Shared ReadOnly Property ErrorData As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "ErrorData"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralAuditFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralAuditFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralAuditSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralAuditSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralDeleteFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralDeleteFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralDeleteSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralDeleteSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralNotifyFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralNotifyFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralNotifySuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralNotifySuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralRestoreFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralRestoreFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralRestoreSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralRestoreSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralSaveFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralSaveFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralSaveSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralSaveSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralUpdateFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralUpdateFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property GeneralUpdateSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "GeneralUpdateSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property InBrowseState As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "InBrowseState"))
            End Get
        End Property

        Public Shared ReadOnly Property InInsertState As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "InInsertState"))
            End Get
        End Property

        Public Shared ReadOnly Property InOtherState As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "InOtherState"))
            End Get
        End Property

        Public Shared ReadOnly Property InsertAction As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "InsertAction"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyAuditFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyAuditFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyAuditSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyAuditSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyDeleteFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyDeleteFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyDeleteSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyDeleteSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyRestoreFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyRestoreFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyRestoreSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyRestoreSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyReturnFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyReturnFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyReturnSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyReturnSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property KeySaveFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeySaveFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeySaveSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeySaveSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyUpdateFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyUpdateFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property KeyUpdateSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "KeyUpdateSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property LoginSystem As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "LoginSystem"))
            End Get
        End Property

        Public Shared ReadOnly Property MasterSaveFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "MasterSaveFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property NoLogin As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "NoLogin"))
            End Get
        End Property

        Public Shared ReadOnly Property OperateRecordClearFailure As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "OperateRecordClearFailure"))
            End Get
        End Property

        Public Shared ReadOnly Property OperateRecordClearSuccess As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "OperateRecordClearSuccess"))
            End Get
        End Property

        Public Shared ReadOnly Property RequestMailBody As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "RequestMailBody"))
            End Get
        End Property

        Public Shared ReadOnly Property RequestMailTitle As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "RequestMailTitle"))
            End Get
        End Property

        Public Shared ReadOnly Property RestoreAction As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "RestoreAction"))
            End Get
        End Property

        Public Shared ReadOnly Property SentAudit As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "SentAudit"))
            End Get
        End Property

        Public Shared ReadOnly Property StopTooLong As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "StopTooLong"))
            End Get
        End Property

        Public Shared ReadOnly Property TimeOut As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "TimeOut"))
            End Get
        End Property

        Public Shared ReadOnly Property UnmatchedParam As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "UnmatchedParam"))
            End Get
        End Property

        Public Shared ReadOnly Property UpdateAction As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "UpdateAction"))
            End Get
        End Property

        Public Shared ReadOnly Property UserNotExists As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "UserNotExists"))
            End Get
        End Property

        Public Shared ReadOnly Property WrongPassword As String
            Get
                Return Conversions.ToString(HttpContext.GetGlobalResourceObject("Message", "WrongPassword"))
            End Get
        End Property

    End Class
End Namespace
