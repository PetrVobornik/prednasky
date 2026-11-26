{ Trojúhelník vymezený diagonálami - dole (vèetnì) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 9 div 1 + 1;
      
  pro i od m div 2 do m opakuj
    pro j od m-i+1 do i opakuj
      a[i, j] := 0;      
konec.