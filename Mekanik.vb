Public Class Mekanik
    Public mycommand As New System.Data.OracleClient.OracleCommand
    Public myadapter As New System.Data.OracleClient.OracleDataAdapter
    Public mydata As New DataTable

    Dim strsql As String
    Dim info As String
    Private _idmekamik As System.Decimal
    Private _nama_mekanik As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idmekamik()
        Get
            Return _idmekamik
        End Get
        Set(ByVal value)
            _idmekamik = value
        End Set
    End Property
    Public Property nama_mekanik()
        Get
            Return _nama_mekanik
        End Get
        Set(ByVal value)
            _nama_mekanik = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (MEKANIK_baru = True) Then
            strsql = "Insert into MEKANIK(idmekamik,nama_mekanik) values ('" & _idmekamik & "','" & _nama_mekanik & "')"
            info = "INSERT"
        Else
            strsql = "update MEKANIK set idmekamik='" & _idmekamik & "', nama_mekanik='" & _nama_mekanik & "' where NAMA_MEKANIK='" & _NAMA_MEKANIK & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub CariMEKANIK(ByVal sIDMEKAMIK As String)
        DBConnect()
        strsql = "SELECT * FROM MEKANIK WHERE IDMEKAMIK='" & sIDMEKAMIK & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            MEKANIK_baru = False
            DR.Read()
            idmekamik = Convert.ToString((DR("idmekamik")))
            nama_mekanik = Convert.ToString((DR("nama_mekanik")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            MEKANIK_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDMEKAMIK As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM MEKANIK WHERE IDMEKAMIK='" & sIDMEKAMIK & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM MEKANIK"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class

