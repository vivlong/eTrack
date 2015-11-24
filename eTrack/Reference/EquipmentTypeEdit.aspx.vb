Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class EquipmentTypeEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsEquipmentType
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
        Return New clsEquipmentType(intUserId)
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
    Private Sub ConvertDate(ByRef con As TextBox, ByVal strVal As Date)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            Else
                con.Text = strVal.ToString("dd/MM/yyyy")
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub ConvertDateTime(ByRef con As TextBox, ByVal strVal As DateTime)
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                con.Text = ""
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    con.Text = strVal.ToString("dd-MMM-yy")
                Else
                    con.Text = strVal.ToString("dd-MMM-yy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal ContainerType As String)
        objServer = NewServerObject(intUserId)
        If ContainerType <> "" Then
            Dim tmpProp As clsPropEquipmentType = objServer.GetDetail(ContainerType)
            fldId.Value = tmpProp.ContainerType.ToString()
            txtContainerType.Text = tmpProp.ContainerType
            txtExternalLength.Text = tmpProp.ExternalLength
            txtExternalWidth.Text = tmpProp.ExternalBreadth
            txtExternalHeight.Text = tmpProp.ExternalHeight
            txtInternalLength.Text = tmpProp.InternalLength
            txtInternalWidth.Text = tmpProp.InternalBreadth
            txtInternalHeight.Text = tmpProp.InternalHeight
            txtMaterial.Text = tmpProp.Material
            txtCoat.Text = tmpProp.Ext_Coat
            txtCapacity.Text = tmpProp.Capacity
            txtMaximumgrossweight.Text = tmpProp.Max_g_Weight
            txtTareWeight.Text = tmpProp.Tare_Weight
            txtMaxPayLoad.Text = tmpProp.MaxPayload
            txtStacking.Text = tmpProp.Stacking
            txtWorkingPressure.Text = tmpProp.Work_press
            txtApprovals.Text = tmpProp.Approvals
            txtContainerType.ReadOnly = True
        Else
            Me.Title = "New"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) '
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            hidUserId.Value = objUser.UserId
            Dim ContainerType As String = ""
            If Not (Request("Id") Is Nothing) Then
                ContainerType = Request("Id").ToString()
                fldId.Value = ContainerType
            Else
                fldId.Value = -1
            End If
            'Bind Detail Data
            BindDetailData(objUser.UserId, ContainerType)
            'SetInitControl
            SetInitControl(ContainerType, objUser.UpperCase)
            If objUser.UpperCase = "y" Then
                txtContainerType.Attributes.Add("onchange", "setToUpperCase(" + txtContainerType.ClientID + ");ValidContainerType('" + ContainerType + "'," + txtContainerType.ClientID + "); return false;")
            Else
                txtContainerType.Attributes.Add("onchange", "ValidContainerType('" + ContainerType + "'," + txtContainerType.ClientID + "); return false;")
            End If
        End If
    End Sub
    Public Function ValidContainerType(ByVal ContainerType As String) As String
        Dim intcount As Integer = 0
        Try
            Dim tmpTable As DataTable = BaseSelectSrvr.GetData("select count(*) from rcco1 where ContainerType='" + ContainerType + "'", "")
            intcount = Integer.Parse(tmpTable.Rows(0)(0))
        Catch ex As Exception
        End Try
        Return intcount.ToString
    End Function
    Private Sub SetInitControl(ByRef ContainerType As String, ByVal UpperFlag As String)
        If UpperFlag = "y" Then

            setUpperCase(txtMaterial)
            setUpperCase(txtCoat)
            setUpperCase(txtStacking)
            setUpperCase(txtApprovals)
        End If
        If Request("Type") Is Nothing OrElse Request("Type").ToString() = "" Then
            'Button Event
            btnSave.Attributes.Add("onclick", "SaveDetail('" + objServer.Title + "',0);return false;")
            btnNew.Attributes.Add("onclick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnClose.Attributes.Add("OnClick", "blChanged=true;CloseWindow(0);return false;")
            'KeyDown Event
            setFocusControl(txtContainerType, txtExternalLength)
            setFocusControl(txtExternalLength, txtExternalWidth)
            setFocusControl(txtExternalWidth, txtExternalHeight)
            setFocusControl(txtExternalHeight, txtInternalLength)
            setFocusControl(txtInternalLength, txtInternalWidth)
            setFocusControl(txtInternalWidth, txtInternalHeight)
            setFocusControl(txtInternalHeight, txtMaterial)
            setFocusControl(txtMaterial, txtCoat)
            setFocusControl(txtCoat, txtCapacity)
            setFocusControl(txtCapacity, txtMaximumgrossweight)
            setFocusControl(txtMaximumgrossweight, txtMaxPayLoad)
            setFocusControl(txtMaxPayLoad, txtStacking)
            setFocusControl(txtStacking, txtTareWeight)
            setFocusControl(txtTareWeight, txtWorkingPressure)
            setFocusControl(txtWorkingPressure, txtApprovals)
            'txtExternalLength
            txtExternalLength.Attributes.Add("OnFocus", "NumberFocusEqu(this);")
            txtExternalLength.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtExternalLength.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtExternalWidth
            txtExternalWidth.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtExternalWidth.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtExternalWidth.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtExternalHeight
            txtExternalHeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtExternalHeight.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtExternalHeight.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtInternalLength
            txtInternalLength.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalLength.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtInternalLength.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtInternalWidth
            txtInternalWidth.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalWidth.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtInternalWidth.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtInternalHeight
            txtInternalHeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalHeight.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtInternalHeight.Attributes.Add("OnKeypress", "NumberInput(event,0);")

            'txtCapacity
            txtCapacity.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtCapacity.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtCapacity.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtMaximumgrossweight
            txtMaximumgrossweight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtMaximumgrossweight.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtMaximumgrossweight.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtTareWeight
            txtTareWeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtTareWeight.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtTareWeight.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            'txtMaxPayLoad
            txtMaxPayLoad.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtMaxPayLoad.Attributes.Add("OnBlur", "NumberBlur(event,4,true);")
            txtMaxPayLoad.Attributes.Add("OnKeypress", "NumberInput(event,0);")

            'txtTestingPressure
            txtWorkingPressure.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtWorkingPressure.Attributes.Add("OnBlur", "NumberBlur(event,2,true);")
            txtWorkingPressure.Attributes.Add("OnKeypress", "NumberInput(event,0);")
            txtContainerType.Focus()
        ElseIf Request("Type").ToString() = "Query" Then
            'Button Event
            btnSave.Style.Add("display", "none")
            btnNew.Style.Add("display", "none")
            btnClose.Attributes.Add("OnClick", "window.close();return false;")
            'Readonly
            txtContainerType.ReadOnly = True

            txtExternalHeight.ReadOnly = True
            txtMaterial.ReadOnly = True
            txtCapacity.ReadOnly = True
            txtTareWeight.ReadOnly = True
            txtWorkingPressure.ReadOnly = True
            txtCoat.ReadOnly = True
            txtApprovals.ReadOnly = True
        Else
            'Button Event
            btnSave.Style.Add("display", "none")
            btnNew.Style.Add("display", "none")
            btnClose.Attributes.Add("OnClick", "window.close();return false;")
        End If
    End Sub
    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");")
    End Sub
    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
End Class