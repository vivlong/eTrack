Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports System.Data.SqlClient

Partial Class ExportShipmentStatus
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
        If Not IsPostBack Then
            Dim strRow As String() = System.Configuration.ConfigurationManager.AppSettings("DataBaseSetting").Split(",")
            If Not strRow Is Nothing AndAlso strRow(0).Trim <> "" Then
                ConDbConn.selectDataBase = strRow(0)
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
                End If
                btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            End If
            BindByBLNo(fieldName, fieldValue, trxno)
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub
    Private Sub BindByBLNo(ByVal fieldName As String, ByVal fieldValue As String, ByVal trxno As String)
        Try
            Dim scriptSql As String = "select " & vbNewLine & _
            " a.BlNo" & vbNewLine & _
            ",VesselName" & vbNewLine & _
            ",VoyageNo" & vbNewLine & _
            ",PortOfLoadingName" & vbNewLine & _
            ",convert(char(20),EtdDate,20) EtdDate" & vbNewLine & _
            ",PortOfDischargeName" & vbNewLine & _
            ",convert(char(20),EtaDate,20) EtaDate" & vbNewLine & _
            ",convert(char(20),CargoReceiptDate,20) CargoReceiptDate" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='c/r') dtcr" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='c/s') dtcs" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='b/l') dtbl" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='c/a') dtca" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='d/o') dtdo" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='d/c') dtdc" & vbNewLine & _
            ",(select top 1 convert(varchar(100),[datetime], 103) [datetime] from jmjm3 where jobno=a.jobno and statuscode='c/c') dtcc" & vbNewLine & _
            ",a.containerNo " & vbNewLine & _
            ",c.sealNo " & vbNewLine & _
            ",a.JobNo " & vbNewLine & _
            "from sebl1 a " & vbNewLine & _
            "left join sebl2 c on a.TrxNo=c.TrxNo " & vbNewLine & _
            "where 1=1 "
            Dim strWhere As String = ""
            If trxno.Trim <> "" Then
                strWhere = String.Format(" and a.TrxNo ={0} ", trxno)
            Else
                If fieldName = "ContainerNo" Then
                    strWhere = String.Format(" and a.ContainerNo like ('%{0}%') ", fieldValue)
                ElseIf fieldName = "BookRefNo" Then
                    Dim strJobNo As String = Mid(fieldValue, 1, fieldValue.Length - 3)
                    Dim strSeqNo As String = Mid(fieldValue, fieldValue.Length - 2, 3)
                    Dim scriptSql2 As String
                    'Dim dt2 As DataTable
                    scriptSql2 = " Select a.BLNo from sebl1 a, sebk1 b where a.bookingno=b.bookingno and b.MasterJobNo like '" & strJobNo & "%' and b.BookingSeqNo ='" & strSeqNo & "' "
                    Dim dt2 As DataTable = BaseSelectSrvr.GetData(scriptSql2, "")
                    If dt2 IsNot Nothing And dt2.Rows.Count > 0 Then
                        strWhere = String.Format(" and a.{0}='{1}'", "BLNo", dt2.Rows(0)("BLNo"))
                    Else
                        strWhere = String.Format(" and a.{0}='{1}'", fieldName, fieldValue)
                    End If
                Else
                    strWhere = String.Format(" and a.{0}='{1}'", fieldName, fieldValue)
                End If
            End If
            scriptSql += strWhere
            Dim dt As DataTable = BaseSelectSrvr.GetData(scriptSql, "")
            If dt IsNot Nothing And dt.Rows.Count > 0 Then
                Dim dtETA As DateTime = Date.MinValue
                Dim dtETD As DateTime = Date.MinValue
                Dim dtRCD As DateTime = Date.MinValue
                Dim strETA As String = ""
                Dim strETD As String = ""
                Dim strRCD As String = ""
                If dt.Rows(0)("EtaDate").ToString() <> DBNull.Value.ToString() Then
                    dtETA = DateTime.Parse(dt.Rows(0)("EtaDate").ToString())
                    If dtETA <= ConDateTime.MinDate Then
                        strETA = ""
                    Else
                        strETA = dtETA.ToString("dd/MM/yyyy")
                    End If
                End If
                If dt.Rows(0)("EtdDate").ToString() <> DBNull.Value.ToString() Then
                    dtETD = DateTime.Parse(dt.Rows(0)("EtdDate").ToString())
                    If dtETD <= ConDateTime.MinDate Then
                        strETD = ""
                    Else
                        strETD = dtETD.ToString("dd/MM/yyyy")
                    End If
                End If
                If dt.Rows(0)("CargoReceiptDate").ToString() <> DBNull.Value.ToString() Then
                    dtRCD = DateTime.Parse(dt.Rows(0)("CargoReceiptDate").ToString())
                    If dtRCD <= ConDateTime.MinDate Then
                        strRCD = ""
                    Else
                        strRCD = dtRCD.ToString("dd/MM/yyyy")
                    End If
                End If
                lblHouseBLNumber.Text = dt.Rows(0)("BlNo")
                lblVslDetails.Text = dt.Rows(0)("VesselName") + "/" + dt.Rows(0)("VoyageNo")
                lblPortOfLoading.Text = dt.Rows(0)("PortOfLoadingName")
                lblETDPOL.Text = strETD
                lblPortofDischarge.Text = dt.Rows(0)("PortOfDischargeName")
                lblETAPOD.Text = strETA
                txtCargoRec.Text = strRCD
                txtCR.Text = dt.Rows(0)("dtcr").ToString()
                lblContainerNo.Text = dt.Rows(0)("containerNo").ToString()
                lblSEALNo.Text = dt.Rows(0)("sealNo").ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
