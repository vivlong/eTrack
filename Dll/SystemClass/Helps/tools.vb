Imports Microsoft.VisualBasic
Imports System.Security
Imports System.IO
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports System.Text
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Namespace SystemClass
    Public Class tools
        Public Shared _instance As New tools
        Public Shared ReadOnly Property Instance() As tools
            Get
                If _instance Is Nothing Then
                    _instance = New tools
                End If
                Return _instance
            End Get
        End Property
        Public Shared Function DesCrypt(ByVal strValue As String) As String
            'If strValue = "" Then Return strValue
            Static DESKey() As Byte = New Byte() {70, 51, 50, 50, 49, 56, 54, 70}
            Static DESIV() As Byte = New Byte() {70, 51, 50, 50, 49, 56, 54, 70}
            Dim desprovider As Cryptography.DES = New Cryptography.DESCryptoServiceProvider()
            Dim data As Byte() = System.Text.Encoding.Default.GetBytes(strValue)
            desprovider.Key = DESKey
            desprovider.IV = DESIV
            Dim ms As MemoryStream = New MemoryStream()
            Dim cs As Cryptography.CryptoStream = New Cryptography.CryptoStream(ms, desprovider.CreateEncryptor(), Cryptography.CryptoStreamMode.Write)
            cs.Write(data, 0, data.Length)
            cs.FlushFinalBlock()
            Dim ret As StringBuilder = New StringBuilder()
            Dim intI As Integer
            Dim result As Byte() = ms.ToArray()
            For intI = 0 To result.Length - 1
                ret.AppendFormat("{0:X2}", result(intI))
            Next
            Return ret.ToString()
        End Function
        Public Shared Function DesDecrypt(ByVal strValue As String) As String
            Try
                Static DESKey() As Byte = New Byte() {70, 51, 50, 50, 49, 56, 54, 70}
                Static DESIV() As Byte = New Byte() {70, 51, 50, 50, 49, 56, 54, 70}
                Dim desprovider As Cryptography.DES = New Cryptography.DESCryptoServiceProvider()
                Dim inputByteArray(strValue.Length / 2 - 1) As Byte
                Dim intI As Integer
                For intI = 0 To strValue.Length / 2 - 1
                    inputByteArray(intI) = CType(Convert.ToInt32(strValue.Substring(intI * 2, 2), 16), Byte)
                Next
                desprovider.Key = DESKey
                desprovider.IV = DESIV
                Dim ms As MemoryStream = New MemoryStream()
                Dim cs As Cryptography.CryptoStream = New Cryptography.CryptoStream(ms, desprovider.CreateDecryptor(), Cryptography.CryptoStreamMode.Write)
                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                Return Encoding.Default.GetString(ms.ToArray())
            Catch
                Return strValue
            End Try
        End Function
        Public Shared Function addZero(ByVal intNum As Integer) As String
            If intNum <= 0 Then
                Return "00"
            ElseIf intNum > 0 And intNum < 10 Then
                Return "0" + intNum.ToString
            Else
                Return intNum
            End If
        End Function

        Public Shared Function showContainerName(ByVal ContainerType As String) As String
            Dim ContainerName As String = ""
            If ContainerType.Trim = "" Then : Return "" : End If
            Select Case ContainerType.ToLower
                Case "mt" : Return "Empty"
                Case "ld" : Return "Laden"
                Case Else : Return ContainerType
            End Select
        End Function
        Private Const CNULL_DATE As String = "01/01/1981"
        Public Shared Function CVal(ByVal varInput As Object) As Double
            Dim strInput As String
            If varInput Is Nothing Then CVal = 0 : Exit Function
            Select Case varInput.GetType().Name
                Case "String", "Char"
                    strInput = varInput
                Case "Int64", "Int32", "Int16", "Byte", "Decimal", "Double", "UInt64", "UInt32", "UInt16", "Single"
                    strInput = varInput.ToString
                Case "Object", "TextBox"
                    strInput = varInput.text
                Case "combobox"
                    strInput = varInput.text
                Case Else
                    strInput = 0
            End Select
            strInput = Replace(strInput, ",", "")
            CVal = Val(strInput)
        End Function
        Public Shared Function CheckNull(ByVal varResult As Object, Optional ByRef DataType As Short = 0) As Object
            'DataType 0 = String
            'DataType 1 = Numeric
            'DataType 2 = Datetime
            Dim varResult1 As Object
            If Not varResult Is Nothing Then
                If varResult.GetType.Name = "TextBox" Then
                    varResult1 = varResult.Text
                Else
                    varResult1 = varResult
                End If
            End If
            If IsDBNull(varResult1) Or varResult1 Is Nothing Then
                Select Case DataType
                    Case 1
                        CheckNull = 0
                    Case 2
                        CheckNull = CDate(CNULL_DATE)
                    Case 0
                        CheckNull = ""
                    Case Else 'to incase programmer pass wrong parameter over
                        Select Case varResult1.GetType.Name
                            Case "String", "Char"
                                CheckNull = ""
                            Case "Int16", "Int32", "Int64", "Decimal", "Double", "Single"
                                CheckNull = 0
                            Case "Datetime"
                                CheckNull = CDate(CNULL_DATE)
                            Case Else
                                CheckNull = ""
                        End Select
                End Select
            Else
                Select Case DataType
                    Case 1
                        Call RemoveSeparator(varResult1)
                        If IsNumeric(varResult1) Then
                            If varResult1.GetType.Name = "String" Or varResult1.GetType.Name = "Char" Then
                                CheckNull = CVal(varResult1)
                            Else
                                CheckNull = varResult1
                            End If
                        Else
                            CheckNull = 0
                        End If
                    Case 2
                        If IsDate(varResult1) Then
                            If varResult1.GetType.Name = "String" Then
                                CheckNull = CDate(varResult1)
                            Else
                                CheckNull = varResult1
                            End If
                        Else
                            CheckNull = CDate(CNULL_DATE)
                        End If
                    Case 0
                        CheckNull = varResult1.ToString()
                    Case Else 'to incase programmer pass wrong parameter over
                        Select Case varResult1.GetType.Name
                            Case "String", "Char"
                                CheckNull = varResult1
                            Case "Int16", "Int32", "Int64", "Decimal", "Double", "Single"
                                If IsNumeric(varResult1) Then
                                    CheckNull = varResult1
                                Else
                                    CheckNull = 0
                                End If
                            Case "Datetime"
                                If IsDate(varResult1) Then
                                    CheckNull = varResult1
                                Else
                                    CheckNull = CDate(CNULL_DATE)
                                End If
                            Case Else
                                CheckNull = ""
                        End Select
                End Select
            End If
        End Function
        Private Const CDEC_SEPARATOR As String = "."
        Private Const CTHS_SEPARATOR As String = ","
        Public Shared Function RemoveSeparator(ByRef SourceText As String, Optional ByRef Destination As TextBox = Nothing) As Object
            If IsDBNull(SourceText) Then SourceText = ""
            '* To store the values before decimal Separator
            Dim var_IntegerPart As String
            '* To store the values After decimal Separator
            Dim var_DecimalPart As String
            '* To store the values formatted with Thousand and Decimal  Separators
            '* including negative value
            Dim var_Value As String
            '* To store the values formatted with Thousand and Decimal  Separators
            '* NOT including negative value
            'Dim var_AbsSourceText As String
            '* No of Thousand that contains in the Source Value
            '* e.g 123456 contains two Thousand Values(1 is 123 and 2 is 456)
            Dim int_DecimalPlace As Short
            '* No of Thousand that contains in the Source Value
            '* e.g 123456 contains two Thousand Values(1 is 123 and 2 is 456)
            Dim int_NoOfThousand As Short
            '* Find Decimal Separator and Mark the position
            '* if  > 0 ,found the decimal
            int_DecimalPlace = InStr(SourceText, CDEC_SEPARATOR)
            var_Value = ""
            var_DecimalPart = ""
            '* Get Absolute value without minus
            'var_AbsSourceText = System.Math.Abs(Val(SourceText))
            '* If Decimal is found
            If int_DecimalPlace > 0 Then
                '* Get the Integer part prior to Decimal Sep:
                var_IntegerPart = Left(SourceText, InStr(SourceText, CDEC_SEPARATOR) - 1)
                '* Get the Integer part prior to Thousand Sep:
                var_DecimalPart = Right(SourceText, Len(SourceText) - Val(int_DecimalPlace))
            Else
                var_IntegerPart = SourceText
            End If
            '* Get the modulas of length that was divided by 3
            int_NoOfThousand = CShort(Len(var_IntegerPart) / 3)
            Do While Not Len(var_IntegerPart) = 0
                '* Find the Thousand Sep:
                If InStr(var_IntegerPart, CTHS_SEPARATOR) > 0 Then
                    '* Get the value prior to Thousand Sep:
                    var_Value = var_Value & Left(var_IntegerPart, InStr(var_IntegerPart, CTHS_SEPARATOR) - 1)
                    '* Refresh Integer part
                    var_IntegerPart = Right(var_IntegerPart, Len(var_IntegerPart) - InStr(var_IntegerPart, CTHS_SEPARATOR))
                Else
                    var_Value = var_Value & var_IntegerPart
                    Exit Do
                End If
            Loop
            '*If Decimal is contained and the value of Decimal Part is greater than 0
            If int_DecimalPlace > 0 And Val(var_DecimalPart) > 0 Then
                '* append the Decimal Separator
                var_Value = var_Value & CDEC_SEPARATOR
                '* Loop value of Decimal until to see Non Zero value
                '* to remove the Trailing Zeros
                Do While Val(Right(var_DecimalPart, 1)) = 0
                    var_DecimalPart = Left(var_DecimalPart, Len(var_DecimalPart) - 1)
                Loop
                '* append the refreshed Decimal Part to the var_Value
                var_Value = var_Value & var_DecimalPart
            End If
            If Val(var_Value) = 0 Then
                RemoveSeparator = "0"
                If Destination Is Nothing Then Exit Function
                Destination.Text = ""
            Else
                RemoveSeparator = var_Value
                If Destination Is Nothing Then Exit Function
                Destination.Text = var_Value
            End If
            If Val(var_Value) < 0 Then
                Destination.ForeColor = System.Drawing.Color.Red
            Else
                Destination.ForeColor = System.Drawing.Color.Black
            End If
        End Function
        Public Shared Function SQLSafe(ByRef Str_Renamed As String) As String
            SQLSafe = Replace(Str_Renamed, "'", "''")
        End Function
        Public Shared Function CheckUpdateFieldLength(ByRef strField As String) As String
            Dim i As Short
            Dim intLen As Short
            On Error GoTo ErrHandler
            CheckUpdateFieldLength = CVal(strField) + 1
            intLen = Len(CheckUpdateFieldLength)
            If intLen <> Len(strField) Then
                For i = intLen To Len(strField) - 1
                    CheckUpdateFieldLength = "0" & CheckUpdateFieldLength
                Next i
            End If
            Exit Function
ErrHandler:
            Return Err.Description
        End Function
        Public Sub setFocusControl(ByRef FirCon As WebControl, ByRef SecCon As WebControl)
            FirCon.Attributes.Add("OnKeyDown", "FocusControl(event,null," + SecCon.ClientID + ");")
        End Sub
    End Class
End Namespace