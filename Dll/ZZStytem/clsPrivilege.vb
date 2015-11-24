Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient

Namespace ZZSystem

    Public Class clsPrivilege
        ' Methods
        Public Sub New(ByVal intUserId As String, ByVal strFunNo As String)
            Me.AddTableToArray(Me.GetPrivilegeTable(intUserId, strFunNo))
        End Sub

        Public Sub New(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
            Me.AddTableToArray(Me.GetPrivilegeTable(intUserId, RoleName, strFunNo))
        End Sub

        Private Sub AddTableToArray(ByVal dt As DataTable)
            Me._ArrProp.Clear()
            Dim num2 As Integer = (dt.Rows.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Dim strName As String = dt.Rows.Item(i).Item("sCode").ToString
                Dim blExist As Boolean = Conversions.ToBoolean(dt.Rows.Item(i).Item("bExist"))
                Dim prop As New clsPrivilegeProp(strName, blExist)
                Me._ArrProp.Add(prop)
                i += 1
            Loop
        End Sub

        Public Function GetPrivilege(ByVal strName As String) As Boolean
            Dim num2 As Integer = (Me._ArrProp.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (Operators.CompareString(DirectCast(Me._ArrProp.Item(i), clsPrivilegeProp).Name.ToLower, strName.ToLower, True) = 0) Then
                    Return DirectCast(Me._ArrProp.Item(i), clsPrivilegeProp).Exist
                End If
                i += 1
            Loop
            Return False
        End Function

        Protected Function GetPrivilegeTable(ByVal intUserId As String, ByVal strFunNo As String) As DataTable
            Dim table2 As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter(2 - 1) {}
                commandParameters(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                commandParameters(0).Value = intUserId
                commandParameters(1) = New SqlParameter("@strFunNo", SqlDbType.NVarChar, 100)
                commandParameters(1).Value = strFunNo
                Dim table As DataTable = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonSubFunction", commandParameters).Tables.Item(0)
                table2 = table
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table2 = New DataTable
                ProjectData.ClearProjectError()
                Return table2
                ProjectData.ClearProjectError()
            End Try
            Return table2
        End Function

        ''' <summary>
        ''' 100315 -zhiwei For admin Role
        ''' </summary>
        ''' <param name="RoleName"></param>
        ''' <param name="strFunNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetPrivilegeTable(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As DataTable
            Dim table2 As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter(2 - 1) {}
                commandParameters(0) = New SqlParameter("@RoleName", SqlDbType.NVarChar, 20)
                commandParameters(0).Value = RoleName
                commandParameters(1) = New SqlParameter("@strFunNo", SqlDbType.NVarChar, 100)
                commandParameters(1).Value = strFunNo
                Dim table As DataTable = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonSubFunction_Admin", commandParameters).Tables.Item(0)
                table2 = table
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table2 = New DataTable
                ProjectData.ClearProjectError()
                Return table2
                ProjectData.ClearProjectError()
            End Try
            Return table2
        End Function
        ' Fields
        Private _ArrProp As ArrayList = New ArrayList
    End Class
End Namespace

