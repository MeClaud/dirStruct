Imports System.IO
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainWindowForm
    Private ExportDirectory As String = String.Format("{0}\Exports\", Environment.CurrentDirectory)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Add("name", "Dateiname")
        DataGridView1.Columns.Add("type", "Dateiart")

        ChoosePath()
        DataGridView1.AutoResizeColumns()
    End Sub
    Private Sub LoadContent()
        For Each foundFolder In My.Computer.FileSystem.GetDirectories(PathBox.Text)
            Dim foundFolderName As String = My.Computer.FileSystem.GetName(foundFolder)
            DataGridView1.Rows.Add(foundFolderName, "DIR")
        Next
        For Each foundFile In My.Computer.FileSystem.GetFiles(PathBox.Text)
            Dim foundFileName = My.Computer.FileSystem.GetName(foundFile)
            DataGridView1.Rows.Add(foundFileName, "FILE")
        Next
    End Sub
    Private Sub ClearContent()
        DataGridView1.Rows.Clear()
    End Sub
    Private Sub ChoosePath()
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = ""

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PathBox.Text = dialog.SelectedPath
            ClearContent()
            LoadContent()
        Else
            PathBox.Text = ""
        End If
    End Sub
    Private Sub ExportData()
        Dim expFile As System.IO.StreamWriter
        Dim expFilePath As String = ExportDirectory & Replace(Replace(Replace(DateTime.Now, ":", ""), ".", ""), " ", "_") & ".txt"

        If Not My.Computer.FileSystem.DirectoryExists(ExportDirectory) Then
            Directory.CreateDirectory(ExportDirectory)
        End If

        File.Create(expFilePath).Close()

        expFile = My.Computer.FileSystem.OpenTextFileWriter(expFilePath, True)

        For i As Integer = 0 To (DataGridView1.Rows.Count - 2)
            expFile.WriteLine(DataGridView1.Rows(i).Cells(0).Value.ToString)
        Next i

        expFile.Close()

        If cbOpenFileAfterExport.Checked = True Then
            Process.Start("notepad.exe", expFilePath)
        End If
    End Sub
    ' ---------------------------------------------------------------
    '                       ACTIONS
    ' ---------------------------------------------------------------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ChoosePath()
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        ExportData()
    End Sub

    Private Sub OpenExports_Click(sender As Object, e As EventArgs) Handles OpenExports.Click
        Process.Start("explorer.exe", ExportDirectory)
    End Sub

    Private Sub BTNRefresh_Click(sender As Object, e As EventArgs) Handles BTNRefresh.Click
        ClearContent()
        LoadContent()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub AlleZeilenLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlleZeilenLöschenToolStripMenuItem.Click
        ClearContent()
    End Sub

    Private Sub VerzeichnisAuswählenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerzeichnisAuswählenToolStripMenuItem.Click
        ChoosePath()
    End Sub

    Private Sub AktualisierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AktualisierenToolStripMenuItem.Click
        ClearContent()
        LoadContent()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        ExportData()
    End Sub

    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        MsgBox("TODO...")
    End Sub
End Class
