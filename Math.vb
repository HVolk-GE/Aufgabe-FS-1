Public Class Math
    'For Next Loop 
    Private Sub Snooze(ByVal seconds As Integer)
        For i As Integer = 0 To seconds / 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub
    Public Sub InkrementDekrement()
        Form1.BtnInkrement.Enabled = False
        Form1.BtnDekrement.Enabled = False
        'Zaehler inkrementieren:
        If Form1.intInkremtint < 100 And Form1.boolDekrem = False Then
            For byteInkremtint = 0 To 100 Step 1
                Form1.NumericUpDown1.Value = byteInkremtint
                Snooze(1)
            Next
            'Zaehler dekrementieren:
        ElseIf Form1.intDekremtint > 0 And Form1.boolDekrem = True Then
            For intDekremtint = 100 To 0 Step -1
                Form1.NumericUpDown1.Value = intDekremtint
                Snooze(1)
            Next
        End If
        'Programm fuer reset, um neu start zu ermoeglichen.
        Form1.boolPrgDone = True
        Form1.BtnInkrement.Enabled = True
        Form1.BtnDekrement.Enabled = True

    End Sub
End Class
