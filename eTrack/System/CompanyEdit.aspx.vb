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

Class CompanyEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private objServer As clsCompany
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

    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsCompany(intUserId)
    End Function

    Public Function SaveData(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Private Sub BindDetailData(ByVal intUserId As String, ByVal intId As Int64)
        objServer = NewServerObject(intUserId)
        If intId >= 0 Then
            Dim tmpProp As clsPropCompany = objServer.GetDetail(intId)
            fldId.Value = tmpProp.Id.ToString()
            txtsCompNo.Text = tmpProp.CompanyCode
            txtsCnCompPartName.Text = tmpProp.CompanyName
            txtsCnCompName.Text = tmpProp.Address1
        Else
            fldId.Value = intId.ToString()
            txtsCompNo.Text = ""
            txtsCnCompPartName.Text = ""
            txtsCnCompName.Text = ""
            txtsCnCompAddr.Text = ""
            txtsCompTel.Text = ""
            txtsCompFax.Text = ""
            txtsCompZip.Text = ""
            txtsCompWeb.Text = ""
            txtsCompEmail.Text = ""
            txtsSmtpServer.Text = ""
            txtsSmtpPort.Text = "25"
            txtsSmtpUser.Text = ""
            txtsSmtpPassword.Text = ""
            txtsConfirmPassword.Text = ""
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Key value
            Dim intId As Int64 = ConClass.NewIdValue
            If Not (Request("Id") Is Nothing) Then
                intId = Int64.Parse(Request("Id").ToString())
            End If
            'Bind Detail Data
            BindDetailData(objUser.UserId, intId)
            'Button Event
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
            btnNew.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            'KeyDown Event
            txtsCompNo.Attributes.Add("OnKeyDown", "FocusControl(event,null," + txtsCnCompPartName.ClientID + ");")
            txtsCnCompPartName.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompNo.ClientID + "," + txtsCnCompName.ClientID + ");")
            txtsCnCompName.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCnCompPartName.ClientID + "," + txtsCnCompAddr.ClientID + ");")
            txtsCnCompAddr.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCnCompName.ClientID + "," + txtsCompTel.ClientID + ");")
            txtsCompTel.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCnCompAddr.ClientID + "," + txtsCompFax.ClientID + ");")
            txtsCompFax.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompTel.ClientID + "," + txtsCompZip.ClientID + ");")
            txtsCompZip.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompFax.ClientID + "," + txtsCompWeb.ClientID + ");")
            txtsCompWeb.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompZip.ClientID + "," + "null" + ");")
            txtsCompEmail.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompWeb.ClientID + "," + txtsSmtpServer.ClientID + ");")
            txtsSmtpServer.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsCompEmail.ClientID + "," + txtsSmtpPort.ClientID + ");")
            txtsSmtpPort.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsSmtpServer.ClientID + "," + txtsSmtpUser.ClientID + ");")
            txtsSmtpUser.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsSmtpPort.ClientID + "," + txtsSmtpPassword.ClientID + ");")
            txtsSmtpPassword.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsSmtpUser.ClientID + "," + txtsConfirmPassword.ClientID + ");")
            txtsConfirmPassword.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsSmtpPassword.ClientID + "," + btnSave.ClientID + ");")
            'First Focus Control
            txtsCompNo.Focus()
        End If
    End Sub

End Class