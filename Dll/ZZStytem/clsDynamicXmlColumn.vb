Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Xml

Namespace ZZSystem

    Public Class clsDynamicXmlColumn
        Inherits colColumn
        ' Methods
        Public Sub New(ByVal strTableName As String)
            Me.TableName = strTableName
            Me.Column = New ArrayList
            Me._XmlFileName = HttpContext.Current.Server.MapPath(("../XML/" & Me.TableName & ".xml"))
            Me._xmlDoc = New XmlDocument
            Me._xmlDoc.Load(Me._XmlFileName)
        End Sub

        Public Sub GetColumnFromXmlFile(ByVal blnAll As Boolean, ByVal blnFieldPrefix As Boolean)
            Dim num As Double = 0
            Dim childNodes As XmlNodeList = Me._xmlDoc.SelectSingleNode("GridView").ChildNodes
            Dim strTitle As String = ""
            Dim strField As String = ""
            Dim strSortField As String = ""
            Dim intLevel As Integer = 0
            Dim dblWidth As New Decimal
            Dim strFieldType As String = ""
            Dim blnVisible As Boolean = False
            Dim strFormat As String = ""
            Dim blnTailZeroDelete As Boolean = False
            Dim intFixedDigital As Integer = 0
            Dim strHeaderImageUrl As String = ""
            Dim str7 As String = ""
            If Not Information.IsNothing(RuntimeHelpers.GetObjectValue(HttpContext.Current.Session.Item("CurrentLanguage"))) Then
                str7 = Conversions.ToString(HttpContext.Current.Session.Item("CurrentLanguage"))
            End If
            If String.IsNullOrEmpty(str7) Then
                str7 = "English"
            End If
            Dim right As String = "EnglishTitle"
            Dim str5 As String = "EnglishFormat"
            right = (str7 & "Title")
            str5 = (str7 & "Format")
            Dim num7 As Integer = childNodes.Count - 1
            Dim i As Integer = 0
            Do While (i <= num7)
                Dim node As XmlNode = childNodes.ItemOf(i)
                If (Operators.CompareString(node.NodeType.ToString, "Comment", True) <> 0) Then
                    Dim element As XmlElement = DirectCast(node, XmlElement)
                    If (Operators.CompareString(element.Name, "Columns", True) = 0) Then
                        strTitle = ""
                        strField = ""
                        strSortField = ""
                        intLevel = 0
                        dblWidth = New Decimal
                        strFieldType = ""
                        blnVisible = True
                        strFormat = ""
                        blnTailZeroDelete = False
                        intFixedDigital = 0
                        Dim num8 As Integer = (element.ChildNodes.Count - 1)
                        Dim j As Integer = 0
                        Do While (j <= num8)
                            Dim node2 As XmlNode = element.ChildNodes.ItemOf(j)
                            Dim name As String = node2.Name
                            If (Operators.CompareString(name, right, True) = 0) Then
                                strTitle = node2.InnerText
                            ElseIf (Operators.CompareString(name, "FieldName", True) = 0) Then
                                strField = node2.InnerText
                            ElseIf (Operators.CompareString(name, "SortField", True) = 0) Then
                                strSortField = node2.InnerText
                            ElseIf (Operators.CompareString(name, "FieldWidth", True) = 0) Then
                                dblWidth = Decimal.Parse(node2.InnerText)
                            ElseIf (Operators.CompareString(name, "FieldType", True) = 0) Then
                                strFieldType = node2.InnerText
                            ElseIf (Operators.CompareString(name, "Order", True) = 0) Then
                                intLevel = Integer.Parse(node2.InnerText)
                            ElseIf (Operators.CompareString(name, "Visible", True) = 0) Then
                                blnVisible = Boolean.Parse(node2.InnerText)
                            ElseIf (Operators.CompareString(name, str5, True) = 0) Then
                                strFormat = node2.InnerText
                            ElseIf (Operators.CompareString(name, "TailZeroDelete", True) = 0) Then
                                blnTailZeroDelete = Boolean.Parse(node2.InnerText)
                            ElseIf (Operators.CompareString(name, "FixedDigital", True) = 0) Then
                                intFixedDigital = Integer.Parse(node2.InnerText)
                            ElseIf (Operators.CompareString(name, "HeaderImageUrl", True) = 0) Then
                                strHeaderImageUrl = node2.InnerText
                            End If
                            j += 1
                        Loop
                        If blnFieldPrefix Then
                            strField = (Me.GetFieldPrefix(strFieldType) & strField)
                        End If
                        If (IIf((blnVisible OrElse blnAll), 1, 0) <> 0) Then
                            Me.AddToColumn(strField, strTitle, Me.GetFieldType(strFieldType), intLevel, dblWidth, strFormat, blnTailZeroDelete, intFixedDigital, strSortField, blnVisible, strHeaderImageUrl)
                            num = (num + Convert.ToDouble(dblWidth))
                        End If
                    ElseIf (Operators.CompareString(element.Name, "Property", True) = 0) Then
                        Me.OrderBy = element.Attributes.ItemOf("OrderBy").InnerText
                    End If
                End If
                i += 1
            Loop
            Me.TotalWidth = CSng(num)
        End Sub

        Public Sub SetColumnToXmlFile(ByVal strValues As String)
            Dim childNodes As XmlNodeList = Me._xmlDoc.SelectSingleNode("GridView").ChildNodes
            Dim right As String = ""
            Dim num3 As Integer = (childNodes.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num3)
                Dim node As XmlNode = childNodes.ItemOf(i)
                If (Operators.CompareString(node.NodeType.ToString, "Comment", True) <> 0) Then
                    Dim element As XmlElement = DirectCast(node, XmlElement)
                    If (Operators.CompareString(element.Name, "Columns", True) = 0) Then
                        right = element.ChildNodes.ItemOf(1).InnerText
                        Dim row As String() = GeneralFun.GetRow(strValues)
                        Dim num4 As Integer = (row.Length - 1)
                        Dim j As Integer = 0
                        Do While (j <= num4)
                            Dim col As String() = GeneralFun.GetCol(row(j))
                            If (Operators.CompareString(col(0), right, True) = 0) Then
                                element.ChildNodes.ItemOf(2).InnerText = col(1)
                                element.ChildNodes.ItemOf(4).InnerText = col(2)
                                element.ChildNodes.ItemOf(5).InnerText = col(3)
                            End If
                            j += 1
                        Loop
                    End If
                End If
                i += 1
            Loop
            Me._xmlDoc.Save(Me._XmlFileName)
        End Sub


        ' Fields
        Private _xmlDoc As XmlDocument
        Private _XmlFileName As String
    End Class
End Namespace