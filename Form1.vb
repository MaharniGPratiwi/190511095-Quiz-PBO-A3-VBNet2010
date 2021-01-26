Public Class Form1
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        login_valid = oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            MessageBox.Show("Selamat Datang " & txtUsername.Text)
            Dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    Private Sub ValidateUserLogin()
        oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then

        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
