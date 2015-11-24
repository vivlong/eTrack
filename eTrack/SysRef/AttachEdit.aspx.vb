Imports System.Web.UI.HtmlControls
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports System.Security.Principal
Imports System.Runtime.InteropServices

Partial Class AttachEdit
    Inherits LanguagePage
    Private strTrxNo As String = ""
    Private strJobNo As String = ""
    Private docPath As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingPath")
    Private docUrl As String = System.Configuration.ConfigurationSettings.AppSettings("TrackingURL")

    Function SaveFile(ByVal ipf As System.Web.HttpPostedFile, ByRef strMsg As String) As Boolean
        If ipf.ContentLength / 1024 / 1024 > 30 Then
            strMsg = CStr(GetGlobalResourceObject("Message", "FileSizeTooBig"))
            Return False
        End If
        If ipf.FileName.Length > 1 Then
            Try
                Dim strFileName As String = ipf.FileName.Substring((ipf.FileName.LastIndexOf("\") + 1))
                Dim strAttachPath As String = Server.MapPath("../Doc/" + Request("Folder").ToString + "/" + strTrxNo.ToString() + "/")
                clsAttachFileDirectory.CreateDirectory(strAttachPath)
                Dim strFullFileName As String = strAttachPath + strFileName
                clsAttachFileDirectory.DeleteFile(strFullFileName)
                ipf.SaveAs(strFullFileName)
                Return True
            Catch ex As Exception
                strMsg = ex.Message
                Return False
            End Try
        End If
        Return True
    End Function
    Function SaveFileTracking(ByVal ipf As System.Web.HttpPostedFile, ByRef strMsg As String) As Boolean
        If ipf.ContentLength / 1024 / 1024 > 30 Then
            strMsg = CStr(GetGlobalResourceObject("Message", "FileSizeTooBig"))
            Return False
        End If
        If ipf.FileName.Length > 1 Then
            Try
                Dim strFileName As String = ipf.FileName.Substring((ipf.FileName.LastIndexOf("\") + 1))
                Dim strAttachPath As String = docPath + strJobNo + "/"
                clsAttachFileDirectory.CreateDirectory(strAttachPath)
                Dim strFullFileName As String = strAttachPath + strFileName
                clsAttachFileDirectory.DeleteFile(strFullFileName)
                ipf.SaveAs(strFullFileName)
                Return True
            Catch ex As Exception
                strMsg = ex.Message
                Return False
            End Try
        End If
        Return True
    End Function
    Protected Sub BtnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        Dim boo As Boolean = False
        Dim blnOk As Boolean = True
        Dim strMsg As String = ""
        If Request("Folder").ToString = "Tracking" Then

            If Not (Request("Id") Is Nothing) Then
                strJobNo = Request("Id").ToString()
                strJobNo = strJobNo.Replace("/", "-")
            End If
            Dim Files As System.Web.HttpFileCollection = Request.Files
            Dim i As Integer = 0
            Dim l As Integer = Files.Count
            Dim HostUser, HostPassword, HostIp As String
            HostUser = "" : HostPassword = "" : HostIp = ""
            If (Not ConfigurationManager.AppSettings.Item("HostUser") Is Nothing) And (Not ConfigurationManager.AppSettings.Item("HostPassword") Is Nothing) Then
                HostUser = ConfigurationManager.AppSettings.Item("HostUser") : HostPassword = ConfigurationManager.AppSettings.Item("HostPassword")
                HostIp = ConfigurationManager.AppSettings.Item("FileServer")
            End If
            'If HostUser <> "" Then
            '    boo = impersonateValidUser(WindowsIdentity.GetCurrent.Name.Split("\")(0), HostUser, HostPassword)
            '    If boo = False Then
            '        Dim ErrNo As String = Runtime.InteropServices.Marshal.GetLastWin32Error()
            '        ' Exit Sub
            '    End If
            'End If
            '  WNetHelper.WNetAddConnection(@"comp-1\user-1", "123456", @"\\192.168.0.9\share", "Z:")
            Try
                WNetHelper.WNetAddConnection(WindowsIdentity.GetCurrent.Name.Split("\")(0) + "\" + HostUser + "", HostPassword, docPath, "Z:")

            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>window.alert('1:" + WindowsIdentity.GetCurrent.Name.Split("\")(0) + "\" + HostUser + "|" + HostPassword + "|" + docPath + "|" + "Z:" + +"');</script>")
            End Try

            ' Directory.CreateDirectory("Z:\test")
            docPath = "Z:\"
            Try
                While i < l
                    If Not SaveFileTracking(Files(i), strMsg) Then
                        blnOk = False
                        Exit While
                    End If
                    i = i + 1
                End While
                If blnOk Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "Close", "<script>window.returnValue='" + strJobNo + "';window.close();</script>")
                Else
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>window.alert('" + strMsg + "');</script>")
                End If
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>window.alert('2:" + WindowsIdentity.GetCurrent.Name.Split("\")(0) + "\" + HostUser + "|" + HostPassword + "|" + docPath + "|" + "Z:" + +"');</script>")

            End Try

        Else
            strTrxNo = Request("id").ToString
            If Request("LineItemNo") IsNot Nothing Then
                strTrxNo += "#" + Request("LineItemNo").ToString
            End If
            Dim BookingFiles As System.Web.HttpFileCollection = Request.Files
            Dim i As Integer = 0
            Dim l As Integer = BookingFiles.Count
            While i < l
                If Not SaveFile(BookingFiles(i), strMsg) Then
                    blnOk = False
                    Exit While
                End If
                i = i + 1
            End While
            If blnOk Then
                ClientScript.RegisterStartupScript(Me.GetType(), "Close", "<script>window.returnValue='" + strTrxNo + "';window.close();</script>")
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>window.alert('" + strMsg + "');</script>")
            End If
        End If


    End Sub

    Dim LOGON32_LOGON_INTERACTIVE As Integer = 2
    Dim LOGON32_PROVIDER_DEFAULT As Integer = 0
    Dim impersonationContext As WindowsImpersonationContext
    Declare Function LogonUserA Lib "advapi32.dll" (ByVal lpszUsername As String, _
    ByVal lpszDomain As String, _
    ByVal lpszPassword As String, _
    ByVal dwLogonType As Integer, _
    ByVal dwLogonProvider As Integer, _
    ByRef phToken As IntPtr) As Integer
    Declare Auto Function DuplicateToken Lib "advapi32.dll" ( _
    ByVal ExistingTokenHandle As IntPtr, _
    ByVal ImpersonationLevel As Integer, _
    ByRef DuplicateTokenHandle As IntPtr) As Integer
    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

    Private Function impersonateValidUser(ByVal domain As String, ByVal userName As String, _
   ByVal password As String) As Boolean

        Dim tempWindowsIdentity As WindowsIdentity
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero
        impersonateValidUser = False
        If RevertToSelf() Then
            If LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                    tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                    impersonationContext = tempWindowsIdentity.Impersonate()
                    If Not impersonationContext Is Nothing Then
                        impersonateValidUser = True
                    End If
                End If
            End If
        End If
        If Not tokenDuplicate.Equals(IntPtr.Zero) Then
            CloseHandle(tokenDuplicate)
        End If
        If Not token.Equals(IntPtr.Zero) Then
            CloseHandle(token)
        End If
    End Function
    Private Sub undoImpersonation()
        If Not impersonationContext Is Nothing Then
            impersonationContext.Undo()
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
        End If
    End Sub
End Class

Public Class WNetHelper
    <DllImport("mpr.dll", EntryPoint:="WNetAddConnection2")> _
    Private Shared Function WNetAddConnection2(ByVal lpNetResource As NetResource, ByVal lpPassword As String, ByVal lpUsername As String, ByVal dwFlags As UInteger) As UInteger
    End Function

    <DllImport("Mpr.dll", EntryPoint:="WNetCancelConnection2")> _
    Private Shared Function WNetCancelConnection2(ByVal lpName As String, ByVal dwFlags As UInteger, ByVal fForce As Boolean) As UInteger
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Public Class NetResource
        Public dwScope As Integer

        Public dwType As Integer

        Public dwDisplayType As Integer

        Public dwUsage As Integer

        Public lpLocalName As String

        Public lpRemoteName As String

        Public lpComment As String

        Public lpProvider As String
    End Class

    ''' <summary> 
    ''' 为网络共享做本地映射 
    ''' </summary> 
    ''' <param name="username">访问用户名（windows系统需要加计算机名，如：comp-1\user-1）</param> 
    ''' <param name="password">访问用户密码</param> 
    ''' <param name="remoteName">网络共享路径（如：\\192.168.0.9\share）</param> 
    ''' <param name="localName">本地映射盘符</param> 
    ''' <returns></returns> 
    Public Shared Function WNetAddConnection(ByVal username As String, ByVal password As String, ByVal remoteName As String, ByVal localName As String) As UInteger
        Dim netResource As New NetResource()

        netResource.dwScope = 2
        netResource.dwType = 1
        netResource.dwDisplayType = 3
        netResource.dwUsage = 1
        netResource.lpLocalName = localName
        netResource.lpRemoteName = remoteName.TrimEnd("\"c)
        Dim result As UInteger = WNetAddConnection2(netResource, password, username, 0)

        Return result
    End Function

    Public Shared Function WNetCancelConnection(ByVal name As String, ByVal flags As UInteger, ByVal force As Boolean) As UInteger
        Dim nret As UInteger = WNetCancelConnection2(name, flags, force)

        Return nret
    End Function
End Class



