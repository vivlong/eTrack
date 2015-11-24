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

#Region " Class Collection of RO2 Info "

    <Serializable()> _
    Public Class colRO2
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropRO2(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of RO2 Info "

    <Serializable()> _
    Public Class clsRO2
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
            colProp = New colRO2()
            Title = "RO2"
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
            colProp = New colRO2()
            Title = "RO2"
        End Sub

        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Private Function InsertRO(ByRef propRO2 As clsPropRO2, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(17) As SqlParameter
                param(0) = New SqlParameter("@ReleasingOrderNo", SqlDbType.NVarChar, 10)
                param(1) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar, 10)
                param(2) = New SqlParameter("@ShipperName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar, 5)
                param(4) = New SqlParameter("@Qty", SqlDbType.BigInt)
                param(5) = New SqlParameter("@DepotCode", SqlDbType.NVarChar, 10)
                param(6) = New SqlParameter("@InstructionToDepot", SqlDbType.NVarChar, 1000)
                param(7) = New SqlParameter("@TruckerCode", SqlDbType.NVarChar, 10)
                param(8) = New SqlParameter("@TruckerName", SqlDbType.NVarChar, 50)
                param(9) = New SqlParameter("@PreCoolFlag", SqlDbType.NVarChar, 1)
                param(10) = New SqlParameter("@PreSetSign", SqlDbType.NVarChar, 1)
                param(11) = New SqlParameter("@PreSetTemperature", SqlDbType.Decimal)
                param(12) = New SqlParameter("@PreSetType", SqlDbType.NVarChar, 1)
                param(13) = New SqlParameter("@Commodity", SqlDbType.NVarChar, 50)
                param(14) = New SqlParameter("@VoltageCode", SqlDbType.NVarChar, 3)
                param(15) = New SqlParameter("@CollectionDate", SqlDbType.DateTime, 8)
                param(16) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(17) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)
                param(17).Direction = ParameterDirection.Output


                'param(0).Value = propRO2.ReleasingOrderNo
                'param(1).Value = propRO2.ShipperCode
                'param(2).Value = propRO2.ShipperName
                'param(3).Value = propRO2.EquipmentType
                'param(4).Value = propRO2.Qty
                'param(5).Value = propRO2.DepotCode
                'param(6).Value = propRO2.InstructionToDepot
                'param(7).Value = propRO2.TruckerCode
                'param(8).Value = propRO2.TruckerName
                'param(9).Value = propRO2.PreCoolFlag
                'param(10).Value = propRO2.PreSetSign
                'param(11).Value = propRO2.PreSetTemperature
                'param(12).Value = propRO2.PreSetType
                'param(13).Value = propRO2.Commodity
                'param(14).Value = propRO2.VoltageCode
                'param(15).Value = propRO2.CollectionDate
                'param(16).Value = propRO2.TrxNo
                'param(17).Value = propRO2.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_ctro12", param)
                If intResult > 0 Then
                    propRO2.LineItemNo = Int64.Parse(param(17).Value.ToString())
                    masterId = Int64.Parse(param(17).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateRO(ByVal propRO2 As clsPropRO2, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(17) As SqlParameter
                param(0) = New SqlParameter("@ReleasingOrderNo", SqlDbType.NVarChar, 10)
                param(1) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar, 10)
                param(2) = New SqlParameter("@ShipperName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar, 5)
                param(4) = New SqlParameter("@Qty", SqlDbType.BigInt)
                param(5) = New SqlParameter("@DepotCode", SqlDbType.NVarChar, 10)
                param(6) = New SqlParameter("@InstructionToDepot", SqlDbType.NVarChar, 1000)
                param(7) = New SqlParameter("@TruckerCode", SqlDbType.NVarChar, 10)
                param(8) = New SqlParameter("@TruckerName", SqlDbType.NVarChar, 50)
                param(9) = New SqlParameter("@PreCoolFlag", SqlDbType.NVarChar, 1)
                param(10) = New SqlParameter("@PreSetSign", SqlDbType.NVarChar, 1)
                param(11) = New SqlParameter("@PreSetTemperature", SqlDbType.Decimal)
                param(12) = New SqlParameter("@PreSetType", SqlDbType.NVarChar, 1)
                param(13) = New SqlParameter("@Commodity", SqlDbType.NVarChar, 50)
                param(14) = New SqlParameter("@VoltageCode", SqlDbType.NVarChar, 3)
                param(15) = New SqlParameter("@CollectionDate", SqlDbType.DateTime, 8)
                param(16) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(17) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)

                'param(0).Value = propRO2.ReleasingOrderNo
                'param(1).Value = propRO2.ShipperCode
                'param(2).Value = propRO2.ShipperName
                'param(3).Value = propRO2.EquipmentType
                'param(4).Value = propRO2.Qty
                'param(5).Value = propRO2.DepotCode
                'param(6).Value = propRO2.InstructionToDepot
                'param(7).Value = propRO2.TruckerCode
                'param(8).Value = propRO2.TruckerName
                'param(9).Value = propRO2.PreCoolFlag
                'param(10).Value = propRO2.PreSetSign
                'param(11).Value = propRO2.PreSetTemperature
                'param(12).Value = propRO2.PreSetType
                'param(13).Value = propRO2.Commodity
                'param(14).Value = propRO2.VoltageCode
                'param(15).Value = propRO2.CollectionDate
                'param(16).Value = propRO2.TrxNo
                'param(17).Value = propRO2.LineItemNo


                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_ctro12", param)
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
        Private Function DeleteRO(ByVal propRO2 As clsPropRO2, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propRO2.TrxNo
                param(1) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)
                param(1).Value = propRO2.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_ctro12", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctro2_List", param)
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
                    If RecordCount < PageSize Then
                        PageCount = 1
                    Else
                        PageCount = Convert.ToInt64(RecordCount / PageSize)
                        If PageCount < RecordCount / PageSize Then
                            PageCount += 1
                        End If
                    End If
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
            Dim strID As String = intId.ToString.Replace("123456789", "#")
            Dim arrId As String() = strID.ToString.Split("#")
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = Integer.Parse(arrId(0))

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                param(1).Value = Integer.Parse(arrId(1))


                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctro12_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overloads Function GetDetail(ByVal intId As Long, ByVal intLineItemNo As Long) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                param(1).Value = intLineItemNo

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctro12_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 21 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropRO2
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.LineItemNo = tmpId
                    State = EditState.Insert
                    'External Flag 
                    'WR Flag
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                'tmpProp.LineItemNo = GeneralFun.StringToInt(strRow(0))
                'tmpProp.ReleasingOrderNo = strRow(1)
                'tmpProp.ShipperCode = strRow(2)
                'tmpProp.ShipperName = strRow(3)
                'tmpProp.EquipmentType = strRow(4)
                'tmpProp.Qty = GeneralFun.StringToInt(strRow(5))
                ''tmpProp. = GeneralFun.StringToDate(strRow(6))
                'tmpProp.DepotCode = strRow(7)
                'tmpProp.InstructionToDepot = strRow(8)
                'tmpProp.TruckerCode = strRow(9)
                'tmpProp.TruckerName = strRow(10)
                'tmpProp.CollectionDate = GeneralFun.StringToDate(strRow(11))
                'tmpProp.PreCoolFlag = strRow(12)
                ''tmpProp.p = strRow(13)
                'tmpProp.PreSetTemperature = GeneralFun.StringToDecimal(strRow(14))
                ''tmpProp.DetentionFreeDay = GeneralFun.StringToInt(strRow(15))
                'tmpProp.Commodity = strRow(16)
                'tmpProp.VoltageCode = strRow(17)
                tmpProp.TrxNo = GeneralFun.StringToInt(strRow(18))
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRO2 = CType(CurrentProp, clsPropRO2)
            blnReturn = InsertRO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropRO2 = CType(CurrentProp, clsPropRO2)
            blnReturn = UpdateRO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropRO2 = CType(CurrentProp, clsPropRO2)
            blnReturn = DeleteRO(tmpProp, conn, trans, 1, strMsg)
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
