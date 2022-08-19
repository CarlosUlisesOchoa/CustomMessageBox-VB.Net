Public MustInherit Class CustomInputDate

    Public Shared Function Show(text As String) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text)
            result = msgForm.ShowDialog()
        End Using
        Return result
    End Function

    Public Shared Function Show(text As String, caption As String) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption)
            result = msgForm.ShowDialog()
        End Using
        Return result
    End Function

    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption, buttons)
            result = msgForm.ShowDialog()
        End Using
        Return result
    End Function

    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption, buttons, icon)
            result = msgForm.ShowDialog()
        End Using
        Return result
    End Function

    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As Date

        Dim res As Date = Nothing

        Using form = New InputDateForm(text, caption, buttons, icon, defaultButton)
            Dim result = form.ShowDialog()
            If result = DialogResult.OK Then
                res = form.DatePickerValue
            End If
        End Using

        Return res

    End Function

    '-> IWin32Window Owner
    '   Displays a message box in front of the specified object And with the other specified parameters.
    '   An implementation of IWin32Window that will own the modal dialog box.*/
    Public Shared Function Show(owner As IWin32Window, text As String) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text)
            result = msgForm.ShowDialog(owner)
        End Using
        Return result
    End Function

    Public Shared Function Show(owner As IWin32Window, text As String, caption As String) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption)
            result = msgForm.ShowDialog(owner)
        End Using
        Return result
    End Function

    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption, buttons)
            result = msgForm.ShowDialog(owner)
        End Using
        Return result
    End Function

    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption, buttons, icon)
            result = msgForm.ShowDialog(owner)
        End Using
        Return result
    End Function

    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim result As DialogResult
        Using msgForm = New InputDateForm(text, caption, buttons, icon, defaultButton)
            result = msgForm.ShowDialog(owner)
        End Using
        Return result
    End Function
End Class
