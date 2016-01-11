Imports System.Web
Imports System.IO
Imports System.Web.UI
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
Imports System.Web.UI.WebControls

Partial Class Print_VesselSchedule
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
            If Session("hid_voyageIDPass") Is Nothing Then
                strId = ""
            Else
                strId = Session("hid_voyageIDPass")
            End If
            If strId <> "" Then
                strId = strId.Substring(0, strId.Length - 1)
                strId = "[" + strId + "]"
                'strId = "['1']"

                crsVesselSchedule.ReportDocument.RecordSelectionFormula = "{vw_Rcvy1.Voyage ID} in " + strId
            Else
                Return False
            End If
            'crvVesselSchedule.SelectionFormula = "{vw_Rcvy1.Voyage ID} in " + strId
            ''End If
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
            For Each table In crsVesselSchedule.ReportDocument.Database.Tables
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
        crvVesselSchedule.ReportSource = objPrint.GetCRS(640, crsVesselSchedule, "where [Trx No]=", "vw_sebl1", objUser)
        crvVesselSchedule.DataBind()
        objPrint.OutToFile(Me.Title, crsVesselSchedule, Response)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intId As Int64 = PageFun.GetPrintId(Page)
								crsVesselSchedule.Report.FileName = "..\Report\CustomerServices\rptRcvy11.rpt"
        ''BindTable(intId)
        ''Exit Sub
								Call BuildConnectionString()
								Try
												If Not LogonReport(Session("UserID"), Session("Password"), Session("Server"), Session("Database")) Then Exit Sub
												If Not InsertSelectionFormula() Then Exit Sub
												crvVesselSchedule.LogOnInfo = myTableLogonInfos
												crvVesselSchedule.ReportSource = crsVesselSchedule
												If m_blnSingleRecord Then
																'    'no toolbar and side slider
																'crvVesselSchedule.Attributes.Add("style", "LEFT: 6px")
																'crvVesselSchedule.Attributes.Add("style", "TOP: 6px")
																crvVesselSchedule.DisplayGroupTree = False
																'    crvVesselSchedule.DisplayToolbar = False
												Else
																crvVesselSchedule.DisplayGroupTree = True
												End If
												'Else 'more than 1 record ...
												crvVesselSchedule.Attributes.Add("style", "LEFT: 6px")
												crvVesselSchedule.Attributes.Add("style", "TOP: 0px")
												crvVesselSchedule.DisplayGroupTree = True
												crvVesselSchedule.DisplayToolbar = True
												'End If
												crvVesselSchedule.DataBind()
												'ExportData(crsVesselSchedule.ReportDocument)
								Catch engEx As LogOnException
												Response.Write("<script language=javascript>alert('LogonExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "') </script>")
								Catch engEx As DataSourceException
												'MsgBox("DataSourceExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
												Response.Write("<script language=javascript>alert('DataSourceExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "') </script>")
								Catch engEx As EngineException
												'MsgBox("EngineExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx))
												Response.Write("<script language=javascript>alert('EngineExp - " + ZZMessage.clsMessage.GetErrorMessage(engEx) + "') </script>")
								Catch ex As Exception
												'MsgBox("Other Error - " + ZZMessage.clsMessage.GetErrorMessage(ex))
												Response.Write("<script language=javascript>alert('Other Error - " + ZZMessage.clsMessage.GetErrorMessage(ex) + "') </script>")
								End Try
    End Sub

    Public Sub ExportData(ByRef oRpt As Object)
        Dim fs As IO.FileStream
        Dim FileSize As Long
        Dim oDest As New CrystalDecisions.Shared.DiskFileDestinationOptions
        Dim ExportFileName As String = Server.MapPath("Print/Temp/") + "Temp.pdf"
        Try
            'Dim oExport As New CrystalDecisions.CrystalReports.Engine.ReportDocument.ExportOptions()

            oRpt.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
            oRpt.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat
            oDest.DiskFileName = ExportFileName
            oRpt.ExportOptions.DestinationOptions = oDest
            oRpt.Export()


            'Build Target Filename

            'Send the file to the user that made the VesselSchedule
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
            ExportData(crsVesselSchedule.ReportDocument)
        End Try


    End Sub

End Class
