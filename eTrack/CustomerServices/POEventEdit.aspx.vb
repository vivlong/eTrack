Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class EventEdit
    Inherits ListEditPage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objPopo1 As clsPO
    Private objServer As clsEvent
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strTitle As String = ""
    'Dim objExport As ExportToExcel.ExcelExpor
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub 
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Private intLineItemNo As Int64 = ConClass.NewIdValue
    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsEvent(intUserId)
    End Function
    Public Function NewServerObject(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsEvent(strUserId, RoleName, strFunNo)
    End Function

#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            fldId.Value = -1
            fldLineItemNo.Value = -1
            'Set Default Value
            If Not (Request("Id") Is Nothing) Then
                intTrxNo = Int64.Parse(Request("Id").ToString())
                intLineItemNo = Request("LineItemNo").ToString()
                fldLineItemNo.Value = Request("LineItemNo").ToString()
                fldId.Value = intTrxNo
                divMiddle1.Style.Add("display", "block")
                SetInitValue1(objUser.UserId)
                BindDetailData(objUser.UserId, intTrxNo, intLineItemNo)
                'bylin
                Dim strFunNo As String = (PageFun.GetFunNo(Page)).ToString
                '-----byRoot
                Session("FunNo") = strFunNo
                '-----End
                'New Object 
                objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
                objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
                ''Assign Page Event and Relative Value
                'Get First Page Data
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                HandlePopupMenu()
                btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',2);return false;")

            Else
                intTrxNo = Int64.Parse(Request("TrxNo").ToString())
                fldId.Value = intTrxNo
                SetInitValue(objUser.UserId)

                'Bind The All Detail
            End If

            KeydownEvent()
            btnEventTitle.Attributes.Add("OnClick", "selBindCode(" + txtEventTitle.ClientID + ",'poev1','TrxNo,Title','','TrxNo','Title');return false;")
            btnEventTitle.Attributes.Add("onchange", "valiString('" + txtEventTitle.ClientID + "','Title','Title','poev1','');")
            chkNotifyUsers.Attributes.Add("OnClick", "TickChk();")

            btnSave.Attributes.Add("OnClick", "SaveDetail('" + objServer.Title + "',1);return false;")
            btnEventDate.Attributes.Add("OnClick", "showCalendar(txtEventDate,0);return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    'Bind DrowDownList Init for New
    Private Sub SetInitValue(ByVal intUserId As String)
        objServer = NewServerObject(intUserId)
        Me.Title = "New LineItem"
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Country
    End Sub
    Private Sub SetInitValue1(ByVal intUserId As String)
        objServer = NewServerObject(intUserId)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'clear dt
    End Sub
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
#End Region
#Region "Add LineItemPO"
    Private Sub KeydownEvent()
        'Item Information
        setFocusControl(txtEventDate, txtEventTitle)
        setFocusControl(txtEventTitle, txtComments)
        ''First Focus Control
        Me.Title = "New LineItem"
    End Sub

    Private Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
        FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
    End Sub
    Public Function SaveData(ByVal strValue As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            objServer = New clsEvent(objUser.UserId)
            If Not objServer.ModifyCurrent(strValue) Then
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.CurrentCannotSave
            Else
                If objServer.Save(strMsg) Then
                    If objServer.masterId Then
                        fldId.Value = objServer.masterId
                    End If
                    Dim intTrxNo As Int64 = GetNewId()
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strMsg + ConSeparator.Par + GridViewFun.RenderControl(fldId)
                End If
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
#End Region
#Region "First Tab"
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
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal intTrxNo As String, ByVal IntLineItem As String)
        objServer = NewServerObject(intUserId)
        If intTrxNo >= 0 Then
            Dim tmpProp As clsPropEvent = objServer.GetDetail(intTrxNo, IntLineItem)
            If tmpProp.TrxNo > 0 Then
                intTrxNo = GetNewId()
                fldId.Value = tmpProp.TrxNo.ToString()
                ''Item Info
                txtEventDate.Text = tmpProp.EventDate
                txtEventTitle.Text = tmpProp.EventTitle
                txtComments.Text = tmpProp.Comments
                'txtItemDescription1.Text = tmpProp.PartDesc
                'txtSupplierPartNumber2.Text = tmpProp.SupplierPartNo
                'drCurrency1.SelectedValue = tmpProp.CurrCode
                'txtUnitPrice2.Text = tmpProp.UnitPrice
                'txtHarmonizedCode2.Text = tmpProp.HarmonizeCode
                'txtDescription2.Text = tmpProp.HarmonizeDesc
                'rbHazardous1.SelectedValue = tmpProp.HazardousFlag
                'ConvertDate(txtEstimatedTimeofArrival2, tmpProp.TimeOfArrival)
                Me.Title = "Purchase No " + tmpProp.TrxNo.ToString
            Else
                Me.Title = "Purchase No " + tmpProp.TrxNo.ToString
            End If
        End If
    End Sub
#End Region
#Region "Event PO"
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsEvent(strUserId, RoleName, strFunNo)
    End Function
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.Header Then
            For i = 0 To objColumns.Column.Count - 1
                e.Row.Cells(i).Style.Add("word-wrap", "break-word")
            Next
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim strChangeClass As String = ""
            Dim strPriority As String = ""
            'KeyValue 
            Dim intTrxNo As String
            intTrxNo = CType(tmpProp, clsPropEvent).TrxNo
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            'Handle display value
            Dim strFieldName As String
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Select Case _ColumnInfo.FieldType
                    'DateTime
                    Case DbType.Date, DbType.DateTime
                        strFieldName = _ColumnInfo.FieldName
                        If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                            Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                            If dtmTemp <= ConDateTime.MinDate Then
                                e.Row.Cells(i + 1).Text = ""
                            Else
                                e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                            End If
                        End If
                    Case DbType.Date, DbType.Decimal
                        strFieldName = _ColumnInfo.FieldName
                        Dim str As String = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If str <> "" Then
                            Dim dtmTemp As Decimal = Decimal.Parse(str)
                            Dim strWt As Decimal = Decimal.Round(dtmTemp, 3)
                            If strWt <> 0.0 Then
                                e.Row.Cells(i + 1).Text = strWt
                            Else
                                e.Row.Cells(i + 1).Text = ""
                            End If
                        End If
                End Select
                'Trx No 
                If _ColumnInfo.FieldName = "TrxNo" Then
                    If intTrxNo = "" Then
                        e.Row.Cells(i + 1).Text = ""
                    End If
                End If
            Next
            'Row(cann) 't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intTrxNo.ToString() + "," + intLineItemNo.ToString() + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgEdit.Attributes.Add("OnClick", "EditDetail(" + intTrxNo.ToString() + ",'" + Request("FunNo").ToString + "'," + intLineItemNo.ToString() + ");return false;")
                e.Row.Attributes.Add("ondblclick", "EditDetail(" + intTrxNo.ToString() + ",'" + Request("FunNo").ToString + "'," + intLineItemNo.ToString() + ");return false;")
            Else
                imgEdit.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail();return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail();return false;")
            Else
                imgInsert.Visible = False
            End If
            'Print
            Dim imgPrint As Image = CType(e.Row.FindControl("imgPrint"), Image)
            If (intTrxNo.ToString <> "") AndAlso objList.PrintPrivilege Then
                imgPrint.Attributes.Add("OnClick", "PrintDetail(" + intTrxNo.ToString() + ");return false;")
            Else
                imgPrint.Visible = False
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            e.Row.Attributes.Add("ondblclick", "GridColumnSet();return false;")
        End If
    End Sub
    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Edit MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""DeleteDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "DeleteRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Print MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""PrintDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "PrintRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
    End Sub
#End Region
#Region "Edit PO"
    Function SaveLineData(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("PartNo='" + strRow(1) + "'")
            sb.Append(",PartDesc='" + strRow(2) + "'")
            sb.Append(",SupplierPartNo='" + strRow(3) + "'")
            sb.Append(",CurrCode='" + strRow(4) + "'")
            sb.Append(",UnitPrice='" + strRow(5) + "'")
            sb.Append(",HarmonizeCode='" + strRow(6) + "'")
            sb.Append(",HarmonizeDesc='" + strRow(7) + "'")
            sb.Append(",HazardousFlag='" + strRow(8) + "'")
            sb.Append(",TagNo='" + strRow(9) + "'")
            sb.Append(",QtyOrdered='" + strRow(10) + "'")
            sb.Append(" where TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Function SaveShippingInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("InsuranceValue='" + strRow(1) + "'")
            sb.Append(",DateRequested='" + GeneralFun.StringToDate(strRow(2)) + "'")
            sb.Append(",LatestDeliveryDate='" + GeneralFun.StringToDate(strRow(3)) + "'")
            sb.Append(",DateRequestedAtSite='" + GeneralFun.StringToDate(strRow(4)) + "'")
            sb.Append(",TimeOfArrival='" + GeneralFun.StringToDate(strRow(5)) + "'")
            sb.Append(",ShippingStatus='" + strRow(6) + "'")
            sb.Append("where  TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Function SavePackageInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo2 set ")
            sb.Append("UOM='" + ConvertToInt(strRow(1)) + "'")
            sb.Append(",Length=" + ConvertToInt(strRow(2)))
            sb.Append(",Width=" + ConvertToInt(strRow(3)))
            sb.Append(",Height=" + ConvertToInt(strRow(4)))
            sb.Append(",Weight=" + ConvertToInt(strRow(5)))
            sb.Append(" where  TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Function SaveShipToInfo(ByVal strArr As String) As String
        Dim strRow As String() = GeneralFun.GetCol(strArr)
        If strRow.Length <> 39 Then
            Dim sb As New StringBuilder
            sb.Append("update Popo1 set ")
            sb.Append("CompanyName='" + strRow(1) + "'")
            sb.Append(",ContactFirstName='" + strRow(2) + "'")
            sb.Append(",Address1='" + strRow(3) + "'")
            sb.Append(",Address2='" + strRow(4) + "'")
            sb.Append(",City='" + strRow(5) + "'")
            sb.Append(",State='" + strRow(6) + "'")
            sb.Append(",PostalCode='" + strRow(7) + "'")
            sb.Append(",Country='" + strRow(8) + "'")
            sb.Append(",Phone='" + strRow(9) + "'")
            sb.Append(",Fax='" + strRow(10) + "'")
            sb.Append(",Email='" + strRow(11) + "'")
            sb.Append(" where  TrxNo=" + Request("Id").ToString())
            Dim intIn As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, sb.ToString)
            If intIn > 0 Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success" + ConSeparator.Par + fldId.Value
            Else
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + " "
            End If
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function ConvertToInt(ByVal strVal As String) As String
        If IsNumeric(strVal) Then
            Return strVal
        Else
            Return "null"
        End If
    End Function
    Private Function ConvertToDate(ByVal strVal As String) As String
        If IsDate(strVal) Then
            Return "'" + strVal + "'"
        Else
            Return "null"
        End If
    End Function
#End Region
#Region "Call Email"
   
#End Region
End Class
