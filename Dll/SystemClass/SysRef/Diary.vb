Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.IO
Imports System.Globalization

Namespace SystemClass

#Region " Diary by lzw 090116"
    <Serializable()> _
    Public Class Diary
        Public Sub diaryWrite(ByVal functionName As String, ByVal iErr As String)
            Dim diaryPath As String = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\diary.txt"
            Dim _filestream As FileStream = Nothing
            If File.Exists(diaryPath) <> True Then
                _filestream = File.Create(diaryPath)
                _filestream.Close()
                _filestream = Nothing
            End If
            _filestream = New FileStream(diaryPath, FileMode.OpenOrCreate, FileAccess.Write)
            Dim _streamwriter As New StreamWriter(_filestream)
            _streamwriter.Flush()
            _streamwriter.BaseStream.Seek(0, SeekOrigin.End)
            _streamwriter.Write("\r\nLog Entry : ")
            _streamwriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
            _streamwriter.WriteLine("function bylzw " + functionName + "  " + "\r\n\r message£º" + iErr)
            _streamwriter.WriteLine("#########################################")
            _streamwriter.Flush()
            _streamwriter.Close()
            _filestream = Nothing
            _streamwriter = Nothing
        End Sub
    End Class
#End Region
End Namespace
