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

Partial Class PersonEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private objServer As clsPerson

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
        Return New clsPerson(intUserId)
    End Function

    Private Function GetPersonRoleObject(ByVal intUserId As String) As clsPersonRole
        If Session("PersonRole") IsNot Nothing Then
            Return CType(Session("PersonRole"), clsPersonRole)
        Else
            Return Nothing
        End If
    End Function

    Public Function AddSelectedRole(ByVal strRole As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If strRole <> ConString.UndefinedString Then
                objServer = NewServerObject(objUser.UserId)
                objServer.PersonRole = GetPersonRoleObject(objUser.UserId)
                If objServer.PersonRole Is Nothing Then
                    Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
                End If
                objServer.PersonRole.AddSelectedRole(strRole)
                BindPersonRole()
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwRoleInfo)
            Else
                Return ZZMessage.ConMsgRtn.NoChange + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function DeleteOneRole(ByVal strId As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intId As Integer = Integer.Parse(strId)
            objServer = NewServerObject(objUser.UserId)
            objServer.PersonRole = GetPersonRoleObject(objUser.UserId)
            If objServer.PersonRole Is Nothing Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If objServer.PersonRole.DeleteOneRole(intId) Then
                BindPersonRole()
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwRoleInfo)
            Else
                Return ZZMessage.ConMsgRtn.NoChange + ConSeparator.Par + ""
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
            objServer.PersonRole = GetPersonRoleObject(objUser.UserId)
            If (objServer.PersonRole Is Nothing) Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If Request("Id") Is Nothing Then
                    objServer.State = EditState.Insert
                End If
                Dim Arr() As String = GeneralFun.GetCol(strValue)
                Dim dtRec As DataTable
                dtRec = BaseSelectSrvr.GetData("select * from saus1 where UserID='" + Arr(0) + "'", "")
                If Not dtRec Is Nothing AndAlso dtRec.Rows.Count > 0 Then
                    objServer.State = EditState.Edit
                    '  Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Already existed this UserID."
                Else
                    objServer.State = EditState.Insert
                End If
                If objServer.Save(strMsg) Then
                    objServer.PersonRole.ColBaseDetail.DeleteAllDetail()
                    BindPersonRole()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg + ConSeparator.Par + "" + ConSeparator.Par + GridViewFun.RenderControl(gvwRoleInfo)
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Private Sub BindDetailData(ByVal intUserId As String, ByVal intId As String)
        objServer = NewServerObject(intUserId)
        If intId <> "" Then
            Dim tmpProp As clsPropPerson = objServer.GetDetail(intId)
            fldId.Value = tmpProp.UserId
            txtsUserNo.Text = tmpProp.UserId
            txtsUserName.Text = tmpProp.UserName
            txtsPassword.Attributes.Add("value", tmpProp.Password)
            txtPassword.Attributes.Add("value", tmpProp.Password)
            objServer.PersonRole.GetDetail(intId)
            BindPersonRole()
        Else
            fldId.Value = intId
            txtsUserNo.Text = ""
            txtsUserName.Text = ""
            txtsPassword.Attributes.Add("value", "")
            txtPassword.Attributes.Add("value", "")
            Dim tmpA As Label = FindControl("a2")
            tmpA.Style.Add("display", "none")
            objServer.PersonRole.GetDetail(intId)
            BindPersonRole()
        End If
    End Sub

    Private Sub BindPersonRole()
        gvwRoleInfo.DataSource = objServer.PersonRole.ArrDetail
        gvwRoleInfo.DataBind()
        Session("PersonRole") = objServer.PersonRole
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
            Dim intId As String = ""
            hid_No.Value = ""
            If Not (Request("Id") Is Nothing) Then
                intId = Request("Id").ToString()
                hid_No.Value = intId
                txtsUserNo.ReadOnly = True
            End If
            'Bind Detail Data
            BindDetailData(objUser.UserId, intId)
            'Button Event
            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
            ' btnNew.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnNew.Attributes.Add("OnClick", "NewDetail(1);return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            'KeyDown Event
            txtsUserNo.Attributes.Add("OnKeyDown", "FocusControl(event,null," + txtsUserName.ClientID + ");")
            txtsUserName.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsUserNo.ClientID + "," + txtsPassword.ClientID + ");")
            txtsPassword.Attributes.Add("OnKeyDown", "FocusControl(event," + txtsUserName.ClientID + "," + txtPassword.ClientID + ");")
            'First Focus Control 
            txtsUserNo.Focus()
        End If
    End Sub

    Protected Sub gvwRoleInfo_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objServer.PersonRole.Count - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneRole(" + (e.Row.RowIndex + 1).ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objServer.PersonRole.Count - 1 Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedRole();return false;")
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objServer.PersonRole.ArrDetail.Count - 1 Then
                e.Row.Cells(0).Text = ""
            End If
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

        End If
    End Sub

End Class