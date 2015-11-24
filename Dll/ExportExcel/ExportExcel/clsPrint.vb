Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Xml
Imports SysMagic.SystemClass
Imports SysMagic.ZZSystem

Namespace ExportExcel
    <Serializable()> _
    Public Class clsPrint
        ' Methods
        Public Function GetCompName(ByVal objUser As clsUser) As String
            Return objUser.CompanyName
        End Function

        <CLSCompliant(False)> _
        Public Function GetCRS(ByVal intId As Long, ByRef crs As CrystalReportSource, ByVal strWhere As String, ByVal strName As String, ByVal objUser As clsUser) As CrystalReportSource
            Dim commandText As String = "select * from  "
            If (intId <> 0) Then
                commandText = String.Concat(New String() {commandText, strName, " ", strWhere, intId.ToString})
            ElseIf (strWhere <> "") Then
                commandText = (commandText & strName & " " & strWhere)
            Else
                commandText = (commandText & strName)
            End If
            Dim [set] As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, commandText)
            crs.ReportDocument.SetDataSource([set].Tables.Item(0))
            Dim num2 As Integer = (crs.ReportDocument.ParameterFields.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Dim values As New ParameterValues
                Dim value2 As New ParameterDiscreteValue
                If (crs.ReportDocument.ParameterFields.Item(i).Name = "compName") Then
                    value2.Value = Me.GetCompName(objUser)
                    values.Add(value2)
                    crs.ReportDocument.DataDefinition.ParameterFields.Item(i).ApplyDefaultValues(values)
                    crs.ReportDocument.DataDefinition.ParameterFields.Item(i).ApplyCurrentValues(values)
                End If
                i += 1
            Loop
            crs.DataBind()
            Return crs
        End Function

        Public Sub GetGridViewColumns(ByVal strTableName As String, ByVal gvwHidden As GridView, ByRef alType As ArrayList, ByRef strTableTitle As String)
            Dim enumerator As IEnumerator
            Dim unit As Unit
            Dim filename As String = HttpContext.Current.Server.MapPath(("../XML/" & strTableName & ".xml"))
            Dim document As New XmlDocument
            document.Load(filename)
            Dim childNodes As XmlNodeList = document.SelectSingleNode("GridView").ChildNodes
            Dim num As Double = 0
            Try
                enumerator = childNodes.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As XmlNode = DirectCast(enumerator.Current, XmlNode)
                    Dim field As New BoundField
                    If (current.NodeType.ToString <> "Comment") Then
                        Dim element As XmlElement = DirectCast(current, XmlElement)
                        If (element.Name = "Columns") Then
                            field.HeaderText = element.Attributes.ItemOf("sColTitle").InnerText
                            field.DataField = element.Attributes.ItemOf("sColName").InnerText
                            gvwHidden.Columns.Add(field)
                            Dim innerText As String = element.Attributes.ItemOf("sType").InnerText
                            alType.Add(innerText)
                            Dim num2 As Double = Double.Parse(element.Attributes.ItemOf("lColWidth").InnerText)
                            num = (num + num2)
                            unit = New Unit((num2.ToString & "cm"))
                            gvwHidden.Columns.Item((gvwHidden.Columns.Count - 1)).ItemStyle.Width = unit
                            If ((((innerText = "Currency") Or (innerText = "Double")) Or (innerText = "Decimal")) Or (innerText = "Float")) Then
                                gvwHidden.Columns.Item((gvwHidden.Columns.Count - 1)).ItemStyle.HorizontalAlign = HorizontalAlign.Right
                            Else
                                gvwHidden.Columns.Item((gvwHidden.Columns.Count - 1)).ItemStyle.HorizontalAlign = HorizontalAlign.Left
                            End If
                            gvwHidden.Columns.Item((gvwHidden.Columns.Count - 1)).ItemStyle.Font.Name = ChrW(23435) & ChrW(20307)
                        ElseIf (element.Name = "sTitle") Then
                            strTableTitle = element.Attributes.ItemOf("sName").InnerText
                        End If
                    End If
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            unit = New Unit((num.ToString & "cm"))
            gvwHidden.Width = unit
        End Sub

        Public Function GetPartCompName(ByVal objUser As clsUser) As String
            Return objUser.PartCompanyName
        End Function

        Public Sub GetWidth(ByVal strTableName As String, ByVal gvwHidden As GridView, ByRef alType As ArrayList, ByRef strTableTitle As String)
            Dim unit As Unit
            Dim num As Double = 0
            Dim filename As String = HttpContext.Current.Server.MapPath(("../XML/" & strTableName & ".xml"))
            Dim document As New XmlDocument
            document.Load(filename)
            Dim childNodes As XmlNodeList = document.SelectSingleNode("GridView").ChildNodes
            Dim num4 As Integer = (gvwHidden.Columns.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num4)
                Dim enumerator As IEnumerator
                Try
                    enumerator = childNodes.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As XmlNode = DirectCast(enumerator.Current, XmlNode)
                        Dim innerText As String = ""
                        If (current.NodeType.ToString <> "Comment") Then
                            Dim element As XmlElement = DirectCast(current, XmlElement)
                            If (element.Name = "Columns") Then
                                innerText = element.Attributes.ItemOf("sColTitle").InnerText
                                If (gvwHidden.Columns.Item(i).HeaderText <> innerText) Then
                                    GoTo Label_0261
                                End If
                                Dim num3 As Double = Double.Parse(element.Attributes.ItemOf("lColWidth").InnerText)
                                Dim str3 As String = element.Attributes.ItemOf("sType").InnerText
                                alType.Add(str3)
                                unit = New Unit((num3 + Conversions.ToDouble("cm")))
                                gvwHidden.Columns.Item(i).ItemStyle.Width = unit
                                num = (num + num3)
                                If ((((str3 = "Currency") Or (str3 = "Double")) Or (str3 = "Decimal")) Or (str3 = "Float")) Then
                                    gvwHidden.Columns.Item(i).ItemStyle.HorizontalAlign = HorizontalAlign.Right
                                Else
                                    gvwHidden.Columns.Item(i).ItemStyle.HorizontalAlign = HorizontalAlign.Left
                                End If
                                gvwHidden.Columns.Item(i).ItemStyle.Font.Name = ChrW(23435) & ChrW(20307)
                                GoTo Label_0298
                            End If
                            If (element.Name = "sTitle") Then
                                strTableTitle = element.Attributes.ItemOf("sName").InnerText
                            End If
Label_0261:
                        End If
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
Label_0298:
                i += 1
            Loop
            unit = New Unit((num + Conversions.ToDouble("cm")))
            gvwHidden.Width = unit
        End Sub

        <CLSCompliant(False)> _
        Public Sub OutToFile(ByVal strFileName As String, ByVal crs As CrystalReportSource, ByVal Response As HttpResponse)
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

    End Class
End Namespace

