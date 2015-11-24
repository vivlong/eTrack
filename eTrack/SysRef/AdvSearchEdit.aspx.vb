Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Class AdvSearchEdit
    Inherits LanguagePage

    Private objColumns As colColumn

    Private Sub SetInitValue()
        If (Request("TableName") IsNot Nothing) AndAlso (Request("FieldPrefix") IsNot Nothing) Then
            Dim strTableName As String = Request("TableName").ToString()
            Dim blnFieldPrefix As Boolean = GeneralFun.IntStringAsBool(Request("FieldPrefix").ToString())
            Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
            drpCondition1.Items.Insert(0, New ListItem(ListItemSelect, ""))
            drpCondition2.Items.Insert(0, New ListItem(ListItemSelect, ""))
            drpCondition3.Items.Insert(0, New ListItem(ListItemSelect, ""))
            drpCondition4.Items.Insert(0, New ListItem(ListItemSelect, ""))
            drpCondition5.Items.Insert(0, New ListItem(ListItemSelect, ""))
            Dim strSql As String = " select sFieldName,sEnglishTitle,sFieldType from GridSet where sTableName='" + strTableName + "' order by sEnglishTitle"
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData(strSql, "")
            If dt.Rows.Count > 0 Then
                Dim FieldTitle As String
                Dim FieldName As String
                Dim strType As String
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    FieldTitle = dt.Rows(i)("sEnglishTitle").ToString.Trim
                    FieldName = dt.Rows(i)("sFieldName").ToString.Trim
                    strType = dt.Rows(i)("sFieldName").ToString.Trim
                    Select Case strType
                        Case "nvarchar"
                            drpCondition1.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",0"))
                            drpCondition2.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",0"))
                            drpCondition3.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",0"))
                            drpCondition4.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",0"))
                            drpCondition5.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",0"))
                        Case Else
                            drpCondition1.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",1"))
                            drpCondition2.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",1"))
                            drpCondition3.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",1"))
                            drpCondition4.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",1"))
                            drpCondition5.Items.Insert(i + 1, New ListItem(FieldTitle, FieldName + ",1"))
                    End Select
                Next i
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            SetInitValue()
            btnOk.Attributes.Add("OnClick", "ClosingWindow(1);return false;")
            btnCancel.Attributes.Add("OnClick", "ClosingWindow(0);return false;")
        End If
    End Sub

End Class