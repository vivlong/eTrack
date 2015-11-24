Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Collections
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class of Property of Sub Role Function "

    <Serializable()> _
    Public Class clsPropSubFun
        Private _Code As String
        Private _Name As String
        Private _Flag As Boolean
        Private _RoleId As Integer
        Private _FunNo As String
        Private _SubId As Integer
        Private _UserFlag As String
        Private _SubType As String
        Private _ViewCondition As String

        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property Flag() As Boolean
            Get
                Return _Flag
            End Get
            Set(ByVal value As Boolean)
                _Flag = value
            End Set
        End Property

        Public Property RoleId() As Integer
            Get
                Return _RoleId
            End Get
            Set(ByVal value As Integer)
                _RoleId = value
            End Set
        End Property

        Public Property FunNo() As String
            Get
                Return _FunNo
            End Get
            Set(ByVal value As String)
                _FunNo = value
            End Set
        End Property

        Public Property SubId() As Integer
            Get
                Return _SubId
            End Get
            Set(ByVal value As Integer)
                _SubId = value
            End Set
        End Property

        Public Property UserFlag() As String
            Get
                Return _UserFlag
            End Get
            Set(ByVal value As String)
                _UserFlag = value
            End Set
        End Property

        Public Property SubType() As String
            Get
                Return _SubType
            End Get
            Set(ByVal value As String)
                _SubType = value
            End Set
        End Property

        Public Property ViewCondition() As String
            Get
                Return _ViewCondition
            End Get
            Set(ByVal value As String)
                _ViewCondition = value
            End Set
        End Property

    End Class

#End Region

#Region " Class of Property of Role Function "

    <Serializable()> _
    Public Class clsPropRoleFuntion
        Private _No As Integer
        Private _FunNo As String
        Private _FunName As String
        Private _UserFlag As String
        Private _SubFun As ArrayList
        Private _ViewCondition As String
        Private _SubType As String

        Public Property No() As Integer
            Get
                Return _No
            End Get
            Set(ByVal value As Integer)
                _No = value
            End Set
        End Property

        Public Property FunNo() As String
            Get
                Return _FunNo
            End Get
            Set(ByVal value As String)
                _FunNo = value
            End Set
        End Property

        Public Property FunName() As String
            Get
                Return _FunName
            End Get
            Set(ByVal value As String)
                _FunName = value
            End Set
        End Property

        Public Property UserFlag() As String
            Get
                Return _UserFlag
            End Get
            Set(ByVal value As String)
                _UserFlag = value
            End Set
        End Property

        Public Property SubFun() As ArrayList
            Get
                Return _SubFun
            End Get
            Set(ByVal value As ArrayList)
                _SubFun = value
            End Set
        End Property
        Public Property ViewCondition() As String
            Get
                Return _ViewCondition
            End Get
            Set(ByVal value As String)
                _ViewCondition = value
            End Set
        End Property
        Public Property SubType() As String
            Get
                Return _SubType
            End Get
            Set(ByVal value As String)
                _SubType = value
            End Set
        End Property
        Public Sub New(ByVal strFunNo As String)
            _FunNo = strFunNo
            _No = 0
            _SubFun = New ArrayList()
        End Sub
    End Class

#End Region

#Region " Class of Property of FunctionInfo UserFalg "

    <Serializable()> _
    Public Class clsPropUserFalg
        Private _No As Integer
        Private _FunNo As String
        Private _UserFlag As String

        Public Property No() As Integer
            Get
                Return _No
            End Get
            Set(ByVal value As Integer)
                _No = value
            End Set
        End Property

        Public Property FunNo() As String
            Get
                Return _FunNo
            End Get
            Set(ByVal value As String)
                _FunNo = value
            End Set
        End Property

        Public Property UserFlag() As String
            Get
                Return _UserFlag
            End Get
            Set(ByVal value As String)
                _UserFlag = value
            End Set
        End Property

        Public Sub New(ByVal strFunNo As String)
            _FunNo = strFunNo
            _No = 0
            _UserFlag = "N"
        End Sub
    End Class

#End Region
#Region " Class Collection of UserFlag "

    <Serializable()> _
    Public Class colUserFlag
        Private _ArrProp As ArrayList

        Public Sub New()
            _ArrProp = New ArrayList()
        End Sub

        Public ReadOnly Property ArrProp() As ArrayList
            Get
                Return _ArrProp
            End Get
        End Property

        Public Function AddTableToArray(ByVal dt As DataTable) As Boolean
            Dim strFunNo As String
            Dim tmpProp As clsPropUserFalg
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                'FunNo
                If dt.Rows(i)("sFunNo") Is System.DBNull.Value Then
                    strFunNo = ""
                Else
                    strFunNo = dt.Rows(i)("sFunNo").ToString()
                End If
                'New Prop Class
                tmpProp = New clsPropUserFalg(strFunNo)
                'UserFlag
                If dt.Rows(i)("UserFlag") Is System.DBNull.Value Then
                    tmpProp.UserFlag = "Y"
                Else
                    tmpProp.UserFlag = dt.Rows(i)("UserFlag").ToString().TrimEnd()
                End If
                'N0
                tmpProp.No = i
                'Add Object to Array
                _ArrProp.Add(tmpProp)
            Next i
            Return True
        End Function
        Private Function Convert(ByVal strFlag As String) As String
            Dim strUserFlag As String = ""
            If strFlag = "0" Then
                Return "N"
            ElseIf strFlag = "1" Then
                Return "Y"
            End If
            Return strUserFlag
        End Function
    End Class

#End Region
#Region " Class Collection of Role Function "

    <Serializable()> _
    Public Class colRoleFunction
        Private _ArrProp As ArrayList

        Public Sub New()
            _ArrProp = New ArrayList()
        End Sub

        Public ReadOnly Property ArrProp() As ArrayList
            Get
                Return _ArrProp
            End Get
        End Property

        Public Function AddTableToArray(ByVal dt As DataTable, ByVal dtSub As DataTable) As Boolean
            Dim strFunNo As String
            Dim tmpProp As clsPropRoleFuntion
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                'FunNo
                If dt.Rows(i)("sFunNo") Is System.DBNull.Value Then
                    strFunNo = ""
                Else
                    strFunNo = dt.Rows(i)("sFunNo").ToString()
                End If
                'New Prop Class
                tmpProp = New clsPropRoleFuntion(strFunNo)
                'FunName
                If dt.Rows(i)("sFunName") Is System.DBNull.Value Then
                    tmpProp.FunName = ""
                Else
                    tmpProp.FunName = dt.Rows(i)("sFunName").ToString().TrimEnd()
                End If
                'UserFlag
                If dt.Rows(i)("UserFlag") Is System.DBNull.Value Then
                    tmpProp.UserFlag = "Y"
                Else
                    tmpProp.UserFlag = dt.Rows(i)("UserFlag").ToString().TrimEnd()
                End If
                'N0
                tmpProp.No = i
                'SubProp
                Dim dtRow As DataRow() = dtSub.Select("sFunNo='" + strFunNo + "'")
                Dim _tmpSubProp As clsPropSubFun
                Dim j As Integer
                For j = 0 To dtRow.Length - 1
                    _tmpSubProp = New clsPropSubFun()
                    _tmpSubProp.Code = dtRow(j)("sCode").ToString().TrimEnd()
                    _tmpSubProp.Name = dtRow(j)("sName").ToString().TrimEnd()
                    _tmpSubProp.Flag = Boolean.Parse(dtRow(j)("bExistFun").ToString())
                    _tmpSubProp.SubId = Integer.Parse(dtRow(j)("lSubId").ToString())
                    _tmpSubProp.FunNo = dtRow(j)("sFunNo").ToString().TrimEnd()
                    _tmpSubProp.SubType = dtRow(j)("SubType").ToString().TrimEnd()
                    _tmpSubProp.ViewCondition = dtRow(j)("ViewCondition").ToString().TrimEnd()
                    tmpProp.SubFun.Add(_tmpSubProp)
                Next j
                'Add Object to Array
                _ArrProp.Add(tmpProp)
            Next i
            Return True
        End Function

    End Class

#End Region

#Region " Class of Role Function Server "

    <Serializable()> _
    Public Class clsRoleFunction
        Inherits BaseTranSrvr
        Private _intUserId As String
        Private _RoleId As Integer
        Private _RoleName As String
        Private _ArrRoleFunction As colRoleFunction
        Private _ArrUserFlag As colUserFlag
        Private _Title As String

        Public Sub New(ByVal intUserId As String, ByVal intRoleId As Integer, ByVal strRoleName As String) 'byzhiwei 090608
            _ArrRoleFunction = New colRoleFunction()
            _ArrUserFlag = New colUserFlag()
            _intUserId = intUserId
            _RoleId = intRoleId
            _RoleName = strRoleName
            _Title = "role access module"
        End Sub

        Public Property intUserId() As String
            Get
                Return _intUserId
            End Get
            Set(ByVal value As String)
                _intUserId = value
            End Set
        End Property

        Public Property RoleId() As Integer
            Get
                Return _RoleId
            End Get
            Set(ByVal value As Integer)
                _RoleId = value
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

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public ReadOnly Property ArrRoleFunction() As ArrayList
            Get
                Return _ArrRoleFunction.ArrProp
            End Get
        End Property

        Private Function GetAllFunction(ByVal RoleName As String) As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@RoleName", SqlDbType.NVarChar)
                param(0).Value = RoleName

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_FunctionInfo", param)
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Private Function GetSubFunction() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@strRoleId", SqlDbType.NVarChar)
                param(0).Value = RoleId

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleSubFunction", param)
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Private Function SaveSubFunction(ByVal propSubFun As clsPropSubFun, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(3) As SqlParameter

                param(0) = New SqlParameter("@intRoleId", SqlDbType.Int)
                param(0).Value = RoleId

                param(1) = New SqlParameter("@strFunNo", SqlDbType.NVarChar, 20)
                param(1).Value = propSubFun.FunNo

                param(2) = New SqlParameter("@intSubId", SqlDbType.Int)
                param(2).Value = propSubFun.SubId

                param(3) = New SqlParameter("@ViewCondition", SqlDbType.NVarChar, 255)
                param(3).Value = propSubFun.ViewCondition

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_PowerLevel", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function DeleteAllSubFunction(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@intRoleId", SqlDbType.BigInt)
                param(0).Value = RoleId

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_PowerLevel", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Public Function ModifyCurrent(ByVal strValue As String) As Boolean
            Try
                Dim strRow As String() = GeneralFun.GetRow(strValue)
                Dim i As Integer
                Dim j As Integer
                Dim k As Integer
                For i = 0 To _ArrRoleFunction.ArrProp.Count - 1
                    Dim tmpSubFun As ArrayList = CType(_ArrRoleFunction.ArrProp(i), clsPropRoleFuntion).SubFun
                    Dim tmpsFunNo As String = CType(_ArrRoleFunction.ArrProp(i), clsPropRoleFuntion).FunNo
                    If tmpSubFun.Count > 0 Then
                        For k = 0 To strRow.Length - 1
                            Dim strCol As String() = GeneralFun.GetCol(strRow(k))
                            If strCol(0).Length > 3 Then
                                For j = 1 To strCol.Length - 1
                                    If tmpsFunNo = strCol(0) Then
                                        Dim arrSub() As String = strCol(j).Split("|")
                                        CType(tmpSubFun(j - 1), clsPropSubFun).Flag = GeneralFun.IntStringAsBool(arrSub(0))
                                        If arrSub.Length > 1 Then
                                            arrSub(1) = Uri.UnescapeDataString(arrSub(1))
                                            CType(tmpSubFun(j - 1), clsPropSubFun).ViewCondition = arrSub(1)
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
                Return True
            Catch
                Return False
            End Try
        End Function

        Protected Overrides Function SaveData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnResult As Boolean = DeleteAllSubFunction(conn, trans, strMsg)
            If blnResult Then
                Dim i As Integer
                Dim j As Integer
                For i = 0 To _ArrRoleFunction.ArrProp.Count - 1
                    Dim tmpSubFun As ArrayList = CType(_ArrRoleFunction.ArrProp(i), clsPropRoleFuntion).SubFun
                    For j = 0 To tmpSubFun.Count - 1
                        Dim propSubFun As clsPropSubFun = CType(tmpSubFun(j), clsPropSubFun)
                        If propSubFun.Flag Then
                            blnResult = SaveSubFunction(propSubFun, conn, trans, strMsg)
                            If Not blnResult Then
                                Return blnResult
                            End If
                        End If
                    Next j
                Next i
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralUpdateSuccess, Title)
                clsLog.InsertLog(intUserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, _RoleName))
                Return blnResult
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, _RoleName)
                End If
                Return blnResult
            End If
        End Function

        Public Function GetRoleFunction(ByVal RoleName As String) As Boolean
            Return _ArrRoleFunction.AddTableToArray(GetAllFunction(RoleName), GetSubFunction())
        End Function

        'save UserFlag
        Public Function GetUserFlag() As Boolean
            Try
                Return _ArrUserFlag.AddTableToArray(GetAllUserFlag())
            Catch ex As Exception

            End Try

        End Function

        Private Function GetAllUserFlag() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, "select sFunNo,UserFlag from FunctionInfo")
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
        Public Function SaveUserFlag(ByRef strMsg As String) As Boolean
            Dim blnResult As Boolean = DeleteUserFlag(strMsg)
            If blnResult Then
                Dim i As Integer
                For i = 0 To _ArrUserFlag.ArrProp.Count - 1
                    Dim propUserFlag As clsPropUserFalg = CType(_ArrUserFlag.ArrProp(i), clsPropUserFalg)
                    If propUserFlag.FunNo.Length > 2 Then
                        blnResult = SaveUserFlagData(propUserFlag, strMsg)
                        If Not blnResult Then
                            Return blnResult
                        End If
                    End If
                Next
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralUpdateSuccess, Title)
                clsLog.InsertLog(intUserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, _RoleName))
                Return blnResult
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, _RoleName)
                End If
                Return blnResult
            End If
        End Function

        Private Function DeleteUserFlag(ByRef strMsg As String) As Boolean
            Try
                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, "update FunctionInfo set UserFlag='N' where len(sFunNo)>2")
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function SaveUserFlagData(ByVal propUserFlag As clsPropUserFalg, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@strFunNo", SqlDbType.NVarChar, 20)
                param(0).Value = propUserFlag.FunNo

                param(1) = New SqlParameter("@UserFlag", SqlDbType.NVarChar, 1)
                param(1).Value = propUserFlag.UserFlag

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.Text, "update FunctionInfo set UserFlag='" + propUserFlag.UserFlag + "' where sFunNo='" + propUserFlag.FunNo + "'")

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_Track_Administrator", param)

                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Public Function ModifyAdminCurrent(ByVal strValue As String) As Boolean
            Try
                Dim strRow As String() = GeneralFun.GetRow(strValue)
                Dim i As Integer
                Dim j As Integer
                For i = 0 To _ArrUserFlag.ArrProp.Count - 1
                    Dim tmpFunNo As String = CType(_ArrUserFlag.ArrProp(i), clsPropUserFalg).FunNo
                    If tmpFunNo.Length > 2 Then
                        If tmpFunNo.Length > 0 Then
                            For j = 0 To strRow.Length - 1
                                Dim strCol As String() = GeneralFun.GetCol(strRow(j))
                                If strCol(1).Trim = "1" Then
                                    strCol(1) = "Y"
                                Else
                                    strCol(1) = "N"
                                End If
                                If tmpFunNo = strCol(0).Trim Then
                                    CType(_ArrUserFlag.ArrProp(i), clsPropUserFalg).UserFlag = strCol(1).Trim
                                End If
                            Next
                        End If
                    End If
                Next i
                Return True
            Catch
                Return False
            End Try
        End Function

    End Class

#End Region
End Namespace