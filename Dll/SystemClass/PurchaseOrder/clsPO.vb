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

#Region " Class Collection of PO Info "

    <Serializable()> _
    Public Class colPO
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropPO(ConClass.NewIdValue.ToString)
        End Function
    End Class
#End Region
#Region " Class Server of PO Info "

    <Serializable()> _
    Public Class clsPO
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
            colProp = New colPO()
            Title = "PO"
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
            colProp = New colPO()
            Title = "PO"
        End Sub
        Private Function InsertPO(ByRef propPO As clsPropPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(49) As SqlParameter
                param(0) = New SqlParameter("@CompanyName", SqlDbType.NVarChar, 50)
                param(1) = New SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                param(2) = New SqlParameter("@Address1", SqlDbType.NVarChar, 100)
                param(3) = New SqlParameter("@City", SqlDbType.NVarChar, 3)
                param(4) = New SqlParameter("@PostalCode", SqlDbType.NVarChar, 50)
                param(5) = New SqlParameter("@Phone", SqlDbType.NVarChar, 50)
                param(6) = New SqlParameter("@Email", SqlDbType.NVarChar, 50)
                param(7) = New SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                param(8) = New SqlParameter("@Address2", SqlDbType.NVarChar, 100)
                param(9) = New SqlParameter("@State", SqlDbType.NVarChar, 50)
                param(10) = New SqlParameter("@Country", SqlDbType.NVarChar, 3)
                param(11) = New SqlParameter("@Fax", SqlDbType.NVarChar, 50)
                param(12) = New SqlParameter("@PONo", SqlDbType.NVarChar, 50)
                param(13) = New SqlParameter("@POCurrCode", SqlDbType.NVarChar, 3)
                param(14) = New SqlParameter("@IncoTerm", SqlDbType.NVarChar, 5)
                param(15) = New SqlParameter("@POAmt", SqlDbType.Decimal)
                param(16) = New SqlParameter("@POIssueDate", SqlDbType.DateTime)
                param(17) = New SqlParameter("@ModeOfTransport", SqlDbType.NVarChar, 50)
                param(18) = New SqlParameter("@InvoiceNo", SqlDbType.NVarChar, 50)
                param(19) = New SqlParameter("@PODescription", SqlDbType.NVarChar, 50)
                param(20) = New SqlParameter("@SupplierName", SqlDbType.NVarChar, 50)
                param(21) = New SqlParameter("@SupplierFirstName", SqlDbType.NVarChar, 50)
                param(22) = New SqlParameter("@SupplierLastName", SqlDbType.NVarChar, 50)
                param(23) = New SqlParameter("@SupplierAddr1", SqlDbType.NVarChar, 50)
                param(24) = New SqlParameter("@SupplierAddr2", SqlDbType.NVarChar, 50)
                param(25) = New SqlParameter("@SupplierCity", SqlDbType.NVarChar, 3)
                param(26) = New SqlParameter("@SupplierState", SqlDbType.NVarChar, 50)
                param(27) = New SqlParameter("@SupplierPostalCode", SqlDbType.NVarChar, 50)
                param(28) = New SqlParameter("@SupplierCountry", SqlDbType.NVarChar, 3)
                param(29) = New SqlParameter("@SupplierPhone", SqlDbType.NVarChar, 50)
                param(30) = New SqlParameter("@SupplierFax", SqlDbType.NVarChar, 50)
                param(31) = New SqlParameter("@SupplierEmail", SqlDbType.NVarChar, 80)
                param(32) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(32).Direction = ParameterDirection.Output
                param(33) = New SqlParameter("@PartialPOFlag", SqlDbType.NVarChar, 1)
                param(34) = New SqlParameter("@BusinessPartyCode", SqlDbType.NVarChar, 10)
                param(35) = New SqlParameter("@ContactPerson", SqlDbType.NVarChar, 50)
                param(36) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 5)
                param(37) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 5)
                param(38) = New SqlParameter("@ShipToName", SqlDbType.NVarChar, 100)
                param(39) = New SqlParameter("@ShipToAddress1", SqlDbType.NVarChar, 100)
                param(40) = New SqlParameter("@ShipToAddress2", SqlDbType.NVarChar, 100)
                param(41) = New SqlParameter("@ShipToAddress3", SqlDbType.NVarChar, 100)
                param(42) = New SqlParameter("@ShipToAddress4", SqlDbType.NVarChar, 100)
                param(43) = New SqlParameter("@ShipToEmail", SqlDbType.NVarChar, 50)
                param(44) = New SqlParameter("@ShipToPhone", SqlDbType.NVarChar, 30)
                param(45) = New SqlParameter("@ShipToFax", SqlDbType.NVarChar, 30)
                param(46) = New SqlParameter("@ETA", SqlDbType.DateTime)
                param(47) = New SqlParameter("@ETD", SqlDbType.DateTime)
                param(48) = New SqlParameter("@RequiredDate", SqlDbType.DateTime)
                param(49) = New SqlParameter("@IncoTermCity", SqlDbType.NVarChar, 3)
                param(0).Value = propPO.CompanyName
                param(1).Value = propPO.FirstName
                param(2).Value = propPO.Address1
                param(3).Value = propPO.City
                param(4).Value = propPO.PostalCode
                param(5).Value = propPO.Phone
                param(6).Value = propPO.Email
                param(7).Value = propPO.LastName
                param(8).Value = propPO.Address2
                param(9).Value = propPO.State
                param(10).Value = propPO.Country
                param(11).Value = propPO.Fax
                param(12).Value = propPO.PONo
                param(13).Value = propPO.POCurrCode
                param(14).Value = propPO.IncoTerm
                param(15).Value = propPO.POAmt
                param(16).Value = propPO.POIssueDate
                param(17).Value = propPO.ModeOfTransport
                param(18).Value = propPO.InvoiceNo
                param(19).Value = propPO.PODescription
                param(20).Value = propPO.SupplierName
                param(21).Value = propPO.SupplierFirstName
                param(22).Value = propPO.SupplierLastName
                param(23).Value = propPO.SupplierAddr1
                param(24).Value = propPO.SupplierAddr2
                param(25).Value = propPO.SupplierCity
                param(26).Value = propPO.SupplierState
                param(27).Value = propPO.SupplierPostalCode
                param(28).Value = propPO.SupplierCountry
                param(29).Value = propPO.SupplierPhone
                param(30).Value = propPO.SupplierFax
                param(31).Value = propPO.SupplierEmail
                param(32).Value = propPO.TrxNo
                param(33).Value = propPO.PartialPOFlag
                param(34).Value = propPO.BusinessPartyCode
                param(35).Value = propPO.ContactPerson
                param(36).Value = propPO.PortOfLoadingCode
                param(37).Value = propPO.PortOfDischargeCode
                param(38).Value = propPO.ShipToName
                param(39).Value = propPO.ShipToAddress1
                param(40).Value = propPO.ShipToAddress2
                param(41).Value = propPO.ShipToAddress3
                param(42).Value = propPO.ShipToAddress4
                param(43).Value = propPO.ShipToEmail
                param(44).Value = propPO.ShipToPhone
                param(45).Value = propPO.ShipToFax
                param(46).Value = propPO.ETA
                param(47).Value = propPO.ETD
                param(48).Value = propPO.RequiredDate
                param(49).Value = propPO.IncoTermCity
                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Popo1", param)
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
        Private Function UpdatePO(ByVal propPO As clsPropPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
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
        Private Function DeletePO(ByVal propPO As clsPropPO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propPO.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Popo1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Popo1_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Popo1_Detail", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_POPO1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length < 51 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropPO
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                'ship to info
                tmpProp.CompanyName = strRow(1)
                tmpProp.FirstName = strRow(2)
                tmpProp.Address1 = strRow(3)
                tmpProp.City = strRow(4)
                tmpProp.PostalCode = strRow(5)
                tmpProp.Phone = strRow(6)
                tmpProp.Email = strRow(7)
                tmpProp.LastName = strRow(8)
                tmpProp.Address2 = strRow(9)
                tmpProp.State = strRow(10)
                tmpProp.Country = strRow(11)
                tmpProp.Fax = strRow(12)
                tmpProp.PortOfLoadingCode = strRow(13)
                tmpProp.PortOfDischargeCode = strRow(14)
                'po info info
                tmpProp.PONo = strRow(15)
                tmpProp.POCurrCode = strRow(16)
                tmpProp.IncoTerm = strRow(17)
                tmpProp.IncoTermCity = strRow(18)
                tmpProp.POAmt = GeneralFun.StringToInt(strRow(19))
                tmpProp.POIssueDate = GeneralFun.StringToDate(strRow(20))
                tmpProp.ModeOfTransport = strRow(21)
                tmpProp.InvoiceNo = strRow(22)
                tmpProp.PODescription = strRow(23)
                'supplier 
                tmpProp.SupplierName = strRow(24)
                tmpProp.SupplierFirstName = strRow(25)
                tmpProp.SupplierLastName = strRow(26)
                tmpProp.SupplierAddr1 = strRow(27)
                tmpProp.SupplierAddr2 = strRow(28)
                tmpProp.SupplierCity = strRow(29)
                tmpProp.SupplierState = strRow(30)
                tmpProp.SupplierPostalCode = strRow(31)
                tmpProp.SupplierCountry = strRow(32)
                tmpProp.SupplierPhone = strRow(33)
                tmpProp.SupplierFax = strRow(34)
                tmpProp.SupplierEmail = strRow(35)
                tmpProp.ContactPerson = strRow(36)
                tmpProp.ShipToName = strRow(37)
                tmpProp.ShipToAddress1 = strRow(38)
                tmpProp.ShipToAddress2 = strRow(39)
                tmpProp.ShipToAddress3 = strRow(40)
                tmpProp.ShipToAddress4 = strRow(41)
                tmpProp.ShipToEmail = strRow(42)
                tmpProp.ShipToPhone = strRow(43)
                tmpProp.ShipToFax = strRow(44)

                tmpProp.PartialPOFlag = strRow(45)
                tmpProp.ETA = GeneralFun.StringToDate(strRow(46))
                tmpProp.ETD = GeneralFun.StringToDate(strRow(47))
                tmpProp.RequiredDate = GeneralFun.StringToDate(strRow(48))

                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropPO = CType(CurrentProp, clsPropPO)
            blnReturn = InsertPO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropPO = CType(CurrentProp, clsPropPO)
            blnReturn = UpdatePO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropPO = CType(CurrentProp, clsPropPO)
            blnReturn = DeletePO(tmpProp, conn, trans, 1, strMsg)
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