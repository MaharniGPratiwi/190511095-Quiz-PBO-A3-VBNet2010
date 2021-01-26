Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports System.Data.OracleClient.OracleException
Imports DevComponents.DotNetBar
Module Mymod
    Public mycommand As New System.Data.OracleClient.OracleCommand
    Public myadapter As New System.Data.OracleClient.OracleDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OracleClient.OracleDataReader
    Public SQL As String
    Public conn As New System.Data.OracleClient.OracleConnection
    Public cn As New Connection



    'Tabel Mekanik
    '-------------------------------
    Public MEKANIK_baru As Boolean
    Public oMekanik As New Mekanik
    Public menu_Mekanik As Boolean
    Public cldMekanik As New DMekanik()
    '--------------------------------

    'Tabel Service_Sepeda
    '-------------------------------
    Public SERVICE_SEPEDA_baru As Boolean
    Public oService_Sepeda As New Service_Sepeda
    Public menu_Service As Boolean
    Public cldService As New DService()
    '--------------------------------

    'Tabel Spare_Part
    '-------------------------------
    Public SPARE_PART_baru As Boolean
    Public oSpare_Part As New Spare_Part
    Public menu_SparePart As Boolean
    Public cldSparePart As New DSparePart()
    '--------------------------------

    Public TotalTab As Integer = 0
    Public x As Integer

    'Tabel User
    '--------------------------------
    Public user_baru As Boolean
    Public oUser As New user
    '--------------------------------
    Public login_valid As Boolean

    Public Sub DBConnect()
        cn.DataSource = "xe"
        cn.UserID = "Maharani"
        cn.Password = "123"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function

   Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)
    End Sub
End Module
