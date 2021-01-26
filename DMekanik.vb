Public Class DMekanik
    Private Sub reload()
        oMekanik.getAllData(DataGridView1)
    End Sub
    Private Sub DMekanik_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
    Private Sub TampilMekanik()
        txtIDMekanik.Text = oMekanik.idmekamik
        txtNmMekanik.Text = oMekanik.nama_mekanik
    End Sub
    Private Sub SimpanDataMekanik()
        oMekanik.idmekamik = txtIDMekanik.Text
        oMekanik.nama_mekanik = txtNmMekanik.Text
        oMekanik.Simpan()
        reload()
        If (oMekanik.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oMekanik.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub clearentry()
        txtIDMekanik.Clear()
        txtNmMekanik.Clear()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If (txtIDMekanik.Text <> "" And txtNmMekanik.Text <> "") Then
            SimpanDataMekanik()
            clearentry()
            reload()
        Else
            MessageBox.Show("Data tidak boleh kosong!")
        End If
    End Sub

    Private Sub txtIDMekanik_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIDMekanik.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oMekanik.CariMEKANIK(txtIDMekanik.Text)
            If (MEKANIK_baru = False) Then
                TampilMekanik()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearentry()
    End Sub

End Class