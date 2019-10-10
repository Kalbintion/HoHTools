Imports System.ComponentModel

Public Class frmSettingsEditor
    Private lastFile As String = Nothing
    Private lastFileS As String = Nothing
    Private dgvSettings As BindingList(Of Wrapper)

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        If Not lastFile Is Nothing Then ofd.InitialDirectory = lastFile

        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            lastFile = ofd.FileName
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(ofd.FileName)
            Dim contents As String = sr.ReadToEnd()
            updateDGV(contents)
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Not lastFileS Is Nothing Then sfd.InitialDirectory = lastFileS

        If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            lastFile = sfd.FileName
            Dim contents As String = ""
            For Each itm As Wrapper In dgvSettings
                contents &= itm.ToSaveString() & vbCrLf
            Next

            System.IO.File.WriteAllText(sfd.FileName, contents)
        End If
    End Sub

    Private Sub updateDGV(contents As String)
        dgv.DataSource = Nothing

        dgvSettings = New BindingList(Of Wrapper)

        Dim lines() As String = contents.Split(vbCrLf.ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
        System.Array.Sort(lines)

        For Each line As String In lines
            If line = "" Then Continue For
            Dim parts() As String = line.Split(" ".ToCharArray(), 2)
            If parts.Length <> 2 Then Continue For

            Dim lAdd As New Wrapper(parts(0), parts(1))
            dgvSettings.Add(lAdd)
        Next

        dgv.DataSource = dgvSettings

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoSize = True
    End Sub

    Private Class Wrapper
        Public Sub New(ByVal name As String, ByVal value As String)
            _name = name
            _value = value
        End Sub

        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Private _value As String
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(value As String)
                _value = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Name() & " : " & Value()
        End Function

        Public Function ToSaveString() As String
            Return Name() & " " & Value()
        End Function
    End Class

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        dgvSettings.Add(New Wrapper("", ""))
    End Sub

    Private Sub frmSettingsEditor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class