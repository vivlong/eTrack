Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.Security
Imports System.Text

Namespace SystemClass

#Region " Class of Page Param "

    <Serializable()> _
    Public Class clsPagePara
        Private _SearchSize As Integer
        Private _OpenSize As Integer
        Private _DetailSize As Integer
        Private _InfoSize As Integer
        Private _QuerySize As Integer

        Public Property SearchSize() As Integer
            Get
                Return _SearchSize
            End Get
            Set(ByVal value As Integer)
                _SearchSize = value
            End Set
        End Property

        Public Property DetailSize() As Integer
            Get
                Return _DetailSize
            End Get
            Set(ByVal value As Integer)
                _DetailSize = value
            End Set
        End Property

        Public Property OpenSize() As Integer
            Get
                Return _OpenSize
            End Get
            Set(ByVal value As Integer)
                _OpenSize = value
            End Set
        End Property

        Public Property InfoSize() As Integer
            Get
                Return _InfoSize
            End Get
            Set(ByVal value As Integer)
                _InfoSize = value
            End Set
        End Property

        Public Property QuerySize() As Integer
            Get
                Return _QuerySize
            End Get
            Set(ByVal value As Integer)
                _QuerySize = value
            End Set
        End Property

    End Class

#End Region

#Region " Class of Person Station "

    <Serializable()> _
    Public Class clsPersonStation
        Private _IsProgrammer As Boolean
        Private _IsTester As Boolean
        Private _IsCompanyManager As Boolean
        Private _IsOtherman As Boolean

        Public Property IsProgrammer() As Boolean
            Get
                Return _IsProgrammer
            End Get
            Set(ByVal value As Boolean)
                _IsProgrammer = value
            End Set
        End Property

        Public Property IsTester() As Boolean
            Get
                Return _IsTester
            End Get
            Set(ByVal value As Boolean)
                _IsTester = value
            End Set
        End Property

        Public Property IsCompanyManager() As Boolean
            Get
                Return _IsCompanyManager
            End Get
            Set(ByVal value As Boolean)
                _IsCompanyManager = value
            End Set
        End Property

        Public Property IsOtherman() As Boolean
            Get
                Return _IsOtherman
            End Get
            Set(ByVal value As Boolean)
                _IsOtherman = value
            End Set
        End Property
    End Class

#End Region

#Region " Class of User "

    <Serializable()> _
    Public Class clsUser
        Private _UserId As String
        Private _Password As String = ""
        Private _UserName As String = ""
        Private _DepartNo As String = ""
        Private _DepartName As String = ""
        Private _CompanyName As String = ""
        Private _PartCompanyName As String = ""
        Private _IpAddress As String
        Private _RoleName As String = ""
        Private _SiteCode As String = ""
        Private _ExportConfig As String = ""
        Private _ImportConfig As String = ""
        Private _UpperCase As String = ""
        Private _CompNo As String
        'First Page 
        Private _NavigatePage As String
        Private _DisplaySmsHint As Boolean = True
        Private _PagePara As clsPagePara
        Private _PersonStation As clsPersonStation
        'database by lzw 090609
        Private _DataBase As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _LoginType As String
        Public ReadOnly Property UserId() As String
            Get
                Return _UserId
            End Get
        End Property

        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                If _Password <> value Then
                    _Password = value
                End If
            End Set
        End Property

        Public Property PortOfDischargeCode() As String
            Get
                Return _PortOfDischargeCode
            End Get
            Set(ByVal value As String)
                If _PortOfDischargeCode <> value Then
                    _PortOfDischargeCode = value
                End If
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                If _UserName <> value Then
                    _UserName = value
                End If
            End Set
        End Property

        Public Property DepartNo() As String
            Get
                Return _DepartNo
            End Get
            Set(ByVal value As String)
                If _DepartNo <> value Then
                    _DepartNo = value
                End If
            End Set
        End Property

        Public Property DepartName() As String
            Get
                Return _DepartName
            End Get
            Set(ByVal value As String)
                If _DepartName <> value Then
                    _DepartName = value
                End If
            End Set
        End Property

        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                If _CompanyName <> value Then
                    _CompanyName = value
                End If
            End Set
        End Property

        Public Property PartCompanyName() As String
            Get
                Return _PartCompanyName
            End Get
            Set(ByVal value As String)
                If _PartCompanyName <> value Then
                    _PartCompanyName = value
                End If
            End Set
        End Property

        Public Property IpAddress() As String
            Get
                Return _IpAddress
            End Get
            Set(ByVal value As String)
                _IpAddress = value
            End Set
        End Property

        Public Property SiteCode() As String
            Get
                Return _SiteCode
            End Get
            Set(ByVal value As String)
                _SiteCode = value
            End Set
        End Property

        Public Property UpperCase() As String
            Get
                Return _UpperCase
            End Get
            Set(ByVal value As String)
                _UpperCase = value
            End Set
        End Property

        Public Property CompNo() As String
            Get
                Return _CompNo
            End Get
            Set(ByVal value As String)
                _CompNo = value
            End Set
        End Property

        Public Property ExportConfig() As String
            Get
                Return _ExportConfig
            End Get
            Set(ByVal value As String)
                _ExportConfig = value
            End Set
        End Property

        Public Property ImportConfig() As String
            Get
                Return _ImportConfig
            End Get
            Set(ByVal value As String)
                _ImportConfig = value
            End Set
        End Property

        Public Property RoleName() As String
            Get
                Return _RoleName
            End Get
            Set(ByVal value As String)
                _RoleName = value
            End Set
        End Property

        Public Property NavigatePage() As String
            Get
                Return _NavigatePage
            End Get
            Set(ByVal value As String)
                If _NavigatePage <> value Then
                    _NavigatePage = value
                End If
            End Set
        End Property

        Public Property DisplaySmsHint() As Boolean
            Get
                Return _DisplaySmsHint
            End Get
            Set(ByVal value As Boolean)
                _DisplaySmsHint = value
            End Set
        End Property

        Public Property DataBase() As String
            Get
                Return _DataBase
            End Get
            Set(ByVal value As String)
                If _DataBase <> value Then
                    _DataBase = value
                End If
            End Set
        End Property
        Public Property LoginType() As String
            Get
                Return _LoginType
            End Get
            Set(ByVal value As String)
                If _LoginType <> value Then
                    _LoginType = value
                End If
            End Set
        End Property
        Public Sub New()
            _UserId = ""
            'Page Para
            _PagePara = New clsPagePara()
            _PagePara.SearchSize = 10
            _PagePara.DetailSize = 16
            _PagePara.OpenSize = 10
            _PagePara.QuerySize = 17
            _PagePara.InfoSize = 10
            'Person Station
            _PersonStation = New clsPersonStation()
            _PersonStation.IsProgrammer = False
            _PersonStation.IsTester = False
            _PersonStation.IsCompanyManager = False
            _PersonStation.IsOtherman = False
            'Show Sms
            _DisplaySmsHint = True
            'NavigatePage
            _NavigatePage = ""
        End Sub

        Public Property PagePara() As clsPagePara
            Get
                Return _PagePara
            End Get
            Set(ByVal value As clsPagePara)
                _PagePara = value
            End Set
        End Property

        Public Property PersonStation() As clsPersonStation
            Get
                Return _PersonStation
            End Get
            Set(ByVal value As clsPersonStation)
                _PersonStation = value
            End Set
        End Property
        ''' <summary>
        ''' JudgePassword --- by lzw 090609
        ''' when customer login then judge by 
        ''' 
        ''' 
        ''' </summary>
        ''' <param name="strPassword"></param>
        ''' <param name="intCompanyId"></param>
        ''' <param name="strMsg"></param>
        ''' <param name="intType">intType=0 means use Customer to login, intType=1 use Internal user to login</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function JudgePassword(ByVal strUserID As String, ByVal strPassword As String, ByVal intCompanyId As Integer, ByRef strMsg As String, ByRef strDatabase As String, Optional ByRef intType As Integer = 0) As Boolean
            Dim ds As DataSet
            Dim strValue As String
            Dim strLogin3(1) As String
            Dim strLoginChk As String
            Dim blnLoginChk As Boolean
            Dim n As Integer
            'added to check the login type for customer / agent
            strLoginChk = ""
            strLogin3(0) = "OA" 'Overseas agent
            strLogin3(1) = "WH" 'Warehouse user
            Try
                If intType = 0 Or intType = 3 Then '20151111
                    'Define Param and Set Param  Rcbp1
                    Dim param(0) As SqlParameter
                    param(0) = New SqlParameter("@strUserNo", SqlDbType.NVarChar, 10)
                    param(0).Value = strUserID
                    ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_LoginParam", param)
                    strValue = "BusinessPartyCode"
                    _LoginType = "cu"
                    If ds.Tables(0).Rows.Count > 0 Then
                        strLoginChk = ds.Tables(0).Rows(0)("PartyType").ToString.Trim
                        For n = 0 To strLogin3.Length - 1
                            If strLoginChk = strLogin3(n) Then
                                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.UserNotExists, strUserID)
                                Return False
                            End If
                        Next
                    End If
                ElseIf intType = 2 Then 'sclee 20140624 - added login type = fixed
                    'Define Param and Set Param  Rcbp1
                    Dim param(0) As SqlParameter
                    param(0) = New SqlParameter("@strUserNo", SqlDbType.NVarChar, 10)
                    param(0).Value = strUserID
                    ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_LoginParam", param)
                    strValue = "BusinessPartyCode"
                    _LoginType = "cu"
                    If ds.Tables(0).Rows.Count > 0 Then
                        _LoginType = ds.Tables(0).Rows(0)("PartyType").ToString.Trim
                    End If
                    strLoginChk = _LoginType.Trim.ToUpper
                    blnLoginChk = False
                    For n = 0 To strLogin3.Length - 1
                        If strLoginChk = strLogin3(n) Then
                            blnLoginChk = True
                        End If
                    Next
                    If blnLoginChk = False Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.UserNotExists, strUserID)
                        Return False
                    End If
                Else
                    'Define Param and Set Param Saus1
                    Dim param(1) As SqlParameter
                    param(0) = New SqlParameter("@strUserNo", SqlDbType.NVarChar, 20)
                    param(0).Value = strUserID
                    param(1) = New SqlParameter("@strDatabase", SqlDbType.NVarChar, 50)
                    param(1).Value = strDatabase
                    ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_InternalUser_LoginParam", param)
                    strValue = "UserID"
                    _LoginType = "in"
                End If
            Catch ex As Exception
                strMsg = "Connect to DataBase Faile." + vbNewLine + ex.Message
                ds = Nothing
                Return False
            End Try
            Dim dt As DataTable
            dt = ds.Tables(0)
            '>>>>>>>>>If accessRight =A then default RoleName "administrator">>>>>>>>>>>>
            Dim strAccessRight As String = ""
            If intType = 1 Then
                If dt IsNot Nothing Then
                    Try
                        strAccessRight = dt.Rows(0)("AccessRight").ToString.Trim
                        '_CompNo = dt.Rows(1)("BusinessPartyCode").ToString.Trim
                    Catch ex As Exception
                    End Try
                End If
            End If
            '>>>>>>>>>>>>>>>>>>>>>
            ' Judge Password and Set result value 
            If dt.Rows.Count <> 1 Then
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.UserNotExists, strUserID)
                Return False
            Else
                If dt.Rows(0)(strValue).ToString().Trim().ToUpper <> UCase(strUserID) Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.UserNotExists, strUserID)
                    Return False
                Else
                    If dt.Columns.IndexOf("Password") < 0 Then
                        'strMsg = ConMsgInfo.UnmatchedParam + " 'Password' not exits in Database."
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.UnmatchedParam, "'Password'")
                        Return False
                    Else
                        If dt.Columns.IndexOf("Password") >= 0 AndAlso (dt.Rows(0)("Password").ToString().ToLower.Trim() <> strPassword.ToLower And dt.Rows(0)("Password").ToString().ToLower.Trim() <> Me.Md5Crypt(strPassword).ToLower) Then
                            strMsg = ConMsgInfo.WrongPassword
                            Return False
                        Else
                            _Password = strPassword
                            If intType = 0 Or intType = 3 Then '20151111
                                _UserName = dt.Rows(0)("BusinessPartyName").ToString().Trim()
                            ElseIf intType = 2 Then
                                _UserName = dt.Rows(0)("BusinessPartyName").ToString().Trim()
                            Else
                                _UserName = dt.Rows(0)("UserName").ToString().Trim()
                                _SiteCode = dt.Rows(0)("SiteCode").ToString().Trim()
                                _ExportConfig = dt.Rows(0)("ExportConfig").ToString().Trim()
                                _ImportConfig = dt.Rows(0)("ImportConfig").ToString().Trim()
                            End If
                            _UserId = strUserID
                            _DataBase = strDatabase
                            '<<<100202 byzhiwei add User RoleName
                            If ds.Tables.Count > 1 Then
                                Try
                                    dt = ds.Tables(1)
                                    If dt IsNot Nothing Then
                                        For i As Integer = 0 To dt.Rows.Count - 1
                                            If dt.Rows(i)("sRoleName").ToString = "Customer" Then
                                                _RoleName = "Customer,"
                                            Else
                                                _RoleName += dt.Rows(i)("sRoleName").ToString + ","
                                            End If
                                        Next
                                        If strUserID.Trim = "sa" And intType = 1 Then
                                            _RoleName = "admin,"
                                        ElseIf _RoleName.Trim = "" And strAccessRight = "A" Then
                                            _RoleName = "administrator,"
                                        End If
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                            If RoleName.IndexOf("admin") > -1 And RoleName.IndexOf("administrator") = -1 Then
                                _RoleName = "admin,"
                            End If
                            '>>>
                            _DisplaySmsHint = False
                            'Page Para
                            If System.Configuration.ConfigurationManager.AppSettings("SearchSize") = "" Then
                                _PagePara.SearchSize = 20
                            Else
                                _PagePara.SearchSize = GeneralFun.StringToInt(System.Configuration.ConfigurationManager.AppSettings("SearchSize"))
                            End If

                            If System.Configuration.ConfigurationManager.AppSettings("OpenSize") = "" Then
                                _PagePara.OpenSize = 20
                            Else
                                _PagePara.OpenSize = GeneralFun.StringToInt(System.Configuration.ConfigurationManager.AppSettings("OpenSize"))
                            End If

                            If System.Configuration.ConfigurationManager.AppSettings("DetailSize") = "" Then
                                _PagePara.DetailSize = 20
                            Else
                                _PagePara.DetailSize = GeneralFun.StringToInt(System.Configuration.ConfigurationManager.AppSettings("DetailSize"))
                            End If

                            If System.Configuration.ConfigurationManager.AppSettings("InfoSize") = "" Then
                                _PagePara.InfoSize = 20
                            Else
                                _PagePara.InfoSize = GeneralFun.StringToInt(System.Configuration.ConfigurationManager.AppSettings("InfoSize"))
                            End If

                            If System.Configuration.ConfigurationManager.AppSettings("QuerySize") = "" Then
                                _PagePara.QuerySize = 20
                            Else
                                _PagePara.QuerySize = GeneralFun.StringToInt(System.Configuration.ConfigurationManager.AppSettings("QuerySize"))
                            End If
                            'Other Information
                            'First Page
                            Dim strFunNo As String = ""
                            Dim strFunUrl As String = ""
                            Return True
                        End If
                    End If
                End If
            End If
            ds = Nothing
            dt = Nothing
        End Function
        Public Function Md5Crypt(ByVal strValue As String) As String
            Dim md5provider As Cryptography.MD5 = New Cryptography.MD5CryptoServiceProvider()
            Dim data As Byte() = System.Text.Encoding.Default.GetBytes(strValue)
            Dim result As Byte() = md5provider.ComputeHash(data)
            Dim ret As StringBuilder = New StringBuilder()
            Dim intI As Integer
            For intI = 0 To result.Length - 1
                ret.AppendFormat("{0:X2}", result(intI))
            Next
            Return ret.ToString()
        End Function
        Public Shared Function ListSubWithOutRole(ByVal RoleName As String, ByVal sFunno As String) As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim strSql As String = ""
                strSql = "select lSubId  from PowerLevel where sFunno= '" + sFunno + "' and lRoleId in (select lId from RoleInfo where sRoleName in ('" + RoleName + "'))"
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSql)
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
        Public Shared Function ListSub(ByVal RoleName As String, ByVal sFunno As String) As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                If RoleName.IndexOf("'") < 0 Then
                    RoleName = "'" + RoleName
                    RoleName = RoleName.Replace(",", "','")
                    RoleName = RoleName.Substring(0, RoleName.Length - 2)
                End If
                Dim strSql As String = ""
                If RoleName.IndexOf("admin") > -1 Then
                    strSql = "select lSubId,''  from FunctionInfoSub where sFunno= '" + sFunno + "'"
                Else
                    strSql = "select lSubId,ViewCondition  from PowerLevel where sFunno= '" + sFunno + "' and lRoleId in (select lId from RoleInfo where sRoleName in (" + RoleName + "))"
                End If
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSql)
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

