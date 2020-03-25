Function BezDiakritiky(text)
    dia = "ÁÈÏÉÌÍÒÓØŠÚÙİáèïéìíòóøšúùı"
    bez = "ACDEEINORSTUUYZacdeeinorstuuyz"
    For i = 1 To Len(dia)
        d = Mid(dia, i, 1)
        b = Mid(bez, i, 1)
        text = Replace(text, d, b)
    Next i
    BezDiakritiky = text
End Function
