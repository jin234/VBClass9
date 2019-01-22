Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim part As String = "D:\Northwind.mdf"
        Dim Constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=" & part
        Dim conn As New SqlConnection(Constr)

        conn.Open()

        Dim sql As String = "SELECT Customers.CompanyName,Customers.ContactName,Customers.Address,Customers.City,Customers.Phone,Customers.CustomerID
                             FROM Customers                                                            
                            "
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Customers")
        Dim found As Boolean = False
        Dim txtid As String = TextBox1.Text
        If data.Tables("Customers").Rows.Count <> 0 Then
            For i = 0 To data.Tables("Customers").Rows.Count - 1
                If data.Tables("Customers").Rows(i)(5) = txtid.ToUpper Then
                    Label7.Text = data.Tables("Customers").Rows(i)(0)
                    Label8.Text = data.Tables("Customers").Rows(i)(1)
                    Label9.Text = data.Tables("Customers").Rows(i)(2)
                    Label10.Text = data.Tables("Customers").Rows(i)(3)
                    Label11.Text = data.Tables("Customers").Rows(i)(4)
                    found = True
                End If
            Next
        End If
        If found = False Then

            MessageBox.Show(txtid & " not Found")
            Label7.Text = "..."
            Label8.Text = "..."
            Label9.Text = "..."
            Label10.Text = "..."
            Label11.Text = "..."
        End If
        conn.Close()
    End Sub


End Class
