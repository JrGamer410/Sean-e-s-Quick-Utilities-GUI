Imports System.IO
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Win32

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem.ToString = "All Unrestrict" Then
            Dim result As DialogResult = MsgBox("This tool will attempt to unrestrict (almost) everything. Are you sure you still want to continue?", 4 + 32, "Notice")
            If result = DialogResult.Yes Then
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRun", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoViewContextMenu", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\System", "DisableCMD", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoControlPanel", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDesktop", "0", RegistryValueKind.DWord)
                Catch ex As Exception
                    MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
                End Try
            End If
        ElseIf ListBox1.SelectedItem.ToString = "Logon Message Changer" Then
            LMC.Show()
        ElseIf ListBox1.SelectedItem.ToString = "Manage UAC" Then
            Dim osVersion As Version = Environment.OSVersion.Version
            If osVersion.Major = 5 AndAlso osVersion.Minor = 1 Then
                ' Your Windows XP-specific code here
                MsgBox("Your operating system doesn't support User Account Control.", 0 + 16, "Unsupported Utility")
            ElseIf osVersion.Major = 4 AndAlso osVersion.Minor = 10 Then
                ' Your Windows 98-specific code here
                MsgBox("Your operating system doesn't support User Account Control.", 0 + 16, "Unsupported Utility")
            Else
                Dim registryKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"
                Dim valueName As String = "EnableLUA"

                ' Read the registry value
                Dim enableLUA As Integer = ReadRegistryValue(registryKeyPath, valueName)
                If enableLUA = "1" Then
                    Dim UACresult As DialogResult = MsgBox("UAC is currently enabled.
Would you like to disable it?", 4 + 32, "Manage UAC")
                    If UACresult = DialogResult.Yes Then
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", "0", RegistryValueKind.DWord)
                    End If
                ElseIf enableLUA = "0" Then
                    Dim UACresult2 As DialogResult = MsgBox("UAC is currently disabled.
Would you like to enable it?", 4 + 32, "Manage UAC")
                    If UACresult2 = DialogResult.Yes Then
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", "1", RegistryValueKind.DWord)
                    End If
                End If



            End If
        ElseIf ListBox1.SelectedItem.ToString = "File Downloader" Then
            FileDownloader.Show()
        ElseIf ListBox1.SelectedItem.ToString = "Basic File Tools" Then
            BasicFileTools.Show()
        ElseIf ListBox1.SelectedItem.ToString = "Open a program or file" Then
            Dim ToOpen As String = InputBox("Enter the program or file to open.", "Open a program or file")
            If ToOpen = "" Then
            Else
                Process.Start(ToOpen)
            End If
        ElseIf ListBox1.SelectedItem.ToString = "Mass User Creator" Then
            MassUserCreator.Show()
        ElseIf ListBox1.SelectedItem.ToString = "Math Converters" Then
            MathConverters.Show()
        ElseIf ListBox1.SelectedItem.ToString = "Mass App Copier" Then
            Dim AppCount As String = InputBox("How many copies would you like to make?", "Mass App Copier")
            If AppCount = "" Or AppCount < 1 Then
            Else
                Dim current_app_count As Integer = 0
                While current_app_count < AppCount + 1
                    Dim path As String = "File" & current_app_count & ".exe"
                    System.IO.File.Copy("Sean-e's Quick Utilities GUI.exe", path)
                    current_app_count = current_app_count + 1
                End While
            End If
        ElseIf ListBox1.SelectedItem.ToString = "Restart Explorer" Then
            Shell("cmd /c taskkill /f /im explorer.exe")
            System.Threading.Thread.Sleep("1000")
            Process.Start("explorer")
        ElseIf ListBox1.SelectedItem.ToString = "What is my IP?" Then
            Dim request As HttpWebRequest = WebRequest.Create("https://httpbin.org/ip")
            Using response As WebResponse = request.GetResponse()
                Using dataStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(dataStream)
                        Dim responseFromServer As String = reader.ReadToEnd()
                        Dim ipAddressStart As Integer = responseFromServer.IndexOf(":") + 2
                        Dim ipAddressEnd As Integer = responseFromServer.LastIndexOf("""") - 1

                        Dim publicIPAddress As String = responseFromServer.Substring(ipAddressStart, ipAddressEnd - ipAddressStart + 1)

                        MsgBox("Your computer's public IP address is: " & publicIPAddress, 0 + 64, "Your IP Address")
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Function ReadRegistryValue(keyPath As String, valueName As String) As Integer
        Dim registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey(keyPath)

        If registryKey IsNot Nothing Then
            Dim value As Object = registryKey.GetValue(valueName)
            registryKey.Close()

            If value IsNot Nothing AndAlso Integer.TryParse(value.ToString(), Nothing) Then
                Return Integer.Parse(value.ToString())
            End If
        End If

        ' Return a default value or handle the case when the registry value doesn't exist
        Return -1 ' For example, return -1 when the value doesn't exist
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        About.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class
