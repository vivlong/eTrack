Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports SysMagic.ExportExcel
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.SystemClass
Imports CrystalDecisions.Web
Imports SysMagic

Partial Class Print_crRequest
    Inherits System.Web.UI.Page

    Dim dtRec As DataTable

    Dim myTableLogonInfos As CrystalDecisions.Shared.TableLogOnInfos
    Dim myTableLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
    Dim myConnectionInfo As CrystalDecisions.Shared.ConnectionInfo

    Dim m_blnSingleRecord As Boolean = True
    Dim strType As String

    Private Sub BuildConnectionString()
        Session("UserID") = System.Configuration.ConfigurationManager.AppSettings("UserId")
        Session("Password") = System.Configuration.ConfigurationManager.AppSettings("Password")
        Session("Server") = System.Configuration.ConfigurationManager.AppSettings("DataSource")
        If Session("Database") Is Nothing OrElse Session("Database").ToString = "" Then
            Session("Database") = System.Configuration.ConfigurationManager.AppSettings("InitialCatalog")
        End If
    End Sub

    Public Function SQLSafe(ByRef Str_Renamed As String) As String
        SQLSafe = Replace(Str_Renamed, "'", "''")
    End Function

    Private Function InsertSelectionFormula() As Boolean
        Dim strValue As String = ""
        Dim strFormulaField As String = ""
        Dim strFormulaFieldValue As String = ""
        'Dim i As Integer
        If Request("FormulaField") IsNot Nothing Then
            strFormulaField = Request("FormulaField").ToString
        End If
        If Request("FormulaFieldValue") IsNot Nothing Then
            strFormulaFieldValue = Request("FormulaFieldValue").ToString
        End If
        If Request("Type") IsNot Nothing Then
            strType = Request("Type").ToString
        End If
        Try
            If strFormulaField <> "" And strFormulaFieldValue <> "" And strType <> "" Then
                If strType = "Int" Then
                    strValue += "" & strFormulaField & " = " & SQLSafe(strFormulaFieldValue)
                Else
                    strValue += "" & strFormulaField & " = '" & SQLSafe(strFormulaFieldValue) & "'"
                End If
                crsRequest.ReportDocument.RecordSelectionFormula = "(" & strValue & ")"
            End If
            Return True
        Catch ex As Exception
            '  MsgBox("Error setting report header - " + ex.Message)
            Page.RegisterStartupScript("", "<script language='javascript'>alert('Error setting report header - " + ex.Message + "');</script>")

            Return False
        End Try
    End Function

    Private Function LogonReport(ByVal UserID As String, ByVal Password As String, ByVal Server As String, ByVal Database As String) As Boolean
        Dim logonInfo As TableLogOnInfo
        Dim table As CrystalDecisions.CrystalReports.Engine.Table
        Try
            ' Set the logon information for each table.
            For Each table In crsRequest.ReportDocument.Database.Tables
                logonInfo = New TableLogOnInfo
                ' Get the TableLogOnInfo object.
                logonInfo = table.LogOnInfo
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
            '   MsgBox("Error Logon to Report - " & ex.Message)
            Page.RegisterStartupScript("", "<script language='javascript'>alert('Error Logon to Report - " & ex.Message + "');</script>")

            LogonReport = False
        End Try
    End Function

    Private Sub OutToFile(ByVal strFileName As String, ByVal crs As CrystalReportSource, ByVal Response As HttpResponse)
        Dim str As String = (HttpRuntime.AppDomainAppPath & "Print\")
        Dim random As New Random
        Dim filename As String = (random.Next(0, 100).ToString & strFileName & ".pdf")
        For i As Integer = 0 To crs.ReportDocument.ParameterFields.Count - 1
            crs.ReportDocument.ParameterFields(i).CurrentValues = crs.ReportDocument.ParameterFields(i).DefaultValues
        Next
        crs.ReportDocument.ExportToDisk(5, (str & filename))
        ' crs.ReportDocument.Export(5)
        Dim Data As Byte() = GetData(str & filename)
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline;filename=" + filename + "")
        Response.OutputStream.Write(Data, 0, Data.Length)
        ' Response.WriteFile(filename)
        Response.Flush()
        Response.Close()
        File.Delete((str & filename))
    End Sub
    Private Function GetData(ByVal strPath As String) As Byte()
        Dim reader As System.IO.FileStream = System.IO.File.OpenRead(strPath)
        Dim retData As Byte() = New Byte(reader.Length - 1) {}
        Try
            reader.Read(retData, 0, retData.Length)
        Catch ex As Exception
        Finally
            reader.Close()
        End Try
        Return retData
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Dim intId As Int64 = PageFun.GetPrintId(Page)

        Session("ReportName") = Request("FileName").ToString
        crsRequest.Report.FileName = "..\Report\Documents\" + Session("ReportName")

        Call BuildConnectionString()

        Try

            If Not LogonReport(Session("UserID"), Session("Password"), Session("Server"), Session("Database")) Then Exit Sub
            If Not InsertSelectionFormula() Then Exit Sub

            crvRequest.LogOnInfo = myTableLogonInfos
            crvRequest.ReportSource = crsRequest

            If m_blnSingleRecord Then
                crvRequest.DisplayGroupTree = False
            Else
                crvRequest.DisplayGroupTree = True
            End If
            'Else 'more than 1 record ...
            crvRequest.Attributes.Add("style", "LEFT: 6px")
            crvRequest.Attributes.Add("style", "TOP: 0px")
            crvRequest.DisplayGroupTree = True
            crvRequest.DisplayToolbar = True
            'End If
            crvRequest.DataBind()
            '原始导出方式
            'If crsRequest.ReportDocument.ParameterFields.Count > 0 Then
            'If IsPostBack Then
            OutToFile(Me.Title, crsRequest, Response)
            'Exit Sub
            'End If
            'Else
            'OutToFile(Me.Title, crsRequest, Response)
            ' End If
            ' ExportData(crsRequest.ReportDocument)

        Catch engEx As LogOnException
            'MsgBox("LogonExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
            Page.RegisterStartupScript("", "<script language='javascript'>alert('LogonExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "');</script>")
        Catch engEx As DataSourceException
            ' MsgBox("DataSourceExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
            Page.RegisterStartupScript("", "<script language='javascript'>alert('DataSourceExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "');</script>")
        Catch engEx As EngineException
            ' MsgBox("EngineExp -  " + ZZMessage.clsMessage.GetErrorMessage(engEx))
            If engEx.ErrorID <> "5634" Then
                Page.RegisterStartupScript("", "<script language='javascript'>alert('EngineExp -  " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "');</script>")

            End If
        Catch ex As Exception
            ' MsgBox("Other Error -  " + ZZMessage.clsMessage.GetErrorMessage(ex))
            Page.RegisterStartupScript("", "<script language='javascript'>alert('Other Error -  " + ZZMessage.clsMessage.GetErrorMessage(ex) + "');</script>")
        End Try
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
        End Try


    End Sub

End Class
