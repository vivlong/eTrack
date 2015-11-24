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

Partial Class ContainerEnquiryDetail
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsContainerEnquiry_Sebl1_Sibl1Edit
    Private objColumns As colColumn
    Private objList As clsJobStatus
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

    Public Function SaveData(ByVal strValue As String, ByVal strCheckDate As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = NewServerObject(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                strMsg = CheckDataEnter(strCheckDate)
                If strMsg = "" Then
                    If SaveScreen(strValue) = "" Then
                        Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
                    Else
                        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
                    End If
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function

    Private Function CheckDataEnter(strCheckDate As String) As String
        CheckDataEnter = ""
        Dim dateCom As Date
        Dim strLastDate As String = ""
        Dim dateLastDate As Date
        Dim blnReturnDate As Boolean = False
        Dim strErrorMessage As String = ""
        Dim strList() As String = strCheckDate.Split("###")
        Dim strDateList As String = ""
        If Me.txtETD.Value <> "" Then
            dateLastDate = CDate(getSQLValue(Me.txtETD.Value))
            strLastDate = Me.txtETD.Value
            strDateList = "ETD"
        End If
        If Me.txtETA.Text <> "" Then
            dateLastDate = CDate(getSQLValue(Me.txtETA.Text))
            strLastDate = Me.txtETA.Text
            strDateList = strDateList & IIf(strDateList = "", "", " and ") & "ETA"
        End If
        For intI As Integer = 0 To strList.Length - 1
            If strList(intI) <> "" AndAlso strList(intI).Split("=").Length = 2 Then
                'If strList(intI).Split("=")(0) = "FinalDestDate" AndAlso strList(intI).Split("=")(1) <> "" Then
                '    dateCom = CDate(getSQLValue(strList(intI).Split("=")(1)))
                '    If strLastDate <> "" AndAlso dateLastDate > dateCom Then
                '        Return "Arrive ICD must later then (" & strDateList & "),Please Check"
                '    Else
                '        strLastDate = strList(intI).Split("=")(1)
                '        dateLastDate = dateCom
                '    End If
                '    strDateList = strDateList & IIf(strDateList = "", "", " and ") & "'Arrive ICD'"
                'End If
                If strList(intI).Split("=")(0) = "DOReleaseDate" AndAlso strList(intI).Split("=")(1) <> "" Then
                    dateCom = CDate(getSQLValue(strList(intI).Split("=")(1)))
                    If strLastDate <> "" AndAlso dateLastDate > dateCom Then
                        Return "D/O Date must later then (" & strDateList & "),Please Check"
                    Else
                        strLastDate = strList(intI).Split("=")(1)
                        dateLastDate = dateCom
                    End If
                    strDateList = strDateList & IIf(strDateList = "", "", " and ") & "'D/O Date'"
                End If
                If strList(intI).Split("=")(0) = "CntrReturnDate" AndAlso strList(intI).Split("=")(1) <> "" Then
                    dateCom = CDate(getSQLValue(strList(intI).Split("=")(1)))
                    If strLastDate <> "" AndAlso dateLastDate > dateCom Then
                        Return "Return Date must later then (" & strDateList & "),Please Check"
                    Else
                        strLastDate = strList(intI).Split("=")(1)
                        dateLastDate = dateCom
                    End If
                    strDateList = strDateList & IIf(strDateList = "", "", " and ") & "'D/O Date'"
                    blnReturnDate = True
                End If
                If strList(intI).Split("=")(0) = "CntrReturnType" AndAlso strList(intI).Split("=")(1) = "" AndAlso blnReturnDate Then
                    Return "Return Type must be enter when Return Date has the value."
                End If
            End If
        Next
    End Function

    Private Function SaveScreen(strValue As String) As String
        SaveScreen = ""
        Dim intResult As Integer
        Dim strSql As String = ""
        Dim strList() As String = strValue.Split("###")
        Dim strUpdate As String = ""
        If Not strList Is Nothing AndAlso strList.Length > 0 Then
            For intI As Integer = 0 To strList.Length - 1
                If strList(intI).Length > 0 AndAlso InStr(strList(intI), "=") > 0 Then
                    strUpdate = strUpdate & IIf(strUpdate = "", "", ",") & strList(intI).Split("=")(0) & " = "
                    If strList(intI).Split("=")(1) = "" Then
                        strUpdate = strUpdate & "NULL "
                    Else
                        strUpdate = strUpdate & "'" & getSQLValue(strList(intI).Split("=")(1)).Replace("'", "''") & "' "
                    End If
                End If
            Next
        End If
        'Dim tmpProp As clsPropContainerEnquiry = objServer.GetDetail(strContainerKey)
        strSql = "Update " & Me.fldId.Value.ToString.Split("A")(0) & " Set " & strUpdate
        strSql = strSql & " Where TrxNo = " & Me.fldId.Value.ToString.Split("A")(1) & " AND LineItemNo = " & Me.fldId.Value.ToString.Split("A")(2)
        'strSql = "Update omtx1 set AttachmentFlag='N' Where TrxNo=" + intTrxNo.ToString + ""
        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)


    End Function

    Private Function getSQLValue(strValue As String) As String
        If strValue.Split("/").Length <> 3 Then
            Return strValue
        Else
            If strValue.Split("/")(2).Length = 4 Then
                Return strValue.Split("/")(2) & "-" & strValue.Split("/")(1) & "-" & strValue.Split("/")(0)
            Else
                Try
                    Return CDate(strValue)
                Catch ex As Exception
                    ex.Data.Clear()
                    Return strValue
                End Try
            End If
        End If
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsContainerEnquiry_Sebl1_Sibl1Edit(intUserId)
    End Function
    Private Sub BindDetailData(ByVal intUserId As String, ByVal strContainerKey As String)
        objServer = NewServerObject(intUserId)
        If strContainerKey <> "" Then
            Dim tmpProp As clsPropContainerEnquiry = objServer.GetDetail(strContainerKey)
            fldId.Value = strContainerKey
            Me.txtCntrRemark.Text = tmpProp.CntrRemark
            Me.txtCntrReturnDate.sDateValue = IIf(tmpProp.CntrReturnDate = DateTime.MinValue, "", tmpProp.CntrReturnDate)
            Me.drCntrReturnType.SelectedValue = tmpProp.CntrReturnType
            Me.txtContainerNo.Text = tmpProp.ContainerNo
            Me.txtOwner.Text = tmpProp.Owner
            Me.txtDOReleaseDate.sDateValue = IIf(tmpProp.DOReleaseDate = DateTime.MinValue, "", tmpProp.DOReleaseDate)
            Me.txtETA.Text = IIf(tmpProp.EtaDate = DateTime.MinValue, "", tmpProp.EtaDate.ToString("dd/MM/yyyy"))
            Me.txtETD.Value = IIf(tmpProp.EtdDate = DateTime.MinValue, "", tmpProp.EtdDate.ToString("dd/MM/yyyy"))
            Me.fldCntrTransferDate.Value = IIf(tmpProp.CntrTransferDate = DateTime.MinValue, "", tmpProp.CntrTransferDate)
            Me.txtFinalDestDate.sDateValue = IIf(tmpProp.FinalDestDate = DateTime.MinValue, "", tmpProp.FinalDestDate)
            Me.txtHODate.sDateValue = IIf(tmpProp.HODate = DateTime.MinValue, "", tmpProp.HODate)
            Me.txtPickupDate.sDateValue = IIf(tmpProp.PickupDate = DateTime.MinValue, "", tmpProp.PickupDate)
            Me.dtsDischargeDate.sDateValue = IIf(tmpProp.DischargeDate = DateTime.MinValue, "", tmpProp.DischargeDate)
            Me.fldRccfContainer.Value = tmpProp.RccfContainer
            If tmpProp.CargoStatusCode = "INB" OrElse tmpProp.CargoStatusCode = "CMP" Then
                Me.drCargoStatusCode.SelectedValue = "Y"
                Me.drCargoStatusCode.Enabled = False
            Else
                Me.drCargoStatusCode.SelectedValue = "N"
            End If
        Else
            fldId.Value = ""
            Me.txtCntrRemark.Text = ""
            Me.txtCntrReturnDate.sDateValue = ""
            Me.drCntrReturnType.Text = ""
            Me.drCargoStatusCode.Text = ""
            Me.txtOwner.Text = ""
            Me.txtContainerNo.Text = ""
            Me.txtDOReleaseDate.sDateValue = ""
            Me.txtETA.Text = ""
            Me.txtFinalDestDate.sDateValue = ""
            Me.txtHODate.sDateValue = ""
            Me.txtPickupDate.sDateValue = ""
            Me.fldCntrTransferDate.Value = ""
            Me.dtsDischargeDate.sDateValue = ""
            Me.fldRccfContainer.Value = ""
        End If
            'Repair Detail
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        objServer = NewServerObject(intUserId)
        btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',0);return false;")
        btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load '
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
            Dim strVoyageID As String = ""
            If Not (Request("id") Is Nothing) Then
                strVoyageID = Request("id").ToString()
                Head1.Title = "Container Enquiry"
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            'Bind Detail Data
            BindDetailData(objUser.UserId, strVoyageID)
            If Me.txtCntrReturnDate.sDateValue <> "0001-01-01" Then
                Me.txtCntrReturnDate.ReadOnlyNew = True
                Me.drCntrReturnType.Enabled = False
            End If
            If Me.txtDOReleaseDate.sDateValue <> "0001-01-01" Then Me.txtDOReleaseDate.ReadOnlyNew = True
            If Me.txtFinalDestDate.sDateValue <> "0001-01-01" Then Me.txtFinalDestDate.ReadOnlyNew = True
            If Me.dtsDischargeDate.sDateValue <> "0001-01-01" Then Me.dtsDischargeDate.ReadOnlyNew = True
            If Me.txtHODate.sDateValue <> "0001-01-01" Then Me.txtHODate.ReadOnlyNew = True
            If Me.txtPickupDate.sDateValue <> "0001-01-01" Then Me.txtPickupDate.ReadOnlyNew = True
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

End Class