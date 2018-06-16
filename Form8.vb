Imports MySql.Data.MySqlClient

Public Class Form8

    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim cno As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader


        MysqlConn.Open()

        Dim query As String
        Dim complain As String
        Dim dname As String

        dname = ComboBox1.SelectedItem.ToString
        If RadioButton1.Checked = True Then

            complain = "Breaking Rules"

        ElseIf RadioButton2.Checked = True Then
            complain = "Fast Driving"

        ElseIf RadioButton3.Checked = True Then

            complain = "Wrong Dressing Sense"

        ElseIf RadioButton5.Checked = True Then

            complain = "Rude Behaviour"

        Else
            complain = "Dirty Car Environment"

        End If


        query = "insert into cab.complaints(name,complain) Values ('" & dname & "','" & complain & "')"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader


        MsgBox("Sorry for the inconvenience! We'll Back to you Soon!")
        READER.Close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Hide()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class