Imports System.Data
Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim part As String = "D:\Northwind.mdf"
        Dim Constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=" & part

        Dim conn As New SqlConnection(Constr)

        conn.Open()

        Dim sql As String = "SELECT * 
                             FROM Categories"
        Dim cmd As New SqlCommand(sql, conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read
            ListBox1.Items.Add(reader("categoryid") & " " & reader("categoryname"))
        End While
        conn.Close()

    End Sub

End Class
