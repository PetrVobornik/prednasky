{ Trojúhelník vymezený diagonálami - vlevo (vèetnì) }
zaèátek
  m := 5;
  pro i od 1 do m opakuj
    pro j od 1 do m opakuj
      a[i, j] := random * 9 div 1 + 1;
      
  pro j od 1 do m div 2 + 1 opakuj
    pro i od j do m-j+1 opakuj
      a[i, j] := 0;      
konec.