
Imports System.IO
Imports System.Threading

Partial Class ShowAttachFile
    Inherits System.Web.UI.Page

    Public Shared Function ResponseFile(ByVal _Request As HttpRequest, ByVal _Response As HttpResponse, ByVal _fileName As String, ByVal _fullPath As String, ByVal _speed As Long) As Boolean
        Try
            Dim myFile As New FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim br As New BinaryReader(myFile)
            Try
                _Response.AddHeader("Accept-Ranges", "bytes")
                _Response.Buffer = False
                Dim fileLength As Long = myFile.Length
                Dim startBytes As Long = 0
                Dim pack As Double = 10240
                '10K bytes 
                'int sleep = 200; //5*10K bytes per second
                Dim sleep As Integer = CInt(Math.Floor(1000 * pack / _speed)) + 1
                If _Request.Headers("Range") IsNot Nothing Then
                    _Response.StatusCode = 206
                    Dim range As String() = _Request.Headers("Range").Split(New Char() {"="c, "-"c})
                    startBytes = Convert.ToInt64(range(1))
                End If
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString())
                'Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength-1, fileLength)); 
                If startBytes <> 0 Then
                End If
                _Response.AddHeader("Connection", "Keep-Alive")
                _Response.ContentType = "application/octet-stream"
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8))
                br.BaseStream.Seek(startBytes, SeekOrigin.Begin)
                Dim maxCount As Integer = CInt(Math.Floor((fileLength - startBytes) / pack)) + 1
                For i As Integer = 0 To maxCount - 1
                    If _Response.IsClientConnected Then
                        _Response.BinaryWrite(br.ReadBytes(Integer.Parse(pack.ToString())))
                        Thread.Sleep(sleep)
                    Else
                        i = maxCount
                    End If
                Next
            Catch
                Return False
            Finally
                br.Close()
                myFile.Close()
            End Try
        Catch
            Return False
        End Try
        Return True
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Page.Response.Clear()
        If Request("Id") IsNot Nothing AndAlso Request("FileName") IsNot Nothing Then
            Dim intTrxNo As Int64 = Int64.Parse(Request("Id").ToString())
            Dim strFolder As String = Server.HtmlDecode(Request("Folder").ToString())
            Dim strAttachPath As String = Server.MapPath("../Doc/" + strFolder + "/" + intTrxNo.ToString() + "/")
            Dim strFileName As String = Server.HtmlDecode(Request("FileName").ToString().Trim)
            'special word
            If strFileName.IndexOf("%26") Then
                strFileName = strFileName.Replace("%26", "&")
            End If
            If strFileName.IndexOf("%2B") Then
                strFileName = strFileName.Replace("%2B", "+")
            End If
            If strFileName.IndexOf("%3D") Then
                strFileName = strFileName.Replace("%3D", "=")
            End If

            If strFileName.IndexOf("%25") Then
                strFileName = strFileName.Replace("%25", "%")
            End If
            If strFileName.IndexOf("%23") Then
                strFileName = strFileName.Replace("%23", "#")
            End If


            Dim success As Boolean = ResponseFile(Page.Request, Page.Response, strFileName, strAttachPath + strFileName, 1024000)
            If Not success Then
                Response.Write("Show Attachment Error!")
            End If
        Else
            Response.Write("No attachment to be shown!")
        End If
        Page.Response.End()
    End Sub

End Class
