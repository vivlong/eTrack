Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data

Namespace ZZSystem
    <CLSCompliant(True)> _
    Public Class clsSysMenu
        ' Methods
        Public Function GetMenu() As ArrayList
            Dim table As DataTable
            Try
                table = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_SysMenu").Tables.Item(0)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table = New DataTable
                ProjectData.ClearProjectError()
            End Try
            Me._ColMenuProp.AddTableToList(table)
            Return Me._ColMenuProp.ArrMenuProp
        End Function


        ' Fields
        Private _ColMenuProp As colMenuProp = New colMenuProp
    End Class
End Namespace

