Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Web.UI.WebControls

Namespace ZZSystem

    Public Class colColumn
        ' Methods
        Private Sub AddToColumn(ByVal intLevel As Integer, ByVal objColumn As clsPropColumn)
            Dim num As Integer
            Dim num3 As Integer
            Dim num4 As Integer
            objColumn.Level = intLevel
            Dim flag As Boolean = False
            Select Case Me._Column.Count
                Case 0
                    Me._Column.Add(objColumn)
                    GoTo Label_00F0
                Case 1
                    If (DirectCast(Me._Column.Item(0), clsPropColumn).Level > intLevel) Then
                        Me._Column.Insert(0, objColumn)
                    Else
                        Me._Column.Add(objColumn)
                    End If
                    GoTo Label_00F0
                Case Else
                    num = (Me._Column.Count - 1)
                    GoTo Label_00CF
            End Select
Label_00CF:
            num4 = 0
            If (num >= num4) Then
                If (DirectCast(Me._Column.Item(num), clsPropColumn).Level <= intLevel) Then
                    Me._Column.Insert((num + 1), objColumn)
                    flag = True
                Else
                    num = (num + -1)
                    GoTo Label_00CF
                End If
            End If
            If Not flag Then
                Me._Column.Insert(0, objColumn)
            End If
Label_00F0:
            num3 = (Me._Column.Count - 1)
            num = 0
            Do While (num <= num3)
                DirectCast(Me._Column.Item(num), clsPropColumn).Position = (num + 1)
                num += 1
            Loop
        End Sub

        Public Sub AddToColumn(ByVal strField As String, ByVal strTitle As String, ByVal FieldType As DbType, ByVal intLevel As Integer, ByVal dblWidth As Decimal, ByVal strFormat As String, ByVal blnTailZeroDelete As Boolean, ByVal intFixedDigital As Integer, ByVal strSortField As String, ByVal blnVisible As Boolean, ByVal strHeaderImageUrl As String)
            Dim objColumn As New clsPropColumn
            objColumn.FieldName = strField
            objColumn.FieldTitle = strTitle
            objColumn.Width = dblWidth
            objColumn.FixedDigital = intFixedDigital
            objColumn.TailZeroDelete = blnTailZeroDelete
            objColumn.Format = strFormat
            objColumn.Visible = blnVisible
            objColumn.HeaderImageUrl = strHeaderImageUrl
            objColumn.SortField = strSortField
            Select Case CInt(FieldType)
                Case 4, 7, 8
                    objColumn.FieldType = DbType.Decimal
                    objColumn.Align = HorizontalAlign.Right
                    If (Operators.CompareString(objColumn.Format, "", True) = 0) Then
                        objColumn.Format = ConNumeric.NormalFormat
                    End If
                    Exit Select
                Case 5
                    objColumn.FieldType = DbType.Date
                    objColumn.Align = HorizontalAlign.Left
                    If (Operators.CompareString(objColumn.Format, "", True) = 0) Then
                        objColumn.Format = ConDateTime.DateFormat
                    End If
                    Exit Select
                Case 6
                    objColumn.FieldType = DbType.DateTime
                    objColumn.Align = HorizontalAlign.Left
                    If (Operators.CompareString(objColumn.Format, "", True) = 0) Then
                        objColumn.Format = ConDateTime.DateTimeFormat
                    End If
                    Exit Select
                Case 10, 11
                    objColumn.FieldType = DbType.Int32
                    objColumn.Align = HorizontalAlign.Right
                    Exit Select
                Case 12
                    objColumn.FieldType = DbType.Int64
                    objColumn.Align = HorizontalAlign.Right
                    Exit Select
                Case &H10
                    objColumn.FieldType = DbType.String
                    objColumn.Align = HorizontalAlign.Left
                    Exit Select
                Case Else
                    objColumn.FieldType = DbType.String
                    objColumn.Align = HorizontalAlign.Left
                    Exit Select
            End Select
            objColumn.Position = Me._Column.Count
            Me.AddToColumn(intLevel, objColumn)
        End Sub

        Protected Function GetFieldPrefix(ByVal strFieldType As String) As String
            Dim preDateTime As String = ""
            Dim left As String = strFieldType
            If (Operators.CompareString(left, "String", True) = 0) Then
                Return FieldPrefix.PreString
            End If
            If (Operators.CompareString(left, "Double", True) = 0) Then
                Return FieldPrefix.PreDecimal
            End If
            If (Operators.CompareString(left, "Decimal", True) = 0) Then
                Return FieldPrefix.PreDecimal
            End If
            If (Operators.CompareString(left, "Currency", True) = 0) Then
                Return FieldPrefix.PreDecimal
            End If
            If (Operators.CompareString(left, "Integer", True) = 0) Then
                Return FieldPrefix.PreInteger
            End If
            If (Operators.CompareString(left, "Int32", True) = 0) Then
                Return FieldPrefix.PreInteger
            End If
            If (Operators.CompareString(left, "Int64", True) = 0) Then
                Return FieldPrefix.PreInteger
            End If
            If (Operators.CompareString(left, "Boolean", True) = 0) Then
                Return FieldPrefix.PreBoolean
            End If
            If (Operators.CompareString(left, "Date", True) = 0) Then
                Return FieldPrefix.PreDateTime
            End If
            If (Operators.CompareString(left, "DateTime", True) = 0) Then
                preDateTime = FieldPrefix.PreDateTime
            End If
            Return preDateTime
        End Function

        Protected Function GetFieldType(ByVal strFieldType As String) As DbType
            Dim dateTime As DbType = DbType.String
            Dim left As String = strFieldType
            If (Operators.CompareString(left, "String", True) = 0) Then
                Return DbType.String
            End If
            If (Operators.CompareString(left, "Double", True) = 0) Then
                Return DbType.Double
            End If
            If (Operators.CompareString(left, "Decimal", True) = 0) Then
                Return DbType.Decimal
            End If
            If (Operators.CompareString(left, "Currency", True) = 0) Then
                Return DbType.Currency
            End If
            If (Operators.CompareString(left, "Integer", True) = 0) Then
                Return DbType.Int16
            End If
            If (Operators.CompareString(left, "Int32", True) = 0) Then
                Return DbType.Int32
            End If
            If (Operators.CompareString(left, "Int64", True) = 0) Then
                Return DbType.Int64
            End If
            If (Operators.CompareString(left, "Boolean", True) = 0) Then
                Return DbType.Boolean
            End If
            If (Operators.CompareString(left, "Date", True) = 0) Then
                Return DbType.Date
            End If
            If (Operators.CompareString(left, "DateTime", True) = 0) Then
                dateTime = DbType.DateTime
            End If
            Return dateTime
        End Function


        ' Properties
        Public Property Column() As ArrayList
            Get
                Return Me._Column
            End Get
            Set(ByVal value As ArrayList)
                Me._Column = value
            End Set
        End Property

        Public Property OrderBy() As String
            Get
                Return Me._OrderBy
            End Get
            Set(ByVal value As String)
                Me._OrderBy = value
            End Set
        End Property

        Public Property TableName() As String
            Get
                Return Me._TableName
            End Get
            Set(ByVal value As String)
                Me._TableName = value
            End Set
        End Property

        Public Property TotalWidth() As Single
            Get
                Return Me._TotalWidth
            End Get
            Set(ByVal value As Single)
                Me._TotalWidth = value
            End Set
        End Property


        ' Fields
        Private _Column As ArrayList
        Private _OrderBy As String
        Private _TableName As String
        Private _TotalWidth As Single
    End Class
End Namespace

