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
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Class PersonSet
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private objPerson As clsPersonSet
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

    Public Function UpdatePersonSet(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objPerson = New clsPersonSet(objUser.UserId)
            If Not objPerson.ModifyCurrent(objPerson, strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objPerson.UpdatePersonSet(objPerson, strMsg) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin
        End If
    End Function

    Private Sub BindData()
        txtUserId.Value = objPerson.UserId.ToString()
        drpFirstPage.SelectedValue = objPerson.FirstPage
        txtInfoSize.Text = objPerson.InfoSize.ToString()
        txtSearchSize.Text = objPerson.SearchSize.ToString()
        txtOpenSize.Text = objPerson.OpenSize.ToString()
        txtDetailSize.Text = objPerson.DetailSize.ToString()
        txtStatSize.Text = objPerson.QuerySize.ToString()
        chkDisplaySmsHint.Checked = objPerson.DisplaySmsHint
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'First Page
        Dim objFirstPage As New clsFirstPageList
        drpFirstPage.DataSource = objFirstPage.ListData()
        drpFirstPage.DataTextField = "sFunName"
        drpFirstPage.DataValueField = "lType"
        drpFirstPage.DataBind()
        drpFirstPage.Items.Insert(0, New ListItem(ListItemSelect, "-1"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Get Person Set
            objPerson = New clsPersonSet(objUser.UserId)
            objPerson.GetPersonSet(objUser.UserId)
            'Set Default Value
            SetInitValue(objUser.UserId)
            'Set Data
            BindData()
            'KeyDown Event
            drpFirstPage.Attributes.Add("OnKeyDown", "FocusControl(event,null," + chkDisplaySmsHint.ClientID + ");")
            chkDisplaySmsHint.Attributes.Add("OnKeyDown", "FocusControl(event," + drpFirstPage.ClientID + "," + txtInfoSize.ClientID + ");")
            txtInfoSize.Attributes.Add("OnKeyDown", "FocusControl(event," + chkDisplaySmsHint.ClientID + "," + txtSearchSize.ClientID + ");")
            txtSearchSize.Attributes.Add("OnKeyDown", "FocusControl(event," + txtInfoSize.ClientID + "," + txtOpenSize.ClientID + ");")
            txtOpenSize.Attributes.Add("OnKeyDown", "FocusControl(event," + txtSearchSize.ClientID + "," + txtDetailSize.ClientID + ");")
            txtDetailSize.Attributes.Add("OnKeyDown", "FocusControl(event," + txtOpenSize.ClientID + "," + txtStatSize.ClientID + ");")
            txtStatSize.Attributes.Add("OnKeyDown", "FocusControl(event," + txtDetailSize.ClientID + "," + btnOk.ClientID + ");")
            'Button Click Event
            btnOk.Attributes.Add("onclick", "UpdatePersonSet();return false;")
            'Set first focus control
            drpFirstPage.Focus()
        End If
    End Sub

End Class