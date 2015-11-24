Imports System
Imports System.Collections
Imports System.Collections.Generic
Partial Class Statistics_Charts
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadByVal(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'BindControl()
            BindData()
        End If
    End Sub
    'Sub BindControl()
    '    Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
    '    drStyle.Items.Insert(0, New ListItem("None_None_None_None_None_None", "None_None_None_None_None_None"))
    '    drStyle.Items.Insert(0, New ListItem("Bar_2D_Breeze_NoCrystal_NoGlow_NoBorder", "Bar_2D_Breeze_NoCrystal_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem("Bar_3D_Breeze_NoCrystal_NoGlow_NoBorder", "Bar_3D_Breeze_NoCrystal_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem("Line_2D_StarryNight_ThickRound_NoGlow_NoBorder", "Line_2D_StarryNight_ThickRound_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem("Line_3D_Breeze_NoCrystalNone_NoGlow_NoBorder", "Line_3D_Breeze_NoCrystalNone_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem("Pie_2D_Breeze_NoCrystal_NoGlow_NoBorder", "Pie_2D_Breeze_NoCrystal_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem("Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder", "Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder"))
    '    drStyle.Items.Insert(0, New ListItem(ListItemSelect, ""))
    'End Sub
    Sub BindData()
        Dim strMonth As String = ""
        Dim arrMonth() As String
        clStatis.Width = 400
        Dim arrTitle As New ArrayList()
        Dim arrData As ArrayList() = New ArrayList() {New ArrayList}
        If Not IsPostBack Then
            If Request("strMonth") IsNot Nothing Then
                strMonth = Request("strMonth").ToString
                arrMonth = strMonth.Split(",")
                arrTitle.Add("Jan")
                arrTitle.Add("Feb")
                arrTitle.Add("Mar")
                arrTitle.Add("Apr")
                arrTitle.Add("May")
                arrTitle.Add("Jun")
                arrTitle.Add("Jul")
                arrTitle.Add("Aug")
                arrTitle.Add("Sep")
                arrTitle.Add("Oct")
                arrTitle.Add("Nov")
                arrTitle.Add("Dec")
                Dim i As Integer
                For i = 0 To 11
                    'arrData(0).Add(arrMonth(i))
                    arrData(0).Add(arrMonth(i))
                Next
            End If
        End If
        clStatis.FillShiftStep = 8

        clStatis.InitializeData(arrData, arrTitle, Nothing)
    End Sub
End Class
