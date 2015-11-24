Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Net.Mail
Imports System.Web.UI

Namespace SystemClass

#Region " Class Collection of RI Info "

    <Serializable()> _
    Public Class colRI
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropRI(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of RI Info "

    <Serializable()> _
    Public Class clsRI
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Private _masterId As String
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
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
            colProp = New colRI()
            Title = "Releasing Instruction"
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
            colProp = New colRI()
            Title = "Releasing Instruction"
        End Sub
        Private Function InsertRI(ByRef propRI As clsPropRI, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(17) As SqlParameter
                param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
                param(1) = New SqlParameter("@MasterJobNo", SqlDbType.NVarChar, 40)
                param(2) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
                param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@ReleaseType", SqlDbType.NVarChar, 10)
                param(6) = New SqlParameter("@ReleasingDestinationCode", SqlDbType.NVarChar, 10)
                param(7) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 10)
                param(8) = New SqlParameter("@FirstViaPortCode", SqlDbType.NVarChar, 10)
                param(9) = New SqlParameter("@SecondViaPortCode", SqlDbType.NVarChar, 10)
                param(10) = New SqlParameter("@ThirdViaPortCode", SqlDbType.NVarChar, 10)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 10)
                param(12) = New SqlParameter("@DetentionCode", SqlDbType.NVarChar, 20)
                param(13) = New SqlParameter("@DetentionFreeDay", SqlDbType.Int)
                param(14) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(14).Direction = ParameterDirection.Output
                param(15) = New SqlParameter("@ReleasingInstructionNo", SqlDbType.NVarChar, 20)
                param(16) = New SqlParameter("@SiteCode", SqlDbType.NVarChar, 20)
                param(17) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)

                param(0).Value = propRI.OrganisationCode
                param(1).Value = propRI.MasterJobNo
                param(2).Value = propRI.VesselName
                param(3).Value = propRI.VoyageNo
                param(4).Value = propRI.EtaDate
                param(5).Value = propRI.ReleaseType
                param(6).Value = propRI.ReleasingDestinationCode
                param(7).Value = propRI.PortOfLoadingCode
                param(8).Value = propRI.FirstViaPortCode
                param(9).Value = propRI.SecondViaPortCode
                param(10).Value = propRI.ThirdViaPortCode
                param(11).Value = propRI.PortOfDischargeCode
                param(12).Value = propRI.DetentionCode
                param(13).Value = propRI.DetentionFreeDay
                param(14).Value = propRI.TrxNo
                param(15).Value = propRI.ReleasingInstructionNo
                param(16).Value = propRI.SiteCode
                param(17).Value = propRI.UserNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_ctri1", param)
                If intResult > 0 Then
                    propRI.TrxNo = Int64.Parse(param(14).Value.ToString())
                    masterId = Int64.Parse(param(14).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateRI(ByVal propRI As clsPropRI, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(15) As SqlParameter
                param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
                param(1) = New SqlParameter("@MasterJobNo", SqlDbType.NVarChar, 40)
                param(2) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
                param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@ReleaseType", SqlDbType.NVarChar, 10)
                param(6) = New SqlParameter("@ReleasingDestinationCode", SqlDbType.NVarChar, 10)
                param(7) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 10)
                param(8) = New SqlParameter("@FirstViaPortCode", SqlDbType.NVarChar, 10)
                param(9) = New SqlParameter("@SecondViaPortCode", SqlDbType.NVarChar, 10)
                param(10) = New SqlParameter("@ThirdViaPortCode", SqlDbType.NVarChar, 10)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 10)
                param(12) = New SqlParameter("@DetentionCode", SqlDbType.NVarChar, 20)
                param(13) = New SqlParameter("@DetentionFreeDay", SqlDbType.Int)
                param(14) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(15) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)

                param(0).Value = propRI.OrganisationCode
                param(1).Value = propRI.MasterJobNo
                param(2).Value = propRI.VesselName
                param(3).Value = propRI.VoyageNo
                param(4).Value = propRI.EtaDate
                param(5).Value = propRI.ReleaseType
                param(6).Value = propRI.ReleasingDestinationCode
                param(7).Value = propRI.PortOfLoadingCode
                param(8).Value = propRI.FirstViaPortCode
                param(9).Value = propRI.SecondViaPortCode
                param(10).Value = propRI.ThirdViaPortCode
                param(11).Value = propRI.PortOfDischargeCode
                param(12).Value = propRI.DetentionCode
                param(13).Value = propRI.DetentionFreeDay
                param(14).Value = propRI.TrxNo
                param(15).Value = propRI.UserNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_ctri1", param)
                If intResult > 0 Then
                    masterId = propRI.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function DeleteRI(ByVal propRI As clsPropRI, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propRI.TrxNo
                param(1) = New SqlParameter("@msg", SqlDbType.NVarChar, 400)
                param(1).Direction = ParameterDirection.Output

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_ctri1", param)
                If intResult > 0 Then
                    Return True
                Else
                    strMsg = param(1).Value.ToString
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

                If FunNo = "1002" Then
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctri1_DepotOut_List", param)
                Else
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctri1_List", param)
                End If

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
            Catch
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctri1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 22 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropRI
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
                tmpProp.TrxNo = strRow(0)
                tmpProp.OrganisationCode = strRow(1)
                tmpProp.MasterJobNo = strRow(3)
                tmpProp.VesselName = strRow(4)
                tmpProp.VoyageNo = strRow(5)
                tmpProp.EtaDate = GeneralFun.StringToDate(strRow(6))
                tmpProp.ReleaseType = strRow(7)
                tmpProp.ReleasingDestinationCode = strRow(8)
                tmpProp.PortOfLoadingCode = strRow(9)
                tmpProp.FirstViaPortCode = strRow(10)
                tmpProp.SecondViaPortCode = strRow(11)
                tmpProp.ThirdViaPortCode = strRow(12)
                tmpProp.PortOfDischargeCode = strRow(13)
                tmpProp.DetentionCode = strRow(14)
                tmpProp.DetentionFreeDay = GeneralFun.StringToInt(strRow(15))
                tmpProp.ReleasingInstructionNo = strRow(16)
                tmpProp.SiteCode = strRow(17)
                tmpProp.UserNo = strRow(18)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRI = CType(CurrentProp, clsPropRI)
            blnReturn = InsertRI(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropRI = CType(CurrentProp, clsPropRI)
            blnReturn = UpdateRI(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropRI = CType(CurrentProp, clsPropRI)
            blnReturn = DeleteRI(tmpProp, conn, trans, 1, strMsg)
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
    End Class

#End Region
End Namespace
