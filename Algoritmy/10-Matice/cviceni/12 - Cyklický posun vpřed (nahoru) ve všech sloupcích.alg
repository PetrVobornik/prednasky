{ Cyklický posun vpøed (nahoru) ve všech sloupcích }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù 
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := i + m * (j-1);
      
  pro j od 1 do n opakuj
  zaèátek
    p := a[1, j];
    pro i od 1 do m-1 opakuj
      a[i, j] := a[i+1, j];
    a[m, j] := p;  
  konec;  
konec.