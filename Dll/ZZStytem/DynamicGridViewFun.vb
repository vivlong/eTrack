Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Web.UI.WebControls

Namespace ZZSystem
    Public Class DynamicGridViewFun
        Inherits GridViewFun
        ' Methods
        Public Shared Function GetColumnFromSqlFile(ByVal strTableName As String, ByRef gvw As GridView, ByVal tyTemplate As TemplateType, ByVal intUserId As String, ByVal LoginType As String) As colColumn
            Dim columnInfos As New clsDynamicSqlColumn(intUserId, strTableName, False)
            columnInfos.GetColumnFromSql(False, False, LoginType)
            GridViewFun.CreateGridColumn(columnInfos, gvw, tyTemplate)
            Return columnInfos
        End Function

        Public Shared Function GetColumnFromSqlFile(ByVal strTableName As String, ByVal intUserId As String, ByVal blnDefault As Boolean, ByVal blnHavePrefix As Boolean, ByVal LoginType As String) As colColumn
            Dim column2 As New clsDynamicSqlColumn(intUserId, strTableName, blnDefault)
            column2.GetColumnFromSql(True, blnHavePrefix, LoginType) 'by lzw 090605 for explor excel by user config
            Return column2
        End Function

        Public Shared Function GetColumnExport(ByVal strTableName As String, ByVal intUserId As String, ByVal blnDefault As Boolean, ByVal blnHavePrefix As Boolean, ByVal LoginType As String) As colColumn
            Dim column2 As New clsDynamicSqlColumn(intUserId, strTableName, blnDefault)
            column2.GetColumnFromSql(False, blnHavePrefix, LoginType) 'by lzw 090605 for explor excel by user config
            Return column2
        End Function

        Public Shared Function GetColumnFromXmlFile(ByVal strTableName As String, ByVal blnHavePrefix As Boolean) As colColumn
            Dim column2 As New clsDynamicXmlColumn(strTableName)
            Dim list As New ArrayList
            column2.GetColumnFromXmlFile(False, blnHavePrefix)
            Return column2
        End Function

        Public Shared Function GetColumnFromXmlFile(ByVal strTableName As String, ByRef gvw As GridView, ByVal tyTemplate As TemplateType) As colColumn
            Dim columnInfos As New clsDynamicXmlColumn(strTableName)
            columnInfos.GetColumnFromXmlFile(False, False)
            GridViewFun.CreateGridColumn(columnInfos, gvw, tyTemplate)
            Return columnInfos
        End Function

        Public Shared Function SetColumnToSqlFile(ByVal strTableName As String, ByVal intUserId As String, ByVal strValues As String) As Boolean
            Dim column As New clsDynamicSqlColumn(intUserId, strTableName, False)
            Return column.SetColumnToSqlFile(strValues)
        End Function

    End Class
End Namespace

