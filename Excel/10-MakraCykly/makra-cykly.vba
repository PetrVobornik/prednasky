Sub CyklusFor1()
' od aktuální buòky 100 dolù s posunem

    For i = 1 To 100
        ActiveCell.Value = i
        ActiveCell.Offset(1, 0).Select
    Next i

End Sub

Sub CyklusFor2()
' od aktuální buòky 100 dolù bez posunu

    For i = 1 To 100
        Cells(i, 2).Value = i
    Next i

End Sub

Sub CyklusFor3()
' oblast 20x10 náhodných celých jednociferných èísel

    For i = 1 To 20
        For j = 1 To 10
            Cells(i, j).Value = Int(Rnd * 10)
        Next j
    Next i

End Sub

Sub CyklusProOznacenouOblast()
' u neprázdných bunìk v oznaèené oblasti zvýšit hodnotu o 2
    
    For Each bunka In Selection
        If Not IsEmpty(bunka) Then
            bunka.Value = bunka.Value + 2
        End If
    Next bunka
    
End Sub

Sub CyklusWhile1()
' Od aktuální pozice až po první prázdnou buòku +1 (a pak se vrátit)

    adresa = ActiveCell.Address
    While (Not IsEmpty(ActiveCell))
        ActiveCell.Value = ActiveCell.Value + 1
        ActiveCell.Offset(1, 0).Select
    Wend
    Range(adresa).Select

End Sub

Sub CyklusWhile2()
' V prvním sloupci od zaèátku až po první prázdnou buòku +1 bez posunu

    Dim i As Integer
    i = 1
    While (Not IsEmpty(Cells(i, 1)))
        Cells(i, 1).Value = Cells(i, 1).Value + 1
        i = i + 1
    Wend

End Sub

Sub Terc()
    ActiveCell.Interior.Color = rgbBlack
    For i = 1 To ActiveCell.Value - 1
        Range(ActiveCell.Offset(-2 * i, -2 * i), ActiveCell.Offset(-2 * i, 2 * i)).Interior.Color = rgbBlack
        Range(ActiveCell.Offset(2 * i, -2 * i), ActiveCell.Offset(2 * i, 2 * i)).Interior.Color = rgbBlack
        Range(ActiveCell.Offset(-2 * i, -2 * i), ActiveCell.Offset(2 * i, -2 * i)).Interior.Color = rgbBlack
        Range(ActiveCell.Offset(-2 * i, 2 * i), ActiveCell.Offset(2 * i, 2 * i)).Interior.Color = rgbBlack
    Next i
End Sub

Sub Spirala()
    
    Dim smer As Integer, krok As Integer, krokuVeSmeru As Integer, _
        x As Integer, y As Integer
    
    smer = 1
    krok = 0
    krokuVeSmeru = 2
    x = 0
    y = 0
    
    For i = 1 To ActiveCell.Value
        ActiveCell.Offset(y, x).Interior.Color = rgbBlack
        Select Case smer
            Case 1
                x = x - 1
            Case 2
                y = y + 1
            Case 3
                x = x + 1
            Case 4
                y = y - 1
        End Select
        
        krok = krok + 1
        If krok >= krokuVeSmeru - 1 Then
            krok = 0
            krokuVeSmeru = krokuVeSmeru + 1
            smer = smer + 1
            If smer > 4 Then
                smer = 1
            End If
        End If
        Application.Wait (Now + TimeValue("00:00:01"))
    Next i
    
End Sub
