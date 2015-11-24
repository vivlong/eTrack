Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports System.Net.Mail
Imports System.Web.UI
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class Collection of LineItemPO Info "

    <Serializable()> _
    Public Class colLineItemPO
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropLineItemPO(ConClass.NewIdValue.ToString)
        End Function
    End Class
#End Region
#Region " Class Server of LineItemPO Info "

    <Serializable()> _
    Public Class clsLineItemPO
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
            colProp = New colLineItemPO()
            Title = "LineItemPO"
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
            colProp = New colLineItemPO()
            Title = "LineItemPO"
        End Sub
        Private Function InsertLineItemPO(ByRef propPO As clsPropLineItemPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(25) As SqlParameter
                param(0) = New SqlParameter("@LineItemNo", SqlDbType.NVarChar, 50)
                param(1) = New SqlParameter("@PartNo", SqlDbType.NVarChar, 50)
                param(2) = New SqlParameter("@PartDesc", SqlDbType.NVarChar, 80)
                param(3) = New SqlParameter("@HarmonizeCode", SqlDbType.NVarChar, 15)
                param(4) = New SqlParameter("@HarmonizeDesc", SqlDbType.NVarChar, 50)
                param(5) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                param(6) = New SqlParameter("@CurrCode", SqlDbType.NVarChar, 3)
                param(7) = New SqlParameter("@SupplierPartNo", SqlDbType.NVarChar, 50)
                param(8) = New SqlParameter("@QtyOrdered", SqlDbType.NVarChar, 50)
                param(9) = New SqlParameter("@QtyUOM", SqlDbType.NVarChar, 3)
                param(10) = New SqlParameter("@NetWeight", SqlDbType.Decimal)
                param(11) = New SqlParameter("@GrossWeight", SqlDbType.Decimal)
                param(12) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 50)
                param(13) = New SqlParameter("@InsuranceValue", SqlDbType.Decimal)
                param(14) = New SqlParameter("@DateRequested", SqlDbType.DateTime)
                param(15) = New SqlParameter("@LatestDeliveryDate", SqlDbType.DateTime)
                param(16) = New SqlParameter("@ModeofTransport", SqlDbType.NVarChar, 10)
                param(17) = New SqlParameter("@ShippingStatus", SqlDbType.NVarChar, 10)
                param(18) = New SqlParameter("@UOM", SqlDbType.NVarChar, 50)
                param(19) = New SqlParameter("@Length", SqlDbType.Decimal)
                param(20) = New SqlParameter("@Width", SqlDbType.Decimal)
                param(21) = New SqlParameter("@Height", SqlDbType.Decimal)
                param(22) = New SqlParameter("@Weight", SqlDbType.Decimal)
                param(23) = New SqlParameter("@WeightMeasurement", SqlDbType.NVarChar, 50)
                param(24) = New SqlParameter("@LineItemComments", SqlDbType.NVarChar, 80)
                param(25) = New SqlParameter("@TrxNo", SqlDbType.Int)

                param(0).Value = propPO.LineItemNo
                param(1).Value = propPO.PartNo
                param(2).Value = propPO.PartDesc
                param(3).Value = propPO.HarmonizeCode
                param(4).Value = propPO.HarmonizeDesc
                param(5).Value = propPO.UnitPrice
                param(6).Value = propPO.CurrCode
                param(7).Value = propPO.SupplierPartNo
                param(8).Value = propPO.QtyOrdered
                param(9).Value = propPO.QtyUOM
                param(10).Value = propPO.NetWeight
                param(11).Value = propPO.GrossWeight
                param(12).Value = propPO.TagNo
                param(13).Value = propPO.InsuranceValue
                param(14).Value = propPO.DateRequested
                param(15).Value = propPO.LatestDeliveryDate
                param(16).Value = propPO.ModeofTransport
                param(17).Value = propPO.ShippingStatus
                param(18).Value = propPO.UOM
                param(19).Value = propPO.Length
                param(20).Value = propPO.Width
                param(21).Value = propPO.Height
                param(22).Value = propPO.Weight
                param(23).Value = propPO.WeightMeasurement
                param(24).Value = propPO.LineItemComments
                param(25).Value = propPO.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Popo2", param)
                If intResult > 0 Then
                    propPO.TrxNo = intResult
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateLineItemPO(ByVal propPO As clsPropLineItemPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(50) As SqlParameter
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)

                param(51).Value = propPO.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "", param)
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
        Private Function DeleteLineItemPO(ByVal propPO As clsPropLineItemPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propPO.TrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)
                param(1).Value = propPO.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Popo2", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Popo2_List", param)
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
        Public Overloads Function GetDetail(ByVal intId As Long, ByVal lineItem As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.NVarChar, 50)
                param(1).Value = lineItem

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_POPO2_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As Long) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_POPO2_Detail", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_POPO2_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 30 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropLineItemPO
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                'Item Information
                tmpProp.LineItemNo = strRow(1)
                tmpProp.PartNo = strRow(2)
                tmpProp.PartDesc = strRow(3)
                tmpProp.HarmonizeCode = strRow(4)
                tmpProp.HarmonizeDesc = strRow(5)
                tmpProp.UnitPrice = GeneralFun.StringToDecimal(strRow(6))
                tmpProp.CurrCode = strRow(7)
                tmpProp.SupplierPartNo = strRow(8)
                tmpProp.QtyOrdered = strRow(9)
                tmpProp.QtyUOM = strRow(10)
                tmpProp.NetWeight = GeneralFun.StringToDecimal(strRow(11))
                tmpProp.GrossWeight = GeneralFun.StringToDecimal(strRow(12))
                'Shipping Information
                tmpProp.TagNo = strRow(13)
                tmpProp.InsuranceValue = GeneralFun.StringToDecimal(strRow(14))
                tmpProp.DateRequested = GeneralFun.StringToDate(strRow(15))
                tmpProp.LatestDeliveryDate = GeneralFun.StringToDate(strRow(16))
                tmpProp.ModeofTransport = strRow(17)
                tmpProp.ShippingStatus = strRow(18)
                'Package Information
                tmpProp.UOM = strRow(19)
                tmpProp.Length = GeneralFun.StringToDecimal(strRow(20))
                tmpProp.Width = GeneralFun.StringToDecimal(strRow(21))
                tmpProp.Height = GeneralFun.StringToDecimal(strRow(22))
                tmpProp.Weight = GeneralFun.StringToDecimal(strRow(24))
                tmpProp.WeightMeasurement = strRow(23)
                tmpProp.LineItemComments = strRow(25)
                tmpProp.TrxNo = strRow(26)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropLineItemPO = CType(CurrentProp, clsPropLineItemPO)
            blnReturn = InsertLineItemPO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropLineItemPO = CType(CurrentProp, clsPropLineItemPO)
            blnReturn = UpdateLineItemPO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropLineItemPO = CType(CurrentProp, clsPropLineItemPO)
            blnReturn = DeleteLineItemPO(tmpProp, conn, trans, 1, strMsg)
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