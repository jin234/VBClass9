Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Dim part As String = "D:\Northwind.mdf"
    Dim Constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=" & part

    Dim conn As New SqlConnection(Constr)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.Open()

        Dim sql As String = "SELECT  distinct Customers.Country
                             FROM Customers             
                            "
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Customers")

        For i = 0 To data.Tables("Customers").Rows.Count - 1
            ComboBox1.Items.Add(data.Tables("Customers").Rows(i)(0))
        Next
        conn.Close()
        ComboBox1.Sorted = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        conn.Open()

        Dim sql As String = "SELECT  distinct Customers.City
                             FROM Customers    
                             where Customers.Country = '" & ComboBox1.Text & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Customers")
        ComboBox2.Items.Clear()

        For i = 0 To data.Tables("Customers").Rows.Count - 1
            ComboBox2.Items.Add(data.Tables("Customers").Rows(i)(0))
        Next
        conn.Close()
        ComboBox2.Enabled = True
        ComboBox2.Sorted = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.SelectedIndex <> -1 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()

        Dim sql As String = "SELECT Customers.CompanyName,Customers.ContactName,Customers.Phone
                             FROM Customers
                             where Customers.City = '" & ComboBox2.Text & "'" & "
                             Order By 1"
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Customers")

        DataGridView1.DataSource = data.Tables("Customers")

        conn.Close()
    End Sub
End Class
