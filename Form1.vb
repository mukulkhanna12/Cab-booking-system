Imports MySql.Data.MySqlClient

Public Class Form1

    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Public id As Double
    Public wallet As Double

    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim Query As String
            Query = "Select * from cab.users where email='" & t1.Text & "' and pass='" & t2.Text & "' "
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0

            While READER.Read
                id = READER.GetString("id")
                wallet = READER.GetString("wallet")
                count = count + 1
            End While

            If count = 1 Then
                MessageBox.Show("Successfully logged in!")
                Form3.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username and password does not match")
            End If

            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
