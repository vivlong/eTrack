Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Enum Person Type "

    Public Enum PersonType
        None = 0
        CompanyManager = 1
        Programmer = 2
        Tester = 3
        Otherman = 4
        CompanyManagerAndProgrammer = 12
        CompanyManagerAndTester = 13
        ProgrammerAndTester = 23
    End Enum

#End Region

#Region " Class of Person Detail "

    <Serializable()> _
    Public Class clsPersonDetail

        Private _UserId As String
        Private _No As Integer
        Private _UserNo As String
        Private _UserName As String

        Public Property No() As Integer
            Get
                Return _No
            End Get
            Set(ByVal value As Integer)
                _No = value
            End Set
        End Property

        Public Property UserId() As String
            Get
                Return _UserId
            End Get
            Set(ByVal value As String)
                _UserId = value
            End Set
        End Property

        Public Property UserNo() As String
            Get
                Return _UserNo
            End Get
            Set(ByVal value As String)
                _UserNo = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property

        Public Sub New(ByVal intNo As Integer)
            Me._No = intNo
        End Sub

        Public Sub New(ByVal intNo As Integer, ByVal intUserId As String, ByVal strUserNo As String, ByVal strUserName As String)
            Me._No = intNo
            Me._UserId = intUserId
            Me._UserNo = strUserNo
            Me._UserName = strUserName
        End Sub

    End Class

#End Region

#Region " Class of Collection of Person Detail "

    <Serializable()> _
    Public Class colPersonDetail

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

        Public Function AddOneDetail(ByVal intUserId As String, ByVal strUserNo As String, ByVal strUserName As String) As Boolean
            If _IsEmpty Then
                _ArrDetail.Clear()
                _IsEmpty = False
                _ArrDetail.Add(New clsPersonDetail(1, intUserId, strUserNo, strUserName))
                _ArrDetail.Add(New clsPersonDetail(2))
                Return True
            Else
                Dim _tmpPerson As clsPersonDetail = CType(_ArrDetail((_ArrDetail.Count - 1)), clsPersonDetail)
                _tmpPerson.UserId = intUserId
                _tmpPerson.UserNo = strUserNo
                _tmpPerson.UserName = strUserName
                Dim intNo As Integer = _ArrDetail.Count + 1
                _ArrDetail.Add(New clsPersonDetail(intNo))
                Return True
            End If
        End Function

        Public Function DeleteOneDetail(ByVal intNo As Integer) As Boolean
            Dim intPosition As Integer = -1
            If _ArrDetail.Count >= intNo Then
                Dim _tmpPerson As clsPersonDetail = CType(_ArrDetail((intNo - 1)), clsPersonDetail)
                _ArrDetail.Remove(_tmpPerson)
                intPosition = intNo - 1
            End If
            If _ArrDetail.Count = 0 Then
                _ArrDetail.Add(New clsPersonDetail(0))
                _IsEmpty = True
                Return True
            End If
            If intPosition = -1 Then
                Return False
            Else
                Dim i As Integer
                For i = intPosition To _ArrDetail.Count - 1
                    Dim _tmpPerson As clsPersonDetail = CType(_ArrDetail(i), clsPersonDetail)
                    _tmpPerson.No = i + 1
                Next i
                Return True
            End If
        End Function

        Public Function DeleteAllDetail() As Boolean
            _ArrDetail.Clear()
            _ArrDetail.Add(New clsPersonDetail(1))
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

#Region " Class of Person Detail Server "

    <Serializable()> _
    Public MustInherit Class clsPersonDetailSrvr

        Private _ColBaseDetail As colPersonDetail
        Private _MasterId As String

        Public Property MasterId() As String
            Get
                Return _MasterId
            End Get
            Set(ByVal value As String)
                _MasterId = value
            End Set
        End Property

        Public Property ColBaseDetail() As colPersonDetail
            Get
                Return _ColBaseDetail
            End Get
            Set(ByVal value As colPersonDetail)
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

        Public Function AddSelectedPerson(ByVal strPerson As String) As ArrayList
            Dim strRow As String() = GeneralFun.GetRow(strPerson)
            Dim strValue() As String
            Dim UserNo As String
            Dim strUserNo As String
            Dim strUserName As String
            Dim blExists As Boolean = False
            Dim i As Integer
            For i = 0 To strRow.Length - 1
                strValue = GeneralFun.GetCol(strRow(i))
                Dim j As Integer
                blExists = False
                For j = 0 To _ColBaseDetail.ArrDetail.Count - 1
                    If strValue(2) = CType(_ColBaseDetail.ArrDetail(j), clsPersonDetail).UserNo Then
                        blExists = True
                        Exit For
                    End If
                Next j
                If Not blExists Then
                    Select Case strValue.Length
                        Case 1
                            UserNo = strValue(0)
                            strUserNo = ""
                            strUserName = ""
                            _ColBaseDetail.AddOneDetail(UserNo, strUserNo, strUserName)
                        Case 2
                            UserNo = strValue(2)
                            strUserNo = strValue(1)
                            strUserName = ""
                            _ColBaseDetail.AddOneDetail(UserNo, strUserNo, strUserName)
                        Case 3
                            UserNo = strValue(2)
                            strUserNo = strValue(2)
                            strUserName = strValue(3)
                            _ColBaseDetail.AddOneDetail(UserNo, strUserNo, strUserName)
                        Case 4
                            UserNo = strValue(2)
                            strUserNo = strValue(2)
                            strUserName = strValue(3)
                            _ColBaseDetail.AddOneDetail(UserNo, strUserNo, strUserName)
                        Case Else
                    End Select
                End If
            Next i
            Return _ColBaseDetail.ArrDetail
        End Function

        Public Function DeleteOnePerson(ByVal intNo As Integer) As Boolean
            Return _ColBaseDetail.DeleteOneDetail(intNo)
        End Function

        Public MustOverride Function GetDetail(ByVal MasterId As Int64) As ArrayList

        Public MustOverride Function InsertDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

        Public MustOverride Function UpdateDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

        Public MustOverride Function DeleteDetail(ByVal MasterId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean

    End Class

#End Region

#Region " Class Property of Person "

    <Serializable()> _
    Public Class clsPropPerson
        Inherits clsProp
        Private _lUserID As String
        Private _UserName As String
        Private _Password As String
        Private _StatusCode As String
        ' 
        Public Property lUserID() As String
            Set(ByVal value As String)
                If _lUserID <> value Then
                    _lUserID = value
                End If
            End Set
            Get
                Return _lUserID
            End Get
        End Property
        ' 
        Public Property UserName() As String
            Set(ByVal value As String)
                If _UserName <> value Then
                    _UserName = value
                End If
            End Set
            Get
                Return _UserName
            End Get
        End Property
        ' 
        Public Property Password() As String
            Set(ByVal value As String)
                If _Password <> value Then
                    _Password = value
                End If
            End Set
            Get
                Return _Password
            End Get
        End Property

        Public Property StatusCode() As String
            Set(ByVal value As String)
                If _StatusCode <> value Then
                    _StatusCode = value
                End If
            End Set
            Get
                Return _StatusCode
            End Get
        End Property


        Public Sub New(ByVal intId As String)
            MyBase.New(intId)
            _lUserID = ""
            _UserName = ""
            _Password = ""
            _StatusCode = ""
        End Sub
    End Class

#End Region

#Region " Class Collection of Person "

    <Serializable()> _
    Public Class colPerson
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False 'add by lzw 090608
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropPerson(ConClass.NewIdValue)
        End Function
    End Class

#End Region

#Region " Class Server of Person "

    <Serializable()> _
    Public Class clsPerson
        Inherits clsBaseSrv
        Private _PersonRole As clsPersonRole


        Public Property PersonRole() As clsPersonRole
            Get
                Return _PersonRole
            End Get
            Set(ByVal value As clsPersonRole)
                _PersonRole = value
            End Set
        End Property


        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colPerson()
            Title = "User Info"
            _PersonRole = New clsPersonRole(intUserId)

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
            colProp = New colPerson()
            Title = "User Info"
        End Sub

        Private Function InsertPerson(ByVal propPerson As clsPropPerson, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(2) As SqlParameter

                param(0) = New SqlParameter("@UserID", SqlDbType.NVarChar, 20)
                param(0).Value = propPerson.lUserID

                param(1) = New SqlParameter("@UserName", SqlDbType.NVarChar, 20)
                param(1).Value = propPerson.UserName

                param(2) = New SqlParameter("@Password", SqlDbType.NVarChar, 40)
                param(2).Value = propPerson.Password


                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Person", param)
                If intResult > 0 Then
                    propPerson.Id = Integer.Parse(param(0).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdatePerson(ByVal propPerson As clsPropPerson, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(2) As SqlParameter


                param(0) = New SqlParameter("@UserID", SqlDbType.NVarChar, 20)
                param(0).Value = propPerson.lUserID

                param(1) = New SqlParameter("@UserName", SqlDbType.NVarChar, 20)
                param(1).Value = propPerson.UserName

                param(2) = New SqlParameter("@Password", SqlDbType.NVarChar, 40)
                param(2).Value = propPerson.Password

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Person", param)
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

        Private Function DeletePerson(ByVal propPerson As clsPropPerson, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@UserID", SqlDbType.NVarChar, 20)
                param(0).Value = propPerson.UserId

                param(1) = New SqlParameter("@intIsDeleted", SqlDbType.Int)
                param(1).Value = 2 ' intDeleteType

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Person", param)
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
                Dim param(8) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
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

                param(8) = New SqlParameter("@Condition", SqlDbType.NVarChar)
                param(8).Value = Condition


                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Person_List", param)
                'Total Page Count
                PageCount = Integer.Parse(param(6).Value.ToString())
                'Total Record Count
                RecordCount = Integer.Parse(param(7).Value.ToString())
                dt = ds.Tables(1)
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
                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Person_Detail", param)
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
                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Person_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 3 Then
                Return False
            Else
                Dim tmpId As String = strRow(0).Trim
                Dim tmpProp As clsPropPerson
                If tmpId = "" Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropPerson)
                    tmpProp.Id = tmpId
                    State = EditState.Insert
                Else
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropPerson)
                    tmpProp.lUserID = strRow(0).Trim
                    tmpProp.UserName = strRow(1).Trim
                    tmpProp.Password = strRow(2).Trim
                    State = EditState.Edit
                End If

                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            blnReturn = InsertPerson(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                blnReturn = PersonRole.InsertDetail(tmpProp.Id, conn, trans, strMsg)
                If blnReturn Then
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.lUserID)

                    End If
                    Return True
                Else
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.lUserID)
                    End If
                    Return False
                End If
            End If
            Return False
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            blnReturn = UpdatePerson(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                blnReturn = PersonRole.UpdateDetail(tmpProp.lUserID, conn, trans, strMsg)
                If blnReturn Then
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.lUserID)
                    End If
                    Return True
                Else
                    If strMsg = "" Then
                        strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.lUserID)
                    End If
                    Return False
                End If
            End If
            Return False
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            blnReturn = DeletePerson(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.lUserID)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.lUserID)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            blnReturn = DeletePerson(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.lUserID)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.lUserID)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.lUserID))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.lUserID))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.lUserID))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropPerson = CType(CurrentProp, clsPropPerson)
            clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.lUserID))
        End Sub

    End Class

#End Region

#Region " Class of Password "

    <Serializable()> _
    Public Class clsPassword
        Inherits BaseTranSrvr
        Private _TableName As String
        Private _UserId As String
        Private _Password As String

        Public Function ModifyPassword(ByVal strValue As String) As Boolean
            Dim strCol As String() = GeneralFun.GetCol(strValue)
            If strCol.Length <> 3 Then
                Return False
            Else
                _UserId = strCol(0)
                _Password = strCol(1)
                _TableName = strCol(2)
                Return True
            End If
        End Function

        Protected Overrides Function SaveData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(2) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = _UserId

                param(1) = New SqlParameter("@strPassword", SqlDbType.NVarChar, 40)
                param(1).Value = _Password

                param(2) = New SqlParameter("@TableName", SqlDbType.NVarChar, 40)
                param(2).Value = _TableName

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Password", param)
                If intResult > 0 Then
                    strMsg = "Password is changed,please remember it!"
                    Return True
                Else
                    strMsg = "Password is changed failure!"
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

    End Class

#End Region

#Region " Class of Person List "

    <Serializable()> _
    Public Class clsPersonList
        Private _Type As PersonType
        Private _UserId As String

        Public Sub New(ByVal intUserId As String, ByVal intType As PersonType)
            _UserId = intUserId
            _Type = intType
        End Sub

        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = _UserId

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                Select Case _Type
                    Case PersonType.None
                        param(1).Value = ""
                    Case PersonType.CompanyManager
                        param(1).Value = "bCompanyManager=1"
                    Case PersonType.Programmer
                        param(1).Value = "bProgrammer=1"
                    Case PersonType.Tester
                        param(1).Value = "bTester=1"
                    Case PersonType.CompanyManagerAndProgrammer
                        param(1).Value = "(bCompanyManager=1 or bProgrammer=1 )"
                    Case PersonType.CompanyManagerAndTester
                        param(1).Value = "(bCompanyManager=1 or bTester=1)"
                    Case PersonType.ProgrammerAndTester
                        param(1).Value = "(bProgrammer=1 or bTester=1) "
                End Select
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Person", param)
                'Return DataTable
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try

        End Function

    End Class

#End Region

#Region " Class of Person Setting "

    <Serializable()> _
    Public Class clsPersonSet
        Private _UserId As String
        Private _FirstPage As String
        Private _DetailSize As Integer
        Private _QuerySize As Integer
        Private _OpenSize As Integer
        Private _SearchSize As Integer
        Private _InfoSize As Integer
        Private _DisplaySmsHint As Boolean
        Private _Title As String

        Public Sub New(ByVal intUserId As String)
            UserId = intUserId
            _Title = "personality setting"
        End Sub

        Public Property UserId() As String
            Get
                Return _UserId
            End Get
            Set(ByVal value As String)
                _UserId = value
            End Set
        End Property

        Public Property FirstPage() As String
            Get
                Return _FirstPage
            End Get
            Set(ByVal value As String)
                _FirstPage = value
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

        Public Property QuerySize() As Integer
            Get
                Return _QuerySize
            End Get
            Set(ByVal value As Integer)
                _QuerySize = value
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

        Public Property SearchSize() As Integer
            Get
                Return _SearchSize
            End Get
            Set(ByVal value As Integer)
                _SearchSize = value
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

        Public Property DisplaySmsHint() As Boolean
            Get
                Return _DisplaySmsHint
            End Get
            Set(ByVal value As Boolean)
                _DisplaySmsHint = value
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

        Public Function ModifyCurrent(ByVal tmpProp As clsPersonSet, ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 8 Then
                Return False
            Else
                tmpProp.UserId = strRow(0)
                tmpProp.FirstPage = strRow(1)
                If strRow(2) = "" Then
                    tmpProp.InfoSize = 10
                Else
                    tmpProp.InfoSize = Integer.Parse(strRow(2))
                End If
                If strRow(3) = "" Then
                    tmpProp.SearchSize = 10
                Else
                    tmpProp.SearchSize = Integer.Parse(strRow(3))
                End If
                If strRow(4) = "" Then
                    tmpProp.OpenSize = 10
                Else
                    tmpProp.OpenSize = Integer.Parse(strRow(4))
                End If
                If strRow(5) = "" Then
                    tmpProp.QuerySize = 10
                Else
                    tmpProp.QuerySize = Integer.Parse(strRow(5))
                End If
                If strRow(6) = "" Then
                    tmpProp.DetailSize = 10
                Else
                    tmpProp.DetailSize = Integer.Parse(strRow(6))
                End If
                If strRow(7) = "" Then
                    tmpProp.DisplaySmsHint = False
                Else
                    tmpProp.DisplaySmsHint = Boolean.Parse(strRow(7))
                End If
                Return True
            End If
        End Function

        Public Sub GetPersonSet(ByVal intUserId As String)
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intUserId

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonSet", param)
                dt = ds.Tables(0)
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    'UserId
                    'UserId = CInt(GeneralFun.CheckNull(dt.Rows(0)("lUserId"), DbType.Int32))
                    UserId = CStr(GeneralFun.CheckNull(dt.Rows(0)("lUserId"), DbType.String))
                    'FirstPage
                    FirstPage = CStr(GeneralFun.CheckNull(dt.Rows(0)("sFirstPage"), DbType.String)).TrimEnd()
                    'DetailSize
                    DetailSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lDetailSize"), DbType.Int32))
                    'QuerySize
                    QuerySize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lQuerySize"), DbType.Int32))
                    'OpenSize
                    OpenSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lOpenSize"), DbType.Int32))
                    'SearchSize
                    SearchSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lSearchSize"), DbType.Int32))
                    'InfoSize
                    InfoSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lInfoSize"), DbType.Int32))
                    'DisplaySmsHint
                    DisplaySmsHint = CBool(GeneralFun.CheckNull(dt.Rows(0)("bDisplaySmsHint"), DbType.Boolean))
                Next i
            Catch
            End Try
        End Sub

        Public Function UpdatePersonSet(ByVal propPerson As clsPersonSet, ByRef strMsg As String) As Boolean
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = propPerson.UserId

                param(1) = New SqlParameter("@strFirstPage", SqlDbType.NVarChar, 50)
                param(1).Value = propPerson.FirstPage

                param(2) = New SqlParameter("@intDetailSize", SqlDbType.Int)
                param(2).Value = propPerson.DetailSize

                param(3) = New SqlParameter("@intQuerySize", SqlDbType.Int)
                param(3).Value = propPerson.QuerySize

                param(4) = New SqlParameter("@intOpenSize", SqlDbType.Int)
                param(4).Value = propPerson.OpenSize

                param(5) = New SqlParameter("@intSearchSize", SqlDbType.Int)
                param(5).Value = propPerson.SearchSize

                param(6) = New SqlParameter("@intInfoSize", SqlDbType.Int)
                param(6).Value = propPerson.InfoSize

                param(7) = New SqlParameter("@blDisplaySmsHint", SqlDbType.Bit)
                param(7).Value = propPerson.DisplaySmsHint

                SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_Track_PersonSet", param)
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralUpdateSuccess, Title)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

    End Class

#End Region

#Region " Class of Person Role "

    <Serializable()> _
    Public Class clsPersonRole
        Inherits clsRoleInfoDetailSrvr

        Public Sub New(ByVal intUserId As String)
            ColBaseDetail = New colRoleInfoDetail()
        End Sub

        Public Overrides Function GetDetail(ByVal MasterId As String) As ArrayList
            ColBaseDetail.DeleteAllDetail()
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = MasterId

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_PersonRole", param)
                dt = ds.Tables(0)

                Dim intId As Integer
                Dim strRoleNo As String
                Dim strRoleName As String

                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    'intId
                    intId = CInt(GeneralFun.CheckNull(dt.Rows(i)("lId"), DbType.Int32))
                    'RoleNo
                    strRoleNo = CStr(GeneralFun.CheckNull(dt.Rows(i)("sRoleNo"), DbType.String)).TrimEnd()
                    'RoleName
                    strRoleName = CStr(GeneralFun.CheckNull(dt.Rows(i)("sRoleName"), DbType.String)).TrimEnd()

                    ColBaseDetail.AddOneDetail(intId, strRoleNo, strRoleName)
                Next i
                Return ColBaseDetail.ArrDetail
            Catch
                Return Nothing
            End Try
        End Function

        Private Function InsertOnePeronRole(ByVal intId As String, ByVal RoleInfo As clsRoleInfoDetail, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@intRoleId", SqlDbType.NVarChar, 20)
                param(0).Value = RoleInfo.Id

                param(1) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(1).Value = intId

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_RolePerson", param)

                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Public Overrides Function InsertDetail(ByVal intId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim _RoleInfo As clsRoleInfoDetail
            Dim blnResult As Boolean = True
            Dim i As Integer
            For i = 0 To (ArrDetail.Count - 1) - 1
                _RoleInfo = CType(ArrDetail(i), clsRoleInfoDetail)
                blnResult = InsertOnePeronRole(intId, _RoleInfo, conn, trans, strMsg)
                If Not blnResult Then
                    If strMsg = "" Then
                        '  strMsg = KeySaveFailure
                        '"Save user role raised error!(Role No:" + _RoleInfo.RoleNo + ")"
                    End If
                    Exit For
                End If
            Next i
            Return blnResult
        End Function

        Public Overrides Function UpdateDetail(ByVal intId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            If DeleteDetail(intId, conn, trans, strMsg) Then
                Return InsertDetail(intId, conn, trans, strMsg)
            Else
                Return False
            End If
        End Function

        Public Overrides Function DeleteDetail(ByVal intId As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intId

                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_PersonRole", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

    End Class

#End Region

#Region " Class of Person Query  Used in Query Person Settings "

    <Serializable()> _
    Public Class clsPersonQuery
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(4) As SqlParameter

                param(0) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                param(0).Value = Where

                param(1) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param(1).Value = PageIndex

                param(2) = New SqlParameter("@PageSize", SqlDbType.Int)
                param(2).Value = PageSize

                param(3) = New SqlParameter("@PageCount", SqlDbType.Int)
                param(3).Direction = ParameterDirection.Output

                param(4) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param(4).Direction = ParameterDirection.Output

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Person_Query", param)
                'Return PageCount
                PageCount = Integer.Parse(param(3).Value.ToString())
                'Total Record Count
                RecordCount = Integer.Parse(param(4).Value.ToString())
                dt = ds.Tables(1)
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

        Public Sub AddToWhereString(ByRef strOld As String, ByVal strAdd As String)
            If strAdd = "" Then
                Return
            End If
            If strOld = "" Then
                strOld = strAdd
            Else
                strOld = strOld + " or " + strAdd
            End If
        End Sub

    End Class

#End Region

#Region " Class of FirstPage List "

    <Serializable()> _
    Public Class clsFirstPageList
        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_FirstPage")
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