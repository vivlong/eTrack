Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Web.UI
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class Collection of ExportBooking Info "
    <Serializable()> _
    Public Class ExportBooking
        Inherits colclsProp
        Public Sub New()
            Me.HavePrefix = False
        End Sub
        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropExportBooking(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of ExportBooking Info "
    <Serializable()> _
    Public Class clsExportBooking
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Private _masterId As String
        Public Property masterId() As String
            Get
                Return _masterId
            End Get
            Set(ByVal value As String)
                _masterId = value
            End Set
        End Property
        Public Property ConfirmExternal() As Boolean
            Get
                Return _ConfirmExternal
            End Get
            Set(ByVal value As Boolean)
                _ConfirmExternal = value
            End Set
        End Property
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            _ConfirmExternal = False
            colProp = New ExportBooking()
            Title = "ExportBooking"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub
        ''' <summary>
        ''' 100315 ZhiWei for judge by Role
        ''' </summary>
        ''' <param name="strUserId"></param>
        ''' <param name="RoleName"></param>
        ''' <param name="strFunNo"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
            MyBase.New(strUserId, RoleName, strFunNo)
            _ConfirmExternal = False
            colProp = New ExportBooking()
            Title = "ExportBooking"
        End Sub
        Private Function InsertExportBooking(ByRef prop As clsPropExportBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(21) As SqlParameter
                param(0) = New SqlParameter("@BookingDateTime", SqlDbType.DateTime)
                param(1) = New SqlParameter("@BookingNo", SqlDbType.NVarChar, 20)
                param(2) = New SqlParameter("@BookingCustomerName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@ContactName", SqlDbType.NVarChar, 50)
                param(4) = New SqlParameter("@ContactTelephone", SqlDbType.NVarChar, 30)
                param(5) = New SqlParameter("@VesselCode", SqlDbType.NVarChar, 50)
                param(6) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 50)
                param(7) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(8) = New SqlParameter("@EtdDate", SqlDbType.DateTime)
                param(9) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(10) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 5)
                param(11) = New SqlParameter("@DestCode", SqlDbType.NVarChar, 3)
                param(12) = New SqlParameter("@CargoType", SqlDbType.NVarChar, 3)
                param(13) = New SqlParameter("@DgFlag", SqlDbType.NVarChar, 1)
                param(14) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar, 10)
                param(15) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 50)
                param(16) = New SqlParameter("@TotalPcs", SqlDbType.Int)
                param(17) = New SqlParameter("@TotalGrossWeight", SqlDbType.Decimal)
                param(18) = New SqlParameter("@TotalVolume", SqlDbType.Decimal)
                param(19) = New SqlParameter("@Footer1", SqlDbType.NVarChar, 160)
                param(20) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(20).Direction = ParameterDirection.Output
                param(21) = New SqlParameter("@SeblTrxNo", SqlDbType.Int)

                param(0).Value = prop.BookingDateTime
                param(1).Value = prop.BookingNo
                param(2).Value = prop.BookingCustomerName
                param(3).Value = prop.ContactName
                param(4).Value = prop.ContactTelephone
                param(5).Value = prop.VesselCode
                param(6).Value = prop.VesselName
                param(7).Value = prop.VoyageNo
                param(8).Value = prop.EtdDate
                param(9).Value = prop.EtaDate
                param(10).Value = prop.PortOfDischargeCode
                param(11).Value = prop.DestCode
                param(12).Value = prop.CargoType
                param(13).Value = prop.DgFlag
                param(14).Value = prop.CommodityCode
                param(15).Value = prop.CommodityDescription
                param(16).Value = prop.TotalPcs
                param(17).Value = prop.TotalGrossWeight
                param(18).Value = prop.TotalVolume
                param(19).Value = prop.Footer1
                param(21).Value = prop.SeblTrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Sebk1", param)
                If intResult > 0 Then
                    prop.TrxNo = Int64.Parse(param(20).Value.ToString())
                    masterId = Int64.Parse(param(20).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateExportBooking(ByVal prop As clsPropExportBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(20) As SqlParameter
                param(0) = New SqlParameter("@BookingDateTime", SqlDbType.DateTime)
                param(1) = New SqlParameter("@BookingNo", SqlDbType.NVarChar, 20)
                param(2) = New SqlParameter("@BookingCustomerName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@ContactName", SqlDbType.NVarChar, 50)
                param(4) = New SqlParameter("@ContactTelephone", SqlDbType.NVarChar, 30)
                param(5) = New SqlParameter("@VesselCode", SqlDbType.NVarChar, 50)
                param(6) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 50)
                param(7) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(8) = New SqlParameter("@EtdDate", SqlDbType.DateTime)
                param(9) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(10) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 5)
                param(11) = New SqlParameter("@DestCode", SqlDbType.NVarChar, 3)
                param(12) = New SqlParameter("@CargoType", SqlDbType.NVarChar, 3)
                param(13) = New SqlParameter("@DgFlag", SqlDbType.NVarChar, 1)
                param(14) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar, 10)
                param(15) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 50)
                param(16) = New SqlParameter("@TotalPcs", SqlDbType.Int)
                param(17) = New SqlParameter("@TotalGrossWeight", SqlDbType.Decimal)
                param(18) = New SqlParameter("@TotalVolume", SqlDbType.Decimal)
                param(19) = New SqlParameter("@Footer1", SqlDbType.NVarChar, 255)
                param(20) = New SqlParameter("@TrxNo", SqlDbType.Int)

                param(0).Value = prop.BookingDateTime
                param(1).Value = prop.BookingNo
                param(2).Value = prop.BookingCustomerName
                param(3).Value = prop.ContactName
                param(4).Value = prop.ContactTelephone
                param(5).Value = prop.VesselCode
                param(6).Value = prop.VesselName
                param(7).Value = prop.VoyageNo
                param(8).Value = prop.EtdDate
                param(9).Value = prop.EtaDate
                param(10).Value = prop.PortOfDischargeCode
                param(11).Value = prop.DestCode
                param(12).Value = prop.CargoType
                param(13).Value = prop.DgFlag
                param(14).Value = prop.CommodityCode
                param(15).Value = prop.CommodityDescription
                param(16).Value = prop.TotalPcs
                param(17).Value = prop.TotalGrossWeight
                param(18).Value = prop.TotalVolume
                param(19).Value = prop.Footer1
                param(20).Value = prop.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Sebk1", param)
                If intResult > 0 Then
                    masterId = prop.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function DeleteExportBooking(ByVal prop As clsPropExportBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = prop.TrxNo
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Sebk1", param)
                If intResult > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = -1

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                param(1).Value = Where

                param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
                param(2).Value = Query

                param(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
                param(3).Value = OrderBy

                param(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param(4).Value = PageIndex

                param(5) = New SqlParameter("@PageSize", SqlDbType.Int)
                param(5).Value = PageSize

                param(6) = New SqlParameter("@PageCount", SqlDbType.Int)
                param(6).Direction = ParameterDirection.Output

                param(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param(7).Direction = ParameterDirection.Output

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebk1", param)
                If PageSize = 0 Then
                    'Total Page Count
                    PageCount = 1
                    'Total Record Count
                    RecordCount = ds.Tables(0).Rows.Count
                    dt = ds.Tables(0)
                Else
                    'Total Page Count
                    PageCount = Integer.Parse(param(6).Value.ToString())
                    'Total Record Count
                    RecordCount = Integer.Parse(param(7).Value.ToString())
                    dt = ds.Tables(1)
                End If
                Return dt
            Catch err As Exception
                Return New DataTable()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As Long) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebk1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebk1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 27 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropExportBooking
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                    'External Flag
                    'WR Flag
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.BookingDateTime = GeneralFun.StringToDate(strRow(1))
                tmpProp.BookingNo = strRow(2)
                tmpProp.BookingCustomerName = strRow(3)
                tmpProp.ContactName = strRow(4)
                tmpProp.ContactTelephone = strRow(5)
                tmpProp.VesselCode = strRow(6)
                tmpProp.VesselName = strRow(7)
                tmpProp.VoyageNo = strRow(8)
                tmpProp.EtdDate = GeneralFun.StringToDate(strRow(9))
                tmpProp.EtaDate = GeneralFun.StringToDate(strRow(10))
                tmpProp.PortOfDischargeCode = strRow(11)
                tmpProp.DestCode = strRow(13)
                tmpProp.CargoType = strRow(15)
                tmpProp.DgFlag = strRow(16)
                tmpProp.CommodityCode = strRow(17)
                tmpProp.CommodityDescription = strRow(18)
                tmpProp.TotalPcs = GeneralFun.StringToInt(strRow(19))
                tmpProp.TotalGrossWeight = GeneralFun.StringToDecimal(strRow(20))
                tmpProp.TotalVolume = GeneralFun.StringToDecimal(strRow(21))
                tmpProp.BookingCustomerCode = strRow(22)
                tmpProp.Footer1 = strRow(22)
                tmpProp.SeblTrxNo = GeneralFun.StringToInt(strRow(23))
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropExportBooking = CType(CurrentProp, clsPropExportBooking)
            blnReturn = InsertExportBooking(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropExportBooking = CType(CurrentProp, clsPropExportBooking)
            blnReturn = UpdateExportBooking(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropExportBooking = CType(CurrentProp, clsPropExportBooking)
            blnReturn = DeleteExportBooking(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
        'Get Email Set
        Private Function GetEmailAddress(ByVal intTrxNo As Int64, ByRef strFrom As String, ByRef strTo As String, ByRef strSmtpServer As String, ByRef intSmtpPort As Integer, ByRef strSmtpUser As String, ByRef strSmtpPassword As String) As Boolean
            If intTrxNo >= 0 Then
                Try
                    Dim param(6) As SqlParameter

                    param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                    param(0).Value = intTrxNo

                    param(1) = New SqlParameter("@strEmail", SqlDbType.NVarChar, 3000)
                    param(1).Direction = ParameterDirection.Output

                    param(2) = New SqlParameter("@strFrom", SqlDbType.NVarChar, 1000)
                    param(2).Direction = ParameterDirection.Output

                    param(3) = New SqlParameter("@strSmtpServer", SqlDbType.NVarChar, 1000)
                    param(3).Direction = ParameterDirection.Output

                    param(4) = New SqlParameter("@intSmtpPort", SqlDbType.Int)
                    param(4).Direction = ParameterDirection.Output

                    param(5) = New SqlParameter("@strSmtpUser", SqlDbType.NVarChar, 1000)
                    param(5).Direction = ParameterDirection.Output

                    param(6) = New SqlParameter("@strSmtpPassword", SqlDbType.NVarChar, 1000)
                    param(6).Direction = ParameterDirection.Output

                    SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sps_ExportBookingEmailAddress", param)
                    strFrom = CStr(param(2).Value)
                    strTo = CStr(param(1).Value)
                    strSmtpServer = CStr(param(3).Value)
                    intSmtpPort = CInt(param(4).Value)
                    strSmtpUser = CStr(param(5).Value)
                    strSmtpPassword = CStr(param(6).Value)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            Else
                Return False
            End If
        End Function
        Public Function SendEmail(ByVal prop As clsPropExportBooking, ByVal strUserName As String, Optional ByVal m_blnConfirm As Boolean = False, Optional ByVal m_blnSend As Boolean = False, Optional ByVal intType As Integer = 0, Optional ByVal strFunNo As String = "") As Boolean
            Dim objMail As New MailMessage
            Dim client As New SmtpClient
            Try
                Dim strHost = "mail.sysfreight.com"
                Dim strFrom As String = ""
                Dim strSmtpServer As String = ""
                Dim intSmtpPort As Integer = 25
                Dim strSmtpUser As String = ""
                Dim strSmtpPassword As String = ""
                Dim strTo As String = ""
                Dim strSubject As String = ""
                Dim strBody As String = ""
                Dim i As Integer
                '+++++++++++++++++++ 081212 Net678 +++++++++++++++++++++++
                Dim strSubOfTitle As String = "ExportBooking"
                Dim TrxNo As String = "TrxNo"
                '+++++++++++++++++++++++ End +++++++++++++++++++++++++++++
                If Not GetEmailAddress(prop.TrxNo, strFrom, strTo, strSmtpServer, intSmtpPort, strSmtpUser, strSmtpPassword) Then
                    Return False
                End If
                Dim strModule As String = ""

                If strModule <> "" Then
                    strModule = strModule.Substring(0, strModule.Length - 2)
                End If
                If intType = 0 Then  '' intType=0 just for the first Tab "ExportBooking" to send button
                    'strSubject = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.ExportBookingMailTitle, strUserName)
                    '+++++++++++++++++++++++ 081212 Net678 ++++++++++++++++++++++++++++++
                    'strBody = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, mailInfo) '' note: this RestoreAction just put the emailbody...
                    strBody = "ExportBooking Summary" & vbCrLf & vbCrLf

                    Dim strAttach = System.Web.HttpContext.Current.Server.MapPath("../Attach/")
                    Dim arrAttachFileName() As String = clsAttachFileDirectory.GetAllFileName(strAttach + prop.TrxNo.ToString())
                    If Not arrAttachFileName Is Nothing Then
                        For i = 0 To arrAttachFileName.Length - 1
                            objMail.Attachments.Add(New Attachment(arrAttachFileName(i)))
                        Next
                    End If
                    Dim tmpARR() As String
                    objMail.From = New MailAddress(strFrom) 'strFrom
                    'testbyzhiwei
                    strTo = "zhiwei@sysfreight.com,"
                    'test
                    ' 081023 zhiwei
                    If strTo.Trim <> "" Then
                        'add email to 
                        tmpARR = strTo.Split(",")
                        For i = 0 To UBound(tmpARR)
                            If tmpARR(i).Trim <> "" Then
                                objMail.To.Add(New MailAddress(tmpARR(i).Trim))
                            End If
                        Next
                    End If
                End If
                '++++++++++++++++++++++++++ End ++++++++++++++++++++++++++++++++
                objMail.Subject = strSubject
                objMail.Body = strBody

                client.Host = strSmtpServer
                client.Port = intSmtpPort
                If strSmtpServer <> "" Then
                    '.byzhiwei090106
                    client.UseDefaultCredentials = True '
                    client.EnableSsl = False '
                    client.Credentials = New System.Net.NetworkCredential(strSmtpUser, strSmtpPassword)
                    client.DeliveryMethod = SmtpDeliveryMethod.Network
                End If
                Try
                    client.Send(objMail)
                    Return True
                Catch ex As Exception
                    ''MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
#End Region
End Namespace