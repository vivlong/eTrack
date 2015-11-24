Imports System.Web.UI.WebControls
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class RoleInfoEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private objServer As clsRoleInfo

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
        Return New clsRoleInfo(intUserId)
    End Function

    Private Function GetRolePersonObject(ByVal intUserId As String) As clsRolePerson
        If Session("RolePerson") IsNot Nothing Then
            Return CType(Session("RolePerson"), clsRolePerson)
        Else
            Return Nothing
        End If
    End Function

    Public Function AddSelectedRolePerson(ByVal strPerson As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strPerson <> ConString.UndefinedString Then
                objServer = NewServerObject(objUser.UserId)
                objServer.RolePerson = GetRolePersonObject(objUser.UserId)
                If objServer.RolePerson Is Nothing Then
                    Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
                End If
                objServer.RolePerson.AddSelectedPerson(strPerson)
                BindRolePerson()
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwPerson)
            Else
                Return ZZMessage.ConMsgRtn.NoChange + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function DeleteOneRolePerson(ByVal strId As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intId As Integer = Integer.Parse(strId)
            objServer = NewServerObject(objUser.UserId)
            objServer.RolePerson = GetRolePersonObject(objUser.UserId)
            If objServer.RolePerson Is Nothing Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If objServer.RolePerson.DeleteOnePerson(intId) Then
                BindRolePerson()
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwPerson)
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function SaveData(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            objServer.RolePerson = GetRolePersonObject(objUser.UserId)
            If objServer.RolePerson Is Nothing Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    objServer.RolePerson.ColBaseDetail.DeleteAllDetail()
                    BindRolePerson()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(gvwPerson)
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Private Sub BindRolePerson()
        gvwPerson.DataSource = objServer.RolePerson.ArrDetail
        gvwPerson.DataBind()
        Session("RolePerson") = objServer.RolePerson
    End Sub

    Private Sub BindDetailData(ByVal intUserId As String, ByVal intId As Int64)
        objServer = NewServerObject(intUserId)
        If intId >= 0 Then
            Dim tmpProp As clsPropRoleInfo = objServer.GetDetail(intId)
            fldId.Value = tmpProp.lId.ToString()
            txtsRoleNo.Text = tmpProp.sRoleNo
            txtsRoleName.Text = tmpProp.sRoleName
            objServer.RolePerson.GetDetail(tmpProp.lId)
            BindRolePerson()
        Else
            fldId.Value = intId.ToString()
            txtsRoleNo.Text = ""
            txtsRoleName.Text = ""
            objServer.RolePerson.GetDetail(intId)
            BindRolePerson()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            hidUser.value = objUser.UserId
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
            txtsRoleNo.Attributes.Add("OnKeyDown", "FocusControl(event,null," + txtsRoleName.ClientID + ");")
            txtsRoleName.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsRoleNo.ClientID + "," + btnSave.ClientID + ");")
            'First Focus Control 
            txtsRoleNo.Focus()
        End If
    End Sub

    Protected Sub gvwPerson_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objServer.RolePerson.Count - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneRolePerson(" + (e.Row.RowIndex + 1).ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objServer.RolePerson.Count - 1 Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedRolePerson();return false;")
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objServer.RolePerson.ArrDetail.Count - 1 Then
                e.Row.Cells(0).Text = ""
            End If
        End If
    End Sub

End Class