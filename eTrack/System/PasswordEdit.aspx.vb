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
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Class PasswordEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private returnValue As String

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

    Public Function SavePassword(ByVal strValue As String) As String
        Dim strMsg As String = ""
        Dim objPassword As New clsPassword()
        If objPassword.ModifyPassword(strValue) Then
            If objPassword.Save(strMsg) Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
            End If
        Else
            Return ZZMessage.ConMsgRtn.Err
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
        'Set timeout 
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Judge Login or not
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Request("BusinessPartyCode") IsNot Nothing Then
                fldUserNo.Value = Request("BusinessPartyCode").ToString
                fldPassword.Value = getPassowrd(Request("BusinessPartyCode").ToString)
                fldTable.value = "rcbp1"
            Else
                If Session("LoginType") = 0 Then
                    fldTable.Value = "rcbp1"
                Else
                    fldTable.Value = "saus1"
                End If
                fldUserNo.Value = objUser.UserId
                fldPassword.Value = objUser.Password
            End If
        End If
        'First Focus Control
        txtsPasswordOld.Focus()
        'KeyDown Event
        txtsPasswordOld.Attributes.Add("OnKeyDown", "FocusControl(event,null," + txtsPassword1.ClientID + ");")
        txtsPassword1.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsPasswordOld.ClientID + "," + txtsPassword2.ClientID + ");")
        txtsPassword2.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsPassword1.ClientID + "," + btnSave.ClientID + ");")
        'Button Event
        btnSave.Attributes.Add("OnClick", "SavePassword();return false;")
        btnClear.Attributes.Add("OnClick", "ClearDetail();return false;")
    End Sub
    Private Function getPassowrd(ByVal UserId As String) As String
        If UserId.Trim <> "" Then
            Dim dt As DataTable
            dt = BaseSelectSrvr.GetData("select Password from rcbp1 where BusinessPartyCode='" + UserId + "'", "")
            If dt IsNot Nothing Then
                Return dt.Rows(0)(0).ToString()
            End If
        Else
            Return ""
        End If
        Return ""
    End Function

End Class