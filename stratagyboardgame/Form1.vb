Public Class Form1
    Dim switch As Boolean = False
    Public kingclicked As Boolean = False
    Dim attackrangex As Integer = 0
    Dim attackrangey As Integer = 0
    Dim redattackrangex As Integer = 0
    Dim redattackrangey As Integer = 0
    Dim attackdifx As Integer = 0
    Dim attackdify As Integer = 0
    Dim changeinx As Integer = 24
    Dim changeiny As Integer = 10
    Dim patternwidth As Integer = 13
    Dim patternheight As Integer = 22
    Dim once As Boolean = False
    Public turn As Integer = 1
    Dim BU As Boolean = False
    Dim mpx As Integer
    Dim mpy As Integer
    Dim go As Boolean = False
    Dim collum As Integer = 0
    Dim row As Integer = 0
    Dim worriorattackrangex As Integer = 0
    Dim worriorattackrangey As Integer = 0
    Dim odd As Integer = 0
    Dim count As Integer = 0
    Dim prevrow As Integer = 0
    Dim prevcollum As Integer = 0
    Public blueattack As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Public redattack As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Public attacktrack As Integer = 0
    Public winner As Integer = 0
    Public selecttrack As Integer = 0
    ' Unit status
    'is the unit dead or alive
    Dim BlueUnitStatus As Boolean() = {True, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim RedUnitStatus As Boolean() = {True, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}

    Dim UnitStatusCout As Integer = 0
    'has a unit preformed a move this turn
    Public BlueUnitDone As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Public RedUnitDone As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    'has the max unit production be reached?
    'Red unit Select
    Public RedSelect As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    'Blue Unit Select
    Public BlueSelect As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    'Blue Unit Health
    Public BlueUnitHealth As Integer() = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
    'Red Unit Health
    Public RedUnitHealth As Integer() = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
    Dim moveflip As Boolean = False
    Dim moves As Integer = 1
    Public good As Boolean = True
    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnEndTurn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndTurn.Click
        'Updates player turn lable
            For j = 0 To 49
            RedUnitDone(j) = False
            BlueUnitDone(j) = False
            RedSelect(j) = False
            BlueSelect(j) = False
            redattack(j) = False
            blueattack(j) = False
            Next
        If turn = 1 Then
            turn = 2
        Else
            turn = 1
        End If
        BU = False
        If moveflip = True Then
            moves += 1
        End If
        If moveflip = True Then
            moveflip = False
        Else
            moveflip = True
        End If
        lblMoveCounter.Text = moves
        My.Computer.Audio.Play(My.Resources._next, AudioPlayMode.WaitToComplete)

    End Sub
    Private Sub World_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles World.Tick
        Label1.Text = collum
        Label3.Text = row

        If turn = 1 Then
            For j = 0 To 49
                If BlueSelect(j) = True Then
                    unitstatusbar.Value = BlueUnitHealth(j) * 10
                End If
            Next
        End If
        If turn = 2 Then
            For j = 0 To 49
                If RedSelect(j) = True Then
                    unitstatusbar.Value = RedUnitHealth(j) * 10
                End If
            Next
        End If

        ' turn updater
        If turn = 1 Then
            lblTurn.Text = " 1 "
        ElseIf turn = 2 Then
            lblTurn.Text = " 2 "
        End If
        'checking to see if blue unit is dead
        For j = 0 To 49
            If BlueUnitHealth(j) <= 0 Then
                BlueUnitStatus(j) = False
            End If
        Next
        'checking to see if red unit is dead
        For j = 0 To 49
            If RedUnitHealth(j) <= 0 Then
                RedUnitStatus(j) = False
            End If
        Next
        For j = 0 To 49
            If BlueUnitDone(j) = True Then
                BlueSelect(j) = False
            End If
            If RedUnitDone(j) = True Then
                RedSelect(j) = False
            End If
        Next
        attackdifx = attackrangex - mpx
        attackdify = attackrangey - mpy

        If turn = 1 Then
            For j = 0 To 49
                If redattack(j) = True Then
                    For h = 0 To 49
                        If BlueSelect(h) = True Then
                            attacktrack = j
                            selecttrack = h
                            good = True
                            Form2.done = False
                            Form2.Show()
                        End If
                    Next
                End If
                If j = 49 Then
                    For h = 0 To 49
                        redattack(j) = False
                    Next
                End If
            Next
        End If
            If turn = 2 Then
                For j = 0 To 49
                    If blueattack(j) = True Then
                        For h = 0 To 49
                            If RedSelect(h) = True Then
                                attacktrack = j
                                selecttrack = h
                                good = True
                                Form2.done = False
                                Form2.Show()
                            End If
                        Next
                    End If
                    If j = 49 Then
                        For h = 0 To 49
                            blueattack(j) = False
                        Next
                    End If
                Next
            End If
            If kingclicked = True Then
                Form3.Show()
            End If
            If turn = 1 And BU = False Then
                For j = 0 To 49
                    If j = 0 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit1.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit1.Enabled = True
                        lblBlueUnit1.Visible = True
                        lblBlueUnit1.Text = "BW"
                        BU = True
                    ElseIf j = 1 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit2.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit2.Enabled = True
                        lblBlueUnit2.Visible = True
                        lblBlueUnit2.Text = "BW"
                        BU = True
                    ElseIf j = 2 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit3.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit3.Enabled = True
                        lblBlueUnit3.Visible = True
                        lblBlueUnit3.Text = "BW"
                        BU = True
                    ElseIf j = 3 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit4.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit4.Enabled = True
                        lblBlueUnit4.Visible = True
                        lblBlueUnit4.Text = "BW"
                        BU = True
                    ElseIf j = 4 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit5.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit5.Enabled = True
                        lblBlueUnit5.Visible = True
                        lblBlueUnit5.Text = "BW"
                        BU = True
                    ElseIf j = 5 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit6.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit6.Enabled = True
                        lblBlueUnit6.Visible = True
                        lblBlueUnit6.Text = "BW"
                        BU = True
                    ElseIf j = 6 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit7.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit7.Enabled = True
                        lblBlueUnit7.Visible = True
                        lblBlueUnit7.Text = "BW"
                        BU = True
                    ElseIf j = 7 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit8.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit8.Enabled = True
                        lblBlueUnit8.Visible = True
                        lblBlueUnit8.Text = "BW"
                        BU = True
                    ElseIf j = 8 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit9.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit9.Enabled = True
                        lblBlueUnit9.Visible = True
                        lblBlueUnit9.Text = "BW"
                        BU = True
                    ElseIf j = 9 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit10.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit10.Enabled = True
                        lblBlueUnit10.Visible = True
                        lblBlueUnit10.Text = "BW"
                        BU = True
                    ElseIf j = 10 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit11.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit11.Enabled = True
                        lblBlueUnit11.Visible = True
                        lblBlueUnit11.Text = "BW"
                        BU = True
                    ElseIf j = 11 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit12.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit12.Enabled = True
                        lblBlueUnit12.Visible = True
                        lblBlueUnit12.Text = "BW"
                        BU = True
                    ElseIf j = 12 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit13.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit13.Enabled = True
                        lblBlueUnit13.Visible = True
                        lblBlueUnit13.Text = "BW"
                        BU = True
                    ElseIf j = 13 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit14.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit14.Enabled = True
                        lblBlueUnit14.Visible = True
                        lblBlueUnit14.Text = "BW"
                        BU = True
                    ElseIf j = 14 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit15.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit15.Enabled = True
                        lblBlueUnit15.Visible = True
                        lblBlueUnit15.Text = "BW"
                        BU = True
                    ElseIf j = 15 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit16.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit16.Enabled = True
                        lblBlueUnit16.Visible = True
                        lblBlueUnit16.Text = "BW"
                        BU = True
                    ElseIf j = 16 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit17.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit17.Enabled = True
                        lblBlueUnit17.Visible = True
                        lblBlueUnit17.Text = "BW"
                        BU = True
                    ElseIf j = 17 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit18.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit18.Enabled = True
                        lblBlueUnit18.Visible = True
                        lblBlueUnit18.Text = "BW"
                        BU = True
                    ElseIf j = 18 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit19.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit19.Enabled = True
                        lblBlueUnit19.Visible = True
                        lblBlueUnit19.Text = "BW"
                        BU = True
                    ElseIf j = 19 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit20.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit20.Enabled = True
                        lblBlueUnit20.Visible = True
                        lblBlueUnit20.Text = "BW"
                        BU = True
                    ElseIf j = 20 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit21.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit21.Enabled = True
                        lblBlueUnit21.Visible = True
                        lblBlueUnit21.Text = "BW"
                        BU = True
                    ElseIf j = 21 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit22.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit22.Enabled = True
                        lblBlueUnit22.Visible = True
                        lblBlueUnit22.Text = "BW"
                        BU = True
                    ElseIf j = 22 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit23.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit23.Enabled = True
                        lblBlueUnit23.Visible = True
                        lblBlueUnit23.Text = "BW"
                        BU = True
                    ElseIf j = 23 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit24.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit24.Enabled = True
                        lblBlueUnit24.Visible = True
                        lblBlueUnit24.Text = "BW"
                        BU = True
                    ElseIf j = 24 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit25.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit25.Enabled = True
                        lblBlueUnit25.Visible = True
                        lblBlueUnit25.Text = "BW"
                        BU = True
                    ElseIf j = 25 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit26.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit26.Enabled = True
                        lblBlueUnit26.Visible = True
                        lblBlueUnit26.Text = "BW"
                        BU = True
                    ElseIf j = 26 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit27.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit27.Enabled = True
                        lblBlueUnit27.Visible = True
                        lblBlueUnit27.Text = "BW"
                        BU = True
                    ElseIf j = 27 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit28.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit28.Enabled = True
                        lblBlueUnit28.Visible = True
                        lblBlueUnit28.Text = "BW"
                        BU = True
                    ElseIf j = 28 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit29.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit29.Enabled = True
                        lblBlueUnit29.Visible = True
                        lblBlueUnit29.Text = "BW"
                        BU = True
                    ElseIf j = 29 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit30.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit30.Enabled = True
                        lblBlueUnit30.Visible = True
                        lblBlueUnit30.Text = "BW"
                        BU = True
                    ElseIf j = 30 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit31.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit31.Enabled = True
                        lblBlueUnit31.Visible = True
                        lblBlueUnit31.Text = "BW"
                        BU = True
                    ElseIf j = 31 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit32.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit32.Enabled = True
                        lblBlueUnit32.Visible = True
                        lblBlueUnit32.Text = "BW"
                        BU = True
                    ElseIf j = 32 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit33.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit33.Enabled = True
                        lblBlueUnit33.Visible = True
                        lblBlueUnit33.Text = "BW"
                        BU = True
                    ElseIf j = 33 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit34.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit34.Enabled = True
                        lblBlueUnit34.Visible = True
                        lblBlueUnit34.Text = "BW"
                        BU = True
                    ElseIf j = 34 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit35.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit35.Enabled = True
                        lblBlueUnit35.Visible = True
                        lblBlueUnit35.Text = "BW"
                        BU = True
                    ElseIf j = 35 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit36.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit36.Enabled = True
                        lblBlueUnit36.Visible = True
                        lblBlueUnit36.Text = "BW"
                        BU = True
                    ElseIf j = 36 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit37.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit37.Enabled = True
                        lblBlueUnit37.Visible = True
                        lblBlueUnit37.Text = "BW"
                        BU = True
                    ElseIf j = 37 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit38.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit38.Enabled = True
                        lblBlueUnit38.Visible = True
                        lblBlueUnit38.Text = "BW"
                        BU = True
                    ElseIf j = 38 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit39.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit39.Enabled = True
                        lblBlueUnit39.Visible = True
                        lblBlueUnit39.Text = "BW"
                        BU = True
                    ElseIf j = 39 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit40.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit40.Enabled = True
                        lblBlueUnit40.Visible = True
                        lblBlueUnit40.Text = "BW"
                        BU = True
                    ElseIf j = 40 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit41.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit41.Enabled = True
                        lblBlueUnit41.Visible = True
                        lblBlueUnit41.Text = "BW"
                        BU = True
                    ElseIf j = 41 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit42.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit42.Enabled = True
                        lblBlueUnit42.Visible = True
                        lblBlueUnit42.Text = "BW"
                        BU = True
                    ElseIf j = 42 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit43.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit43.Enabled = True
                        lblBlueUnit43.Visible = True
                        lblBlueUnit43.Text = "BW"
                        BU = True
                    ElseIf j = 43 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit44.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit44.Enabled = True
                        lblBlueUnit44.Visible = True
                        lblBlueUnit44.Text = "BW"
                        BU = True
                    ElseIf j = 44 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit45.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit45.Enabled = True
                        lblBlueUnit45.Visible = True
                        lblBlueUnit45.Text = "BW"
                        BU = True
                    ElseIf j = 45 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit46.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit46.Enabled = True
                        lblBlueUnit46.Visible = True
                        lblBlueUnit46.Text = "BW"
                        BU = True
                    ElseIf j = 46 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit47.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit47.Enabled = True
                        lblBlueUnit47.Visible = True
                        lblBlueUnit47.Text = "BW"
                        BU = True
                    ElseIf j = 47 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit48.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit48.Enabled = True
                        lblBlueUnit48.Visible = True
                        lblBlueUnit48.Text = "BW"
                        BU = True
                    ElseIf j = 48 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit49.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit49.Enabled = True
                        lblBlueUnit49.Visible = True
                        lblBlueUnit49.Text = "BW"
                        BU = True
                    ElseIf j = 49 And BU = False And BlueUnitStatus(j) = False Then
                        BlueUnitStatus(j) = True
                        BlueUnitHealth(j) = 10
                        lblBlueUnit50.Location = New Point(16 + 10 * 24, 16 + 22 * 23)
                        lblBlueUnit50.Enabled = True
                        lblBlueUnit50.Visible = True
                        lblBlueUnit50.Text = "BW"
                        BU = True
                    End If
                Next
            End If

            If turn = 2 And BU = False Then
                For j = 0 To 49
                    If BU = False And j = 0 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit1.Location = New Point(16 + 10 * 24, 16 + 1 * 23)
                        lblRedUnit1.Enabled = True
                        lblRedUnit1.Visible = True
                        lblRedUnit1.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 1 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit2.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit2.Enabled = True
                        lblRedUnit2.Visible = True
                        lblRedUnit2.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 2 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit3.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit3.Enabled = True
                        lblRedUnit3.Visible = True
                        lblRedUnit3.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 3 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit4.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit4.Enabled = True
                        lblRedUnit4.Visible = True
                        lblRedUnit4.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 4 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit5.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit5.Enabled = True
                        lblRedUnit5.Visible = True
                        lblRedUnit5.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 5 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit6.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit6.Enabled = True
                        lblRedUnit6.Visible = True
                        lblRedUnit6.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 6 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit7.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit7.Enabled = True
                        lblRedUnit7.Visible = True
                        lblRedUnit7.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 7 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit8.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit8.Enabled = True
                        lblRedUnit8.Visible = True
                        lblRedUnit8.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 8 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit9.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit9.Enabled = True
                        lblRedUnit9.Visible = True
                        lblRedUnit9.Text = "RW"

                        BU = True
                    ElseIf BU = False And j = 9 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit10.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit10.Enabled = True
                        lblRedUnit10.Visible = True
                        lblRedUnit10.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 10 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit11.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit11.Enabled = True
                        lblRedUnit11.Visible = True
                        lblRedUnit11.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 11 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit12.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit12.Enabled = True
                        lblRedUnit12.Visible = True
                        lblRedUnit12.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 12 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit13.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit13.Enabled = True
                        lblRedUnit13.Visible = True
                        lblRedUnit13.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 13 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit14.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit14.Enabled = True
                        lblRedUnit14.Visible = True
                        lblRedUnit14.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 14 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit15.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit15.Enabled = True
                        lblRedUnit15.Visible = True
                        lblRedUnit15.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 15 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit16.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit16.Enabled = True
                        lblRedUnit16.Visible = True
                        lblRedUnit16.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 16 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit17.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit17.Enabled = True
                        lblRedUnit17.Visible = True
                        lblRedUnit17.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 17 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit18.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit18.Enabled = True
                        lblRedUnit18.Visible = True
                        lblRedUnit18.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 18 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit19.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit19.Enabled = True
                        lblRedUnit19.Visible = True
                        lblRedUnit19.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 19 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit20.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit20.Enabled = True
                        lblRedUnit20.Visible = True
                        lblRedUnit20.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 20 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit21.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit21.Enabled = True
                        lblRedUnit21.Visible = True
                        lblRedUnit21.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 21 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit22.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit22.Enabled = True
                        lblRedUnit22.Visible = True
                        lblRedUnit22.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 22 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit3.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit23.Enabled = True
                        lblRedUnit23.Visible = True
                        lblRedUnit23.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 23 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit24.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit24.Enabled = True
                        lblRedUnit24.Visible = True
                        lblRedUnit24.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 24 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit25.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit25.Enabled = True
                        lblRedUnit25.Visible = True
                        lblRedUnit25.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 25 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit26.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit26.Enabled = True
                        lblRedUnit26.Visible = True
                        lblRedUnit26.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 26 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit27.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit27.Enabled = True
                        lblRedUnit27.Visible = True
                        lblRedUnit27.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 27 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit28.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit28.Enabled = True
                        lblRedUnit28.Visible = True
                        lblRedUnit28.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 28 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit29.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit29.Enabled = True
                        lblRedUnit29.Visible = True
                        lblRedUnit29.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 29 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit30.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit30.Enabled = True
                        lblRedUnit30.Visible = True
                        lblRedUnit30.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 30 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit31.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit31.Enabled = True
                        lblRedUnit31.Visible = True
                        lblRedUnit31.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 31 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit32.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit32.Enabled = True
                        lblRedUnit32.Visible = True
                        lblRedUnit32.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 32 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit33.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit33.Enabled = True
                        lblRedUnit33.Visible = True
                        lblRedUnit33.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 33 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit34.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit34.Enabled = True
                        lblRedUnit34.Visible = True
                        lblRedUnit34.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 34 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit35.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit35.Enabled = True
                        lblRedUnit35.Visible = True
                        lblRedUnit35.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 35 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit36.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit36.Enabled = True
                        lblRedUnit36.Visible = True
                        lblRedUnit36.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 36 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit37.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit37.Enabled = True
                        lblRedUnit37.Visible = True
                        lblRedUnit37.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 37 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit38.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit38.Enabled = True
                        lblRedUnit38.Visible = True
                        lblRedUnit38.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 38 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit39.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit39.Enabled = True
                        lblRedUnit39.Visible = True
                        lblRedUnit39.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 39 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit40.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit40.Enabled = True
                        lblRedUnit40.Visible = True
                        lblRedUnit40.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 40 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit41.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit41.Enabled = True
                        lblRedUnit41.Visible = True
                        lblRedUnit41.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 41 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit42.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit42.Enabled = True
                        lblRedUnit42.Visible = True
                        lblRedUnit42.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 42 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit43.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit43.Enabled = True
                        lblRedUnit43.Visible = True
                        lblRedUnit43.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 43 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit44.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit44.Enabled = True
                        lblRedUnit44.Visible = True
                        lblRedUnit44.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 44 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit45.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit45.Enabled = True
                        lblRedUnit45.Visible = True
                        lblRedUnit45.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 45 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit46.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit46.Enabled = True
                        lblRedUnit46.Visible = True
                        lblRedUnit46.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 46 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit47.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit47.Enabled = True
                        lblRedUnit47.Visible = True
                        lblRedUnit47.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 47 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit48.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit48.Enabled = True
                        lblRedUnit48.Visible = True
                        lblRedUnit48.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 48 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit49.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit49.Enabled = True
                        lblRedUnit49.Visible = True
                        lblRedUnit49.Text = "RW"
                        BU = True
                    ElseIf BU = False And j = 49 And RedUnitStatus(j) = False Then
                        RedUnitStatus(j) = True
                        RedUnitHealth(j) = 10
                        lblRedUnit50.Location = New Point(16 + 10 * 24, (16 + 1 * 23))
                        lblRedUnit50.Enabled = True
                        lblRedUnit50.Visible = True
                        lblRedUnit50.Text = "RW"
                        BU = True
                    ElseIf j = 49 And BU = False Then
                        BU = True
                    End If
                Next
            End If





    End Sub

    Private Sub BlueDead_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueDead.Tick

        'Removeing dead blue units
        For j = 1 To 49
            If BlueUnitStatus(j) = False Then
                If j = 0 Then
                    lblBlueUnit1.Location = New Point(400, 400)
                    lblBlueUnit1.Visible = False
                    lblBlueUnit1.Enabled = False
                ElseIf j = 1 Then
                    lblBlueUnit2.Location = New Point(400, 400)
                    lblBlueUnit2.Visible = False
                    lblBlueUnit2.Enabled = False
                ElseIf j = 2 Then
                    lblBlueUnit3.Location = New Point(400, 400)
                    lblBlueUnit3.Visible = False
                    lblBlueUnit3.Enabled = False
                ElseIf j = 3 Then
                    lblBlueUnit4.Location = New Point(400, 400)
                    lblBlueUnit4.Visible = False
                    lblBlueUnit4.Enabled = False
                ElseIf j = 4 Then
                    lblBlueUnit5.Location = New Point(400, 400)
                    lblBlueUnit5.Visible = False
                    lblBlueUnit5.Enabled = False
                ElseIf j = 5 Then
                    lblBlueUnit6.Location = New Point(400, 400)
                    lblBlueUnit6.Visible = False
                    lblBlueUnit6.Enabled = False
                ElseIf j = 6 Then
                    lblBlueUnit7.Location = New Point(400, 400)
                    lblBlueUnit7.Visible = False
                    lblBlueUnit7.Enabled = False
                ElseIf j = 7 Then
                    lblBlueUnit8.Location = New Point(400, 400)
                    lblBlueUnit8.Visible = False
                    lblBlueUnit8.Enabled = False
                ElseIf j = 8 Then
                    lblBlueUnit9.Location = New Point(400, 400)
                    lblBlueUnit9.Visible = False
                    lblBlueUnit9.Enabled = False
                ElseIf j = 9 Then
                    lblBlueUnit10.Location = New Point(400, 400)
                    lblBlueUnit10.Visible = False
                    lblBlueUnit10.Enabled = False
                ElseIf j = 10 Then
                    lblBlueUnit11.Location = New Point(400, 400)
                    lblBlueUnit11.Visible = False
                    lblBlueUnit11.Enabled = False
                ElseIf j = 11 Then
                    lblBlueUnit12.Location = New Point(400, 400)
                    lblBlueUnit12.Visible = False
                    lblBlueUnit12.Enabled = False
                ElseIf j = 12 Then
                    lblBlueUnit13.Location = New Point(400, 400)
                    lblBlueUnit13.Visible = False
                    lblBlueUnit13.Enabled = False
                ElseIf j = 13 Then
                    lblBlueUnit14.Location = New Point(400, 400)
                    lblBlueUnit14.Visible = False
                    lblBlueUnit14.Enabled = False
                ElseIf j = 14 Then
                    lblBlueUnit15.Location = New Point(400, 400)
                    lblBlueUnit15.Visible = False
                    lblBlueUnit15.Enabled = False
                ElseIf j = 15 Then
                    lblBlueUnit16.Location = New Point(400, 400)
                    lblBlueUnit16.Visible = False
                    lblBlueUnit16.Enabled = False
                ElseIf j = 16 Then
                    lblBlueUnit17.Location = New Point(400, 400)
                    lblBlueUnit17.Visible = False
                    lblBlueUnit17.Enabled = False
                ElseIf j = 17 Then
                    lblBlueUnit18.Location = New Point(400, 400)
                    lblBlueUnit18.Visible = False
                    lblBlueUnit18.Enabled = False
                ElseIf j = 18 Then
                    lblBlueUnit19.Location = New Point(400, 400)
                    lblBlueUnit19.Visible = False
                    lblBlueUnit19.Enabled = False
                ElseIf j = 19 Then
                    lblBlueUnit20.Location = New Point(400, 400)
                    lblBlueUnit20.Visible = False
                    lblBlueUnit20.Enabled = False
                ElseIf j = 20 Then
                    lblBlueUnit21.Location = New Point(400, 400)
                    lblBlueUnit21.Visible = False
                    lblBlueUnit21.Enabled = False
                ElseIf j = 21 Then
                    lblBlueUnit22.Location = New Point(400, 400)
                    lblBlueUnit22.Visible = False
                    lblBlueUnit22.Enabled = False
                ElseIf j = 22 Then
                    lblBlueUnit23.Location = New Point(400, 400)
                    lblBlueUnit23.Visible = False
                ElseIf j = 23 Then
                    lblBlueUnit24.Location = New Point(400, 400)
                    lblBlueUnit24.Visible = False
                    lblBlueUnit24.Enabled = False
                ElseIf j = 24 Then
                    lblBlueUnit25.Location = New Point(400, 400)
                    lblBlueUnit25.Visible = False
                    lblBlueUnit25.Enabled = False
                ElseIf j = 25 Then
                    lblBlueUnit26.Location = New Point(400, 400)
                    lblBlueUnit26.Visible = False
                    lblBlueUnit26.Enabled = False
                ElseIf j = 26 Then
                    lblBlueUnit27.Location = New Point(400, 400)
                    lblBlueUnit27.Visible = False
                    lblBlueUnit27.Enabled = False
                ElseIf j = 27 Then
                    lblBlueUnit28.Location = New Point(400, 400)
                    lblBlueUnit28.Visible = False
                    lblBlueUnit28.Enabled = False
                ElseIf j = 28 Then
                    lblBlueUnit29.Location = New Point(400, 400)
                    lblBlueUnit29.Visible = False
                    lblBlueUnit29.Enabled = False
                ElseIf j = 29 Then
                    lblBlueUnit30.Location = New Point(400, 400)
                    lblBlueUnit30.Visible = False
                    lblBlueUnit30.Enabled = False
                ElseIf j = 30 Then
                    lblBlueUnit31.Location = New Point(400, 400)
                    lblBlueUnit31.Visible = False
                    lblBlueUnit31.Enabled = False
                ElseIf j = 31 Then
                    lblBlueUnit32.Location = New Point(400, 400)
                    lblBlueUnit32.Visible = False
                    lblBlueUnit32.Enabled = False
                ElseIf j = 32 Then
                    lblBlueUnit33.Location = New Point(400, 400)
                    lblBlueUnit33.Visible = False
                    lblBlueUnit33.Enabled = False
                ElseIf j = 33 Then
                    lblBlueUnit34.Location = New Point(400, 400)
                    lblBlueUnit34.Visible = False
                    lblBlueUnit34.Enabled = False
                ElseIf j = 34 Then
                    lblBlueUnit35.Location = New Point(400, 400)
                    lblBlueUnit35.Visible = False
                    lblBlueUnit35.Enabled = False
                ElseIf j = 35 Then
                    lblBlueUnit36.Location = New Point(400, 400)
                    lblBlueUnit36.Visible = False
                    lblBlueUnit36.Enabled = False
                ElseIf j = 36 Then
                    lblBlueUnit37.Location = New Point(400, 400)
                    lblBlueUnit37.Visible = False
                    lblBlueUnit37.Enabled = False
                ElseIf j = 37 Then
                    lblBlueUnit38.Location = New Point(400, 400)
                    lblBlueUnit38.Visible = False
                    lblBlueUnit38.Enabled = False
                ElseIf j = 38 Then
                    lblBlueUnit39.Location = New Point(400, 400)
                    lblBlueUnit39.Visible = False
                    lblBlueUnit39.Enabled = False
                ElseIf j = 39 Then
                    lblBlueUnit40.Location = New Point(400, 400)
                    lblBlueUnit40.Visible = False
                    lblBlueUnit40.Enabled = False
                ElseIf j = 40 Then
                    lblBlueUnit41.Location = New Point(400, 400)
                    lblBlueUnit41.Visible = False
                    lblBlueUnit41.Enabled = False
                ElseIf j = 41 Then
                    lblBlueUnit42.Location = New Point(400, 400)
                    lblBlueUnit42.Visible = False
                    lblBlueUnit42.Enabled = False
                ElseIf j = 42 Then
                    lblBlueUnit43.Location = New Point(400, 400)
                    lblBlueUnit43.Visible = False
                    lblBlueUnit43.Enabled = False
                ElseIf j = 43 Then
                    lblBlueUnit44.Location = New Point(400, 400)
                    lblBlueUnit44.Visible = False
                    lblBlueUnit44.Enabled = False
                ElseIf j = 44 Then
                    lblBlueUnit45.Location = New Point(400, 400)
                    lblBlueUnit45.Visible = False
                    lblBlueUnit45.Enabled = False
                ElseIf j = 45 Then
                    lblBlueUnit46.Location = New Point(400, 400)
                    lblBlueUnit46.Visible = False
                    lblBlueUnit46.Enabled = False
                ElseIf j = 46 Then
                    lblBlueUnit47.Location = New Point(400, 400)
                    lblBlueUnit47.Visible = False
                    lblBlueUnit47.Enabled = False
                ElseIf j = 47 Then
                    lblBlueUnit48.Location = New Point(400, 400)
                    lblBlueUnit48.Visible = False
                    lblBlueUnit48.Enabled = False
                ElseIf j = 48 Then
                    lblBlueUnit9.Location = New Point(400, 400)
                    lblBlueUnit9.Visible = False
                    lblBlueUnit49.Enabled = False
                ElseIf j = 49 Then
                    lblBlueUnit50.Location = New Point(400, 400)
                    lblBlueUnit50.Visible = False
                    lblBlueUnit50.Enabled = False
                End If
            End If
        Next
        For j = 0 To 49
            If RedUnitStatus(j) = False Then
                If j = 0 Then
                    lblRedUnit1.Location = New Point(400, 400)
                    lblRedUnit1.Visible = False
                    lblRedUnit1.Enabled = False
                ElseIf j = 1 Then
                    lblRedUnit2.Location = New Point(400, 400)
                    lblRedUnit2.Visible = False
                    lblRedUnit2.Enabled = False
                ElseIf j = 2 Then
                    lblRedUnit3.Location = New Point(400, 400)
                    lblRedUnit3.Visible = False
                    lblRedUnit3.Enabled = False
                ElseIf j = 3 Then
                    lblRedUnit4.Location = New Point(400, 400)
                    lblRedUnit4.Visible = False
                    lblRedUnit4.Enabled = False
                ElseIf j = 4 Then
                    lblRedUnit5.Location = New Point(400, 400)
                    lblRedUnit5.Visible = False
                    lblRedUnit5.Enabled = False
                ElseIf j = 5 Then
                    lblRedUnit6.Location = New Point(400, 400)
                    lblRedUnit6.Visible = False
                    lblRedUnit6.Enabled = False
                ElseIf j = 6 Then
                    lblRedUnit7.Location = New Point(400, 400)
                    lblRedUnit7.Visible = False
                    lblRedUnit7.Enabled = False
                ElseIf j = 7 Then
                    lblRedUnit8.Location = New Point(400, 400)
                    lblRedUnit8.Visible = False
                    lblRedUnit8.Enabled = False
                ElseIf j = 8 Then
                    lblRedUnit9.Location = New Point(400, 400)
                    lblRedUnit9.Visible = False
                    lblRedUnit9.Enabled = False
                ElseIf j = 9 Then
                    lblRedUnit10.Location = New Point(400, 400)
                    lblRedUnit10.Visible = False
                    lblRedUnit10.Enabled = False
                ElseIf j = 10 Then
                    lblRedUnit11.Location = New Point(400, 400)
                    lblRedUnit11.Visible = False
                    lblRedUnit11.Enabled = False
                ElseIf j = 11 Then
                    lblRedUnit12.Location = New Point(400, 400)
                    lblRedUnit12.Visible = False
                    lblRedUnit12.Enabled = False
                ElseIf j = 12 Then
                    lblRedUnit13.Location = New Point(400, 400)
                    lblRedUnit13.Visible = False
                    lblRedUnit13.Enabled = False
                ElseIf j = 13 Then
                    lblRedUnit14.Location = New Point(400, 400)
                    lblRedUnit14.Visible = False
                    lblRedUnit14.Enabled = False
                ElseIf j = 14 Then
                    lblRedUnit15.Location = New Point(400, 400)
                    lblRedUnit15.Visible = False
                    lblRedUnit15.Enabled = False
                ElseIf j = 15 Then
                    lblRedUnit16.Location = New Point(400, 400)
                    lblRedUnit16.Visible = False
                    lblRedUnit16.Enabled = False
                ElseIf j = 16 Then
                    lblRedUnit17.Location = New Point(400, 400)
                    lblRedUnit17.Visible = False
                    lblRedUnit17.Enabled = False
                ElseIf j = 17 Then
                    lblRedUnit18.Location = New Point(400, 400)
                    lblRedUnit18.Visible = False
                    lblRedUnit18.Enabled = False
                ElseIf j = 18 Then
                    lblRedUnit19.Location = New Point(400, 400)
                    lblRedUnit19.Visible = False
                    lblRedUnit19.Enabled = False
                ElseIf j = 19 Then
                    lblRedUnit20.Location = New Point(400, 400)
                    lblRedUnit20.Visible = False
                    lblRedUnit20.Enabled = False
                ElseIf j = 20 Then
                    lblRedUnit21.Location = New Point(400, 400)
                    lblRedUnit21.Visible = False
                    lblRedUnit21.Enabled = False
                ElseIf j = 21 Then
                    lblRedUnit22.Location = New Point(400, 400)
                    lblRedUnit22.Visible = False
                    lblRedUnit22.Enabled = False
                ElseIf j = 22 Then
                    lblRedUnit23.Location = New Point(400, 400)
                    lblRedUnit23.Visible = False
                    lblRedUnit23.Enabled = False
                ElseIf j = 23 Then
                    lblRedUnit24.Location = New Point(400, 400)
                    lblRedUnit24.Visible = False
                    lblRedUnit24.Enabled = False
                ElseIf j = 24 Then
                    lblRedUnit25.Location = New Point(400, 400)
                    lblRedUnit25.Visible = False
                    lblRedUnit25.Enabled = False
                ElseIf j = 25 Then
                    lblRedUnit26.Location = New Point(400, 400)
                    lblRedUnit26.Visible = False
                    lblRedUnit26.Enabled = False
                ElseIf j = 26 Then
                    lblRedUnit27.Location = New Point(400, 400)
                    lblRedUnit27.Visible = False
                    lblRedUnit27.Enabled = False
                ElseIf j = 27 Then
                    lblRedUnit28.Location = New Point(400, 400)
                    lblRedUnit28.Visible = False
                    lblRedUnit28.Enabled = False
                ElseIf j = 28 Then
                    lblRedUnit29.Location = New Point(400, 400)
                    lblRedUnit29.Visible = False
                    lblRedUnit29.Enabled = False
                ElseIf j = 29 Then
                    lblRedUnit30.Location = New Point(400, 400)
                    lblRedUnit30.Visible = False
                    lblRedUnit30.Enabled = False
                ElseIf j = 30 Then
                    lblRedUnit31.Location = New Point(400, 400)
                    lblRedUnit31.Visible = False
                    lblRedUnit31.Enabled = False
                ElseIf j = 31 Then
                    lblRedUnit32.Location = New Point(400, 400)
                    lblRedUnit32.Visible = False
                    lblRedUnit32.Enabled = False
                ElseIf j = 32 Then
                    lblRedUnit33.Location = New Point(400, 400)
                    lblRedUnit33.Visible = False
                    lblRedUnit33.Enabled = False
                ElseIf j = 33 Then
                    lblRedUnit34.Location = New Point(400, 400)
                    lblRedUnit34.Visible = False
                    lblRedUnit34.Enabled = False
                ElseIf j = 34 Then
                    lblRedUnit35.Location = New Point(400, 400)
                    lblRedUnit35.Visible = False
                    lblRedUnit35.Enabled = False
                ElseIf j = 35 Then
                    lblRedUnit36.Location = New Point(400, 400)
                    lblRedUnit36.Visible = False
                    lblRedUnit36.Enabled = False
                ElseIf j = 36 Then
                    lblRedUnit37.Location = New Point(400, 400)
                    lblRedUnit37.Visible = False
                    lblRedUnit37.Enabled = False
                ElseIf j = 27 Then
                    lblRedUnit38.Location = New Point(400, 400)
                    lblRedUnit38.Visible = False
                    lblRedUnit38.Enabled = False
                ElseIf j = 28 Then
                    lblRedUnit39.Location = New Point(400, 400)
                    lblRedUnit39.Visible = False
                    lblRedUnit39.Enabled = False
                ElseIf j = 29 Then
                    lblRedUnit30.Location = New Point(400, 400)
                    lblRedUnit30.Visible = False
                    lblRedUnit30.Enabled = False
                ElseIf j = 30 Then
                    lblRedUnit31.Location = New Point(400, 400)
                    lblRedUnit31.Visible = False
                    lblRedUnit31.Enabled = False
                ElseIf j = 31 Then
                    lblRedUnit32.Location = New Point(400, 400)
                    lblRedUnit32.Visible = False
                    lblRedUnit32.Enabled = False
                ElseIf j = 32 Then
                    lblRedUnit33.Location = New Point(400, 400)
                    lblRedUnit33.Visible = False
                    lblRedUnit33.Enabled = False
                ElseIf j = 33 Then
                    lblRedUnit34.Location = New Point(400, 400)
                    lblRedUnit34.Visible = False
                    lblRedUnit34.Enabled = False
                ElseIf j = 34 Then
                    lblRedUnit35.Location = New Point(400, 400)
                    lblRedUnit35.Visible = False
                    lblRedUnit35.Enabled = False
                ElseIf j = 35 Then
                    lblRedUnit36.Location = New Point(400, 400)
                    lblRedUnit36.Visible = False
                    lblRedUnit36.Enabled = False
                ElseIf j = 36 Then
                    lblRedUnit37.Location = New Point(400, 400)
                    lblRedUnit37.Visible = False
                    lblRedUnit37.Enabled = False
                ElseIf j = 37 Then
                    lblRedUnit38.Location = New Point(400, 400)
                    lblRedUnit38.Visible = False
                    lblRedUnit38.Enabled = False
                ElseIf j = 38 Then
                    lblRedUnit39.Location = New Point(400, 400)
                    lblRedUnit39.Visible = False
                    lblRedUnit39.Enabled = False
                ElseIf j = 39 Then
                    lblRedUnit40.Location = New Point(400, 400)
                    lblRedUnit40.Visible = False
                    lblRedUnit40.Enabled = False
                ElseIf j = 40 Then
                    lblRedUnit41.Location = New Point(400, 400)
                    lblRedUnit41.Visible = False
                    lblRedUnit41.Enabled = False
                ElseIf j = 41 Then
                    lblRedUnit42.Location = New Point(400, 400)
                    lblRedUnit42.Visible = False
                    lblRedUnit42.Enabled = False
                ElseIf j = 42 Then
                    lblRedUnit43.Location = New Point(400, 400)
                    lblRedUnit43.Visible = False
                    lblRedUnit43.Enabled = False
                ElseIf j = 43 Then
                    lblRedUnit44.Location = New Point(400, 400)
                    lblRedUnit44.Visible = False
                    lblRedUnit44.Enabled = False
                ElseIf j = 44 Then
                    lblRedUnit45.Location = New Point(400, 400)
                    lblRedUnit45.Visible = False
                    lblRedUnit45.Enabled = False
                ElseIf j = 45 Then
                    lblRedUnit46.Location = New Point(400, 400)
                    lblRedUnit46.Visible = False
                    lblRedUnit46.Enabled = False
                ElseIf j = 46 Then
                    lblRedUnit47.Location = New Point(400, 400)
                    lblRedUnit47.Visible = False
                    lblRedUnit47.Enabled = False
                ElseIf j = 47 Then
                    lblRedUnit48.Location = New Point(400, 400)
                    lblRedUnit48.Visible = False
                    lblRedUnit48.Enabled = False
                ElseIf j = 48 Then
                    lblRedUnit49.Location = New Point(400, 400)
                    lblRedUnit49.Visible = False
                    lblRedUnit49.Enabled = False
                ElseIf j = 49 Then
                    lblRedUnit50.Location = New Point(400, 400)
                    lblRedUnit50.Visible = False
                    lblRedUnit50.Enabled = False
                End If
            End If
        Next
    End Sub
    Private Sub BlueUnitClick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueUnitClick.Tick
        If BlueSelect(0) = True Then
            lblBlueUnit1.ForeColor = Color.Yellow
        ElseIf BlueSelect(0) = False And BlueUnitDone(0) = True Then
            lblBlueUnit1.ForeColor = Color.Violet
        Else
            lblBlueUnit1.ForeColor = Color.Black
        End If
        If BlueSelect(1) = True Then
            lblBlueUnit2.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(1) = True Then
            lblBlueUnit2.ForeColor = Color.Violet
        Else
            lblBlueUnit2.ForeColor = Color.Black
        End If
        If BlueSelect(2) = True Then
            lblBlueUnit3.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(2) = True Then
            lblBlueUnit3.ForeColor = Color.Violet
        Else
            lblBlueUnit3.ForeColor = Color.Black
        End If
        If BlueSelect(3) = True Then
            lblBlueUnit4.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(3) = True Then
            lblBlueUnit4.ForeColor = Color.Violet
        Else
            lblBlueUnit4.ForeColor = Color.Black
        End If
        If BlueSelect(4) = True Then
            lblBlueUnit5.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(4) = True Then
            lblBlueUnit5.ForeColor = Color.Violet
        Else
            lblBlueUnit5.ForeColor = Color.Black
        End If
        If BlueSelect(5) = True Then
            lblBlueUnit6.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(5) = True Then
            lblBlueUnit6.ForeColor = Color.Violet
        Else
            lblBlueUnit6.ForeColor = Color.Black
        End If
        If BlueSelect(6) = True Then
            lblBlueUnit7.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(6) = True Then
            lblBlueUnit7.ForeColor = Color.Violet
        Else
            lblBlueUnit7.ForeColor = Color.Black
        End If
        If BlueSelect(7) = True Then
            lblBlueUnit8.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(7) = True Then
            lblBlueUnit8.ForeColor = Color.Violet
        Else
            lblBlueUnit8.ForeColor = Color.Black
        End If
        If BlueSelect(8) = True Then
            lblBlueUnit9.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(8) = True Then
            lblBlueUnit9.ForeColor = Color.Yellow
        Else
            lblBlueUnit9.ForeColor = Color.Black
        End If
        If BlueSelect(9) = True Then
            lblBlueUnit10.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(9) = True Then
            lblBlueUnit10.ForeColor = Color.Violet
        Else
            lblBlueUnit10.ForeColor = Color.Black
        End If
        If BlueSelect(10) = True Then
            lblBlueUnit11.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(10) = True Then
            lblBlueUnit11.ForeColor = Color.Violet
        Else
            lblBlueUnit11.ForeColor = Color.Black
        End If
        If BlueSelect(11) = True Then
            lblBlueUnit12.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(11) = True Then
            lblBlueUnit12.ForeColor = Color.Violet
        Else
            lblBlueUnit12.ForeColor = Color.Black
        End If
        If BlueSelect(12) = True Then
            lblBlueUnit13.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(12) = True Then
            lblBlueUnit13.ForeColor = Color.Violet
        Else
            lblBlueUnit13.ForeColor = Color.Black
        End If
        If BlueSelect(13) = True Then
            lblBlueUnit14.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(13) = True Then
            lblBlueUnit14.ForeColor = Color.Violet
        Else
            lblBlueUnit14.ForeColor = Color.Black
        End If
        If BlueSelect(14) = True Then
            lblBlueUnit15.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(14) = True Then
            lblBlueUnit15.ForeColor = Color.Violet
        Else
            lblBlueUnit15.ForeColor = Color.Black
        End If
        If BlueSelect(15) = True Then
            lblBlueUnit16.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(15) = True Then
            lblBlueUnit16.ForeColor = Color.Violet
        Else
            lblBlueUnit16.ForeColor = Color.Black
        End If
        If BlueSelect(16) = True Then
            lblBlueUnit17.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(16) = True Then
            lblBlueUnit17.ForeColor = Color.Violet
        Else
            lblBlueUnit17.ForeColor = Color.Black
        End If
        If BlueSelect(17) = True Then
            lblBlueUnit18.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(17) = True Then
            lblBlueUnit18.ForeColor = Color.Violet
        Else
            lblBlueUnit18.ForeColor = Color.Black
        End If
        If BlueSelect(18) = True Then
            lblBlueUnit19.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(18) = True Then
            lblBlueUnit19.ForeColor = Color.Violet
        Else
            lblBlueUnit19.ForeColor = Color.Black
        End If
        If BlueSelect(19) = True Then
            lblBlueUnit20.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(19) = True Then
            lblBlueUnit20.ForeColor = Color.Violet
        Else
            lblBlueUnit20.ForeColor = Color.Black
        End If
        If BlueSelect(20) = True Then
            lblBlueUnit21.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(20) = True Then
            lblBlueUnit21.ForeColor = Color.Violet
        Else
            lblBlueUnit21.ForeColor = Color.Black
        End If
        If BlueSelect(21) = True Then
            lblBlueUnit22.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(21) = True Then
            lblBlueUnit22.ForeColor = Color.Violet
        Else
            lblBlueUnit22.ForeColor = Color.Black
        End If
        If BlueSelect(22) = True Then
            lblBlueUnit23.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(22) - True Then
            lblBlueUnit23.ForeColor = Color.Violet
        Else
            lblBlueUnit23.ForeColor = Color.Black
        End If
        If BlueSelect(23) = True Then
            lblBlueUnit24.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(23) = True Then
            lblBlueUnit24.ForeColor = Color.Violet
        Else
            lblBlueUnit24.ForeColor = Color.Black
        End If
        If BlueSelect(24) = True Then
            lblBlueUnit25.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(24) = True Then
            lblBlueUnit25.ForeColor = Color.Violet
        Else
            lblBlueUnit25.ForeColor = Color.Black
        End If
        If BlueSelect(25) = True Then
            lblBlueUnit26.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(25) = True Then
            lblBlueUnit26.ForeColor = Color.Violet
        Else
            lblBlueUnit26.ForeColor = Color.Black
        End If
        If BlueSelect(26) = True Then
            lblBlueUnit27.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(26) = True Then
            lblBlueUnit27.ForeColor = Color.Violet
        Else
            lblBlueUnit27.ForeColor = Color.Black
        End If
        If BlueSelect(27) = True Then
            lblBlueUnit28.ForeColor = Color.Yellow
        Else
            lblBlueUnit28.ForeColor = Color.Black
        End If
        If BlueSelect(28) = True Then
            lblBlueUnit29.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(28) = True Then
            lblBlueUnit29.ForeColor = Color.Violet
        Else
            lblBlueUnit29.ForeColor = Color.Black
        End If
        If BlueSelect(29) = True Then
            lblBlueUnit30.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(29) = True Then
            lblBlueUnit30.ForeColor = Color.Violet
        Else
            lblBlueUnit30.ForeColor = Color.Black
        End If
        If BlueSelect(30) = True Then
            lblBlueUnit31.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(30) = True Then
            lblBlueUnit31.ForeColor = Color.Violet
        Else
            lblBlueUnit31.ForeColor = Color.Black
        End If
        If BlueSelect(31) = True Then
            lblBlueUnit32.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(31) = True Then
            lblBlueUnit32.ForeColor = Color.Violet
        Else
            lblBlueUnit32.ForeColor = Color.Black
        End If
        If BlueSelect(32) = True Then
            lblBlueUnit33.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(32) = True Then
            lblBlueUnit33.ForeColor = Color.Violet
        Else
            lblBlueUnit33.ForeColor = Color.Black
        End If
        If BlueSelect(33) = True Then
            lblBlueUnit34.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(33) = True Then
            lblBlueUnit34.ForeColor = Color.Violet
        Else
            lblBlueUnit34.ForeColor = Color.Black
        End If
        If BlueSelect(34) = True Then
            lblBlueUnit35.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(34) = True Then
            lblBlueUnit35.ForeColor = Color.Violet
        Else
            lblBlueUnit35.ForeColor = Color.Black
        End If
        If BlueSelect(35) = True Then
            lblBlueUnit36.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(35) = True Then
            lblBlueUnit36.ForeColor = Color.Violet
        Else
            lblBlueUnit36.ForeColor = Color.Black
        End If
        If BlueSelect(36) = True Then
            lblBlueUnit37.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(36) = True Then
            lblBlueUnit27.ForeColor = Color.Violet
        Else
            lblBlueUnit37.ForeColor = Color.Black
        End If
        If BlueSelect(37) = True Then
            lblBlueUnit38.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(37) = True Then
            lblBlueUnit38.ForeColor = Color.Violet
        Else
            lblBlueUnit38.ForeColor = Color.Black
        End If
        If BlueSelect(38) = True Then
            lblBlueUnit39.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(38) = True Then
            lblBlueUnit39.ForeColor = Color.Violet
        Else
            lblBlueUnit39.ForeColor = Color.Black
        End If
        If BlueSelect(39) = True Then
            lblBlueUnit40.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(39) = True Then
            lblBlueUnit40.ForeColor = Color.Violet
        Else
            lblBlueUnit40.ForeColor = Color.Black
        End If
        If BlueSelect(40) = True Then
            lblBlueUnit41.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(40) = True Then
            lblBlueUnit21.ForeColor = Color.Violet
        Else
            lblBlueUnit41.ForeColor = Color.Black
        End If
        If BlueSelect(41) = True Then
            lblBlueUnit42.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(41) = True Then
            lblBlueUnit42.ForeColor = Color.Violet
        Else
            lblBlueUnit42.ForeColor = Color.Black
        End If
        If BlueSelect(42) = True Then
            lblBlueUnit43.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(42) = True Then
            lblBlueUnit43.ForeColor = Color.Violet
        Else
            lblBlueUnit43.ForeColor = Color.Black
        End If
        If BlueSelect(43) = True Then
            lblBlueUnit44.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(43) = True Then
            lblBlueUnit44.ForeColor = Color.Violet
        Else
            lblBlueUnit44.ForeColor = Color.Black
        End If
        If BlueSelect(44) = True Then
            lblBlueUnit45.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(44) = True Then
            lblBlueUnit45.ForeColor = Color.Violet
        Else
            lblBlueUnit45.ForeColor = Color.Black
        End If
        If BlueSelect(45) = True Then
            lblBlueUnit46.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(45) = True Then
            lblBlueUnit46.ForeColor = Color.Violet
        Else
            lblBlueUnit46.ForeColor = Color.Black
        End If
        If BlueSelect(46) = True Then
            lblBlueUnit47.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(46) = True Then
            lblBlueUnit47.ForeColor = Color.Violet
        Else
            lblBlueUnit47.ForeColor = Color.Black
        End If
        If BlueSelect(47) = True Then
            lblBlueUnit48.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(47) = True Then
            lblBlueUnit48.ForeColor = Color.Violet
        Else
            lblBlueUnit48.ForeColor = Color.Black
        End If
        If BlueSelect(48) = True Then
            lblBlueUnit49.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(48) = True Then
            lblBlueUnit49.ForeColor = Color.Violet
        Else
            lblBlueUnit49.ForeColor = Color.Black
        End If
        If BlueSelect(49) = True Then
            lblBlueUnit50.ForeColor = Color.Yellow
        ElseIf BlueUnitDone(49) = True Then
            lblBlueUnit50.ForeColor = Color.Violet
        Else
            lblBlueUnit50.ForeColor = Color.Black
        End If

    End Sub

    Private Sub lblBlueUnit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit2.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(1) = False And turn = 1 Then
            BlueSelect(1) = True
        Else
            BlueSelect(1) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(1) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit3.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(2) = False And turn = 1 Then
            BlueSelect(2) = True
        Else
            BlueSelect(2) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(2) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit4.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(3) = False And turn = 1 Then
            BlueSelect(3) = True
        Else
            BlueSelect(3) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(3) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit5.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(4) = False And turn = 1 Then
            BlueSelect(4) = True
        Else
            BlueSelect(4) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(4) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit6.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(5) = False And turn = 1 Then
            BlueSelect(5) = True
        Else
            BlueSelect(5) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(5) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit7.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(6) = False And turn = 1 Then
            BlueSelect(6) = True
        Else
            BlueSelect(6) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(6) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit8.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(7) = False And turn = 1 Then
            BlueSelect(7) = True
        Else
            BlueSelect(7) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(7) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit9.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(8) = False And turn = 1 Then
            BlueSelect(8) = True
        Else
            BlueSelect(8) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(8) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit10.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(9) = False And turn = 1 Then
            BlueSelect(9) = True
        Else
            BlueSelect(9) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(9) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit11.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(10) = False And turn = 1 Then
            BlueSelect(10) = True
        Else
            BlueSelect(10) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(10) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit12.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(11) = False And turn = 1 Then
            BlueSelect(11) = True
        Else
            BlueSelect(11) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(11) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit13.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(12) = False And turn = 1 Then
            BlueSelect(12) = True
        Else
            BlueSelect(12) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(12) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit14.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(13) = False And turn = 1 Then
            BlueSelect(13) = True
        Else
            BlueSelect(13) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(13) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit15.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(14) = False And turn = 1 Then
            BlueSelect(14) = True
        Else
            BlueSelect(14) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(14) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit16.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(15) = False And turn = 1 Then
            BlueSelect(15) = True
        Else
            BlueSelect(15) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(15) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit17.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(16) = False And turn = 1 Then
            BlueSelect(16) = True
        Else
            BlueSelect(16) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(16) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit18.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(17) = False And turn = 1 Then
            BlueSelect(17) = True
        Else
            BlueSelect(17) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(17) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit19.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(18) = False And turn = 1 Then
            BlueSelect(18) = True
        Else
            BlueSelect(18) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(18) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit20.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(19) = False And turn = 1 Then
            BlueSelect(19) = True
        Else
            BlueSelect(19) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(19) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit21.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(20) = False And turn = False Then
            BlueSelect(20) = True
        Else
            BlueSelect(20) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(20) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit22.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(21) = False And turn = 1 Then
            BlueSelect(21) = True
        Else
            BlueSelect(21) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(21) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit23.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(22) = False And turn = 1 Then
            BlueSelect(22) = True
        Else
            BlueSelect(22) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(22) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit24.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(23) = False And turn = 1 Then
            BlueSelect(23) = True
        Else
            BlueSelect(23) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(23) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit25.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(24) = False And turn = 1 Then
            BlueSelect(24) = True
        Else
            BlueSelect(24) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(4) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit26.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(25) = False And turn = 1 Then
            BlueSelect(25) = True
        Else
            BlueSelect(25) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(25) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit27.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(26) = False And turn = 1 Then
            BlueSelect(26) = True
        Else
            BlueSelect(26) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(26) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit28.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(27) = False And turn = 1 Then
            BlueSelect(27) = True
        Else
            BlueSelect(27) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(27) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit29.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(28) = False And turn = 1 Then
            BlueSelect(28) = True
        Else
            BlueSelect(28) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(28) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit30.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(29) = False And turn = 1 Then
            BlueSelect(29) = True
        Else
            BlueSelect(29) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(29) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit31.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(30) = False And turn = 1 Then
            BlueSelect(30) = True
        Else
            BlueSelect(30) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(30) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit32.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(31) = False And turn = 1 Then
            BlueSelect(31) = True
        Else
            BlueSelect(31) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(31) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit33.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(32) = False And turn = 1 Then
            BlueSelect(32) = True
        Else
            BlueSelect(32) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(32) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit34.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(33) = False And turn = 1 Then
            BlueSelect(33) = True
        Else
            BlueSelect(33) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(33) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit35.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(34) = False And turn = 1 Then
            BlueSelect(34) = True
        Else
            BlueSelect(34) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(34) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit36.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(35) = False And turn = 1 Then
            BlueSelect(35) = True
        Else
            BlueSelect(35) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(35) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit37.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(36) = False And turn = 1 Then
            BlueSelect(36) = True
        Else
            BlueSelect(36) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(36) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit38.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(37) = False And turn = 1 Then
            BlueSelect(37) = True
        Else
            BlueSelect(37) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(37) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit39.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(38) = False And turn = 1 Then
            BlueSelect(38) = True
        Else
            BlueSelect(38) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(38) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit40.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(39) = False And turn = 1 Then
            BlueSelect(39) = True
        Else
            BlueSelect(38) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(39) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit41.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(40) = False And turn = 1 Then
            BlueSelect(40) = True
        Else
            BlueSelect(40) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(40) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit42.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(41) = False And turn = 1 Then
            BlueSelect(41) = True
        Else
            BlueSelect(41) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(41) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit43.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(42) = False And turn = 1 Then
            BlueSelect(42) = True
        Else
            BlueSelect(42) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(42) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit44.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(43) = False And turn = 1 Then
            BlueSelect(43) = True
        Else
            BlueSelect(43) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(43) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit45.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(44) = False And turn = 1 Then
            BlueSelect(44) = True
        Else
            BlueSelect(44) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(44) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit46.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(45) = False And turn = 1 Then
            BlueSelect(45) = True
        Else
            BlueSelect(45) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(45) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit47.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(46) = False And turn = 1 Then
            BlueSelect(46) = True
        Else
            BlueSelect(46) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(46) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit48.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(47) = False And turn = 1 Then
            BlueSelect(47) = True
        Else
            BlueSelect(47) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(47) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit49.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(48) = False And turn = 1 Then
            BlueSelect(48) = True
        Else
            BlueSelect(48) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(48) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblBlueUnit50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit50.Click
        If turn = 1 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(49) = False And turn = 1 Then
            BlueSelect(49) = True
        Else
            BlueSelect(49) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(49) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub RedDead_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedDead.Tick
        For j = 0 To 49
            If RedUnitStatus(j) = False Then
                If j = 0 Then
                    lblRedUnit1.Location = New Point(400, 415)
                    lblRedUnit1.Visible = False
                    lblRedUnit1.Enabled = False
                ElseIf j = 1 Then
                    lblRedUnit2.Location = New Point(400, 415)
                    lblRedUnit2.Visible = False
                    lblRedUnit2.Enabled = False
                ElseIf j = 2 Then
                    lblRedUnit3.Location = New Point(400, 415)
                    lblRedUnit3.Visible = False
                    lblRedUnit3.Enabled = False
                ElseIf j = 3 Then
                    lblRedUnit4.Location = New Point(400, 415)
                    lblRedUnit4.Visible = False
                    lblRedUnit4.Enabled = False
                ElseIf j = 4 Then
                    lblRedUnit5.Location = New Point(400, 415)
                    lblRedUnit5.Visible = False
                    lblRedUnit5.Enabled = False
                ElseIf j = 5 Then
                    lblRedUnit6.Location = New Point(400, 415)
                    lblRedUnit6.Visible = False
                    lblRedUnit6.Enabled = False
                ElseIf j = 6 Then
                    lblRedUnit7.Location = New Point(400, 415)
                    lblRedUnit7.Visible = False
                    lblRedUnit7.Enabled = False
                ElseIf j = 7 Then
                    lblRedUnit8.Location = New Point(400, 415)
                    lblRedUnit8.Visible = False
                    lblRedUnit8.Enabled = False
                ElseIf j = 8 Then
                    lblRedUnit9.Location = New Point(400, 415)
                    lblRedUnit9.Visible = False
                    lblRedUnit9.Enabled = False
                ElseIf j = 9 Then
                    lblRedUnit10.Location = New Point(400, 415)
                    lblRedUnit10.Visible = False
                    lblRedUnit10.Enabled = False
                ElseIf j = 10 Then
                    lblRedUnit11.Location = New Point(400, 415)
                    lblRedUnit11.Visible = False
                    lblRedUnit11.Enabled = False
                ElseIf j = 11 Then
                    lblRedUnit12.Location = New Point(400, 415)
                    lblRedUnit12.Visible = False
                    lblRedUnit12.Enabled = False
                ElseIf j = 12 Then
                    lblRedUnit13.Location = New Point(400, 415)
                    lblRedUnit13.Visible = False
                    lblRedUnit13.Enabled = False
                ElseIf j = 13 Then
                    lblRedUnit14.Location = New Point(400, 415)
                    lblRedUnit14.Visible = False
                    lblRedUnit14.Enabled = False
                ElseIf j = 14 Then
                    lblRedUnit15.Location = New Point(400, 415)
                    lblRedUnit15.Visible = False
                    lblRedUnit15.Enabled = False
                ElseIf j = 15 Then
                    lblRedUnit16.Location = New Point(400, 415)
                    lblRedUnit16.Visible = False
                    lblRedUnit16.Enabled = False
                ElseIf j = 16 Then
                    lblRedUnit17.Location = New Point(400, 415)
                    lblRedUnit17.Visible = False
                    lblRedUnit17.Enabled = False
                ElseIf j = 17 Then
                    lblRedUnit18.Location = New Point(400, 415)
                    lblRedUnit18.Visible = False
                    lblRedUnit18.Enabled = False
                ElseIf j = 18 Then
                    lblRedUnit19.Location = New Point(400, 415)
                    lblRedUnit19.Visible = False
                    lblRedUnit19.Enabled = False
                ElseIf j = 19 Then
                    lblRedUnit20.Location = New Point(400, 415)
                    lblRedUnit20.Visible = False
                    lblRedUnit20.Enabled = False
                ElseIf j = 20 Then
                    lblRedUnit21.Location = New Point(400, 415)
                    lblRedUnit21.Visible = False
                    lblRedUnit21.Enabled = False
                ElseIf j = 21 Then
                    lblRedUnit22.Location = New Point(400, 415)
                    lblRedUnit22.Visible = False
                    lblRedUnit22.Enabled = False
                ElseIf j = 22 Then
                    lblRedUnit23.Location = New Point(400, 415)
                    lblRedUnit23.Visible = False
                    lblRedUnit23.Enabled = False
                ElseIf j = 23 Then
                    lblRedUnit24.Location = New Point(400, 415)
                    lblRedUnit24.Visible = False
                    lblRedUnit24.Enabled = False
                ElseIf j = 24 Then
                    lblRedUnit25.Location = New Point(400, 415)
                    lblRedUnit25.Visible = False
                    lblRedUnit25.Enabled = False
                ElseIf j = 25 Then
                    lblRedUnit26.Location = New Point(400, 415)
                    lblRedUnit26.Visible = False
                    lblRedUnit26.Enabled = False
                ElseIf j = 27 Then
                    lblRedUnit28.Location = New Point(400, 415)
                    lblRedUnit28.Visible = False
                    lblRedUnit28.Enabled = False
                ElseIf j = 28 Then
                    lblRedUnit29.Location = New Point(400, 415)
                    lblRedUnit29.Visible = False
                    lblRedUnit29.Enabled = False
                ElseIf j = 29 Then
                    lblRedUnit30.Location = New Point(400, 415)
                    lblRedUnit30.Visible = False
                    lblRedUnit30.Enabled = False
                ElseIf j = 30 Then
                    lblRedUnit31.Location = New Point(400, 415)
                    lblRedUnit31.Visible = False
                    lblRedUnit31.Enabled = False
                ElseIf j = 31 Then
                    lblRedUnit32.Location = New Point(400, 415)
                    lblRedUnit32.Visible = False
                    lblRedUnit32.Enabled = False
                ElseIf j = 32 Then
                    lblRedUnit33.Location = New Point(400, 415)
                    lblRedUnit33.Visible = False
                    lblRedUnit33.Enabled = False
                ElseIf j = 33 Then
                    lblRedUnit34.Location = New Point(400, 415)
                    lblRedUnit34.Visible = False
                    lblRedUnit34.Enabled = False
                ElseIf j = 34 Then
                    lblRedUnit35.Location = New Point(400, 415)
                    lblRedUnit35.Visible = False
                    lblRedUnit35.Enabled = False
                ElseIf j = 35 Then
                    lblRedUnit36.Location = New Point(400, 415)
                    lblRedUnit36.Visible = False
                    lblRedUnit36.Enabled = False
                ElseIf j = 36 Then
                    lblRedUnit37.Location = New Point(400, 415)
                    lblRedUnit37.Visible = False
                    lblRedUnit37.Enabled = False
                ElseIf j = 37 Then
                    lblRedUnit38.Location = New Point(400, 415)
                    lblRedUnit38.Visible = False
                    lblRedUnit38.Enabled = False
                ElseIf j = 38 Then
                    lblRedUnit39.Location = New Point(400, 415)
                    lblRedUnit39.Visible = False
                    lblRedUnit39.Enabled = False
                ElseIf j = 39 Then
                    lblRedUnit40.Location = New Point(400, 415)
                    lblRedUnit40.Visible = False
                    lblRedUnit40.Enabled = False
                ElseIf j = 40 Then
                    lblRedUnit41.Location = New Point(400, 415)
                    lblRedUnit41.Visible = False
                    lblRedUnit41.Enabled = False
                ElseIf j = 41 Then
                    lblRedUnit42.Location = New Point(400, 415)
                    lblRedUnit42.Visible = False
                    lblRedUnit42.Enabled = False
                ElseIf j = 42 Then
                    lblRedUnit43.Location = New Point(400, 415)
                    lblRedUnit43.Visible = False
                    lblRedUnit43.Enabled = False
                ElseIf j = 43 Then
                    lblRedUnit44.Location = New Point(400, 415)
                    lblRedUnit44.Visible = False
                    lblRedUnit44.Enabled = False
                ElseIf j = 44 Then
                    lblRedUnit45.Location = New Point(400, 415)
                    lblRedUnit45.Visible = False
                    lblRedUnit45.Enabled = False
                ElseIf j = 45 Then
                    lblRedUnit46.Location = New Point(400, 415)
                    lblRedUnit46.Visible = False
                    lblRedUnit46.Enabled = False
                ElseIf j = 46 Then
                    lblRedUnit47.Location = New Point(400, 415)
                    lblRedUnit47.Visible = False
                    lblRedUnit47.Enabled = False
                ElseIf j = 47 Then
                    lblRedUnit48.Location = New Point(400, 415)
                    lblRedUnit48.Visible = False
                    lblRedUnit48.Enabled = False
                ElseIf j = 48 Then
                    lblRedUnit49.Location = New Point(400, 415)
                    lblRedUnit49.Visible = False
                    lblRedUnit49.Enabled = False
                ElseIf j = 49 Then
                    lblRedUnit50.Location = New Point(400, 415)
                    lblRedUnit50.Visible = False
                    lblRedUnit50.Enabled = False
                End If

            End If
        Next
    End Sub

    Private Sub RedUnitClick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedUnitClick.Tick

        If RedSelect(0) = True And turn = 2 Then
            lblRedUnit1.ForeColor = Color.Yellow
        ElseIf RedUnitDone(0) = True Then
            lblRedUnit1.ForeColor = Color.Violet
        Else
            lblRedUnit1.ForeColor = Color.Black
        End If
        If RedSelect(1) = True And turn = 2 Then
            lblRedUnit2.ForeColor = Color.Yellow
        ElseIf RedUnitDone(1) = True Then
            lblRedUnit2.ForeColor = Color.Violet
        Else
            lblRedUnit2.ForeColor = Color.Black
        End If
        If RedSelect(2) = True And turn = 2 Then
            lblRedUnit3.ForeColor = Color.Yellow
        ElseIf RedUnitDone(2) = True Then
            lblRedUnit3.ForeColor = Color.Violet
        Else
            lblRedUnit3.ForeColor = Color.Black
        End If
        If RedSelect(3) = True And turn = 2 Then
            lblRedUnit4.ForeColor = Color.Yellow
        ElseIf RedUnitDone(3) = True Then
            lblRedUnit4.ForeColor = Color.Violet
        Else
            lblRedUnit4.ForeColor = Color.Black
        End If
        If RedSelect(4) = True And turn = 2 Then
            lblRedUnit5.ForeColor = Color.Yellow
        ElseIf RedUnitDone(4) = True Then
            lblRedUnit5.ForeColor = Color.Violet
        Else
            lblRedUnit5.ForeColor = Color.Black
        End If
        If RedSelect(5) = True And turn = 2 Then
            lblRedUnit6.ForeColor = Color.Yellow
        ElseIf RedUnitDone(5) = True Then
            lblRedUnit6.ForeColor = Color.Violet
        Else
            lblRedUnit6.ForeColor = Color.Black
        End If
        If RedSelect(6) = True And turn = 2 Then
            lblRedUnit7.ForeColor = Color.Yellow
        ElseIf RedUnitDone(6) = True Then
            lblRedUnit7.ForeColor = Color.Violet
        Else
            lblRedUnit7.ForeColor = Color.Black
        End If
        If RedSelect(7) = True And turn = 2 Then
            lblRedUnit8.ForeColor = Color.Yellow
        ElseIf RedUnitDone(7) = True Then
            lblRedUnit8.ForeColor = Color.Violet
        Else
            lblRedUnit8.ForeColor = Color.Black
        End If
        If RedSelect(8) = True And turn = 2 Then
            lblRedUnit9.ForeColor = Color.Yellow
        ElseIf RedUnitDone(8) = True Then
            lblRedUnit9.ForeColor = Color.Violet
        Else
            lblRedUnit9.ForeColor = Color.Black
        End If
        If RedSelect(9) = True And turn = 2 Then
            lblRedUnit10.ForeColor = Color.Yellow
        ElseIf RedUnitDone(9) = True Then
            lblRedUnit10.ForeColor = Color.Violet
        Else
            lblRedUnit10.ForeColor = Color.Black
        End If
        If RedSelect(10) = True And turn = 2 Then
            lblRedUnit11.ForeColor = Color.Yellow
        ElseIf RedUnitDone(10) = True Then
            lblRedUnit11.ForeColor = Color.Violet
        Else
            lblRedUnit11.ForeColor = Color.Black
        End If
        If RedSelect(11) = True And turn = 2 Then
            lblRedUnit12.ForeColor = Color.Yellow
        ElseIf RedUnitDone(11) = True Then
            lblRedUnit12.ForeColor = Color.Violet
        Else
            lblRedUnit12.ForeColor = Color.Black
        End If
        If RedSelect(12) = True And turn = 2 Then
            lblRedUnit13.ForeColor = Color.Yellow
        ElseIf RedUnitDone(12) = True Then
            lblRedUnit13.ForeColor = Color.Violet
        Else
            lblRedUnit13.ForeColor = Color.Black
        End If
        If RedSelect(13) = True And turn = 2 Then
            lblRedUnit14.ForeColor = Color.Yellow
        ElseIf RedUnitDone(13) = True Then
            lblRedUnit14.ForeColor = Color.Violet
        Else
            lblRedUnit14.ForeColor = Color.Black
        End If
        If RedSelect(14) = True And turn = 2 Then
            lblRedUnit15.ForeColor = Color.Yellow
        ElseIf RedUnitDone(14) = True Then
            lblRedUnit15.ForeColor = Color.Violet
        Else
            lblRedUnit15.ForeColor = Color.Black
        End If
        If RedSelect(15) = True And turn = 2 Then
            lblRedUnit16.ForeColor = Color.Yellow
        ElseIf RedUnitDone(15) = True Then
            lblRedUnit16.ForeColor = Color.Violet
        Else
            lblRedUnit16.ForeColor = Color.Black
        End If
        If RedSelect(16) = True And turn = 2 Then
            lblRedUnit17.ForeColor = Color.Yellow
        ElseIf RedUnitDone(16) = True Then
            lblRedUnit17.ForeColor = Color.Violet
        Else
            lblRedUnit17.ForeColor = Color.Black
        End If
        If RedSelect(17) = True And turn = 2 Then
            lblRedUnit18.ForeColor = Color.Yellow
        ElseIf RedUnitDone(17) = True Then
            lblRedUnit18.ForeColor = Color.Violet
        Else
            lblRedUnit18.ForeColor = Color.Black
        End If
        If RedSelect(18) = True And turn = 2 Then
            lblRedUnit19.ForeColor = Color.Yellow
        ElseIf RedUnitDone(18) = True Then
            lblRedUnit19.ForeColor = Color.Violet
        Else
            lblRedUnit19.ForeColor = Color.Black
        End If
        If RedSelect(19) = True And turn = 2 Then
            lblRedUnit20.ForeColor = Color.Yellow
        ElseIf RedUnitDone(19) = True Then
            lblRedUnit20.ForeColor = Color.Violet
        Else
            lblRedUnit20.ForeColor = Color.Black
        End If
        If RedSelect(20) = True And turn = 2 Then
            lblRedUnit21.ForeColor = Color.Yellow
        ElseIf RedUnitDone(20) = True Then
            lblRedUnit21.ForeColor = Color.Violet
        Else
            lblRedUnit21.ForeColor = Color.Black

        End If
        If RedSelect(21) = True And turn = 2 Then
            lblRedUnit22.ForeColor = Color.Yellow
        ElseIf RedUnitDone(21) = True Then
            lblRedUnit22.ForeColor = Color.Violet
        Else
            lblRedUnit22.ForeColor = Color.Black
        End If
        If RedSelect(22) = True And turn = 2 Then
            lblRedUnit23.ForeColor = Color.Yellow
        ElseIf RedUnitDone(22) = True Then
            lblRedUnit23.ForeColor = Color.Violet
        Else
            lblRedUnit23.ForeColor = Color.Black
        End If
        If RedSelect(23) = True And turn = 2 Then
            lblRedUnit24.ForeColor = Color.Yellow
        ElseIf RedUnitDone(23) = True Then
            lblRedUnit24.ForeColor = Color.Violet
        Else
            lblRedUnit24.ForeColor = Color.Black
        End If
        If RedSelect(24) = True And turn = 2 Then
            lblRedUnit25.ForeColor = Color.Yellow
        ElseIf RedUnitDone(24) = True Then
            lblRedUnit25.ForeColor = Color.Violet
        Else
            lblRedUnit25.ForeColor = Color.Black
        End If
        If RedSelect(25) = True And turn = 2 Then
            lblRedUnit26.ForeColor = Color.Yellow
        ElseIf RedUnitDone(25) = True Then
            lblRedUnit26.ForeColor = Color.Violet
        Else
            lblRedUnit26.ForeColor = Color.Black
        End If
        If RedSelect(26) = True And turn = 2 Then
            lblRedUnit27.ForeColor = Color.Yellow
        ElseIf RedUnitDone(26) = True Then
            lblRedUnit27.ForeColor = Color.Violet
        Else
            lblRedUnit27.ForeColor = Color.Black
        End If
        If RedSelect(27) = True And turn = 2 Then
            lblRedUnit28.ForeColor = Color.Yellow
        ElseIf RedUnitDone(27) = True Then
            lblRedUnit28.ForeColor = Color.Violet
        Else
            lblRedUnit28.ForeColor = Color.Black
        End If
        If RedSelect(28) = True And turn = 2 Then
            lblRedUnit29.ForeColor = Color.Yellow
        ElseIf RedUnitDone(28) = True Then
            lblRedUnit29.ForeColor = Color.Violet
        Else
            lblRedUnit29.ForeColor = Color.Black
        End If
        If RedSelect(29) = True And turn = 2 Then
            lblRedUnit30.ForeColor = Color.Yellow
        ElseIf RedUnitDone(29) = True Then
            lblRedUnit30.ForeColor = Color.Violet
        Else
            lblRedUnit30.ForeColor = Color.Black
        End If
        If RedSelect(30) = True And turn = 2 Then
            lblRedUnit31.ForeColor = Color.Yellow
        ElseIf RedUnitDone(30) = True Then
            lblRedUnit31.ForeColor = Color.Violet
        Else
            lblRedUnit31.ForeColor = Color.Black
        End If
        If RedSelect(31) = True And turn = 2 Then
            lblRedUnit32.ForeColor = Color.Yellow
        ElseIf RedUnitDone(31) = True Then
            lblRedUnit32.ForeColor = Color.Violet
        Else
            lblRedUnit32.ForeColor = Color.Black
        End If
        If RedSelect(32) = True And turn = 2 Then
            lblRedUnit33.ForeColor = Color.Yellow
        ElseIf RedUnitDone(32) = True Then
            lblRedUnit33.ForeColor = Color.Violet
        Else
            lblRedUnit33.ForeColor = Color.Black
        End If
        If RedSelect(33) = True And turn = 2 Then
            lblRedUnit34.ForeColor = Color.Yellow
        ElseIf RedUnitDone(33) = True Then
            lblRedUnit34.ForeColor = Color.Violet
        Else
            lblRedUnit34.ForeColor = Color.Black
        End If
        If RedSelect(34) = True And turn = 2 Then
            lblRedUnit35.ForeColor = Color.Yellow
        ElseIf RedUnitDone(34) = True Then
            lblRedUnit35.ForeColor = Color.Violet
        Else
            lblRedUnit35.ForeColor = Color.Black
        End If
        If RedSelect(35) = True And turn = 2 Then
            lblRedUnit36.ForeColor = Color.Yellow
        ElseIf RedUnitDone(35) = True Then
            lblRedUnit36.ForeColor = Color.Violet
        Else
            lblRedUnit36.ForeColor = Color.Black
        End If
        If RedSelect(36) = True And turn = 2 Then
            lblRedUnit37.ForeColor = Color.Yellow
        ElseIf RedUnitDone(36) = True Then
            lblRedUnit37.ForeColor = Color.Violet
        Else
            lblRedUnit37.ForeColor = Color.Black
        End If
        If RedSelect(37) = True And turn = 2 Then
            lblRedUnit38.ForeColor = Color.Yellow
        ElseIf RedUnitDone(37) = True Then
            lblRedUnit38.ForeColor = Color.Violet
        Else
            lblRedUnit38.ForeColor = Color.Black
        End If
        If RedSelect(38) = True And turn = 2 Then
            lblRedUnit39.ForeColor = Color.Yellow
        ElseIf RedUnitDone(38) = True Then
            lblRedUnit39.ForeColor = Color.Violet
        Else
            lblRedUnit39.ForeColor = Color.Black
        End If
        If RedSelect(39) = True And turn = 2 Then
            lblRedUnit40.ForeColor = Color.Yellow
        ElseIf RedUnitDone(39) = True Then
            lblRedUnit40.ForeColor = Color.Violet
        Else
            lblRedUnit40.ForeColor = Color.Black
        End If
        If RedSelect(40) = True And turn = 2 Then
            lblRedUnit41.ForeColor = Color.Yellow
        ElseIf RedUnitDone(40) = True Then
            lblRedUnit41.ForeColor = Color.Violet
        Else
            lblRedUnit41.ForeColor = Color.Black
        End If

        If RedSelect(41) = True And turn = 2 Then
            lblRedUnit42.ForeColor = Color.Yellow
        ElseIf RedUnitDone(41) = True Then
            lblRedUnit42.ForeColor = Color.Violet
        Else
            lblRedUnit42.ForeColor = Color.Black
        End If
        If RedSelect(42) = True And turn = 2 Then
            lblRedUnit43.ForeColor = Color.Yellow
        ElseIf RedUnitDone(42) = True Then
            lblRedUnit43.ForeColor = Color.Violet
        Else
            lblRedUnit43.ForeColor = Color.Black
        End If
        If RedSelect(43) = True And turn = 2 Then
            lblRedUnit44.ForeColor = Color.Yellow
        ElseIf RedUnitDone(43) = True Then
            lblRedUnit44.ForeColor = Color.Violet
        Else
            lblRedUnit44.ForeColor = Color.Black
        End If
        If RedSelect(44) = True And turn = 2 Then
            lblRedUnit45.ForeColor = Color.Yellow
        ElseIf RedUnitDone(44) = True Then
            lblRedUnit45.ForeColor = Color.Violet
        Else
            lblRedUnit45.ForeColor = Color.Black
        End If
        If RedSelect(45) = True And turn = 2 Then
            lblRedUnit46.ForeColor = Color.Yellow
        ElseIf RedUnitDone(45) = True Then
            lblRedUnit46.ForeColor = Color.Violet
        Else
            lblRedUnit46.ForeColor = Color.Black
        End If
        If RedSelect(46) = True And turn = 2 Then
            lblRedUnit47.ForeColor = Color.Yellow
        ElseIf RedUnitDone(46) = True Then
            lblRedUnit47.ForeColor = Color.Violet
        Else
            lblRedUnit47.ForeColor = Color.Black
        End If
        If RedSelect(47) = True And turn = 2 Then
            lblRedUnit48.ForeColor = Color.Yellow
        ElseIf RedUnitDone(47) = True Then
            lblRedUnit48.ForeColor = Color.Violet
        Else
            lblRedUnit48.ForeColor = Color.Black
        End If
        If RedSelect(48) = True And turn = 2 Then
            lblRedUnit49.ForeColor = Color.Yellow
        ElseIf RedUnitDone(48) = True Then
            lblRedUnit49.ForeColor = Color.Violet
        Else
            lblRedUnit49.ForeColor = Color.Black
        End If
        If RedSelect(49) = True And turn = 2 Then
            lblRedUnit50.ForeColor = Color.Yellow
        ElseIf RedUnitDone(49) = True Then
            lblRedUnit50.ForeColor = Color.Violet
        Else
            lblRedUnit50.ForeColor = Color.Black
        End If

    End Sub

    Private Sub lblRedUnit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit1.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(0) = False And turn = 2 Then
            RedSelect(0) = True
        Else
            RedSelect(0) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(0) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit2.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(1) = False And turn = 2 Then
            RedSelect(1) = True
        Else
            RedSelect(1) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(1) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit3.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(2) = False And turn = 2 Then
            RedSelect(2) = True
        Else
            RedSelect(2) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(2) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit4.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(3) = False And turn = 2 Then
            RedSelect(3) = True
        Else
            RedSelect(3) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(3) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit5.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(4) = False And turn = 2 Then
            RedSelect(4) = True
        Else
            RedSelect(4) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(4) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit6.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(5) = False And turn = 2 Then
            RedSelect(5) = True
        Else
            RedSelect(5) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(5) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit7.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(6) = False And turn = 2 Then
            RedSelect(6) = True
        Else
            RedSelect(6) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(6) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit8.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(7) = False And turn = 2 Then
            RedSelect(7) = True
        Else
            RedSelect(7) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(7) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit9.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(8) = False And turn = 2 Then
            RedSelect(8) = True
        Else
            RedSelect(8) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(8) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit10.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(9) = False And turn = 2 Then
            RedSelect(9) = True
        Else
            RedSelect(9) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(9) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit11.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(10) = False And turn = 2 Then
            RedSelect(10) = True
        Else
            RedSelect(10) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(10) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit12.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(11) = False And turn = 2 Then
            RedSelect(11) = True
        Else
            RedSelect(11) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(11) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit13.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(12) = False And turn = 2 Then
            RedSelect(12) = True
        Else
            RedSelect(12) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(12) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit14.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(13) = False And turn = 2 Then
            RedSelect(13) = True
        Else
            RedSelect(13) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(13) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit15.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(14) = False And turn = 2 Then
            RedSelect(14) = True
        Else
            RedSelect(14) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(14) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit16.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(15) = False And turn = 2 Then
            RedSelect(15) = True
        Else
            RedSelect(15) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(15) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit17.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(16) = False And turn = 2 Then
            RedSelect(16) = True
        Else
            RedSelect(16) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(16) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit18.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(17) = False And turn = 2 Then
            RedSelect(17) = True
        Else
            RedSelect(17) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(17) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit19.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(18) = False And turn = 2 Then
            RedSelect(18) = True
        Else
            RedSelect(18) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(18) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit20.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(19) = False And turn = 2 Then
            RedSelect(19) = True
        Else
            RedSelect(19) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(19) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit21.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(20) = False And turn = 2 Then
            RedSelect(20) = True
        Else
            RedSelect(20) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(20) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit22.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(21) = False And turn = 2 Then
            RedSelect(21) = True
        Else
            RedSelect(21) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(21) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub


    Private Sub lblRedUnit23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit23.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(22) = False And turn = 2 Then
            RedSelect(22) = True
        Else
            RedSelect(22) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(22) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit24.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(23) = False And turn = 2 Then
            RedSelect(23) = True
        Else
            RedSelect(23) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(23) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit25.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(24) = False And turn = 2 Then
            RedSelect(24) = True
        Else
            RedSelect(24) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(24) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit26.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(25) = False And turn = 2 Then
            RedSelect(25) = True
        Else
            RedSelect(25) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(25) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit27.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(26) = False And turn = 2 Then
            RedSelect(26) = True
        Else
            RedSelect(26) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(26) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit28.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(27) = False And turn = 2 Then
            RedSelect(27) = True
        Else
            RedSelect(27) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(27) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit29.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(28) = False And turn = 2 Then
            RedSelect(28) = True
        Else
            RedSelect(28) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(28) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit30.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(29) = False And turn = 2 Then
            RedSelect(29) = True
        Else
            RedSelect(29) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(29) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit31.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(30) = False And turn = 2 Then
            RedSelect(30) = True
        Else
            RedSelect(30) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(30) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit32.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(31) = False And turn = 2 Then
            RedSelect(31) = True
        Else
            RedSelect(31) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(31) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit33.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(32) = False And turn = 2 Then
            RedSelect(32) = True
        Else
            RedSelect(32) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(32) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit34.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(33) = False And turn = 2 Then
            RedSelect(33) = True
        Else
            RedSelect(33) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(33) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit35.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(34) = False And turn = 2 Then
            RedSelect(34) = True
        Else
            RedSelect(34) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(34) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit36.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(35) = False And turn = 2 Then
            RedSelect(35) = True
        Else
            RedSelect(35) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(35) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit37.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(36) = False And turn = 2 Then
            RedSelect(36) = True
        Else
            RedSelect(36) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(36) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit38.Click
        'Clicking logic to tell what tile the player is clicking on for player 2'
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(37) = False And turn = 2 Then
            RedSelect(37) = True
        Else
            RedSelect(37) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(37) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit39.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(38) = False And turn = 2 Then
            RedSelect(38) = True
        Else
            RedSelect(38) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(38) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit40.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(39) = False And turn = 2 Then
            RedSelect(39) = True
        Else
            RedSelect(39) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(39) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub
    Private Sub lblRedUnit41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit41.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(40) = False And turn = 2 Then
            RedSelect(40) = True
        Else
            RedSelect(40) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(40) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub
    Private Sub lblRedUnit42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit42.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(41) = False And turn = 2 Then
            RedSelect(41) = True
        Else
            RedSelect(41) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(41) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub
    Private Sub lblRedUnit43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit43.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(42) = False And turn = 2 Then
            RedSelect(42) = True
        Else
            RedSelect(42) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(42) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit44.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(43) = False And turn = 2 Then
            RedSelect(43) = True
        Else
            RedSelect(43) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(43) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub



    Private Sub lblRedUnit45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit45.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(44) = False And turn = 2 Then
            RedSelect(44) = True
        Else
            RedSelect(44) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(44) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit46.Click
        If turn = 2 Then
            attackrangex = mpx
            good = False
            attackrangey = mpy
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(45) = False And turn = 2 Then
            RedSelect(45) = True
        Else
            RedSelect(45) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(45) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit47.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(46) = False And turn = 2 Then
            RedSelect(46) = True
        Else
            RedSelect(46) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(46) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit48.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(47) = False And turn = 2 Then
            RedSelect(47) = True
        Else
            RedSelect(47) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(47) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub lblRedUnit50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedUnit50.Click
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(49) = False And turn = 2 Then
            RedSelect(49) = True
        Else
            RedSelect(49) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(49) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub
    Private Sub lblRedUnit49_Click()
        If turn = 2 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 2 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If RedSelect(48) = False And turn = 2 Then
            RedSelect(48) = True
        Else
            RedSelect(48) = False
        End If
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            redattack(48) = True
        ElseIf turn = 1 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub Form1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        go = True
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
        End If
    End Sub
    Private Sub moveUnit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveUnit.Tick
        Dim changeinx As Integer
        Dim changeiny As Integer
        changeinx = collum - prevcollum
        changeiny = row - prevrow
        If changeinx > 2 Or changeinx < -2 Or changeiny > 2 Or changeiny < -2 Then
            go = False
        End If
        If row = 11 And collum <= 8 And collum >= 5 Then
            go = False
        End If
        If collum = 0 Then
            go = False
        End If
        If row = 22 And collum <= 5 Then
            go = False
        End If
        If row = 22 And collum >= 11 Then
            go = False
        End If
        If collum = 13 Then
            go = False
        End If
        If collum = 1 Or collum = 3 Or collum = 5 Or collum = 7 Or collum = 9 Or collum = 11 Or collum = 13 Then
            odd = 10
        Else
            odd = 0
        End If
        For j = 0 To 49
            If BlueSelect(j) = True And go = True Then
                If j = 0 Then
                    lblBlueUnit1.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 1 Then
                    lblBlueUnit2.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 2 Then
                    lblBlueUnit3.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 3 Then
                    lblBlueUnit4.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 4 Then
                    lblBlueUnit5.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 5 Then
                    lblBlueUnit6.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 6 Then
                    lblBlueUnit7.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 7 Then
                    lblBlueUnit8.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 8 Then
                    lblBlueUnit9.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 9 Then
                    lblBlueUnit10.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 10 Then
                    lblBlueUnit11.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 11 Then
                    lblBlueUnit12.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 12 Then
                    lblBlueUnit13.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 13 Then
                    lblBlueUnit14.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 14 Then
                    lblBlueUnit15.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 15 Then
                    lblBlueUnit16.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 16 Then
                    lblBlueUnit17.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 17 Then
                    lblBlueUnit18.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 18 Then
                    lblBlueUnit19.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 19 Then
                    lblBlueUnit20.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 20 Then
                    lblBlueUnit21.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 21 Then
                    lblBlueUnit22.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 22 Then
                    lblBlueUnit23.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 23 Then
                    lblBlueUnit24.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 24 Then
                    lblBlueUnit25.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 25 Then
                    lblBlueUnit26.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 26 Then
                    lblBlueUnit27.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 27 Then
                    lblBlueUnit28.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 28 Then
                    lblBlueUnit29.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 29 Then
                    lblBlueUnit30.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 30 Then
                    lblBlueUnit31.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 31 Then
                    lblBlueUnit32.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 32 Then
                    lblBlueUnit33.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 33 Then
                    lblBlueUnit34.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 34 Then
                    lblBlueUnit35.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 35 Then
                    lblBlueUnit36.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 36 Then
                    lblBlueUnit37.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 37 Then
                    lblBlueUnit38.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 38 Then
                    lblBlueUnit39.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 39 Then
                    lblBlueUnit40.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 40 Then
                    lblBlueUnit41.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 41 Then
                    lblBlueUnit42.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 42 Then
                    lblBlueUnit43.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 43 Then
                    lblBlueUnit44.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 44 Then
                    lblBlueUnit45.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 45 Then
                    lblBlueUnit46.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 46 Then
                    lblBlueUnit47.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 47 Then
                    lblBlueUnit48.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 48 Then
                    lblBlueUnit49.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                ElseIf j = 49 Then
                    lblBlueUnit50.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    BlueUnitDone(j) = True
                    go = False
                End If
            End If
        Next
        For j = 0 To 49
            If RedSelect(j) = True And go = True Then
                If j = 0 Then
                    lblRedUnit1.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 1 Then
                    lblRedUnit2.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 2 Then
                    lblRedUnit3.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 3 Then
                    lblRedUnit4.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 4 Then
                    lblRedUnit5.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 5 Then
                    lblRedUnit6.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 6 Then
                    lblRedUnit7.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 7 Then
                    lblRedUnit8.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 8 Then
                    lblRedUnit9.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 9 Then
                    lblRedUnit10.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 10 Then
                    lblRedUnit11.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 11 Then
                    lblRedUnit12.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 12 Then
                    lblRedUnit13.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 13 Then
                    lblRedUnit14.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 14 Then
                    lblRedUnit15.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 15 Then
                    lblRedUnit16.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 16 Then
                    lblRedUnit17.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 17 Then
                    lblRedUnit18.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 18 Then
                    lblRedUnit19.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 19 Then
                    lblRedUnit20.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 20 Then
                    lblRedUnit21.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 21 Then
                    lblRedUnit22.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 22 Then
                    lblRedUnit23.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 23 Then
                    lblRedUnit24.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 24 Then
                    lblRedUnit25.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 25 Then
                    lblRedUnit26.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 26 Then
                    lblRedUnit27.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 27 Then
                    lblRedUnit28.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 28 Then
                    lblRedUnit29.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 29 Then
                    lblRedUnit30.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 30 Then
                    lblRedUnit31.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 31 Then
                    lblRedUnit32.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 32 Then
                    lblRedUnit33.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 33 Then
                    lblRedUnit34.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 34 Then
                    lblRedUnit35.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 35 Then
                    lblRedUnit36.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 36 Then
                    lblRedUnit37.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 37 Then
                    lblRedUnit38.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 38 Then
                    lblRedUnit39.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 39 Then
                    lblRedUnit40.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 40 Then
                    lblRedUnit41.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 41 Then
                    lblRedUnit42.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 42 Then
                    lblRedUnit43.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 43 Then
                    lblRedUnit44.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 44 Then
                    lblRedUnit45.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 45 Then
                    lblRedUnit46.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 46 Then
                    lblRedUnit47.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 47 Then
                    lblRedUnit48.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 48 Then
                    lblRedUnit49.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                ElseIf j = 49 Then
                    lblRedUnit50.Location = New Point(16 + collum * 24, (16 + row * 23) + odd)
                    RedUnitDone(j) = True
                    go = False
                End If
            End If
        Next
    End Sub
    Private Sub Form2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        mpx = (e.X)
        mpy = (e.Y)
        Label2.Text = (e.X & " " & e.Y)
    End Sub
    Public Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'resetting all the values so that the grid will be painted proporly
        Dim pointonex As Integer = 10
        Dim pointoney As Integer = 20
        Dim pointtwox As Integer = 20
        Dim pointtwoy As Integer = 10
        Dim pointthreex As Integer = 30
        Dim pointthreey As Integer = 10
        Dim pointfourx As Integer = 40
        Dim pointfoury As Integer = 20
        Dim pointfivex As Integer = 30
        Dim pointfivey As Integer = 30
        Dim pointsixx As Integer = 20
        Dim pointsixy As Integer = 30
        Dim waterchange As Integer = 1
        Dim waterchangerow As Integer = 1
        Dim flipflop As Integer = 10
        For h = 0 To patternheight

            'This for statement draws the tiles
            For j = 0 To patternwidth
                e.Graphics.FillPolygon(Brushes.Green, {New Point(pointonex, pointoney), New Point(pointtwox, pointtwoy), New Point(pointthreex, pointthreey), New Point(pointfourx, pointfoury), New Point(pointfivex, pointfivey), New Point(pointsixx, pointsixy)})
                e.Graphics.DrawPolygon(Pens.Black, {New Point(pointonex, pointoney), New Point(pointtwox, pointtwoy), New Point(pointthreex, pointthreey), New Point(pointfourx, pointfoury), New Point(pointfivex, pointfivey), New Point(pointsixx, pointsixy)})
                pointonex += changeinx
                pointtwox += changeinx
                pointthreex += changeinx
                pointfourx += changeinx
                pointfivex += changeinx
                pointsixx += changeinx
                If switch = True Then
                    pointoney -= changeiny
                    pointtwoy -= changeiny
                    pointthreey -= changeiny
                    pointfoury -= changeiny
                    pointfivey -= changeiny
                    pointsixy -= changeiny
                    switch = False
                Else
                    pointoney += 10
                    pointtwoy += 10
                    pointthreey += 10
                    pointfoury += 10
                    pointfivey += 10
                    pointsixy += 10
                    switch = True
                End If
            Next
            pointonex = 10
            pointtwox = 20
            pointthreex = 30
            pointfourx = 40
            pointfivex = 30
            pointsixx = 20

            pointoney += 23
            pointtwoy += 23
            pointthreey += 23
            pointfoury += 23
            pointfivey += 23
            pointsixy += 23
        Next
        ' water graphics
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(178, 283), New Point(188, 273), New Point(198, 273), New Point(208, 283), New Point(198, 293), New Point(188, 293)})
        e.Graphics.DrawPolygon(Pens.Black, {New Point(178, 283), New Point(188, 273), New Point(198, 273), New Point(208, 283), New Point(198, 293), New Point(188, 293)})
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(202, 273), New Point(212, 263), New Point(222, 263), New Point(232, 273), New Point(222, 283), New Point(212, 283)})
        e.Graphics.DrawPolygon(Pens.Black, {New Point(202, 273), New Point(212, 263), New Point(222, 263), New Point(232, 273), New Point(222, 283), New Point(212, 283)})
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(130, 283), New Point(140, 273), New Point(150, 273), New Point(160, 283), New Point(150, 293), New Point(140, 293)})
        e.Graphics.DrawPolygon(Pens.Black, {New Point(130, 283), New Point(140, 273), New Point(150, 273), New Point(160, 283), New Point(150, 293), New Point(140, 293)})
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(154, 273), New Point(164, 263), New Point(174, 263), New Point(184, 273), New Point(174, 283), New Point(164, 283)})
        e.Graphics.DrawPolygon(Pens.Black, {New Point(154, 273), New Point(164, 263), New Point(174, 263), New Point(184, 273), New Point(174, 283), New Point(164, 283)})
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(10, 20), New Point(20, 10), New Point(30, 10), New Point(40, 20), New Point(30, 30), New Point(20, 30)})
        e.Graphics.DrawPolygon(Pens.Black, {New Point(10, 20), New Point(20, 10), New Point(30, 10), New Point(40, 20), New Point(30, 30), New Point(20, 30)})
        For j = 0 To 21
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10, 20 + 23 * waterchange), New Point(20, 10 + 23 * waterchange), New Point(30, 10 + 23 * waterchange), New Point(40, 20 + 23 * waterchange), New Point(30, 30 + 23 * waterchange), New Point(20, 30 + 23 * waterchange)})
            waterchange += 1
        Next
        waterchange = 0
        For j = 0 To 22
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10 + 24 * 13, (20 + 23 * waterchange) + 10), New Point(20 + 24 * 13, (10 + 23 * waterchange) + 10), New Point(30 + 24 * 13, (10 + 23 * waterchange) + 10), New Point(40 + 24 * 13, (20 + 23 * waterchange) + 10), New Point(30 + 24 * 13, (30 + 23 * waterchange) + 10), New Point(20 + 24 * 13, (30 + 23 * waterchange) + 10)})
            waterchange += 1
        Next
        waterchange = 22
        For j = 0 To 4
            If waterchangerow = 1 Or waterchangerow = 3 Or waterchangerow = 5 Then
                flipflop = -10
            Else
                flipflop = 0
            End If
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(40 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop)})
            waterchangerow += 1
        Next
        waterchange = 22
        waterchangerow = 11
        For j = 0 To 1
            If waterchangerow = 11 Or waterchangerow = 13 Or waterchangerow = 15 Then
                flipflop = -10
            Else
                flipflop = 0
            End If
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(40 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop)})
            waterchangerow += 1
        Next
        waterchangerow = 0
        waterchange = 0
        For j = 0 To 6
            If waterchangerow = 9 Or waterchangerow = 7 Or waterchangerow = 5 Or waterchangerow = 3 Or waterchangerow = 1 Or waterchangerow = 11 Or waterchangerow = 13 Or waterchangerow = 15 Then
                flipflop = -10
            Else
                flipflop = 0
            End If
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(40 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop)})
            waterchangerow += 1
        Next
        e.Graphics.FillPolygon(Brushes.Blue, {New Point(202, 20), New Point(212, 10), New Point(222, 10), New Point(232, 20), New Point(222, 30), New Point(212, 30)})
        waterchange = 0
        waterchangerow = 10
        For j = 0 To 3
            If waterchangerow = 9 Or waterchangerow = 7 Or waterchangerow = 5 Or waterchangerow = 3 Or waterchangerow = 1 Or waterchangerow = 11 Or waterchangerow = 13 Or waterchangerow = 15 Then
                flipflop = -10
            Else
                flipflop = 0
            End If
            e.Graphics.FillPolygon(Brushes.Blue, {New Point(10 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (10 + 23 * waterchange) - flipflop), New Point(40 + 24 * waterchangerow, (20 + 23 * waterchange) - flipflop), New Point(30 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop), New Point(20 + 24 * waterchangerow, (30 + 23 * waterchange) - flipflop)})
            waterchangerow += 1
        Next
        'end of water graphics logic

    End Sub

    Private Sub lblBlueUnit1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlueUnit1.Click
        If turn = 1 Then
            attackrangex = mpx
            attackrangey = mpy
            good = False
        End If
        If turn = 1 Then
            go = False
        End If
        If mpx >= 10 And mpx <= 33 Then
            collum = 0
            prevcollum = 0
        ElseIf mpx > 33 And mpx <= 57 Then
            collum = 1
            prevcollum = 1
        ElseIf mpx > 57 And mpx <= 81 Then
            collum = 2
            prevcollum = 2
        ElseIf mpx > 81 And mpx <= 105 Then
            collum = 3
            prevcollum = 3
        ElseIf mpx > 105 And mpx <= 129 Then
            collum = 4
            prevcollum = 4
        ElseIf mpx > 129 And mpx <= 153 Then
            collum = 5
            prevcollum = 5
        ElseIf mpx > 153 And mpx <= 177 Then
            collum = 6
            prevcollum = 6
        ElseIf mpx > 177 And mpx <= 201 Then
            collum = 7
            prevcollum = 7
        ElseIf mpx > 201 And mpx <= 225 Then
            collum = 8
            prevcollum = 8
        ElseIf mpx > 225 And mpx <= 249 Then
            collum = 9
            prevcollum = 9
        ElseIf mpx > 249 And mpx <= 272 Then
            collum = 10
            prevcollum = 10
        ElseIf mpx > 272 And mpx <= 296 Then
            collum = 11
            prevcollum = 11
        ElseIf mpx > 296 And mpx <= 320 Then
            collum = 12
            prevcollum = 12
        ElseIf mpx > 320 And mpx <= 344 Then
            collum = 13
            prevcollum = 13
        End If
        If mpy > 10 And mpy <= 35 Then
            row = 0
            prevrow = 0
        ElseIf mpy > 35 And mpy <= 58 Then
            row = 1
            prevrow = 1
        ElseIf mpy > 58 And mpy <= 81 Then
            row = 2
            prevrow = 2
        ElseIf mpy > 81 And mpy <= 104 Then
            row = 3
            prevrow = 3
        ElseIf mpy > 104 And mpy <= 127 Then
            row = 4
            prevrow = 4
        ElseIf mpy > 127 And mpy <= 150 Then
            row = 5
            prevrow = 5
        ElseIf mpy > 150 And mpy <= 173 Then
            row = 6
            prevrow = 6
        ElseIf mpy > 173 And mpy <= 196 Then
            row = 7
            prevrow = 7
        ElseIf mpy > 196 And mpy <= 219 Then
            row = 8
            prevrow = 8
        ElseIf mpy > 219 And mpy <= 242 Then
            row = 9
            prevrow = 9
        ElseIf mpy > 242 And mpy <= 265 Then
            row = 10
            prevrow = 10
        ElseIf mpy > 265 And mpy <= 288 Then
            row = 11
            prevrow = 11
        ElseIf mpy > 288 And mpy <= 311 Then
            row = 12
            prevrow = 12
        ElseIf mpy > 311 And mpy <= 334 Then
            row = 13
            prevrow = 13
        ElseIf mpy > 334 And mpy <= 357 Then
            row = 14
            prevrow = 14
        ElseIf mpy > 357 And mpy <= 380 Then
            row = 15
            prevrow = 15
        ElseIf mpy > 380 And mpy <= 403 Then
            row = 16
            prevrow = 16
        ElseIf mpy > 403 And mpy <= 426 Then
            row = 17
            prevrow = 17
        ElseIf mpy > 426 And mpy <= 449 Then
            row = 18
            prevrow = 18
        ElseIf mpy > 449 And mpy <= 472 Then
            row = 19
            prevrow = 19
        ElseIf mpy > 472 And mpy <= 495 Then
            row = 20
            prevrow = 20
        ElseIf mpy > 495 And mpy <= 518 Then
            row = 21
            prevrow = 21
        ElseIf mpy > 518 And mpy <= 541 Then
            row = 22
            prevrow = 22
        End If
        If BlueSelect(0) = False And turn = 1 Then
            BlueSelect(0) = True
        Else
            BlueSelect(0) = False
        End If
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            blueattack(0) = True
        ElseIf turn = 2 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        End If
    End Sub
    Private Sub blueKing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blueKing.Click
        If turn = 2 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            attackdifx = mpx - redattackrangex
            attackdify = mpx - redattackrangey
            kingclicked = True
            winner = 2
        End If
    End Sub

    Private Sub lblRedKing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRedKing.Click
        attackdifx = mpx - attackrangex
        attackdify = mpy - attackrangey
        If turn = 1 And attackdifx <= 50 And attackdifx >= -50 And attackdify <= 50 And attackdify >= -50 Then
            kingclicked = True
            winner = 1
        End If
    End Sub
    Private Sub attackrevome_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For j = 0 To 49
            blueattack(j) = False
            redattack(j) = False
            good = True
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.bye, AudioPlayMode.WaitToComplete)
        Application.Exit()
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class