Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel

Partial Class TranshipmentTrack
    Inherits QueryPage
    Private dtTmplin As DataTable
    Private strbGroup As String = "-1"
    Private StrOninit As String
    Protected Overrides Function BindSourceData(ByVal intUserId As String, ByVal intPage As Integer, ByVal intSize As Integer) As Boolean
        Return True
    End Function
    Protected Overrides Function NewObjectList(ByVal intUserId As String, ByVal strFunNo As String) As clsList
        Return New clsVessualSchedule_Sebl1(intUserId)
    End Function

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
    Private Sub SetInitValue(ByVal intUserId As String)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
            Dim trxno As String = ""
            Dim fieldName As String = ""
            Dim fieldValue As String = ""
            If Request("trxno") IsNot Nothing Then
                trxno = Request("trxno").ToString()
            Else
                If Request("fieldName") IsNot Nothing And Request("fieldValue") IsNot Nothing Then
                    fieldName = Request("fieldName").ToString()
                    fieldValue = Request("fieldValue").ToString()
                ElseIf Request("ContainerNo") IsNot Nothing Then
                    fieldName = "ContainerNo"
                    fieldValue = Request("ContainerNo").ToString()
                End If
            End If
            BindByBLNo(fieldName, fieldValue, trxno)
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If

    End Sub
    Public Origin As String = ""
    Public ETA As String = ""
    Public House As String = ""
    Public Booking As String = ""
    Public Connecting As String = ""
    Public ETD As String = ""
    Public ETAPOD As String = ""
    Public Final As String = ""
    Public Delivery As String = ""
    Private Sub BindByBLNo(ByVal fieldName As String, ByVal fieldValue As String, ByVal trxno As String)
        Try
            Dim sbSql As New StringBuilder()
            sbSql.Append("select BlNo,a.VesselName+' / '+ a.VoyageNo VesselVoyage ")
            sbSql.Append(",convert(varchar(100),a.EtaDate, 103) ETASingapore")
            sbSql.Append(",a.ExportBookingNo")
            sbSql.Append(" from Sibl1 a where a.TranshipmentFlag='Y' ")
            Dim strWhere As String = ""
            If trxno.Trim <> "" Then
                strWhere = String.Format(" and TrxNo ={0} ", trxno)
            Else
                If fieldName = "ContainerNo" Then
                    strWhere = String.Format(" and ContainerNo like ('%{0}%') ", fieldValue)
                Else
                    strWhere = String.Format(" and {0}='{1}'", fieldName, fieldValue)
                End If
            End If
            sbSql.Append(strWhere)
            Dim dt As DataTable = BaseSelectSrvr.GetData(sbSql.ToString(), "")
            Dim ExportBookingNo As String = ""
            Dim strBlNo As String = ""
            If dt IsNot Nothing And dt.Rows.Count > 0 Then
                txtOrigin.Text = dt.Rows(0)("VesselVoyage").ToString()
                txtETA.Text = dt.Rows(0)("ETASingapore").ToString()
                strBlNo = dt.Rows(0)("BlNo").ToString()
                ExportBookingNo = dt.Rows(0)("ExportBookingNo").ToString()
                If fieldName = "ContainerNo" Then
                    Dim i As Integer
                    For i = 1 To dt.Rows.Count - 1
                        ExportBookingNo = ExportBookingNo & "," & dt.Rows(i)("ExportBookingNo").ToString()
                    Next

                End If
                '-------------------------------------
            End If
            Dim sbSql1 As New StringBuilder()
            sbSql1.Append("select ")
            If fieldName = "ContainerNo" Then
                sbSql1.Append("i.BlNo ")
            Else
                sbSql1.Append(String.Format("'{0}' as BlNo ", strBlNo))
            End If
            'sbSql1.Append(String.Format("'{0}' as BlNo ", strBlNo))
            sbSql1.Append(",c.CityName ")
            sbSql1.Append(",b.VesselName +' / '+b.VoyageNo as VesselName")
            sbSql1.Append(",convert(varchar(100),b.EtdDate, 103) EtdDate ")
            sbSql1.Append(",convert(varchar(100),b.EtaDate, 103) EtaDate ")
            sbSql1.Append(",isnull(s.ContainerSealNoType,'') ContainerSealNoType ")
            sbSql1.Append(",b.DeliveryAgentName ")
            sbSql1.Append(",b.BookingNo as ExportBookingNo ")
            sbSql1.Append(" from sebk1 b ")
            sbSql1.Append(" left Join rcct1 c on b.DestCode=c.CityCode left join sebl1 s on b.BookingNo=s.BookingNo")
            If fieldName = "ContainerNo" Then
                sbSql1.Append(" left join sibl1 i on b.BookingNo = i.ExportBookingNo and i.TranshipmentFlag='Y' and i.ContainerNo like ('%" & fieldValue & "%')  ")
            End If
            sbSql1.Append(String.Format(" where b.BookingNo in ('{0}')", IIf(ExportBookingNo.IndexOf(",") > 0, ExportBookingNo.Replace(",", "','").Replace("''", "'"), ExportBookingNo))) 'charindex(b.BookingNo,'{0}')>0
            Dim dt2 As DataTable = BaseSelectSrvr.GetData(sbSql1.ToString(), "")
            If IsNothing(dt2) Then
                Dim strField As String
                strField = vbCrLf & "rcct1.CityName"
                strField = strField & vbCrLf & "sebk1.VesselName" & vbCrLf & "sebk1.EtdDate" & vbCrLf & "sebk1.EtaDate" & vbCrLf & "sebk1.DeliveryAgentName" & vbCrLf & "sebk1.ExportBookingNo"
                strField = strField & vbCrLf & "sebl1.ContainerSealNoType"
                MsgBox("One or more fields are not found in table. Please check the following fields:" & strField, , "dt2 is Nothing")
            End If
            If dt2 IsNot Nothing And dt2.Rows.Count > 0 Then
                rptSource.DataSource = dt2
                rptSource.DataBind()
            Else
                dt2.Rows.Add(dt2.NewRow())
                rptSource.DataSource = dt2
                rptSource.DataBind()
                rptSource.Items(0).Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
