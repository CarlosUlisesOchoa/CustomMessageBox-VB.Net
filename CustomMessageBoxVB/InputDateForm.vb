Imports System.Runtime.InteropServices

Public Class InputDateForm

    'Fields
    Private _primaryColor As Color = Color.CornflowerBlue
    Private _borderSize As Integer = 2
    Private _datePickerValue As Date

    'Properties
    Public Property PrimaryColor As Color
        Get
            Return _primaryColor
        End Get
        Set(value As Color)
            _primaryColor = value
            Me.BackColor = PrimaryColor 'Form Border Color
            Me.panelTitleBar.BackColor = PrimaryColor 'Title Bar Back Color
        End Set
    End Property
    Public Property DatePickerValue As Date
        Get
            Return _datePickerValue
        End Get
        Set(value As Date)
            _datePickerValue = value
        End Set
    End Property

    'Constructors
    Public Sub New(text As String)
        InitializeComponent()
        InitializeItems()
        Me.PrimaryColor = _primaryColor
        Me.labelMessage.Text = text
        Me.labelCaption.Text = ""
        SetFormSize()
        SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1) 'Set Default Buttons
    End Sub

    Public Sub New(text As String, caption As String)
        InitializeComponent()
        InitializeItems()
        Me.PrimaryColor = _primaryColor
        Me.labelMessage.Text = text
        Me.labelCaption.Text = caption
        SetFormSize()
        SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1) 'Set Default Buttons
    End Sub

    Public Sub New(text As String, caption As String, buttons As MessageBoxButtons)
        InitializeComponent()
        InitializeItems()
        Me.PrimaryColor = _primaryColor
        Me.labelMessage.Text = text
        Me.labelCaption.Text = caption
        SetFormSize()
        SetButtons(buttons, MessageBoxDefaultButton.Button1) 'Set [Default Button 1]
    End Sub

    Public Sub New(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon)
        InitializeComponent()
        InitializeItems()
        Me.PrimaryColor = _primaryColor
        Me.labelMessage.Text = text
        Me.labelCaption.Text = caption
        SetFormSize()
        SetButtons(buttons, MessageBoxDefaultButton.Button1) 'Set [Default Button 1]
        SetIcon(icon)
    End Sub

    Public Sub New(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton)
        InitializeComponent()
        InitializeItems()
        Me.PrimaryColor = _primaryColor
        Me.labelMessage.Text = text & Environment.NewLine
        Me.labelCaption.Text = caption
        SetFormSize()
        SetButtons(buttons, defaultButton)
        SetIcon(icon)
        SetDatePickerLocation()
    End Sub

    '-> Private Methods
    Private Sub InitializeItems()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Padding = New Padding(_borderSize) 'Set border size
        Me.labelMessage.MaximumSize = New Size(550, 0)
        Me.btnClose.DialogResult = DialogResult.Cancel
        Me.button1.DialogResult = DialogResult.OK
        Me.button1.Visible = False
        Me.button2.Visible = False
        Me.button3.Visible = False
    End Sub

    Private Sub SetFormSize()
        Dim widht As Integer = Me.labelMessage.Width + Me.pictureBoxIcon.Width + Me.panelBody.Padding.Left
        Dim height As Integer = Me.panelTitleBar.Height + Me.labelMessage.Height + Me.panelButtons.Height + Me.panelBody.Padding.Top + Me.panelDatePicker.Height
        Me.Size = New Size(widht, height)
    End Sub

    Private Sub SetDatePickerLocation()

        Dim xCenter As Integer = (Me.panelDatePicker.Width - DatePicker.Width) / 2
        Dim yCenter As Integer = (Me.panelDatePicker.Height - 25) / 2

        DatePicker.Location = New Point(xCenter, yCenter)

    End Sub

    Private Sub SetButtons(buttons As MessageBoxButtons, defaultButton As MessageBoxDefaultButton)
        Dim xCenter As Integer = (Me.panelButtons.Width - button1.Width) / 2
        Dim yCenter As Integer = (Me.panelButtons.Height - button1.Height) / 2

        Select Case buttons
            Case MessageBoxButtons.OK
                'OK Button
                button1.Visible = True
                button1.Location = New Point(xCenter, yCenter)
                button1.Text = "Ok"
                button1.DialogResult = DialogResult.OK 'Set DialogResult
                button1.Tag = "return" 'Indicates if this button will return DatePicker value

                'Set Default Button
                SetDefaultButton(defaultButton)

            Case MessageBoxButtons.OKCancel
                'OK Button
                button1.Visible = True
                button1.Location = New Point(xCenter - (button1.Width / 2) - 5, yCenter)
                button1.Text = "Ok"
                button1.DialogResult = DialogResult.OK 'Set DialogResult
                button1.Tag = "return" 'Indicates if this button will return DatePicker value

                'Cancel Button
                button2.Visible = True
                button2.Location = New Point(xCenter + (button2.Width / 2) + 5, yCenter)
                button2.Text = "Cancel"
                button2.DialogResult = DialogResult.Cancel 'Set DialogResult
                button2.BackColor = Color.DimGray

                'Set Default Button
                If defaultButton <> MessageBoxDefaultButton.Button3 Then
                    SetDefaultButton(defaultButton)
                Else
                    SetDefaultButton(MessageBoxDefaultButton.Button1)
                End If

            Case MessageBoxButtons.RetryCancel
                'Retry Button
                button1.Visible = True
                button1.Location = New Point(xCenter - (button1.Width / 2) - 5, yCenter)
                button1.Text = "Retry"
                button1.DialogResult = DialogResult.Retry 'Set DialogResult

                'Cancel Button
                button2.Visible = True
                button2.Location = New Point(xCenter + (button2.Width / 2) + 5, yCenter)
                button2.Text = "Cancel"
                button2.DialogResult = DialogResult.Cancel 'Set DialogResult
                button2.BackColor = Color.DimGray

                'Set Default Button
                If defaultButton <> MessageBoxDefaultButton.Button3 Then
                    SetDefaultButton(defaultButton)
                Else
                    SetDefaultButton(MessageBoxDefaultButton.Button1)
                End If

            Case MessageBoxButtons.YesNo
                'Yes Button
                button1.Visible = True
                button1.Location = New Point(xCenter - (button1.Width / 2) - 5, yCenter)
                button1.Text = "Yes"
                button1.DialogResult = DialogResult.Yes 'Set DialogResult
                button1.Tag = "return" 'Indicates if this button will return DatePicker value

                'No Button
                button2.Visible = True
                button2.Location = New Point(xCenter + (button2.Width / 2) + 5, yCenter)
                button2.Text = "No"
                button2.DialogResult = DialogResult.No 'Set DialogResult
                button2.BackColor = Color.IndianRed

                'Set Default Button
                If defaultButton <> MessageBoxDefaultButton.Button3 Then
                    SetDefaultButton(defaultButton)
                Else
                    SetDefaultButton(MessageBoxDefaultButton.Button1)
                End If

            Case MessageBoxButtons.YesNoCancel
                'Yes Button
                button1.Visible = True
                button1.Location = New Point(xCenter - button1.Width - 5, yCenter)
                button1.Text = "Yes"
                button1.DialogResult = DialogResult.Yes 'Set DialogResult
                button1.Tag = "return" 'Indicates if this button will return DatePicker value

                'No Button
                button2.Visible = True
                button2.Location = New Point(xCenter, yCenter)
                button2.Text = "No"
                button2.DialogResult = DialogResult.No 'Set DialogResult
                button2.BackColor = Color.IndianRed

                'Cancel Button
                button3.Visible = True
                button3.Location = New Point(xCenter + button2.Width + 5, yCenter)
                button3.Text = "Cancel"
                button3.DialogResult = DialogResult.Cancel 'Set DialogResult
                button3.BackColor = Color.DimGray

                'Set Default Button
                SetDefaultButton(defaultButton)

            Case MessageBoxButtons.AbortRetryIgnore
                'Abort Button
                button1.Visible = True
                button1.Location = New Point(xCenter - button1.Width - 5, yCenter)
                button1.Text = "Abort"
                button1.DialogResult = DialogResult.Abort 'Set DialogResult
                button1.BackColor = Color.Goldenrod

                'Retry Button
                button2.Visible = True
                button2.Location = New Point(xCenter, yCenter)
                button2.Text = "Retry"
                button2.DialogResult = DialogResult.Retry 'Set DialogResult

                'Ignore Button
                button3.Visible = True
                button3.Location = New Point(xCenter + button2.Width + 5, yCenter)
                button3.Text = "Ignore"
                button3.DialogResult = DialogResult.Ignore 'Set DialogResult
                button3.BackColor = Color.IndianRed

                'Set Default Button
                SetDefaultButton(defaultButton)
        End Select
    End Sub

    Private Sub SetDefaultButton(defaultButton As MessageBoxDefaultButton)
        Select Case defaultButton
            Case MessageBoxDefaultButton.Button1 'Focus button 1
                button1.Select()
                button1.ForeColor = Color.White
                button1.Font = New Font(button1.Font, FontStyle.Underline)

            Case MessageBoxDefaultButton.Button2 'Focus button 2
                button2.Select()
                button2.ForeColor = Color.White
                button2.Font = New Font(button2.Font, FontStyle.Underline)

            Case MessageBoxDefaultButton.Button3 'Focus button 3
                button3.Select()
                button3.ForeColor = Color.White
                button3.Font = New Font(button3.Font, FontStyle.Underline)
        End Select
    End Sub

    Private Sub SetIcon(icon As MessageBoxIcon)
        Select Case icon
            Case MessageBoxIcon.Error
                Me.pictureBoxIcon.Image = My.Resources._error
                PrimaryColor = Color.FromArgb(224, 79, 95)
                Me.btnClose.FlatAppearance.MouseOverBackColor = Color.Crimson

            Case MessageBoxIcon.Information
                Me.pictureBoxIcon.Image = My.Resources.information
                PrimaryColor = Color.FromArgb(38, 191, 166)

            Case MessageBoxIcon.Question
                Me.pictureBoxIcon.Image = My.Resources.question
                PrimaryColor = Color.FromArgb(10, 119, 232)

            Case MessageBoxIcon.Exclamation
                Me.pictureBoxIcon.Image = My.Resources.exclamation
                PrimaryColor = Color.FromArgb(255, 140, 0)

            Case MessageBoxIcon.None
                Me.pictureBoxIcon.Image = My.Resources.chat
                PrimaryColor = Color.CornflowerBlue
        End Select
    End Sub

    '-> Events Methods
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles button3.Click, button2.Click, button1.Click

        If DirectCast(sender, Button).Tag = "return" Then

            Me.DatePickerValue = DatePicker.Value.Date

        End If

    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DatePickerValue = DatePicker.Value.Date
        Me.Close()
    End Sub

#Region "-> Drag Form"
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As System.IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    Private Sub panelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles panelTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub FormInputDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region
End Class