Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ZZSystem

    Public Class clsMergeHeader
        ' Methods
        Private Sub AddMergeHeader(ByVal arrHeaderCells As ArrayList)
            Me.m_arrHeaderCells = arrHeaderCells
        End Sub

        Private Sub DatagridToDecorate_ItemCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            Dim rowType As DataControlRowType = e.Row.RowType
            If (DataControlRowType.Header = rowType) Then
                e.Row.SetRenderMethodDelegate(New RenderMethod(AddressOf Me.NewRenderMethod))
            End If
        End Sub

        Public Sub MergeGrid(ByVal gvw As GridView, ByVal arrColumns As ArrayList, ByVal intPos As Integer, ByVal intRowSpan As Integer, ByVal intColSpan As Integer)
            Dim cell As TableCell = Nothing
            Me.DatagridToDecorate = gvw
            Dim arrHeaderCells As New ArrayList
            Dim num2 As Integer = (arrColumns.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                cell = New TableCell
                cell.Text = arrColumns.Item(i).ToString
                cell.Font.Bold = True
                If (i < intPos) Then
                    cell.RowSpan = intRowSpan
                Else
                    cell.ColumnSpan = intColSpan
                End If
                arrHeaderCells.Add(cell)
                i += 1
            Loop
            Me.AddMergeHeader(arrHeaderCells)
        End Sub

        Private Sub NewRenderMethod(ByVal writer As HtmlTextWriter, ByVal ctl As Control)
            Dim num As Integer
            Me.m_htblRowspanIndex.Clear()
            Dim num2 As Integer = 0
            Dim num3 As Integer = (Me.m_arrHeaderCells.Count - 1)
            num = 0
            Do While (num <= num3)
                Dim cell As TableCell = DirectCast(Me.m_arrHeaderCells.Item(num), TableCell)
                If (cell.ColumnSpan > 1) Then
                    num2 = (num2 + (cell.ColumnSpan - 1))
                End If
                If (cell.RowSpan > 1) Then
                    Me.m_htblRowspanIndex.Add((num2 + num), (num2 + num))
                End If
                cell.RenderControl(writer)
                num += 1
            Loop
            writer.WriteEndTag("TR")
            Me.m_dgDatagridToDecorate.HeaderStyle.AddAttributesToRender(writer)
            writer.RenderBeginTag("TR")
            Dim num4 As Integer = (ctl.Controls.Count - 1)
            num = 0
            Do While (num <= num4)
                If Operators.ConditionalCompareObjectEqual(Nothing, Me.m_htblRowspanIndex.Item(num), True) Then
                    ctl.Controls.Item(num).RenderControl(writer)
                End If
                num += 1
            Loop
        End Sub


        ' Properties
        Private Property DatagridToDecorate() As GridView
            Get
                Return Me.m_dgDatagridToDecorate
            End Get
            Set(ByVal value As GridView)
                If (Not Me.m_dgDatagridToDecorate Is Nothing) Then
                    RemoveHandler Me.m_dgDatagridToDecorate.RowCreated, New GridViewRowEventHandler(AddressOf Me.DatagridToDecorate_ItemCreated)
                End If
                Me.m_dgDatagridToDecorate = value
                AddHandler Me.m_dgDatagridToDecorate.RowCreated, New GridViewRowEventHandler(AddressOf Me.DatagridToDecorate_ItemCreated)
            End Set
        End Property


        ' Fields
        Private m_arrHeaderCells As ArrayList = Nothing
        Private m_dgDatagridToDecorate As GridView = Nothing
        Private m_htblRowspanIndex As Hashtable = New Hashtable
    End Class
End Namespace

