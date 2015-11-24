Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Reflection

Namespace ZZSystem

    Public MustInherit Class colclsProp
        ' Methods
        Public Function AddOneSpaceRecord(ByVal intFirstNo As Integer, ByVal intUserId As String) As Boolean
            Dim prop As clsProp = Me.NewOneProp
            prop.No = ((intFirstNo + Me.ArrProp.Count) + 1)
            prop.UserId = intUserId
            Me.ArrProp.Add(prop)
            Return True
        End Function

        Public Function AddTableToArray(ByVal dt As DataTable, ByVal intFirstNo As Integer, ByVal intUserId As String) As Boolean
            Me._ArrProp.Clear()
            Me._IsEmpty = True
            If (dt Is Nothing) Then
                Dim flag As Boolean
                Return flag
            End If
            Dim num2 As Integer = (dt.Rows.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                Me._ArrProp.Add(Me.RecordToProp(dt, intFirstNo, i))
                If Me._IsEmpty Then
                    Me._IsEmpty = False
                End If
                i += 1
            Loop
            Me.AddOneSpaceRecord(intFirstNo, intUserId)
            Return True
        End Function

        Public Overridable Function NewOneProp() As clsProp
            Return New clsProp(CLng(ConClass.NewIdValue))
        End Function

        Public Function RecordToProp(ByVal dt As DataTable, ByVal intFirstNo As Integer, ByVal intRowIndex As Integer) As clsProp
            Dim objProp As clsProp = Me.NewOneProp
            If (dt.Rows.Count > 0) Then
                Return Me.RecordToProp((objProp), dt, intFirstNo, intRowIndex)
            End If
            Return objProp
        End Function

        Public Function RecordToProp(ByRef objProp As clsProp, ByVal dt As DataTable, ByVal intFirstNo As Integer, ByVal intRowIndex As Integer) As clsProp
            Dim info As PropertyInfo
            For Each info In objProp.GetType.GetProperties
                Dim name As String = info.Name
                Dim str2 As String = info.PropertyType.Name
                Dim left As String = str2
                If (Operators.CompareString(left, "String", True) = 0) Then
                    name = (Me._PreString & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, "", Nothing)
                        Else
                            info.SetValue(objProp, dt.Rows.Item(intRowIndex).Item(name).ToString.TrimEnd(New Char(0 - 1) {}), Nothing)
                        End If
                    End If
                ElseIf (IIf(((Operators.CompareString(left, "Int16", True) = 0) OrElse (Operators.CompareString(left, "Int32", True) = 0)), 1, 0) <> 0) Then
                    name = (Me._PreInteger & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, 0, Nothing)
                        Else
                            info.SetValue(objProp, Integer.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    ElseIf (Operators.CompareString(name, (Me._PreInteger & "No"), True) = 0) Then
                        objProp.No = ((intFirstNo + intRowIndex) + 1)
                    End If
                ElseIf (Operators.CompareString(left, "Int64", True) = 0) Then
                    name = (Me._PreInteger & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, 0, Nothing)
                        Else
                            info.SetValue(objProp, Long.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    End If
                ElseIf (Operators.CompareString(left, "Double", True) = 0) Then
                    name = (Me._PreDecimal & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, 0, Nothing)
                        Else
                            info.SetValue(objProp, Double.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    End If
                ElseIf (Operators.CompareString(left, "Decimal", True) = 0) Then
                    name = (Me._PreDecimal & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, Decimal.Zero, Nothing)
                        Else
                            info.SetValue(objProp, Decimal.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    End If
                ElseIf (Operators.CompareString(left, "DateTime", True) = 0) Then
                    name = (Me._PreDateTime & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, DateTime.MinValue, Nothing)
                        Else
                            info.SetValue(objProp, DateTime.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    End If
                ElseIf (Operators.CompareString(left, "Boolean", True) = 0) Then
                    name = (Me._PreBoolean & name)
                    If (dt.Columns.IndexOf(name) >= 0) Then
                        If (dt.Rows.Item(intRowIndex).Item(name) Is DBNull.Value) Then
                            info.SetValue(objProp, False, Nothing)
                        Else
                            info.SetValue(objProp, Boolean.Parse(dt.Rows.Item(intRowIndex).Item(name).ToString), Nothing)
                        End If
                    ElseIf (Operators.CompareString(name, (Me._PreBoolean & "IsAdd"), True) = 0) Then
                        objProp.IsAdd = False
                    End If
                End If
            Next
            Return objProp
        End Function


        ' Properties
        Public Property ArrProp() As ArrayList
            Get
                Return Me._ArrProp
            End Get
            Set(ByVal value As ArrayList)
                Me._ArrProp = value
            End Set
        End Property

        Public Property HavePrefix() As Boolean
            Get
                Return Me._HavePrefix
            End Get
            Set(ByVal value As Boolean)
                Me._HavePrefix = value
                If Not Me._HavePrefix Then
                    Me._PreString = ""
                    Me._PreInteger = ""
                    Me._PreDecimal = ""
                    Me._PreDateTime = ""
                    Me._PreBoolean = ""
                Else
                    Me._PreString = FieldPrefix.PreString
                    Me._PreInteger = FieldPrefix.PreInteger
                    Me._PreDecimal = FieldPrefix.PreDecimal
                    Me._PreDateTime = FieldPrefix.PreDateTime
                    Me._PreBoolean = FieldPrefix.PreBoolean
                End If
            End Set
        End Property

        Public Property IsEmpty() As Boolean
            Get
                Return Me._IsEmpty
            End Get
            Set(ByVal value As Boolean)
                Me._IsEmpty = value
            End Set
        End Property


        ' Fields
        Private _ArrProp As ArrayList = New ArrayList
        Private _HavePrefix As Boolean = True
        Private _IsEmpty As Boolean = True
        Private _PreBoolean As String = FieldPrefix.PreBoolean
        Private _PreDateTime As String = FieldPrefix.PreDateTime
        Private _PreDecimal As String = FieldPrefix.PreDecimal
        Private _PreInteger As String = FieldPrefix.PreInteger
        Private _PreString As String = FieldPrefix.PreString
    End Class
End Namespace

