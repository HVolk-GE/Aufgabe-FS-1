﻿'# ==========================================================================================================================================
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
    Public intCounter, intInkremtint, intDekremtint As Integer
    Public boolDekrem, boolPrgDone, boolForNextLoop As Boolean
    ReadOnly instMath As New Math()
    '* ======================================= Timer definition ==============================================================================
    Private WithEvents oTimerProgress, oTimerCounter As Timer

    '* ======================================= On Form load actions ==========================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'NumericUpDown1 Feld deaktiviert - wird nur von dem Programm als Ziel der Kalkulationen benutzt!
        Me.NumericUpDown1.Enabled = False
        '==================================== For Next Switch ================================================================================
        'Auf True setzen, wenn man mit der For Next loop arbeiten moechte.
        'Bei False wird der oTimerCounter benutzt.
        boolForNextLoop = True
    End Sub

    '* ==================================== Button Inkrementieren ============================================================================
    Private Sub BtnInkrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseDown
        'Solange linke Maustaste auf dem Button "Inkrement" gedrückt wird, wird folgender Code ausgeführt:
        'Wenn Programm erfolgreích druchlaufen ist, wird der oTimerCounter gestoppt.
        If boolPrgDone = True Then
            If boolForNextLoop = False Then
                oTimerCounter.Stop()
            End If
            'Neustart Initialisierung
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            intCounter = 0
            boolPrgDone = False
        End If
        'Dekrementierung deaktiveren = Inkrementierung aktiv.
        boolDekrem = False
        'Progressbar fuellen aufrufen
        ProgressbarFill()
    End Sub
    Private Sub BtnInkrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseUp
        'Dekrementierung deaktiveren = Inkrementierung aktiviert.
        boolDekrem = False
        'Progressbar-Timer stoppen
        oTimerProgress.Stop()
    End Sub

    '* ==================================== Button Dekrementieren ============================================================================
    Private Sub BtnDekrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseDown
        'Solange linke Maustaste auf dem Button "Dekrement" gedrückt wird, wird folgender Code ausgeführt:
        'Wenn Programm erfolgreích druchlaufen ist, wird der oTimerCounter gestoppt.
        If boolPrgDone = True Then
            If boolForNextLoop = False Then
                oTimerCounter.Stop()
            End If
            'Neustart Initialisierung
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            intCounter = 0
            boolPrgDone = False
        End If
        'Dekrementiert aktiveren, dekrementier Startwert auf 100 setzen und Progressbar fuellen aufrufen
        boolDekrem = True
        intDekremtint = 100
        ProgressbarFill()
    End Sub

    Private Sub BtnDekrement_MouseUp(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDekrement.MouseUp
        'Dekrementierung aktiveren = Inkrementierung deaktivert.
        boolDekrem = True
        'Progressbar-Timer stoppen
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
        'Zaehler Timer 0-100 starten, ticks 100ms
        If IsNothing(oTimerCounter) Then oTimerCounter = New Timer
        oTimerCounter.Interval = 100
        oTimerCounter.Start()
    End Sub

    '* ==================================== (Timer) Progressbar füllen =========================================================================
    Private Sub oTimerProgress_Tick(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles oTimerProgress.Tick

        intCounter += 1
        'Progressbar füllen auf 100 prozent
        If Me.ProgressBar.Value < 100 Then
            Me.ProgressBar.Value = intCounter
        Else
            'Ist Progressbar voll, wird dieser Timer gestopt und die In-/Dekrementierung gestartet
            oTimerProgress.Stop()
            'For Next Loop, wenn true dann aktiv.
            If boolForNextLoop = False Then
                InkremDekrem()
            ElseIf boolForNextLoop = True Then
                instMath.InkrementDekrement() 'Startet For Next Loop.
            End If
        End If

    End Sub

    '* ==================================== (Timer) In-/Dekrementieren =========================================================================
    Private Sub oTimerCounter_Tick(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles oTimerCounter.Tick

        Me.BtnInkrement.Enabled = False
        Me.BtnDekrement.Enabled = False
        'Zaehler inkrementieren:
        If intInkremtint < 100 And boolDekrem = False Then
            intInkremtint += 1
            Me.NumericUpDown1.Value = intInkremtint
            'Zaehler dekrementieren:
        ElseIf intDekremtint > 0 And boolDekrem = True Then
            intDekremtint -= 1
            Me.NumericUpDown1.Value = intDekremtint
        Else
            'Programm fuer reset, um neu start zu ermoeglichen.
            boolPrgDone = True
            Me.BtnInkrement.Enabled = True
            Me.BtnDekrement.Enabled = True
        End If

    End Sub

End Class
