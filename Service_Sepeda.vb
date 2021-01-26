Public Class Service_Sepeda
    Dim strsql As String
    Dim info As String
    Private _idservice As System.Decimal
    Private _kode_sepeda As System.Decimal
    Private _merk_sepeda As System.String
    Private _barang_service As System.String
    Private _jumblah_service As System.String
    Private _subtotal As System.Decimal
    Private _harga As System.Decimal
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idservice()
        Get
            Return _idservice
        End Get
        Set(ByVal value)
            _idservice = value
        End Set
    End Property
    Public Property kode_sepeda()
        Get
            Return _kode_sepeda
        End Get
        Set(ByVal value)
            _kode_sepeda = value
        End Set
    End Property
    Public Property merk_sepeda()
        Get
            Return _merk_sepeda
        End Get
        Set(ByVal value)
            _merk_sepeda = value
        End Set
    End Property
    Public Property barang_service()
        Get
            Return _barang_service
        End Get
        Set(ByVal value)
            _barang_service = value
        End Set
    End Property
    Public Property jumblah_service()
        Get
            Return _jumblah_service
        End Get
        Set(ByVal value)
            _jumblah_service = value
        End Set
    End Property
    Public Property subtotal()
        Get
            Return _subtotal
        End Get
        Set(ByVal value)
            _subtotal = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (SERVICE_SEPEDA_baru = True) Then
            strsql = "Insert into SERVICE_SEPEDA(idservice,kode_sepeda,merk_sepeda,barang_service,jumblah_service,subtotal,harga) values ('" & _idservice & "','" & _kode_sepeda & "','" & _merk_sepeda & "','" & _barang_service & "','" & _jumblah_service & "','" & _subtotal & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update SERVICE_SEPEDA set idservice='" & _idservice & "', kode_sepeda='" & _kode_sepeda & "', merk_sepeda='" & _merk_sepeda & "', barang_service='" & _barang_service & "', jumblah_service='" & _jumblah_service & "', subtotal='" & _subtotal & "', harga='" & _harga & "' where KODE_SEPEDA='" & _KODE_SEPEDA & "'"
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
    Public Sub CariSERVICE_SEPEDA(ByVal sIDSERVICE As String)
        DBConnect()
        strsql = "SELECT * FROM SERVICE_SEPEDA WHERE IDSERVICE='" & sIDSERVICE & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            SERVICE_SEPEDA_baru = False
            DR.Read()
            idservice = Convert.ToString((DR("idservice")))
            kode_sepeda = Convert.ToString((DR("kode_sepeda")))
            merk_sepeda = Convert.ToString((DR("merk_sepeda")))
            barang_service = Convert.ToString((DR("barang_service")))
            jumblah_service = Convert.ToString((DR("jumblah_service")))
            subtotal = Convert.ToString((DR("subtotal")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            SERVICE_SEPEDA_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDSERVICE As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM SERVICE_SEPEDA WHERE IDSERVICE='" & sIDSERVICE & "'"
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
            strsql = "SELECT * FROM SERVICE_SEPEDA"
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
