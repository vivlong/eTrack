Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient

Namespace ZZSystem

    Public Class clsFunMenu
        ' Methods
        Public Function GetPersonFunction(ByVal intUserId As String) As ArrayList
            Dim table As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter() {New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)}
                commandParameters(0).Value = intUserId
                table = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonFunction", commandParameters).Tables.Item(0)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table = New DataTable
                ProjectData.ClearProjectError()
            End Try
            Me._ColFunProp.AddTableToList(table)
            Return Me._ColFunProp.ArrFunProp
        End Function

        ' Methods
        Public Function GetParentMenu(ByVal intUserId As String) As DataTable
            Dim table As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter() {New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)}
                commandParameters(0).Value = intUserId
                table = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_ParentFunction", commandParameters).Tables.Item(0)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table = New DataTable
                ProjectData.ClearProjectError()
            End Try
            Return table
        End Function

#Region "For Customer"
        Public Function GetPersonFunctionByRole(ByVal RoleName As String) As ArrayList
            Dim table As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter() {New SqlParameter("@RoleName", SqlDbType.NVarChar, 20)}
                commandParameters(0).Value = RoleName
                table = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonFunctionByRole", commandParameters).Tables.Item(0)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table = New DataTable
                ProjectData.ClearProjectError()
            End Try
            Me._ColFunProp.AddTableToList(table)
            Return Me._ColFunProp.ArrFunProp
        End Function

        Public Function GetParentMenubyRole(ByVal RoleName As String) As DataTable
            Dim table As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter() {New SqlParameter("@RoleName", SqlDbType.NVarChar, 20)}
                commandParameters(0).Value = RoleName
                table = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_ParentFunctionByRole", commandParameters).Tables.Item(0)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table = New DataTable
                ProjectData.ClearProjectError()
            End Try
            Return table
        End Function
#End Region


        ' Fields
        Private _ColFunProp As colFunProp = New colFunProp
    End Class
End Namespace

