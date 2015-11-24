Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports SysMagic

Partial Class ExportBookingSelect
    Inherits QueryPage
    Dim strMod As String = ""
    Private dtTmplin As DataTable
    Private StrOninit As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return False
        End If
        intPageIndex = intPage
        objList.OrderBy = "EtdDate"
        Dim dtTmp As DataTable = objList.GetPageList(intPage, intSize)
        dtTmplin = dtTmp
        objColumns = DynamicGridViewFun.GetColumnFromXmlFile(TableName, gvwSource, TemplateType.None)
        gvwSource.DataSource = dtTmp
        gvwSource.DataBind()
        intPageCount = objList.PageCount
        Return True
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Me.TableName = "VesselSchedule_Sebk1"
        Me.MyGridView = gvwSource
        Dim blnExternalFlag As Boolean = False
        Dim blnWRFlag As Boolean = False
        Me.CurrentSortField = "EtdDate"
        Me.SortDesc = False
    End Sub
    Private Sub HandleLanguageRelative()
        lblPage.Text = CStr(GetGlobalResourceObject("PageList", "Page")) _
            + intPageIndex.ToString() _
            + CStr(GetGlobalResourceObject("PageList", "PageSeparator")) _
            + intPageCount.ToString()
        lbtnFirst.Text = CStr(GetGlobalResourceObject("PageList", "First"))
        lbtnPrior.Text = CStr(GetGlobalResourceObject("PageList", "Prior"))
        lbtnNext.Text = CStr(GetGlobalResourceObject("PageList", "Next"))
        lbtnLast.Text = CStr(GetGlobalResourceObject("PageList", "Last"))
        lbtnGoTo.Text = CStr(GetGlobalResourceObject("PageList", "Goto"))
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "", GetJavascriptLanguageConst())
    End Sub
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsExportBookingSelect(intUserId)
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        StrOninit = "N"
        If Not IsPostBack Then
            StrOninit = "Y"
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If

            'New Object
            objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            'Get First Page Data
            'BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
            'Assign Page Event and Relative Value 
            lbtnFirst.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',0);return false;")
            lbtnPrior.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',1);return false;")
            lbtnNext.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',2);return false;")
            lbtnLast.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',3);return false;")
            lbtnGoTo.Attributes.Add("OnClick", "javascript:GetPageData('txtPage',4);return false;")
            txtPage.Text = intPageIndex.ToString()
            txtPage.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetPageData('txtPage',4); return false;}")
            txtPage.Attributes.Add("OnKeyPress", "NumberInput(event,0);")
            drpSearch.Attributes.Add("onchange", "SelectByPod();return false;")
            'Language 
            HandleLanguageRelative()
            BinInitControl()

            'Set First Focused Control 
        End If
    End Sub
    Private Sub BinInitControl()
        'blind drPort
        Dim scriptPort As String = "select " & _
" distinct (select PortName from rcsp1 where PortCode=a.PortOfDischargeCode) PortOfDischargeName " & _
" from sebl1 a" & _
" where isnull(PortOfDischargeName,'')!=''" & _
" Order by PortOfDischargeName "
        Try
            Dim dt As DataTable = BaseSelectSrvr.GetData(scriptPort, "")
            If dt IsNot Nothing And dt.Rows.Count > 0 Then
                drpSearch.DataSource = dt
                drpSearch.DataTextField = "PortOfDischargeName"
                drpSearch.DataValueField = "PortOfDischargeName"
                drpSearch.DataBind()
                drpSearch.Items.Insert(0, New ListItem("All", "All"))
                drpSearch.Items.Insert(0, New ListItem("", ""))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim str As String = StrOninit
        e.Row.Cells(0).Visible = False
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim script As String = String.Format("setValue_EB('{0}'); return false;", e.Row.Cells(0).Text.Trim())
            e.Row.Attributes.Add("ondblclick", script)
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
                    If e.Row.RowIndex = dtTmplin.Rows.Count Then
                        e.Row.Cells(0).Text = ""
                        e.Row.Cells(1).Text = ""
                        e.Row.Cells(2).Text = ""
                        e.Row.Cells(3).Text = ""
                    End If
                End If
            Next
        End If
    End Sub
    Private Function ConvertDateTime(ByVal strVal As DateTime) As String
        If strVal.ToString <> "" Then
            If strVal.ToString("yyyy-MM-dd") = "1981-01-01" Or strVal.ToString("yyyy-MM-dd") = "0001-01-01" Then
                Return ""
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    Return strVal.ToString("dd/MM/yyyy")
                Else
                    Return strVal.ToString("dd/MM/yyyy HH:mm")
                End If
            End If
        Else
            Return ""
        End If
    End Function

    Public Function SelectByPod(ByVal strPOD As String) As String
        'Judge Login or not
        Dim objUser As clsUser = Nothing
        If strPOD <> "" Then
            If PageFun.GetCurrentUserInfo(Page, objUser) Then
                'New Object
                objList = NewObjectList(objUser.UserId, PageFun.GetFunNo(Page))
                btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
                'Get First Page Data
                If strPOD.ToLower() <> "all" Then
                    objList.Where = String.Format(" and PortOfDischargeName='{0}'", strPOD)
                Else
                    objList.Where = ""
                End If
                BindSourceData(objUser.UserId, 1, objUser.PagePara.InfoSize)
                Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + GridViewFun.RenderControl(gvwSource)
            End If
        End If
        Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + "Search false;"
    End Function
End Class
