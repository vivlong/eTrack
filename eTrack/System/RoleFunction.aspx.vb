Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.IO
Imports SysMagic

Partial Class RoleFunction
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler

    Private Const strSessionName As String = "RoleFunction"
    Private objList As clsRoleFunction

    Private returnValue As String
    Private objUser As clsUser = Nothing

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

    Public Function SaveRoleFunction(ByVal strValue As String, ByVal valRoleInfo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ""
        Else
            Dim intRoleId As Integer = Integer.Parse(valRoleInfo)
            'New Object 
            objList = New clsRoleFunction(objUser.UserId, valRoleInfo, "")
            'Get Data 
            objList.GetRoleFunction(objUser.RoleName.Substring(0, objUser.RoleName.Length - 1).Trim)
            If objList Is Nothing Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If objList.ModifyCurrent(strValue) Then
                If objList.Save(strMsg) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            End If
        End If
    End Function

    Public Function SaveAdminFunction(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ""
        Else
            'New Object 
            objList = New clsRoleFunction(objUser.UserId, 0, "")
            'Get Data 
            objList.GetUserFlag()
            If objList Is Nothing Then
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
            End If
            If objList.ModifyAdminCurrent(strValue) Then
                If objList.SaveUserFlag(strMsg) Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strMsg
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
                End If
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            End If
        End If
    End Function

    Public Function SelectRoleFunction(ByVal strRoleId As String, ByVal strRoleName As String, ByVal strdiv As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intRoleId As Integer = Integer.Parse(strRoleId)
            drpRoleInfo.SelectedValue = intRoleId
            If hidType.Value = "1" AndAlso strdiv <> "3" Then
                BindAllSourceData("sa", 0, objUser.RoleName.Substring(0, objUser.RoleName.Length - 1).Trim)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSourceAdmin)
            Else
                BindSourceData(objUser.UserId, intRoleId, strRoleName)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Public Function SelectRoleForAdmin(ByVal selectId As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strRoleName As String = ""
            Dim RoleId As Integer = 0
            If selectId = "1" Then
                strRoleName = objUser.RoleName.Substring(0, objUser.RoleName.Length - 1).Trim
                'RoleId = 1001
                If drpRoleInfo.SelectedValue <> "" Then
                    RoleId = Integer.Parse(drpRoleInfo.SelectedValue)
                End If
                BindSourceData(objUser.UserId, RoleId, strRoleName)
                'BindAllSourceData(objUser.UserId, RoleId, strRoleName)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            Else
                strRoleName = "customer"
                RoleId = Integer.Parse(hidRoleId.Value)
                BindSourceData(objUser.UserId, RoleId, strRoleName)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Private Sub SetInitValue(ByVal objUser As clsUser)
        Dim objRole As New clsRoleInfoList()
        drpRoleInfo.DataSource = objRole.ListData(objUser.UserId, "", "")
        drpRoleInfo.DataTextField = "sRoleName"
        drpRoleInfo.DataValueField = "lId"
        drpRoleInfo.DataBind()
        ''
        Dim strSql As String = "select lId from RoleInfo where sRoleName='customer'"
        Try
            Dim dt As DataTable = BaseSelectSrvr.GetData(strSql, "")
            If dt IsNot Nothing Then
                hidRoleId.Value = dt.Rows(0)(0).ToString
            End If
        Catch ex As Exception
            hidRoleId.Value = ""
        End Try
        lblCustomer.Text = "Customer"
    End Sub

    Private Sub BindSourceData(ByVal UserNo As String, ByVal intRoleId As Integer, ByVal strRoleName As String)
        'New Object 
        objList = New clsRoleFunction(UserNo, intRoleId, strRoleName)
        'Get Data 
        objList.GetRoleFunction(strRoleName)
        'Bind Data 
        gvwSource.DataSource = objList.ArrRoleFunction
        gvwSource.AllowPaging = False
        gvwSource.DataBind()
    End Sub
    'by Bind all Data 
    Private Sub BindAllSourceData(ByVal UserNo As String, ByVal intRoleId As Integer, ByVal strRoleName As String)
        'New Object 
        objList = New clsRoleFunction(UserNo, intRoleId, strRoleName)
        'Get Data 
        objList.GetRoleFunction(strRoleName)
        'Bind Data 
        gvwSourceAdmin.DataSource = objList.ArrRoleFunction
        gvwSourceAdmin.AllowPaging = False
        gvwSourceAdmin.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Judge Login or not
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            'Set Default Value
            SetInitValue(objUser)
            If objUser.RoleName.Substring(0, IIf(objUser.RoleName.ToString = "", 0, objUser.RoleName.Length - 1)).Trim <> "admin" Then
                'From Role Info 
                If Not (Request("Id") Is Nothing) Then
                    drpRoleInfo.SelectedValue = Request("Id").ToString()
                    drpRoleInfo.Visible = False
                    btnBack.Visible = True
                    lblRoleName.Visible = True
                    lblRoleName.Text = drpRoleInfo.SelectedItem.Text
                End If
                Dim intRoleId As Integer = 0
                If drpRoleInfo.SelectedValue <> "" Then
                    intRoleId = Integer.Parse(drpRoleInfo.SelectedValue)
                End If
                'Bind Data
                If drpRoleInfo.SelectedItem IsNot Nothing Then
                    BindSourceData(objUser.UserId, intRoleId, drpRoleInfo.SelectedItem.Text)
                End If
                'New Role Function 
                drpRoleInfo.Attributes.Add("OnChange", "SelectRoleFunction(" + drpRoleInfo.ClientID + ");return false;")
                'Button event
                btnOk.Attributes.Add("OnClick", "SaveRoleFunction();return false;")
            Else
                divSearch.Style.Add("display", "none")
                drpRoleInfo.Attributes.Add("OnChange", "SelectRoleFunction(" + drpRoleInfo.ClientID + ");return false;")
                BindAllSourceData("sa", 0, objUser.RoleName.Substring(0, objUser.RoleName.Length - 1).Trim)
                btnOk.Attributes.Add("OnClick", "SaveAdminFunction();return false;")
            End If
            If objUser.UserId = "sa" Or objUser.RoleName.Substring(0, IIf(objUser.RoleName.ToString = "", 0, objUser.RoleName.Length - 1)).Trim = "admin" Then
                'lblCustomerLogin.Style.Add("display", "none")
                'lblTitle.Attributes.Add("onclick", "return false;")
                hidType.Value = "1"
            Else
                lblTitle2.Style.Add("display", "none")
                hidType.Value = "0"
            End If
            btnBack.Attributes.Add("OnClick", "history.back();return false")
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim tmpSelect As HtmlInputCheckBox = CType(e.Row.FindControl("chkSelect"), HtmlInputCheckBox)
                tmpSelect.Attributes.Add("OnClick", "SelectAllSubFunction()")
                Dim tmpSubFun As ArrayList = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).SubFun
                'add by lzw 100201>>>
                Dim strFunNo As String = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).FunNo
                Dim strUserFlag As String = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).UserFlag
                Dim strSubType As String = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).SubType
                If strFunNo.Length = 2 Then
                    e.Row.Cells(0).ColumnSpan = 3
                    tmpSelect.Attributes.Add("OnClick", "return false;")
                    tmpSelect.Style.Add("display", "none")
                    Dim tb As New Label
                    tb.Text = e.Row.Cells(1).Text
                    tb.Width = 300
                    tb.CssClass = "Cell1"
                    e.Row.Cells(0).Style.Add("text-align", "left")
                    e.Row.Cells(0).Controls.Add(tb)
                    e.Row.Cells(1).Visible = False
                    e.Row.Cells(2).Visible = False
                End If
                If Integer.Parse(strFunNo) > 1500 Then
                    Dim tb As New Label
                    tb.Font.Bold = True
                    tb.Text = e.Row.Cells(1).Text
                    e.Row.Cells(1).Controls.Clear()
                    e.Row.Cells(1).Controls.Add(tb)
                End If
                '<<<
                Dim j As Integer = 0
                Dim i As Integer
                'Dim div As HtmlGenericControl = New HtmlGenericControl("Div")
                'Dim br As HtmlGenericControl = New HtmlGenericControl("br")

                'div.InnerHtml = "&nbsp;"
                'div.InnerText = "<br>"
                For i = 0 To tmpSubFun.Count - 1
                    Dim tmpCkbx As CheckBox = CType(e.Row.FindControl("chkFun" + i.ToString()), CheckBox)
                    If Not (tmpCkbx Is Nothing) Then
                        tmpCkbx.Text = CType(tmpSubFun(i), clsPropSubFun).Name
                        tmpCkbx.Checked = CType(tmpSubFun(i), clsPropSubFun).Flag
                        'tmpLiter = tmpCkbx.Parent.Controls(tmpCkbx.Parent.Controls.IndexOf(tmpCkbx) + 1)
                        'tmpLiter.Controls.Add(br)
                        If i < (tmpSubFun.Count - 1) Then
                            e.Row.Cells(2).Controls.AddAt(e.Row.Cells(2).Controls.IndexOf(tmpCkbx) + 1, New BR)

                        End If
                        If tmpCkbx.Checked = True Then
                            j += 1
                        End If

                    End If
                    Dim SubType As String = CType(tmpSubFun(i), clsPropSubFun).SubType
                    Dim tmpTxt As TextBox = CType(e.Row.FindControl("txtCondition" + i.ToString()), TextBox)
                    If Not (tmpTxt Is Nothing) Then
                        If SubType = "T" Then
                            tmpTxt.Text = CType(tmpSubFun(i), clsPropSubFun).ViewCondition
                            ' tmpCkbx.Parent.Controls.AddAt(tmpTxt.Parent.Controls.IndexOf(tmpTxt) + 1, brCtr)
                        Else
                            tmpTxt.Visible = False
                            Dim ind As Integer = e.Row.Cells(3).Controls.IndexOf(tmpTxt)
                            If i < (tmpSubFun.Count - 1) Then
                                Dim div As HtmlGenericControl = New HtmlGenericControl("Div")
                                div.InnerHtml = "&nbsp;"
                                e.Row.Cells(3).Controls.AddAt(ind + 1, New BR)
                            End If
                            'e.Row.Cells(3).Controls.Add(br)
                            '  tmpTxt.Parent.Controls.AddAt(tmpTxt.Parent.Controls.IndexOf(tmpTxt), br)
                        End If
                    End If
                Next i
                If j > 0 Then
                    tmpSelect.Checked = True
                End If
                For i = tmpSubFun.Count To 16
                    Dim tmpCkbx As CheckBox = e.Row.FindControl(("chkFun" + i.ToString()))
                    If Not (tmpCkbx Is Nothing) Then
                        tmpCkbx.Visible = False
                    End If
                Next i
                For i = tmpSubFun.Count To 5
                    Dim tmpTxt As TextBox = e.Row.FindControl(("txtCondition" + i.ToString()))
                    If Not (tmpTxt Is Nothing) Then
                        tmpTxt.Visible = False
                    End If
                Next i
            End If
        End If
    End Sub

    Public Function UpdateUserFlag(ByVal UserFlag As String, ByVal FunNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ""
        Else
            Try
                Dim strSql As String = "Update FunctionInfo set UserFlag='" + UserFlag + "' where sFunNo='" + FunNo + "'"
                Dim intResult As String = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + UserFlag
                Else
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + UserFlag
                End If
            Catch ex As Exception
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + UserFlag
            End Try
        End If
    End Function

    Protected Sub gvwSourceAdmin_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvwSourceAdmin.RowDataBound
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim tmpSelect As HtmlInputCheckBox = CType(e.Row.FindControl("chkSelect"), HtmlInputCheckBox)
                tmpSelect.Attributes.Add("OnClick", "SelectUserFlag()")
                Dim tmpSubFun As ArrayList = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).SubFun
                'add by lzw 100201>>>
                Dim strFunNo As String = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).FunNo
                Dim strUserFlag As String = CType(objList.ArrRoleFunction(e.Row.RowIndex), clsPropRoleFuntion).UserFlag
                If strUserFlag = "Y" Then
                    tmpSelect.Checked = True
                Else
                    tmpSelect.Checked = False
                End If
                If strFunNo.Length = 2 Then
                    e.Row.Cells(0).ColumnSpan = 3
                    tmpSelect.Attributes.Add("OnClick", "return false;")
                    tmpSelect.Style.Add("display", "none")
                    Dim tb As New Label
                    tb.Text = e.Row.Cells(1).Text
                    tb.Width = 200
                    tb.CssClass = "Cell1"
                    e.Row.Cells(0).Style.Add("text-align", "left")
                    e.Row.Cells(0).Controls.Add(tb)
                    e.Row.Cells(1).Visible = False
                End If
                If Integer.Parse(strFunNo) > 1500 Then
                    Dim tb As New Label
                    tb.Font.Bold = True
                    tb.Text = e.Row.Cells(1).Text
                    e.Row.Cells(1).Controls.Clear()
                    e.Row.Cells(1).Controls.Add(tb)
                End If
            End If
            If objUser.RoleName.IndexOf("admin") = -1 Then
                e.Row.Cells(3).Visible = False
            End If
        End If
    End Sub
End Class
Class BR
    Inherits Control
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        writer.Write("<br />")
    End Sub
End Class