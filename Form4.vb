
Imports MySql.Data.MySqlClient

Public Class Form4

    Public MysqlConn As MySqlConnection
    Public COMMAND As MySqlCommand
    Public selected1 As String
    Public selected2 As String
    Public amount As Integer

    Private Sub b2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b2.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "Select * from cab.place"
            Command = New MySqlCommand(Query, MysqlConn)
            READER = Command.ExecuteReader
            Dim count As Integer
            count = 0
            cb_test.Items.Clear()
            While READER.Read
                Dim sname As String
                sname = READER.GetString("place")
                cb_test.Items.Add(sname)
                cb_test2.Items.Add(sname)
            End While

            cb_test.Text = "Select from..."
            cb_test2.Text = "Select from..."
            'MsgBox(Form1.id)
            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selected1 = cb_test.SelectedItem.ToString
        selected2 = cb_test2.SelectedItem.ToString

        Dim READER2 As MySqlDataReader

        MysqlConn.Open()
        Dim Query As String
        Query = "Select * from cab.place where place='" & selected1 & "'"
        COMMAND = New MySqlCommand(Query, MysqlConn)

        READER2 = COMMAND.ExecuteReader
        Dim id1 As Integer
        Dim id2 As Integer

        While READER2.Read
            id1 = READER2.GetString("id")
        End While
        READER2.Close()

        Query = "Select * from cab.place where place='" & selected2 & "'"
        COMMAND = New MySqlCommand(Query, MysqlConn)

        READER2 = COMMAND.ExecuteReader

        While READER2.Read
            id2 = READER2.GetString("id")
        End While

        MysqlConn.Close()


        Dim temp As Integer
        Dim Diff As Integer

        If id1 < id2 Then
            temp = id1
            id1 = id2
            id2 = temp
        End If

        Diff = id1 - id2
        amount = 0

        If Diff >= 0 And Diff <= 5 Then
            amount = 100
        End If

        If Diff > 5 And Diff <= 10 Then
            amount = 200
        End If

        If Diff > 10 And Diff <= 15 Then
            amount = 300
        End If

        If Diff > 15 And Diff <= 20 Then
            amount = 400
        End If


        Form5.Show()
        Me.Hide()

    End Sub

    Private Sub cb_test_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_test.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class