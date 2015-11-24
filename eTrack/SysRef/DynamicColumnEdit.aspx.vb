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

Class DynamicColumnEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private returnValue As String
    Dim numObjColumns As Integer
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Dim arrParam As String() = GeneralFun.GetPar(returnValue)
        Select Case arrParam.Length
            Case 1
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, Nothing))
            Case Else
                Dim arrObject(arrParam.Length - 2) As Object
                Dim i As Integer
                For i = 0 To arrParam.Length - 2
                    arrObject(i) = arrParam(i + 1)
                Next
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, arrObject))
        End Select
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Public Function GetDefaultSetting() As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            BindSourceData(objUser.UserId, True)
            Return GridViewFun.RenderControl(gvwSource)
        Else
            Return ""
        End If
    End Function

    Public Function SaveGridColumnSetting(ByVal strValues As String) As String
        Dim objUser As clsUser = Nothing
        Dim strTableName As String = Request("TableName").ToString()
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If DynamicGridViewFun.SetColumnToSqlFile(strTableName, objUser.UserId, strValues) Then
                Return "1"
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function

    Private Function BindSourceData(ByVal intUserId As String, ByVal blnDefault As Boolean) As Boolean
        Dim strTableName As String = Request("TableName").ToString()
        Dim objColumns As colColumn

        If Session("CustType") Is Nothing =False then
            If strTableName.ToUpper = "JMJM1" And Session("CustType").ToString.ToUpper = "WH" Then
                strTableName = "jmjm2"
            End If
        End If
        
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(strTableName, intUserId, blnDefault, False, "DynamicCE")
        numObjColumns = objColumns.Column.Count
        gvwSource.DataSource = objColumns.Column
        gvwSource.DataBind()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Bind Data
            BindSourceData(objUser.UserId, False)
            btnDefault.Attributes.Add("OnClick", "GetDefaultSetting();return false;")
            btnOk.Attributes.Add("OnClick", "SaveGridColumnSetting();return false;")
            btnCancel.Attributes.Add("OnClick", "CloseWindow();return false;")
            If Session("LoginType") = 0 Then
                chkAll.Attributes.Add("onclick", "selectAll('cus'," + chkAll.ClientID + ");")
            Else
                chkAll.Attributes.Add("onclick", "selectAll('int'," + chkAll.ClientID + ");")
            End If


        End If
    End Sub

    Protected Sub gvwSource_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvwSource.DataBound
        Dim i As Integer
        For i = 0 To gvwSource.Rows.Count - 1
            Dim ckb As HtmlControls.HtmlInputCheckBox = gvwSource.Rows(i).FindControl("chkVisible")
            Dim str As String = HttpContext.Current.Session.Item("intCount")
            If Session("LoginType") = 0 Then
                ckb.Attributes.Add("onclick", "JudChk(event,'cus')")
                If numObjColumns > 9 And i > 9 And HttpContext.Current.Session.Item("intCount") = 0 Then
                    ckb.Checked = False
                End If
            ElseIf Session("LoginType") = "1" Then
                If numObjColumns > 9 And str = "0" And i > 9 Then
                    ckb.Checked = False
                End If
                ckb.Attributes.Add("onclick", "JudChk(event,'int')")
            End If
        Next
    End Sub

End Class