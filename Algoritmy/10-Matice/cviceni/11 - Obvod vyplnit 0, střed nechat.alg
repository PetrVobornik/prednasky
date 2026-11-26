{ Obvod vyplnit 0, støed nechat }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù 
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 1 do m opakuj
  zaèátek
    a[i, 1] := 0;
    a[i, n] := 0;
  konec;
  pro j od 2 do n-1 opakuj
  zaèátek
    a[1, j] := 0;
    a[m, j] := 0;
  konec;
konec.