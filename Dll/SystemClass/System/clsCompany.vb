Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class of Property Company "

    <Serializable()> _
    Public Class clsPropCompany
        Inherits clsProp
        Private _CompanyCode As String
        Private _CompanyName As String
        Private _Address1 As String

        Public Property CompanyCode() As String
            Get
                Return _CompanyCode
            End Get
            Set(ByVal value As String)
                _CompanyCode = value
            End Set
        End Property

        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                _CompanyName = value
            End Set
        End Property

        Public Property Address1() As String
            Get
                Return _Address1
            End Get
            Set(ByVal value As String)
                _Address1 = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _CompanyCode = ""
            _CompanyName = ""
            _Address1 = ""
        End Sub

    End Class
#End Region

#Region " Class of Collection of Property Company "

    <Serializable()> _
    Public Class colCompany
        Inherits colclsProp
        Public Sub New()
            Me.HavePrefix = False
        End Sub
        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropCompany(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of Company Server "

    <Serializable()> _
    Public Class clsCompany
        Inherits clsBaseSrv
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colCompany()
            Title = "Company Info"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Private Function InsertCompany(ByVal propCompany As clsPropCompany, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(4) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.BigInt)
                param(0).Value = propCompany.Id
                param(0).Direction = ParameterDirection.Output

                param(1) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(1).Value = propCompany.UserId

                param(2) = New SqlParameter("@strCompNo", SqlDbType.NVarChar, 32)
                param(2).Value = propCompany.CompanyCode

                param(3) = New SqlParameter("@strCnCompPartName", SqlDbType.NVarChar, 50)
                param(3).Value = propCompany.CompanyName

                param(4) = New SqlParameter("@strCnCompName", SqlDbType.NVarChar, 100)
                param(4).Value = propCompany.Address1

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Company", param)
                If intResult > 0 Then
                    propCompany.Id = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateCompany(ByVal propCompany As clsPropCompany, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(15) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.BigInt)
                param(0).Value = propCompany.Id

                param(1) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(1).Value = propCompany.UserId

                param(2) = New SqlParameter("@strCompNo", SqlDbType.NVarChar, 32)
                param(2).Value = propCompany.CompanyCode

                param(3) = New SqlParameter("@strCnCompPartName", SqlDbType.NVarChar, 50)
                param(3).Value = propCompany.CompanyName

                param(4) = New SqlParameter("@strCnCompName", SqlDbType.NVarChar, 100)
                param(4).Value = propCompany.Address1

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Company", param)
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

        Private Function DeleteCompany(ByVal propCompany As clsPropCompany, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = propCompany.Id

                param(1) = New SqlParameter("@intIsDeleted", SqlDbType.Int)
                param(1).Value = intDeleteType

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Company", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Company_List", param)
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
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Company_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Company_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 14 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropCompany
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropCompany)
                    tmpProp.Id = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.CompanyCode = strRow(1)
                tmpProp.CompanyName = strRow(2)
                tmpProp.Address1 = strRow(3)
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropCompany = CType(CurrentProp, clsPropCompany)
            blnReturn = InsertCompany(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.CompanyCode)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.CompanyCode)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropCompany = CType(CurrentProp, clsPropCompany)
            blnReturn = UpdateCompany(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.CompanyCode)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.CompanyCode)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropCompany = CType(CurrentProp, clsPropCompany)
            blnReturn = DeleteCompany(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.CompanyCode)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.CompanyCode)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropCompany = CType(CurrentProp, clsPropCompany)
            blnReturn = DeleteCompany(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.CompanyCode)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.CompanyCode)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
    End Class

#End Region

#Region " Class of Company List "

    <Serializable()> _
    Public Class clsCompanyList
        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Company")
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
    End Class

#End Region
End Namespace