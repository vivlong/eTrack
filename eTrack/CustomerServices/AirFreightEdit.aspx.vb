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

Partial Class AirFreightEdit
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsAirFreight
    Private objColumns As colColumn
    Private objList As clsJobStatus
    Private returnValue As String
    Private docPath As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingPath")
    Private docUrl As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingURL")
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
        Return New clsAirFreight(intUserId)
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
 
        Dim dtTmp As DataTable = objList.GetAllList()
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile("JobStatus", gvwSource, TemplateType.None)
        gvwSource.DataSource = dtTmp
        gvwSource.DataBind()
        Return True
    End Function

    Private Sub BindDetailData(ByVal intUserId As String, ByVal strJobNo As String, ByVal strModule As String, ByVal dataBase As String)
        objServer = NewServerObject(intUserId)
        If strJobNo <> "" Then
            Dim tmpProp As clsPropAirFreight = objServer.GetDetail(strJobNo + ConSeparator.Col + strModule + ConSeparator.Col + dataBase)
            fldId.Value = tmpProp.JobNo
            txtJobNo.Text = tmpProp.JobNo
            txtRefNo.Text = tmpProp.ReferenceNo
            txtAWBBlNo.Text = tmpProp.AWBBlNo
            txtMawbOBLNo.Text = tmpProp.MawbOBLNo
            txtOrigin.Text = tmpProp.OriginCode
            txtDestCode.Text = tmpProp.DestCode
            txtFlightTo1.Text = tmpProp.FirstToDestCode
            txtFlightBy1.Text = tmpProp.FirstByAirlineID
            txtFlightNo1.Text = tmpProp.FirstFlightNo
            If tmpProp.FirstFlightDate > ConDateTime.MinDate Then
                txtFlightDate1.Text = tmpProp.FirstFlightDate.ToString(ConDateTime.DateFormat)
            Else
                txtFlightDate1.Text = ""
            End If
            txtFlightTo2.Text = tmpProp.SecondToDestCode
            txtFlightBy2.Text = tmpProp.SecondByAirlineID
            txtFlightNo2.Text = tmpProp.SecondFlightNo
            If tmpProp.SecondFlightDate > ConDateTime.MinDate Then
                txtFlightDate2.Text = tmpProp.SecondFlightDate.ToString(ConDateTime.DateFormat)
            Else
                txtFlightDate2.Text = ""
            End If
            txtFlightTo3.Text = tmpProp.ThirdToDestCode
            txtFlightBy3.Text = tmpProp.ThirdByAirlineID
            txtFlightNo3.Text = tmpProp.ThirdFlightNo
            If tmpProp.ThirdFlightDate > ConDateTime.MinDate Then
                txtFlightDate3.Text = tmpProp.ThirdFlightDate.ToString(ConDateTime.DateFormat)
            Else
                txtFlightDate3.Text = ""
            End If
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
            txtCommodity.Text = tmpProp.Commodity
            'STATUS
            BindSourceData(intUserId, strJobNo)
        Else
            fldId.Value = ""
            txtJobNo.Text = ""
            txtRefNo.Text = ""
            txtAWBBlNo.Text = ""
            txtMawbOBLNo.Text = ""
            txtOrigin.Text = ""
            txtDestCode.Text = ""
            txtFlightTo1.Text = ""
            txtFlightBy1.Text = ""
            txtFlightNo1.Text = ""
            txtFlightDate1.Text = ""
            txtFlightTo2.Text = ""
            txtFlightBy2.Text = ""
            txtFlightNo2.Text = ""
            txtFlightDate2.Text = ""
            txtFlightTo3.Text = ""
            txtFlightBy3.Text = ""
            txtFlightNo3.Text = ""
            txtFlightDate3.Text = ""
            txtPcs.Text = ""
            txtGross.Text = ""
            txtCommodity.Text = ""
        End If

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
                Head1.Title = "AIR FREIGHT-" + strJobNo
            End If
            Dim strModule As String = ""
            If Not (Request("Module") Is Nothing) Then
                strModule = Request("Module").ToString()
            End If
            Dim dataBase As String = ""
            If Not (Request("DB") Is Nothing) Then
                dataBase = Request("DB").ToString()
            End If
            If Session("LoginType") = 3 Then
                'Set Default Value
                SetInitValue(3)
                'Bind Detail Data
                BindDetailData(3, strJobNo, strModule, dataBase)
            Else
                'Set Default Value
                SetInitValue(objUser.UserId)
                'Bind Detail Data
                BindDetailData(objUser.UserId, strJobNo, strModule, dataBase)
            End If
            If Request("Type") Is Nothing OrElse Request("Type").ToString() = "" Then
                'Button Event
                ' btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
                '  btnNew.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
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
                txtOrigin.ReadOnly = True
                txtDestCode.ReadOnly = True
                txtFlightTo1.ReadOnly = True
                txtFlightBy1.ReadOnly = True
                txtFlightNo1.ReadOnly = True
                txtFlightDate1.ReadOnly = True
                txtFlightTo2.ReadOnly = True
                txtFlightBy2.ReadOnly = True
                txtFlightNo2.ReadOnly = True
                txtFlightDate2.ReadOnly = True
                txtFlightTo3.ReadOnly = True
                txtFlightBy3.ReadOnly = True
                txtFlightNo3.ReadOnly = True
                txtFlightDate3.ReadOnly = True
                txtPcs.ReadOnly = True
                txtGross.ReadOnly = True
                txtCommodity.ReadOnly = True
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
    'bylzw081224
    Private Sub BindAttach(ByVal intUserId As String, Optional ByVal intNum As Integer = 0)
        If intNum = 0 Then
            ''Specitication
            Dim strJobNo As String = ""
            If Not (Request("JobNo") Is Nothing) Then
                strJobNo = Request("JobNo").ToString()
                strJobNo = strJobNo.Replace("/", "-")
            End If
            objServer = New clsAirFreight(intUserId)
            objServer.GetListInfo(Server.MapPath("..\Doc\" + strJobNo + "\"), "..\Doc\" + strJobNo + "\")
            ' objServer.GetListInfo(Server.MapPath(docPath + strJobNo + "\"), docUrl + strJobNo + "\")

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
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes.Add("OnClick", "DownloadAttachment(""div1"");return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
        If e.Row.RowIndex = objServer.ArrProp.Count - 1 Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Text = ""
            e.Row.Cells(2).Text = ""
            e.Row.Cells(3).Text = ""
        End If
    End Sub
End Class