Imports System.Data
Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim part As String = "D:\Northwind.mdf"
        Dim Constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=" & part

        Dim conn As New SqlConnection(Constr)

        conn.Open()

        Dim sql As String = "SELECT * 
                             FROM Categories
                                                            
                            "
        Dim cmd As New SqlCommand(sql, conn)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()

        adapter.Fill(data, "Categories")

        'MessageBox.Show(data.Tables("Categories").Rows.Count & ": Row" & vbNewLine & data.Tables("Categories").Columns.Count & ": Columns")
        'MessageBox.Show(data.Tables("Categories").Columns(0).ToString)
        'MessageBox.Show(data.Tables("Categories").Rows(0)("CategoryName"))
        DataGridView1.DataSource = data.Tables("Categories")

        For i = 0 To data.Tables("Categories").Rows.Count - 1
            ListBox1.Items.Add(data.Tables("Categories").Rows(i)("CategoryID") & ").  " & data.Tables("Categories").Rows(i)("CategoryName"))
        Next

        conn.Close()

    End Sub

End Class
