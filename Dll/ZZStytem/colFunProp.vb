Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data

Namespace ZZSystem
    <CLSCompliant(True)> _
    Public Class colFunProp
        ' Methods
        Public Sub AddTableToList(ByVal dt As DataTable)
            Me._ArrFunProp.Clear()
            Dim num2 As Integer = (dt.Rows.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Dim prop As New clsFunProp
                If (dt.Rows.Item(i).Item("sFunNo") Is DBNull.Value) Then
                    prop.FunNo = ""
                Else
                    prop.FunNo = dt.Rows.Item(i).Item("sFunNo").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("sFunName") Is DBNull.Value) Then
                    prop.FunName = ""
                Else
                    prop.FunName = dt.Rows.Item(i).Item("sFunName").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("sFunUrl") Is DBNull.Value) Then
                    prop.FunUrl = ""
                Else
                    prop.FunUrl = dt.Rows.Item(i).Item("sFunUrl").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("sImage") Is DBNull.Value) Then
                    prop.Image = ""
                Else
                    prop.Image = dt.Rows.Item(i).Item("sImage").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("sParentNo") Is DBNull.Value) Then
                    prop.ParentNo = ""
                Else
                    prop.ParentNo = dt.Rows.Item(i).Item("sParentNo").ToString.Trim
                End If
                If (dt.Rows.Item(i).Item("lType") Is DBNull.Value) Then
                    prop.Type = 0
                Else
                    prop.Type = Integer.Parse(dt.Rows.Item(i).Item("lType").ToString.Trim)
                End If
                prop.No = (i + 1)
                Me._ArrFunProp.Add(prop)
                i += 1
            Loop
        End Sub


        ' Properties
        Public ReadOnly Property ArrFunProp() As ArrayList
            Get
                Return Me._ArrFunProp
            End Get
        End Property


        ' Fields
        Private _ArrFunProp As ArrayList = New ArrayList
    End Class
End Namespace

