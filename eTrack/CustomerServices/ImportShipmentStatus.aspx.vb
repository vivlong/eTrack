Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic.ExportExcel
Imports System.Data.SqlClient

Partial Class ImportShipmentStatus
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

        'hide unwanted rows
        trCR.Style.Add("display", "none")
        trDO.Style.Add("display", "none")
        trCA.Style.Add("display", "none")

        '<-- change row label
        Dim strLbl As String = ""

        'Cargo unstuffed from Container at CFS
        strLbl = ""
        strLbl = ConfigurationManager.AppSettings.Item("ImpShipment_Label14")
        If strLbl Is Nothing = False Then
            Label14.Text = strLbl
        End If
        'B/L ready for Collection
        strLbl = ""
        strLbl = ConfigurationManager.AppSettings.Item("ImpShipment_Label4")
        If strLbl Is Nothing = False Then
            Label4.Text = strLbl
        End If
        'Delivery Order collected by Consignee
        strLbl = ""
        strLbl = ConfigurationManager.AppSettings.Item("ImpShipment_Label6")
        If strLbl Is Nothing = False Then
            Label6.Text = strLbl
        End If
        'Cargo collect by Consignee
        strLbl = ""
        strLbl = ConfigurationManager.AppSettings.Item("ImpShipment_Label16")
        If strLbl Is Nothing = False Then
            Label16.Text = strLbl
        End If

        'change row label-->

    End Sub
    Private Sub BindByBLNo(ByVal fieldName As String, ByVal fieldValue As String, ByVal trxno As String)
        Try

            Dim scriptSql As String = "select " & vbNewLine & _
            " BlNo" & vbNewLine & _
            ",VesselName" & vbNewLine & _
            ",VoyageNo" & vbNewLine & _
            ",PortOfLoadingName" & vbNewLine & _
            ",convert(char(20),EtdDate,20) EtdDate" & vbNewLine & _
            ",PortOfDischargeName" & vbNewLine & _
            ",convert(char(20),EtaDate,20) EtaDate" & vbNewLine & _
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
            "from sibl1 a " & vbNewLine & _
            "left join sibl2 c on a.TrxNo=c.TrxNo " & vbNewLine & _
            "where 1=1 "
            Dim strWhere As String = ""
            If trxno.Trim <> "" Then
                strWhere = String.Format(" and a.TrxNo ={0} ", trxno)
            Else
                If fieldName = "ContainerNo" Then
                    strWhere = String.Format(" and a.ContainerNo like ('%{0}%') ", fieldValue)
                Else
                    strWhere = String.Format(" and a.{0}='{1}'", fieldName, fieldValue)
                End If
            End If
            scriptSql += strWhere

            '--- check sibl1 column to replace txtDC & txtCC - 20140910
            Dim scriptSql2 As String
            Dim blnDC As Boolean = False
            Dim blnCC As Boolean = False
            Dim strDC2 As String = ""
            Dim strCC2 As String = ""
            Dim i As Integer
            Dim dt2 As DataTable
            scriptSql2 = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Sibl1' AND COLUMN_NAME in ('DeliveryOrderReleaseDate','CargoCollectionDate')"
            dt2 = BaseSelectSrvr.GetData(scriptSql2, "")
            If dt2 IsNot Nothing And dt2.Rows.Count > 0 Then
                For i = 0 To dt2.Rows.Count - 1
                    Select Case dt2.Rows(i)("COLUMN_NAME").ToString.ToUpper
                        Case "DeliveryOrderReleaseDate".ToUpper
                            blnDC = True
                        Case "CargoCollectionDate".ToUpper
                            blnCC = True
                    End Select
                Next
            End If

            If blnDC = True Then
                scriptSql2 = "select convert(varchar(100),[DeliveryOrderReleaseDate], 103) as dtDC, * from sibl1 a where  1=1 " + strWhere
                dt2 = BaseSelectSrvr.GetData(scriptSql2, "")
                If dt2 IsNot Nothing And dt2.Rows.Count > 0 Then
                    strDC2 = dt2.Rows(0)("dtDC").ToString()
                End If
            End If
            If blnCC = True Then
                scriptSql2 = "select convert(varchar(100),[CargoCollectionDate], 103) as dtCC, * from sibl1 a where  1=1 " + strWhere
                dt2 = BaseSelectSrvr.GetData(scriptSql2, "")
                If dt2 IsNot Nothing And dt2.Rows.Count > 0 Then
                    strCC2 = dt2.Rows(0)("dtCC").ToString()
                End If
            End If

            'check sibl1 column to replace txtDC & txtCC - 20140910 --


            Dim dt As DataTable = BaseSelectSrvr.GetData(scriptSql, "")
            If dt IsNot Nothing And dt.Rows.Count > 0 Then
                Dim dtETA As DateTime = Date.MinValue
                Dim dtETD As DateTime = Date.MinValue
                Dim strETA As String = ""
                Dim strETD As String = ""
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
                lblHouseBLNumber.Text = dt.Rows(0)("BlNo")
                lblVslDetails.Text = dt.Rows(0)("VesselName") + "/" + dt.Rows(0)("VoyageNo")
                lblPortOfLoading.Text = dt.Rows(0)("PortOfLoadingName")
                lblETDPOL.Text = strETD
                lblPortofDischarge.Text = dt.Rows(0)("PortofDischargeName")
                lblETAPOD.Text = strETA
                '/////////////////////////
                txtCR.Text = dt.Rows(0)("dtcr").ToString()
                txtCS.Text = dt.Rows(0)("dtcs").ToString()
                txtBL.Text = dt.Rows(0)("dtbl").ToString()
                txtCA.Text = dt.Rows(0)("dtca").ToString()
                txtDO.Text = dt.Rows(0)("dtdo").ToString()

                '//////////get dc/////////
                Dim strDC As String = ""
                Dim strJobNo As String = dt.Rows(0)("JobNo").ToString()
                If strJobNo.Trim <> "" Then
                    Dim param(1) As SqlParameter
                    param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                    param(1) = New SqlParameter("@result", SqlDbType.NVarChar, 50)
                    param(1).Direction = ParameterDirection.Output

                    param(0).Value = strJobNo
                    Dim result As Integer
                    Try
                        result = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Slcr1_InvoiceNo", param)
                        strDC = param(1).Value.ToString()
                    Catch ex As Exception
                    End Try
                End If
                '/////////////////////////


                If blnDC = True Then
                    txtDC.Text = strDC2
                Else
                    txtDC.Text = strDC.Replace(" ", "&nbsp;")
                End If
                If blnCC = True Then
                    txtCC.Text = strCC2
                Else
                    txtCC.Text = dt.Rows(0)("dtcc").ToString()
                End If
                lblContainerNo.Text = dt.Rows(0)("containerNo").ToString()
                lblSEALNo.Text = dt.Rows(0)("sealNo").ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
