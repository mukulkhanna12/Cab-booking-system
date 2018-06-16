
Imports MySql.Data.MySqlClient

Public Class Form6
    Public MysqlConn As MySqlConnection
    Public COMMAND As MySqlCommand
    Dim wallet As Integer
    Dim temp As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Value As Integer
        Dim final As Integer

        Value = ComboBox1.SelectedItem.ToString
        final = wallet + Value

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        MysqlConn.Open()
        Dim Query As String
        Query = "Update cab.users set wallet = '" & final & "' where id = '" & Form1.id & "'"
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = COMMAND.ExecuteReader

        MsgBox("Added")

        Label3.Text = final

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        MysqlConn.Open()
        Dim Query As String
        Query = "Select * from cab.users where id ='" & Form1.id & "'"
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = COMMAND.ExecuteReader


        While READER.Read
            wallet = READER.GetString("wallet")
        End While

        temp = wallet

        Label3.Text = wallet
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("100")
        ComboBox1.Items.Add("200")
        ComboBox1.Items.Add("300")
        ComboBox1.Items.Add("400")
        ComboBox1.Items.Add("500")
        ComboBox1.Text = "Select from..."



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class