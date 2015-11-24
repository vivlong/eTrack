Imports System.IO
Partial Class SysRef_DownLoad
    Inherits System.Web.UI.Page

    Private docPath As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingPath")
    Public Sub WriteDLWindow(ByVal strFileName As String, ByVal page As System.Web.UI.Page)
        Try
            If File.Exists(strFileName) Then
                Dim TargetFile As FileInfo = New FileInfo(strFileName)
                '清除缓冲区流中的所有内容输出.  
                page.Response.Clear()
                '向输出流添加HTTP头  [指定下载/保存  对话框的文件名]  
                page.Response.AppendHeader("Content-Disposition", "attachment;  filename=" + page.Server.UrlEncode(TargetFile.Name))

                '繁体格式  
                'page.Response.AppendHeader("Content-Disposition",  "attachment;filename="  +  HttpUtility.UrlEncode(strFileName,  System.Text.Encoding.UTF8))  

                '向输出流添加HTTP头  [指定文件的长度,这样下载文件就会显示正确的进度  
                page.Response.AppendHeader("Content-Length", TargetFile.Length.ToString())
                '表明输出的HTTP为流[stream],因此客户端只能下载.  
                page.Response.ContentType = "application/octet-stream"
                '发送文件流到客户端.  
                page.Response.WriteFile(TargetFile.FullName)
                '停止执行当前页  
                page.Response.End()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim file As String = Request("file")
        If file.IndexOf("..") >= 0 Then
            Exit Sub
        End If
        WriteDLWindow(docPath + file, Me)
    End Sub
End Class
