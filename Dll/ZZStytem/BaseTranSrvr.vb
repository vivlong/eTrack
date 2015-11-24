Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage

Namespace ZZSystem

    Public MustInherit Class BaseTranSrvr
        ' Methods
        Public Function Save(ByRef strMsg As String) As Boolean
            Dim flag2 As Boolean
            strMsg = ""
            Dim conn As New SqlConnection(ConDbConn.ConnectionString)
            conn.Open()
            Dim trans As SqlTransaction = conn.BeginTransaction
            If Me.SaveData(conn, trans, strMsg) Then
                Try
                    trans.Commit()
                    If (Operators.CompareString(strMsg, "", True) = 0) Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralSaveSuccess, "")
                    End If
                    Return True
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim ex As Exception = exception1
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralSaveFailure, "", clsMessage.GetErrorMessage(ex))
                    flag2 = False
                    ProjectData.ClearProjectError()
                    Return flag2
                    ProjectData.ClearProjectError()
                End Try
                Return flag2
            End If
            Try
                trans.Rollback()
                If (Operators.CompareString(strMsg, "", True) = 0) Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralSaveFailure, "")
                End If
                flag2 = False
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralSaveFailure, "", clsMessage.GetErrorMessage(exception2))
                flag2 = False
                ProjectData.ClearProjectError()
                Return flag2
                ProjectData.ClearProjectError()
            End Try
            Return flag2
        End Function

        Protected MustOverride Function SaveData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

    End Class
End Namespace

