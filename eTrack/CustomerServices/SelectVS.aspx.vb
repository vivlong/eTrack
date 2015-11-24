Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel

Partial Class SelectVS
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strbGroup As String = "-1"
    Private StrOninit As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        intPageIndex = intPage
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)
        If dtTmp.Rows.Count = 0 Then
            Return False
        End If
        dtTmplin = dtTmp
        Dim dv As DataView = dtTmp.DefaultView
        rpSource.DataSource = dv.ToTable(True, "PortofDischargeName")
        rpSource.DataBind()
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsVessualSchedule(intUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = ConSessionName.VessualSchedule
        'Me.MyGridView = gvwSource
        'Me.CurrentSortField = "JobNo"
        If Session("LoginType") = 0 Then
            Me.CurrentSortField = "PortofDischargeName"
        Else
            Me.CurrentSortField = "PortofDischargeName"
        End If
        Me.CurrentSortField = "Etd"
        Me.SortDesc = False

    End Sub

    Private Sub HandleLanguageRelative()
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Session("hid_voyageIDPass") = ""
        StrOninit = "N"
        If Not IsPostBack Then
            Dim strRow As String() = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting").Split(",")
            If Not strRow Is Nothing AndAlso strRow(0).Trim <> "" Then
                ConDbConn.selectDataBase = strRow(0)
            End If
            StrOninit = "Y"
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser, "unNeedValid") Then
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            'New Object
            objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            If Session("LoginType") = 0 Then
                Dim strWhere As String
                strWhere = SqlRelation.GetStringWhere("a.CustomerCode", objUser.UserId, 1)
                objList.Where = "" 'strWhere
            End If
            objList.OrderBy = "Etd"
            Dim strScript As String = ""
            If Request("port") IsNot Nothing Then
                If Request("port").ToString() <> "" Then
                    Dim port As String = Request("port").ToString()
                    If port.ToLower() <> "all" Then
                        objList.Where = " and PortofDischargeName='" + Request("port").ToString() + "'"
                        hidPod.Value = Request("port").ToString()
                    End If
                End If
            End If
            'Get First Page Data
            BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            HandleLanguageRelative()
            btnPrint.Attributes.Add("OnClick", ConPrintLimit.PrintButtonOnClick(99, GetType(clsVessualSchedule).AssemblyQualifiedName, TableName, 1, True))
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim str As String = StrOninit
        'e.Row.Font.Size = 3
        'add Color 
        e.Row.Cells(0).Style.Add("background-color", "#67A2F0")
        e.Row.Cells(2).Style.Add("background-color", "#67A2F0")
        e.Row.Cells(4).Style.Add("background-color", "#67A2F0")
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
            Dim i As Integer
            Dim tmpColumn As clsPropColumn
            For i = 0 To objColumns.Column.Count - 1
                tmpColumn = CType(objColumns.Column(i), clsPropColumn)
                If tmpColumn.FieldName.ToLower() = "voyageid" Then
                    Dim strVoyageID As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VoyageID"))
                    Session("hid_voyageIDPass") += "'" + strVoyageID + "'" + ","
                    If e.Row.RowIndex = dtTmplin.Rows.Count - 1 Then
                        e.Row.Visible = False
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub rpSource_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpSource.ItemDataBound
        Dim lblPOD As New Label
        lblPOD = e.Item.FindControl("lblPOD")
        Dim gvwSource As GridView = e.Item.FindControl("gvwSource")
        Dim dv As DataView = dtTmplin.DefaultView
        With dv
            .RowFilter = "PortofDischargeName = '" + DvRowFilter(lblPOD.Text) + "'"
            .Sort = "PortofDischargeName DESC"
        End With
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.Font.Size = 2
        gvwSource.DataSource = dv
        gvwSource.DataBind()
    End Sub
    Private Function DvRowFilter(ByVal rowFilter As String) As String

        Return rowFilter.Replace("[", "[[ ").Replace("]", " ]]").Replace("*", "[*]").Replace("%", "[%]").Replace("[[ ", "[[]").Replace(" ]]", "[]]").Replace("'", "''")

    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    Protected Sub btnToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls")
        Response.ContentType = "application/excel"
        Dim sw As StringWriter = New StringWriter()
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        rpSource.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
End Class
