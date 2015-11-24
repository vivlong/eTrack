Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Configuration
Imports System.Xml
Imports System.Web

Namespace ZZSystem
    <OptionText()> _
    Public Class ConnectionInfo
        Public server As String
        Public dataBaseList As String
        Public userId As String
        Public password As String
    End Class
    <OptionText()> _
    Public Class ConDbConn
        Public Shared _instance As New ConDbConn
        Public Shared ReadOnly Property Instance() As ConDbConn
            Get
                If _instance Is Nothing Then
                    _instance = New ConDbConn
                End If
                Return _instance
            End Get
        End Property
        Public Shared _dataKey As String
        Public Shared Property DataKey As String
            Get
                Return _dataKey
            End Get
            Set(ByVal value As String)
                If _dataKey = value Then
                    Return
                End If
                _dataKey = value
            End Set
        End Property
        Public Sub SetDataKey(ByVal keyValue As String)
            DataKey = keyValue
            If ConfigurationManager.AppSettings.Item(DataKey) IsNot Nothing Then
                Dim connStr() As String = ConfigurationManager.AppSettings.Item(DataKey).Split(",")
                If connStr.Length = 4 Then
                    _SelectDataBase = connStr(1)
                End If
            Else
                _SelectDataBase = keyValue
            End If
        End Sub
#Region "Return Note From XML"
        'Return Note From XML
        Public Function ReturnNoteName(ByVal noteName) As List(Of ConnectionInfo)
            Dim connectionInfo As New List(Of ConnectionInfo)

            Try
                Dim xmlPath As String = HttpContext.Current.Server.MapPath("Xml/MutiServer.xml")
                Dim xmlDoc = New XmlDocument
                xmlDoc.Load(xmlPath)
                Dim childNodes As XmlNodeList = xmlDoc.SelectSingleNode("MutiServer").ChildNodes
                Dim numChildNodes As Integer = childNodes.Count - 1
                Dim i As Integer = 0
                Do While (i <= numChildNodes)
                    Dim node As XmlNode = childNodes.ItemOf(i)
                    If (Operators.CompareString(node.NodeType.ToString, "Connection", True) <> 0) Then
                        Dim element As XmlElement = DirectCast(node, XmlElement)
                        If (Operators.CompareString(element.Name, "Connection", True) = 0) Then

                            Dim num8 As Integer = (element.ChildNodes.Count - 1)
                            Dim j As Integer = 0
                            Dim server As String = ""
                            Dim mutidatabase As String = ""
                            Dim userid As String = ""
                            Dim password As String = ""
                            Dim enable As String = ""
                            Do While (j <= num8)
                                Dim node2 As XmlNode = element.ChildNodes.ItemOf(j)
                                Dim name As String = node2.Name
                                Select Case name.ToLower
                                    Case "server"
                                        server = node2.InnerText
                                    Case "mutidatabase"
                                        mutidatabase = node2.InnerText
                                    Case "userid"
                                        userid = node2.InnerText
                                    Case "password"
                                        password = node2.InnerText
                                    Case "enable"
                                        enable = node2.InnerText
                                End Select
                                j += 1
                            Loop
                            Dim connection As New ConnectionInfo
                            If enable = "true" Then
                                connection.server = server
                                connection.dataBaseList = mutidatabase
                                connection.userId = userid
                                connection.password = password
                                connectionInfo.Add(connection)
                            End If
                        End If
                    End If
                    i += 1
                Loop
            Catch ex As Exception
                Return Nothing
            End Try
            Return connectionInfo
        End Function

        Public Shared selectServerName As String
        Public Shared selectDataBase As String
        Public Shared selectUserId As String
        Public Shared selectPassword As String

        ' Fields
        Public Shared _ConnectionString As String
        Public Shared Property _SelectServerName As String
            Get
                Return selectServerName
            End Get
            Set(ByVal value As String)
                If selectServerName = value Then
                    Return
                End If
                _ConnectionString = ""
                selectServerName = value
            End Set
        End Property
        Public Shared Property _SelectDataBase As String
            Get
                Return selectDataBase
            End Get
            Set(ByVal value As String)
                If selectDataBase = value Then
                    Return
                End If
                _ConnectionString = ""
                selectDataBase = value
            End Set
        End Property
        Public Shared Property _SelectUserId As String
            Get
                Return selectUserId
            End Get
            Set(ByVal value As String)
                If selectUserId = value Then
                    Return
                End If
                _ConnectionString = ""
                selectUserId = value
            End Set
        End Property
        Public Shared Property _SelectPassword As String
            Get
                Return selectPassword
            End Get
            Set(ByVal value As String)
                If selectPassword = value Then
                    Return
                End If
                _ConnectionString = ""
                selectPassword = value
            End Set
        End Property
#End Region
        Public Function ReturnDataBaseList() As String()
            Dim arrDataBase As String() = Nothing
            If ConfigurationManager.AppSettings.Item("DataBase") IsNot Nothing Then
                Dim dataBase As String = ConfigurationManager.AppSettings.Item("DataBase")
                arrDataBase = dataBase.Split(",")
            End If
            Return arrDataBase
        End Function

        Shared str0 As String = ""
        Shared str1 As String = ""
        Shared str2 As String = ""
        Shared str3 As String = ""


        Public Shared Property ConnectionString() As String
            Get
                Try
                    If ConfigurationManager.AppSettings.Item(DataKey) IsNot Nothing Then
                        Dim connStr() As String = ConfigurationManager.AppSettings.Item(DataKey).Split(",")
                        If connStr.Length = 4 Then
                            str0 = connStr(0)
                            str1 = connStr(1)
                            str2 = connStr(2)
                            str3 = connStr(3)
                            _ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};timeout={4}", str0, str1, str2, str3, "120")
                            Return _ConnectionString
                        End If
                    Else
                        str0 = ConfigurationManager.AppSettings.Item("DataSource")

                        If String.IsNullOrEmpty(_SelectDataBase) Then
                            str1 = ConfigurationManager.AppSettings.Item("InitialCatalog")
                        Else
                            str1 = _SelectDataBase
                        End If

                        str2 = ConfigurationManager.AppSettings.Item("UserId")
                        str3 = ConfigurationManager.AppSettings.Item("Password")
                        _ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};timeout={4}", str0, str1, str2, str3, "120")
                        Return _ConnectionString
                    End If

                Catch ex As Exception

                End Try
                If String.IsNullOrEmpty(_ConnectionString) Then
                    _ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};timeout={4}", str0, str1, str2, str3, "120")
                End If
                Return _ConnectionString
            End Get
            Set(ByVal value As String)
                _ConnectionString = value
            End Set
        End Property
    End Class
End Namespace

