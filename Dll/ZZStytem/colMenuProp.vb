Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data

Namespace ZZSystem
    <CLSCompliant(True)> _
    Public Class colMenuProp
        ' Methods
        Public Sub AddTableToList(ByVal dt As DataTable)
            Me._ArrMenuProp.Clear()
            Dim num2 As Integer = (dt.Rows.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Dim prop As New clsMenuProp
                If (dt.Rows.Item(i).Item("sMenuName") Is DBNull.Value) Then
                    prop.MenuName = ""
                Else
                    prop.MenuName = dt.Rows.Item(i).Item("sMenuName").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("sImage") Is DBNull.Value) Then
                    prop.Image = ""
                Else
                    prop.Image = dt.Rows.Item(i).Item("sImage").ToString.Trim
                End If
                prop.No = (i + 1)
                Me._ArrMenuProp.Add(prop)
                i += 1
            Loop
        End Sub


        ' Properties
        Public ReadOnly Property ArrMenuProp() As ArrayList
            Get
                Return Me._ArrMenuProp
            End Get
        End Property


        ' Fields
        Private _ArrMenuProp As ArrayList = New ArrayList
    End Class
End Namespace

