Public Class indekrement
    'For Next Loop (Man koennte auch Do While oder For Each etc. nutzen - alle haben jedoch ein Problem ->) Loesung,
    'nicht benutzbar fuer GUI Darstellung, da die Zaehlung schneller ist als die Refreshrate der Monitore!
    'Break, Pause, Sleep usw. soll man laut offizieller VB.Net Dokumentation nicht mehr nutzen!

    Public Sub inkrementDekrement()
        Form1.BtnInkrement.Enabled = False
        Form1.BtnDekrement.Enabled = False
        'Zaehler inkrementieren:
        If Form1.intInkremtint < 100 And Form1.boolDekrem = False Then
            For byteInkremtint = 0 To 100 Step 1
                Form1.NumericUpDown1.Value = byteInkremtint
            Next
            'Zaehler dekrementieren:
        ElseIf Form1.intDekremtint > 0 And Form1.boolDekrem = True Then
            'For indexB = 20 To 1 Step -3
            For intDekremtint = 100 To 0 Step -1
                Form1.NumericUpDown1.Value = intDekremtint
            Next
        End If
        'Programm fuer reset, um neu start zu ermoeglichen.
        Form1.boolPrgDone = True
        Form1.BtnInkrement.Enabled = True
        Form1.BtnDekrement.Enabled = True

    End Sub
End Class
