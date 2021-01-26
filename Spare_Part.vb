Public Class Spare_Part

    Public mycommand As New System.Data.OracleClient.OracleCommand
    Public myadapter As New System.Data.OracleClient.OracleDataAdapter
    Public mydata As New DataTable
    Dim strsql As String
    Dim info As String
    Private _idsparepart As System.Decimal
    Private _kode_barang As System.String
    Private _nama_barang As System.String
    Private _jumblah_barang As System.String
    Private _satuan As System.String
    Private _harga As System.Decimal
    Private _subtotal As System.Decimal
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idsparepart()
        Get
            Return _idsparepart
        End Get
        Set(ByVal value)
            _idsparepart = value
        End Set
    End Property
    Public Property kode_barang()
        Get
            Return _kode_barang
        End Get
        Set(ByVal value)
            _kode_barang = value
        End Set
    End Property
    Public Property nama_barang()
        Get
            Return _nama_barang
        End Get
        Set(ByVal value)
            _nama_barang = value
        End Set
    End Property
    Public Property jumblah_barang()
        Get
            Return _jumblah_barang
        End Get
        Set(ByVal value)
            _jumblah_barang = value
        End Set
    End Property
    Public Property satuan()
        Get
            Return _satuan
        End Get
        Set(ByVal value)
            _satuan = value
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
    Public Property subtotal()
        Get
            Return _subtotal
        End Get
        Set(ByVal value)
            _subtotal = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (SPARE_PART_baru = True) Then
            strsql = "Insert into SPARE_PART(idsparepart,kode_barang,nama_barang,jumblah_barang,satuan,harga,subtotal) values ('" & _idsparepart & "','" & _kode_barang & "','" & _nama_barang & "','" & _jumblah_barang & "','" & _satuan & "','" & _harga & "','" & _subtotal & "')"
            info = "INSERT"
        Else
            strsql = "update SPARE_PART set idsparepart='" & _idsparepart & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', jumblah_barang='" & _jumblah_barang & "', satuan='" & _satuan & "', harga='" & _harga & "', subtotal='" & _subtotal & "' where KODE_BARANG='" & _kode_barang & "'"
            info = "UPDATE"
        End If
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
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
    Public Sub CariSPARE_PART(ByVal sIDSPAREPART As String)
        DBConnect()
        strsql = "SELECT * FROM SPARE_PART WHERE IDSPAREPART='" & sIDSPAREPART & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader
        If (DR.HasRows = True) Then
            SPARE_PART_baru = False
            DR.Read()
            idsparepart = Convert.ToString((DR("idsparepart")))
            kode_barang = Convert.ToString((DR("kode_barang")))
            nama_barang = Convert.ToString((DR("nama_barang")))
            jumblah_barang = Convert.ToString((DR("jumblah_barang")))
            satuan = Convert.ToString((DR("satuan")))
            harga = Convert.ToString((DR("harga")))
            subtotal = Convert.ToString((DR("subtotal")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            SPARE_PART_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDSPAREPART As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM SPARE_PART WHERE IDSPAREPART='" & sIDSPAREPART & "'"
        info = "DELETE"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM SPARE_PART"
            mycommand.Connection = conn
            mycommand.CommandText = strsql
            mydata.Clear()
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydata)
            With dg
                .DataSource = mydata
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

