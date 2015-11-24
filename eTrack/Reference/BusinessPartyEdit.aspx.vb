Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Reflection

Partial Class BusinessPartyEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsBusinessParty
    Private objColumns As colColumn
    Private returnValue As String
    Private m_blnSplitWR As Boolean
    Private m_blnExternal As Boolean
    Private m_blnClose As Boolean
    Private m_blnStatusCode As Boolean
    Private strModuleCode As String = ""
    'Dim objExport As ExportToExcel.ExcelExport
    Private strBusinessPartyCode As String = ConClass.NewIdValue.ToString

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
        Return New clsBusinessParty(intUserId)
    End Function
    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function
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
            Else
                If strVal.ToString("HH:mm") = "00:00" Then
                    con.Text = strVal.ToString("dd/MM/yyyy")
                Else
                    con.Text = strVal.ToString("dd/MM/yyyy HH:mm")
                End If
            End If
        Else
            con.Text = ""
        End If
    End Sub
    Private Sub BindDetailData(ByVal intUserId As String, ByVal strBusinessPartyCode As String)
        objServer = NewServerObject(intUserId)
        If strBusinessPartyCode <> "" Then
            Dim tmpProp As clsPropBusinessParty = objServer.GetDetail(strBusinessPartyCode)
            If tmpProp.BusinessPartyCode = "" Then
                strBusinessPartyCode = GetNewId().ToString
                tmpProp.TrxNo = strBusinessPartyCode
            End If
            txtBusinessPartyCode.Text = tmpProp.BusinessPartyCode
            BindSourceData(tmpProp.BusinessPartyCode.Trim)
            txtPartyType.Text = tmpProp.PartyType
            txtCustomerCode.Text = tmpProp.CustomerCode
            txtCustomerName.Text = ""
            txtVendorCode.Text = tmpProp.VendorCode
            txtVendorName.Text = ""
            txtCurrencyCode.Text = tmpProp.CurrCode
            txtCurrencyName.Text = ""
            txtTermCode.Text = tmpProp.TermCode
            txtTermName.Text = ""
            txtOnHold.Text = ""
            txtBusinessPartyName.Text = tmpProp.BusinessPartyName
            txtlocalName.Text = tmpProp.LocalName
            txtAddress1.Text = tmpProp.Address1
            txtAddress2.Text = tmpProp.Address2
            txtAddress3.Text = tmpProp.Address3
            txtAddress4.Text = tmpProp.Address4
            txtPostalCode.Text = tmpProp.PostalCode
            txtCityCode.Text = tmpProp.CityCode
            txtlblCountryCode.Text = tmpProp.CountryCode
            txtTelephone.Text = tmpProp.Telephone
            txtFax.Text = tmpProp.Fax
            txtEmail.Text = tmpProp.Email
            txtWebSite.Text = tmpProp.WebSite
            txtTelex.Text = tmpProp.Telex

            txtSalesmanCode.Text = tmpProp.SalesmanCode
            txtCR.Text = tmpProp.CrNo + ""
            Me.Title = "BusinessParty Info"
            btnInternetPassword.Attributes.Add("OnClick", "UpdatePassword('" + strBusinessPartyCode + "','" + tmpProp.Password + "');return false;")
        Else
            Me.Title = "BusinessParty Info"
        End If
    End Sub

    Protected Sub BindSourceData(ByVal strbusinesscode As String)
        If strbusinesscode.Trim <> "" Then
            Dim strSql As String = "select * from rcbp3 where businesspartycode='" + strbusinesscode + "'"
            Dim dtTmp As DataTable
            dtTmp = BaseSelectSrvr.GetData(strSql, "")
            objColumns = DynamicGridViewFun.GetColumnFromXmlFile("ContactInof", gvwSource, TemplateType.None)
            If dtTmp.Rows.Count <= 0 Then
                dtTmp.Rows.Add(New TableCell())
                gvwSource.DataSource = dtTmp
                gvwSource.DataBind()
                gvwSource.Rows(0).Visible = False
            Else
                gvwSource.DataSource = dtTmp
                gvwSource.DataBind()
            End If
            gvwSource.Width = 570
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
#End Region
#Region "public"
    Private Sub SetInitValue(ByVal intUserId As String)
        'set control hid
        Dim ListItemSelect As String = CStr(GetGlobalResourceObject("Common", "ListItemSelect"))
        Dim strwhere As String = ""
        If Request("Id") = Nothing Then
            strwhere = ""
        End If
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
            divlblCustomerCode.Style.Add("display", "none")
            divlbVendorCode.Style.Add("display", "none")

            divtxtTelex.Style.Add("display", "none")
            divlblPostalCode.Style.Add("display", "none")
            'Set Default Value
            SetInitValue(objUser.UserId)
            If Not (Request("Id") Is Nothing) Then
                Dim state As String = Request("Id").ToString
                strBusinessPartyCode = Request("Id").ToString()
            End If
            BindDetailData(objUser.UserId, strBusinessPartyCode)
            'Button Event 
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    Private Function getTrxNo() As String
        Dim strTrxNo As String = ""
        Dim dtReclzw As DataTable
        dtReclzw = BaseSelectSrvr.GetData("select max(TrxNo) as TrxNo from omtx1", "")
        strTrxNo = dtReclzw.Rows(0)("TrxNo")
        Return strTrxNo
    End Function
#End Region
End Class
