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

Partial Class Print_crBooking
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

    Public Function SQLSafe(ByRef Str_Renamed As String) As String
        SQLSafe = Replace(Str_Renamed, "'", "''")
    End Function

    Private Function InsertSelectionFormula() As Boolean

        Dim strArr() As String = Split(Session("KeyValue"), ",")

        Try
            Dim strId As String = ""
            strId = Request("id").ToString
            crsBooking.ReportDocument.RecordSelectionFormula = "{vw_Omtx1.Trx No}=" + strId
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
            For Each table In crsBooking.ReportDocument.Database.Tables
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

    Protected Sub BindTable(ByVal intId As Int64)
        Dim objPrint As clsPrint = New clsPrint()
        Dim objUser As clsUser = Nothing
        PageFun.GetCurrentUserInfo(Page, objUser)
        crvBooking.ReportSource = objPrint.GetCRS(640, crsBooking, "where [Trx No]=", "vw_sebl1", objUser)
        crvBooking.DataBind()
        objPrint.OutToFile(Me.Title, crsBooking, Response)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intId As Int64 = PageFun.GetPrintId(Page)
        Dim strReport As String = "..\Report\CustomerServices\omtx\rptOmtx11.rpt"
        If Request("Report") IsNot Nothing Then
            strReport = "..\Report\CustomerServices\omtx\" + Request("Report").ToString + ".rpt"
        End If
        crsBooking.Report.FileName = strReport
        ''BindTable(intId)
        ''Exit Sub
        Call BuildConnectionString()

        Try

            If Not LogonReport(Session("UserID"), Session("Password"), Session("Server"), Session("Database")) Then Exit Sub
            If Not InsertSelectionFormula() Then Exit Sub

            crvBooking.LogOnInfo = myTableLogonInfos
            crvBooking.ReportSource = crsBooking

            If m_blnSingleRecord Then
                '    'no toolbar and side slider
                'crvBooking.Attributes.Add("style", "LEFT: 6px")
                'crvBooking.Attributes.Add("style", "TOP: 6px")
                crvBooking.DisplayGroupTree = False
                '    crvBooking.DisplayToolbar = False
            Else
                crvBooking.DisplayGroupTree = True
            End If
            'Else 'more than 1 record ...
            crvBooking.Attributes.Add("style", "LEFT: 6px")
            crvBooking.Attributes.Add("style", "TOP: 0px")
            crvBooking.DisplayGroupTree = True
            crvBooking.DisplayToolbar = True
            'End If
            crvBooking.DataBind()
            ExportData(crsBooking.ReportDocument)

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

    Public Sub ExportData(ByRef oRpt As Object)
        Dim fs As IO.FileStream
        Dim FileSize As Long
        Dim oDest As New CrystalDecisions.Shared.DiskFileDestinationOptions
        Dim ExportFileName As String = Server.MapPath("Temp/") + "Temp.pdf"
        Try
            'Dim oExport As New CrystalDecisions.CrystalReports.Engine.ReportDocument.ExportOptions()

            oRpt.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
            oRpt.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat
            oDest.DiskFileName = ExportFileName
            oRpt.ExportOptions.DestinationOptions = oDest
            oRpt.Export()


            'Build Target Filename

            'Send the file to the user that made the Booking
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("Content-Type", "application/pdf")
            '        Response.AddHeader("Content-Disposition", "attachment;filename=" & Session.SessionID & ".pdf;")
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
            ''ExportData(crsBooking.ReportDocument)
        End Try


    End Sub

End Class
