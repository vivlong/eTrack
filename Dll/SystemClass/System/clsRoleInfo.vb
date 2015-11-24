Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Collections
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class Property of Role Info "

    <Serializable()> _
    Public Class clsPropRoleInfo
        Inherits clsProp
        Private _lId As Integer
        Private _sRoleNo As String
        Private _sRoleName As String
        Private _sSearchCode1 As String

        Public Property lId() As Integer
            Get
                Return _lId
            End Get
            Set(ByVal value As Integer)
                _lId = value
            End Set
        End Property

        Public Property sRoleNo() As String
            Get
                Return _sRoleNo
            End Get
            Set(ByVal value As String)
                _sRoleNo = value
            End Set
        End Property

        Public Property sRoleName() As String
            Get
                Return _sRoleName
            End Get
            Set(ByVal value As String)
                _sRoleName = value
            End Set
        End Property

        Public Property sSearchCode1() As String
            Get
                Return _sSearchCode1
            End Get
            Set(ByVal value As String)
                _sSearchCode1 = value
            End Set
        End Property

        Public Sub New(ByVal intId As String)
            MyBase.New(intId)
            _lId = intId
            _sRoleNo = ""
            _sRoleName = ""
            _sSearchCode1 = ""
        End Sub

    End Class

#End Region

#Region " Class Collection of Role Info"

    <Serializable()> _
    Public Class colRoleInfo
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropRoleInfo(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class Server of Role Info "

    <Serializable()> _
    Public Class clsRoleInfo
        Inherits clsBaseSrv

        Private _RolePerson As clsRolePerson

        Public Property RolePerson() As clsRolePerson
            Get
                Return _RolePerson
            End Get
            Set(ByVal value As clsRolePerson)
                _RolePerson = value
            End Set
        End Property

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colRoleInfo()
            Title = "role info"
            _RolePerson = New clsRolePerson(intUserId)
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
            colProp = New colRoleInfo()
            Title = "role info"
        End Sub

        Private Function InsertRoleInfo(ByVal propRoleInfo As clsPropRoleInfo, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(4) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                'param(0).Value = propRoleInfo.Id
                param(0).Direction = ParameterDirection.Output

                param(1) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
                param(1).Value = propRoleInfo.UserId

                param(2) = New SqlParameter("@strRoleNo", SqlDbType.NVarChar, 20)
                param(2).Value = propRoleInfo.sRoleNo

                param(3) = New SqlParameter("@strRoleName", SqlDbType.NVarChar, 20)
                param(3).Value = propRoleInfo.sRoleName

                param(4) = New SqlParameter("@strSearchCode1", SqlDbType.NVarChar, 255)
                param(4).Value = propRoleInfo.sSearchCode1

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_RoleInfo", param)
                If intResult > 0 Then
                    propRoleInfo.Id = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateRoleInfo(ByVal propRoleInfo As clsPropRoleInfo, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(4) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = propRoleInfo.lId

                param(1) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
                param(1).Value = propRoleInfo.UserId

                param(2) = New SqlParameter("@strRoleNo", SqlDbType.NVarChar, 20)
                param(2).Value = propRoleInfo.sRoleNo

                param(3) = New SqlParameter("@strRoleName", SqlDbType.NVarChar, 20)
                param(3).Value = propRoleInfo.sRoleName

                param(4) = New SqlParameter("@strSearchCode1", SqlDbType.NVarChar, 255)
                param(4).Value = propRoleInfo.sSearchCode1

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_RoleInfo", param)
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

        Private Function DeleteRoleInfo(ByVal propRoleInfo As clsPropRoleInfo, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = propRoleInfo.lId

                param(1) = New SqlParameter("@intIsDeleted", SqlDbType.Int)
                param(1).Value = intDeleteType

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_RoleInfo", param)
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

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleInfo_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleInfo_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
            ds = Nothing
            dt = Nothing
        End Function
        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intId", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleInfo_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
            ds = Nothing
            dt = Nothing
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 4 Then
                Return False
            Else
                Dim tmpId As Integer = Integer.Parse(strRow(0))
                Dim tmpProp As clsPropRoleInfo
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropRoleInfo)
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.sRoleNo = strRow(1)
                tmpProp.sRoleName = strRow(2)
                tmpProp.UserId = strRow(3)
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            blnReturn = InsertRoleInfo(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                RolePerson.MasterId = tmpProp.sRoleNo
                blnReturn = RolePerson.InsertDetail(tmpProp.Id, conn, trans, strMsg)
                If blnReturn Then
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.lId)

                    End If
                    Return True
                Else
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.lId)
                    End If
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            blnReturn = UpdateRoleInfo(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                RolePerson.MasterId = tmpProp.lId
                blnReturn = RolePerson.UpdateDetail(tmpProp.lId, conn, trans, strMsg)
                If blnReturn Then
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.lId)
                    End If
                    Return True
                Else
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.lId)
                    End If
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            blnReturn = DeleteRoleInfo(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.lId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.lId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            blnReturn = DeleteRoleInfo(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.lId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.lId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.lId))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.lId))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.lId))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropRoleInfo = CType(CurrentProp, clsPropRoleInfo)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.lId))
        End Sub

    End Class

#End Region

#Region " Class of Role Person "

    <Serializable()> _
    Public Class clsRolePerson
        Inherits clsPersonDetailSrvr

        Public Sub New(ByVal intUserId As String)
            ColBaseDetail = New colPersonDetail()
        End Sub

        Private Function InsertOneRolePerson(ByVal propPerson As clsPersonDetail, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intRoleId", SqlDbType.NVarChar)
                param(0).Value = MasterId

                param(1) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
                param(1).Value = propPerson.UserNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_RolePerson", param)
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

        Public Overrides Function GetDetail(ByVal MasterId As Int64) As ArrayList
            ColBaseDetail.DeleteAllDetail()
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intRoleId", SqlDbType.Int)
                param(0).Value = MasterId

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_RolePerson", param)
                dt = ds.Tables(0)

                Dim UserNo As String
                Dim strUserNo As String
                Dim strUserName As String

                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    'UserId
                    If dt.Rows(i)("lUserId") Is System.DBNull.Value Then
                        UserNo = 0
                    Else
                        UserNo = dt.Rows(i)("lUserId").ToString()
                    End If
                    'UserNo
                    If dt.Rows(i)("UserNo") Is System.DBNull.Value Then
                        strUserNo = ""
                    Else
                        strUserNo = dt.Rows(i)("UserNo").ToString().TrimEnd()
                    End If
                    'UserName
                    If dt.Rows(i)("UserName") Is System.DBNull.Value Then
                        strUserName = ""
                    Else
                        strUserName = dt.Rows(i)("UserName").ToString().TrimEnd()
                    End If
                    ColBaseDetail.AddOneDetail(UserNo, strUserNo, strUserName)
                Next i
                Return ColBaseDetail.ArrDetail
            Catch
                Return Nothing
            End Try
        End Function

        Public Overrides Function InsertDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim tmpProp As clsPersonDetail
            Dim Count As Integer = CInt(ArrDetail.Count) - 1
            Dim i As Integer
            For i = 0 To Count - 1
                tmpProp = CType(ArrDetail(i), clsPersonDetail)
                InsertOneRolePerson(tmpProp, conn, trans, strMsg)
            Next i
            Return True
        End Function

        Public Overrides Function UpdateDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim tmpProp As clsPersonDetail
            If DeleteDetail(MasterId, conn, trans, strMsg) Then
                Dim Count As Integer = CInt(ArrDetail.Count) - 1
                Dim i As Integer
                For i = 0 To Count - 1
                    tmpProp = CType(ArrDetail(i), clsPersonDetail)
                    InsertOneRolePerson(tmpProp, conn, trans, strMsg)
                Next i
                Return True
            Else
                Return False
            End If
        End Function

        Public Overrides Function DeleteDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@RoleId", SqlDbType.NVarChar)
                param(0).Value = MasterId

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_RolePerson", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

    End Class

#End Region

#Region " Class of Role Info List "

    <Serializable()> _
    Public Class clsRoleInfoList

        Public Function ListData(ByVal RoleName As String, ByVal strWhere As String, ByVal strQuery As String) As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(2) As SqlParameter
                param(0) = New SqlParameter("@RoleName", SqlDbType.NVarChar, 4)
                param(0).Value = RoleName

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar)
                param(1).Value = strWhere

                param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar)
                param(2).Value = strQuery

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleInfo", param)
                'Return DataTable
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class of Role Info Detail "

    <Serializable()> _
    Public Class clsRoleInfoDetail

        Private _Id As Integer
        Private _No As Integer
        Private _RoleNo As String
        Private _RoleName As String

        Public Property No() As Integer
            Get
                Return _No
            End Get
            Set(ByVal value As Integer)
                _No = value
            End Set
        End Property

        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
            End Set
        End Property

        Public Property RoleNo() As String
            Get
                Return _RoleNo
            End Get
            Set(ByVal value As String)
                _RoleNo = value
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

        Public Sub New(ByVal intNo As Integer)
            _No = intNo
        End Sub

        Public Sub New(ByVal intNo As Integer, ByVal intId As Integer, ByVal strRoleNo As String, ByVal strRoleName As String)
            _No = intNo
            _Id = intId
            _RoleNo = strRoleNo
            _RoleName = strRoleName
        End Sub

    End Class

#End Region

#Region " Class Collection of Role Info Detail "

    <Serializable()> _
    Public Class colRoleInfoDetail

        Private _ArrDetail As ArrayList
        Private _IsEmpty As Boolean = True

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return _IsEmpty
            End Get
        End Property

        Public Sub New()
            _ArrDetail = New ArrayList()
            _IsEmpty = True
        End Sub

        Public Function AddOneDetail(ByVal intId As String, ByVal strRoleNo As String, ByVal strRoleName As String) As Boolean
            If _IsEmpty Then
                _ArrDetail.Clear()
                _IsEmpty = False
                _ArrDetail.Add(New clsRoleInfoDetail(1, intId, strRoleNo, strRoleName))
                _ArrDetail.Add(New clsRoleInfoDetail(2))
                Return True
            Else
                Dim _tmpRole As clsRoleInfoDetail = CType(_ArrDetail((_ArrDetail.Count - 1)), clsRoleInfoDetail)
                _tmpRole.Id = intId
                _tmpRole.RoleNo = strRoleNo
                _tmpRole.RoleName = strRoleName
                Dim intNo As Integer = _ArrDetail.Count + 1
                _ArrDetail.Add(New clsRoleInfoDetail(intNo))
                Return True
            End If
        End Function

        Public Function DeleteOneDetail(ByVal intNo As Integer) As Boolean
            Dim intPosition As Integer = -1
            If _ArrDetail.Count >= intNo Then
                Dim _tmpRole As clsRoleInfoDetail = CType(_ArrDetail((intNo - 1)), clsRoleInfoDetail)
                _ArrDetail.Remove(_tmpRole)
                intPosition = intNo - 1
            End If
            If _ArrDetail.Count = 0 Then
                _ArrDetail.Add(New clsRoleInfoDetail(0))
                _IsEmpty = True
                Return True
            End If
            If intPosition = -1 Then
                Return False
            Else
                Dim i As Integer
                For i = intPosition To _ArrDetail.Count - 1
                    Dim _tmpRole As clsRoleInfoDetail = CType(_ArrDetail(i), clsRoleInfoDetail)
                    _tmpRole.No = i + 1
                Next i
                Return True
            End If
        End Function

        Public Function DeleteAllDetail() As Boolean
            _ArrDetail.Clear()
            _ArrDetail.Add(New clsRoleInfoDetail(1))
            _IsEmpty = True
            Return True
        End Function

        Public ReadOnly Property ArrDetail() As ArrayList
            Get
                Return _ArrDetail
            End Get
        End Property

    End Class

#End Region

#Region " Class of Role Info Detail Server "

    <Serializable()> _
    Public MustInherit Class clsRoleInfoDetailSrvr

        Private _ColBaseDetail As colRoleInfoDetail
        Private _MasterId As String

        Public Property MasterId() As String
            Get
                Return _MasterId
            End Get
            Set(ByVal value As String)
                _MasterId = value
            End Set
        End Property

        Public Property ColBaseDetail() As colRoleInfoDetail
            Get
                Return _ColBaseDetail
            End Get
            Set(ByVal value As colRoleInfoDetail)
                _ColBaseDetail = value
            End Set
        End Property

        Public ReadOnly Property ArrDetail() As ArrayList
            Get
                Return _ColBaseDetail.ArrDetail
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return _ColBaseDetail.ArrDetail.Count
            End Get
        End Property

        Public Function AddSelectedRole(ByVal strPerson As String) As ArrayList
            Dim strRow As String() = GeneralFun.GetRow(strPerson)
            Dim strValue() As String
            Dim intId As Integer
            Dim strRoleNo As String
            Dim strRoleName As String
            Dim blExists As Boolean = False
            Dim i As Integer
            For i = 0 To strRow.Length - 1
                strValue = GeneralFun.GetCol(strRow(i))
                Dim j As Integer
                blExists = False
                For j = 0 To _ColBaseDetail.ArrDetail.Count - 1
                    If Integer.Parse(strValue(0)) = CType(_ColBaseDetail.ArrDetail(j), clsRoleInfoDetail).Id Then
                        blExists = True
                        Exit For
                    End If
                Next j
                If Not blExists Then
                    Select Case strValue.Length
                        Case 1
                            intId = Integer.Parse(strValue(0))
                            strRoleNo = ""
                            strRoleName = ""
                            _ColBaseDetail.AddOneDetail(intId, strRoleNo, strRoleName)
                        Case 2
                            intId = Integer.Parse(strValue(0))
                            strRoleNo = strValue(1)
                            strRoleName = ""
                            _ColBaseDetail.AddOneDetail(intId, strRoleNo, strRoleName)
                        Case 3
                            intId = Integer.Parse(strValue(0))
                            strRoleNo = strValue(1)
                            strRoleName = strValue(2)
                            _ColBaseDetail.AddOneDetail(intId, strRoleNo, strRoleName)
                        Case 4
                            intId = Integer.Parse(strValue(0))
                            strRoleNo = strValue(2)
                            strRoleName = strValue(3)
                            _ColBaseDetail.AddOneDetail(intId, strRoleNo, strRoleName)
                        Case Else
                    End Select
                End If
            Next i
            Return _ColBaseDetail.ArrDetail
        End Function

        Public Function DeleteOneRole(ByVal intNo As Integer) As Boolean
            Return _ColBaseDetail.DeleteOneDetail(intNo)
        End Function

        Public MustOverride Function GetDetail(ByVal MasterId As String) As ArrayList

        Public MustOverride Function InsertDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

        Public MustOverride Function UpdateDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

        Public MustOverride Function DeleteDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

    End Class

#End Region
End Namespace