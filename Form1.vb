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
    Dim byteCounter, byteInkremtint, byteDekremtint As Byte
    Dim boolDekrem, boolPrgDone As Boolean

    '* ======================================= Timer definition ==============================================================================
    Private WithEvents oTimerProgress, oTimerCounter As Timer


    '* ======================================= On Form load actions ==========================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.NumericUpDown1.Enabled = False
    End Sub

    '* ==================================== Button Inkrementieren ============================================================================
    Private Sub BtnInkrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseDown
        If boolPrgDone = True Then
            oTimerCounter.Stop()
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            byteCounter = 0
            boolPrgDone = False
        End If
        'Dekrementiert deaktiveren und Progressbar fuellen aufrufen
        boolDekrem = False
        ProgressbarFill()
    End Sub
    Private Sub BtnInkrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseUp
        'Progressbar Timer stoppen
        boolDekrem = False
        oTimerProgress.Stop()
    End Sub

    '* ==================================== Button Dekrementieren ============================================================================
    Private Sub BtnDekrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseDown
        If boolPrgDone = True Then
            oTimerCounter.Stop()
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            byteCounter = 0
            boolPrgDone = False
        End If
        'Dekrementiert aktiveren, dekrementier Startwert auf 100 setzen und Progressbar fuellen aufrufen
        boolDekrem = True
        byteDekremtint = 100
        ProgressbarFill()
    End Sub

    Private Sub BtnDekrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseUp
        'Progressbar Timer stoppen
        boolDekrem = True
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
        byteCounter += 1
        'Progressbar füllen auf 100 prozent
        If Me.ProgressBar.Value < 100 Then
            Me.ProgressBar.Value = byteCounter
        Else
            'Ist Progressbar voll, wird dieser Timer gestopt und In-/Dekrementierung gestartet
            oTimerProgress.Stop()
            InkremDekrem()
        End If
    End Sub

    '* ==================================== (Timer) In-/Dekrementieren =========================================================================
    Private Sub oTimerCounter_Tick(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles oTimerCounter.Tick
        'Zaehler inkrementieren:
        If byteInkremtint < 100 And boolDekrem = False Then
            Me.BtnInkrement.Enabled = False
            Me.BtnDekrement.Enabled = False
            byteInkremtint += 1
            Me.NumericUpDown1.Value = byteInkremtint
            'Zaehler dekrementieren:
        ElseIf byteDekremtint > 0 And boolDekrem = True Then
            Me.BtnInkrement.Enabled = False
            Me.BtnDekrement.Enabled = False
            byteDekremtint -= 1
            Me.NumericUpDown1.Value = byteDekremtint
        Else
            'Programm fuer reset, um neu start zu ermoeglichen.
            boolPrgDone = True
            Me.BtnInkrement.Enabled = True
            Me.BtnDekrement.Enabled = True
        End If
    End Sub

End Class
