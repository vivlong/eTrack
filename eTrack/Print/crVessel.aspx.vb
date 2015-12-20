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
Imports SysMagic.ZZMessage
Imports SysMagic

Partial Class crVessel
    Inherits System.Web.UI.Page

    Dim dtRec As DataTable

    Dim myTableLogonInfos As CrystalDecisions.Shared.TableLogOnInfos
    Dim myTableLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
    Dim myConnectionInfo As CrystalDecisions.Shared.ConnectionInfo

    Dim m_blnSingleRecord As Boolean = True

    Private Sub BuildConnectionString()
        Session("UserID") = System.Configuration.ConfigurationManager.AppSettings("UserId")
        Session("Password") = System.Configuration.ConfigurationManager.AppSettings("Password")
        Session("Server") = System.Configuration.ConfigurationManager.AppSettings("DataSource")
        Session("Database") = System.Configuration.ConfigurationManager.AppSettings("InitialCatalog")
    End Sub

    Private Function InsertSelectionFormula() As Boolean
        Try
            Dim strId As String = ""
            Dim sb As New StringBuilder
            sb.Append(" ({vw_Sebl1.Job Type} = ""GP"" or {vw_Sebl1.Job Type} = ""SE"")")
            sb.Append(" and {vw_Sebl1.Shipment Type} = ""M""")
            sb.Append(" and (IsNull({vw_Sebl1.Close Consol}) or {vw_Sebl1.Close Consol} <> ""Y"")")
            sb.Append(" and {@Etd} >=dateadd(""d"",-30,CurrentDate) ")
            'sb.Append(" and {@Etd} >= dateadd(getdate(),-30,d))")CurrentDate
            If (Request("id") IsNot Nothing) Then
                strId = Request("id").ToString
                If strId.Trim() <> "" And strId.Trim().ToLower <> "all" Then
                    sb.Append(" and {vw_Sebl1.Port Of Discharge Name} = """ + strId + """")
                End If
            End If
            crsVessel.ReportDocument.RecordSelectionFormula = sb.ToString()
            Return True
        Catch ex As Exception
            MsgBox("Error setting report header - " + ex.Message)
            Return False
        End Try
    End Function
    Private Function LogonReport(ByVal UserID As String, ByVal Password As String, ByVal Server As String, ByVal Database As String) As Boolean
        Dim logonInfo As TableLogOnInfo
        Dim table As CrystalDecisions.CrystalReports.Engine.Table
        Try
            ' Set the logon information for each table.
            For Each table In crsVessel.ReportDocument.Database.Tables
                logonInfo = New TableLogOnInfo
                ' Get the TableLogOnInfo object.
                logonInfo = table.LogOnInfo
                ' Set the server or ODBC data source name, database name, 
                ' user ID, and password.
                logonInfo.ConnectionInfo.ServerName = Server
                logonInfo.ConnectionInfo.DatabaseName = Database
                logonInfo.ConnectionInfo.UserID = UserID
                logonInfo.ConnectionInfo.Password = Password
                ' Apply the connection information to the table.
                table.ApplyLogOnInfo(logonInfo)
            Next table
            LogonReport = True
        Catch ex As Exception
            MsgBox("Error Logon to Report - " & ex.Message)
            LogonReport = False
        End Try
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'crsVessel.ReportDocument.RecordSelectionFormula = ""
        Dim intId As Int64 = PageFun.GetPrintId(Page)
        Dim strReport As String = "..\Report\CustomerServices\sebl\rptSebl09OLE.rpt"
        crsVessel.Report.FileName = strReport
        ''Exit Sub
        Call BuildConnectionString()
        Try
            If Not LogonReport(Session("UserID"), Session("Password"), Session("Server"), Session("Database")) Then Exit Sub
            If Not InsertSelectionFormula() Then Exit Sub

            crvVessel.LogOnInfo = myTableLogonInfos
            crvVessel.ReportSource = crsVessel

            If m_blnSingleRecord Then
                'no toolbar and side slider
                crvVessel.DisplayGroupTree = False
                'crvVessel.DisplayToolbar = False
            Else
                crvVessel.DisplayGroupTree = True
            End If
            'Else 'more than 1 record ...
            crvVessel.Attributes.Add("style", "LEFT: 6px")
            crvVessel.Attributes.Add("style", "TOP: 0px")
            crvVessel.DisplayGroupTree = True
            crvVessel.DisplayToolbar = True
            'End If
            crvVessel.DataBind()
            '原始导出方式
            OutToFile(Me.Title, crsVessel, Response)
            'ExportData(crsVessel.ReportDocument)
            crsVessel.Dispose()
        Catch engEx As LogOnException
            MsgBox("LogonExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
        Catch engEx As DataSourceException
            MsgBox("DataSourceExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
        Catch engEx As EngineException
            MsgBox("EngineExp -  " + ZZMessage.clsMessage.GetErrorMessage(engEx))
        Catch ex As Exception
            MsgBox("Other Error -  " + ZZMessage.clsMessage.GetErrorMessage(ex))
        End Try

    End Sub
    Private Sub OutToFile(ByVal strFileName As String, ByVal crs As CrystalReportSource, ByVal Response As HttpResponse)
        Dim str As String = (HttpRuntime.AppDomainAppPath & "Print\")
        Dim random As New Random
        Dim filename As String = (random.Next(0, 100).ToString & strFileName & ".pdf")
        crs.ReportDocument.ExportToDisk(5, (str & filename))
        Response.ContentType = "application/pdf"
        Response.WriteFile(filename)
        Response.Flush()
        Response.Close()
        File.Delete((str & filename))
    End Sub
    Public Sub ExportData(ByRef oRpt As Object)
        Dim fs As IO.FileStream
        Dim FileSize As Long
        Dim oDest As New CrystalDecisions.Shared.DiskFileDestinationOptions
        Dim ExportFileName As String = Server.MapPath("Temp/") + "Temp.pdf"
        Try

            oRpt.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
            oRpt.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat
            oDest.DiskFileName = ExportFileName
            oRpt.ExportOptions.DestinationOptions = oDest
            oRpt.Export()
            'Send the file to the user that made the Vessel
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("Content-Type", "application/pdf")
            fs = New IO.FileStream(ExportFileName, IO.FileMode.Open)

            FileSize = fs.Length
            Dim bBuffer(CInt(FileSize)) As Byte
            fs.Read(bBuffer, 0, CInt(FileSize))
            fs.Close()

            Response.BinaryWrite(bBuffer)
            Response.Flush()
            Response.Close()
        Catch e As Exception
            ''MsgBox("Other Error -  " + ZZMessage.clsMessage.GetErrorMessage(e))
            ''ExportData(crsVessel.ReportDocument)
        End Try


    End Sub

End Class
