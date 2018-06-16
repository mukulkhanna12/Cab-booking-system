Imports MySql.Data.MySqlClient

Public Class Form5
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim cno As String
    Dim phno As String
    Dim cid As String
    Dim dname As String

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader


        MysqlConn.Open()

        Dim query As String

        query = "Select * from cab.cars where price = '" & Form4.amount & "'"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader


        While READER.Read
            cno = READER.GetString("cno")
            phno = READER.GetString("phoneno")
            cid = READER.GetString("cid")
            Dname = READER.GetString("name")
        End While

        READER.Close()
        Label6.Text = Form4.amount

        Label4.Text = cno
        Label5.Text = phno

        Label9.Text = Dname

        MysqlConn.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        MysqlConn.Open()

        Dim READER As MySqlDataReader

        Dim uid As Integer
        Dim start As String
        Dim drop As String
        Dim amount As String

        start = Form4.selected1
        amount = Form4.amount
        drop = Form4.selected2

        Dim query As String
        Dim wallet As Integer

        uid = Form1.id
        wallet = 0

        query = "select * from cab.users where id = '" & Form1.id & "'"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
        While READER.Read
            wallet = READER.GetString("wallet")
        End While

        READER.Close()

        If wallet < (amount) Then
            MsgBox("Insufficient Funds ")
        Else
            Dim subb As Integer
            subb = wallet - amount

            query = "UPDATE cab.users SET wallet = '" & subb & "' where id='" & Form1.id & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
            End While

            READER.Close()

            query = "INSERT INTO cab.trip (uid,cid,start,end,amount) VALUES ('" & uid & "', '" & cid & "','" & start & "','" & drop & "','" & amount & "')"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
            End While

            READER.Close()

            MsgBox("Cab Booked Successfully")

            Form3.Show()
            Me.Hide()
        End If

        MysqlConn.Close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
        Me.Hide()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class