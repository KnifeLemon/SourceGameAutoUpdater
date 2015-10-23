<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrUpdateCheck = New System.Windows.Forms.Timer(Me.components)
        Me.ofdSteamCmd = New System.Windows.Forms.OpenFileDialog()
        Me.ofdSrcds = New System.Windows.Forms.OpenFileDialog()
        Me.ChromeThemeContainer1 = New SourceGameAutoUpdater.ChromeThemeContainer()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFindSteamPath = New SourceGameAutoUpdater.ChromeButton()
        Me.txtSteamPath = New System.Windows.Forms.TextBox()
        Me.txtArguments = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUpdateTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFindSrcdsPath = New SourceGameAutoUpdater.ChromeButton()
        Me.txtSrcdsPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindSteamCMD = New SourceGameAutoUpdater.ChromeButton()
        Me.txtSteamCMDPath = New System.Windows.Forms.TextBox()
        Me.ComboGame = New System.Windows.Forms.ComboBox()
        Me.ChromeSeparator2 = New SourceGameAutoUpdater.ChromeSeparator()
        Me.PanelBox1 = New SourceGameAutoUpdater.PanelBox()
        Me.txtOutPut = New System.Windows.Forms.RichTextBox()
        Me.btnStartStop = New SourceGameAutoUpdater.ChromeButton()
        Me.ChromeSeparator1 = New SourceGameAutoUpdater.ChromeSeparator()
        Me.ofdSteam = New System.Windows.Forms.OpenFileDialog()
        Me.ChromeThemeContainer1.SuspendLayout()
        Me.PanelBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrUpdateCheck
        '
        Me.tmrUpdateCheck.Interval = 5000
        '
        'ofdSteamCmd
        '
        Me.ofdSteamCmd.FileName = "steamcmd.exe"
        Me.ofdSteamCmd.Filter = "SteamCMD|steamcmd.exe"
        Me.ofdSteamCmd.Title = "SteamCMD를 선택해주세요."
        '
        'ofdSrcds
        '
        Me.ofdSrcds.FileName = "srcds.exe"
        Me.ofdSrcds.Filter = "Srcds|srcds.exe"
        Me.ofdSrcds.Title = "SRCDS를 선택해주세요."
        '
        'ChromeThemeContainer1
        '
        Me.ChromeThemeContainer1.BackColor = System.Drawing.Color.White
        Me.ChromeThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChromeThemeContainer1.Controls.Add(Me.Label6)
        Me.ChromeThemeContainer1.Controls.Add(Me.btnFindSteamPath)
        Me.ChromeThemeContainer1.Controls.Add(Me.txtSteamPath)
        Me.ChromeThemeContainer1.Controls.Add(Me.txtArguments)
        Me.ChromeThemeContainer1.Controls.Add(Me.Label5)
        Me.ChromeThemeContainer1.Controls.Add(Me.Label4)
        Me.ChromeThemeContainer1.Controls.Add(Me.txtUpdateTime)
        Me.ChromeThemeContainer1.Controls.Add(Me.Label3)
        Me.ChromeThemeContainer1.Controls.Add(Me.Label2)
        Me.ChromeThemeContainer1.Controls.Add(Me.btnFindSrcdsPath)
        Me.ChromeThemeContainer1.Controls.Add(Me.txtSrcdsPath)
        Me.ChromeThemeContainer1.Controls.Add(Me.Label1)
        Me.ChromeThemeContainer1.Controls.Add(Me.btnFindSteamCMD)
        Me.ChromeThemeContainer1.Controls.Add(Me.txtSteamCMDPath)
        Me.ChromeThemeContainer1.Controls.Add(Me.ComboGame)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator2)
        Me.ChromeThemeContainer1.Controls.Add(Me.PanelBox1)
        Me.ChromeThemeContainer1.Controls.Add(Me.btnStartStop)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator1)
        Me.ChromeThemeContainer1.Customization = "AAAA/1paWv9ycnL/"
        Me.ChromeThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromeThemeContainer1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChromeThemeContainer1.Image = Nothing
        Me.ChromeThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ChromeThemeContainer1.Movable = True
        Me.ChromeThemeContainer1.Name = "ChromeThemeContainer1"
        Me.ChromeThemeContainer1.NoRounding = False
        Me.ChromeThemeContainer1.Sizable = True
        Me.ChromeThemeContainer1.Size = New System.Drawing.Size(359, 475)
        Me.ChromeThemeContainer1.SmartBounds = True
        Me.ChromeThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.ChromeThemeContainer1.TabIndex = 0
        Me.ChromeThemeContainer1.Text = "소스게임 자동 업데이터"
        Me.ChromeThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.Transparent = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "steam.inf 경로"
        '
        'btnFindSteamPath
        '
        Me.btnFindSteamPath.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.btnFindSteamPath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnFindSteamPath.Image = Nothing
        Me.btnFindSteamPath.Location = New System.Drawing.Point(312, 36)
        Me.btnFindSteamPath.Name = "btnFindSteamPath"
        Me.btnFindSteamPath.NoRounding = False
        Me.btnFindSteamPath.Size = New System.Drawing.Size(33, 23)
        Me.btnFindSteamPath.TabIndex = 16
        Me.btnFindSteamPath.Text = "..."
        Me.btnFindSteamPath.Transparent = False
        '
        'txtSteamPath
        '
        Me.txtSteamPath.BackColor = System.Drawing.Color.White
        Me.txtSteamPath.Location = New System.Drawing.Point(102, 36)
        Me.txtSteamPath.Name = "txtSteamPath"
        Me.txtSteamPath.ReadOnly = True
        Me.txtSteamPath.Size = New System.Drawing.Size(204, 23)
        Me.txtSteamPath.TabIndex = 17
        '
        'txtArguments
        '
        Me.txtArguments.BackColor = System.Drawing.Color.White
        Me.txtArguments.Location = New System.Drawing.Point(10, 440)
        Me.txtArguments.Name = "txtArguments"
        Me.txtArguments.Size = New System.Drawing.Size(230, 23)
        Me.txtArguments.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ms(1000 = 1초)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "업데이트 주기"
        '
        'txtUpdateTime
        '
        Me.txtUpdateTime.BackColor = System.Drawing.Color.White
        Me.txtUpdateTime.Location = New System.Drawing.Point(102, 123)
        Me.txtUpdateTime.Name = "txtUpdateTime"
        Me.txtUpdateTime.Size = New System.Drawing.Size(94, 23)
        Me.txtUpdateTime.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 422)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "서버실행 명령어"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Srcds경로"
        '
        'btnFindSrcdsPath
        '
        Me.btnFindSrcdsPath.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.btnFindSrcdsPath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnFindSrcdsPath.Image = Nothing
        Me.btnFindSrcdsPath.Location = New System.Drawing.Point(312, 65)
        Me.btnFindSrcdsPath.Name = "btnFindSrcdsPath"
        Me.btnFindSrcdsPath.NoRounding = False
        Me.btnFindSrcdsPath.Size = New System.Drawing.Size(33, 23)
        Me.btnFindSrcdsPath.TabIndex = 7
        Me.btnFindSrcdsPath.Text = "..."
        Me.btnFindSrcdsPath.Transparent = False
        '
        'txtSrcdsPath
        '
        Me.txtSrcdsPath.BackColor = System.Drawing.Color.White
        Me.txtSrcdsPath.Location = New System.Drawing.Point(102, 65)
        Me.txtSrcdsPath.Name = "txtSrcdsPath"
        Me.txtSrcdsPath.ReadOnly = True
        Me.txtSrcdsPath.Size = New System.Drawing.Size(204, 23)
        Me.txtSrcdsPath.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "SteamCMD경로"
        '
        'btnFindSteamCMD
        '
        Me.btnFindSteamCMD.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.btnFindSteamCMD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnFindSteamCMD.Image = Nothing
        Me.btnFindSteamCMD.Location = New System.Drawing.Point(312, 94)
        Me.btnFindSteamCMD.Name = "btnFindSteamCMD"
        Me.btnFindSteamCMD.NoRounding = False
        Me.btnFindSteamCMD.Size = New System.Drawing.Size(33, 23)
        Me.btnFindSteamCMD.TabIndex = 1
        Me.btnFindSteamCMD.Text = "..."
        Me.btnFindSteamCMD.Transparent = False
        '
        'txtSteamCMDPath
        '
        Me.txtSteamCMDPath.BackColor = System.Drawing.Color.White
        Me.txtSteamCMDPath.Location = New System.Drawing.Point(102, 94)
        Me.txtSteamCMDPath.Name = "txtSteamCMDPath"
        Me.txtSteamCMDPath.ReadOnly = True
        Me.txtSteamCMDPath.Size = New System.Drawing.Size(204, 23)
        Me.txtSteamCMDPath.TabIndex = 5
        '
        'ComboGame
        '
        Me.ComboGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboGame.FormattingEnabled = True
        Me.ComboGame.Items.AddRange(New Object() {"게임을 선택해주세요.", "Counter-Strike: Source", "Counter-Strike: Global Offensive"})
        Me.ComboGame.Location = New System.Drawing.Point(10, 154)
        Me.ComboGame.Name = "ComboGame"
        Me.ComboGame.Size = New System.Drawing.Size(332, 23)
        Me.ComboGame.TabIndex = 1
        '
        'ChromeSeparator2
        '
        Me.ChromeSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator2.Colors = New SourceGameAutoUpdater.Bloom(-1) {}
        Me.ChromeSeparator2.Customization = ""
        Me.ChromeSeparator2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator2.Image = Nothing
        Me.ChromeSeparator2.Location = New System.Drawing.Point(-5, 184)
        Me.ChromeSeparator2.Name = "ChromeSeparator2"
        Me.ChromeSeparator2.NoRounding = False
        Me.ChromeSeparator2.Size = New System.Drawing.Size(364, 1)
        Me.ChromeSeparator2.TabIndex = 4
        Me.ChromeSeparator2.Text = "ChromeSeparator2"
        Me.ChromeSeparator2.Transparent = False
        '
        'PanelBox1
        '
        Me.PanelBox1.Controls.Add(Me.txtOutPut)
        Me.PanelBox1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.PanelBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PanelBox1.Location = New System.Drawing.Point(10, 193)
        Me.PanelBox1.Name = "PanelBox1"
        Me.PanelBox1.NoRounding = False
        Me.PanelBox1.Size = New System.Drawing.Size(335, 216)
        Me.PanelBox1.TabIndex = 2
        Me.PanelBox1.Text = "PanelBox1"
        '
        'txtOutPut
        '
        Me.txtOutPut.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.txtOutPut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutPut.Location = New System.Drawing.Point(3, 3)
        Me.txtOutPut.Name = "txtOutPut"
        Me.txtOutPut.ReadOnly = True
        Me.txtOutPut.Size = New System.Drawing.Size(329, 207)
        Me.txtOutPut.TabIndex = 0
        Me.txtOutPut.Text = ""
        '
        'btnStartStop
        '
        Me.btnStartStop.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.btnStartStop.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnStartStop.Image = Nothing
        Me.btnStartStop.Location = New System.Drawing.Point(246, 425)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.NoRounding = False
        Me.btnStartStop.Size = New System.Drawing.Size(99, 38)
        Me.btnStartStop.TabIndex = 1
        Me.btnStartStop.Text = "시작"
        Me.btnStartStop.Transparent = False
        '
        'ChromeSeparator1
        '
        Me.ChromeSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator1.Colors = New SourceGameAutoUpdater.Bloom(-1) {}
        Me.ChromeSeparator1.Customization = ""
        Me.ChromeSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator1.Image = Nothing
        Me.ChromeSeparator1.Location = New System.Drawing.Point(-5, 27)
        Me.ChromeSeparator1.Name = "ChromeSeparator1"
        Me.ChromeSeparator1.NoRounding = False
        Me.ChromeSeparator1.Size = New System.Drawing.Size(364, 1)
        Me.ChromeSeparator1.TabIndex = 0
        Me.ChromeSeparator1.Text = "ChromeSeparator1"
        Me.ChromeSeparator1.Transparent = False
        '
        'ofdSteam
        '
        Me.ofdSteam.FileName = "steam.inf"
        Me.ofdSteam.Filter = "steam.inf|steam.inf"
        Me.ofdSteam.Title = "steam.inf를 선택해주세요."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 475)
        Me.Controls.Add(Me.ChromeThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "소스게임 자동 업데이터"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.ResumeLayout(False)
        Me.ChromeThemeContainer1.PerformLayout()
        Me.PanelBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChromeThemeContainer1 As SourceGameAutoUpdater.ChromeThemeContainer
    Friend WithEvents ChromeSeparator1 As SourceGameAutoUpdater.ChromeSeparator
    Friend WithEvents PanelBox1 As SourceGameAutoUpdater.PanelBox
    Friend WithEvents btnStartStop As SourceGameAutoUpdater.ChromeButton
    Friend WithEvents txtOutPut As System.Windows.Forms.RichTextBox
    Friend WithEvents ChromeSeparator2 As SourceGameAutoUpdater.ChromeSeparator
    Friend WithEvents ComboGame As System.Windows.Forms.ComboBox
    Friend WithEvents tmrUpdateCheck As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindSteamCMD As SourceGameAutoUpdater.ChromeButton
    Friend WithEvents txtSteamCMDPath As System.Windows.Forms.TextBox
    Friend WithEvents ofdSteamCmd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFindSrcdsPath As SourceGameAutoUpdater.ChromeButton
    Friend WithEvents txtSrcdsPath As System.Windows.Forms.TextBox
    Friend WithEvents ofdSrcds As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateTime As System.Windows.Forms.TextBox
    Friend WithEvents txtArguments As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFindSteamPath As SourceGameAutoUpdater.ChromeButton
    Friend WithEvents txtSteamPath As System.Windows.Forms.TextBox
    Friend WithEvents ofdSteam As System.Windows.Forms.OpenFileDialog

End Class
