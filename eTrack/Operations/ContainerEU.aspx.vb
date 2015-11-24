Imports System.Web.UI.WebControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports System.Data.SqlClient
Imports SysMagic

Partial Class Operations_ContainerEU
    Inherits ListEditPage
    Protected ConfigPath As String
    Protected ExportConfig As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, 0)
        objColumns = DynamicGridViewFun.GetColumnFromSqlFile(TableName, gvwSource, TemplateType.BaseInfo, intUserId, Session("LoginType").ToString)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsctcl(strUserId, RoleName, strFunNo)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ctcl1"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Me.CurrentSortField = "TrxNo"
        Me.SortDesc = True
    End Sub

    Private Sub HandleLanguageRelative()
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub HandlePopupMenu()
        Dim strOperate As String = ""
        Dim strReturn As String = ControlChars.NewLine
        'Add New MenuItem
        If objList.NewPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""InsertDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "InsertRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Edit MenuItem
        If objList.EditPrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""EditDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "EditRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Delete MenuItem
        If objList.DeletePrivilege Then
            strOperate = strOperate + "<div class=""menuitems"" id=""DeleteDetail"">" + ZZMessage.clsMessage.GetFormatMessage(CStr(GetGlobalResourceObject("Common", "DeleteRecord")), GetLocalResourceObject("Page.Title")) + "</div>" + strReturn
        End If
        'Add Separator
        If strOperate <> "" Then
            strOperate = strOperate + "<hr class =""separator"" />" + strReturn
        End If
        'Add Edit Column MenuItem 
        strOperate = strOperate + "<div class=""menuitems"" id=""EditColumn"">Edit Column</div> " + strReturn
        popupMenu.InnerHtml = strOperate
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'DrNO
        DrNO.Items.Add(New ListItem("Job No", "JobNo"))
        DrNO.Items.Add(New ListItem("Container No", "ContainerNo"))

        'drEvent
        drEvent.Items.Add(New ListItem("Box Discharge", "BXL"))
        drEvent.Items.Add(New ListItem("Box Load", "GTI"))
        drEvent.Items.Add(New ListItem("Gate In", "DPO"))
        drEvent.Items.Add(New ListItem("Gate Out", "BXD"))
        drEvent.Items.Insert(0, New ListItem(ListItemSelect, ""))
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
            'Set style Config
            ExportConfig = objUser.ExportConfig
            Select Case ExportConfig
                Case "Blue"
                    ConfigPath = "../App_Themes"
                Case "Orange"
                    ConfigPath = "../App_Themes_Orange"
                Case "Smalt"
                    ConfigPath = "../App_Themes_Smalt"
                Case Else
                    ConfigPath = "../App_Themes"
            End Select
            SetInitValue(objUser.UserId)
            'New Object 
objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            hidFunNo.Value = PageFun.GetFunNo(Page)
            objList.Where = " and 1!=1"
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Language
            HandleLanguageRelative()
            'Popup Menu
            HandlePopupMenu()
            'Set First Focused Control
            btnQUERY.Attributes.Add("OnClick", "GetQueryDataEU('" + objUser.SiteCode + "');return false;")
            btnCreateEvent.Attributes.Add("OnClick", "CreateEvent();return false;")

            txtEventDate.Text = DateTime.Now.ToString("dd-MMM-yy HH:mm")
            btnEventDate.Attributes.Add("OnClick", "WdatePicker({el:'txtEventDate',dateFmt:'dd-MMM-yy HH:mm'});return false;")
            txtEventDate.Attributes.Add("onfocus", "ChangeShortDate('" + txtEventDate.ClientID + "');return false;")
            txtEventDate.Attributes.Add("onblur", "ChangeLongDate('" + txtEventDate.ClientID + "');return false;")

            drEvent.Attributes.Add("onchange", "drEventSelect(" + drEvent.ClientID + ")")
            setUpperCase(txtNewVoyageNo)
            divNewVoyageNo.Style.Add("display", "none")
            btnCancel.Attributes.Add("OnClick", "showCancel();return false;")
        End If
    End Sub

    Private Sub setUpperCase(ByRef objCon As TextBox)
        objCon.Attributes.Add("onblur", "setToUpperCase(" + objCon.ClientID + ");return false;")
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim i As Integer
        Dim strFun As String = PageFun.GetFunNo(Page)
        Dim _ColumnInfo As clsPropColumn
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            'KeyValue 
            Dim ds As DataSet
            Dim intTrxNo As String = CType(tmpProp, clsPropctcl).TrxNo.ToString()

            'Popupmenu
            If intTrxNo > 0 Then
                e.Row.Attributes.Add("oncontextmenu", "ShowMenu(event," + intTrxNo.ToString() + ");return false;")
            End If
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            If tmpProp.IsDeleted = 1 Then
                e.Row.ForeColor = ConColor.Deleted
            Else
                e.Row.ForeColor = ConColor.Normal
            End If
            'Handle display value
            For i = 0 To objColumns.Column.Count - 1
                _ColumnInfo = CType(objColumns.Column(i), clsPropColumn)
                Dim strFieldName As String = _ColumnInfo.FieldName
                If _ColumnInfo.FieldType = DbType.Date Or _ColumnInfo.FieldType = DbType.DateTime Then
                    'e.Row.Cells(i).Text
                    If tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing).ToString <> "" Then
                        Dim dtmTemp As DateTime = tmpProp.GetType().GetProperty(strFieldName).GetValue(tmpProp, Nothing)
                        If dtmTemp <= ConDateTime.MinDate Then
                            e.Row.Cells(i + 1).Text = ""
                        Else
                            e.Row.Cells(i + 1).Text = dtmTemp.ToString("dd/MM/yyy")
                        End If
                    End If
                End If
            Next
            Dim ckb As New CheckBox
            ckb.ID = "ckbTrxNO"
            e.Row.Cells(0).Controls.Add(ckb)
            Dim hidTrxNo As New HiddenField
            hidTrxNo.ID = "hidTrxNo"
            hidTrxNo.Value = intTrxNo
            e.Row.Cells(0).Controls.Add(hidTrxNo)
            'Row cann't be select
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Attributes.Add("onSelectStart", "return false;")
            Next
            'Delete
            Dim imgDelete As Image = CType(e.Row.FindControl("imgDelete"), Image)
            If objList.DeletePrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgDelete.Attributes.Add("OnClick", "DeleteDetail(" + intTrxNo + ");return false;")
            Else
                imgDelete.Visible = False
            End If
            'Undelete
            Dim imgRestore As Image = CType(e.Row.FindControl("imgRestore"), Image)
            If objList.RestorePrivilege And tmpProp.IsDeleted = 1 And Not tmpProp.IsAdd Then
                imgRestore.Attributes.Add("OnClick", "UndeleteDetail(" + intTrxNo + ");return false;")
            Else
                imgRestore.Visible = False
            End If
            'Edit
            Dim imgEdit As Image = CType(e.Row.FindControl("imgEdit"), Image)
            If objList.EditPrivilege AndAlso tmpProp.IsDeleted = 0 AndAlso Not tmpProp.IsAdd Then
                imgEdit.Attributes.Add("OnClick", "EditDetail(" + intTrxNo + ",'" + strFun + "');return false;")
                e.Row.Attributes.Add("ondblclick", "EditDetail(" + intTrxNo + ",'" + strFun + "');return false;")
            Else
                imgEdit.Visible = False
            End If
            'Insert
            Dim imgInsert As Image = CType(e.Row.FindControl("imgInsert"), Image)
            If objList.NewPrivilege AndAlso tmpProp.IsAdd Then
                imgInsert.Attributes.Add("OnClick", "InsertDetail(" + hidFunNo.Value + ");return false;")
                e.Row.Attributes.Add("ondblclick", "InsertDetail(" + hidFunNo.Value + ");return false;")
            ElseIf tmpProp.IsAdd Then
                e.Row.Visible = False
            Else
                imgInsert.Visible = False
            End If
            If e.Row.RowIndex = objList.ArrProp.Count - 1 And objColumns.Column.Count > 0 Then
                e.Row.Cells(1).Text = ""
            End If
            '-----------------check new status-------------------------------------------------------------- 
            Dim ContainerNo As String = CType(tmpProp, clsPropctcl).ContainerNo.ToString()
            Dim State As String = CType(tmpProp, clsPropctcl).State.ToString()
            Dim EventDateTime As DateTime = CType(tmpProp, clsPropctcl).EventDate
            Dim NewState As String = ""
            Dim dtTime As DateTime
            Dim param(2) As SqlParameter
            Try
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                param(1) = New SqlParameter("@State", SqlDbType.NVarChar, 3)
                param(1).Direction = ParameterDirection.Output
                param(2) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                param(2).Direction = ParameterDirection.Output

                param(0).Value = ContainerNo
                'param(1).Value = State
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_check", param)
            Catch ex As Exception
            End Try
            NewState = param(1).Value.ToString
            If param(2).Value.ToString <> "" Then
                dtTime = DateTime.Parse(param(2).Value.ToString)
            End If
            If DateDiff(DateInterval.Minute, dtTime, EventDateTime) = 0 Then
                Select Case State
                    Case "GTO" 'Depot In
                        If NewState <> "GTO" Then
                            e.Row.Visible = False
                        End If
                    Case "BXD" 'GateOut
                        If NewState <> "BXD" Then
                            e.Row.Visible = False
                        End If
                    Case "BXL" 'Box Discharge
                        If NewState <> "BXL" Then
                            e.Row.Visible = False
                        End If
                    Case "GTI" 'Box Load
                        If NewState <> "GTI" Then
                            e.Row.Visible = False
                        End If
                    Case "DPO" 'Box Load
                        If NewState <> "DPO" Then
                            e.Row.Visible = False
                        End If
                End Select
            Else
                e.Row.Style.Add("display", "none")
            End If
            '------------------------------------------------------------------------------------------------
        End If
    End Sub

    Public Function CreateEvent(ByVal strTrxNo As String, ByVal strEvent As String, ByVal strEventDate As String, ByVal strVoyageNo As String) As String
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
        End If
        Dim strsql As String = ""
        If strTrxNo.Trim <> "" Then
            Dim intResult As Integer = 0
            strTrxNo = strTrxNo.Substring(0, strTrxNo.Length - 1)
            Dim strAdd As String = ""
            Dim VoyageFlag As String = ""
            If strVoyageNo.Trim <> "" Then
                VoyageFlag = "y"
            End If
            Dim strInt As String() = strTrxNo.Split(",")
            Dim ds As DataSet = Nothing
            Dim InsertFlag As String = ""
            Dim msg As String = ""
            For Each intTrx As Integer In strInt
                If IsNumeric(Integer.Parse(intTrx)) Then
                    Dim param(8) As SqlParameter
                    param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                    param(1) = New SqlParameter("@state", SqlDbType.NVarChar, 3)
                    param(2) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                    param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 12)
                    param(4) = New SqlParameter("@VoyageFlag", SqlDbType.NVarChar, 1)
                    param(5) = New SqlParameter("@InsertFlag", SqlDbType.NVarChar, 1)
                    param(5).Direction = ParameterDirection.Output
                    param(6) = New SqlParameter("@msg", SqlDbType.NVarChar, 13)
                    param(6).Direction = ParameterDirection.Output
                    param(7) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)
                    param(8) = New SqlParameter("@SiteCode", SqlDbType.NVarChar, 5)

                    param(0).Value = Integer.Parse(intTrx) 'TrxNo
                    param(1).Value = strEvent 'state
                    param(2).Value = GeneralFun.StringToDate(strEventDate) 'EventDate
                    param(3).Value = strVoyageNo 'VoyageN
                    param(4).Value = VoyageFlag 'VoyageNo
                    param(7).Value = objUser.UserId   'objUser
                    param(8).Value = objUser.SiteCode  'objUser
                    Try
                        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_ctcl1_EventUpdate", param)
                    Catch ex As Exception
                    End Try
                    InsertFlag = param(5).Value.ToString
                    If param(6).Value.ToString <> "" Then
                        msg += param(6).Value.ToString + vbNewLine
                    End If
                End If
            Next
            If msg = "" Then
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource) + ConSeparator.Par + "Save Success"
            Else
                msg = "Container (listed below) Event Date must be later than " + GeneralFun.StringToDate(strEventDate).ToString("dd-MMM-yyyy HH:mm") + "." + vbNewLine + msg
                Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "" + ConSeparator.Par + msg
            End If
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
    End Function
End Class
