Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class Tank Detail Report"

    <Serializable()> _
    Public Class clsTankDetailReport
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            Dim arrValue As String() = GeneralFun.GetCol(strValue)
            If arrValue.Length <> 1 Then
                strMsg = ConMsgInfo.UnmatchedParam
                Return False
            End If
            If arrValue(0) <> "0" Then
                Dim strWhere As String = ""
                'Location
                SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("Tank_Cat", arrValue(0), 1))
                'Set Where Property
                SqlRelation.AddToWhereString(Where, strWhere)
            End If
            'Error Message
            strMsg = ""
            Return True
        End Function

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_rccf1_List", param)
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
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Public Overrides Function GetGroupList() As System.Data.DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                param(0).Value = Where

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_TankMasterListLessor", param)
                dt = ds.Tables(0)
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class of Property rccf1 "

    <Serializable()> _
    Public Class clsProprccf1
        Inherits clsProp
        Private _TrxNo As Int64
        Private _S_No As String
        Private _Comm_Date As DateTime
        Private _Tank_Cat As Integer
        Private _Lessor As String
        Private _Date_Manu As DateTime
        Private _Manufacturer As String
        Private _Plate As String
        Private _Tank_Type As String
        Private _Length As Integer
        Private _Breadth As Integer
        Private _Height As Integer
        Private _Material As String
        Private _Capacity As Integer
        Private _Max_g_Weight As Integer
        Private _Stacking As String
        Private _Tare_Weight As Integer
        Private _Work_press As Decimal
        Private _Test_press As Decimal
        Private _Thickness As Decimal
        Private _Insulation As String
        Private _Ext_Coat As String
        Private _Heat_surf As Decimal
        Private _Steam_press As Decimal
        Private _Top_access As String
        Private _Manhole As String
        Private _Dipstick As String
        Private _Valves As String
        Private _Thermometer As String
        Private _Top_outlet As String
        Private _Bot_outlet As String
        Private _Out_connect As String
        Private _Gaskets As String
        Private _Approvals As String
        Private _Name_of_file As String
        Private _Next_Test_Date As DateTime
        Private _Last_Test_Date As DateTime
        Private _Flag As String
        Private _CategoryName As String
        Private _TypeName As String
        Private _Deletable As Boolean

        Public Property TrxNo() As Int64
            Get
                Return _TrxNo
            End Get
            Set(ByVal value As Int64)
                _TrxNo = value
                Id = value
            End Set
        End Property

        Public Property S_No() As String
            Get
                Return _S_No
            End Get
            Set(ByVal Value As String)
                _S_No = Value
            End Set
        End Property

        Public Property Comm_Date() As DateTime
            Get
                Return _Comm_Date
            End Get
            Set(ByVal Value As DateTime)
                _Comm_Date = Value
            End Set
        End Property

        Public Property Tank_Cat() As Integer
            Get
                Return _Tank_Cat
            End Get
            Set(ByVal Value As Integer)
                _Tank_Cat = Value
            End Set
        End Property

        Public Property Lessor() As String
            Get
                Return _Lessor
            End Get
            Set(ByVal Value As String)
                _Lessor = Value
            End Set
        End Property

        Public Property Date_Manu() As DateTime
            Get
                Return _Date_Manu
            End Get
            Set(ByVal Value As DateTime)
                _Date_Manu = Value
            End Set
        End Property

        Public Property Manufacturer() As String
            Get
                Return _Manufacturer
            End Get
            Set(ByVal Value As String)
                _Manufacturer = Value
            End Set
        End Property

        Public Property Plate() As String
            Get
                Return _Plate
            End Get
            Set(ByVal Value As String)
                _Plate = Value
            End Set
        End Property

        Public Property Tank_Type() As String
            Get
                Return _Tank_Type
            End Get
            Set(ByVal Value As String)
                _Tank_Type = Value
            End Set
        End Property

        Public Property Length() As Integer
            Get
                Return _Length
            End Get
            Set(ByVal Value As Integer)
                _Length = Value
            End Set
        End Property

        Public Property Breadth() As Integer
            Get
                Return _Breadth
            End Get
            Set(ByVal Value As Integer)
                _Breadth = Value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return _Height
            End Get
            Set(ByVal Value As Integer)
                _Height = Value
            End Set
        End Property

        Public Property Material() As String
            Get
                Return _Material
            End Get
            Set(ByVal Value As String)
                _Material = Value
            End Set
        End Property

        Public Property Capacity() As Integer
            Get
                Return _Capacity
            End Get
            Set(ByVal Value As Integer)
                _Capacity = Value
            End Set
        End Property

        Public Property Max_g_Weight() As Integer
            Get
                Return _Max_g_Weight
            End Get
            Set(ByVal Value As Integer)
                _Max_g_Weight = Value
            End Set
        End Property

        Public Property Stacking() As String
            Get
                Return _Stacking
            End Get
            Set(ByVal Value As String)
                _Stacking = Value
            End Set
        End Property

        Public Property Tare_Weight() As Integer
            Get
                Return _Tare_Weight
            End Get
            Set(ByVal Value As Integer)
                _Tare_Weight = Value
            End Set
        End Property

        Public Property Work_press() As Double
            Get
                Return _Work_press
            End Get
            Set(ByVal Value As Double)
                _Work_press = Value
            End Set
        End Property

        Public Property Test_press() As Double
            Get
                Return _Test_press
            End Get
            Set(ByVal Value As Double)
                _Test_press = Value
            End Set
        End Property

        Public Property Thickness() As Double
            Get
                Return _Thickness
            End Get
            Set(ByVal Value As Double)
                _Thickness = Value
            End Set
        End Property

        Public Property Insulation() As String
            Get
                Return _Insulation
            End Get
            Set(ByVal Value As String)
                _Insulation = Value
            End Set
        End Property

        Public Property Ext_Coat() As String
            Get
                Return _Ext_Coat
            End Get
            Set(ByVal Value As String)
                _Ext_Coat = Value
            End Set
        End Property

        Public Property Heat_surf() As Double
            Get
                Return _Heat_surf
            End Get
            Set(ByVal Value As Double)
                _Heat_surf = Value
            End Set
        End Property

        Public Property Steam_press() As Double
            Get
                Return _Steam_press
            End Get
            Set(ByVal Value As Double)
                _Steam_press = Value
            End Set
        End Property

        Public Property Top_access() As String
            Get
                Return _Top_access
            End Get
            Set(ByVal Value As String)
                _Top_access = Value
            End Set
        End Property

        Public Property Manhole() As String
            Get
                Return _Manhole
            End Get
            Set(ByVal Value As String)
                _Manhole = Value
            End Set
        End Property

        Public Property Dipstick() As String
            Get
                Return _Dipstick
            End Get
            Set(ByVal Value As String)
                _Dipstick = Value
            End Set
        End Property

        Public Property Valves() As String
            Get
                Return _Valves
            End Get
            Set(ByVal Value As String)
                _Valves = Value
            End Set
        End Property

        Public Property Thermometer() As String
            Get
                Return _Thermometer
            End Get
            Set(ByVal Value As String)
                _Thermometer = Value
            End Set
        End Property

        Public Property Top_outlet() As String
            Get
                Return _Top_outlet
            End Get
            Set(ByVal Value As String)
                _Top_outlet = Value
            End Set
        End Property

        Public Property Bot_outlet() As String
            Get
                Return _Bot_outlet
            End Get
            Set(ByVal Value As String)
                _Bot_outlet = Value
            End Set
        End Property

        Public Property Out_connect() As String
            Get
                Return _Out_connect
            End Get
            Set(ByVal Value As String)
                _Out_connect = Value
            End Set
        End Property

        Public Property Gaskets() As String
            Get
                Return _Gaskets
            End Get
            Set(ByVal Value As String)
                _Gaskets = Value
            End Set
        End Property

        Public Property Approvals() As String
            Get
                Return _Approvals
            End Get
            Set(ByVal Value As String)
                _Approvals = Value
            End Set
        End Property

        Public Property Name_of_file() As String
            Get
                Return _Name_of_file
            End Get
            Set(ByVal Value As String)
                _Name_of_file = Value
            End Set
        End Property

        Public Property Next_Test_Date() As DateTime
            Get
                Return _Next_Test_Date
            End Get
            Set(ByVal Value As DateTime)
                _Next_Test_Date = Value
            End Set
        End Property

        Public Property Last_Test_Date() As DateTime
            Get
                Return _Last_Test_Date
            End Get
            Set(ByVal Value As DateTime)
                _Last_Test_Date = Value
            End Set
        End Property

        Public Property Flag() As String
            Get
                Return _Flag
            End Get
            Set(ByVal Value As String)
                _Flag = Value
            End Set
        End Property

        Public Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
            Set(ByVal value As String)
                _CategoryName = value
            End Set
        End Property

        Public Property TypeName() As String
            Get
                Return _TypeName
            End Get
            Set(ByVal value As String)
                _TypeName = value
            End Set
        End Property

        Public Property Deletable() As Boolean
            Get
                Return _Deletable
            End Get
            Set(ByVal value As Boolean)
                _Deletable = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _S_No = ""
            _Comm_Date = ConDateTime.MinDate
            _Tank_Cat = 0
            _Lessor = ""
            _Date_Manu = ConDateTime.MinDate
            _Manufacturer = ""
            _Plate = ""
            _Tank_Type = ""
            _Length = 0
            _Breadth = 0
            _Height = 0
            _Material = ""
            _Capacity = 0
            _Max_g_Weight = 0
            _Stacking = ""
            _Tare_Weight = 0
            _Work_press = 0
            _Test_press = 0
            _Thickness = 0
            _Insulation = ""
            _Ext_Coat = ""
            _Heat_surf = 0
            _Steam_press = 0
            _Top_access = ""
            _Manhole = ""
            _Dipstick = ""
            _Valves = ""
            _Thermometer = ""
            _Top_outlet = ""
            _Bot_outlet = ""
            _Out_connect = ""
            _Gaskets = ""
            _Approvals = ""
            _Name_of_file = ""
            _Next_Test_Date = ConDateTime.MinDate
            _Last_Test_Date = ConDateTime.MinDate
            _Flag = "1"
            _CategoryName = ""
            _TypeName = ""
            _Deletable = False
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property rccf1 "

    <Serializable()> _
    Public Class colrccf1
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsProprccf1(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of rccf1 Server "

    <Serializable()> _
    Public Class clsrccf1
        Inherits clsBaseSrv

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colrccf1()
            Title = "Tank Master"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Private Function Insertrccf1(ByVal proprccf1 As clsProprccf1, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(37) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = proprccf1.TrxNo

                param(1) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(1).Value = proprccf1.S_No

                param(2) = New SqlParameter("@Comm_Date", SqlDbType.SmallDateTime)
                param(2).Value = proprccf1.Comm_Date

                param(3) = New SqlParameter("@Tank_Cat", SqlDbType.SmallInt)
                param(3).Value = proprccf1.Tank_Cat

                param(4) = New SqlParameter("@Lessor", SqlDbType.NVarChar, 70)
                param(4).Value = proprccf1.Lessor

                param(5) = New SqlParameter("@Date_Manu", SqlDbType.SmallDateTime)
                param(5).Value = proprccf1.Date_Manu

                param(6) = New SqlParameter("@Manufacturer", SqlDbType.NVarChar, 70)
                param(6).Value = proprccf1.Manufacturer

                param(7) = New SqlParameter("@Plate", SqlDbType.NVarChar, 40)
                param(7).Value = proprccf1.Plate

                param(8) = New SqlParameter("@Tank_Type", SqlDbType.NVarChar, 7)
                param(8).Value = proprccf1.Tank_Type

                param(9) = New SqlParameter("@Length", SqlDbType.Int)
                param(9).Value = proprccf1.Length

                param(10) = New SqlParameter("@Breadth", SqlDbType.Int)
                param(10).Value = proprccf1.Breadth

                param(11) = New SqlParameter("@Height", SqlDbType.Int)
                param(11).Value = proprccf1.Height

                param(12) = New SqlParameter("@Material", SqlDbType.NVarChar, 70)
                param(12).Value = proprccf1.Material

                param(13) = New SqlParameter("@Capacity", SqlDbType.Int)
                param(13).Value = proprccf1.Capacity

                param(14) = New SqlParameter("@Max_g_Weight", SqlDbType.Int)
                param(14).Value = proprccf1.Max_g_Weight

                param(15) = New SqlParameter("@Stacking", SqlDbType.NVarChar, 70)
                param(15).Value = proprccf1.Stacking

                param(16) = New SqlParameter("@Tare_Weight", SqlDbType.Int)
                param(16).Value = proprccf1.Tare_Weight

                param(17) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(17).Value = proprccf1.Work_press

                param(18) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(18).Value = proprccf1.Test_press

                param(19) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(19).Value = proprccf1.Thickness

                param(20) = New SqlParameter("@Insulation", SqlDbType.NVarChar, 50)
                param(20).Value = proprccf1.Insulation

                param(21) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar, 50)
                param(21).Value = proprccf1.Ext_Coat

                param(22) = New SqlParameter("@Heat_surf", SqlDbType.Decimal)
                param(22).Value = proprccf1.Heat_surf

                param(23) = New SqlParameter("@Steam_press", SqlDbType.Decimal)
                param(23).Value = proprccf1.Steam_press

                param(24) = New SqlParameter("@Top_access", SqlDbType.NVarChar, 60)
                param(24).Value = proprccf1.Top_access

                param(25) = New SqlParameter("@Manhole", SqlDbType.NVarChar, 20)
                param(25).Value = proprccf1.Manhole

                param(26) = New SqlParameter("@Dipstick", SqlDbType.NVarChar, 60)
                param(26).Value = proprccf1.Dipstick

                param(27) = New SqlParameter("@Valves", SqlDbType.NVarChar, 40)
                param(27).Value = proprccf1.Valves

                param(28) = New SqlParameter("@Thermometer", SqlDbType.NVarChar, 40)
                param(28).Value = proprccf1.Thermometer

                param(29) = New SqlParameter("@Top_outlet", SqlDbType.NVarChar, 80)
                param(29).Value = proprccf1.Top_outlet

                param(30) = New SqlParameter("@Bot_outlet", SqlDbType.NVarChar, 70)
                param(30).Value = proprccf1.Bot_outlet

                param(31) = New SqlParameter("@Out_connect", SqlDbType.NVarChar, 70)
                param(31).Value = proprccf1.Out_connect

                param(32) = New SqlParameter("@Gaskets", SqlDbType.NVarChar, 70)
                param(32).Value = proprccf1.Gaskets

                param(33) = New SqlParameter("@Approvals", SqlDbType.NText)
                param(33).Value = proprccf1.Approvals

                param(34) = New SqlParameter("@Name_of_file", SqlDbType.NVarChar, 40)
                param(34).Value = proprccf1.Name_of_file

                param(35) = New SqlParameter("@Next_Test_Date", SqlDbType.SmallDateTime)
                param(35).Value = proprccf1.Next_Test_Date

                param(36) = New SqlParameter("@Last_Test_Date", SqlDbType.SmallDateTime)
                param(36).Value = proprccf1.Last_Test_Date

                param(37) = New SqlParameter("@Flag", SqlDbType.Char, 1)
                param(37).Value = proprccf1.Flag

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_rccf1", param)
                If intResult > 0 Then
                    proprccf1.TrxNo = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function Updaterccf1(ByVal proprccf1 As clsProprccf1, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(37) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = proprccf1.TrxNo

                param(1) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(1).Value = proprccf1.S_No

                param(2) = New SqlParameter("@Comm_Date", SqlDbType.SmallDateTime)
                param(2).Value = proprccf1.Comm_Date

                param(3) = New SqlParameter("@Tank_Cat", SqlDbType.SmallInt)
                param(3).Value = proprccf1.Tank_Cat

                param(4) = New SqlParameter("@Lessor", SqlDbType.NVarChar, 70)
                param(4).Value = proprccf1.Lessor

                param(5) = New SqlParameter("@Date_Manu", SqlDbType.SmallDateTime)
                param(5).Value = proprccf1.Date_Manu

                param(6) = New SqlParameter("@Manufacturer", SqlDbType.NVarChar, 70)
                param(6).Value = proprccf1.Manufacturer

                param(7) = New SqlParameter("@Plate", SqlDbType.NVarChar, 40)
                param(7).Value = proprccf1.Plate

                param(8) = New SqlParameter("@Tank_Type", SqlDbType.NVarChar, 7)
                param(8).Value = proprccf1.Tank_Type

                param(9) = New SqlParameter("@Length", SqlDbType.Int)
                param(9).Value = proprccf1.Length

                param(10) = New SqlParameter("@Breadth", SqlDbType.Int)
                param(10).Value = proprccf1.Breadth

                param(11) = New SqlParameter("@Height", SqlDbType.Int)
                param(11).Value = proprccf1.Height

                param(12) = New SqlParameter("@Material", SqlDbType.NVarChar, 70)
                param(12).Value = proprccf1.Material

                param(13) = New SqlParameter("@Capacity", SqlDbType.Int)
                param(13).Value = proprccf1.Capacity

                param(14) = New SqlParameter("@Max_g_Weight", SqlDbType.Int)
                param(14).Value = proprccf1.Max_g_Weight

                param(15) = New SqlParameter("@Stacking", SqlDbType.NVarChar, 70)
                param(15).Value = proprccf1.Stacking

                param(16) = New SqlParameter("@Tare_Weight", SqlDbType.Int)
                param(16).Value = proprccf1.Tare_Weight

                param(17) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(17).Value = proprccf1.Work_press

                param(18) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(18).Value = proprccf1.Test_press

                param(19) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(19).Value = proprccf1.Thickness

                param(20) = New SqlParameter("@Insulation", SqlDbType.NVarChar, 50)
                param(20).Value = proprccf1.Insulation

                param(21) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar, 50)
                param(21).Value = proprccf1.Ext_Coat

                param(22) = New SqlParameter("@Heat_surf", SqlDbType.Decimal)
                param(22).Value = proprccf1.Heat_surf

                param(23) = New SqlParameter("@Steam_press", SqlDbType.Decimal)
                param(23).Value = proprccf1.Steam_press

                param(24) = New SqlParameter("@Top_access", SqlDbType.NVarChar, 60)
                param(24).Value = proprccf1.Top_access

                param(25) = New SqlParameter("@Manhole", SqlDbType.NVarChar, 20)
                param(25).Value = proprccf1.Manhole

                param(26) = New SqlParameter("@Dipstick", SqlDbType.NVarChar, 60)
                param(26).Value = proprccf1.Dipstick

                param(27) = New SqlParameter("@Valves", SqlDbType.NVarChar, 40)
                param(27).Value = proprccf1.Valves

                param(28) = New SqlParameter("@Thermometer", SqlDbType.NVarChar, 40)
                param(28).Value = proprccf1.Thermometer

                param(29) = New SqlParameter("@Top_outlet", SqlDbType.NVarChar, 80)
                param(29).Value = proprccf1.Top_outlet

                param(30) = New SqlParameter("@Bot_outlet", SqlDbType.NVarChar, 70)
                param(30).Value = proprccf1.Bot_outlet

                param(31) = New SqlParameter("@Out_connect", SqlDbType.NVarChar, 70)
                param(31).Value = proprccf1.Out_connect

                param(32) = New SqlParameter("@Gaskets", SqlDbType.NVarChar, 70)
                param(32).Value = proprccf1.Gaskets

                param(33) = New SqlParameter("@Approvals", SqlDbType.NText)
                param(33).Value = proprccf1.Approvals

                param(34) = New SqlParameter("@Name_of_file", SqlDbType.NVarChar, 40)
                param(34).Value = proprccf1.Name_of_file

                param(35) = New SqlParameter("@Next_Test_Date", SqlDbType.SmallDateTime)
                param(35).Value = proprccf1.Next_Test_Date

                param(36) = New SqlParameter("@Last_Test_Date", SqlDbType.SmallDateTime)
                param(36).Value = proprccf1.Last_Test_Date

                param(37) = New SqlParameter("@Flag", SqlDbType.Char, 1)
                param(37).Value = proprccf1.Flag

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

        Private Function Deleterccf1(ByVal proprccf1 As clsProprccf1, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = proprccf1.Id

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
                param(0).Value = UserId

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

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 37 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsProprccf1
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsProprccf1)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.S_No = strRow(1)
                tmpProp.Comm_Date = GeneralFun.StringToDate(strRow(2))
                tmpProp.Tank_Cat = strRow(3)
                tmpProp.Lessor = strRow(4)
                tmpProp.Date_Manu = GeneralFun.StringToDate(strRow(5))
                tmpProp.Manufacturer = strRow(6)
                tmpProp.Plate = strRow(7)
                tmpProp.Tank_Type = strRow(8)
                tmpProp.Length = Integer.Parse(strRow(9).Replace(",", ""))
                tmpProp.Breadth = Integer.Parse(strRow(10).Replace(",", ""))
                tmpProp.Height = Integer.Parse(strRow(11).Replace(",", ""))
                tmpProp.Material = strRow(12)
                tmpProp.Capacity = Integer.Parse(strRow(13).Replace(",", ""))
                tmpProp.Max_g_Weight = Integer.Parse(strRow(14).Replace(",", ""))
                tmpProp.Stacking = strRow(15)
                tmpProp.Tare_Weight = Integer.Parse(strRow(16).Replace(",", ""))
                tmpProp.Work_press = GeneralFun.StringToDecimal(strRow(17))
                tmpProp.Test_press = GeneralFun.StringToDecimal(strRow(18))
                tmpProp.Thickness = GeneralFun.StringToDecimal(strRow(19))
                tmpProp.Insulation = strRow(20)
                tmpProp.Ext_Coat = strRow(21)
                tmpProp.Heat_surf = GeneralFun.StringToDecimal(strRow(22))
                tmpProp.Steam_press = GeneralFun.StringToDecimal(strRow(23))
                tmpProp.Top_access = strRow(24)
                tmpProp.Manhole = strRow(25)
                tmpProp.Dipstick = strRow(26)
                tmpProp.Valves = strRow(27)
                tmpProp.Thermometer = strRow(28)
                tmpProp.Top_outlet = strRow(29)
                tmpProp.Bot_outlet = strRow(30)
                tmpProp.Out_connect = strRow(31)
                tmpProp.Gaskets = strRow(32)
                tmpProp.Approvals = strRow(33)
                tmpProp.Name_of_file = strRow(34)
                tmpProp.Next_Test_Date = GeneralFun.StringToDate(strRow(35))
                tmpProp.Last_Test_Date = GeneralFun.StringToDate(strRow(36))
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            blnReturn = Insertrccf1(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            blnReturn = Updaterccf1(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            blnReturn = Deleterccf1(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            blnReturn = Deleterccf1(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsProprccf1 = CType(CurrentProp, clsProprccf1)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region
#Region " Class of clsrccf1bylzw Server 081121 lzw "

    <Serializable()> _
    Public Class clsrccf1bylzw
        Inherits clsBaseSrv

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colrccf1()
            Title = "Tank Master"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_Delete_List", param)
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
        Public Function GetDeleteDetail(ByVal intId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_delete_Detail", param)
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
                param(0) = New SqlParameter("@S_No", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_rccf1_delete_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 37 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsProprccf1
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsProprccf1)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.S_No = strRow(1)
                tmpProp.Comm_Date = GeneralFun.StringToDate(strRow(2))
                tmpProp.Tank_Cat = strRow(3)
                tmpProp.Lessor = strRow(4)
                tmpProp.Date_Manu = GeneralFun.StringToDate(strRow(5))
                tmpProp.Manufacturer = strRow(6)
                tmpProp.Plate = strRow(7)
                tmpProp.Tank_Type = strRow(8)
                tmpProp.Length = Integer.Parse(strRow(9).Replace(",", ""))
                tmpProp.Breadth = Integer.Parse(strRow(10).Replace(",", ""))
                tmpProp.Height = Integer.Parse(strRow(11).Replace(",", ""))
                tmpProp.Material = strRow(12)
                tmpProp.Capacity = Integer.Parse(strRow(13).Replace(",", ""))
                tmpProp.Max_g_Weight = Integer.Parse(strRow(14).Replace(",", ""))
                tmpProp.Stacking = strRow(15)
                tmpProp.Tare_Weight = Integer.Parse(strRow(16).Replace(",", ""))
                tmpProp.Work_press = GeneralFun.StringToDecimal(strRow(17))
                tmpProp.Test_press = GeneralFun.StringToDecimal(strRow(18))
                tmpProp.Thickness = GeneralFun.StringToDecimal(strRow(19))
                tmpProp.Insulation = strRow(20)
                tmpProp.Ext_Coat = strRow(21)
                tmpProp.Heat_surf = GeneralFun.StringToDecimal(strRow(22))
                tmpProp.Steam_press = GeneralFun.StringToDecimal(strRow(23))
                tmpProp.Top_access = strRow(24)
                tmpProp.Manhole = strRow(25)
                tmpProp.Dipstick = strRow(26)
                tmpProp.Valves = strRow(27)
                tmpProp.Thermometer = strRow(28)
                tmpProp.Top_outlet = strRow(29)
                tmpProp.Bot_outlet = strRow(30)
                tmpProp.Out_connect = strRow(31)
                tmpProp.Gaskets = strRow(32)
                tmpProp.Approvals = strRow(33)
                tmpProp.Name_of_file = strRow(34)
                tmpProp.Next_Test_Date = GeneralFun.StringToDate(strRow(35))
                tmpProp.Last_Test_Date = GeneralFun.StringToDate(strRow(36))
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
    End Class

#End Region
#Region " Class of Property Tank_Type "

    <Serializable()> _
    Public Class clsPropTank_Type
        Inherits clsProp
        Private _TrxNo As Int64
        Private _Tank_Type As String
        Private _Length As Integer
        Private _Breadth As Integer
        Private _Height As Integer
        Private _Material As String
        Private _Capacity As Integer
        Private _Max_g_Weight As Integer
        Private _Stacking As String
        Private _Tare_Weight As Integer
        Private _Work_press As Decimal
        Private _Test_press As Decimal
        Private _Thickness As Decimal
        Private _Insulation As String
        Private _Ext_Coat As String
        Private _Heat_surf As Decimal
        Private _Steam_press As Decimal
        Private _Top_access As String
        Private _Manhole As String
        Private _Dipstick As String
        Private _Valves As String
        Private _Thermometer As String
        Private _Top_outlet As String
        Private _Bot_outlet As String
        Private _Out_connect As String
        Private _Gaskets As String
        Private _Approvals As String
        Private _Flag As String
        Private _Deletable As Boolean

        Public Property TrxNo() As Int64
            Get
                Return _TrxNo
            End Get
            Set(ByVal value As Int64)
                _TrxNo = value
                Id = value
            End Set
        End Property

        Public Property Tank_Type() As String
            Get
                Return _Tank_Type
            End Get
            Set(ByVal Value As String)
                _Tank_Type = Value
            End Set
        End Property

        Public Property Length() As Integer
            Get
                Return _Length
            End Get
            Set(ByVal Value As Integer)
                _Length = Value
            End Set
        End Property

        Public Property Breadth() As Integer
            Get
                Return _Breadth
            End Get
            Set(ByVal Value As Integer)
                _Breadth = Value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return _Height
            End Get
            Set(ByVal Value As Integer)
                _Height = Value
            End Set
        End Property

        Public Property Material() As String
            Get
                Return _Material
            End Get
            Set(ByVal Value As String)
                _Material = Value
            End Set
        End Property

        Public Property Capacity() As Integer
            Get
                Return _Capacity
            End Get
            Set(ByVal Value As Integer)
                _Capacity = Value
            End Set
        End Property

        Public Property Max_g_Weight() As Integer
            Get
                Return _Max_g_Weight
            End Get
            Set(ByVal Value As Integer)
                _Max_g_Weight = Value
            End Set
        End Property

        Public Property Stacking() As String
            Get
                Return _Stacking
            End Get
            Set(ByVal Value As String)
                _Stacking = Value
            End Set
        End Property

        Public Property Tare_Weight() As Integer
            Get
                Return _Tare_Weight
            End Get
            Set(ByVal Value As Integer)
                _Tare_Weight = Value
            End Set
        End Property

        Public Property Work_press() As Double
            Get
                Return _Work_press
            End Get
            Set(ByVal Value As Double)
                _Work_press = Value
            End Set
        End Property

        Public Property Test_press() As Double
            Get
                Return _Test_press
            End Get
            Set(ByVal Value As Double)
                _Test_press = Value
            End Set
        End Property

        Public Property Thickness() As Double
            Get
                Return _Thickness
            End Get
            Set(ByVal Value As Double)
                _Thickness = Value
            End Set
        End Property

        Public Property Insulation() As String
            Get
                Return _Insulation
            End Get
            Set(ByVal Value As String)
                _Insulation = Value
            End Set
        End Property

        Public Property Ext_Coat() As String
            Get
                Return _Ext_Coat
            End Get
            Set(ByVal Value As String)
                _Ext_Coat = Value
            End Set
        End Property

        Public Property Heat_surf() As Double
            Get
                Return _Heat_surf
            End Get
            Set(ByVal Value As Double)
                _Heat_surf = Value
            End Set
        End Property

        Public Property Steam_press() As Double
            Get
                Return _Steam_press
            End Get
            Set(ByVal Value As Double)
                _Steam_press = Value
            End Set
        End Property

        Public Property Top_access() As String
            Get
                Return _Top_access
            End Get
            Set(ByVal Value As String)
                _Top_access = Value
            End Set
        End Property

        Public Property Manhole() As String
            Get
                Return _Manhole
            End Get
            Set(ByVal Value As String)
                _Manhole = Value
            End Set
        End Property

        Public Property Dipstick() As String
            Get
                Return _Dipstick
            End Get
            Set(ByVal Value As String)
                _Dipstick = Value
            End Set
        End Property

        Public Property Valves() As String
            Get
                Return _Valves
            End Get
            Set(ByVal Value As String)
                _Valves = Value
            End Set
        End Property

        Public Property Thermometer() As String
            Get
                Return _Thermometer
            End Get
            Set(ByVal Value As String)
                _Thermometer = Value
            End Set
        End Property

        Public Property Top_outlet() As String
            Get
                Return _Top_outlet
            End Get
            Set(ByVal Value As String)
                _Top_outlet = Value
            End Set
        End Property

        Public Property Bot_outlet() As String
            Get
                Return _Bot_outlet
            End Get
            Set(ByVal Value As String)
                _Bot_outlet = Value
            End Set
        End Property

        Public Property Out_connect() As String
            Get
                Return _Out_connect
            End Get
            Set(ByVal Value As String)
                _Out_connect = Value
            End Set
        End Property

        Public Property Gaskets() As String
            Get
                Return _Gaskets
            End Get
            Set(ByVal Value As String)
                _Gaskets = Value
            End Set
        End Property

        Public Property Approvals() As String
            Get
                Return _Approvals
            End Get
            Set(ByVal Value As String)
                _Approvals = Value
            End Set
        End Property

        Public Property Flag() As String
            Get
                Return _Flag
            End Get
            Set(ByVal Value As String)
                _Flag = Value
            End Set
        End Property

        Public Property Deletable() As Boolean
            Get
                Return _Deletable
            End Get
            Set(ByVal value As Boolean)
                _Deletable = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _Tank_Type = ""
            _Length = 0
            _Breadth = 0
            _Height = 0
            _Material = ""
            _Capacity = 0
            _Max_g_Weight = 0
            _Stacking = ""
            _Tare_Weight = 0
            _Work_press = 0
            _Test_press = 0
            _Thickness = 0
            _Insulation = ""
            _Ext_Coat = ""
            _Heat_surf = 0
            _Steam_press = 0
            _Top_access = ""
            _Manhole = ""
            _Dipstick = ""
            _Valves = ""
            _Thermometer = ""
            _Top_outlet = ""
            _Bot_outlet = ""
            _Out_connect = ""
            _Gaskets = ""
            _Approvals = ""
            _Flag = "1"
            _Deletable = False
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Tank_Type "

    <Serializable()> _
    Public Class colTank_Type
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropTank_Type(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of Tank_Type Server "

    <Serializable()> _
    Public Class clsTank_Type
        Inherits clsBaseSrv
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colTank_Type()
            Title = "Tank Type"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Private Function InsertTank_Type(ByVal propTank_Type As clsPropTank_Type, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Type.TrxNo

                param(1) = New SqlParameter("@Tank_Type", SqlDbType.NVarChar, 7)
                param(1).Value = propTank_Type.Tank_Type

                param(2) = New SqlParameter("@Length", SqlDbType.Int)
                param(2).Value = propTank_Type.Length

                param(3) = New SqlParameter("@Breadth", SqlDbType.Int)
                param(3).Value = propTank_Type.Breadth

                param(4) = New SqlParameter("@Height", SqlDbType.Int)
                param(4).Value = propTank_Type.Height

                param(5) = New SqlParameter("@Material", SqlDbType.NVarChar, 70)
                param(5).Value = propTank_Type.Material

                param(6) = New SqlParameter("@Capacity", SqlDbType.Int)
                param(6).Value = propTank_Type.Capacity

                param(7) = New SqlParameter("@Max_g_Weight", SqlDbType.Int)
                param(7).Value = propTank_Type.Max_g_Weight

                param(8) = New SqlParameter("@Stacking", SqlDbType.NVarChar, 70)
                param(8).Value = propTank_Type.Stacking

                param(9) = New SqlParameter("@Tare_Weight", SqlDbType.Int)
                param(9).Value = propTank_Type.Tare_Weight

                param(10) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(10).Value = propTank_Type.Work_press

                param(11) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(11).Value = propTank_Type.Test_press

                param(12) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(12).Value = propTank_Type.Thickness

                param(13) = New SqlParameter("@Insulation", SqlDbType.NVarChar, 50)
                param(13).Value = propTank_Type.Insulation

                param(14) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar, 50)
                param(14).Value = propTank_Type.Ext_Coat

                param(15) = New SqlParameter("@Heat_surf", SqlDbType.Decimal)
                param(15).Value = propTank_Type.Heat_surf

                param(16) = New SqlParameter("@Steam_press", SqlDbType.Decimal)
                param(16).Value = propTank_Type.Steam_press

                param(17) = New SqlParameter("@Top_access", SqlDbType.NVarChar, 60)
                param(17).Value = propTank_Type.Top_access

                param(18) = New SqlParameter("@Manhole", SqlDbType.NVarChar, 20)
                param(18).Value = propTank_Type.Manhole

                param(19) = New SqlParameter("@Dipstick", SqlDbType.NVarChar, 60)
                param(19).Value = propTank_Type.Dipstick

                param(20) = New SqlParameter("@Valves", SqlDbType.NVarChar, 40)
                param(20).Value = propTank_Type.Valves

                param(21) = New SqlParameter("@Thermometer", SqlDbType.NVarChar, 40)
                param(21).Value = propTank_Type.Thermometer

                param(22) = New SqlParameter("@Top_outlet", SqlDbType.NVarChar, 80)
                param(22).Value = propTank_Type.Top_outlet

                param(23) = New SqlParameter("@Bot_outlet", SqlDbType.NVarChar, 70)
                param(23).Value = propTank_Type.Bot_outlet

                param(24) = New SqlParameter("@Out_connect", SqlDbType.NVarChar, 70)
                param(24).Value = propTank_Type.Out_connect

                param(25) = New SqlParameter("@Gaskets", SqlDbType.NVarChar, 70)
                param(25).Value = propTank_Type.Gaskets

                param(26) = New SqlParameter("@Approvals", SqlDbType.NText)
                param(26).Value = propTank_Type.Approvals

                param(27) = New SqlParameter("@Flag", SqlDbType.Char, 1)
                param(27).Value = propTank_Type.Flag


                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Tank_Type", param)
                If intResult > 0 Then
                    propTank_Type.TrxNo = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateTank_Type(ByVal propTank_Type As clsPropTank_Type, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Type.TrxNo

                param(1) = New SqlParameter("@Tank_Type", SqlDbType.NVarChar, 7)
                param(1).Value = propTank_Type.Tank_Type

                param(2) = New SqlParameter("@Length", SqlDbType.Int)
                param(2).Value = propTank_Type.Length

                param(3) = New SqlParameter("@Breadth", SqlDbType.Int)
                param(3).Value = propTank_Type.Breadth

                param(4) = New SqlParameter("@Height", SqlDbType.Int)
                param(4).Value = propTank_Type.Height

                param(5) = New SqlParameter("@Material", SqlDbType.NVarChar, 70)
                param(5).Value = propTank_Type.Material

                param(6) = New SqlParameter("@Capacity", SqlDbType.Int)
                param(6).Value = propTank_Type.Capacity

                param(7) = New SqlParameter("@Max_g_Weight", SqlDbType.Int)
                param(7).Value = propTank_Type.Max_g_Weight

                param(8) = New SqlParameter("@Stacking", SqlDbType.NVarChar, 70)
                param(8).Value = propTank_Type.Stacking

                param(9) = New SqlParameter("@Tare_Weight", SqlDbType.Int)
                param(9).Value = propTank_Type.Tare_Weight

                param(10) = New SqlParameter("@Work_press", SqlDbType.Decimal)
                param(10).Value = propTank_Type.Work_press

                param(11) = New SqlParameter("@Test_press", SqlDbType.Decimal)
                param(11).Value = propTank_Type.Test_press

                param(12) = New SqlParameter("@Thickness", SqlDbType.Decimal)
                param(12).Value = propTank_Type.Thickness

                param(13) = New SqlParameter("@Insulation", SqlDbType.NVarChar, 50)
                param(13).Value = propTank_Type.Insulation

                param(14) = New SqlParameter("@Ext_Coat", SqlDbType.NVarChar, 50)
                param(14).Value = propTank_Type.Ext_Coat

                param(15) = New SqlParameter("@Heat_surf", SqlDbType.Decimal)
                param(15).Value = propTank_Type.Heat_surf

                param(16) = New SqlParameter("@Steam_press", SqlDbType.Decimal)
                param(16).Value = propTank_Type.Steam_press

                param(17) = New SqlParameter("@Top_access", SqlDbType.NVarChar, 60)
                param(17).Value = propTank_Type.Top_access

                param(18) = New SqlParameter("@Manhole", SqlDbType.NVarChar, 20)
                param(18).Value = propTank_Type.Manhole

                param(19) = New SqlParameter("@Dipstick", SqlDbType.NVarChar, 60)
                param(19).Value = propTank_Type.Dipstick

                param(20) = New SqlParameter("@Valves", SqlDbType.NVarChar, 40)
                param(20).Value = propTank_Type.Valves

                param(21) = New SqlParameter("@Thermometer", SqlDbType.NVarChar, 40)
                param(21).Value = propTank_Type.Thermometer

                param(22) = New SqlParameter("@Top_outlet", SqlDbType.NVarChar, 80)
                param(22).Value = propTank_Type.Top_outlet

                param(23) = New SqlParameter("@Bot_outlet", SqlDbType.NVarChar, 70)
                param(23).Value = propTank_Type.Bot_outlet

                param(24) = New SqlParameter("@Out_connect", SqlDbType.NVarChar, 70)
                param(24).Value = propTank_Type.Out_connect

                param(25) = New SqlParameter("@Gaskets", SqlDbType.NVarChar, 70)
                param(25).Value = propTank_Type.Gaskets

                param(26) = New SqlParameter("@Approvals", SqlDbType.NText)
                param(26).Value = propTank_Type.Approvals

                param(27) = New SqlParameter("@Flag", SqlDbType.Char, 1)
                param(27).Value = propTank_Type.Flag

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Tank_Type", param)
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

        Private Function DeleteTank_Type(ByVal propTank_Type As clsPropTank_Type, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Type.Id

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Tank_Type", param)
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
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Type_List", param)
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

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Type_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Function GetDetailAsString(ByVal intId As Int64) As String
            Dim tmpProp As clsPropTank_Type = GetDetail(intId)
            Dim strResult As String
            strResult = tmpProp.Length.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Breadth.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Height.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Material
            strResult = strResult + ConSeparator.Col + tmpProp.Capacity.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Max_g_Weight.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Stacking
            strResult = strResult + ConSeparator.Col + tmpProp.Tare_Weight.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Work_press.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Test_press.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Thickness.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Insulation
            strResult = strResult + ConSeparator.Col + tmpProp.Ext_Coat
            strResult = strResult + ConSeparator.Col + tmpProp.Heat_surf.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Steam_press.ToString()
            strResult = strResult + ConSeparator.Col + tmpProp.Top_access
            strResult = strResult + ConSeparator.Col + tmpProp.Manhole
            strResult = strResult + ConSeparator.Col + tmpProp.Dipstick
            strResult = strResult + ConSeparator.Col + tmpProp.Valves
            strResult = strResult + ConSeparator.Col + tmpProp.Thermometer
            strResult = strResult + ConSeparator.Col + tmpProp.Top_outlet
            strResult = strResult + ConSeparator.Col + tmpProp.Bot_outlet
            strResult = strResult + ConSeparator.Col + tmpProp.Out_connect
            strResult = strResult + ConSeparator.Col + tmpProp.Gaskets
            strResult = strResult + ConSeparator.Col + tmpProp.Approvals
            Return strResult
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 27 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropTank_Type
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropTank_Type)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.Tank_Type = strRow(1)
                tmpProp.Length = GeneralFun.StringToInt(strRow(2))
                tmpProp.Breadth = GeneralFun.StringToInt(strRow(3))
                tmpProp.Height = GeneralFun.StringToInt(strRow(4))
                tmpProp.Material = strRow(5)
                tmpProp.Capacity = GeneralFun.StringToInt(strRow(6))
                tmpProp.Max_g_Weight = GeneralFun.StringToInt(strRow(7))
                tmpProp.Stacking = strRow(8)
                tmpProp.Tare_Weight = GeneralFun.StringToInt(strRow(9))
                tmpProp.Work_press = GeneralFun.StringToDecimal(strRow(10))
                tmpProp.Test_press = GeneralFun.StringToDecimal(strRow(11))
                tmpProp.Thickness = GeneralFun.StringToDecimal(strRow(12))
                tmpProp.Insulation = strRow(13)
                tmpProp.Ext_Coat = strRow(14)
                tmpProp.Heat_surf = GeneralFun.StringToDecimal(strRow(15))
                tmpProp.Steam_press = GeneralFun.StringToDecimal(strRow(16))
                tmpProp.Top_access = strRow(17)
                tmpProp.Manhole = strRow(18)
                tmpProp.Dipstick = strRow(19)
                tmpProp.Valves = strRow(20)
                tmpProp.Thermometer = strRow(21)
                tmpProp.Top_outlet = strRow(22)
                tmpProp.Bot_outlet = strRow(23)
                tmpProp.Out_connect = strRow(24)
                tmpProp.Gaskets = strRow(25)
                tmpProp.Approvals = strRow(26)
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            blnReturn = InsertTank_Type(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.Tank_Type)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.Tank_Type)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            blnReturn = UpdateTank_Type(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.Tank_Type)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.Tank_Type)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            blnReturn = DeleteTank_Type(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.Tank_Type)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.Tank_Type)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            blnReturn = DeleteTank_Type(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.Tank_Type)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.Tank_Type)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.Tank_Type))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.Tank_Type))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.Tank_Type))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropTank_Type = CType(CurrentProp, clsPropTank_Type)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.Tank_Type))
        End Sub

    End Class

#End Region

#Region " Class of Property Tank_Update "

    <Serializable()> _
    Public Class clsPropTank_Update
        Inherits clsProp
        'From rccf1
        Private _TrxNo As Int64
        Private _S_No As String
        Private _Tank_Cat As Integer
        Private _Lessor As String
        Private _Tank_Type As String
        Private _Capacity As Integer
        Private _CategoryName As String
        Private _TypeName As String
        'From Tank_Update Table
        Private _Status As Integer
        Private _StartDate As DateTime
        Private _Location As String
        Private _Customer As String
        Private _Port As Integer
        Private _Chemical As String
        Private _Consignee As String
        Private _Remarks As String
        Private _Portl As Integer
        Private _StatusName As String
        Private _LocationName As String
        Private _CompanyName As String
        Private _LoadPort As String
        Private _DestPort As String
        Private _ChemicalName As String
        Private _LastStartDate As DateTime
        Private _UpdateTrxNo As Int64

        Public Property TrxNo() As Int64
            Get
                Return _TrxNo
            End Get
            Set(ByVal value As Int64)
                _TrxNo = value
                Id = value
            End Set
        End Property

        Public Property S_No() As String
            Get
                Return _S_No
            End Get
            Set(ByVal Value As String)
                _S_No = Value
            End Set
        End Property

        Public Property Tank_Cat() As Integer
            Get
                Return _Tank_Cat
            End Get
            Set(ByVal Value As Integer)
                _Tank_Cat = Value
            End Set
        End Property

        Public Property Lessor() As String
            Get
                Return _Lessor
            End Get
            Set(ByVal Value As String)
                _Lessor = Value
            End Set
        End Property

        Public Property Tank_Type() As String
            Get
                Return _Tank_Type
            End Get
            Set(ByVal Value As String)
                _Tank_Type = Value
            End Set
        End Property

        Public Property Capacity() As Integer
            Get
                Return _Capacity
            End Get
            Set(ByVal Value As Integer)
                _Capacity = Value
            End Set
        End Property

        Public Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
            Set(ByVal value As String)
                _CategoryName = value
            End Set
        End Property

        Public Property TypeName() As String
            Get
                Return _TypeName
            End Get
            Set(ByVal value As String)
                _TypeName = value
            End Set
        End Property

        Public Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal Value As Integer)
                _Status = Value
            End Set
        End Property

        Public Property StartDate() As DateTime
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As DateTime)
                _StartDate = Value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _Location
            End Get
            Set(ByVal Value As String)
                _Location = Value
            End Set
        End Property

        Public Property Customer() As String
            Get
                Return _Customer
            End Get
            Set(ByVal Value As String)
                _Customer = Value
            End Set
        End Property

        Public Property Port() As Integer
            Get
                Return _Port
            End Get
            Set(ByVal Value As Integer)
                _Port = Value
            End Set
        End Property

        Public Property Chemical() As String
            Get
                Return _Chemical
            End Get
            Set(ByVal Value As String)
                _Chemical = Value
            End Set
        End Property

        Public Property Consignee() As String
            Get
                Return _Consignee
            End Get
            Set(ByVal Value As String)
                _Consignee = Value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Return _Remarks
            End Get
            Set(ByVal Value As String)
                _Remarks = Value
            End Set
        End Property

        Public Property Portl() As Integer
            Get
                Return _Portl
            End Get
            Set(ByVal Value As Integer)
                _Portl = Value
            End Set
        End Property

        Public Property StatusName() As String
            Get
                Return _StatusName
            End Get
            Set(ByVal value As String)
                _StatusName = value
            End Set
        End Property

        Public Property LocationName() As String
            Get
                Return _LocationName
            End Get
            Set(ByVal value As String)
                _LocationName = value
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

        Public Property LoadPort() As String
            Get
                Return _LoadPort
            End Get
            Set(ByVal value As String)
                _LoadPort = value
            End Set
        End Property

        Public Property DestPort() As String
            Get
                Return _DestPort
            End Get
            Set(ByVal value As String)
                _DestPort = value
            End Set
        End Property

        Public Property ChemicalName() As String
            Get
                Return _ChemicalName
            End Get
            Set(ByVal value As String)
                _ChemicalName = value
            End Set
        End Property

        Public Property LastStartDate() As DateTime
            Get
                Return _LastStartDate
            End Get
            Set(ByVal Value As DateTime)
                _LastStartDate = Value
            End Set
        End Property

        Public Property UpdateTrxNo() As Int64
            Get
                Return _UpdateTrxNo
            End Get
            Set(ByVal value As Int64)
                _UpdateTrxNo = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _S_No = ""
            _Tank_Cat = 0
            _Lessor = ""
            _Tank_Type = ""
            _Capacity = 0
            _CategoryName = ""
            _TypeName = ""
            _Status = 0
            _StartDate = ConDateTime.MinDate
            _Location = ""
            _Customer = ""
            _Port = 0
            _Chemical = ""
            _Consignee = ""
            _Remarks = ""
            _Portl = 0
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Tank_Update "

    <Serializable()> _
    Public Class colTank_Update
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropTank_Update(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of Tank_Update Server "

    <Serializable()> _
    Public Class clsTank_Update
        Inherits clsBaseSrv
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colTank_Update()
            Title = "Tank Update"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Private Function InsertTank_Update(ByVal propTank_Update As clsPropTank_Update, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(10) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Direction = ParameterDirection.Output
                'param(0).Value = propTank_Update.TrxNo

                param(1) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(1).Value = propTank_Update.S_No

                param(2) = New SqlParameter("@Status", SqlDbType.SmallInt)
                param(2).Value = propTank_Update.Status

                param(3) = New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
                param(3).Value = propTank_Update.StartDate

                param(4) = New SqlParameter("@Location", SqlDbType.NVarChar, 3)
                param(4).Value = propTank_Update.Location

                param(5) = New SqlParameter("@Customer", SqlDbType.NVarChar, 10)
                param(5).Value = propTank_Update.Customer

                param(6) = New SqlParameter("@Port", SqlDbType.SmallInt)
                param(6).Value = propTank_Update.Port

                param(7) = New SqlParameter("@Chemical", SqlDbType.NVarChar, 5)
                param(7).Value = propTank_Update.Chemical

                param(8) = New SqlParameter("@Consignee", SqlDbType.NText)
                param(8).Value = propTank_Update.Consignee

                param(9) = New SqlParameter("@Remarks", SqlDbType.NText)
                param(9).Value = propTank_Update.Remarks

                param(10) = New SqlParameter("@Portl", SqlDbType.SmallInt)
                param(10).Value = propTank_Update.Portl

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Tank_Update", param)
                If intResult > 0 Then
                    propTank_Update.TrxNo = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateTank_Update(ByVal propTank_Update As clsPropTank_Update, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(10) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Update.TrxNo

                param(1) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(1).Value = propTank_Update.S_No

                param(2) = New SqlParameter("@Status", SqlDbType.SmallInt)
                param(2).Value = propTank_Update.Status

                param(3) = New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
                param(3).Value = propTank_Update.StartDate

                param(4) = New SqlParameter("@Location", SqlDbType.NVarChar, 3)
                param(4).Value = propTank_Update.Location

                param(5) = New SqlParameter("@Customer", SqlDbType.NVarChar, 10)
                param(5).Value = propTank_Update.Customer

                param(6) = New SqlParameter("@Port", SqlDbType.SmallInt)
                param(6).Value = propTank_Update.Port

                param(7) = New SqlParameter("@Chemical", SqlDbType.NVarChar, 5)
                param(7).Value = propTank_Update.Chemical

                param(8) = New SqlParameter("@Consignee", SqlDbType.NText)
                param(8).Value = propTank_Update.Consignee

                param(9) = New SqlParameter("@Remarks", SqlDbType.NText)
                param(9).Value = propTank_Update.Remarks

                param(10) = New SqlParameter("@Portl", SqlDbType.SmallInt)
                param(10).Value = propTank_Update.Portl

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Tank_Update", param)
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

        Private Function DeleteTank_Update(ByVal propTank_Update As clsPropTank_Update, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Update.UpdateTrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Tank_Update", param)
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
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Update_List", param)
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

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Update_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Function GetDetailFromTable(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Update_Detail_2", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        '081126lzw
        Public Function GetDeleteDetailFromTable(ByVal intId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@S_No", SqlDbType.NVarChar, 50)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Delete_Tank_Update_Detail_2", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 12 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropTank_Update
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropTank_Update)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Edit
                End If
                tmpProp.S_No = strRow(1)
                tmpProp.Status = GeneralFun.StringToInt(strRow(2))
                tmpProp.StartDate = GeneralFun.StringToDateTime(strRow(3))
                tmpProp.Location = strRow(4)
                tmpProp.Customer = strRow(5)
                tmpProp.Portl = GeneralFun.StringToInt(strRow(6))
                tmpProp.Port = GeneralFun.StringToInt(strRow(7))
                tmpProp.Chemical = GeneralFun.StringToInt(strRow(8))
                tmpProp.Consignee = strRow(9)
                tmpProp.Remarks = strRow(10)
                tmpProp.LastStartDate = GeneralFun.StringToDateTime(strRow(11))
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            blnReturn = InsertTank_Update(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            blnReturn = UpdateTank_Update(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            blnReturn = DeleteTank_Update(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            blnReturn = DeleteTank_Update(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            If tmpProp.StartDate <= ConDateTime.MinDate Then
                strMsg = "Start date of the tank status must input!"
                Return False
            End If
            If tmpProp.StartDate <= tmpProp.LastStartDate Then
                strMsg = "Start date of the new tank status cannot be earlier than the start date of the last status."
                Return False
            End If
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropTank_Update = CType(CurrentProp, clsPropTank_Update)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region

#Region " Class of Property Tank_Book "

    <Serializable()> _
    Public Class clsPropTank_Book
        Inherits clsProp
        Private _TrxNo As Int64
        'From rccf1
        Private _S_No As String
        Private _Tank_Cat As Integer
        Private _Lessor As String
        Private _Tank_Type As String
        Private _Capacity As Integer
        Private _CategoryName As String
        Private _TypeName As String
        'From Tank_Book
        Private _Book_No As String
        Private _Location As String
        Private _Start_From As DateTime
        Private _End_At As DateTime
        Private _LocationName As String
        Private _BookTrxNo As Int64

        Public Property TrxNo() As Int64
            Get
                Return _TrxNo
            End Get
            Set(ByVal value As Int64)
                _TrxNo = value
                Id = value
            End Set
        End Property

        Public Property S_No() As String
            Get
                Return _S_No
            End Get
            Set(ByVal Value As String)
                _S_No = Value
            End Set
        End Property

        Public Property Tank_Cat() As Integer
            Get
                Return _Tank_Cat
            End Get
            Set(ByVal Value As Integer)
                _Tank_Cat = Value
            End Set
        End Property

        Public Property Lessor() As String
            Get
                Return _Lessor
            End Get
            Set(ByVal Value As String)
                _Lessor = Value
            End Set
        End Property

        Public Property Tank_Type() As String
            Get
                Return _Tank_Type
            End Get
            Set(ByVal Value As String)
                _Tank_Type = Value
            End Set
        End Property

        Public Property Capacity() As Integer
            Get
                Return _Capacity
            End Get
            Set(ByVal Value As Integer)
                _Capacity = Value
            End Set
        End Property

        Public Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
            Set(ByVal value As String)
                _CategoryName = value
            End Set
        End Property

        Public Property TypeName() As String
            Get
                Return _TypeName
            End Get
            Set(ByVal value As String)
                _TypeName = value
            End Set
        End Property

        Public Property Book_No() As String
            Get
                Return _Book_No
            End Get
            Set(ByVal Value As String)
                _Book_No = Value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _Location
            End Get
            Set(ByVal Value As String)
                _Location = Value
            End Set
        End Property

        Public Property Start_From() As DateTime
            Get
                Return _Start_From
            End Get
            Set(ByVal Value As DateTime)
                _Start_From = Value
            End Set
        End Property

        Public Property End_At() As DateTime
            Get
                Return _End_At
            End Get
            Set(ByVal Value As DateTime)
                _End_At = Value
            End Set
        End Property

        Public Property LocationName() As String
            Get
                Return _LocationName
            End Get
            Set(ByVal Value As String)
                _LocationName = Value
            End Set
        End Property

        Public Property BookTrxNo() As Int64
            Get
                Return _BookTrxNo
            End Get
            Set(ByVal value As Int64)
                _BookTrxNo = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _S_No = ""
            _Tank_Cat = 0
            _Lessor = ""
            _Tank_Type = ""
            _Capacity = 0
            _CategoryName = ""
            _TypeName = ""
            _Book_No = ""
            _Location = ""
            _Start_From = ConDateTime.MinDate
            _End_At = ConDateTime.MinDate
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Tank_Book "

    <Serializable()> _
    Public Class colTank_Book
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropTank_Book(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of Tank_Book Server "

    <Serializable()> _
    Public Class clsTank_Book
        Inherits clsBaseSrv

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colTank_Book()
            Title = "Tank Booking"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Private Function InsertTank_Book(ByVal propTank_Book As clsPropTank_Book, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(5) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Direction = ParameterDirection.Output
                'param(0).Value = propTank_Book.TrxNo

                param(1) = New SqlParameter("@Book_No", SqlDbType.NVarChar, 10)
                param(1).Direction = ParameterDirection.Output
                'param(1).Value = propTank_Book.Book_No

                param(2) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(2).Value = propTank_Book.S_No

                param(3) = New SqlParameter("@Location", SqlDbType.NVarChar, 3)
                param(3).Value = propTank_Book.Location

                param(4) = New SqlParameter("@Start_From", SqlDbType.SmallDateTime)
                param(4).Value = propTank_Book.Start_From

                param(5) = New SqlParameter("@End_At", SqlDbType.SmallDateTime)
                param(5).Value = propTank_Book.End_At

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Tank_Book", param)
                If intResult > 0 Then
                    propTank_Book.TrxNo = Integer.Parse(param(0).Value.ToString())
                    propTank_Book.Book_No = param(1).Value.ToString()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateTank_Book(ByVal propTank_Book As clsPropTank_Book, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(5) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Book.TrxNo

                param(1) = New SqlParameter("@Book_No", SqlDbType.NVarChar, 10)
                param(1).Value = propTank_Book.Book_No

                param(2) = New SqlParameter("@S_No", SqlDbType.NVarChar, 12)
                param(2).Value = propTank_Book.S_No

                param(3) = New SqlParameter("@Location", SqlDbType.NVarChar, 3)
                param(3).Value = propTank_Book.Location

                param(4) = New SqlParameter("@Start_From", SqlDbType.SmallDateTime)
                param(4).Value = propTank_Book.Start_From

                param(5) = New SqlParameter("@End_At", SqlDbType.SmallDateTime)
                param(5).Value = propTank_Book.End_At

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Tank_Book", param)
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

        Private Function DeleteTank_Book(ByVal propTank_Book As clsPropTank_Book, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propTank_Book.BookTrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Tank_Book", param)
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
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Book_List", param)
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

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Tank_Book_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 5 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropTank_Book
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropTank_Book)
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.S_No = strRow(1)
                tmpProp.Location = strRow(2)
                tmpProp.Start_From = GeneralFun.StringToDate(strRow(3))
                tmpProp.End_At = GeneralFun.StringToDate(strRow(4))
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            blnReturn = InsertTank_Book(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            blnReturn = UpdateTank_Book(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            blnReturn = DeleteTank_Book(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            blnReturn = DeleteTank_Book(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.S_No)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.S_No)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            If tmpProp.Start_From > tmpProp.End_At Then
                strMsg = "Start date cannot be later than the end date."
                Return False
            End If
            If tmpProp.Start_From < ConDateTime.Today OrElse tmpProp.End_At < ConDateTime.Today Then
                strMsg = "Both start and end date of the tank booking must be later than now."
                Return False
            End If
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropTank_Book = CType(CurrentProp, clsPropTank_Book)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

        'Public Function GetLastBook(ByVal strSerialNo As String)

        'End Function

    End Class

#End Region

#Region " Class of Tank Type List "

    <Serializable()> _
    Public Class clsTankTypeList

        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_TankType")
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
    End Class

#End Region

#Region " Class of Tank Category List "

    <Serializable()> _
    Public Class clsTankCategoryList

        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_TankCategory")
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class of Tank Status List "

    <Serializable()> _
    Public Class clsTankStatusList

        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Status")
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class of TankUpdate Product List "

    <Serializable()> _
    Public Class clsTankProductList

        Public Function ListData(ByVal strSerialNo As String, ByVal strChemical As String) As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@S_No", SqlDbType.NVarChar, 20)
                param(0).Value = strSerialNo

                param(1) = New SqlParameter("@Chemical", SqlDbType.NVarChar, 10)
                param(1).Value = strChemical

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Tank_Update_ProductList", param)
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class Tank Query "

    <Serializable()> _
    Public Class clsTankQuery
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Private Function CheckCapacity(ByVal strCapacityFrom As String, ByVal strCapacityTo As String, ByRef intFrom As Integer, ByRef intTo As Integer, ByRef strMsg As String) As Boolean
            Dim errMsg1 As String = "Please enter a valid range of tank capacity."

            If (strCapacityFrom = "" OrElse strCapacityTo = "") Then
                strMsg = errMsg1
                Return False
            End If
            Dim decFrom As Integer = 0
            Dim decTo As Integer = 0
            If Not Decimal.TryParse(strCapacityFrom, decFrom) Then
                strMsg = errMsg1
                Return False
            End If
            If Not Decimal.TryParse(strCapacityTo, decTo) Then
                strMsg = errMsg1
                Return False
            End If
            If decFrom > decTo Then
                strMsg = errMsg1
                Return False
            End If
            intFrom = Decimal.Round(decFrom)
            intTo = Decimal.Round(decTo)
            Return True
        End Function

        Private Function CheckAvailable(ByVal strAvailableFrom As String, ByVal strAvailableTo As String, ByRef dtmFrom As DateTime, ByRef dtmTo As DateTime, ByRef strMsg As String) As Boolean
            Dim errMsg1 As String = "Please enter valid availability period."
            Dim errMsg2 As String = "The availability dates must be after today."
            If (strAvailableFrom = "" OrElse strAvailableTo = "") Then
                Return True
            End If
            dtmFrom = ConDateTime.MinDate
            dtmTo = ConDateTime.MinDate
            dtmFrom = GeneralFun.StringToDate(strAvailableFrom)
            If dtmFrom = ConDateTime.MinDate Then
                strMsg = errMsg1
                Return False
            End If
            dtmTo = GeneralFun.StringToDate(strAvailableTo)
            If dtmTo = ConDateTime.MinDate Then
                strMsg = errMsg1
                Return False
            End If
            If dtmFrom > dtmTo Then
                strMsg = errMsg1
                Return False
            End If
            If dtmFrom < ConDateTime.Today OrElse dtmTo < ConDateTime.Today Then
                strMsg = errMsg2
                Return False
            End If
            Return True
        End Function

        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            Dim arrValue As String() = GeneralFun.GetCol(strValue)
            Dim intFrom As Integer = 0
            Dim intTo As Integer = 0
            Dim dtmFrom As DateTime
            Dim dtmTo As DateTime
            If arrValue.Length <> 7 Then
                strMsg = ConMsgInfo.UnmatchedParam
                Return False
            ElseIf Not CheckCapacity(arrValue(1), arrValue(2), intFrom, intTo, strMsg) Then
                Return False
            ElseIf Not CheckAvailable(arrValue(5), arrValue(6), dtmFrom, dtmTo, strMsg) Then
                Return False
            End If
            Dim strWhere As String = ""
            'TankType
            SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("a.Tank_Type", arrValue(0), 1))
            'Capacity From >=
            SqlRelation.AddToWhereString(strWhere, SqlRelation.GetIntegerWhere("a.Capacity", intFrom.ToString(), 2))
            'Capacity To  <=
            SqlRelation.AddToWhereString(strWhere, SqlRelation.GetIntegerWhere("a.Capacity", intTo.ToString(), 1))
            'Cargo Type
            If arrValue(3) <> "" Then
                SqlRelation.AddToWhereString(strWhere, "s_no not in (select tt.s_no from tank_update tt where startdate = (select max(startdate) from tank_update tt2 where tt2.s_no = tt.s_no) and chemical not in ((select compatible from chemical where chemical = '" + SqlRelation.SqlSafe(arrValue(4)) + "') union(select distinct value from code_table where value = '+ SqlRelation.SqlSafe(arrValue(4)) + '))) ")
            End If
            'Location
            If arrValue(4) <> "" Then
                SqlRelation.AddToWhereString(strWhere, "S_No not in (select tt.S_No from Tank_Update tt where StartDate = (select max(StartDate) from Tank_Update tt2 where tt2.s_no = tt.s_no) and (location <> '" + SqlRelation.SqlSafe(arrValue(4)) + "' and location is not null)) ")

            End If
            If arrValue(5) <> "" AndAlso arrValue(6) <> "" Then
                If dtmFrom >= ConDateTime.Today AndAlso dtmTo >= ConDateTime.Today AndAlso dtmTo >= dtmFrom Then
                    SqlRelation.AddToWhereString(strWhere, "S_No not in (select tb.s_no from tank_book tb where not((start_from >'" + dtmTo.ToString(ConDateTime.SqlDateFormat) + "' or end_at <'" + dtmFrom.ToString(ConDateTime.SqlDateFormat) + "')))")
                End If
            End If
            'Set Where Property
            SqlRelation.AddToWhereString(Where, strWhere)
            'Error Message
            strMsg = ""
            Return True
        End Function

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_TankMaster_Query", param)
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
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class Tank Repair Report "

    <Serializable()> _
    Public Class clsTankRepairbylzw
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub
        '081205lzw
        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            Dim strWhere As String = ""
            Dim strWhere1 As String = ""
            Dim arrValue As String() = GeneralFun.GetCol(strValue)
            If arrValue(0) <> "0" Then
                If arrValue(0).ToString.Trim = "1" Then
                    strWhere = " and (a.Status=12 or Status=45)"
                ElseIf arrValue(0).ToString.Trim = "2" Then
                    strWhere = " and (a.Status=25 or Status=26)"
                End If
            End If
            If arrValue(1) <> "0" Then
                If arrValue(1).ToString.Trim = "3" Then
                    strWhere1 = " and StartDate1 is null"
                ElseIf arrValue(1).ToString.Trim = "4" Then
                    strWhere1 = " and StartDate1 is not null"
                End If
            End If
            strWhere = strWhere + strWhere1
            SqlRelation.AddToWhereString(Where, strWhere)
            'Error Message
            strMsg = ""
            Return True
        End Function
        ''lzw081002
        'Private Function ConvertDate(ByVal dt As System.Data.DataTable) As DataTable
        '    'Total value
        '    'Dim dr As New DataRow
        '    Dim i As Integer
        '    For i = 0 To dt.Rows.Count - 1
        '        If (dt.Rows(i)("Date_Out") = "01/01/1981") Then
        '            dt.Rows(i)("Date_Out") = System.DBNull.Value
        '        End If
        '    Next
        '    Return dt
        'End Function
        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = UserId

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

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Subleased_List", param)
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
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region
End Namespace