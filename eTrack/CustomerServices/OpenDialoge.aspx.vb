Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Partial Class Query_OpenDialoge
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strID As String = Server.HtmlEncode(Request.QueryString("ID"))
        If strID <> "" Then
            Dim ds As DataSet
            Dim dt As DataTable
            Dim strModuleCode As String = ""
            Dim strFunUrl As String = ""
            Dim strDBName As String = System.Configuration.ConfigurationManager.AppSettings("InitialCatalog")
            If strID.Trim <> "" Then
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, "select modulecode from jmjm1 where jobno=" + strID)
                dt = ds.Tables(0)
                strModuleCode = dt.Rows(0)("modulecode").ToString
                Select Case strModuleCode
                    Case "AE", "AI"
                        strFunUrl = "CustomerServices/AirFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo=" + strID.Trim
                    Case "SE", "SI"
                        strFunUrl = "CustomerServices/SeaFreightEdit.aspx?Type=Query&Module=" + strModuleCode + "&DB=" + strDBName + "&JobNo=" + strID.Trim
                End Select
            End If
            Response.Write("<script language='javascript'>GoToPage('" + strFunUrl + "','SeaFreight',10,10);window.close();</script>")
        Else
            Response.Write("<script language='javascript'>alert('Not Date Exit.');window.close();</script>")
        End If
    End Sub
End Class
