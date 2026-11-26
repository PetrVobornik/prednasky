{ Støed vyplnit 1, obvod nechat }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù 
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 2 do m-1 opakuj
    pro j od 2 do n-1 opakuj
      a[i, j] := 1;
konec.