Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Collections
Imports SysMagic.ZZSystem

Namespace SystemClass

    <Serializable()> _
    Public Class clsSelectRole
        Private _Id As Integer
        Private _No As Integer
        Private _RoleNo As String
        Private _RoleName As String

        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
            End Set
        End Property

        Public Property No() As Integer
            Get
                Return _No
            End Get
            Set(ByVal value As Integer)
                _No = value
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

        Public Sub New(ByVal intId As String)
            Me._Id = intId
            Me._No = 0
            Me._RoleNo = ""
            Me._RoleName = ""
        End Sub 'New
    End Class

    <Serializable()> _
    Public Class colSelectRole

        Private _ArrRole As ArrayList
        Private _IsEmpty As Boolean

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return _IsEmpty
            End Get
        End Property

        Public ReadOnly Property ArrRole() As ArrayList
            Get
                Return _ArrRole
            End Get
        End Property

        Public Sub New()
            _ArrRole = New ArrayList()
            _ArrRole.Add(New clsSelectRole(-1))
            _IsEmpty = True
        End Sub

        Public Function AddTableToArray(ByVal dt As DataTable, ByVal intFirstNo As Integer) As ArrayList
            _ArrRole.Clear()
            _IsEmpty = True
            Dim _tmpProduct As clsSelectRole
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                _tmpProduct = New clsSelectRole(-1)
                Dim t As Type = _tmpProduct.GetType()
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
                                    p.SetValue(_tmpProduct, "", Nothing)
                                Else
                                    p.SetValue(_tmpProduct, dt.Rows(i)(strFieldName).ToString().TrimEnd(), Nothing)
                                End If
                            End If
                        Case "Int16", "Int32"
                            strFieldName = "l" + strFieldName
                            If dt.Columns.IndexOf(strFieldName) >= 0 Then
                                If dt.Rows(i)(strFieldName) Is System.DBNull.Value Then
                                    p.SetValue(_tmpProduct, 0, Nothing)
                                Else
                                    p.SetValue(_tmpProduct, Integer.Parse(dt.Rows(i)(strFieldName).ToString()), Nothing)
                                End If
                            Else
                                'Not Database Field's Value
                                If strFieldName = "lNo" Then
                                    _tmpProduct.No = intFirstNo + i + 1
                                End If
                            End If
                        Case "Int64"
                            strFieldName = "l" + strFieldName
                            If dt.Columns.IndexOf(strFieldName) >= 0 Then
                                If dt.Rows(i)(strFieldName) Is System.DBNull.Value Then
                                    p.SetValue(_tmpProduct, 0, Nothing)
                                Else
                                    p.SetValue(_tmpProduct, Int64.Parse(dt.Rows(i)(strFieldName).ToString()), Nothing)
                                End If
                            End If
                        Case Else
                    End Select
                Next p
                'Add Object to Array
                _ArrRole.Add(_tmpProduct)
                'Set IsEmpty Property to false;
                If _IsEmpty Then
                    _IsEmpty = False
                End If
            Next i
            Return _ArrRole
        End Function
    End Class

    <Serializable()> _
    Public Class clsSelectRoleInfo '
        Private _ConnectionString As String
        Private ColRole As colSelectRole
        Private _Id As String

        Public Property Id() As String
            Get
                Return _Id
            End Get
            Set(ByVal value As String)
                _Id = value
            End Set
        End Property

        Public Sub New(ByVal intId As String)
            _ConnectionString = ConDbConn.ConnectionString
            ColRole = New colSelectRole()
            _Id = intId
        End Sub

        Public ReadOnly Property SourceIsEmpty() As Boolean
            Get
                Return ColRole.IsEmpty
            End Get
        End Property

        Public Function GetRoleInfoList(ByVal RoleName As String, ByVal strQuery As String) As ArrayList
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@RoleName", SqlDbType.NVarChar, 20)
                param(0).Value = RoleName

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1000)
                param(1).Value = strQuery

                ds = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "sps_Track_RoleInfo", param)
                dt = ds.Tables(0)
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                End If
                ColRole.AddTableToArray(dt, 0)
                Return ColRole.ArrRole
            Catch ex As Exception
                Return ColRole.ArrRole
            End Try
        End Function

    End Class
End Namespace
