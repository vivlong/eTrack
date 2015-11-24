Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class ContainerMasterEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsContainerMaster
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
        Return New clsContainerMaster(intUserId)
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

    Private Sub BindDetailData(ByVal intUserId As String, ByVal intId As Int64)
        objServer = NewServerObject(intUserId)
        If intId >= 0 Then
            Dim tmpProp As clsPropContainerMaster = objServer.GetDetail(intId)
            fldId.Value = tmpProp.TrxNo.ToString()
            txtContainerNo.Text = tmpProp.ContainerNo
            ConvertDateTime(txtCommissionDate, tmpProp.Comm_Date)
            ConvertDateTime(txtOnHireDate, tmpProp.OnHireDateTime)
            ConvertDateTime(txtOffHireDate, tmpProp.OffHireDateTime)
            drpTankCategory.SelectedValue = tmpProp.Tank_Cat
            txtLessor.Text = tmpProp.Lessor
            ConvertDateTime(txtManuDate, tmpProp.Date_Manu)
            txtManufacturer.Text = tmpProp.Manufacturer
            txtPlate.Text = tmpProp.Plate
            drpContainerType.SelectedValue = tmpProp.ContainerType
            txtExternalLength.Text = tmpProp.ExternalLength
            txtExternalWidth.Text = tmpProp.ExternalBreadth
            txtHeight.Text = tmpProp.ExternalHeight
            txtInternalLength.Text = tmpProp.InternalLength
            txtInternalWidth.Text = tmpProp.InternalBreadth
            txtInternalHeight.Text = tmpProp.InternalHeight
            txtMaterial.Text = tmpProp.Material
            txtCoat.Text = tmpProp.Ext_Coat
            txtCapacity.Text = tmpProp.Capacity
            txtMaximumgrossweight.Text = tmpProp.Max_g_Weight
            txtTareWeight.Text = tmpProp.Tare_Weight
            txtMaxPayLoad.Text = tmpProp.MaxPayload
            txtTestingPressure.Text = tmpProp.Test_press
            txtThickness.Text = tmpProp.Thickness
            txtApprovals.Text = tmpProp.Approvals
            txtFileName.Text = tmpProp.Name_of_file
            rblUseFlag.SelectedValue = tmpProp.UseFlag
        Else
            Me.Title = "New"
            txtCommissionDate.Attributes.Add("onchange", "DefaultOnHireDate(" + txtCommissionDate.ClientID + "," + txtOnHireDate.ClientID + ")")
        End If

    End Sub

    Private Sub SetInitValue(ByVal strUserId As String)
        hidUserId.Value = strUserId
        'Dim objTankCategoryList As New clsTankCategoryList
        'drpTankCategory.DataSource = BaseSelectSrvr.GetData("select * from Code_table where Code = 'TANK_CAT '", "")
        'drpTankCategory.DataTextField = "Code_desc"
        'drpTankCategory.DataValueField = "Value"
        'drpTankCategory.DataBind()
        'drpTankCategory.Items.RemoveAt(0) 'add by zeng 20080108 ,  delete item "all"
        drpTankCategory.Items.Add(New ListItem("select...", ""))
        Dim objTankType As New clsTankTypeList
        Dim tmpTable As DataTable = BaseSelectSrvr.GetData("select * from rccf1", "")
        drpContainerType.DataSource = tmpTable
        drpContainerType.DataTextField = "ContainerType"
        drpContainerType.DataValueField = "ContainerType"
        drpContainerType.DataBind()
        If tmpTable.Rows.Count > 0 Then
            drpContainerType.SelectedValue = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ContainerType"), DbType.String))
            txtExternalLength.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalLength"), DbType.String))
            txtExternalWidth.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalBreadth"), DbType.String))
            txtHeight.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalHeight"), DbType.String))
            txtInternalLength.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalLength"), DbType.String))
            txtInternalWidth.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalBreadth"), DbType.String))


            txtInternalHeight.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalHeight"), DbType.String))
            txtMaterial.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Material"), DbType.String))
            txtCapacity.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Capacity"), DbType.String))
            txtTareWeight.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Tare_Weight"), DbType.String))
            '091223
            txtMaximumgrossweight.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Max_g_Weight"), DbType.String))



            txtMaxPayLoad.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("MaxPayload"), DbType.String))
            txtCoat.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Ext_Coat"), DbType.String))
            txtApprovals.Text = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Approvals"), DbType.String))
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
            Dim intId As Int64 = ConClass.NewIdValue
            If Not (Request("Id") Is Nothing) Then
                intId = Int64.Parse(Request("Id").ToString())
                fldId.Value = intId
            Else
                fldId.Value = -1
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            'btnCommissionDate
            btnCommissionDate.Attributes.Add("OnClick", "WdatePicker({el:'txtCommissionDate',dateFmt:'dd-MMM-yy'});return false;")
            txtCommissionDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtCommissionDate.ClientID + "');return false;")
            txtCommissionDate.Attributes.Add("onblur", "ChangeLongDate('" + txtCommissionDate.ClientID + "');return false;")
            'btnOnHireDate
            btnOnHireDate.Attributes.Add("OnClick", "WdatePicker({el:'txtOnHireDate',dateFmt:'dd-MMM-yy'});return false;")
            txtOnHireDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtOnHireDate.ClientID + "');return false;")
            txtOnHireDate.Attributes.Add("onblur", "ChangeLongDate('" + txtOnHireDate.ClientID + "');return false;")
            'btnOffHireDate
            btnOffHireDate.Attributes.Add("OnClick", "WdatePicker({el:'txtOffHireDate',dateFmt:'dd-MMM-yy'});return false;")
            txtOffHireDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtOffHireDate.ClientID + "');return false;")
            txtOffHireDate.Attributes.Add("onblur", "ChangeLongDate('" + txtOffHireDate.ClientID + "');return false;")
            'btnManuDate
            btnManuDate.Attributes.Add("OnClick", "WdatePicker({el:'txtManuDate',dateFmt:'dd-MMM-yy'});return false;")
            txtManuDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtManuDate.ClientID + "');return false;")
            txtManuDate.Attributes.Add("onblur", "ChangeLongDate('" + txtManuDate.ClientID + "');return false;")
            'Bind Detail Data
            BindDetailData(objUser.UserId, intId)
            'SetInitControl
            SetInitControl(intId, objUser.UpperCase)
        End If
    End Sub

    Private Sub SetInitControl(ByRef intId As Int64, ByVal UpperFlag As String)
        If UpperFlag = "y" Then
            setUpperCase(txtContainerNo)
            setUpperCase(txtLessor)
            setUpperCase(txtManufacturer)
            setUpperCase(txtPlate)
            setUpperCase(txtMaterial)
            setUpperCase(txtCoat)
            setUpperCase(txtApprovals)
            setUpperCase(txtFileName)
        End If
        drpContainerType.Attributes.Add("OnChange", "GetContainerType();")
        If Request("Type") Is Nothing OrElse Request("Type").ToString() = "" Then
            'Button Event
            btnBook.Style.Add("display", "none")
            btnSave.Attributes.Add("onclick", "SaveDetail('" + objServer.Title + "',0);return false;")
            btnNew.Attributes.Add("onclick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnClose.Attributes.Add("OnClick", "blChanged=true;CloseWindow(0);return false;")
            'KeyDown Event
            setFocusControl(txtContainerNo, txtCommissionDate)
            setFocusControl(txtCommissionDate, drpTankCategory)
            setFocusControl(drpTankCategory, txtOnHireDate)
            setFocusControl(txtOnHireDate, txtOffHireDate)
            setFocusControl(txtOffHireDate, txtLessor)
            setFocusControl(txtLessor, txtManuDate)
            setFocusControl(txtManuDate, txtManufacturer)
            setFocusControl(txtManufacturer, txtPlate)
            setFocusControl(txtPlate, drpContainerType)
            setFocusControl(drpContainerType, txtExternalLength)
            setFocusControl(txtExternalLength, txtExternalWidth)
            setFocusControl(txtExternalWidth, txtHeight)
            setFocusControl(txtHeight, txtInternalLength)
            setFocusControl(txtInternalLength, txtInternalWidth)
            setFocusControl(txtInternalWidth, txtInternalHeight)
            setFocusControl(txtInternalHeight, txtMaterial)
            setFocusControl(txtMaterial, txtCoat)

            setFocusControl(txtCoat, txtCapacity)
            setFocusControl(txtCapacity, txtMaximumgrossweight)
            setFocusControl(txtMaximumgrossweight, txtTareWeight)
            setFocusControl(txtTareWeight, txtMaxPayLoad)
            setFocusControl(txtMaxPayLoad, txtTestingPressure)
            setFocusControl(txtTestingPressure, txtThickness)
            setFocusControl(txtThickness, txtApprovals)

            'txtExternalLength
            txtExternalLength.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtExternalLength.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtExternalLength.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtExternalWidth
            txtExternalWidth.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtExternalWidth.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtExternalWidth.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtHeight
            txtHeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtHeight.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtHeight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtInternalLength
            txtInternalLength.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalLength.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtInternalLength.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtInternalWidth
            txtInternalWidth.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalWidth.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtInternalWidth.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtInternalHeight
            txtInternalHeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtInternalHeight.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtInternalHeight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtCapacity
            txtCapacity.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtCapacity.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtCapacity.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtMaximumgrossweight
            txtMaximumgrossweight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtMaximumgrossweight.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtMaximumgrossweight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtTareWeight
            txtTareWeight.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtTareWeight.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtTareWeight.Attributes.Add("OnKeypress", "NumberInput(event,4);")
            'txtMaxPayLoad
            txtMaxPayLoad.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtMaxPayLoad.Attributes.Add("OnBlur", "NumberBlur(4,true);")
            txtMaxPayLoad.Attributes.Add("OnKeypress", "NumberInput(event,4);")

            'txtTestingPressure
            txtTestingPressure.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtTestingPressure.Attributes.Add("OnBlur", "NumberBlur(2,true);")
            txtTestingPressure.Attributes.Add("OnKeypress", "NumberInput(event,2);")
            'txtThickness
            txtThickness.Attributes.Add("OnFocus", "NumberFocusbylzw(this);")
            txtThickness.Attributes.Add("OnBlur", "NumberBlur(2,true);")
            txtThickness.Attributes.Add("OnKeypress", "NumberInput(event,2);")
            txtContainerNo.Focus()
        ElseIf Request("Type").ToString() = "Query" Then
            'Button Event
            btnBook.Attributes.Add("OnClick", "BookTank(" + intId.ToString() + ");return false;")
            btnSave.Style.Add("display", "none")
            btnNew.Style.Add("display", "none")
            btnClose.Attributes.Add("OnClick", "window.close();return false;")
            'Readonly
            txtContainerNo.ReadOnly = True
            txtLessor.ReadOnly = True
            txtManuDate.ReadOnly = True
            txtManufacturer.ReadOnly = True
            txtPlate.ReadOnly = True
            txtHeight.ReadOnly = True
            txtMaterial.ReadOnly = True
            txtCapacity.ReadOnly = True
            txtTareWeight.ReadOnly = True
            txtTestingPressure.ReadOnly = True
            txtThickness.ReadOnly = True
            txtCoat.ReadOnly = True
            txtApprovals.ReadOnly = True
            txtFileName.ReadOnly = True
        Else
            'Button Event
            btnBook.Style.Add("display", "none")
            btnSave.Style.Add("display", "none")
            btnNew.Style.Add("display", "none")
            btnClose.Attributes.Add("OnClick", "window.close();return false;")
        End If
    End Sub

    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub

    Public Function GetContainerType(ByVal ContainerType As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim strResult As String = GetDetailAsString(ContainerType)
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + strResult
        Else
            Return ZZMessage.ConMsgRtn.NoLogin + ConSeparator.Par + ZZMessage.ConMsgInfo.NoLogin
        End If
    End Function

    Public Function GetDetailAsString(ByVal ContdainerType As String) As String
        Dim tmpTable As DataTable = BaseSelectSrvr.GetData("select * from rcco1 where ContainerType='" + ContdainerType + "'", "")
        Dim strResult As String = ""
        If tmpTable.Rows.Count > 0 Then
            strResult = CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalLength"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalBreadth"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("ExternalHeight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalLength"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalBreadth"), DbType.String))

            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("InternalHeight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Material"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Capacity"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Tare_Weight"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Max_g_Weight"), DbType.String))

            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("MaxPayload"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Ext_Coat"), DbType.String))
            strResult = strResult + ConSeparator.Col + CStr(GeneralFun.CheckNull(tmpTable.Rows(0)("Approvals"), DbType.String))
        End If
        Return strResult
    End Function

    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");")
    End Sub
End Class