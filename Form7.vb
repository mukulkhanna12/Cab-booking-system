Imports MySql.Data.MySqlClient

Public Class Form7

    Public MysqlConn As MySqlConnection
    Public COMMAND As MySqlCommand

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        MysqlConn.Open()
        Dim Query As String
        Query = "Select * from cab.trip where uid='" & Form1.id & "'"
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = Command.ExecuteReader

        ListView1.View = View.Details
        ListView1.Columns.Add("S no.", 100)
        ListView1.Columns.Add("FROM", 150)
        ListView1.Columns.Add("To", 150)
        ListView1.Columns.Add("amount", 150)

        Dim i As Integer
        i = 1
        Dim j As Integer
        j = 0

        While READER.Read


            ListView1.Items.Add(i)
            ListView1.Items(j).SubItems.Add(READER.GetString("start"))
            ListView1.Items(j).SubItems.Add(READER.GetString("end"))
            ListView1.Items(j).SubItems.Add(READER.GetString("amount"))

            i = i + 1
            j = j + 1


        End While


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Hide()
    End Sub

End Class