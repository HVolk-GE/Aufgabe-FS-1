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
    Dim intCounter, intInkremtint, intDekremtint As Integer
    Dim boolDekrem, boolPrgDone, boolForNextLoop As Boolean

    '* ======================================= Timer definition ==============================================================================
    Private WithEvents oTimerProgress, oTimerCounter As Timer

    '* ======================================= On Form load actions ==========================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.NumericUpDown1.Enabled = False
        '==================================== For Next Switch ================================================================================
        'Interne Loops sind fuer die Darstellung auf einer GUI nicht geeignet, Pause oder Break werden in neuen Programmiersprachen nicht mehr
        'benutzt. Da man heute mit Timern arbeiten "soll"!
        'Auf True setzen, wenn man mit der For Next loop arbeiten moechte.
        'Bei False wird der oTimerCounter benutzt. Dieses ist besser fuer die Nachvollziehbarkeit (Sichbarkeit) im GUI geeignet!
        boolForNextLoop = False
    End Sub

    '* ==================================== Button Inkrementieren ============================================================================
    Private Sub BtnInkrement_MouseDown(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnInkrement.MouseDown
        If boolPrgDone = True Then
            If boolForNextLoop = False Then
                oTimerCounter.Stop()
            End If
            Me.ProgressBar.Value = 0
            Me.NumericUpDown1.Value = 0
            intCounter = 0
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
            If boolForNextLoop = False Then
                oTimerCounter.Stop()
            End If
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
        intCounter += 1
        'Progressbar füllen auf 100 prozent
        If Me.ProgressBar.Value < 100 Then
            Me.ProgressBar.Value = intCounter
        Else
            'Ist Progressbar voll, wird dieser Timer gestopt und In-/Dekrementierung gestartet
            oTimerProgress.Stop()
            If boolForNextLoop = False Then
                InkremDekrem()
            ElseIf boolForNextLoop = True Then
                inkrementDekrement() ' Startet For Next Loop, Kalkulationen sind auf der GUI jedoch nicht nachvollziehbar!
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

    'For Next (Man koennte auch Do While oder For Each nutzen - alle haben jedoch das selbe Problem ->) Loesung,
    'nicht benutzbar fuer GUI Darstellung, da die Zaehlung schneller ist als die Refreshrate der Monitore!
    Private Sub inkrementDekrement()
        Me.BtnInkrement.Enabled = False
        Me.BtnDekrement.Enabled = False
        'Zaehler inkrementieren:
        If intInkremtint < 100 And boolDekrem = False Then
            For byteInkremtint = 0 To 100 Step 1
                Me.NumericUpDown1.Value = byteInkremtint
            Next
            'Zaehler dekrementieren:
        ElseIf intDekremtint > 0 And boolDekrem = True Then
            'For indexB = 20 To 1 Step -3
            For intDekremtint = 100 To 0 Step -1
                Me.NumericUpDown1.Value = intDekremtint
            Next
        End If
        'Programm fuer reset, um neu start zu ermoeglichen.
        boolPrgDone = True
        Me.BtnInkrement.Enabled = True
        Me.BtnDekrement.Enabled = True

    End Sub

End Class
