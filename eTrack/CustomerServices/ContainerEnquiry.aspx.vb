Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel

Partial Class ContainerEnquiry
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strbGroup As String = "-1"
    Private StrOninit As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)
        dtTmplin = dtTmp
        Dim dv As DataView = dtTmp.DefaultView
        Dim strColumnName As String = ""
        For i As Integer = 0 To dv.ToTable.Columns.Count - 1
            If dv.ToTable.Columns(i).ColumnName.ToLower = "PortofDischargeCode".ToLower Then
                strColumnName = dv.ToTable.Columns(i).ColumnName
                Exit For
            End If
        Next
        If strColumnName <> "" Then
            rpSource.DataSource = dv.ToTable(True, strColumnName)
        Else
            rpSource.DataSource = dv.ToTable
        End If
        rpSource.DataBind()
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsContainerEnquiry_Sebl1_Sibl1(intUserId)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "ContainerEnquiry_Sebl1_Sibl1"
        Me.MyRepeater = rpSource
        Me.CurrentSortField = "ContainerNo"
        Me.SortDesc = False
    End Sub
    Private Sub HandleLanguageRelative()
        btnSearch.Text = CStr(GetGlobalResourceObject("PageList", "Search"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub
    Private Sub SetInitValue(ByVal intUserId As String)
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        'Search        
        'From 
        'To
        Dim dtRec As DataTable
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            If Not PageFun.GetCurrentUserInfo(Page, objUser, "unNeedValid") Then
            End If
        End If
        Dim strPortOfDischargeCodeSe As String = ""
        Dim strPortOfDischargeCodeSi As String = ""
        dtRec = BaseSelectSrvr.GetData("Select [Port Code],[City Code],[Country Code] from vw_rcbp1 Where [Business Party Code] = '" + Replace(objUser.UserId, "'", "''") + "' ", "")
        If Not dtRec Is Nothing AndAlso dtRec.Rows.Count > 0 Then
            objUser.PortOfDischargeCode = dtRec.Rows(0).Item(0).ToString.Trim
            If objUser.PortOfDischargeCode.Trim <> "" Then
                objUser.PortOfDischargeCode = objUser.PortOfDischargeCode.Replace("'", "''")
            Else
                objUser.PortOfDischargeCode = dtRec.Rows(0).Item("Country Code").ToString.Trim & dtRec.Rows(0).Item("City Code").ToString.Trim
                objUser.PortOfDischargeCode = objUser.PortOfDischargeCode.Replace("'", "''")
            End If
            fldPortofDischargeCode.Value = objUser.PortOfDischargeCode
        End If
        Dim strSql As String = "Select distinct ContainerNo From (Select Sebl2.ContainerNo from Sebl2 Join Sebl1 on sebl1.TrxNo = Sebl2.TrxNo" & _
                               " where Sebl2.ContainerNo is not null and Sebl2.ContainerNo<>'' AND Sebl1.StatusCode <> 'DEL' " & _
                               " AND Sebl1.PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' " & _
                               ") a Order by a.ContainerNo"
        'Union All Select Sibl2.ContainerNo from Sibl2 Join Sibl1 on sibl1.TrxNo = Sibl2.TrxNo" & _
        '" where Sibl2.ContainerNo is not null and Sibl2.ContainerNo<>'' AND Sibl1.StatusCode <> 'DEL'" & _
        '" AND Sibl1.PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' " & _
        ' " 
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drContainerNo.DataSource = dtRec
            drContainerNo.DataTextField = "ContainerNo"
            drContainerNo.DataValueField = "ContainerNo"
            drContainerNo.DataBind()
            drContainerNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drContainerNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        'strSql = "Select distinct MasterJobNo from jmjm1 Where (ModuleCode = 'SE' OR ModuleCode = 'SI') AND StatusCode <> 'DEL' AND StatusCode <> 'CLS' AND PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' AND not MasterJobNo is null AND MasterJobNo <> ''  Order By MasterJobNo  "
        strSql = "Select distinct MasterJobNo from Sebl1 Where StatusCode <> 'DEL' AND StatusCode <> 'CLS' AND PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' AND not MasterJobNo is null AND MasterJobNo <> ''  Order By MasterJobNo  "
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drMasterJobNo.DataSource = dtRec
            drMasterJobNo.DataTextField = "MasterJobNo"
            drMasterJobNo.DataValueField = "MasterJobNo"
            drMasterJobNo.DataBind()
            drMasterJobNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drMasterJobNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        'strSql = "Select distinct MAwbOblNo from jmjm1 Where (ModuleCode = 'SE' OR ModuleCode = 'SI') AND StatusCode <> 'DEL' AND StatusCode <> 'CLS' AND PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' AND not MAwbOblNo is null AND MAwbOblNo <> ''  Order By MAwbOblNo "
        strSql = "Select distinct OblNo from Sebl1 Where StatusCode <> 'DEL' AND StatusCode <> 'CLS' AND PortOfDischargeCode = '" & objUser.PortOfDischargeCode & "' AND not OblNo is null AND OblNo <> ''  Order By OblNo "
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drOBLNo.DataSource = dtRec
            drOBLNo.DataTextField = "OblNo"
            drOBLNo.DataValueField = "OblNo"
            drOBLNo.DataBind()
            drOBLNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drOBLNo.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        strSql = "Select VesselName from Rcvs1 Where StatusCode <> 'DEL' AND not VesselName is null AND VesselName <> '' Order By VesselName"
        dtRec = BaseSelectSrvr.GetData(strSql, "")
        If dtRec.Rows.Count > 0 Then
            drVesselName.DataSource = dtRec
            drVesselName.DataTextField = "VesselName"
            drVesselName.DataValueField = "VesselName"
            drVesselName.DataBind()
            drVesselName.Items.Insert(0, New ListItem(ListItemSelect, ""))
        Else
            drVesselName.Items.Insert(0, New ListItem(ListItemSelect, ""))
        End If
        drCargoStatusCode.Items.Insert(0, New ListItem("EXP", "EXP"))
        drCargoStatusCode.Items.Insert(1, New ListItem("CMP", "CMP"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        StrOninit = "N"
        If Not IsPostBack Then
            StrOninit = "Y"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                If Not PageFun.GetCurrentUserInfo(Page, objUser, "unNeedValid") Then
                End If
            End If
            SetInitValue(objUser.UserId)
            fldCustomerCode.Value = objUser.UserId
            objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            If Session("LoginType") = 0 Then
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.CustomerCode", objUser.UserId, 1)
                objList.Where = ""
                objList.OrderBy = ""
                fldLoginType.Value = 0
            ElseIf Session("LoginType") = 3 Then '20151111
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.ConsigneeCode", objUser.UserId, 1)
                objList.Where = ""
                objList.OrderBy = ""
                fldLoginType.Value = 3
            Else
                objList.OrderBy = ""
                fldLoginType.Value = 1
            End If
            objList.Where = " and a.PortofDischargeCode = '" + fldPortofDischargeCode.Value.Trim() + "' AND (a.CargoStatusCode is null OR (a.CargoStatusCode != 'CMP' AND a.CargoStatusCode != 'INB')) "
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            btnSearch.Attributes.Add("OnClick", "GetVesuslQueryResult();return false;")
            btnToExcel.Attributes.Add("OnClick", ConExportExcel.ExcelButtonOnClick(objUser.PagePara.QuerySize, True))
            HandleLanguageRelative()
        End If
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim str As String = StrOninit
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim intType, intTrxNo, intLineItemNo As Integer
            Dim strContainerKey As String = ""
            Try
                strContainerKey = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TableName"))
                If strContainerKey.ToLower = "sebl2" Then
                    intType = 1
                Else
                    intType = 2
                End If
                intTrxNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TrxNo"))
                intLineItemNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LineItemNo"))
            Catch ex As Exception
                ex.Data.Clear()
                strContainerKey = ""
            End Try
            If strContainerKey <> "" Then
                Session("hid_voyageIDPass") += "'" + strContainerKey + "'" + ","
                e.Row.Attributes.Add("ondblclick", "ContainerDetail(" + intType.ToString + "," + intTrxNo.ToString + "," + intLineItemNo.ToString + ");return false;")
            End If
        End If
    End Sub
    Protected Sub rpSource_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpSource.ItemDataBound
        Dim gvwSource As GridView = e.Item.FindControl("gvwSource")
        Dim dv As DataView = dtTmplin.DefaultView
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = dv
        gvwSource.DataBind()
    End Sub
    Private Function DvRowFilter(ByVal rowFilter As String) As String
        Return rowFilter.Replace("[", "[[ ").Replace("]", " ]]").Replace("*", "[*]").Replace("%", "[%]").Replace("[[ ", "[[]").Replace(" ]]", "[]]").Replace("'", "''")
    End Function
End Class
