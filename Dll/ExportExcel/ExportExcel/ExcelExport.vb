Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports SysMagic.ZZSystem

Namespace ExportExcel
    Public Class ExcelExport
        ' Methods
        Public Function AddExcelSheetToExcelTemplate(ByVal strExcelFile As String, ByVal strExcelTemplate As String) As String
            Dim str As String
            Try
                str = Me.AddExcelSheetToExcelTemplate(strExcelFile, strExcelTemplate, 1, "Temp")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function AddExcelSheetToExcelTemplate(ByVal strExcelFile As String, ByVal strExcelTemplate As String, ByVal intIndexOfExcelSheetToBeCopied As Integer) As String
            Dim str As String
            Try
                str = Me.AddExcelSheetToExcelTemplate(strExcelFile, strExcelTemplate, intIndexOfExcelSheetToBeCopied, "Temp")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function AddExcelSheetToExcelTemplate(ByVal strExcelFile As String, ByVal strExcelTemplate As String, ByVal strExcelSheetName As String) As String
            Dim str As String
            Try
                str = Me.AddExcelSheetToExcelTemplate(strExcelFile, strExcelTemplate, 1, strExcelSheetName)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function AddExcelSheetToExcelTemplate(ByVal strExcelFile As String, ByVal strExcelTemplate As String, ByVal intIndexOfExcelSheetToBeCopied As Integer, ByVal strExcelSheetName As String) As String
            Dim str As String
            Dim obj2 As Object = Nothing
            Dim instance As Object = Nothing
            Dim obj4 As Object = Nothing
            Dim obj5 As Object = Nothing
            Try
                Dim typeFromProgID As Type = Type.GetTypeFromProgID("Excel.Application")
                Me.objExcel = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(typeFromProgID))
                NewLateBinding.LateSet(Me.objExcel, Nothing, "Visible", New Object() {False}, Nothing, Nothing)
                NewLateBinding.LateSet(Me.objExcel, Nothing, "DisplayAlerts", New Object() {False}, Nothing, Nothing)
                strExcelTemplate = strExcelTemplate.Replace(Me.TemplateFolder, "")
                strExcelFile = strExcelFile.Replace(Me.TempFolder, "")
                instance = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Me.objExcel, Nothing, "Workbooks", New Object(0 - 1) {}, Nothing, Nothing, Nothing))
                NewLateBinding.LateCall(instance, Nothing, "Open", New Object() {(Me.TemplateFolder & strExcelTemplate)}, Nothing, Nothing, Nothing, True)
                NewLateBinding.LateCall(instance, Nothing, "Open", New Object() {(Me.TempFolder & strExcelFile)}, Nothing, Nothing, Nothing, True)
                Dim str2 As String = String.Concat(New String() {Me.TempFolder, strExcelTemplate.Replace(".xls", ""), DateAndTime.Now.ToString("MM-dd-yy"), " ", DateAndTime.Now.Hour.ToString, DateAndTime.Now.Minute.ToString, DateAndTime.Now.Second.ToString, DateAndTime.Now.Millisecond.ToString, ".xls"})
                Dim arguments As Object() = New Object() {str2}
                Dim copyBack As Boolean() = New Boolean() {True}
                NewLateBinding.LateCall(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {1}, Nothing, Nothing, Nothing), Nothing, "SaveAs", arguments, Nothing, Nothing, copyBack, True)
                If copyBack(0) Then
                    str2 = CStr(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments(0)), GetType(String)))
                End If
                Dim objArray As Object() = New Object() {intIndexOfExcelSheetToBeCopied}
                copyBack = New Boolean() {True}
                If copyBack(0) Then
                    intIndexOfExcelSheetToBeCopied = CInt(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray(0)), GetType(Integer)))
                End If
                Dim objArray9 As Object() = New Object(1 - 1) {}
                Dim obj6 As Object = instance
                Dim objArray5 As Object() = New Object(1 - 1) {}
                Dim objArray4 As Object() = objArray5
                Dim index As Integer = 0
                Dim obj7 As Object = 1
                objArray4(index) = RuntimeHelpers.GetObjectValue(obj7)
                Dim objArray6 As Object() = objArray4
                Dim argumentNames As String() = Nothing
                Dim objArray7 As Object() = New Object(0 - 1) {}
                Dim strArray2 As String() = Nothing
                Dim objArray8 As Object() = New Object(1 - 1) {}
                Dim num3 As Integer = 1
                objArray8(0) = num3
                objArray9(0) = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj6, Nothing, "Item", objArray6, argumentNames, Nothing, Nothing), Nothing, "Worksheets", objArray7, strArray2, Nothing, Nothing), Nothing, "Item", objArray8, Nothing, Nothing, Nothing))
                Dim objArray10 As Object() = objArray9
                Dim flagArray2 As Boolean() = New Boolean() {True}
                NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {2}, Nothing, Nothing, Nothing), Nothing, "Worksheets", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "Item", objArray, Nothing, Nothing, copyBack), Nothing, "Copy", objArray10, Nothing, Nothing, flagArray2, True)
                If flagArray2(0) Then
                    objArray4 = objArray5
                    objArray4(index) = RuntimeHelpers.GetObjectValue(obj7)
                    NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj6, Nothing, "Item", objArray6, argumentNames, Nothing, Nothing), Nothing, "Worksheets", objArray7, strArray2, Nothing, Nothing), Nothing, "Item", New Object() {num3, RuntimeHelpers.GetObjectValue(objArray10(0))}, Nothing, Nothing, True, True)
                End If
                NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {1}, Nothing, Nothing, Nothing), Nothing, "Worksheets", New Object(0 - 1) {}, Nothing, Nothing, Nothing), Nothing, "Item", New Object() {1}, Nothing, Nothing, Nothing), Nothing, "Name", New Object() {strExcelSheetName}, Nothing, Nothing, False, True)
                NewLateBinding.LateCall(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {2}, Nothing, Nothing, Nothing), Nothing, "Close", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
                NewLateBinding.LateCall(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {1}, Nothing, Nothing, Nothing), Nothing, "Save", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
                NewLateBinding.LateCall(NewLateBinding.LateGet(instance, Nothing, "Item", New Object() {1}, Nothing, Nothing, Nothing), Nothing, "Close", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
                NewLateBinding.LateCall(Me.objExcel, Nothing, "Quit", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
                str = str2
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            Finally
                Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(Me.objExcel))
                Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(instance))
                Me.objExcel = Nothing
                instance = Nothing
                obj2 = Nothing
                obj5 = Nothing
                obj4 = Nothing
                GC.Collect()
            End Try
            Return str
        End Function

        Public Sub CleanUpTemporaryFiles()
            Try
                If (Me.TempFolder <> HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath)) Then
                    Dim str As String
                    For Each str In Directory.GetFiles(Me.TempFolder)
                        'If (DateTime.Compare(File.GetLastAccessTime(str), DateTime.Now.AddMinutes(-10)) < 0) Then
                        File.Delete(str)
                        'End If
                    Next
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Private Function CreateXSL(ByVal dtTable As DataTable, ByVal blnDisplayColumnHeader As Boolean) As String
            Dim str As String
            Dim builder As StringBuilder
            Try
                Dim enumerator2 As IEnumerator
                builder = New StringBuilder
                builder.Append("<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" version=""1.0"">" & ChrW(13) & ChrW(10))
                builder.Append("<xsl:template match=""/"">" & ChrW(13) & ChrW(10))
                builder.Append("<HTML>" & ChrW(13) & ChrW(10))
                builder.Append("<HEAD>" & ChrW(13) & ChrW(10))
                builder.Append("<STYLE>" & ChrW(13) & ChrW(10))
                builder.Append(".Item {")
                builder.Append("border: solid thin Black;")
                builder.Append("}" & ChrW(13) & ChrW(10))
                builder.Append("</STYLE>" & ChrW(13) & ChrW(10))
                builder.Append("</HEAD>" & ChrW(13) & ChrW(10))
                builder.Append("<BODY>" & ChrW(13) & ChrW(10))
                builder.Append("<TABLE>" & ChrW(13) & ChrW(10))
                builder.Append("<TR>" & ChrW(13) & ChrW(10))
                If blnDisplayColumnHeader Then
                    Dim enumerator As IEnumerator
                    Try
                        enumerator = dtTable.Columns.GetEnumerator
                        Do While enumerator.MoveNext
                            Dim current As DataColumn = DirectCast(enumerator.Current, DataColumn)
                            If (current.ColumnName.IndexOf("rowstat") < 0) Then
                                builder.Append("<TD class=""Item"" style=""font-weight:bolder;test-align:center"">")
                                builder.Append(current.ColumnName)
                                builder.Append("</TD>" & ChrW(13) & ChrW(10))
                            End If
                        Loop
                    Finally
                        If TypeOf enumerator Is IDisposable Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
                builder.Append("</TR>" & ChrW(13) & ChrW(10))
                builder.Append(("<xsl:for-each select=""NewDataSet/" & dtTable.TableName & """>" & ChrW(13) & ChrW(10)))
                builder.Append("<TR>" & ChrW(13) & ChrW(10))
                Try
                    enumerator2 = dtTable.Columns.GetEnumerator
                    Do While enumerator2.MoveNext
                        Dim column2 As DataColumn = DirectCast(enumerator2.Current, DataColumn)
                        If (column2.ColumnName.IndexOf("rowstat") < 0) Then
                            builder.Append("<TD class=""Item"" style=""test-align:left""><xsl:value-of select=""")
                            builder.Append(column2.ColumnName)
                            builder.Append("""/></TD>" & ChrW(13) & ChrW(10))
                        End If
                    Loop
                Finally
                    If TypeOf enumerator2 Is IDisposable Then
                        TryCast(enumerator2, IDisposable).Dispose()
                    End If
                End Try
                builder.Append("</TR>" & ChrW(13) & ChrW(10))
                builder.Append("</xsl:for-each>" & ChrW(13) & ChrW(10))
                builder.Append("</TABLE>" & ChrW(13) & ChrW(10))
                builder.Append("</BODY>" & ChrW(13) & ChrW(10))
                builder.Append("</HTML>" & ChrW(13) & ChrW(10))
                builder.Append("</xsl:template>" & ChrW(13) & ChrW(10))
                builder.Append("</xsl:stylesheet>" & ChrW(13) & ChrW(10))
                str = builder.ToString
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            Finally
                builder = Nothing
            End Try
            Return str
        End Function

        Private Function CreateXSL(ByVal dtTable As DataTable, ByVal objColumns As colColumn, ByVal blnDisplayColumnHeader As Boolean) As String
            Dim str As String
            Dim builder As StringBuilder
            Try
                Dim enumerator2 As IEnumerator
                builder = New StringBuilder
                builder.Append("<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform""")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(" xmlns:msxsl=""urn:schemas-microsoft-com:xslt""")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(" xmlns:vcsharp=""urn:vcsharp-com""")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(" xmlns:ms=""urn:schemas-microsoft-com:xslt""")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(" xmlns:obj=""")
                builder.Append("urn:User-Controls")
                builder.Append("""")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(">")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<xsl:template match=""/"">")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<HTML>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<HEAD>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<STYLE>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(".Item {")
                builder.Append("border: solid thin Black;")
                builder.Append("}")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</STYLE>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</HEAD>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<BODY>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<TABLE>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<TR>")
                builder.Append(ChrW(13) & ChrW(10))
                If blnDisplayColumnHeader Then 'Column Name
                    Dim enumerator As IEnumerator
                    Try
                        enumerator = objColumns.Column.GetEnumerator
                        Do While enumerator.MoveNext
                            Dim current As clsPropColumn = DirectCast(enumerator.Current, clsPropColumn)
                            builder.Append("<TD class=""Item""")
                            builder.Append(" style=""text-align:center;font-weight:bolder;width:") 'by lzw for column center
                            builder.Append(current.Width.ToString)
                            builder.Append("px""")
                            builder.Append(">")
                            builder.Append(current.FieldTitle)
                            builder.Append("</TD>")
                            builder.Append(ChrW(13) & ChrW(10))
                        Loop
                    Finally
                        If TypeOf enumerator Is IDisposable Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
                builder.Append("</TR>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append(("<xsl:for-each select=""NewDataSet/" & dtTable.TableName & """>"))
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("<TR>")
                builder.Append(ChrW(13) & ChrW(10))
                Try
                    enumerator2 = objColumns.Column.GetEnumerator
                    Do While enumerator2.MoveNext
                        Dim column2 As clsPropColumn = DirectCast(enumerator2.Current, clsPropColumn)
                        Select Case CInt(column2.FieldType)
                            Case 5
                                builder.Append("<TD class=""Item"" style=""test-align:left""><xsl:value-of select=""obj:FormatDateTime(") 'by lzw for column align
                                builder.Append(column2.FieldName)
                                builder.Append(",'")
                                If (column2.Format = "") Then
                                    GoTo Label_03EF
                                End If
                                builder.Append(column2.Format)
                                GoTo Label_03FC
                            Case 6
                                builder.Append("<TD class=""Item"" style=""test-align:left""><xsl:value-of select=""obj:FormatDateTime(") 'by lzw for column align
                                builder.Append(column2.FieldName)
                                builder.Append(",'")
                                If (column2.Format = "") Then
                                    GoTo Label_046C
                                End If
                                builder.Append(column2.Format)
                                GoTo Label_0479
                            Case 7, 8
                                builder.Append("<TD class=""Item"" style=""test-align:left""><xsl:value-of select=""obj:FormatNumber(") 'by lzw for column align
                                builder.Append(column2.FieldName)
                                builder.Append(",'")
                                If (column2.Format = "") Then
                                    Exit Select
                                End If
                                builder.Append(column2.Format)
                                GoTo Label_037F
                            Case Else
                                GoTo Label_0494
                        End Select
                        builder.Append("#,##0.00")
Label_037F:
                        builder.Append("')""/></TD>")
                        builder.Append(ChrW(13) & ChrW(10))
                        GoTo Label_04C6
Label_03EF:
                        builder.Append("yyyy-MM-dd")
Label_03FC:
                        builder.Append("')""/></TD>")
                        builder.Append(ChrW(13) & ChrW(10))
                        GoTo Label_04C6
Label_046C:
                        builder.Append("yyyy-MM-dd HH:mm")
Label_0479:
                        builder.Append("')""/></TD>")
                        builder.Append(ChrW(13) & ChrW(10))
                        GoTo Label_04C6
Label_0494:
                        builder.Append("<TD class=""Item""><xsl:value-of select=""")
                        builder.Append(column2.FieldName)
                        builder.Append("""/></TD>")
                        builder.Append(ChrW(13) & ChrW(10))
Label_04C6:
                    Loop
                Finally
                    If TypeOf enumerator2 Is IDisposable Then
                        TryCast(enumerator2, IDisposable).Dispose()
                    End If
                End Try
                builder.Append("</TR>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</xsl:for-each>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</TABLE>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</BODY>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</HTML>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</xsl:template>")
                builder.Append(ChrW(13) & ChrW(10))
                builder.Append("</xsl:stylesheet>")
                builder.Append(ChrW(13) & ChrW(10))
                str = builder.ToString
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            Finally
                builder = Nothing
            End Try
            Return str
        End Function

        Private Sub JavaScriptFormatData(ByRef sbXSL As StringBuilder)
            sbXSL.Append("  <msxsl:script language=""javascript"" implements-prefix =""user"" >")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("    <![CDATA[")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("       function formatDateTime(dateValue,DateFormat)")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("       {")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("           return dateValue;")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("       }")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("   ]]>")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("")
            sbXSL.Append(ChrW(13) & ChrW(10))
            sbXSL.Append("   </msxsl:script>")
            sbXSL.Append(ChrW(13) & ChrW(10))
        End Sub

        Public Sub SendExcelToClient(ByVal strExcelFile As String)
            Try
                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=NewFile.xls")
                HttpContext.Current.Response.Charset = ""
                HttpContext.Current.Response.ContentType = "application/vnd.xls"
                HttpContext.Current.Response.WriteFile(strExcelFile)
                HttpContext.Current.Response.End()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Function TransformDataTableToExcel(ByVal dtTable As DataTable) As String
            Dim str As String
            Try
                str = Me.TransformDataTableToExcel(dtTable, Nothing, True, "")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function TransformDataTableToExcel(ByVal dtTable As DataTable, ByVal blnDisplayColumnHeader As Boolean) As String
            Dim str As String
            Try
                str = Me.TransformDataTableToExcel(dtTable, Nothing, blnDisplayColumnHeader, "")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function TransformDataTableToExcel(ByVal dtTable As DataTable, ByVal strXSLFile As String) As String
            Dim str As String
            Try
                str = Me.TransformDataTableToExcel(dtTable, Nothing, True, strXSLFile)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Function TransformDataTableToExcel(ByVal dtTable As DataTable, ByVal objColumns As colColumn) As String
            Dim str As String
            Try
                str = Me.TransformDataTableToExcel(dtTable, objColumns, True, "")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Private Function TransformDataTableToExcel(ByVal dtTable As DataTable, ByVal objColumns As colColumn, ByVal blnDisplayColumnHeader As Boolean, ByVal strXSLFile As String) As String
            Dim [set] As DataSet
            Dim w As FileStream = Nothing
            Dim stream As FileStream = Nothing
            Dim input As StringReader = Nothing
            Dim writer As StreamWriter = Nothing
            Dim reader As XmlTextReader = Nothing
            Dim writer2 As XmlTextWriter = Nothing
            Dim document As XPathDocument = Nothing
            Dim transform As XslCompiledTransform = Nothing
            Dim str2 As String
            Dim path As String = Nothing
            Dim str4 As String
            Dim resolver As XmlResolver = Nothing
            Try
                [set] = New DataSet
                [set].Tables.Add(dtTable.Copy)
                If (strXSLFile = "") Then
                    If (objColumns Is Nothing) Then
                        str2 = Me.CreateXSL(dtTable, blnDisplayColumnHeader)
                    Else
                        str2 = Me.CreateXSL(dtTable, objColumns, blnDisplayColumnHeader)
                    End If
                    path = String.Concat(New String() {Me.TempFolder, dtTable.TableName, DateAndTime.Now.ToString("MM-dd-yy"), "_", DateAndTime.Now.Hour.ToString, DateAndTime.Now.Minute.ToString, DateAndTime.Now.Second.ToString, DateAndTime.Now.Millisecond.ToString, ".xsl"})
                    stream = New FileStream(path, FileMode.Create)
                    writer = New StreamWriter(stream)
                    writer.Write(str2)
                    writer.Flush()
                    writer.Close()
                End If
                Dim str As String = String.Concat(New String() {Me.TempFolder, dtTable.TableName, DateAndTime.Now.ToString("MM-dd-yy"), "_", DateAndTime.Now.Hour.ToString, DateAndTime.Now.Minute.ToString, DateAndTime.Now.Second.ToString, DateAndTime.Now.Millisecond.ToString, ".xls"})
                w = New FileStream(str, FileMode.Create)
                writer2 = New XmlTextWriter(w, Encoding.Unicode)
                input = New StringReader([set].GetXml)
                reader = New XmlTextReader(input)
                document = New XPathDocument(reader)
                transform = New XslCompiledTransform
                Dim settings As New XsltSettings
                settings.EnableDocumentFunction = True
                settings.EnableScript = True
                If (strXSLFile = "") Then
                    transform.Load(path, settings, Nothing)
                Else
                    strXSLFile.Replace(Me.XSLStyleSheetFolder, "")
                    strXSLFile = (Me.XSLStyleSheetFolder & strXSLFile)
                    transform.Load(strXSLFile, settings, Nothing)
                End If
                Dim extension As New DataConverter
                Dim arguments As New XsltArgumentList
                arguments.AddExtensionObject("urn:User-Controls", extension)
                transform.Transform(DirectCast(document, IXPathNavigable), arguments, DirectCast(writer2, XmlWriter))
                str4 = str
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            Finally
                str2 = Nothing
                path = Nothing
                [set] = Nothing
                If (Not stream Is Nothing) Then
                    stream.Close()
                    stream = Nothing
                End If
                If (Not writer Is Nothing) Then
                    writer.Close()
                    writer = Nothing
                End If
                If (Not writer2 Is Nothing) Then
                    writer2.Close()
                    writer2 = Nothing
                End If
                If (Not w Is Nothing) Then
                    w.Close()
                    w = Nothing
                End If
                If (Not input Is Nothing) Then
                    input.Close()
                    input = Nothing
                End If
                If (Not reader Is Nothing) Then
                    reader.Close()
                    reader = Nothing
                End If
                document = Nothing
                transform = Nothing
                resolver = Nothing
            End Try
            Return str4
        End Function

        Public Function TransformXMLDocumentToExcel(ByVal XMLDoc As XmlDataDocument, ByVal strXSLFullFilePath As String) As String
            Dim w As FileStream = Nothing
            Dim input As StringReader = Nothing
            Dim reader As XmlTextReader = Nothing
            Dim results As XmlTextWriter = Nothing
            Dim document As XPathDocument = Nothing
            Dim resolver As XmlResolver = Nothing
            Dim transform As XslCompiledTransform = Nothing
            Dim str2 As String
            Try
                input = New StringReader(XMLDoc.OuterXml)
                reader = New XmlTextReader(input)
                document = New XPathDocument(reader)
                Dim path As String = String.Concat(New String() {Me.TempFolder, "ExportedExcel", DateAndTime.Now.ToString("MM-dd-yy"), " ", DateAndTime.Now.Hour.ToString, DateAndTime.Now.Minute.ToString, DateAndTime.Now.Second.ToString, DateAndTime.Now.Millisecond.ToString, ".xls"})
                w = New FileStream(path, FileMode.Create)
                results = New XmlTextWriter(w, Encoding.Unicode)
                transform = New XslCompiledTransform
                strXSLFullFilePath = strXSLFullFilePath.Replace(Me.XSLStyleSheetFolder, "")
                strXSLFullFilePath = (Me.XSLStyleSheetFolder & strXSLFullFilePath)
                Dim settings As New XsltSettings
                settings.EnableDocumentFunction = True
                settings.EnableScript = True
                transform.Load(strXSLFullFilePath, settings, Nothing)
                transform.Transform(document, results)
                str2 = path
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Throw
                ProjectData.ClearProjectError()
            Finally
                If (Not results Is Nothing) Then
                    results.Close()
                    results = Nothing
                End If
                If (Not input Is Nothing) Then
                    input.Close()
                    input = Nothing
                End If
                If (Not reader Is Nothing) Then
                    reader.Close()
                    reader = Nothing
                End If
                If (Not w Is Nothing) Then
                    w.Close()
                    w = Nothing
                End If
                document = Nothing
                transform = Nothing
                resolver = Nothing
            End Try
            Return str2
        End Function


        ' Properties
        Public Property TempFolder As String
            Get
                If (Me.m_strTempFolderName = String.Empty) Then
                    Return (HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\")
                End If
                Return HttpContext.Current.Server.MapPath((HttpContext.Current.Request.ApplicationPath & Me.m_strTempFolderName))
            End Get
            Set(ByVal Value As String)
                Me.m_strTempFolderName = Value
            End Set
        End Property

        Public Property TemplateFolder As String
            Get
                If (Me.m_strTemplateFolderName = String.Empty) Then
                    Return HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath)
                End If
                Return HttpContext.Current.Server.MapPath((HttpContext.Current.Request.ApplicationPath & Me.m_strTemplateFolderName))
            End Get
            Set(ByVal Value As String)
                Me.m_strTemplateFolderName = Value
            End Set
        End Property

        Public Property XSLStyleSheetFolder As String
            Get
                If (Me.m_strXSLStyleSheetFolderName = String.Empty) Then
                    Return HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath)
                End If
                Return HttpContext.Current.Server.MapPath((HttpContext.Current.Request.ApplicationPath & Me.m_strXSLStyleSheetFolderName))
            End Get
            Set(ByVal Value As String)
                Me.m_strXSLStyleSheetFolderName = Value
            End Set
        End Property


        ' Fields
        Private Const DataConverterNameSpaceUrl As String = "urn:User-Controls"
        Private Const DEFAULT_DISPLAY_COLUMN_HEADER As Boolean = True
        Private Const DEFAULT_EXCEL_INDEX As Integer = 1
        Private Const DEFAULT_TEMP_EXCEL_SHEET_NAME As String = "Temp"
        Private Const DEFAULT_XSL_FILE As String = ""
        Private m_strTempFolderName As String = "\Print\Temp\"
        Private m_strTemplateFolderName As String = "\Print\Template\"
        Private m_strXSLStyleSheetFolderName As String = "\Print\XSLStyleSheet\"
        Protected objExcel As Object
        Private Const TEMP_EXCEL_FILE_NAME As String = "ExportedExcel"
    End Class
End Namespace

