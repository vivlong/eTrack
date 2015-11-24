Imports System.Web.UI.WebControls
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Partial Class System_GridSetTable
    Inherits ListEditPage

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        'If e.Row.RowType = DataControlRowType.Header Then
        '    e.Row.Cells(0).Text = showCode
        '    If numFile = 2 Then
        '        e.Row.Cells(1).Text = showName
        '    End If
        'End If
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
        '        e.Row.Visible = False
        '    End If
        '    e.Row.Attributes.Add("OnClick", "ItemClick('" + e.Row.Cells(0).Text.Replace("'", "\'") + "','" + e.Row.Cells(1).Text.Replace("'", "\'") + "');return false;")
        '    e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
        '    If e.Row.RowIndex Mod 2 = 0 Then
        '        e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
        '    Else
        '        e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
        '    End If
        'End If
    End Sub

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean

    End Function

    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv

    End Function
End Class
