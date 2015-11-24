Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Globalization
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ZZSystem

    Public Class GridViewFun
        ' Methods
        Public Shared Sub CreateGridColumn(ByVal ColumnInfos As colColumn, ByRef gvw As GridView, ByVal tyTemplate As TemplateType)
            Dim num As New Decimal
            Dim num3 As Integer = (ColumnInfos.Column.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num3)
                Dim column As clsPropColumn = DirectCast(ColumnInfos.Column.Item(i), clsPropColumn)
                Dim field As New BoundField
                field.DataField = column.FieldName
                field.HeaderText = column.FieldTitle
                field.HeaderImageUrl = column.HeaderImageUrl
                field.ItemStyle.HorizontalAlign = column.Align
                field.SortExpression = column.FieldName
                field.DataFormatString = GridViewFun.GetGridDataFormat(column.Format)
                field.HtmlEncode = False
                Dim unit As New Unit(Convert.ToDouble(column.Width), UnitType.Pixel)
                field.ItemStyle.Width = unit
                gvw.Columns.Add(field)
                i += 1
            Loop
            Select Case CInt(tyTemplate)
                Case 1
                    Dim field2 As New TemplateField
                    field2.ItemTemplate = New BaseInfoTemplate
                    field2.ItemStyle.CssClass = "colEdit taCenter"
                    field2.HeaderStyle.CssClass = "colEdit taCenter"
                    num = 40
                    gvw.Columns.Insert(0, field2)
                    Exit Select
                Case 2
                    Dim field3 As New TemplateField
                    field3.ItemTemplate = New ListPrintTemplate
                    field3.ItemStyle.CssClass = "colListPrint taCenter"
                    field3.HeaderStyle.CssClass = "colListPrint taCenter"
                    num = 60
                    gvw.Columns.Insert(0, field3)
                    Exit Select
                Case 3
                    Dim field4 As New TemplateField
                    field4.ItemTemplate = New RoleInfoTemplate
                    field4.ItemStyle.CssClass = "colRoleInfo taCenter"
                    field4.HeaderStyle.CssClass = "colRoleInfo taCenter"
                    num = 60
                    gvw.Columns.Insert(0, field4)
                    Exit Select
                Case 4
                    Dim field5 As New TemplateField
                    field5.ItemTemplate = New SelectedPrintTemplate
                    field5.ItemStyle.CssClass = "colSelected taCenter"
                    field5.HeaderStyle.CssClass = "colSelected taCenter"
                    num = 60
                    gvw.Columns.Insert(0, field5)
                    Exit Select
            End Select
            gvw.Width = GridViewFun.GetGridViewWidthWithUnit((ColumnInfos.TotalWidth + Convert.ToSingle(num))) 'bylzw090616
        End Sub

        Protected Shared Function GetGridDataFormat(ByVal strFormat As String) As String
            If (Operators.CompareString(strFormat, "", True) <> 0) Then
                Return ("{0:" & strFormat & "}")
            End If
            Return ""
        End Function

        Protected Shared Function GetGridViewWidthWithUnit(ByVal dblTotalWidth As Single) As Unit
            Return New Unit(CDbl(dblTotalWidth), UnitType.Pixel)
        End Function

        Public Shared Function GetSortImage(ByVal blnSortDesc As Boolean) As Image
            Dim sortAscImageUrl As String = GridViewFun.SortAscImageUrl
            If blnSortDesc Then
                sortAscImageUrl = GridViewFun.SortDescImageUrl
            Else
                sortAscImageUrl = GridViewFun.SortAscImageUrl
            End If
            Dim image2 As New Image
            image2.ImageUrl = sortAscImageUrl
            Return image2
        End Function

        Public Shared Function RenderControl(ByVal control As Control) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            Dim writer2 As New HtmlTextWriter(writer)
            control.RenderControl(writer2)
            writer2.Flush()
            writer2.Close()
            Return writer.ToString
        End Function


        ' Fields
        Private Shared SortAscImageUrl As String = "../Images/Edit/SortUp.gif"
        Private Shared SortDescImageUrl As String = "../Images/Edit/SortDown.gif"
    End Class
End Namespace

