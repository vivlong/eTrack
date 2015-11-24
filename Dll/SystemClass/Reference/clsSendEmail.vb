Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Net.Mail
Imports System.Web.UI

Namespace SystemClass

    Public Class clsPropSendEmail
        Inherits clsProp
        Private _Id As Integer

        Private _ToName As String = ""
        Private _Cc As String = ""
        Private _Subject As String = ""
        Private _Content As String = ""
        Public Property ToName() As String
            Set(ByVal value As String)
                If _ToName <> value Then
                    _ToName = value
                End If
            End Set
            Get
                Return _ToName
            End Get
        End Property
        Public Property Cc() As String
            Set(ByVal value As String)
                If _Cc <> value Then
                    _Cc = value
                End If
            End Set
            Get
                Return _Cc
            End Get
        End Property
        Public Property Subject() As String
            Set(ByVal value As String)
                If _Subject <> value Then
                    _Subject = value
                End If
            End Set
            Get
                Return _Subject
            End Get
        End Property
        Public Property Content() As String
            Set(ByVal value As String)
                If _Content <> value Then
                    _Content = value
                End If
            End Set
            Get
                Return _Content
            End Get
        End Property
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            '_Id = intId
            _ToName = ""
            _Cc = ""
            _Subject = ""
            _Content = ""
        End Sub

    End Class
    Public Class colSendEmail
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropSendEmail(ConClass.NewIdValue.ToString)
        End Function
    End Class
    Public Class clsSendEmail
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            '_ConfirmExternal = False
            colProp = New colSendEmail()
            Title = "SendMail"
            ' colProp.AddOneSpaceRecord(0, intUserId)

        End Sub


        ''' <summary>
        ''' 100315 ZhiWei for judge by Role
        ''' </summary>
        ''' <param name="strUserId"></param>
        ''' <param name="RoleName"></param>
        ''' <param name="strFunNo"></param>
        ''' <remarks></remarks>
        'Public Sub New(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
        '    MyBase.New(strUserId, RoleName, strFunNo)
        '    _ConfirmExternal = False
        '    colProp = New colBooking()
        '    Title = "SendEmail"
        'End Sub
        'Get Email Set
        Private Function GetEmailAddress(ByVal intTrxNo As Int64, ByRef strFrom As String, ByRef strTo As String, ByRef strSmtpServer As String, ByRef intSmtpPort As Integer, ByRef strSmtpUser As String, ByRef strSmtpPassword As String) As Boolean
            '  If intTrxNo >= 0 Then
            Try
                Dim param(6) As SqlParameter

                param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                param(0).Value = intTrxNo

                param(1) = New SqlParameter("@strEmail", SqlDbType.NVarChar, 3000)
                param(1).Direction = ParameterDirection.Output

                param(2) = New SqlParameter("@strFrom", SqlDbType.NVarChar, 1000)
                param(2).Direction = ParameterDirection.Output

                param(3) = New SqlParameter("@strSmtpServer", SqlDbType.NVarChar, 1000)
                param(3).Direction = ParameterDirection.Output

                param(4) = New SqlParameter("@intSmtpPort", SqlDbType.Int)
                param(4).Direction = ParameterDirection.Output

                param(5) = New SqlParameter("@strSmtpUser", SqlDbType.NVarChar, 1000)
                param(5).Direction = ParameterDirection.Output

                param(6) = New SqlParameter("@strSmtpPassword", SqlDbType.NVarChar, 1000)
                param(6).Direction = ParameterDirection.Output

                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sps_EmailAddress", param)
                Try
                    strFrom = CStr(param(2).Value)
                    strTo = "" 'CStr(param(1).Value)
                    strSmtpServer = CStr(param(3).Value)
                    intSmtpPort = CInt(param(4).Value)
                    strSmtpUser = CStr(param(5).Value)
                    strSmtpPassword = CStr(param(6).Value)
                Catch ex As Exception

                End Try
                Return True
            Catch ex As Exception
                Return False
            End Try
            'Else
            '  Return False
            'End If
        End Function
        Public Function SendEmail(ByVal strUserName As String, Optional ByVal m_blnConfirm As Boolean = False, Optional ByVal m_blnSend As Boolean = False, Optional ByVal intType As Integer = 0, Optional ByVal strFunNo As String = "") As Boolean
            Dim objMail As New MailMessage
            Dim client As New SmtpClient
            Dim cp As clsPropSendEmail = CurrentProp
            Try
                Dim strHost = "mail.sysfreight.com"
                Dim strFrom As String = ""
                Dim strSmtpServer As String = ""
                Dim intSmtpPort As Integer = 25
                Dim strSmtpUser As String = ""
                Dim strSmtpPassword As String = ""
                Dim strTo As String = ""
                Dim strSubject As String = ""
                Dim strBody As String = ""
                Dim strCc As String = ""
                Dim i As Integer
                '+++++++++++++++++++ 081212 Net678 +++++++++++++++++++++++
                'Dim strSubOfTitle As String = "PO"
                'Dim TrxNo As String = "TrxNo"
                '+++++++++++++++++++++++ End +++++++++++++++++++++++++++++
                If Not GetEmailAddress(cp.Id, strFrom, strTo, strSmtpServer, intSmtpPort, strSmtpUser, strSmtpPassword) Then
                    Return False
                End If
                Dim strModule As String = ""
                strTo = cp.ToName
                strSubject = cp.Subject
                strBody = cp.Content
                strCc = cp.Cc
                If strModule <> "" Then
                    strModule = strModule.Substring(0, strModule.Length - 2)
                End If
                If intType = 0 Then

                    Dim tmpARR() As String
                    objMail.From = New MailAddress(strFrom) 'strFrom
                    'testbyzhiwei
                    'strTo = "zhiwei@sysfreight.com,"
                    'test
                    ' 081023 zhiwei
                    If strTo.Trim <> "" Then
                        'add email to 
                        tmpARR = strTo.Split(",")
                        For i = 0 To UBound(tmpARR)
                            If tmpARR(i).Trim <> "" Then
                                objMail.To.Add(New MailAddress(tmpARR(i).Trim))
                            End If
                        Next
                    End If
                    If strCc.Trim <> "" Then
                        'add email to 
                        tmpARR = strCc.Split(",")
                        For i = 0 To UBound(tmpARR)
                            If tmpARR(i).Trim <> "" Then
                                objMail.CC.Add(New MailAddress(tmpARR(i).Trim))
                            End If
                        Next
                    End If
                End If
                '++++++++++++++++++++++++++ End ++++++++++++++++++++++++++++++++
                objMail.Subject = strSubject
                objMail.Body = strBody

                client.Host = strSmtpServer
                client.Port = intSmtpPort
                If strSmtpServer <> "" Then
                    '.byzhiwei090106
                    client.UseDefaultCredentials = True '
                    client.EnableSsl = False '
                    client.Credentials = New System.Net.NetworkCredential(strSmtpUser, strSmtpPassword)
                    client.DeliveryMethod = SmtpDeliveryMethod.Network
                End If
                Try
                    client.Send(objMail)
                    Return True
                Catch ex As Exception
                    ''MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Overloads Overrides Function GetDetail(ByVal intId As Long) As clsProp

        End Function

        Public Overloads Overrides Function GetDetail(ByVal strKey As String) As clsProp

        End Function

        Protected Overrides Function GetList() As System.Data.DataTable

        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length < 2 Then
                Return False
            Else

                Dim tmpProp As clsPropSendEmail
                CurrentProp = colProp.NewOneProp()
                tmpProp = CurrentProp
                'If tmpId < 0 Then
                '    CurrentProp = colProp.NewOneProp()
                '    tmpProp = CurrentProp

                '    State = EditState.Insert
                'Else
                '    tmpProp = GetDetail(tmpId)
                '    State = EditState.Edit
                'End If
                'ship to info
                tmpProp.ToName = strRow(0)
                tmpProp.Cc = strRow(1)
                tmpProp.Subject = strRow(2)
                tmpProp.Content = strRow(3)

                CurrentProp = tmpProp
                Return True
            End If
        End Function
    End Class
End Namespace
