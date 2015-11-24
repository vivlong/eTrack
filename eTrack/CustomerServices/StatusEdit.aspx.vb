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

Class StatusEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private objServer As clsJobStatus
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
        Return New clsJobStatus(intUserId)
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

    Private Sub BindDetailData(ByVal intUserId As String, ByVal strJobNo As String, ByVal intId As Int64)
        objServer = NewServerObject(intUserId)
        If intId >= 0 Then
            Dim tmpProp As clsPropJobStatus = objServer.GetDetail(intId)
            fldId.Value = tmpProp.Id.ToString()
            txtJobNo.Text = tmpProp.JobNo
            If tmpProp.DateTime > ConDateTime.MinDate Then
                txtDateTime.Text = tmpProp.DateTime.ToString(ConDateTime.DateFormat)
            Else
                txtDateTime.Text = ""
            End If
            txtDescription.Text = tmpProp.Description
            txtRefNo.Text = tmpProp.RefNo
            drpStatusCode.SelectedValue = tmpProp.StatusCode
            fldUpdateBy.Value = tmpProp.UpdateBy
            If tmpProp.UpdateDateTime > ConDateTime.MinDate Then
                fldUpdateDateTime.Value = tmpProp.UpdateDateTime.ToString(ConDateTime.DateFormat)
            Else
                fldUpdateDateTime.Value = ""
            End If
        Else
            fldId.Value = intId.ToString()
            txtJobNo.Text = strJobNo
            txtDateTime.Text = ""
            txtDescription.Text = ""
            txtRefNo.Text = ""
        End If

    End Sub

    Private Sub SetInitValue(ByVal objUser As clsUser)
        fldUpdateBy.Value = objUser.UserId
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim objStatus As clsJobStatusList = New clsJobStatusList()
        drpStatusCode.DataSource = objStatus.ListData
        drpStatusCode.DataTextField = "StatusCode"
        drpStatusCode.DataValueField = "StatusCode"
        drpStatusCode.DataBind()
        drpStatusCode.Items.Insert(0, New ListItem(ListItemSelect, ""))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            Dim strJobNo As String = ""
            If Not (Request("JobNo") Is Nothing) Then
                strJobNo = Request("JobNo").ToString()
            End If
            Dim intId As Integer = ConClass.NewIdValue
            If Not (Request("Id") Is Nothing) Then
                intId = Integer.Parse(Request("Id").ToString())
            End If
            'Set Default Value
            SetInitValue(objUser)
            'Bind Detail Data
            BindDetailData(objUser.UserId, strJobNo, intId)
            'Button Event
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
            btnNew.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            'Datetime Event
            btnDateTime.Attributes.Add("OnClick", "showCalendar(txtDateTime,0);return false;")
            'KeyDown Event
            txtDateTime.Attributes.Add("OnKeyDown", "FocusControl(event,null," + txtDescription.ClientID + ");")
            txtDescription.Attributes.Add("OnKeyDown", "FocusControl(event," + txtDateTime.ClientID + "," + txtRefNo.ClientID + ");")
            txtRefNo.Attributes.Add("OnKeyDown", "FocusControl(event," + txtDescription.ClientID + "," + drpStatusCode.ClientID + ");")
            drpStatusCode.Attributes.Add("OnKeyDown", "FocusControl(event," + txtRefNo.ClientID + "," + btnSave.ClientID + ");")
            'Readonly
            txtJobNo.ReadOnly = True
            'First Focus Control
            txtDateTime.Focus()

            If objUser.LoginType.ToUpper = "OA" Then
                drpStatusCode.Items.Clear()
                drpStatusCode.Items.Add("POD")
                drpStatusCode.Text = "POD"
                'btnNew.visible = False
                'drpStatusCode.Enabled = False
            ElseIf objUser.LoginType.ToUpper = "WH" Then
                drpStatusCode.Items.Clear()
                drpStatusCode.Items.Add("WHC")
                drpStatusCode.Text = "WHC"
                'btnNew.visible = False
            End If

        End If
    End Sub

End Class