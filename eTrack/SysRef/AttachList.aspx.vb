Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Text
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class AttachList
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objColumns As colColumn
    Private returnValue As String
    Private intTrxNo As Int64 = ConClass.NewIdValue
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
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
        Return New clsBooking(intUserId)
    End Function

    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function

#Region "Third Tab"
    Public Function GetNewBookingAttach() As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = GetNewId()
            BindAttach(objUser.UserId, hidId.Value, hidFolder.Value)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + intTrxNo.ToString()
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function AddSelectedAttach(ByVal strNo As String) As String
        Dim objUser As clsUser = Nothing
        Dim strSql As String
        Dim intResult As Integer
        Dim dtRec As DataTable
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            BindAttach(objUser.UserId, hidId.Value, hidFolder.Value)
            strSql = "Select AttachmentFlag from " + hidFolder.Value + " Where TrxNo=" & intTrxNo.ToString & ""
            dtRec = BaseSelectSrvr.GetData(strSql, "")
            If dtRec.Rows.Count > 0 Then
                strSql = "Update " + hidFolder.Value + " set AttachmentFlag='Y' Where TrxNo=" + intTrxNo.ToString + ""
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If intResult > 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach)
                End If
            Else
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function DeleteOneAttach(ByVal strNo As String, ByVal strFileName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strSql As String
        Dim intResult As Integer
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            Dim strAttachPath As String = Server.MapPath("../Doc/" + hidFolder.Value + "/" + intTrxNo.ToString() + "/")
            'special word
            If strFileName.IndexOf("%26") Then
                strFileName = strFileName.Replace("%26", "&")
            End If
            If strFileName.IndexOf("%2B") Then
                strFileName = strFileName.Replace("%2B", "+")
            End If
            If strFileName.IndexOf("%3D") Then
                strFileName = strFileName.Replace("%3D", "=")
            End If

            If strFileName.IndexOf("%25") Then
                strFileName = strFileName.Replace("%25", "%")
            End If
            If strFileName.IndexOf("%23") Then
                strFileName = strFileName.Replace("%23", "#")
            End If
            If clsAttachFileDirectory.DeleteFile(strAttachPath + Server.HtmlDecode(strFileName)) Then
                BindAttach(objUser.UserId, hidId.Value, hidFolder.Value)
                gvwAttach.DataSource = objAttach.ArrProp
                If objAttach.ArrProp.Count > 1 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
                    strSql = "Update " + hidFolder.Value + " set AttachmentFlag='N' Where TrxNo=" + intTrxNo.ToString + ""
                    intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "N" + ConSeparator.Par + "N"
                End If
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Sub BindAttach(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal strFolder As String)
        objAttach = New clsAttach(intUserId, intTrxNo)
        objAttach.GetListInfo(Server.MapPath("../Doc/" + strFolder + "/" + intTrxNo.ToString() + "/"), strFolder)
        gvwAttach.DataSource = objAttach.ArrProp
        gvwAttach.DataBind()
    End Sub
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If Session("LoginType") = 0 Then
            e.Row.Cells(0).Style.Add("display", "none")
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim tmpAttach As clsPropAttach = CType(objAttach.ArrProp(e.Row.RowIndex), clsPropAttach)
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objAttach.Count - 1 Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneAttach(""" + Server.HtmlEncode(tmpAttach.FileName) + """);return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            'imgInsert.Visible = False
            If e.Row.RowIndex = objAttach.Count - 1 Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedAttach();return false;")
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            Else
                imgInsert.Visible = False
            End If
        End If
    End Sub
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            hidId.Value = -1
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                hidId.Value = intTrxNo
            End If
            If Not (Request("Folder") Is Nothing) Then
                hidFolder.Value = Request("Folder").ToString()
            End If
            If Not (Request("Title") Is Nothing) Then
                Me.Title = Request("Title").ToString()
            End If
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            '090325.net836
            BindAttach(objUser.UserId, intTrxNo, hidFolder.Value)
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "", "<script language='javascript'>var TabNo=1;</script>")
        End If
    End Sub
#End Region
End Class