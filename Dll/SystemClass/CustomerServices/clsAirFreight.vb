Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.IO
Imports System.Globalization

Namespace SystemClass

#Region " Class of Air & Sea Query "

    <Serializable()> _
    Public Class clsAirSeaQuery
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            'If strValue = "" Then
            '    SqlRelation.AddToWhereString(Where, strValue)
            '    strMsg = ""
            '    Return True
            'End If
            Dim arrValue As String() = GeneralFun.GetCol(strValue)
            If arrValue.Length <> 7 Then
                strMsg = ConMsgInfo.UnmatchedParam
                Return False
            End If
            Dim strWhere As String = ""
            'CustomerCode
            SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("a.CustomerCode", arrValue(0), 1))
            'Search Value
            SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("a." + arrValue(1), arrValue(2), 0))
            'From 
            If arrValue(3) = "ETD" Or arrValue(3) = "ETA" Then
                If arrValue(4) <> "" Then
                    Dim dtmDate As DateTime = GeneralFun.StringToDateTime(arrValue(4))
                    If dtmDate <= ConDateTime.MinDate Then
                        strMsg = "You must input Date value ,the format is '" + ConDateTime.DateFormat + "'"
                        Return False
                    End If
                    SqlRelation.AddToWhereString(strWhere, SqlRelation.GetDateTimeWhere("a." + arrValue(3), dtmDate.ToString(ConDateTime.SqlDateFormat), 2))
                End If
                'To
                If arrValue(6) <> "" Then
                    Dim dtmDate As DateTime = GeneralFun.StringToDateTime(arrValue(6))
                    If dtmDate <= ConDateTime.MinDate Then
                        strMsg = "You must input Date value ,the format is '" + ConDateTime.DateFormat + "'"
                        Return False
                    End If
                    SqlRelation.AddToWhereString(strWhere, SqlRelation.GetDateTimeWhere("a." + arrValue(3), dtmDate.ToString(ConDateTime.SqlDateFormat), 1))
                End If
            Else
                SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("a." + arrValue(3), arrValue(4), 0))
            End If
            'To
            'SqlRelation.AddToWhereString(strWhere, SqlRelation.GetStringWhere("a." + arrValue(5), arrValue(6), 0))
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
                Dim param(9) As SqlParameter

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

                param(8) = New SqlParameter("@strFields", SqlDbType.NVarChar, 1000)
                param(8).Direction = ParameterDirection.Output

                param(9) = New SqlParameter("@DataBase", SqlDbType.NVarChar, 1000)
                param(9).Value = DataBase

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_List", param)
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

#Region " Class of Property Air Freight "

    <Serializable()> _
    Public Class clsPropAirFreight
        Inherits clsProp
        'From Jmjm1
        Private _JobNo As String
        Private _ReferenceNo As String
        Private _AWBBlNo As String
        Private _MawbOBLNo As String
        Private _OriginCode As String
        Private _DestCode As String
        Private _Pcs As Decimal
        Private _GrossWeight As Decimal
        Private _Volume As Decimal
        Private _Commodity As String
        'From Aiaw1 Table
        Private _FirstToDestCode As String
        Private _FirstByAirlineID As String
        Private _FirstFlightNo As String
        Private _FirstFlightDate As DateTime
        Private _SecondToDestCode As String
        Private _SecondByAirlineID As String
        Private _SecondFlightNo As String
        Private _SecondFlightDate As DateTime
        Private _ThirdToDestCode As String
        Private _ThirdByAirlineID As String
        Private _ThirdFlightNo As String
        Private _ThirdFlightDate As DateTime

        Property JobNo() As String
            Get
                Return _JobNo
            End Get
            Set(ByVal value As String)
                _JobNo = value
            End Set
        End Property

        Property ReferenceNo() As String
            Get
                Return _ReferenceNo
            End Get
            Set(ByVal value As String)
                _ReferenceNo = value
            End Set
        End Property

        Property AWBBlNo() As String
            Get
                Return _AWBBlNo
            End Get
            Set(ByVal value As String)
                _AWBBlNo = value
            End Set
        End Property

        Property MawbOBLNo() As String
            Get
                Return _MawbOBLNo
            End Get
            Set(ByVal value As String)
                _MawbOBLNo = value
            End Set
        End Property

        Property OriginCode() As String
            Get
                Return _OriginCode
            End Get
            Set(ByVal value As String)
                _OriginCode = value
            End Set
        End Property

        Property DestCode() As String
            Get
                Return _DestCode
            End Get
            Set(ByVal value As String)
                _DestCode = value
            End Set
        End Property

        Property Pcs() As Decimal
            Get
                Return _Pcs
            End Get
            Set(ByVal value As Decimal)
                _Pcs = value
            End Set
        End Property

        Property GrossWeight() As Decimal
            Get
                Return _GrossWeight
            End Get
            Set(ByVal value As Decimal)
                _GrossWeight = value
            End Set
        End Property

        Property Volume() As Decimal
            Get
                Return _Volume
            End Get
            Set(ByVal value As Decimal)
                _Volume = value
            End Set
        End Property

        Property Commodity() As String
            Get
                Return _Commodity
            End Get
            Set(ByVal value As String)
                _Commodity = value
            End Set
        End Property

        Property FirstToDestCode() As String
            Get
                Return _FirstToDestCode
            End Get
            Set(ByVal value As String)
                _FirstToDestCode = value
            End Set
        End Property

        Property FirstByAirlineID() As String
            Get
                Return _FirstByAirlineID
            End Get
            Set(ByVal value As String)
                _FirstByAirlineID = value
            End Set
        End Property

        Property FirstFlightNo() As String
            Get
                Return _FirstFlightNo
            End Get
            Set(ByVal value As String)
                _FirstFlightNo = value
            End Set
        End Property

        Property FirstFlightDate() As DateTime
            Get
                Return _FirstFlightDate
            End Get
            Set(ByVal value As DateTime)
                _FirstFlightDate = value
            End Set
        End Property

        Property SecondToDestCode() As String
            Get
                Return _SecondToDestCode
            End Get
            Set(ByVal value As String)
                _SecondToDestCode = value
            End Set
        End Property

        Property SecondByAirlineID() As String
            Get
                Return _SecondByAirlineID
            End Get
            Set(ByVal value As String)
                _SecondByAirlineID = value
            End Set
        End Property

        Property SecondFlightNo() As String
            Get
                Return _SecondFlightNo
            End Get
            Set(ByVal value As String)
                _SecondFlightNo = value
            End Set
        End Property

        Property SecondFlightDate() As DateTime
            Get
                Return _SecondFlightDate
            End Get
            Set(ByVal value As DateTime)
                _SecondFlightDate = value
            End Set
        End Property

        Property ThirdToDestCode() As String
            Get
                Return _ThirdToDestCode
            End Get
            Set(ByVal value As String)
                _ThirdToDestCode = value
            End Set
        End Property

        Property ThirdByAirlineID() As String
            Get
                Return _ThirdByAirlineID
            End Get
            Set(ByVal value As String)
                _ThirdByAirlineID = value
            End Set
        End Property

        Property ThirdFlightNo() As String
            Get
                Return _ThirdFlightNo
            End Get
            Set(ByVal value As String)
                _ThirdFlightNo = value
            End Set
        End Property

        Property ThirdFlightDate() As DateTime
            Get
                Return _ThirdFlightDate
            End Get
            Set(ByVal value As DateTime)
                _ThirdFlightDate = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _JobNo = ""
            _ReferenceNo = ""
            _AWBBlNo = ""
            _MawbOBLNo = ""
            _OriginCode = ""
            _DestCode = ""
            _Pcs = 0
            _GrossWeight = 0
            _Volume = 0
            _Commodity = ""
            'From Aiaw1 Table
            _FirstToDestCode = ""
            _FirstByAirlineID = ""
            _FirstFlightNo = ""
            _FirstFlightDate = ConDateTime.MinDate
            _SecondToDestCode = ""
            _SecondByAirlineID = ""
            _SecondFlightNo = ""
            _SecondFlightDate = ConDateTime.MinDate
            _ThirdToDestCode = ""
            _ThirdByAirlineID = ""
            _ThirdFlightNo = ""
            _ThirdFlightDate = ConDateTime.MinDate
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Air Freight "

    <Serializable()> _
    Public Class colAirFreight
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropAirFreight(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of AirFreight Server "

    <Serializable()> _
    Public Class clsAirFreight
        Inherits clsBaseSrv
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colAirFreight()
            Title = "Air Freight"
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
            colProp = New colAirFreight()
            Title = "Air Freight"
        End Sub

        Private Function InsertAirFreight(ByVal propAirFreight As clsPropAirFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function UpdateAirFreight(ByVal propAirFreight As clsPropAirFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function DeleteAirFreight(ByVal propAirFreight As clsPropAirFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Return True
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal strKey As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim strValue As String() = GeneralFun.GetCol(strKey)

                Dim param(2) As SqlParameter
                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = strValue(0)

                param(1) = New SqlParameter("@ModuleCode", SqlDbType.NVarChar, 10)
                param(1).Value = strValue(1)

                param(2) = New SqlParameter("@strDB", SqlDbType.NVarChar, 100)
                param(2).Value = strValue(2)

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Return True
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropAirFreight = CType(CurrentProp, clsPropAirFreight)
            blnReturn = InsertAirFreight(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropAirFreight = CType(CurrentProp, clsPropAirFreight)
            blnReturn = UpdateAirFreight(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropAirFreight = CType(CurrentProp, clsPropAirFreight)
            blnReturn = DeleteAirFreight(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropAirFreight = CType(CurrentProp, clsPropAirFreight)
            blnReturn = DeleteAirFreight(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
        'bylzw081224创建链接
        Public Shared Function GetReferenceFile(ByVal strPrefix As String, ByVal strFileName As String, ByVal strReference As String) As String
            Return strPrefix + "<A href=""" + strFileName + """ target=""_blank"">" + strReference + "</A>"
        End Function
        'bylzw081224创建链接
        Public Overloads Sub GetListInfo(ByVal strPath As String, ByVal strDownloadPath As String)
            Dim files As FileInfo() = clsDownloadFileDirectory.GetAllFiles(strPath)
            Dim i As Integer
            Dim tmpProp As clsPropDownload
            Dim strFileName As String
            ArrProp.Clear()
            If Not files Is Nothing Then
                For i = 0 To files.Length - 1
                    tmpProp = New clsPropDownload(i)
                    strFileName = (files(i).FullName).Replace(strPath, "")
                    tmpProp.OriginFile = files(i).FullName
                    tmpProp.FileName = HttpContext.Current.Server.HtmlEncode(strFileName)
                    If files(i).Length < 1024 Then
                        tmpProp.FileSize = Decimal.Round(files(i).Length / 1024 + 0.5)
                    Else
                        tmpProp.FileSize = files(i).Length / 1024
                    End If
                    tmpProp.FileDate = files(i).LastWriteTime
                    Dim strExtension As String = files(i).Extension()
                    If (strFileName.IndexOf(" ") < 0) AndAlso (clsDownloadFileDirectory.JudgeDirectShowFile(strExtension)) Then
                        tmpProp.ReferenceFileName = GetReferenceFile("", strDownloadPath + HttpContext.Current.Server.UrlEncode(strFileName), strFileName)
                    Else
                        tmpProp.ReferenceFileName = GetReferenceFile("", strDownloadPath + tmpProp.FileName, strFileName)
                    End If
                    tmpProp.FileId = i + 1
                    tmpProp.No = i + 1
                    ArrProp.Add(tmpProp)
                Next
            End If
            tmpProp = New clsPropDownload(ConClass.NewIdValue)
            tmpProp.No = ArrProp.Count + 1
            ArrProp.Add(tmpProp)
            files = Nothing
            tmpProp = Nothing
        End Sub
    End Class

#End Region

#Region " Class of Property Sea Freight "

    <Serializable()> _
    Public Class clsPropSeaFreight
        Inherits clsProp
        'From Jmjm1
        Private _JobNo As String
        Private _ReferenceNo As String
        Private _AWBBlNo As String
        Private _MawbOBLNo As String
        Private _OriginCode As String
        Private _DestCode As String
        Private _Pcs As Decimal
        Private _GrossWeight As Decimal
        Private _Volume As Decimal
        Private _Commodity As String
        Private _ETD As Date
        Private _ETA As Date
        Private _PortofLoadingName As String
        Private _PortofDischargeName As String
        Private _Noof20FtContainer As Integer
        Private _Noof40FtContainer As Integer
        Private _Noof45FtContainer As Integer
        Private _ContainerNo As String
        'From Siaw1 Table
        Private _VesselName As String
        Private _VoyageNo As String
        Private _FeederVesselName As String
        Private _FeederVoyage As String
        Private _ConnectingVesselName As String
        Private _ConnectingETD As Date
        Private _ConnectingETA As Date
        Private _TelexReleaseFlag As String

        Property JobNo() As String
            Get
                Return _JobNo
            End Get
            Set(ByVal value As String)
                _JobNo = value
            End Set
        End Property

        Property ReferenceNo() As String
            Get
                Return _ReferenceNo
            End Get
            Set(ByVal value As String)
                _ReferenceNo = value
            End Set
        End Property

        Property AWBBlNo() As String
            Get
                Return _AWBBlNo
            End Get
            Set(ByVal value As String)
                _AWBBlNo = value
            End Set
        End Property

        Property MawbOBLNo() As String
            Get
                Return _MawbOBLNo
            End Get
            Set(ByVal value As String)
                _MawbOBLNo = value
            End Set
        End Property

        Property OriginCode() As String
            Get
                Return _OriginCode
            End Get
            Set(ByVal value As String)
                _OriginCode = value
            End Set
        End Property

        Property DestCode() As String
            Get
                Return _DestCode
            End Get
            Set(ByVal value As String)
                _DestCode = value
            End Set
        End Property

        Property Pcs() As Decimal
            Get
                Return _Pcs
            End Get
            Set(ByVal value As Decimal)
                _Pcs = value
            End Set
        End Property

        Property GrossWeight() As Decimal
            Get
                Return _GrossWeight
            End Get
            Set(ByVal value As Decimal)
                _GrossWeight = value
            End Set
        End Property

        Property Volume() As Decimal
            Get
                Return _Volume
            End Get
            Set(ByVal value As Decimal)
                _Volume = value
            End Set
        End Property

        Property Commodity() As String
            Get
                Return _Commodity
            End Get
            Set(ByVal value As String)
                _Commodity = value
            End Set
        End Property

        Property ETD() As Date
            Get
                Return _ETD
            End Get
            Set(ByVal value As Date)
                _ETD = value
            End Set
        End Property

        Property ETA() As Date
            Get
                Return _ETA
            End Get
            Set(ByVal value As Date)
                _ETA = value
            End Set
        End Property

        Property PortofLoadingName() As String
            Get
                Return _PortofLoadingName
            End Get
            Set(ByVal value As String)
                _PortofLoadingName = value
            End Set
        End Property

        Property PortofDischargeName() As String
            Get
                Return _PortofDischargeName
            End Get
            Set(ByVal value As String)
                _PortofDischargeName = value
            End Set
        End Property

        Property Noof20FtContainer() As Integer
            Get
                Return _Noof20FtContainer
            End Get
            Set(ByVal value As Integer)
                _Noof20FtContainer = value
            End Set
        End Property

        Property Noof40FtContainer() As Integer
            Get
                Return _Noof40FtContainer
            End Get
            Set(ByVal value As Integer)
                _Noof40FtContainer = value
            End Set
        End Property

        Property Noof45FtContainer() As Integer
            Get
                Return _Noof45FtContainer
            End Get
            Set(ByVal value As Integer)
                _Noof45FtContainer = value
            End Set
        End Property

        Property ContainerNo() As String
            Get
                Return _ContainerNo
            End Get
            Set(ByVal value As String)
                _ContainerNo = value
            End Set
        End Property

        Property VesselName() As String
            Get
                Return _VesselName
            End Get
            Set(ByVal value As String)
                _VesselName = value
            End Set
        End Property

        Property VoyageNo() As String
            Get
                Return _VoyageNo
            End Get
            Set(ByVal value As String)
                _VoyageNo = value
            End Set
        End Property

        Property FeederVesselName() As String
            Get
                Return _FeederVesselName
            End Get
            Set(ByVal value As String)
                _FeederVesselName = value
            End Set
        End Property

        Property FeederVoyage() As String
            Get
                Return _FeederVoyage
            End Get
            Set(ByVal value As String)
                _FeederVoyage = value
            End Set
        End Property

        Property ConnectingVesselName() As String
            Get
                Return _ConnectingVesselName
            End Get
            Set(ByVal value As String)
                _ConnectingVesselName = value
            End Set
        End Property

        Property ConnectingETD() As Date
            Get
                Return _ConnectingETD
            End Get
            Set(ByVal value As Date)
                _ConnectingETD = value
            End Set
        End Property

        Property ConnectingETA() As Date
            Get
                Return _ConnectingETA
            End Get
            Set(ByVal value As Date)
                _ConnectingETA = value
            End Set
        End Property

        Property TelexReleaseFlag() As String
            Get
                Return _TelexReleaseFlag
            End Get
            Set(ByVal value As String)
                _TelexReleaseFlag = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _JobNo = ""
            _ReferenceNo = ""
            _AWBBlNo = ""
            _MawbOBLNo = ""
            _OriginCode = ""
            _DestCode = ""
            _Pcs = 0
            _GrossWeight = 0
            _Volume = 0
            _Commodity = ""
            _ETD = ConDateTime.MinDate
            _ETA = ConDateTime.MinDate
            _PortofLoadingName = ""
            _PortofDischargeName = ""
            _Noof20FtContainer = 0
            _Noof40FtContainer = 0
            _Noof45FtContainer = 0
            _ContainerNo = ""
            'From Aiaw1 Table
            _VesselName = ""
            _VoyageNo = ""
            _FeederVesselName = ""
            _FeederVoyage = ""
            _ConnectingETD = ConDateTime.MinDate
            _ConnectingETA = ConDateTime.MinDate
            _ConnectingVesselName = ""
            _TelexReleaseFlag = ""
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Sea Freight "

    <Serializable()> _
    Public Class colSeaFreight
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropSeaFreight(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of SeaFreight Server "

    <Serializable()> _
    Public Class clsSeaFreight
        Inherits clsBaseSrv

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colSeaFreight()
            Title = "Sea Freight"
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
            colProp = New colSeaFreight()
            Title = "Sea Freight"
        End Sub

        Private Function InsertSeaFreight(ByVal propSeaFreight As clsPropSeaFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function UpdateSeaFreight(ByVal propSeaFreight As clsPropSeaFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function DeleteSeaFreight(ByVal propSeaFreight As clsPropSeaFreight, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Return True
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal strKey As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim strValue As String() = GeneralFun.GetCol(strKey)

                Dim param(2) As SqlParameter
                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = strValue(0)

                param(1) = New SqlParameter("@ModuleCode", SqlDbType.NVarChar, 10)
                param(1).Value = strValue(1)

                param(2) = New SqlParameter("@strDB", SqlDbType.NVarChar, 100)
                param(2).Value = strValue(2)

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Return True
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropSeaFreight = CType(CurrentProp, clsPropSeaFreight)
            blnReturn = InsertSeaFreight(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropSeaFreight = CType(CurrentProp, clsPropSeaFreight)
            blnReturn = UpdateSeaFreight(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropSeaFreight = CType(CurrentProp, clsPropSeaFreight)
            blnReturn = DeleteSeaFreight(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropSeaFreight = CType(CurrentProp, clsPropSeaFreight)
            blnReturn = DeleteSeaFreight(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
        'bylzw081224创建链接
        Public Shared Function GetReferenceFile(ByVal strPrefix As String, ByVal strFileName As String, ByVal strReference As String) As String
            Return strPrefix + "<A href=""" + strFileName + """ target=""_blank"">" + strReference + "</A>"
        End Function
        Public Overloads Sub GetListInfo(ByVal strPath As String, ByVal strDownloadPath As String)
            Dim files As FileInfo() = clsDownloadFileDirectory.GetAllFiles(strPath)
            Dim i As Integer
            Dim tmpProp As clsPropDownload
            Dim strFileName As String
            ArrProp.Clear()
            If Not files Is Nothing Then
                For i = 0 To files.Length - 1
                    tmpProp = New clsPropDownload(i)
                    strFileName = (files(i).FullName).Replace(strPath, "")
                    tmpProp.OriginFile = files(i).FullName
                    tmpProp.FileName = HttpContext.Current.Server.HtmlEncode(strFileName)
                    If files(i).Length < 1024 Then
                        tmpProp.FileSize = Decimal.Round(files(i).Length / 1024 + 0.5)
                    Else
                        tmpProp.FileSize = files(i).Length / 1024
                    End If
                    tmpProp.FileDate = files(i).LastWriteTime
                    Dim strExtension As String = files(i).Extension()
                    If (strFileName.IndexOf(" ") < 0) AndAlso (clsDownloadFileDirectory.JudgeDirectShowFile(strExtension)) Then
                        tmpProp.ReferenceFileName = GetReferenceFile("", strDownloadPath + HttpContext.Current.Server.UrlEncode(strFileName), strFileName)
                    Else
                        tmpProp.ReferenceFileName = GetReferenceFile("", strDownloadPath + tmpProp.FileName, strFileName)
                    End If
                    tmpProp.FileId = i + 1
                    tmpProp.No = i + 1
                    ArrProp.Add(tmpProp)
                Next
            End If
            tmpProp = New clsPropDownload(ConClass.NewIdValue)
            tmpProp.No = ArrProp.Count + 1
            ArrProp.Add(tmpProp)
            files = Nothing
            tmpProp = Nothing
        End Sub
    End Class

#End Region

    'bylzw081224
#Region " Class of Download Attach File & Directory Operation "

    Public Class clsDownloadFileDirectory

        Private Shared _DirectShowExtension As String

        Public Shared Sub CreateDirectory(ByVal strDirectory As String)
            Try
                If Not Directory.Exists(strDirectory) Then
                    Directory.CreateDirectory(strDirectory)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Shared Sub RenameDirectory(ByVal strOldDirectory As String, ByVal strNewDirectory As String)
            Try
                If Directory.Exists(strOldDirectory) Then
                    Directory.Move(strOldDirectory, strNewDirectory)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Shared Function DeleteFile(ByVal strFullFileName As String) As Boolean
            Try
                If File.Exists(strFullFileName) Then
                    File.Delete(strFullFileName)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function IsExistsFiles(ByVal strDirectory As String) As Boolean
            Try
                Dim dirInfo As New DirectoryInfo(strDirectory)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                Return files.Length > 0
            Catch ex As Exception
                Return False
            End Try
        End Function
        'bylzw0812248
        Public Shared Function GetAllFiles(ByVal strDirectory As String) As FileInfo()
            'CreateDirectory(strDirectory)
            Try
                If Directory.Exists(strDirectory) Then
                    Dim dirInfo As New DirectoryInfo(strDirectory)
                    Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                    Return files
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetAllFileName(ByVal strDirectory As String) As String()
            CreateDirectory(strDirectory)
            Try
                Dim dirInfo As New DirectoryInfo(strDirectory)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                If files.Length = 0 Then
                    Return Nothing
                End If
                Dim i As Integer
                Dim fileNames(files.Length - 1) As String
                For i = 0 To files.Length - 1
                    fileNames(i) = files(i).FullName
                Next
                Return fileNames
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function ClearTempDirectoryLogout() As Boolean
            Try
                If Not HttpContext.Current.Session("AllRequestId") Is Nothing Then
                    Dim AllRequestId As ArrayList = CType(HttpContext.Current.Session("AllRequestId"), ArrayList)
                    Dim i As Integer
                    Dim intId As Int64
                    Dim strPath As String
                    Dim dirInfo As DirectoryInfo
                    For i = 0 To AllRequestId.Count - 1
                        intId = AllRequestId(i)
                        strPath = HttpContext.Current.Server.MapPath("Download/" + intId.ToString() + "/")
                        dirInfo = New DirectoryInfo(strPath)
                        If dirInfo.Exists() Then
                            dirInfo.Delete(True)
                        End If
                    Next
                End If
                HttpContext.Current.Session.Remove("AllRequestId")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function ClearTempDirectoryLogin() As Boolean
            Try
                Dim strPath As String = HttpContext.Current.Server.MapPath("Download/")
                Dim dirInfo As DirectoryInfo = New DirectoryInfo(strPath)
                Dim subdir As DirectoryInfo
                Dim strFileCreateTime As String
                Dim dtmTime As DateTime
                Dim cnCultureInfo = New CultureInfo("zh-cn")
                If dirInfo.Exists() Then
                    Dim directorys As DirectoryInfo() = dirInfo.GetDirectories("-*")
                    For Each subdir In directorys
                        strFileCreateTime = subdir.Name.Substring(1, 14)
                        If (strFileCreateTime.Length = 14) Then
                            strFileCreateTime = strFileCreateTime.Substring(0, 4) + "-" _
                                               + strFileCreateTime.Substring(4, 2) + "-" _
                                               + strFileCreateTime.Substring(6, 2) + " " _
                                               + strFileCreateTime.Substring(8, 2) + ":" _
                                               + strFileCreateTime.Substring(10, 2) + ":" _
                                               + strFileCreateTime.Substring(12, 2)
                            If DateTime.TryParse(strFileCreateTime, cnCultureInfo, DateTimeStyles.None, dtmTime) Then
                                If dtmTime.AddHours(1) < DateTime.Now Then
                                    If subdir.Exists() Then
                                        subdir.Delete(True)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function AddTempDirectoryToSession(ByVal intId As Int64) As Boolean
            Dim AllRequestId As ArrayList
            If HttpContext.Current.Session("AllRequestId") Is Nothing Then
                AllRequestId = New ArrayList()
            Else
                AllRequestId = CType(HttpContext.Current.Session("AllRequestId"), ArrayList)
            End If
            AllRequestId.Add(intId)
            HttpContext.Current.Session("AllRequestId") = AllRequestId
        End Function

        Public Shared Function JudgeDirectShowFile(ByVal strExtension As String) As Boolean
            If _DirectShowExtension Is Nothing OrElse _DirectShowExtension = String.Empty Then
                _DirectShowExtension = ConfigurationManager.AppSettings("DirectShowExtension").ToString().Trim()
            End If
            If _DirectShowExtension.IndexOf(strExtension, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class
#End Region
    'bylzw081224
#Region " Class of Property of Download Attach"

    <Serializable()> _
    Public Class clsPropDownload
        Inherits clsProp
        Private _FileId As Integer
        Private _OriginFile As String
        Private _FileName As String
        Private _FileType As String
        Private _FileSize As Int64
        Private _FileDate As DateTime
        Private _ReferenceFileName As String
        Private _Title As String
        Private _Author As String
        Private _llinTitle As String
        Private _Comments As String
        Public Property FileId() As Integer
            Get
                Return _FileId
            End Get
            Set(ByVal value As Integer)
                _FileId = value
            End Set
        End Property

        Public Property OriginFile() As String
            Get
                Return _OriginFile
            End Get
            Set(ByVal value As String)
                _OriginFile = value
            End Set
        End Property

        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

        Public Property FileType() As String
            Get
                Return _FileType
            End Get
            Set(ByVal value As String)
                _FileType = value
            End Set
        End Property

        Public Property FileSize() As Int64
            Get
                Return _FileSize
            End Get
            Set(ByVal value As Int64)
                _FileSize = value
            End Set
        End Property

        Public Property FileDate() As DateTime
            Get
                Return _FileDate
            End Get
            Set(ByVal value As DateTime)
                _FileDate = value
            End Set
        End Property

        Public Property ReferenceFileName() As String
            Get
                Return _ReferenceFileName
            End Get
            Set(ByVal value As String)
                _ReferenceFileName = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public Property Author() As String
            Get
                Return _Author
            End Get
            Set(ByVal value As String)
                _Author = value
            End Set
        End Property
        Public Property llinTitle() As String
            Get
                Return _llinTitle
            End Get
            Set(ByVal value As String)
                _llinTitle = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _FileId = 0
            _FileName = ""
        End Sub

    End Class

#End Region

End Namespace