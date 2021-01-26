Public Class Dashboard

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnService_Click(sender As System.Object, e As System.EventArgs) Handles btnService.Click
        If (menu_Service = False) Then
            BikinMenu(cldService, TabControl1, "Service")
            menu_Service = True
        Else
            x = getTabIndex(TabControl1, "Service")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded, TabControl1.Click
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub


    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If

        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()

        If (itemToRemove.ToString = "Service") Then
            menu_Service = False
        ElseIf (itemToRemove.ToString = "Spare Part") Then
            menu_SparePart = False
        ElseIf (itemToRemove.ToString = "Mekanik") Then
            menu_Mekanik = False
        Else

        End If
    End Sub

    Private Sub btnMekanik_Click(sender As System.Object, e As System.EventArgs) Handles btnMekanik.Click
        If (menu_Mekanik = False) Then
            BikinMenu(cldMekanik, TabControl1, "Mekanik")
            menu_Mekanik = True
        Else
            x = getTabIndex(TabControl1, "Mekanik")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnSparePart_Click(sender As System.Object, e As System.EventArgs) Handles btnSparePart.Click
        If (menu_SparePart = False) Then
            BikinMenu(cldSparePart, TabControl1, "Spare Part")
            menu_SparePart = True
        Else
            x = getTabIndex(TabControl1, "Spare Part")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub RibbonTabItem2_Click(sender As System.Object, e As System.EventArgs) Handles RibbonTabItem2.Click

    End Sub
End Class