Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Web

Namespace ZZSystem

    Public Class clsDynamicSqlColumn
        Inherits colColumn
        ' Methods
        Public Sub New(ByVal intUserId As String, ByVal strTableName As String, ByVal blnDefault As Boolean)
            Me.Column = New ArrayList
            Me.TableName = strTableName
            Me._UserId = intUserId
            Me._Default = blnDefault
        End Sub

        Private Function GetColumnDataTable() As DataTable
            Dim table2 As DataTable
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter(3 - 1) {}
                commandParameters(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                commandParameters(0).Value = Me._UserId
                commandParameters(1) = New SqlParameter("@strTableName", SqlDbType.NVarChar, 50)
                commandParameters(1).Value = Me.TableName
                commandParameters(2) = New SqlParameter("@blnDefault", SqlDbType.Bit)
                commandParameters(2).Value = Me._Default
                Dim ds As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_GridSet", commandParameters)
                table2 = ds.Tables(0)
                If ds.Tables.Count > 1 Then
                    Me._intCount = ds.Tables(1).Rows(0)(0)
                    HttpContext.Current.Session.Item("intCount") = Me._intCount
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                table2 = New DataTable
                ProjectData.ClearProjectError()
                Return table2
                ProjectData.ClearProjectError()
            End Try
            Return table2
        End Function

        Public Sub GetColumnFromSql(ByVal blnAll As Boolean, ByVal blnFieldPrefix As Boolean, ByVal LoginType As String)
            Dim columnDataTable As DataTable = Me.GetColumnDataTable

            Dim num As Single = 0.0!
            Dim strTitle As String = ""
            Dim strField As String = ""
            Dim str8 As String = ""
            Dim intLevel As Integer = 0
            Dim dblWidth As New Decimal
            Dim strFieldType As String = ""
            Dim blnVisible As Boolean = True
            Dim strFormat As String = ""
            Dim blnTailZeroDelete As Boolean = False
            Dim intFixedDigital As Integer = 0
            Dim strHeaderImageUrl As String = ""
            Dim str7 As String = ""
            Dim str9 As String = "sEnglishTitle"
            Dim str5 As String = "sEnglishFormat"
            If Not Information.IsNothing(RuntimeHelpers.GetObjectValue(HttpContext.Current.Session.Item("CurrentLanguage"))) Then
                str7 = Conversions.ToString(HttpContext.Current.Session.Item("CurrentLanguage"))
            End If
            If String.IsNullOrEmpty(str7) Then
                str7 = "English"
            End If
            str9 = ("s" & str7 & "Title")
            str5 = ("s" & str7 & "Format")
            Dim num6 As Integer = (columnDataTable.Rows.Count - 1)
            Dim i As Integer = 0
            'when Customer login for control display 10 columns
            If LoginType = "0" Then
                If num6 > 9 And _intCount = "0" Then
                    num6 = 9
                End If
            ElseIf LoginType = "1" Then
                If num6 > 9 And _intCount = "0" Then
                    num6 = 9
                End If
            ElseIf LoginType = "DynamicCE" Then

            End If
            Do While (i <= num6)
                strField = columnDataTable.Rows.Item(i).Item("sFieldName").ToString
                strTitle = columnDataTable.Rows.Item(i).Item(str9).ToString
                str8 = columnDataTable.Rows.Item(i).Item("sSortField").ToString
                dblWidth = Decimal.Parse(columnDataTable.Rows.Item(i).Item("lFieldWidth").ToString)
                intLevel = Integer.Parse(columnDataTable.Rows.Item(i).Item("lFieldOrder").ToString)
                blnVisible = Boolean.Parse(columnDataTable.Rows.Item(i).Item("bFieldVisible").ToString)
                strFieldType = columnDataTable.Rows.Item(i).Item("sFieldType").ToString
                strFormat = columnDataTable.Rows.Item(i).Item(str5).ToString
                strHeaderImageUrl = columnDataTable.Rows.Item(i).Item("sHeaderImageUrl").ToString
                If blnFieldPrefix Then
                    strField = (Me.GetFieldPrefix(strFieldType) & strField)
                End If
                If (IIf((blnVisible OrElse blnAll), 1, 0) <> 0) Then
                    Me.AddToColumn(strField, strTitle, Me.GetFieldType(strFieldType), intLevel, dblWidth, strFormat, blnTailZeroDelete, intFixedDigital, strField, blnVisible, strHeaderImageUrl)
                    num = (num + Convert.ToSingle(dblWidth))
                End If
                i += 1
            Loop
            Me.TotalWidth = num
        End Sub

        Private Function SaveOneColumnSettings(ByVal strFieldName As String, ByVal intOrder As Integer, ByVal dblWidth As Decimal, ByVal blnVisible As Integer) As Boolean
            Dim flag As Boolean
            Try
                Dim commandParameters As SqlParameter() = New SqlParameter(6 - 1) {}
                commandParameters(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                commandParameters(0).Value = Me._UserId
                commandParameters(1) = New SqlParameter("@strTableName", SqlDbType.NVarChar, 50)
                commandParameters(1).Value = Me.TableName
                commandParameters(2) = New SqlParameter("@strFieldName", SqlDbType.NVarChar, 50)
                commandParameters(2).Value = strFieldName
                commandParameters(3) = New SqlParameter("@intFieldOrder", SqlDbType.Int)
                commandParameters(3).Value = intOrder
                commandParameters(4) = New SqlParameter("@dblFieldWidth", SqlDbType.Float)
                commandParameters(4).Value = dblWidth
                commandParameters(5) = New SqlParameter("@blnFieldVisible", SqlDbType.Bit)
                commandParameters(5).Value = blnVisible
                SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_Track_GridSet_Person", commandParameters)
                flag = True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                flag = False
                ProjectData.ClearProjectError()
                Return flag
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Function SetColumnToSqlFile(ByVal strValues As String) As Boolean
            Dim row As String() = GeneralFun.GetRow(strValues)
            Dim intOrder As Integer = 0
            Dim dblWidth As New Decimal
            Dim flag As Boolean = True
            Dim num4 As Integer = (row.Length - 1)
            Dim i As Integer = 0
            Do While (i <= num4)
                Dim col As String() = GeneralFun.GetCol(row(i))
                Dim strFieldName As String = col(4)
                intOrder = Integer.Parse(col(1))
                dblWidth = Decimal.Parse(col(2))
                flag = GeneralFun.IntStringAsBool(col(3))
                If Not Me.SaveOneColumnSettings(strFieldName, intOrder, dblWidth, CInt(flag)) Then
                    Return False
                End If
                i += 1
            Loop
            Return True
        End Function


        ' Fields
        Private _Default As Boolean
        Private _UserId As String
        Private _intCount As String
    End Class
End Namespace

