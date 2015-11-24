Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Collections
Imports SysMagic.ZZSystem

Namespace SystemClass

    Public Enum NotifyType
        Normal = 0
        High = 1
    End Enum

#Region " Class Property of Selected Person "

    <Serializable()> _
    Public Class clsPropSelectedPerson
        Private _No As Integer
        Private _UserId As String
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

        Public Sub New(ByVal intId As Integer)
            Me._UserId = intId
            Me._No = 0
            Me._UserNo = ""
            Me._UserName = ""
        End Sub
    End Class

#End Region

#Region " Class Collection of Selected Person "

    <Serializable()> _
    Public Class colSelectPerson
        Private _ArrPerson As ArrayList
        Private _IsEmpty As Boolean

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return _IsEmpty
            End Get
        End Property

        Public ReadOnly Property ArrPerson() As ArrayList
            Get
                Return _ArrPerson
            End Get
        End Property

        Public Sub New()
            _ArrPerson = New ArrayList()
            _ArrPerson.Add(New clsPropSelectedPerson(0))
            _IsEmpty = True
        End Sub

        Public Function AddTableToArray(ByVal dt As DataTable, ByVal intFirstNo As Integer) As ArrayList
            _ArrPerson.Clear()
            _IsEmpty = True
            Dim _tmpPerson As clsPropSelectedPerson
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                _tmpPerson = New clsPropSelectedPerson(-1)
                Dim t As Type = _tmpPerson.GetType()
                Dim strFieldName As String
                Dim p As System.Reflection.PropertyInfo
                For Each p In t.GetProperties()
                    strFieldName = p.Name
                    Dim _TypeName As String = p.PropertyType.Name
                    Select Case _TypeName
                        Case "String"
                            strFieldName = "s" + strFieldName
                            If dt.Columns.IndexOf(strFieldName) >= 0 Then
                                If dt.Rows(i)(strFieldName) Is System.DBNull.Value Then
                                    p.SetValue(_tmpPerson, "", Nothing)
                                Else
                                    p.SetValue(_tmpPerson, dt.Rows(i)(strFieldName).ToString().TrimEnd(), Nothing)
                                End If
                            End If
                        Case "Int16", "Int32"
                            strFieldName = "l" + strFieldName
                            If dt.Columns.IndexOf(strFieldName) >= 0 Then
                                If dt.Rows(i)(strFieldName) Is System.DBNull.Value Then
                                    p.SetValue(_tmpPerson, 0, Nothing)
                                Else
                                    p.SetValue(_tmpPerson, Integer.Parse(dt.Rows(i)(strFieldName).ToString()), Nothing)
                                End If
                            Else
                                'Not Database Field's Value
                                If strFieldName = "lNo" Then
                                    _tmpPerson.No = intFirstNo + i + 1
                                End If
                            End If
                        Case "Int64"
                            strFieldName = "l" + strFieldName
                            If dt.Columns.IndexOf(strFieldName) >= 0 Then
                                If dt.Rows(i)(strFieldName) Is System.DBNull.Value Then
                                    p.SetValue(_tmpPerson, 0, Nothing)
                                Else
                                    p.SetValue(_tmpPerson, Int64.Parse(dt.Rows(i)(strFieldName).ToString()), Nothing)
                                End If
                            End If
                        Case Else
                    End Select
                Next p
                'Add Object to Array
                _ArrPerson.Add(_tmpPerson)
                'Set IsEmpty Property to false;
                If _IsEmpty Then
                    _IsEmpty = False
                End If
            Next i
            Return _ArrPerson
        End Function
    End Class

#End Region

#Region " Class of Selected Person "

    <Serializable()> _
    Public Class clsSelectPersonInfo '
        Private _ConnectionString As String
        Private ColPerson As colSelectPerson
        Private _UserId As String = ""
        Private _Type As PersonType

        Public Property UserId() As String
            Get
                Return _UserId
            End Get
            Set(ByVal value As String)
                _UserId = value
            End Set
        End Property

        Public Sub New(ByVal intUserId As String, ByVal intType As PersonType)
            _ConnectionString = ConDbConn.ConnectionString
            ColPerson = New colSelectPerson()
            _UserId = intUserId
            _Type = intType
        End Sub

        Public ReadOnly Property SourceIsEmpty() As Boolean
            Get
                Return ColPerson.IsEmpty
            End Get
        End Property

        Public Function GetPersonList(ByVal strQuery As String) As ArrayList
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
                param(0).Value = _UserId

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                param(1).Value = ""

                If strQuery <> "" Then
                    If param(1).Value.ToString() <> "" Then
                        param(1).Value = param(1).Value + " and (UserID like '%" + SqlRelation.SqlSafe(strQuery) + "%' or UserName like '%" + SqlRelation.SqlSafe(strQuery) + "%')"
                    Else
                        param(1).Value = " (UserID like '%" + SqlRelation.SqlSafe(strQuery) + "%' or UserName like '%" + SqlRelation.SqlSafe(strQuery) + "%')"
                    End If
                End If
                ds = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "sps_Track_Person", param)
                dt = ds.Tables(0)
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                End If
                ColPerson.AddTableToArray(dt, 0)
                Return ColPerson.ArrPerson
            Catch
                Return ColPerson.ArrPerson
            End Try
        End Function
        Public Function GetPersonListL(ByVal strQuery As String, ByVal flat As String) As ArrayList

            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar)
                param(0).Value = _UserId

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                param(1).Value = ""

                If strQuery <> "" Then
                    If param(1).Value.ToString() <> "" Then
                        param(1).Value = param(1).Value + " and (sUserNo like '%" + SqlRelation.SqlSafe(strQuery) + "%' or sUserName like '%" + SqlRelation.SqlSafe(strQuery) + "%' or sSearchCode1 like '%" + SqlRelation.SqlSafe(strQuery) + "%')"
                    Else
                        param(1).Value = " (sUserNo like '%" + SqlRelation.SqlSafe(strQuery) + "%' or sUserName like '%" + SqlRelation.SqlSafe(strQuery) + "%' or sSearchCode1 like '%" + SqlRelation.SqlSafe(strQuery) + "%')"
                    End If
                End If
                Dim strwhere As String = ""
                If flat.Trim <> "Edit" Then
                    strwhere = " sStatus='USE'"
                End If

                If param(1).Value = "" Then
                    If strwhere.Trim <> "" Then
                        strwhere = " where " & strwhere
                    End If
                    dt = BaseSelectSrvr.GetData("select  lUserId,sUserNo,sUserName from Person " & strwhere & " order by sUserName", "")
                Else
                    If strwhere.Trim <> "" Then
                        strwhere = " and " & strwhere
                    End If
                    dt = BaseSelectSrvr.GetData("select  lUserId,sUserNo,sUserName from Person where " & param(1).Value & strwhere & " order by sUserName", "")
                End If
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                End If
                ColPerson.AddTableToArray(dt, 0)
                Return ColPerson.ArrPerson
            Catch
                Return ColPerson.ArrPerson
            End Try
        End Function

    End Class

#End Region
End Namespace