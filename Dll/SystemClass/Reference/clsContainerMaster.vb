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

#Region " Class Collection of ContainerMaster Info "

    <Serializable()> _
    Public Class colContainerMaster
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropContainerMaster(ConClass.NewIdValue.ToString)
        End Function
    End Class
#End Region
#Region " Class Server of ContainerMaster Info "

    <Serializable()> _
    Public Class clsContainerMaster
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
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
            colProp = New colContainerMaster()
            Title = "Container Master"
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
            colProp = New colContainerMaster()
            Title = "Container Master"
        End Sub

        Private Function InsertContainerMaster(ByRef propContainerMaster As clsPropContainerMaster, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(28) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@Comm_Date", SqlDbType.DateTime)
                param(2) = New SqlParameter("@OnHireDateTime", SqlDbType.DateTime)
                param(3) = New SqlParameter("@OffHireDateTime", SqlDbType.DateTime)
                param(4) = New SqlParameter("@Tank_Cat", SqlDbType.Int)
                param(5) = New SqlParameter("@Lessor", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@Date_Manu", SqlDbType.DateTime)
                param(7) = New SqlParameter("@Manufacturer", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@Plate", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@ExternalLength", SqlDbType.Decimal)
                param(11) = New SqlParameter("@ExternalBreadth", SqlDbType.Decimal)
                param(12) = New SqlParameter("@ExternalHeight", SqlDbType.Decimal)
                param(13) = New SqlParameter("@InternalLength", SqlDbType.Decimal)
                param(14) = New SqlParameter("@InternalBreadth", SqlDbType.Decimal)
                param(15) = New SqlParameter("@InternalHeight", SqlDbType.Decimal)
                param(16) = New SqlParameter("@Material", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@Capacity", SqlDbType.Decimal)
                param(19) = New SqlParameter("@Max_g_Weight", SqlDbType.Decimal)
                param(20) = New SqlParameter("@Tare_Weight", SqlDbType.Decimal)
                param(21) = New SqlParameter("@MaxPayload", SqlDbType.Decimal)
                param(22) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(23) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(24) = New SqlParameter("@Approvals", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Name_of_file", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)
                param(27) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(27).Direction = ParameterDirection.Output
                param(28) = New SqlParameter("@UseFlag", SqlDbType.NVarChar)

                param(0).Value = propContainerMaster.ContainerNo
                param(1).Value = propContainerMaster.Comm_Date
                param(2).Value = propContainerMaster.OnHireDateTime
                param(3).Value = propContainerMaster.OffHireDateTime
                param(4).Value = propContainerMaster.Tank_Cat
                param(5).Value = propContainerMaster.Lessor
                param(6).Value = propContainerMaster.Date_Manu
                param(7).Value = propContainerMaster.Manufacturer
                param(8).Value = propContainerMaster.Plate
                param(9).Value = propContainerMaster.ContainerType
                param(10).Value = propContainerMaster.ExternalLength
                param(11).Value = propContainerMaster.ExternalBreadth
                param(12).Value = propContainerMaster.ExternalHeight
                param(13).Value = propContainerMaster.InternalLength
                param(14).Value = propContainerMaster.InternalBreadth
                param(15).Value = propContainerMaster.InternalHeight
                param(16).Value = propContainerMaster.Material
                param(17).Value = propContainerMaster.Ext_Coat
                param(18).Value = propContainerMaster.Capacity
                param(19).Value = propContainerMaster.Max_g_Weight
                param(20).Value = propContainerMaster.Tare_Weight
                param(21).Value = propContainerMaster.MaxPayload
                param(22).Value = propContainerMaster.Test_press
                param(23).Value = propContainerMaster.Thickness
                param(24).Value = propContainerMaster.Approvals
                param(25).Value = propContainerMaster.Name_of_file
                param(26).Value = propContainerMaster.CreateBy
                param(28).Value = propContainerMaster.UseFlag

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_rccf1", param)
                If intResult > 0 Then
                    propContainerMaster.Id = intResult
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateContainerMaster(ByVal propContainerMaster As clsPropContainerMaster, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try

                Dim param(28) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@Comm_Date", SqlDbType.DateTime)
                param(2) = New SqlParameter("@OnHireDateTime", SqlDbType.DateTime)
                param(3) = New SqlParameter("@OffHireDateTime", SqlDbType.DateTime)
                param(4) = New SqlParameter("@Tank_Cat", SqlDbType.Int)
                param(5) = New SqlParameter("@Lessor", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@Date_Manu", SqlDbType.DateTime)
                param(7) = New SqlParameter("@Manufacturer", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@Plate", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@ExternalLength", SqlDbType.Decimal)
                param(11) = New SqlParameter("@ExternalBreadth", SqlDbType.Decimal)
                param(12) = New SqlParameter("@ExternalHeight", SqlDbType.Decimal)
                param(13) = New SqlParameter("@InternalLength", SqlDbType.Decimal)
                param(14) = New SqlParameter("@InternalBreadth", SqlDbType.Decimal)
                param(15) = New SqlParameter("@InternalHeight", SqlDbType.Decimal)
                param(16) = New SqlParameter("@Material", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@Capacity", SqlDbType.Decimal)
                param(19) = New SqlParameter("@Max_g_Weight", SqlDbType.Decimal)
                param(20) = New SqlParameter("@Tare_Weight", SqlDbType.Decimal)
                param(21) = New SqlParameter("@MaxPayload", SqlDbType.Decimal)
                param(22) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(23) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(24) = New SqlParameter("@Approvals", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Name_of_file", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar)
                param(27) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(28) = New SqlParameter("@UseFlag", SqlDbType.NVarChar)

                param(0).Value = propContainerMaster.ContainerNo
                param(1).Value = propContainerMaster.Comm_Date
                param(2).Value = propContainerMaster.OnHireDateTime
                param(3).Value = propContainerMaster.OffHireDateTime
                param(4).Value = propContainerMaster.Tank_Cat
                param(5).Value = propContainerMaster.Lessor
                param(6).Value = propContainerMaster.Date_Manu
                param(7).Value = propContainerMaster.Manufacturer
                param(8).Value = propContainerMaster.Plate
                param(9).Value = propContainerMaster.ContainerType
                param(10).Value = propContainerMaster.ExternalLength
                param(11).Value = propContainerMaster.ExternalBreadth
                param(12).Value = propContainerMaster.ExternalHeight
                param(13).Value = propContainerMaster.InternalLength
                param(14).Value = propContainerMaster.InternalBreadth
                param(15).Value = propContainerMaster.InternalHeight
                param(16).Value = propContainerMaster.Material
                param(17).Value = propContainerMaster.Ext_Coat
                param(18).Value = propContainerMaster.Capacity
                param(19).Value = propContainerMaster.Max_g_Weight
                param(20).Value = propContainerMaster.Tare_Weight
                param(21).Value = propContainerMaster.MaxPayload
                param(22).Value = propContainerMaster.Test_press
                param(23).Value = propContainerMaster.Thickness
                param(24).Value = propContainerMaster.Approvals
                param(25).Value = propContainerMaster.Name_of_file
                param(26).Value = propContainerMaster.UpdateBy
                param(27).Value = propContainerMaster.TrxNo
                param(28).Value = propContainerMaster.UseFlag
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_rccf1", param)
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
        Private Function DeleteContainerMaster(ByVal propContainerMaster As clsPropContainerMaster, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propContainerMaster.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_rccf1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_Detail", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 34 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropContainerMaster
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.Id = tmpId
                    State = EditState.Insert
                    'External Flag 
                    'WR Flag
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                'tmpProp.ContainerMasterDate = GeneralFun.StringToDate(strRow(1))

                tmpProp.TrxNo = strRow(0)
                tmpProp.TrxNo = strRow(0)
                tmpProp.ContainerNo = strRow(1)
                tmpProp.Comm_Date = GeneralFun.StringToDate(strRow(2))
                tmpProp.OnHireDateTime = GeneralFun.StringToDate(strRow(3))
                tmpProp.OffHireDateTime = GeneralFun.StringToDate(strRow(4))
                tmpProp.Tank_Cat = GeneralFun.StringToInt(strRow(5))
                tmpProp.Lessor = strRow(6)
                tmpProp.Date_Manu = GeneralFun.StringToDate(strRow(7))
                tmpProp.Manufacturer = strRow(8)
                tmpProp.Plate = strRow(9)
                tmpProp.ContainerType = strRow(10)
                tmpProp.ExternalLength = GeneralFun.StringToDecimal(strRow(11))
                tmpProp.ExternalBreadth = GeneralFun.StringToDecimal(strRow(12))
                tmpProp.ExternalHeight = GeneralFun.StringToDecimal(strRow(13))
                tmpProp.InternalLength = GeneralFun.StringToDecimal(strRow(14))
                tmpProp.InternalBreadth = GeneralFun.StringToDecimal(strRow(15))
                tmpProp.InternalHeight = GeneralFun.StringToDecimal(strRow(16))
                tmpProp.Material = strRow(17)
                tmpProp.Ext_Coat = strRow(18)
                tmpProp.Capacity = GeneralFun.StringToDecimal(strRow(19))
                tmpProp.Max_g_Weight = GeneralFun.StringToDecimal(strRow(20))
                tmpProp.Tare_Weight = GeneralFun.StringToDecimal(strRow(21))
                tmpProp.MaxPayload = GeneralFun.StringToDecimal(strRow(22))
                tmpProp.Test_press = GeneralFun.StringToDecimal(strRow(23))
                tmpProp.Thickness = GeneralFun.StringToDecimal(strRow(24))
                tmpProp.Approvals = strRow(25)
                tmpProp.Name_of_file = strRow(26)
                tmpProp.CreateBy = strRow(27)
                tmpProp.UpdateBy = strRow(27)
                tmpProp.UseFlag = strRow(28)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropContainerMaster = CType(CurrentProp, clsPropContainerMaster)
            blnReturn = InsertContainerMaster(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropContainerMaster = CType(CurrentProp, clsPropContainerMaster)
            blnReturn = UpdateContainerMaster(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropContainerMaster = CType(CurrentProp, clsPropContainerMaster)
            blnReturn = DeleteContainerMaster(tmpProp, conn, trans, 1, strMsg)
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