'# ==========================================================================================================================================
'# Aufgabenstellung:
'# ==========================================================================================================================================
'* Das GUI läuft auf einem Windows System und ist In Visual Basic .NET programmiert
'* Das GUI besitzt einen Laufbalken
'* Das GUI besitzt 2 Knöpfe
'* Das GUI besitzt einen Zähler
'* Wenn der 1. Knopf gedrückt und gehalten wird füllt sich der Laufbalken. Ist der Laufbalken voll wird der Zähler inkrementiert
'* Wenn der 2. Knopf gedrückt und gehalten wird füllt sich der Laufbalken. Ist der Laufbalken voll wird der Zähler dekrementiert
'* ==========================================================================================================================================

Public Class Form1
    '* ===================================== Globale Variablen definition ====================================================================
    Dim counter, inkremtint, dekremtint As Byte
    Dim dekrem, prgDone As Boolean

    '* ======================================= Timer definition ==============================================================================
    Private WithEvents oTimerProgress, oTimerCounter As Timer

    '* ==================================== Button Inkrementieren ============================================================================
    Private Sub BtnInkrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseDown
        If prgDone = True Then
            oTimerCounter.Stop()
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            counter = 0
            prgDone = False
        End If
        'Dekrementiert deaktiveren und Progressbar fuellen aufrufen
        dekrem = False
        ProgressbarFill()
    End Sub
    Private Sub BtnInkrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseUp
        'Progressbar Timer stoppen
        dekrem = False
        oTimerProgress.Stop()
    End Sub

    '* ==================================== Button Dekrementieren ============================================================================
    Private Sub BtnDekrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseDown
        If prgDone = True Then
            oTimerCounter.Stop()
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            counter = 0
            prgDone = False
        End If
        'Dekrementiert aktiveren, dekrementier Startwert auf 100 setzen und Progressbar fuellen aufrufen
        dekrem = True
        dekremtint = 100
        ProgressbarFill()
    End Sub

    Private Sub BtnDekrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseUp
        'Progressbar Timer stoppen
        dekrem = True
        oTimerProgress.Stop()
    End Sub


    '* ==================================== (Timer) Progressbar füllen starten =================================================================
    Private Sub ProgressbarFill()
        'Progressbar Timer starten, ticks 100ms
        If IsNothing(oTimerProgress) Then oTimerProgress = New Timer
        oTimerProgress.Interval = 100
        oTimerProgress.Start()
    End Sub

    '* ==================================== (Timer) In-/Dekrementieren starten =================================================================
    Private Sub InkremDekrem()
        'Zaehler Timer starten, ticks 100ms
        If IsNothing(oTimerCounter) Then oTimerCounter = New Timer
        oTimerCounter.Interval = 100
        oTimerCounter.Start()
    End Sub

    '* ==================================== (Timer) Progressbar füllen =========================================================================
    Private Sub oTimerProgress_Tick(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles oTimerProgress.Tick
        counter += 1
        'Progressbar füllen auf 100 prozent
        If Me.ProgressBar.Value < 100 Then
            Me.ProgressBar.Value = counter
        Else
            'Ist Progressbar voll, wird dieser Timer gestopt und In-/Dekrementierung gestartet
            oTimerProgress.Stop()
            InkremDekrem()
        End If
    End Sub

    '* ==================================== (Timer) In-/Dekrementieren =========================================================================
    Private Sub oTimerCounter_Tick(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles oTimerCounter.Tick
        'Inkrementierung
        If inkremtint < 100 And dekrem = False Then
            Me.BtnInkrement.Enabled = False
            Me.BtnDekrement.Enabled = False
            inkremtint += 1
            Me.NumericUpDown1.Value = inkremtint
            'Dekrementierung
        ElseIf dekremtint > 0 And dekrem = True Then
            Me.BtnInkrement.Enabled = False
            Me.BtnDekrement.Enabled = False
            dekremtint -= 1
            Me.NumericUpDown1.Value = dekremtint
        Else
            'Programm fuer reset vorbereiten, wenn es einmal erfolgreich ausgeführt wurde und neu start zu ermoeglichen.
            prgDone = True
            Me.BtnInkrement.Enabled = True
            Me.BtnDekrement.Enabled = True
        End If
    End Sub

End Class
