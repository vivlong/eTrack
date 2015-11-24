Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports Ntools
Imports SysMagic

Partial Class Reference_SendeEmail
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private returnValue As String
    Private objServer As clsSendEmail
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
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsSendEmail(intUserId)
    End Function
   
#Region "Send Email"
    Public Function SendEmail(ByVal strValue As String) As String  '' for this function need first save the data then second send the email.
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                'If objServer.Save(strMsg) Then
                '    Dim intTrxNo As Int64 = GetNewId()
                '    BindAttach(objUser.UserId, intTrxNo)
                'Else
                '    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                'End If
            End If
            Dim tmpProp As clsPropSendEmail = objServer.GetDetail("")
            Dim strUserName As String
            strUserName = CStr(Request.Cookies("UserName").Value)
            If objServer.SendEmail(strUserName) Then
                ''Return "Send the request Successful!"
                Dim returnMessage As String

                returnMessage = "Send Successful!"

                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + returnMessage
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + "Unable to send the email. bcos the email problem , pls check it."
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSend.Attributes.Add("OnClick", "SendEmail();return false;")
        btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
    End Sub
End Class
