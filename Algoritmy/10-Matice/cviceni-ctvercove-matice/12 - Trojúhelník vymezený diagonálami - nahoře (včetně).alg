{ Trojúhelník vymezený diagonálami - nahoøe (vèetnì) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 9 div 1 + 1;
      
  pro i od 1 do m div 2 + 1 opakuj
    pro j od i do m-i+1 opakuj
      a[i, j] := 0;      
konec.