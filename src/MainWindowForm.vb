Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainWindowForm
    Private ExportDirectory As String = String.Format("{0}\Exports\", Environment.CurrentDirectory)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChoosePath()
    End Sub
    Private Sub LoadContent()
        For Each foundFolder In My.Computer.FileSystem.GetDirectories(PathBox.Text)
            OutputBox.Items.Add(My.Computer.FileSystem.GetName(foundFolder), True)
        Next
        For Each foundFile In My.Computer.FileSystem.GetFiles(PathBox.Text)
            OutputBox.Items.Add(My.Computer.FileSystem.GetName(foundFile), True)
        Next
    End Sub
    Private Sub ChoosePath()
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = ""

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PathBox.Text = dialog.SelectedPath
            LoadContent()
        Else
            PathBox.Text = ""
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ChoosePath()
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        Dim expFile As System.IO.StreamWriter
        Dim expFilePath As String = ExportDirectory & Replace(Replace(Replace(DateTime.Now, ":", ""), ".", ""), " ", "_") & ".txt"

        If Not My.Computer.FileSystem.DirectoryExists(ExportDirectory) Then
            Directory.CreateDirectory(ExportDirectory)
        End If

        File.Create(expFilePath).Close()

        expFile = My.Computer.FileSystem.OpenTextFileWriter(expFilePath, True)
        For Each checkedLine In OutputBox.CheckedItems
            expFile.WriteLine(checkedLine)
        Next
        expFile.Close()
    End Sub

    Private Sub OpenExports_Click(sender As Object, e As EventArgs) Handles OpenExports.Click
        Process.Start("explorer.exe", ExportDirectory)
    End Sub
End Class
