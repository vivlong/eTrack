Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Class MoutiExportShipmentStatus
    Inherits ListEditPage
    Dim containerNo As String = ""

    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        GetRequestValue()
        Dim dt As DataTable
        Dim strSql As String = String.Format("select TrxNo,ContainerNo " & _
                                             ",PortOfLoadingCode " & _
                                             ",PortofDischargeCode " & _
                                             ",convert(char(10),EtdDate,20) EtdDate " & _
                                             ",convert(char(10),EtaDate,20) EtaDate " & _
                                             " from Sebl1 a where a.ContainerNo like ('%{0}%') ", containerNo)
        Try
            dt = BaseSelectSrvr.GetData(strSql, "")
            gvwSource.DataSource = dt
            gvwSource.DataBind()
        Catch ex As Exception
        End Try
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String) As clsBaseSrv
        Return New clsTypeSort(strUserId)
    End Function
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
    Private Sub GetRequestValue()
        If (Request("containerno") IsNot Nothing) Then
            containerNo = Request("containerno").ToString()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Dim objUser As clsUser = Nothing
            BindSourceData(-1, 1, -1)
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        e.Row.Cells(0).Style.Add("display", "none")
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnClick", "ItemClick('" + e.Row.Cells(0).Text.Replace("'", "\'") + "');return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
            End If
        End If
    End Sub
End Class
