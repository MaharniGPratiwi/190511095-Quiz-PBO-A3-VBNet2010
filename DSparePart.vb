Public Class DSparePart
    Private Sub reload()
        oSpare_Part.getAllData(DataGridView1)
    End Sub
    Private Sub Spare_Part_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
    Private Sub TampilSpare_Part()
        txtkodeBr.Text = oSpare_Part.kode_barang
        txtnamaBr.Text = oSpare_Part.nama_barang
        txtSatuan.Text = oSpare_Part.satuan
        txtHarga.Text = oSpare_Part.harga
        txtkSubtot.Text = oSpare_Part.subtotal
        If (SPARE_PART_baru = False) Then
            TampilSpare_Part()
        End If
    End Sub
    Private Sub GetData()
        oSpare_Part.getAllData(DataGridView1)
    End Sub
    Private Sub SimpanDataSpare_Part()
        oSpare_Part.kode_barang = txtkodeBr.Text
        oSpare_Part.nama_barang = txtnamaBr.Text
        oSpare_Part.satuan = txtSatuan.Text
        oSpare_Part.harga = txtHarga.Text
        oSpare_Part.subtotal = txtkSubtot.Text
        oSpare_Part.Simpan()
        reload()
        If (oSpare_Part.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oSpare_Part.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        clearentry()
    End Sub

    Private Sub clearentry()
        txtkodeBr.Clear()
        txtnamaBr.Clear()
        txtHarga.Clear()
        txtkSubtot.Clear()
    End Sub

    Private Sub btnHitung_Click(sender As System.Object, e As System.EventArgs) Handles btnHitung.Click
        txtkSubtot.Text = CDec(txtSatuan.Text) * CDec(txtHarga.Text)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If (txtHarga.Text <> "" And txtkodeBr.Text <> "" And txtkSubtot.Text <> "" And txtnamaBr.Text <> "" And txtSatuan.Text <> "") Then
            SimpanDataSpare_Part()
            clearentry()
            reload()
        Else
            MessageBox.Show("Data tidak boleh kosong!")
        End If
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearentry()
    End Sub

    Private Sub txtkodeBr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodeBr.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oSpare_Part.CariSPARE_PART(txtkodeBr.Text)
            If (SPARE_PART_baru = False) Then
                TampilSpare_Part()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub txtkSubtot_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtkSubtot.TextChanged

    End Sub
End Class