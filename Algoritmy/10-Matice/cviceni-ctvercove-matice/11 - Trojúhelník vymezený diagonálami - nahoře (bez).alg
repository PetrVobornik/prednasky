{ Trojúhelník vymezený diagonálami - nahoøe (bez) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 9 div 1 + 1;
      
  pro i od 1 do m div 2 opakuj
    pro j od i+1 do m-i opakuj
      a[i, j] := 0;      
konec.