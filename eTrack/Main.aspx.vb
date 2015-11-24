Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.IO
Imports SysMagic

Partial Public Class Main
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
                Try
                    Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, arrObject))
                Catch ex As Exception
                    Return "0"
                End Try
        End Select
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub
    Private Const ImagePath As String = "Images/Menu/"
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    Public Function HandleLogout() As String
        Try
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return ""
            End If
        Catch ex As Exception
            Response.Write("<script>window.close();alert('You haven\'t log on yet or your session has time out, please log on again.');window.open('loading.aspx?tourl=Default.aspx','_parent');</script>")
        End Try
        Session.RemoveAll()
        Return ""
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
            lblUserName.Text = objUser.UserName
            If Session("LoginType") = 0 Or Session("LoginType") = 3 Then '20151111
                divForm.InnerHtml = AddMenuCustomer()
            ElseIf Session("LoginType") = 2 Then
                Select Case objUser.LoginType.ToUpper
                    Case "OA"
                        divForm.InnerHtml = AddMenuHardCode()
                    Case "WH"
                        divForm.InnerHtml = AddMenuHardCode()
                    Case Else
                        divForm.InnerHtml = AddMenuCustomer()
                End Select
            Else
                divForm.InnerHtml = AddMenuList()
            End If
            btnHelp.Attributes.Add("OnMouseDown", "ImgMouseDown1(" + btnHelp.ClientID + ",3)")
            btnRelogin.Attributes.Add("OnMouseDown", "ImgMouseDown1(" + btnRelogin.ClientID + ",4)")
            btnExit.Attributes.Add("OnMouseDown", "ImgMouseDown1(" + btnExit.ClientID + ",5)")
            HandleLanguageRelative()
        End If
    End Sub
    Private Sub HandleLanguageRelative()
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageRelativeFunction())
    End Sub
    Private Function GetJavascriptLanguageRelativeFunction() As String
        'Const
        Dim strPrefix As String = "<script language =""javascript"" type=""text/javascript"">"
        Dim strPostfix As String = "</script>"
        Dim strReturn As String = ControlChars.NewLine
        'Add javascript prefix to result
        Dim strResult As String = strPrefix
        'Add Logout Const
        strResult = strResult + strReturn + "var ConfirmLogout=""" + ZZMessage.ConMsgInfo.ConfirmLogout + """;"
        'Add Exit System Const
        strResult = strResult + strReturn + "var ConfirmExitSystem=""" + ZZMessage.ConMsgInfo.ConfirmExitSystem + """;"
        'Add javascript postfix to result
        strResult = strResult + strReturn + strPostfix
        Return strResult
    End Function
#Region "Internation Login"
    Private Function AddSubMenuList(ByVal ArrFun As ArrayList, ByVal ParentNo As String, ByRef objUser As clsUser, ByVal strFunNo As String) As String
        Dim strReturn As String = ""
        For j As Integer = 0 To ArrFun.Count - 1
            Dim dt As DataTable
            Dim strWhere As String = ""
            If objUser.RoleName.IndexOf("admin") = -1 Or objUser.RoleName.IndexOf("administrator") > -1 Then
                strWhere = "and isnull(UserFlag,'Y')='Y'"
            End If
            Dim strSql As String = String.Format("select * from FunctionInfo where sParentNo='{0}' {1} order by lType ", ParentNo, strWhere)
            dt = BaseSelectSrvr.GetData(strSql, "")
            '判断VesselSchedule 显示
            '    Dim dr As DataRow() = dt.Select("sFunNo in ('0101','0107')")
            For k As Integer = 0 To dt.Rows.Count - 1
                Dim strId As String = dt.Rows(k)("sFunNo")
                Dim strText As String = dt.Rows(k)("sFunName")

                'If dr.Length = 2 Then
                '    If strId = "0101" Then
                '        strText = "Vessel Schedule(rcvy1)"
                '    ElseIf strId = "0107" Then
                '        strText = "Vessel Schedule(sebl1)"
                '    End If
                'End If
                'subString Item
                If strText.Length > 25 Then
                    strText = strText.Substring(0, 25) + "......"
                End If

                Dim strFunUrl As String = dt.Rows(k)("sFunUrl")
            
                If strFunNo.IndexOf(strId) >= 0 Then
                    'If strId = "0301" Then
                    If strId.Length = 2 Then
                        Dim dtNode As DataTable
                        strSql = String.Format("select * from FunctionInfo where sParentNo='{0}' {1} order by lType ", strId, strWhere)
                        dtNode = BaseSelectSrvr.GetData(strSql, "")
                        Dim strHtml As String = ""

                        For i As Integer = 0 To dtNode.Rows.Count - 1
                            Dim strUrl As String = ""
                            Dim strNodeId As String = dtNode.Rows(i)("sFunNo")
                            Dim strNodeText As String = dtNode.Rows(i)("sFunName")
                            If strNodeText.Length > 20 Then
                                strNodeText = strNodeText.Substring(0, 20) + "..."
                            End If
                            If dtNode.Rows(i)("sFunUrl") = "" Then
                                strUrl = "about:blank"
                            Else
                                strUrl = dtNode.Rows(i)("sFunUrl").ToString
                                If strUrl.IndexOf("?") > 0 Then
                                    strUrl = PageFun.GetWaitingPage(strUrl + "&FunNo=" + strNodeId, 0)
                                Else
                                    strUrl = PageFun.GetWaitingPage(strUrl + "?FunNo=" + strNodeId, 0)
                                End If
                            End If

                            strHtml += "<h2><img class=""imgNode"" src=""Images/Menu/Node.gif""/><a id=""" + strNodeId + """ href=""javascript:void(0)"" onclick=""addTab('" + strNodeText + "','" + strUrl.Trim + "');return false;""  class=""textNode"">" + strNodeText + "</a></h2>"
                        Next

                        If strHtml <> "" Then
                            ' strReturn += "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/><ul><a id=""" + strId + """ href=""javascript:void(0)"" onclick=""addTab('" + strText + "','" + strUrl.Trim + "');return false;""  class=""textNode"">" + strText + "</a>" + strHtml + "</ul></p>"
                            ' strReturn += "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/><ul>" + strText + strHtml + "</ul></p>"
                            strReturn += "<div class=""toggle"">"
                            strReturn += " <dl>"
                            strReturn += "<dt><img class=""imgNode"" src=""Images/Menu/Node.gif""/><a href=""javascript:void(0)"" onclick=""return false;"" >" + strText + "</a></dt>"
                            strReturn += " <dd style=""margin-left:10px"">"
                            strReturn += strHtml
                            strReturn += "</dd>"
                            strReturn += "</dl>"
                            strReturn += " </div>"
                        End If
                    Else

                        Dim strUrl As String = ""
                        If dt.Rows(k)("sFunUrl") = "" Then
                            strUrl = "about:blank"
                        Else
                            strUrl = dt.Rows(k)("sFunUrl").ToString
                            If strUrl.IndexOf("?") > 0 Then
                                strUrl = PageFun.GetWaitingPage(strUrl + "&FunNo=" + strId, 0)
                            Else
                                strUrl = PageFun.GetWaitingPage(strUrl + "?FunNo=" + strId, 0)
                            End If
                        End If
                        strReturn += "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/><a id=""" + strId + """ href=""javascript:void(0)"" onclick=""addTab('" + strText + "','" + strUrl.Trim + "');return false;""  class=""textNode"">" + strText + "</a></p>"
                        'End If
                    End If
                End If
            Next
            Return strReturn
            'End If
        Next
        Return strReturn
    End Function
    Private Function AddMenuList() As String
        Dim strReturn As String = ""
        Dim objSysMenu As New clsSysMenu()
        Dim objFunMenu As New clsFunMenu()
        Dim objUser As clsUser = DirectCast(Session(ConSessionName.UserInfo), clsUser)
        Dim dtMenu As DataTable
        Dim strWhere As String = ""
        Dim strSql As String = ""
        If objUser.RoleName.IndexOf("admin") = -1 Then
            strWhere = " and lUserId='" + objUser.UserId + "'"
            strSql = "select * from FunctionInfo " & _
            " where sFunNo " & _
            " in(select distinct (select sParentNo from FunctionInfo where sFunNo=a.sFunNo ) sParentNo " & _
            " from PowerLevel a " & _
            " where lRoleId in (select lRoleId from RolePerson where 1=1 " + strWhere + "))" & _
            " order by lType"
        ElseIf objUser.RoleName.IndexOf("administrator") > -1 Then
            strWhere = " and isnull(UserFlag,'Y')='Y' "
            strSql = "select * from FunctionInfo " & _
            " where sFunNo " & _
            " in(select distinct (select sParentNo from FunctionInfo where sFunNo=a.sFunNo " + strWhere + " ) sParentNo from PowerLevel a " & _
            " )" & _
            " order by lType"
        Else
            strSql = "select * from FunctionInfo " & _
            " where sFunNo " & _
            " in(select distinct sParentNo from FunctionInfo " & _
            " ) and sParentNo='00'" & _
            " order by lType"
        End If
        dtMenu = BaseSelectSrvr.GetData(strSql, "")
        '" in(select distinct (select sParentNo from FunctionInfo where sFunNo=a.sFunNo) sParentNo from PowerLevel a " & _
        '---------------------------------------------------------------------------------------------------------------------------------------
        'get user Right
        Dim dt1 As DataTable
        If objUser.RoleName.IndexOf("admin") = -1 Then
            strSql = "select distinct sFunNo from PowerLevel " & _
                        "where lRoleId in (select lRoleId from RolePerson where 1=1 " + strWhere + ")"
        Else
            strSql = "select distinct sFunNo from FunctionInfo where sParentNo!='00' "
        End If

        dt1 = BaseSelectSrvr.GetData(strSql, "")
        Dim strFunNo As String = ""
        If dt1 IsNot Nothing Then
            For j As Integer = 0 To dt1.Rows.Count - 1
                If dt1.Rows(j)(0).ToString <> "" Then
                    strFunNo += dt1.Rows(j)(0).ToString + ","
                End If
            Next
        End If
        If strFunNo = "" Then
            Return ""
        End If
        'getDivTop
        Dim strShow As String = ""
        If objUser IsNot Nothing Then
            Dim ArrFun As New ArrayList ' = objFunMenu.GetPersonFunction(objUser.UserId)
            Dim sFunNo As String = ""
            Dim intHide As Integer = 0
            For i As Integer = 0 To dtMenu.Rows.Count - 1
                Dim strText As String = dtMenu.Rows(i)("sFunName")
                Dim strId As String = dtMenu.Rows(i)("sFunNo")
                sFunNo = strId
                Dim strDivId As String = "div" + strId
                Dim strImgId As String = "img" + strId
                ArrFun.Add(strId)
                Dim strSubFunctionHtml As String = AddSubMenuList(ArrFun, strId, objUser, strFunNo)
                strReturn = ""
                If sFunNo = "03" And strSubFunctionHtml <> "" Then
                    Dim strb As StringBuilder = New StringBuilder()
                    Dim sw As StringWriter = New StringWriter(strb)
                    Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
                    divTracking.RenderControl(htw)
                    strSubFunctionHtml = strb.ToString()
                    divTracking.Visible = False
                End If
                If strSubFunctionHtml <> "" Then
                    strReturn += "<div id=""" + strDivId + """ title=""" + strText + """ class=""divMenu"">"
                    strReturn += strSubFunctionHtml
                    strReturn += "</div>         "
                    'End If
                End If

                strShow += strReturn
            Next
        End If
        Return strShow
    End Function
#End Region
#Region "Customer Login"
    Private Function AddSubMenuCustomer(ByVal ArrFun As ArrayList, ByVal ParentNo As String, ByRef objUser As clsUser, ByVal strFunNo As String) As String
        Dim strReturn As String = ""
        For j As Integer = 0 To ArrFun.Count - 1
            Dim dt As DataTable
            Dim strWhere As String = ""
            If objUser.RoleName.IndexOf("admin") = -1 Or objUser.RoleName.Trim = "administrator" Then
                strWhere = "and isnull(UserFlag,'')!='N'"
            End If
            dt = BaseSelectSrvr.GetData("select * from FunctionInfo where sParentNo='" + ParentNo + "' " + strWhere + " order by lType ", "")
            '判断VesselSchedule 显示
            Dim dr As DataRow() = dt.Select("sFunNo in ('0101','0107')")
            For k As Integer = 0 To dt.Rows.Count - 1
                Dim strId As String = dt.Rows(k)("sFunNo")
                Dim strText As String = dt.Rows(k)("sFunName")
                If dr.Length = 2 Then
                    If strId = "0101" Then
                        strText = "Vessel Schedule(rcvy1)"
                    ElseIf strId = "0107" Then
                        strText = "Vessel Schedule(sebl1)"
                    End If
                End If
                'subString Item
                If strText.Length > 23 Then
                    strText = strText.Substring(0, 17) + "......"
                End If

                Dim strFunUrl As String = dt.Rows(k)("sFunUrl")
                If strFunNo.IndexOf(strId) >= 0 Then
                    'If strId = "0301" Then
                    Dim strUrl As String = ""
                    If dt.Rows(k)("sFunUrl") = "" Then
                        strUrl = "about:blank"
                    Else
                        strUrl = dt.Rows(k)("sFunUrl").ToString
                        If strUrl.IndexOf("?") > 0 Then
                            strUrl = PageFun.GetWaitingPage(strUrl + "&FunNo=" + strId, 0)
                        Else
                            strUrl = PageFun.GetWaitingPage(strUrl + "?FunNo=" + strId, 0)
                        End If
                    End If
                    strReturn += "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/><a id=""" + strId + """ href=""javascript:void(0)"" onclick=""addTab('" + strText + "','" + strUrl.Trim + "');return false;""  class=""textNode"">" + strText + "</a></p>"
                    'End If
                End If
            Next
            Return strReturn
            'End If
        Next
        Return strReturn
    End Function
    Private Function AddMenuCustomer() As String
        Dim strReturn As String = ""
        Dim objSysMenu As New clsSysMenu()
        Dim objFunMenu As New clsFunMenu()
        Dim objUser As clsUser = DirectCast(Session(ConSessionName.UserInfo), clsUser)
        Dim dtMenu As DataTable
        Dim strWhere As String = ""
        Dim strSql As String = ""
        strWhere = " and sRoleName='" + objUser.RoleName.Substring(0, objUser.RoleName.Length - 1) + "'"
        strSql = "select * from FunctionInfo " & _
        " where sFunNo " & _
        " in(select distinct (select sParentNo from FunctionInfo where sFunNo=a.sFunNo ) sParentNo " & _
        " from PowerLevel a " & _
        " where lRoleId in (select lId from RoleInfo where 1=1 " + strWhere + "))" & _
        " order by lType"
        dtMenu = BaseSelectSrvr.GetData(strSql, "")
        '" in(select distinct (select sParentNo from FunctionInfo where sFunNo=a.sFunNo) sParentNo from PowerLevel a " & _
        '---------------------------------------------------------------------------------------------------------------------------------------
        'get user Right
        Dim dt1 As DataTable
        strSql = "select distinct sFunNo from PowerLevel " & _
                    "where lRoleId in (select lId from RoleInfo where 1=1 " + strWhere + ")"
        dt1 = BaseSelectSrvr.GetData(strSql, "")
        Dim strFunNo As String = ""
        If dt1 IsNot Nothing Then
            For j As Integer = 0 To dt1.Rows.Count - 1
                If dt1.Rows(j)(0).ToString <> "" Then
                    strFunNo += dt1.Rows(j)(0).ToString + ","
                End If
            Next
        End If
        If strFunNo = "" Then
            Return ""
        End If
        'getDivTop
        Dim strShow As String = ""
        If objUser IsNot Nothing Then
            Dim ArrFun As New ArrayList ' = objFunMenu.GetPersonFunction(objUser.UserId)
            Dim sFunNo As String = ""
            Dim intHide As Integer = 0
            For i As Integer = 0 To dtMenu.Rows.Count - 1
                Dim strText As String = dtMenu.Rows(i)("sFunName")
                Dim strId As String = dtMenu.Rows(i)("sFunNo")
                sFunNo = strId
                Dim strDivId As String = "div" + strId
                Dim strImgId As String = "img" + strId
                ArrFun.Add(strId)
                Dim strSubFunctionHtml As String = AddSubMenuCustomer(ArrFun, strId, objUser, strFunNo)
                strReturn = ""
                If sFunNo = "03" And strSubFunctionHtml <> "" Then
                    Dim strb As StringBuilder = New StringBuilder()
                    Dim sw As StringWriter = New StringWriter(strb)
                    Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
                    divTracking.RenderControl(htw)
                    strSubFunctionHtml = strb.ToString()
                End If
                If strSubFunctionHtml <> "" Then
                    strReturn += "<div id=""" + strDivId + """ title=""" + strText + """ class=""divMenu"">"
                    strReturn += strSubFunctionHtml
                    strReturn += "</div>         "
                    'End If
                End If
                strShow += strReturn
            Next
        End If
        Return strShow
    End Function
    Private Function AddMenuHardCode() As String
        Dim strReturn As String = ""
        Dim objSysMenu As New clsSysMenu()
        Dim objFunMenu As New clsFunMenu()
        Dim objUser As clsUser = DirectCast(Session(ConSessionName.UserInfo), clsUser)
        Dim strWhere As String = ""
        Dim strSql As String = ""
        Select Case objUser.LoginType.ToUpper
            Case "OA"
                strReturn = "<div id=""div01"" title=""Customer Services"" class=""divMenu"">" & _
                            "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/>" & _
                            "<a id=""0103"" href=""javascript:void(0)"" onclick=""addTab('Job Tracking','loading.aspx?tourl=CustomerServices/Tracking.aspx?FunNo=0103'); " & _
                            "return false;""  class=""textNode"">Job Tracking</a></p></div>"
            Case "WH"
                strReturn = "<div id=""div01"" title=""Customer Services"" class=""divMenu"">" & _
                            "<p class=""divNode""><img class=""imgNode"" src=""Images/Menu/Node.gif""/>" & _
                            "<a id=""0103"" href=""javascript:void(0)"" onclick=""addTab('Job Tracking','loading.aspx?tourl=CustomerServices/Tracking.aspx?FunNo=0103'); " & _
                            "return false;""  class=""textNode"">Job Tracking</a></p></div>"
                'divForm.InnerHtml = AddMenuHardCode()
        End Select
        Return strReturn
    End Function
#End Region
End Class
