Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Collections
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Globalization
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class of Property of Attach"

    <Serializable()> _
    Public Class clsPropAttach
        Inherits clsProp
        Private _FileId As Integer
        Private _OriginFile As String
        Private _FileName As String
        Private _FileType As String
        Private _FileSize As Int64
        Private _FileDate As DateTime
        Private _ReferenceFileName As String

        Public Property FileId() As Integer
            Get
                Return _FileId
            End Get
            Set(ByVal value As Integer)
                _FileId = value
            End Set
        End Property

        Public Property OriginFile() As String
            Get
                Return _OriginFile
            End Get
            Set(ByVal value As String)
                _OriginFile = value
            End Set
        End Property

        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

        Public Property FileType() As String
            Get
                Return _FileType
            End Get
            Set(ByVal value As String)
                _FileType = value
            End Set
        End Property

        Public Property FileSize() As Int64
            Get
                Return _FileSize
            End Get
            Set(ByVal value As Int64)
                _FileSize = value
            End Set
        End Property

        Public Property FileDate() As DateTime
            Get
                Return _FileDate
            End Get
            Set(ByVal value As DateTime)
                _FileDate = value
            End Set
        End Property

        Public Property ReferenceFileName() As String
            Get
                Return _ReferenceFileName
            End Get
            Set(ByVal value As String)
                _ReferenceFileName = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _FileId = 0
            _FileName = ""
        End Sub

    End Class

#End Region

#Region " Class Collection of Booking Attach "

    <Serializable()> _
    Public Class colBookingAttach
        Inherits colclsProp

        Public Sub New()
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropAttach(ConClass.NewIdValue)
        End Function

        Public Sub HandleProperty()
            Dim tmpProp As clsPropAttach
            Dim i As Integer
            For i = 0 To ArrProp.Count - 1
                tmpProp = CType(ArrProp(i), clsPropAttach)
                tmpProp.ReferenceFileName = PageFun.GetReferenceFile("", "../Temp/" + tmpProp.FileName, tmpProp.FileName)
            Next

        End Sub

    End Class

#End Region

#Region " Class of Booking Attach Server"

    <Serializable()> _
    Public Class clsAttach
        Inherits clsBaseSrv

        Private _MasterId As String

        Public Property MasterId() As String
            Get
                Return _MasterId
            End Get
            Set(ByVal value As String)
                _MasterId = value
            End Set
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return ArrProp.Count
            End Get
        End Property

        Public Sub New(ByVal intUserId As String, ByVal strTrxNo As String)
            MyBase.New(intUserId)
            colProp = New colBookingAttach()
            Title = "Booking"
            MasterId = strTrxNo
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intTrxNo", SqlDbType.NVarChar, 20)
                param(0).Value = MasterId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Booking_AttachAll", param)
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Public Overloads Sub GetListInfo(ByVal intPageIndex As Integer, ByVal intPageSize As Integer)
            MyBase.GetListInfo(intPageIndex, intPageSize)
            CType(colProp, colBookingAttach).HandleProperty()
        End Sub

        Public Overloads Sub GetListInfo(ByVal strPath As String, ByVal strFolder As String)
            Dim files As FileInfo() = clsAttachFileDirectory.GetAllFiles(strPath)
            Dim i As Integer
            Dim tmpProp As clsPropAttach
            Dim strFileName As String
            ArrProp.Clear()
            If Not files Is Nothing Then
                For i = 0 To files.Length - 1
                    tmpProp = New clsPropAttach(i)
                    strFileName = (files(i).FullName).Replace(strPath, "")
                    tmpProp.OriginFile = files(i).FullName
                    tmpProp.FileName = HttpContext.Current.Server.HtmlEncode(strFileName)
                    If files(i).Length < 1024 Then
                        tmpProp.FileSize = Decimal.Round(files(i).Length / 1024 + 0.5)
                    Else
                        tmpProp.FileSize = files(i).Length / 1024
                    End If
                    tmpProp.FileDate = files(i).LastWriteTime
                    Dim strExtension As String = files(i).Extension()
                    'If (strFileName.IndexOf(" ") < 0) AndAlso (clsAttachFileDirectory.JudgeDirectShowFile(strExtension)) Then
                    '    tmpProp.ReferenceFileName = PageFun.GetReferenceFile("", "../Doc/omtx1" + MasterId.ToString() + "/" + HttpContext.Current.Server.UrlEncode(strFileName), strFileName)
                    'Else
                    'If tmpProp.FileName.IndexOf("%") Then
                    '    tmpProp.FileName = tmpProp.FileName.Replace("%", "%25")
                    'End If
                    If tmpProp.FileName.IndexOf("&") Then
                        tmpProp.FileName = tmpProp.FileName.Replace("&", "%26")
                    End If
                    If tmpProp.FileName.IndexOf("+") Then
                        tmpProp.FileName = tmpProp.FileName.Replace("+", "%2B")
                    End If
                    If tmpProp.FileName.IndexOf("=") Then
                        tmpProp.FileName = tmpProp.FileName.Replace("=", "%3D")
                    End If
                    If tmpProp.FileName.IndexOf("#") Then
                        tmpProp.FileName = tmpProp.FileName.Replace("#", "%23")
                    End If
                    tmpProp.ReferenceFileName = "<A href=""../SysRef/ShowAttachFile.aspx?Id=" + MasterId + "&FileName=" + tmpProp.FileName + "&Folder=" + strFolder + """ target=""_blank"">" + strFileName + "</A>"
                    'End If
                    tmpProp.FileId = i + 1
                    tmpProp.No = i + 1
                    ArrProp.Add(tmpProp)
                Next
            End If
            tmpProp = New clsPropAttach(ConClass.NewIdValue)
            tmpProp.No = ArrProp.Count + 1
            ArrProp.Add(tmpProp)

        End Sub

        'Get Booking Attach Detail 
        Public Shared Function GetBookingAttachDetail(ByVal intTrxNo As Int64, ByVal intFileId As Integer) As Stream
            Dim result As Object = Nothing
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                param(0).Value = intTrxNo

                param(1) = New SqlParameter("@intFileId", SqlDbType.Int)
                param(1).Value = intFileId

                result = SqlHelper.ExecuteScalar(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Booking_AttachContent", param)
                Return New MemoryStream(CType(result, Byte()))
            Catch
                Return result
            End Try
        End Function

        'Insert Attach Detail
        Public Shared Function InsertAttachDetail(ByVal intTrxNo As Int64, ByVal intFileId As Integer, ByVal strFileName As String, ByVal bytesOriginal() As Byte, ByRef strMsg As String) As Boolean
            Try
                Dim param(3) As SqlParameter

                param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                param(0).Value = intTrxNo

                param(1) = New SqlParameter("@intFileId", SqlDbType.Int)
                param(1).Value = intFileId

                param(2) = New SqlParameter("@strFileName", SqlDbType.NVarChar, 100)
                param(2).Value = strFileName

                param(3) = New SqlParameter("@imgContent", SqlDbType.Image)
                param(3).Value = bytesOriginal

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_BookingAttach", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        'Delete Attach Detail 
        Public Shared Function DeleteAttachDetail(ByVal intTrxNo As Int64, ByVal intFileId As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                param(0).Value = intTrxNo

                param(1) = New SqlParameter("@intFileId", SqlDbType.Int)
                param(1).Value = intFileId

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_BookingAttach", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        'Update Attach Detail 
        Public Shared Function UpdateAttachDetail(ByVal intTrxNo As Int64, ByVal intFileId As Integer, ByVal strFileName As String, ByVal bytesOriginal() As Byte, ByRef strMsg As String) As Boolean
            Try
                Dim param(3) As SqlParameter

                param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                param(0).Value = intTrxNo

                param(1) = New SqlParameter("@intFileId", SqlDbType.Int)
                param(1).Value = intFileId

                param(2) = New SqlParameter("@strFileName", SqlDbType.NVarChar, 100)
                param(2).Value = strFileName

                param(3) = New SqlParameter("@imgContent", SqlDbType.Image)
                param(3).Value = bytesOriginal

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_BookingAttach", param)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Return New clsPropAttach(intId)
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Return New clsPropAttach(intId)
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean

        End Function
    End Class

#End Region

#Region " Class of Attach File & Directory Operation "

    Public Class clsAttachFileDirectory

        Private Shared _DirectShowExtension As String

        Public Shared Sub CreateDirectory(ByVal strDirectory As String)
            Try
                If Not Directory.Exists(strDirectory) Then
                    Directory.CreateDirectory(strDirectory)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Shared Sub RenameDirectory(ByVal strOldDirectory As String, ByVal strNewDirectory As String)
            Try
                If Directory.Exists(strOldDirectory) Then
                    Directory.Move(strOldDirectory, strNewDirectory)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Shared Function DeleteFile(ByVal strFullFileName As String) As Boolean
            Try
                If File.Exists(strFullFileName) Then
                    File.Delete(strFullFileName)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function DeleteAllFile(ByVal FolderPath As String) As Boolean
            Try
                Dim dirInfo As New DirectoryInfo(FolderPath)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                If files.Length = 0 Then
                    Return Nothing
                End If
                Dim i As Integer
                Dim fileNames(files.Length - 1) As String
                For i = 0 To files.Length - 1
                    fileNames(i) = files(i).FullName
                    Try
                        File.Delete(fileNames(i))
                    Catch ex As Exception

                    End Try

                Next
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function IsExistsFiles(ByVal strDirectory As String) As Boolean
            Try
                Dim dirInfo As New DirectoryInfo(strDirectory)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                Return files.Length > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function GetAllFiles(ByVal strDirectory As String) As FileInfo()
            CreateDirectory(strDirectory)
            Try
                Dim dirInfo As New DirectoryInfo(strDirectory)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                Return files
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetAllFileName(ByVal strDirectory As String) As String()
            CreateDirectory(strDirectory)
            Try
                Dim dirInfo As New DirectoryInfo(strDirectory)
                Dim files As FileInfo() = dirInfo.GetFiles("*.*")
                If files.Length = 0 Then
                    Return Nothing
                End If
                Dim i As Integer
                Dim fileNames(files.Length - 1) As String
                For i = 0 To files.Length - 1
                    fileNames(i) = files(i).FullName
                Next
                Return fileNames
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function ClearTempDirectoryLogout() As Boolean
            Try
                If Not HttpContext.Current.Session("AllBookingId") Is Nothing Then
                    Dim AllBookingId As ArrayList = CType(HttpContext.Current.Session("AllBookingId"), ArrayList)
                    Dim i As Integer
                    Dim intId As Int64
                    Dim strPath As String
                    Dim dirInfo As DirectoryInfo
                    For i = 0 To AllBookingId.Count - 1
                        intId = AllBookingId(i)
                        strPath = HttpContext.Current.Server.MapPath("Attach/" + intId.ToString() + "/")
                        dirInfo = New DirectoryInfo(strPath)
                        If dirInfo.Exists() Then
                            dirInfo.Delete(True)
                        End If
                    Next
                End If
                HttpContext.Current.Session.Remove("AllBookingId")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function ClearTempDirectoryLogin() As Boolean
            Try
                Dim strPath As String = HttpContext.Current.Server.MapPath("Attach/")
                Dim dirInfo As DirectoryInfo = New DirectoryInfo(strPath)
                Dim subdir As DirectoryInfo
                Dim strFileCreateTime As String
                Dim dtmTime As DateTime
                Dim cnCultureInfo = New CultureInfo("zh-cn")
                If dirInfo.Exists() Then
                    Dim directorys As DirectoryInfo() = dirInfo.GetDirectories("-*")
                    For Each subdir In directorys
                        strFileCreateTime = subdir.Name.Substring(1, 14)
                        If (strFileCreateTime.Length = 14) Then
                            strFileCreateTime = strFileCreateTime.Substring(0, 4) + "-" _
                                               + strFileCreateTime.Substring(4, 2) + "-" _
                                               + strFileCreateTime.Substring(6, 2) + " " _
                                               + strFileCreateTime.Substring(8, 2) + ":" _
                                               + strFileCreateTime.Substring(10, 2) + ":" _
                                               + strFileCreateTime.Substring(12, 2)
                            If DateTime.TryParse(strFileCreateTime, cnCultureInfo, DateTimeStyles.None, dtmTime) Then
                                If dtmTime.AddHours(1) < DateTime.Now Then
                                    If subdir.Exists() Then
                                        subdir.Delete(True)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function AddTempDirectoryToSession(ByVal intId As Int64) As Boolean
            Dim AllBookingId As ArrayList
            If HttpContext.Current.Session("AllBookingId") Is Nothing Then
                AllBookingId = New ArrayList()
            Else
                AllBookingId = CType(HttpContext.Current.Session("AllBookingId"), ArrayList)
            End If
            AllBookingId.Add(intId)
            HttpContext.Current.Session("AllBookingId") = AllBookingId
        End Function

        Public Shared Function JudgeDirectShowFile(ByVal strExtension As String) As Boolean
            If _DirectShowExtension Is Nothing OrElse _DirectShowExtension = String.Empty Then
                _DirectShowExtension = ConfigurationManager.AppSettings("DirectShowExtension").ToString().Trim()
            End If
            If _DirectShowExtension.IndexOf(strExtension, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

#End Region
End Namespace
