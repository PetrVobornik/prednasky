{ Trojúhelník vymezený diagonálami - vpravo (bez) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 9 div 1 + 1;
      
  pro j od m div 2 do m opakuj
    pro i od m-j+2 do j-1 opakuj
      a[i, j] := 0;      
konec.