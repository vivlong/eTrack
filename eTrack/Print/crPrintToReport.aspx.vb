Imports System.Web
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports SysMagic.ExportExcel
Imports SysMagic.SystemClass
Imports SysMagic.ZZSystem

Partial Class Print_crPrintToReport
    Inherits System.Web.UI.Page
    Private Sub OutToFile(ByVal strFileName As String, ByVal crs As CrystalReportSource, ByVal Response As HttpResponse)
        Dim str As String = HttpRuntime.AppDomainAppPath & "Print\"
        Dim Random As Random = New Random()
        Dim filename As String = Random.Next(0, 100).ToString() + strFileName + ".pdf"
        crs.ReportDocument.SetDatabaseLogon(Configuration.WebConfigurationManager.AppSettings("UserId").ToString, Configuration.WebConfigurationManager.AppSettings("Password").ToString)
        crs.ReportDocument.ExportToDisk(5, str + filename)
        Response.ContentType = "application/pdf"
        Response.WriteFile(filename)
        Response.Flush()
        Response.Close()
        File.Delete(str + filename)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strResUrl As String = ""
            Dim strValue As String = ""
            Dim strType As String = ""
            Dim strSelectionFormula As String = ""
            If Request("ResUrl") IsNot Nothing Then
                strResUrl = Request("ResUrl").ToString
            End If
            If Request("SfValue") IsNot Nothing Then
                strValue = Request("SfValue").ToString
            End If
            If Request("SelectionFormula") IsNot Nothing Then
                strSelectionFormula = Request("SelectionFormula").ToString
            End If
            If Request("Type") IsNot Nothing Then
                strType = Request("Type").ToString
            End If
            crsReport.ReportDocument.Load(Server.MapPath(strResUrl))
            SetDBLogonForReport()

            'If strType <> "int" Then
            '    crsReport.ReportDocument.RecordSelectionFormula = strSelectionFormula + " in [" + strValue + "]"
            'End If
            Dim strFormula As String = strSelectionFormula + " in [" + strValue + "]"
            crsReport.ReportDocument.RecordSelectionFormula = strSelectionFormula + " in [" + strValue + "]"

        End If
    End Sub
    Private Sub SetDBLogonForReport()
        Dim connectionInfo As CrystalDecisions.Shared.ConnectionInfo = New CrystalDecisions.Shared.ConnectionInfo()
        connectionInfo.ServerName = Configuration.WebConfigurationManager.AppSettings("DataSource").ToString
        connectionInfo.DatabaseName = Configuration.WebConfigurationManager.AppSettings("InitialCatalog").ToString
        connectionInfo.UserID = Configuration.WebConfigurationManager.AppSettings("UserId").ToString
        connectionInfo.Password = Configuration.WebConfigurationManager.AppSettings("Password").ToString
        Dim tableLogOnInfos As TableLogOnInfos = crvReport.LogOnInfo
        For Each tableLogOnInfo As TableLogOnInfo In tableLogOnInfos
            tableLogOnInfo.ConnectionInfo = connectionInfo
        Next
    End Sub
End Class
