Imports Microsoft.Win32
Public Class Form1
    '프로그램 부분
    Dim SteamPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", Nothing)
    Dim GameVersion As String
    Dim ServerVersion As String

    '카스소스 설정
    Dim CSS_SERVER_STEAM As String = "\cstrike\steam.inf"
    Dim CSS_Arguments As String = "-console -game cstrike -tickrate 66 -port 27015 -maxplayers 24 +map de_dust.bsp"

    '카스글옵 설정
    Dim CSGO_SERVER_STEAM As String = "\csgo\steam.inf"
    Dim CSGO_Arguments As String = "-console -game csgo -usercon +game_type 0 +mapgroup mg_allclassic -tickrate 66 -port 27015 -maxplayers 24 +map de_dust.bsp"

    '외부 프로그램 시작부분
    Private psi As ProcessStartInfo
    Private SteamCMD As Process

    Private Delegate Sub InvokeWithString(ByVal text As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOutPut.AppendText("소스게임 자동 업데이터에 오신것을 환영합니다." & vbNewLine)
        txtOutPut.AppendText("......" & vbNewLine)
        txtOutPut.AppendText("......" & vbNewLine)
        If My.Settings.SteamPath = "" Then
            '설정 SteamPath가 비어있을떄
            txtOutPut.AppendText("[알림] steam.inf경로를 찾아주세요." & vbNewLine)
        Else
            '비어있지않을때
            txtSteamPath.Text = My.Settings.SteamPath
            txtOutPut.AppendText("[알림] steam.inf경로를 성공적으로 불러왔습니다." & vbNewLine)
        End If

        If My.Settings.SrcdsPath = "" Then
            '설정 SrcdsPath가 비어있을떄
            txtOutPut.AppendText("[알림] Srcds경로를 찾아주세요." & vbNewLine)
        Else
            '비어있지않을때
            txtSrcdsPath.Text = My.Settings.SrcdsPath
            txtOutPut.AppendText("[알림] Srcds경로를 성공적으로 불러왔습니다." & vbNewLine)
        End If

        If My.Settings.SteamCMDPath = "" Then
            '설정 SteamCMDPath가 비어있을떄
            txtOutPut.AppendText("[알림] SteamCMD경로를 찾아주세요." & vbNewLine)
        Else
            '비어있지않을때
            txtSteamCMDPath.Text = My.Settings.SteamCMDPath
            txtOutPut.AppendText("[알림] SteamCMD경로를 성공적으로 불러왔습니다." & vbNewLine)
        End If

        '콤보박스를 컨트롤한다
        ComboGame.SelectedIndex = My.Settings.SelectedGame

        If My.Settings.SelectedGame = 0 Then
            '설정 SelectedGame 이 0일떄
            txtOutPut.AppendText("[알림] 게임을 선택해주세요." & vbNewLine)
        Else
            '0이 아닐떄
            txtOutPut.AppendText("[알림] 게임을 성공적으로 불러왔습니다." & vbNewLine)
        End If

        '업데이트 주기를 불러온다.
        txtUpdateTime.Text = My.Settings.UpdateTime

        '서버 명령어를 불러온다.
        txtArguments.Text = My.Settings.ServerArguments

        '스크롤을 내린다.
        txtOutPut.ScrollToCaret()
    End Sub

    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        If btnStartStop.Text = "시작" Then
            '시작버튼의 텍스트가 "시작" 일떄
            ServerStart()
        Else
            '시작버튼의 텍스트가 "시작" 이 아닐떄
            ServerExit()
        End If
    End Sub

    Private Sub ServerStart()
        btnStartStop.Text = "종료"

        txtOutPut.AppendText("-------------------------------------" & vbNewLine)
        txtOutPut.AppendText("서버를 시작합니다." & vbNewLine)

        '업데이트 체크 타이머를 시작해준다.
        tmrUpdateCheck.Start()

        'srcds를 실행하여 서버를켜준다.
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = txtSrcdsPath.Text
        startInfo.Arguments = txtArguments.Text
        Process.Start(startInfo)
    End Sub

    Private Sub ServerExit()
        btnStartStop.Text = "시작"

        txtOutPut.AppendText("-------------------------------------" & vbNewLine)
        txtOutPut.AppendText("서버를 종료합니다." & vbNewLine)

        '업데이트 체크 타이머를 멈춘다.
        tmrUpdateCheck.Stop()

        'srcds 가 켜져있다면 꺼준다.
        Dim SrcdsProcess() As Process = System.Diagnostics.Process.GetProcessesByName("srcds")
        For Each SrcdsKill As Process In SrcdsProcess
            SrcdsKill.Kill()
        Next
    End Sub

    Private Sub tmrUpdateCheck_Tick(sender As Object, e As EventArgs) Handles tmrUpdateCheck.Tick
        'Srcds 작동중지 감지부분
        For Each proc As Process In System.Diagnostics.Process.GetProcesses
            If proc.ProcessName = "srcds" Then
                If proc.Responding = False Then
                    txtOutPut.AppendText("Srcds가 작동중지가 감지되었습니다. 서버를 재시작 합니다." & vbNewLine)
                    proc.Kill()

                    ServerStart()
                    Exit Sub
                End If
            End If
        Next

        'Srcds 따로 종료되었나 감지부분
        Dim p() As Process
        p = Process.GetProcessesByName("srcds")
        If Not p.Count > 0 Then
            txtOutPut.AppendText("Srcds가 종료되어있습니다. 종료버튼을 누릅니다." & vbNewLine)
            ServerExit()
            Exit Sub
        End If

        '버전체크 부분
        If ComboGame.SelectedIndex = 1 Then
            FindGameVersion(My.Settings.SteamPath, 0)
            FindServerVersion(My.Settings.ServerPath + CSS_SERVER_STEAM, 0)
        ElseIf ComboGame.SelectedIndex = 2 Then
            FindGameVersion(My.Settings.SteamPath, 0)
            FindServerVersion(My.Settings.ServerPath + CSGO_SERVER_STEAM, 0)
        End If

        If Not GameVersion = ServerVersion Then
            '게임버전과 서버버전이 일치하지 않을떄
            ServerExit()

            txtOutPut.AppendText("-------------------------------------" & vbNewLine)
            txtOutPut.AppendText("게임의 최신버전을 발견하였습니다. 업데이트를 시작합니다." & vbNewLine)
            txtOutPut.AppendText("[업데이트] SteamCMD를 실행합니다." & vbNewLine)
            txtOutPut.AppendText("-------------------------------------" & vbNewLine)

            'SteamCMD를 킨다.
            psi = New ProcessStartInfo
            Dim systemencoding As System.Text.Encoding =
                System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)
            With psi
                .FileName = txtSteamCMDPath.Text
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            SteamCMD = New Process With {.StartInfo = psi, .EnableRaisingEvents = True}
            AddHandler SteamCMD.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler SteamCMD.OutputDataReceived, AddressOf Async_Data_Received

            SteamCMD.Start()

            SteamCMD.BeginOutputReadLine()
            SteamCMD.BeginErrorReadLine()

            'SteamCMD 명령어 전송부분.
            SteamCMD.StandardInput.WriteLine("@ShutdownOnFailedCommand 1")
            SteamCMD.StandardInput.WriteLine("@NoPromptForPassword 1")
            SteamCMD.StandardInput.WriteLine("login anonymous")
            SteamCMD.StandardInput.WriteLine("force_install_dir " & My.Settings.ServerPath)
            If ComboGame.SelectedIndex = 1 Then
                '카솟일경우 232330 을 사용
                SteamCMD.StandardInput.WriteLine("app_update 232330 validate")
            ElseIf ComboGame.SelectedIndex = 2 Then
                '글옵일경우 740 을 사용
                SteamCMD.StandardInput.WriteLine("app_update 740 validate")
            End If
            SteamCMD.StandardInput.WriteLine("quit")
        End If
    End Sub

    Private Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Me.Invoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
    End Sub

    Private Sub Sync_Output(ByVal text As String)
        txtOutPut.AppendText(text & vbNewLine)
        '카솟일경우
        If ComboGame.SelectedIndex = 1 Then
            'text 의 메세지가 아래와 같은지 체크하여 다운로드가 끝났는지 체크
            If text = "Success! App '232330' fully installed." Then
                txtOutPut.AppendText("-------------------------------------" & vbNewLine)
                txtOutPut.AppendText("[업데이트] 업데이트를 완료하였습니다." & vbNewLine)
                txtOutPut.AppendText("[알림] 서버를 실행합니다." & vbNewLine)

                '버전을 새로 찾아주고
                FindGameVersion(My.Settings.SteamPath, 0)
                FindServerVersion(My.Settings.ServerPath + CSS_SERVER_STEAM, 0)

                '서버 시작
                ServerStart()
            End If
            '글옵일경우
        ElseIf ComboGame.SelectedIndex = 2 Then
            'text 의 메세지가 아래와 같은지 체크하여 다운로드가 끝났는지 체크
            If text = "Success! App '740' fully installed." Then
                txtOutPut.AppendText("-------------------------------------" & vbNewLine)
                txtOutPut.AppendText("[업데이트] 업데이트를 완료하였습니다." & vbNewLine)
                txtOutPut.AppendText("[알림] 서버를 실행합니다." & vbNewLine)

                '버전을 새로 찾아주고
                FindGameVersion(My.Settings.SteamPath, 2)
                FindServerVersion(My.Settings.ServerPath + CSGO_SERVER_STEAM, 2)

                '서버 시작
                ServerStart()
            End If
        End If
        txtOutPut.ScrollToCaret()
    End Sub

    Private Sub ComboGame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboGame.SelectedIndexChanged
        If ComboGame.SelectedIndex = 0 Then
            btnStartStop.Enabled = False
            txtArguments.Enabled = False
            txtArguments.Text = ""
        Else
            btnStartStop.Enabled = True
            txtArguments.Enabled = True
        End If

        '카솟일경우
        If ComboGame.SelectedIndex = 1 Then
            If txtSteamPath.Text = "" Then
                txtOutPut.AppendText("[알림] steam.inf경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            ElseIf txtSrcdsPath.Text = "" Then
                txtOutPut.AppendText("[알림] Srcds경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            ElseIf txtSteamCMDPath.Text = "" Then
                txtOutPut.AppendText("[알림] SteamCMD경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(My.Settings.SteamPath) Then
                txtOutPut.AppendText("[오류] 게임폴더의 steam.inf 를 찾을 수 없습니다." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(My.Settings.ServerPath + CSS_SERVER_STEAM) Then
                txtOutPut.AppendText("[오류] 서버폴더의 steam.inf 를 찾을 수 없습니다." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            '버전을 찾고
            FindGameVersion(My.Settings.SteamPath, 0)
            FindServerVersion(My.Settings.ServerPath + CSS_SERVER_STEAM, 0)
            txtArguments.Text = CSS_Arguments
            '선택한 인덱스가 0이나 2가 아닐경우 설정에 CSS_Arguments를 저장한다.
            If My.Settings.SelectedGame = 0 Or My.Settings.SelectedGame = 2 Then
                My.Settings.ServerArguments = CSS_Arguments
            End If

            '글옵일경우
        ElseIf ComboGame.SelectedIndex = 2 Then
            If txtSteamPath.Text = "" Then
                txtOutPut.AppendText("[알림] steam.inf경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            ElseIf txtSrcdsPath.Text = "" Then
                txtOutPut.AppendText("[알림] Srcds경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            ElseIf txtSteamCMDPath.Text = "" Then
                txtOutPut.AppendText("[알림] SteamCMD경로를 찾아주세요." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(My.Settings.SteamPath) Then
                txtOutPut.AppendText("[오류] 게임폴더의 steam.inf 를 찾을 수 없습니다." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(My.Settings.ServerPath + CSGO_SERVER_STEAM) Then
                txtOutPut.AppendText("[오류] 서버폴더의 steam.inf 를 찾을 수 없습니다." & vbNewLine)
                ComboGame.SelectedIndex = 0
                Exit Sub
            End If

            '버전을 찾고
            FindGameVersion(My.Settings.SteamPath, 2)
            FindServerVersion(My.Settings.ServerPath + CSGO_SERVER_STEAM, 2)
            txtArguments.Text = CSGO_Arguments
            '선택한 인덱스가 0이나 1이 아닐경우 설정에 CSGO_Arguments를 저장한다.
            If My.Settings.SelectedGame = 0 Or My.Settings.SelectedGame = 1 Then
                My.Settings.ServerArguments = CSGO_Arguments
            End If
        End If

            '설정에 콤보박스의 선택인덱스를 저장한다.
            My.Settings.SelectedGame = ComboGame.SelectedIndex
    End Sub

    Private Sub btnFindSteamCMD_Click(sender As Object, e As EventArgs) Handles btnFindSteamCMD.Click
        Dim result As DialogResult = ofdSteamCmd.ShowDialog()

        '파일다이로그에서 OK를 눌렀을경우
        If result = Windows.Forms.DialogResult.OK Then
            txtSteamCMDPath.Text = ofdSteamCmd.FileName
            My.Settings.SteamCMDPath = ofdSteamCmd.FileName
        End If
    End Sub

    Private Sub btnFindSrcdsPath_Click(sender As Object, e As EventArgs) Handles btnFindSrcdsPath.Click
        Dim result As DialogResult = ofdSrcds.ShowDialog()

        '파일다이로그에서 OK를 눌렀을경우
        If result = Windows.Forms.DialogResult.OK Then
            txtSrcdsPath.Text = ofdSrcds.FileName
            My.Settings.SrcdsPath = ofdSrcds.FileName

            'ServerPath 설정에 \srcds.exe를 제거하고 저장한다.
            My.Settings.ServerPath = Replace(ofdSrcds.FileName, "\srcds.exe", "")
        End If
    End Sub

    Private Sub btnFindSteamPath_Click(sender As Object, e As EventArgs) Handles btnFindSteamPath.Click
        Dim result As DialogResult = ofdSteam.ShowDialog()

        ofdSteam.InitialDirectory = SteamPath
        '파일다이로그에서 OK를 눌렀을경우
        If result = Windows.Forms.DialogResult.OK Then
            'SteamPath 설정에 \steam.exe를 제거하고 저장한다.
            My.Settings.SteamPath = ofdSteam.FileName

            txtSteamPath.Text = My.Settings.SteamPath
        End If
    End Sub

    Public Function FindGameVersion(ByVal File_Path As String, LineNum As Integer)
        GameVersion = ReadALine(File_Path, LineNum)
        txtOutPut.AppendText("-------------------------------------" & vbNewLine)
        txtOutPut.AppendText("선택 게임 : " & ComboGame.SelectedItem.ToString & vbNewLine)
        txtOutPut.AppendText("현재 게임 버전 : " & Replace(GameVersion, "Patch", "Game") & vbNewLine)

        txtOutPut.ScrollToCaret()

        Return "Cannot Find File"
    End Function

    Public Function FindServerVersion(ByVal File_Path As String, LineNum As Integer)
        ServerVersion = ReadALine(File_Path, LineNum)
        txtOutPut.AppendText("현재 서버 버전 : " & Replace(ServerVersion, "Patch", "Game") & vbNewLine)
        txtOutPut.AppendText("-------------------------------------" & vbNewLine)

        txtOutPut.ScrollToCaret()

        Return "Cannot Find File"
    End Function

    Public Function ReadALine(ByVal File_Path As String, LineNum As Integer) As String
        Dim tmp() As String = Split(My.Computer.FileSystem.ReadAllText(File_Path), vbNewLine)
        If LineNum < tmp.Count Then Return tmp(LineNum)

        Return "No Such Line"
    End Function

    Private Sub txtUpdateTime_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUpdateTime.KeyUp
        '키를 땔때마다 바뀐값을 저장
        Dim Interval As Integer = Convert.ToInt32(txtUpdateTime.Text)
        My.Settings.UpdateTime = Interval
        tmrUpdateCheck.Interval = Interval
    End Sub

    Private Sub txtArguments_KeyUp(sender As Object, e As KeyEventArgs) Handles txtArguments.KeyUp
        '키를 땔때마다 바뀐값을 저장
        My.Settings.ServerArguments = txtArguments.Text
    End Sub
End Class
