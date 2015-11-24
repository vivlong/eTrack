Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic

Class TypeSort
    Inherits ListEditPage
    Dim strMod As String = ""
    Private strTable As String = ""
    Private strOrder As String = ""
    Private strwhere As String = ""
    Private strCode As String = ""
    Private strName As String = ""
    Private showColumn1 As String = ""
    Private showColumn2 As String = ""
    Private showColumn3 As String = ""
    Private intTrxNo As Int64 = ConClass.NewIdValue
    Protected ConfigPath As String
    Protected ExportConfig As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        objList.GetListInfo(intPage, intSize)
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = objList.ArrProp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsContainerList(strUserId)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ContainerList"
        Me.MyGridView = gvwSource
        Me.ColumnFrom = ColumnFile.Sql
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "AirlineCode"
        Me.SortDesc = True
    End Sub
    Private Sub HandleLanguageRelative()
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst().Replace("EditWidth=", "EditWidth=null").Replace("EditHeight=", "EditHeight=null"))
    End Sub
    Private Sub GetRequestValue(ByVal objUser As clsUser)
        strTable = Request("table").ToString
        Dim arrfields As String() = Request("fields").ToString.Split(",")
        strCode = arrfields(0)
        strOrder = arrfields(0).Replace("distinct", "")
        strName = arrfields(1)
        strwhere = Request("where").ToString
        If strwhere.Trim <> "" Then
            strwhere = strwhere.Replace("~", "=")
            strwhere = strwhere.Replace("@@@", "'")
        Else
            strwhere = " 1=1 "
        End If
        Dim showName As String
        If Request("showName") IsNot Nothing Then
            showName = Request("showName").ToString
            Dim arrShowName As String() = showName.Split(",")
            If arrfields.Length > 2 Then
                showColumn1 = arrShowName(0)
                showColumn2 = arrShowName(1)
                showColumn3 = arrShowName(2)
            End If
        End If
        Dim strFields As String = Request("fields").ToString + ",State,EventDate "
        strTable = Request("table").ToString
        objList.Where = strwhere
        strOrder = strOrder.Replace("distinct", "")
        objList.OrderBy = strFields + "@" + strTable + "@" + strOrder
        Dim VesselName As String = ""
        If Request("VesselName") IsNot Nothing Then
            VesselName = Request("VesselName").ToString
            If VesselName.Trim() <> "" Then
                objList.Where += " and VesselName='" + VesselName + "' "
            End If
        End If
        Dim VoyageNo As String = ""
        If Request("VoyageNo") IsNot Nothing Then
            VoyageNo = Request("VoyageNo").ToString
            If VoyageNo.Trim() <> "" Then
                objList.Where += " and VoyageNo='" + VoyageNo + "' "
            End If
        End If
        objList.Where += " and ContainerNo not in (select ContainerNo from ctso2 where isnull(ReceiveDate,'')='')"
        objList.Where += " and SiteCode='" + objUser.SiteCode + "' "
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            hidTrxNo.Value = "-1"
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
            'New Object 
            objList = NewObjectList(objUser.UserId, objUser.RoleName, PageFun.GetFunNo(Page))
            objList.OrderBy = SqlRelation.GetOrderString(CurrentSortField, SortDesc)
            'get TrxNo
            If Request("TrxNo") IsNot Nothing Then
                hidTrxNo.Value = Request("TrxNo").ToString
            End If
            'Get First Page Data
            GetRequestValue(objUser)
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            btnSelectAll.Attributes.Add("OnClick", "SelectAll();return false;")
            btnClose.Attributes.Add("OnClick", "CloseWindow(0);return false;")
            'Language 
            HandleLanguageRelative()
            Me.Title = "Container List"
            Dim TruckerName As String = ""
            If Request("TruckerName") IsNot Nothing Then
                TruckerName = Request("TruckerName").ToString
            End If
            btnUpdate.Attributes.Add("OnClick", "UpdateContainer('st','" + hidTrxNo.Value + "','" + TruckerName + "');return false;")
        End If
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = showColumn1
            e.Row.Cells(1).Text = showColumn2
            e.Row.Cells(2).Text = showColumn3
            Dim hdTC As New TableCell
            hdTC.ID = "hdTC"
            e.Row.Cells.AddAt(0, hdTC)
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hdTC As New TableCell
            hdTC.ID = "CETC"
            Dim chk As New CheckBox
            chk.ID = "chkContainerNo"
            hdTC.Controls.Add(chk)
            e.Row.Cells.AddAt(0, hdTC)
            If e.Row.RowIndex = objList.ArrProp.Count - 1 Then
                e.Row.Visible = False
            End If
            'e.Row.Attributes.Add("OnClick", "ItemClick('" + e.Row.Cells(0).Text.Replace("'", "\'") + "','" + e.Row.Cells(1).Text.Replace("'", "\'") + "');return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
            '-----------------check new status-------------------------------------------------------------- 
            Dim tmpProp As clsProp = objList.ArrProp(e.Row.RowIndex)
            Dim ds As DataSet
            Dim ContainerNo As String = CType(tmpProp, clsPropContainerList).column1
            Dim State As String = CType(tmpProp, clsPropContainerList).State.ToString()
            Dim EventDateTime As DateTime = CType(tmpProp, clsPropContainerList).EventDate
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
            If DateDiff(DateInterval.Minute, dtTime, EventDateTime) <> 0 Then
                e.Row.Style.Add("display", "none")
            End If
            If NewState <> State Then
                e.Row.Style.Add("display", "none")
            End If
            If State <> "BXD" And State <> "GTO" Then
                e.Row.Style.Add("display", "none")
            End If
            If NewState <> "BXD" And NewState <> "GTO" Then
                e.Row.Style.Add("display", "none")
            End If
            'End If
            '------------------------------------------------------------------------------------------------
        End If
    End Sub
    Public Function UpdateContainer(ByVal ContainerList As String, ByVal TrxNo As String, ByVal TruckerName As String) As String
        Dim objUser As clsUser = Nothing
        Dim strMsg As String = ""
        Dim strSql As String = ""
        Dim intResult As Integer = -1
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            Dim arrContainer As String() = ContainerList.Split(",")
            If arrContainer.Length > 0 Then
                For Each ContainerNo As String In arrContainer
                    If ContainerNo.ToString <> "" Then
                        Dim dt As DataTable
                        Dim strSql2 As String = "select ContainerNo from rccf1 where ContainerNo='" + ContainerNo + "'"
                        dt = BaseSelectSrvr.GetData(strSql2, "")
                        If dt.Rows.Count = 0 Then
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO not exist in Container Master!" + ConSeparator.Par + Me.intPageCount.ToString
                        End If
                        strSql2 = "select ContainerNO from ctso2 where ContainerNO='" + ContainerNo + "' and isnull(ReceiveBatchNo,'')='' "
                        dt = BaseSelectSrvr.GetData(strSql2, "")
                        If dt.Rows.Count > 0 Then
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and not be release!" + ConSeparator.Par + Me.intPageCount.ToString
                        End If
                        dt = BaseSelectSrvr.GetData("select * from ctso2 where TrxNo=" + TrxNo + " and ContainerNO='" + ContainerNo + "'", "")
                        If dt.Rows.Count < 1 Then
                            strSql = " insert into ctso2(TrxNo,LineItemNo,ContainerNo,TruckerName) values (" + TrxNo + "," + getLineItemNo(TrxNo) + ",'" + ContainerNo + "','" + TruckerName + "')"
                            intResult += SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, strSql)
                        Else
                            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Container NO has exist and it not can't not be the same!"
                        End If
                    End If
                Next
                If intResult >= 0 Then
                    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + "Save Success."
                Else
                    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Save false."
                End If
            End If
            'If Not FDeleteCTRO2(strTrxNo, strLineItemNo, ContainerNo, "") Then
            '    Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Can't delete the record."
            'Else
            '    'Omtx3 Details...
            '    BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            '    Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            'End If
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Update false."
        Else
            Return ZZMessage.ConMsgRtn.TimeOut + ConSeparator.Par + ZZMessage.ConMsgInfo.TimeOut
        End If
    End Function
    Private Function getLineItemNo(ByVal TrxNo As String) As String
        Dim strLineItemNo As String = ""
        Dim dt As DataTable
        Try
            dt = BaseSelectSrvr.GetData("select max(LineItemNo)+1 as LineItemNo from ctso2 where TrxNo=" + TrxNo, "")
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("LineItemNo").ToString.Trim <> "" Then
                        strLineItemNo = dt.Rows(0)("LineItemNo").ToString.Trim
                    End If
                End If
            End If
            If strLineItemNo <> "" Then
                Return strLineItemNo
            Else
                Return "1"
            End If
        Catch ex As Exception
            Return "1"
        End Try
    End Function
End Class
