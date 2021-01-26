Public Class DService
    Private Sub reload()
        oService_Sepeda.getAllData(DataGridView1)
    End Sub

    Private Sub DService_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
    Private Sub TampilService_Sepeda()
        txtKS.Text = oService_Sepeda.kode_sepeda
        txtMS.Text = oService_Sepeda.merk_sepeda
        txtJS.Text = oService_Sepeda.jumblah_service
        txtService.Text = oService_Sepeda.barang_service
        txtSubtot.Text = oService_Sepeda.subtotal
        txtharga.Text = oService_Sepeda.harga
    End Sub
    Private Sub SimpanDataService_Sepeda()
        oService_Sepeda.kode_sepeda = txtKS.Text
        oService_Sepeda.merk_sepeda = txtMS.Text
        oService_Sepeda.jumblah_service = txtJS.Text
        oService_Sepeda.barang_service = txtService.Text
        oService_Sepeda.subtotal = txtSubtot.Text
        oService_Sepeda.harga = txtharga.Text
        oService_Sepeda.Simpan()
        reload()
        If (oService_Sepeda.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oService_Sepeda.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub clearentry()
        txtJS.Clear()
        txtKS.Clear()
        txtMS.Clear()
        txtService.Clear()
        txtSubtot.Clear()
        txtharga.Clear()
    End Sub

    Private Sub txtKS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKS.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oService_Sepeda.CariSERVICE_SEPEDA(txtKS.Text)
            If (MEKANIK_baru = False) Then
                TampilService_Sepeda()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If (txtJS.Text <> "" And txtKS.Text <> "" And txtMS.Text <> "" And txtService.Text <> "" And txtSubtot.Text <> "") Then
            SimpanDataService_Sepeda()
            clearentry()
            reload()
        Else
            MessageBox.Show("Data tidak boleh kosong!")
        End If
    End Sub

    Private Sub btnHitung_Click(sender As System.Object, e As System.EventArgs) Handles btnHitung.Click
        txtSubtot.Text = CDec(txtJS.Text) * CDec(txtharga.Text)
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearentry()
    End Sub

    Private Sub txtharga_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtharga.TextChanged

    End Sub
End Class