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
Imports System.Xml
Imports System.Reflection
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class SeaFreightEdit
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsSeaFreight
    Private objColumns As colColumn
    Private objList As clsJobStatus
    Private returnValue As String
    Private docPath As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingPath")
    '   Private docUrl As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingURL")

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
        Return New clsSeaFreight(intUserId)
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

    Public Function GetJobStatus() As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            Dim strJobNo As String = ""
            If Not (Request("JobNo") Is Nothing) Then
                strJobNo = Request("JobNo").ToString()
            End If
            If BindSourceData(objUser.UserId, strJobNo) Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg
            End If
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Protected Function BindSourceData(ByVal intUserId As String, ByVal strJobNo As String) As Boolean
        objList = New clsJobStatus(intUserId)
        objList.Where = SqlRelation.GetStringWhere("a.JobNo", strJobNo, 1)
        Dim strDBName As String = ""
        If Not (Request("DB") Is Nothing) Then
            strDBName = Request("DB").ToString()
        End If
        objList.OrderBy = strDBName
        Dim dtTmp As DataTable = objList.GetAllList()
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile("JobStatus", gvwSource, TemplateType.None)
        gvwSource.DataSource = dtTmp
        gvwSource.DataBind()
        Return True
    End Function

    Private Sub BindDetailData(ByVal intUserId As String, ByVal strJobNo As String, ByVal strModule As String, ByVal strDBName As String)
        objServer = NewServerObject(intUserId)
        If strJobNo <> "" Then
            Dim tmpProp As clsPropSeaFreight = objServer.GetDetail(strJobNo + ConSeparator.Col + strModule + ConSeparator.Col + strDBName)
            fldId.Value = tmpProp.JobNo
            txtJobNo.Text = tmpProp.JobNo
            txtRefNo.Text = tmpProp.ReferenceNo
            txtAWBBlNo.Text = tmpProp.AWBBlNo
            txtMawbOBLNo.Text = tmpProp.MawbOBLNo
            txtLoadPort.Text = tmpProp.PortofLoadingName
            txtDischargePort.Text = tmpProp.PortofDischargeName
            txtDirectVessel.Text = tmpProp.VesselName + " " + tmpProp.VoyageNo
            txtMotherVessel.Text = tmpProp.FeederVesselName + " " + tmpProp.FeederVoyage
            If tmpProp.ETD > ConDateTime.MinDate Then
                txtETD.Text = tmpProp.ETD.ToString(ConDateTime.DateFormat)
            Else
                txtETD.Text = ""
            End If
            If tmpProp.ETA > ConDateTime.MinDate Then
                txtETA.Text = tmpProp.ETA.ToString(ConDateTime.DateFormat)
            Else
                txtETA.Text = ""
            End If
            txtCommodity.Text = tmpProp.Commodity
            If tmpProp.Pcs = 0 Then
                txtPcs.Text = ""
            Else
                txtPcs.Text = tmpProp.Pcs.ToString(ConNumeric.IntegerFormat)
            End If
            If tmpProp.GrossWeight = 0 Then
                txtGross.Text = ""
            Else
                txtGross.Text = tmpProp.GrossWeight.ToString(ConNumeric.NormalFormat)
            End If
            If tmpProp.Volume = 0 Then
                txtVolume.Text = ""
            Else
                txtVolume.Text = tmpProp.Volume.ToString(ConNumeric.NormalFormat)
            End If
            If tmpProp.Noof20FtContainer = 0 Then
                txtFt20.Text = ""
            Else
                txtFt20.Text = tmpProp.Noof20FtContainer.ToString(ConNumeric.IntegerFormat)
            End If
            If tmpProp.Noof40FtContainer = 0 Then
                txtFt40.Text = ""
            Else
                txtFt40.Text = tmpProp.Noof40FtContainer.ToString(ConNumeric.IntegerFormat)
            End If
            If tmpProp.Noof45FtContainer = 0 Then
                txtFt45.Text = ""
            Else
                txtFt45.Text = tmpProp.Noof45FtContainer.ToString(ConNumeric.IntegerFormat)
            End If
            txtContainerNo.Text = tmpProp.ContainerNo

            'sclee 220140619
            If strModule = "SI" Then
                txtTelexReleaseFlag.Text = ""
                txtConnVessel.Text = tmpProp.ConnectingVesselName
                If tmpProp.ConnectingETA > ConDateTime.MinDate Then
                    txtConnETA.Text = tmpProp.ConnectingETA.ToString(ConDateTime.DateFormat)
                Else
                    txtConnETA.Text = ""
                End If
                If tmpProp.ConnectingETD > ConDateTime.MinDate Then
                    txtConnETD.Text = tmpProp.ConnectingETD.ToString(ConDateTime.DateFormat)
                Else
                    txtConnETD.Text = ""
                End If

            ElseIf strModule = "SE" Then
                txtTelexReleaseFlag.Text = tmpProp.TelexReleaseFlag
                txtConnETA.Text = ""
                txtConnETD.Text = ""
                txtConnVessel.Text = ""
            End If



        Else
            fldId.Value = ""
            txtJobNo.Text = ""
            txtRefNo.Text = ""
            txtAWBBlNo.Text = ""
            txtMawbOBLNo.Text = ""
            txtLoadPort.Text = ""
            txtDischargePort.Text = ""
            txtDirectVessel.Text = ""
            txtMotherVessel.Text = ""
            txtETD.Text = ""
            txtETA.Text = ""
            txtCommodity.Text = ""
            txtPcs.Text = ""
            txtGross.Text = ""
            txtVolume.Text = ""
            txtFt20.Text = ""
            txtFt40.Text = ""
            txtFt45.Text = ""
            txtContainerNo.Text = ""
            txtTelexReleaseFlag.Text = ""
            txtConnETA.Text = ""
            txtConnETD.Text = ""
            txtConnVessel.Text = ""
        End If
            'Repair Detail
            BindSourceData(intUserId, strJobNo)
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Session("LoginType") = 3 Then
                '' this part for just directly search so dont need check user ... Add it by Jackie 080904
            Else
                If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                    Return
                End If
            End If
            Dim strJobNo As String = ""
            If Not (Request("JobNo") Is Nothing) Then
                strJobNo = Request("JobNo").ToString()
                Head1.Title = "SEA FREIGHT-" + strJobNo
            End If
            Dim strModule As String = ""
            If Not (Request("Module") Is Nothing) Then
                strModule = Request("Module").ToString()
            End If
            Dim strDBName As String = ""
            If Not (Request("DB") Is Nothing) Then
                strDBName = Request("DB").ToString()
            End If
            If Session("LoginType") = 3 Then
                'Set Default Value
                SetInitValue(3)
                'Bind Detail Data
                BindDetailData(3, strJobNo, strModule, strDBName)
            ElseIf Session("LoginType") = 2 Then 'sclee 20140625 
                'Set Default Value
                SetInitValue(objUser.UserId)
                'Bind Detail Data
                BindDetailData(objUser.UserId, strJobNo, strModule, strDBName)

                If objUser.LoginType.ToUpper = "OA" And strModule = "SE" Then
                    btnAdd.Visible = True
                ElseIf objUser.LoginType.ToUpper = "WH" Then
                    btnAdd.Visible = True
                End If

            Else
                'Set Default Value
                SetInitValue(objUser.UserId)
                'Bind Detail Data
                BindDetailData(objUser.UserId, strJobNo, strModule, strDBName)
            End If
            If Request("Type") Is Nothing OrElse Request("Type").ToString() = "" Then
                'Button Event
                ' btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
                ' btnNew.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
                btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
                btnSave.Style.Add("display", "none")
                btnNew.Style.Add("display", "none")
                btnAdd.Style.Add("display", "none")
                'KeyDown Event
            ElseIf Request("Type").ToString() = "Query" Then
                'Button Event
                btnSave.Style.Add("display", "none")
                btnNew.Style.Add("display", "none")
                btnClose.Attributes.Add("OnClick", "window.close();return false;")
                If objList Is Nothing OrElse Not objList.IsCanUpdate Then
                    btnAdd.Style.Add("display", "none")
                End If
                btnAdd.Attributes.Add("OnClick", "AddStatus();return false;")
                'Readonly
                txtJobNo.ReadOnly = True
                txtRefNo.ReadOnly = True
                txtAWBBlNo.ReadOnly = True
                txtMawbOBLNo.ReadOnly = True
                txtLoadPort.ReadOnly = True
                txtDischargePort.ReadOnly = True
                txtDirectVessel.ReadOnly = True
                txtMotherVessel.ReadOnly = True
                txtETD.ReadOnly = True
                txtETA.ReadOnly = True
                txtCommodity.ReadOnly = True
                txtPcs.ReadOnly = True
                txtGross.ReadOnly = True
                txtVolume.ReadOnly = True
                txtFt20.ReadOnly = True
                txtFt40.ReadOnly = True
                txtFt45.ReadOnly = True
                txtContainerNo.ReadOnly = True
                txtConnETA.ReadOnly = True
                txtConnETD.ReadOnly = True
                txtConnVessel.ReadOnly = True
                txtTelexReleaseFlag.ReadOnly = True
            Else
                'Button Event
                btnSave.Style.Add("display", "none")
                btnNew.Style.Add("display", "none")
                btnAdd.Style.Add("display", "none")
                btnClose.Attributes.Add("OnClick", "window.close();return false;")
            End If
            If Session("LoginType") = 3 Then
                btnPrint.Style.Add("display", "none")
                btnClose.Attributes.Add("OnClick", "window.close();return false;")
            Else
                btnPrint.Attributes.Add("OnClick", "self.print();return false;")
            End If
            'bylzw081224
            If objUser Is Nothing Then
                BindAttach(-1, 0)
            Else
                BindAttach(objUser.UserId, 0)
            End If
        End If
    End Sub
    'bylzw081224
    Public Function AddSelectedDownloadAttach1(ByVal strNo As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim intTrxNo As Int64 = Int64.Parse(strNo)
            BindAttach(objUser.UserId, 1)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach)
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
            '   Dim intTrxNo As Int64 = Int64.Parse(strNo)
            BindAttach(objUser.UserId, 0)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Public Function DeleteOneAttach(ByVal strNo As String, ByVal strFileName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strSql As String
        Dim intResult As Integer
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            ' Dim intTrxNo As Int64 = Int64.Parse(strNo)

            strNo = Request("JobNo").ToString()
            strNo = strNo.Replace("/", "-")

            Dim strAttachPath As String = docPath + strNo + "\"
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
                BindAttach(objUser.UserId, 0)
                gvwAttach.DataSource = objServer.ArrProp
                If objServer.ArrProp.Count > 1 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "Y" + ConSeparator.Par + "Y"
                Else
                    'strSql = "Update omtx1 set AttachmentFlag='N' Where TrxNo=" + intTrxNo.ToString + ""
                    'intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwAttach) + ConSeparator.Par + "N" + ConSeparator.Par + "N"
                End If
            Else
                Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ""
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    'bylzw081224
    Private Sub BindAttach(ByVal intUserId As String, Optional ByVal intNum As Integer = 0)
        If intNum = 0 Then
            ''Specitication
            Dim strJobNo As String = ""
            If Not (Request("JobNo") Is Nothing) Then
                strJobNo = Request("JobNo").ToString()
                strJobNo = strJobNo.Replace("/", "-")
            End If
            objServer = New clsSeaFreight(intUserId)
            ' objServer.GetListInfo(Server.MapPath("..\Doc\" + strJobNo + "\"), "..\Doc\" + strJobNo + "\")
            '   objServer.GetListInfo("c:\Doc\", "http://" + Server.UrlDecod + "/Doc/")
            '  objServer.GetListInfo(docPath + strJobNo + "\", docUrl + strJobNo + "\")
            objServer.GetListInfo(docPath + strJobNo + "\", "../SysRef/DownLoad.aspx?file=" + strJobNo + "/")

            'objServer.GetListInfo(Server.MapPath("C:\doc\"), "C:\doc\")
            '   objServer.GetListInfo("C:\doc\", "C:\doc\")

            gvwAttach.DataSource = objServer.ArrProp
            gvwAttach.DataBind()
        End If
     
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
    End Sub
    'bylzw081224
    'add by danny
    Public Function GetCurrentUserInfo(ByVal pgCurrent As Page, ByRef objUser As clsUser) As Boolean
        Dim strPage As String = pgCurrent.Request.RawUrl
        If HttpContext.Current.Session(ConSessionName.UserInfo) Is Nothing Then
            ' pgCurrent.Response.Redirect(("../Default.aspx?Redirect=" + strPage))
            'pgCurrent.Response.Redirect(("Default.aspx?Redirect=" + strPage))
            Return False
        Else
            objUser = CType(HttpContext.Current.Session(ConSessionName.UserInfo), clsUser)
            HttpContext.Current.Session(ConSessionName.UserInfo) = objUser
            Return True
        End If
    End Function
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim objUser As clsUser = Nothing
        Dim UserLogin As Boolean = GetCurrentUserInfo(Page, objUser)
        ' Exit Sub
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes.Add("OnClick", "DownloadAttachment(""div1"");return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If e.Row.RowIndex < objServer.ArrProp.Count - 1 And UserLogin = True Then
                imgDelete.Attributes.Add("OnClick", "DeleteOneAttach(""" + Server.HtmlEncode(objServer.ArrProp(e.Row.RowIndex).FileName) + """);return false;")
            Else
                imgDelete.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If e.Row.RowIndex = objServer.ArrProp.Count - 1 And UserLogin = True Then
                imgInsert.Attributes.Add("OnClick", "AddSelectedAttach();return false;")
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            Else
                'e.Row.Cells(0).Text = ""
                'e.Row.Cells(1).Text = ""
                'e.Row.Cells(2).Text = ""
                'e.Row.Cells(3).Text = ""
                'e.Row.Cells(4).Text = ""
                imgInsert.Visible = False
            End If
        End If
        If UserLogin = False Then
            If e.Row.RowIndex = objServer.ArrProp.Count - 1 Then
                e.Row.Cells(0).Text = ""
                e.Row.Cells(1).Text = ""
                e.Row.Cells(2).Text = ""
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            End If

        End If

   
    End Sub
End Class