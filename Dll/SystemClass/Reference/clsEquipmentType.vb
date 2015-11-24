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
#Region " Class Collection of EquipmentType Info "

    <Serializable()> _
    Public Class colEquipmentType
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropEquipmentType(ConClass.NewIdValue.ToString)
        End Function
    End Class
#End Region
#Region " Class Server of EquipmentType Info "

    <Serializable()> _
    Public Class clsEquipmentType
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
            colProp = New colEquipmentType()
            Title = "Equipment Type"
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
            colProp = New colEquipmentType()
            Title = "Equipment Type"
        End Sub
        Private Function InsertEquipmentType(ByRef propEquipmentType As clsPropEquipmentType, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(16) As SqlParameter
                param(0) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@ExternalLength", SqlDbType.Decimal)
                param(2) = New SqlParameter("@ExternalBreadth", SqlDbType.Decimal)
                param(3) = New SqlParameter("@ExternalHeight", SqlDbType.Decimal)
                param(4) = New SqlParameter("@InternalLength", SqlDbType.Decimal)
                param(5) = New SqlParameter("@InternalBreadth", SqlDbType.Decimal)
                param(6) = New SqlParameter("@InternalHeight", SqlDbType.Decimal)
                param(7) = New SqlParameter("@Material", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@Capacity", SqlDbType.Decimal)
                param(10) = New SqlParameter("@Max_g_Weight", SqlDbType.Decimal)
                param(11) = New SqlParameter("@Tare_Weight", SqlDbType.Decimal)
                param(12) = New SqlParameter("@MaxPayload", SqlDbType.Decimal)
                param(13) = New SqlParameter("@Stacking", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(15) = New SqlParameter("@Approvals", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)

                param(0).Value = propEquipmentType.ContainerType
                param(1).Value = propEquipmentType.ExternalLength
                param(2).Value = propEquipmentType.ExternalBreadth
                param(3).Value = propEquipmentType.ExternalHeight
                param(4).Value = propEquipmentType.InternalLength
                param(5).Value = propEquipmentType.InternalBreadth
                param(6).Value = propEquipmentType.InternalHeight
                param(7).Value = propEquipmentType.Material
                param(8).Value = propEquipmentType.Ext_Coat
                param(9).Value = propEquipmentType.Capacity
                param(10).Value = propEquipmentType.Max_g_Weight
                param(11).Value = propEquipmentType.Tare_Weight
                param(12).Value = propEquipmentType.MaxPayload
                param(13).Value = propEquipmentType.Stacking
                param(14).Value = propEquipmentType.Work_press
                param(15).Value = propEquipmentType.Approvals
                param(16).Value = propEquipmentType.CreateBy

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_rcco1", param)
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
        Private Function UpdateEquipmentType(ByVal propEquipmentType As clsPropEquipmentType, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(16) As SqlParameter
                param(0) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@ExternalLength", SqlDbType.Decimal)
                param(2) = New SqlParameter("@ExternalBreadth", SqlDbType.Decimal)
                param(3) = New SqlParameter("@ExternalHeight", SqlDbType.Decimal)
                param(4) = New SqlParameter("@InternalLength", SqlDbType.Decimal)
                param(5) = New SqlParameter("@InternalBreadth", SqlDbType.Decimal)
                param(6) = New SqlParameter("@InternalHeight", SqlDbType.Decimal)
                param(7) = New SqlParameter("@Material", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@Capacity", SqlDbType.Decimal)
                param(10) = New SqlParameter("@Max_g_Weight", SqlDbType.Decimal)
                param(11) = New SqlParameter("@Tare_Weight", SqlDbType.Decimal)
                param(12) = New SqlParameter("@MaxPayload", SqlDbType.Decimal)
                param(13) = New SqlParameter("@Stacking", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(15) = New SqlParameter("@Approvals", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar)

                param(0).Value = propEquipmentType.ContainerType
                param(1).Value = propEquipmentType.ExternalLength
                param(2).Value = propEquipmentType.ExternalBreadth
                param(3).Value = propEquipmentType.ExternalHeight
                param(4).Value = propEquipmentType.InternalLength
                param(5).Value = propEquipmentType.InternalBreadth
                param(6).Value = propEquipmentType.InternalHeight
                param(7).Value = propEquipmentType.Material
                param(8).Value = propEquipmentType.Ext_Coat
                param(9).Value = propEquipmentType.Capacity
                param(10).Value = propEquipmentType.Max_g_Weight
                param(11).Value = propEquipmentType.Tare_Weight
                param(12).Value = propEquipmentType.MaxPayload
                param(13).Value = propEquipmentType.Stacking
                param(14).Value = propEquipmentType.Work_press
                param(15).Value = propEquipmentType.Approvals
                param(16).Value = propEquipmentType.UpdateBy
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_rcco1", param)
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
        Private Function DeleteEquipmentType(ByVal propEquipmentType As clsPropEquipmentType, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(0).Value = propEquipmentType.ContainerType

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_rcco1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rcco1_List", param)
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
                param(0) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rcco1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal ContainerType As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@ContainerType", SqlDbType.NVarChar)
                param(0).Value = ContainerType

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rcco1_Detail", param)
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
                Dim tmpId As String = strRow(0)
                Dim tmpProp As clsPropEquipmentType
                If tmpId = "-1" Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    'tmpProp.Id = tmpId
                    State = EditState.Insert
                    'External Flag 
                    'WR Flag
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.ContainerType = strRow(1)
                tmpProp.ExternalLength = GeneralFun.StringToDecimal(strRow(2))
                tmpProp.ExternalBreadth = GeneralFun.StringToDecimal(strRow(3))
                tmpProp.ExternalHeight = GeneralFun.StringToDecimal(strRow(4))
                tmpProp.InternalLength = GeneralFun.StringToDecimal(strRow(5))
                tmpProp.InternalBreadth = GeneralFun.StringToDecimal(strRow(6))
                tmpProp.InternalHeight = GeneralFun.StringToDecimal(strRow(7))
                tmpProp.Material = strRow(8)
                tmpProp.Ext_Coat = strRow(9)
                tmpProp.Capacity = GeneralFun.StringToDecimal(strRow(10))
                tmpProp.Max_g_Weight = GeneralFun.StringToDecimal(strRow(11))
                tmpProp.MaxPayload = GeneralFun.StringToDecimal(strRow(12))
                tmpProp.Stacking = strRow(13)
                tmpProp.Tare_Weight = GeneralFun.StringToDecimal(strRow(14))
                tmpProp.Work_press = GeneralFun.StringToDecimal(strRow(15))
                tmpProp.Approvals = strRow(16)
                tmpProp.CreateBy = strRow(17)
                tmpProp.UpdateBy = strRow(17)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropEquipmentType = CType(CurrentProp, clsPropEquipmentType)
            blnReturn = InsertEquipmentType(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.ContainerType)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.ContainerType)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropEquipmentType = CType(CurrentProp, clsPropEquipmentType)
            blnReturn = UpdateEquipmentType(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.ContainerType)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.ContainerType)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropEquipmentType = CType(CurrentProp, clsPropEquipmentType)
            blnReturn = DeleteEquipmentType(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.ContainerType)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.ContainerType)
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