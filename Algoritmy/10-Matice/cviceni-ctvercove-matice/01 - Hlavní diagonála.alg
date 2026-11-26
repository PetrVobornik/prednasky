{ Hlavní diagonála }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 1 do m opakuj
    a[i, i] := 0;      
konec.