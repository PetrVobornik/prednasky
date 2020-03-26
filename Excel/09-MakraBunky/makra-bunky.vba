Sub Makro1()
'
' Makro1 Makro
'

'
    Range("C4").Select
    ActiveCell.FormulaR1C1 = "Ahoj"
    Range("D7").Select
    ActiveCell.FormulaR1C1 = "25"
    Range("B11").Select
End Sub


Sub Makro2()
'
' Makro2 Makro
'

'
    ActiveCell.FormulaR1C1 = "1"
    ActiveCell.Offset(1, 0).Select
    ActiveCell.FormulaR1C1 = "2"
    ActiveCell.Offset(1, 0).Range("A1").Select
    ActiveCell.FormulaR1C1 = "3"
    ActiveCell.Offset(1, 0).Range("A1").Select
    ActiveCell.FormulaR1C1 = "4"
    ActiveCell.Offset(1, 0).Range("A1").Select
    ActiveCell.FormulaR1C1 = "5"
    ActiveCell.Offset(1, 0).Range("A1").Select
    Selection.End(xlUp).Select
    Selection.End(xlUp).Select
End Sub


Sub Makro3()
'Adresování buòky
    'Range("A4").Select
    'Cells(4, 2).Select
    'ActiveCell.Offset(1, 2).Select
    '[A4].Select
    
'Adresování oblasti
    'Range("B2:C6").Select
    'Range("B2", "C6").Select
    'Range(Cells(2, 2), Cells(6, 3)).Select
    'Range(ActiveCell, ActiveCell.Offset(1, 2)).Select
    'Range([B2], [C6]).Select
    
'Oznaèit list
    'Sheets(2).Activate
    'Sheets("List2").Activate
    
'Hodnota buòky
    'ActiveCell.Value = 123
    'ActiveCell.Value = Date
    'ActiveCell.Value2 = Date
    'ActiveCell.Value2 = 125
    'ActiveCell.Value2 = [C5].Text
    'ActiveCell.Offset(0, 1).Value = ActiveCell.Value
    
    'Range("B2:C6").Value = "kuk"
    'Range("A1, A3, A10").Value = "baf"
    
'Vzorce
    'ActiveCell.Formula = "=SUM(A15:B15)"
    'ActiveCell.FormulaR1C1 = "=SUM(RC[-2]:RC[-1])"
    'ActiveCell.FormulaR1C1 = "=SUM(R[-2]C[-2]:RC[-1])"
    
'Výpoèet pomocí funkce Excelu
    'ActiveCell.Value = Application.WorksheetFunction.Sum(Range("A15:B17"))
    'ActiveCell.Value = Application.WorksheetFunction.Average(Range("A15:B17"))
    
'Formátování bunìk
    'ActiveCell.Offset(0, 1).Interior.Color = rgbRed
    'ActiveCell.Offset(0, 1).Interior.Color = RGB(200, 160, 35)
    'ActiveCell.NumberFormat = "yy-mm-dd"
    
'Spojování bunìk
    'Range(ActiveCell, ActiveCell.Offset(0, 1)).Merge
    'Range(ActiveCell, ActiveCell.Offset(0, 1)).UnMerge
    
'Hodnota z jiného listu
    'ActiveCell.Value = Sheets("List2").Range("B3").Value
    
'Hodnota z jiného sešitu (souboru)
    'Application.Workbooks.Open ("C:\Temp\test.xlsx")
    'Hodnota = Workbooks("test.xlsx").Worksheets("List1").Range("C4").Value
    'Workbooks("test.xlsx").Close
    'ActiveCell.Value = Hodnota
    'MsgBox (Hodnota)
End Sub
