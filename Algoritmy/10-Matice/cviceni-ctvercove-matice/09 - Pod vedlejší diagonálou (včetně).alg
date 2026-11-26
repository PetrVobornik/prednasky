{ Pod vedlejší diagonálou (vèetnì) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 1 do m opakuj
    pro j od m-i+1 do m opakuj
      a[i, j] := 0;      
konec.