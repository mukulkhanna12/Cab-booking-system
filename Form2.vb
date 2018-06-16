Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Form2

    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim COMMAND2 As MySqlCommand
    Public id As Integer

    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=cab"

        Dim READER As MySqlDataReader

        Dim email_err As Boolean
        Dim err As Integer
        Dim phone As String


        err = 0

        Dim email, pass, name, gender As String


        name = t1.Text()
        pass = pass1.Text()

        phone = t3.Text()
        If rb1.Checked = True Then
            gender = "male"
        Else
            gender = "female"
        End If
        email = t4.Text()


        Try
            MysqlConn.Open()
            Dim Query As String
            Dim Query2 As String

            'all-validations

            'gender
            If rb1.Checked = True Then
                err = 0
            Else
                err = err + 1
            End If

            'phone no
            If IsNumeric(t3.Text) And t3.Text.Length = 10 Then
                err = 0
            Else MsgBox("Please Enter valid no.")
                err = err + 1
            End If


            'name
            If Not Regex.IsMatch(t1.Text, "^[a-z ]*$", RegexOptions.IgnoreCase) Then
                err = err + 1
                MessageBox.Show("Please Enter Alphabetic Characters Only!")
                t1.Focus()
                t1.Clear()

            End If

            'email
            email_err = Regex.IsMatch(t4.Text, "([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
                ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})", RegexOptions.IgnoreCase)
            If Not email_err Then
                err = err + 1
                MsgBox("Invalid Email")
            End If

            If err = 0 Then
                Query = "INSERT INTO cab.users (name,email,pass,phone,gender) VALUES ('" & name & "', '" & email & "','" & pass & "', '" & phone & "', '" & gender & "') "
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader

                Dim count As Integer
                count = 0

                While READER.Read
                    count = count + 1
                End While

                READER.Close()

                Query2 = "Select * from cab.users where email='" & email & "' and pass='" & pass & "' "
                    COMMAND2 = New MySqlCommand(Query2, MysqlConn)
                    READER = COMMAND2.ExecuteReader

                    While READER.Read
                        id = READER.GetString("id")
                    End While


                READER.Close()
                Form1.Show()
                Me.Hide()

                    MysqlConn.Close()

            ElseIf err > 0 Then
                    MsgBox("There are some errors!")
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try



    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub t1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t1.TextChanged

    End Sub

    Private Sub b2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b2.Click
        Form1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class