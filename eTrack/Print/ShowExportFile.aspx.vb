Imports System.IO
Imports System.Threading
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ExportExcel
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class ShowExportFile
    Inherits System.Web.UI.Page

    Private objList As clsQuery
    Private _TableName As String = ""
    Private _Title As String = ""
    Private _ClassName As String = ""
    Private _SortField As String = ""
    Private _SortDesc As Boolean = False

    'Object Column of Gridview
    Private objColumns As colColumn

    Private Sub SetInitValue(ByVal objUser As clsUser)
        _TableName = Request.QueryString("TableName").ToString()
        _ClassName = Request.QueryString("ClassName").ToString()
        _Title = Request.QueryString("Title").ToString()
        _SortField = Request.QueryString("SortField").ToString()
        _SortDesc = GeneralFun.IntStringAsBool(Request.QueryString("SortDesc").ToString())
        'Create object of Query
        Dim tyType As Type = Type.GetType(_ClassName)
        Dim obj As Object = Activator.CreateInstance(tyType, objUser.UserId)
        objList = CType(obj, clsQuery)
        objList.Query = Request.QueryString("Query").ToString()
        objList.Where = Request.QueryString("Where").ToString()
        If Request.QueryString("Condition") IsNot Nothing Then
            Dim strMsg As String = ""
            objList.DecodeQueryCondition(Request.QueryString("Condition").ToString(), strMsg)
        End If
    End Sub

    Private Function ResponseFile(ByVal _Request As HttpRequest, ByVal _Response As HttpResponse, ByVal _fileName As String, ByVal _fullPath As String, ByVal _speed As Long) As Boolean
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
        Try
            'Object Excel Export
            Dim objExport As ExcelExport
            objExport = New ExcelExport
            objExport.CleanUpTemporaryFiles()

            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                SetInitValue(objUser)
                Dim strExcelFile As String
                objColumns = DynamicGridViewFun.GetColumnFromXmlFile(_TableName, False)
                strExcelFile = objExport.TransformDataTableToExcel(objList.GetAllList(), objColumns)
                'objExport.SendExcelToClient(strExcelFile)
                Dim success As Boolean = ResponseFile(Page.Request, Page.Response, "NewFile.xls", strExcelFile, 1024000)
                If Not success Then
                    Response.Write("Export Excel File Error!")
                End If
            Else
                Response.Write(ZZMessage.ConMsgInfo.TimeOut)
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Page.Response.End()
    End Sub

End Class
