{ Horizontální pøevrácení matice podle støedové osy }
zaèátek
  m := 4; // øádkù
  n := 5; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := j + n * (i-1);
      
  pro i od 1 do m opakuj
    pro j od 1 do n div 2 opakuj
    zaèátek
      p := a[i, j];
      a[i, j] := a[i, n-j+1];
      a[i, n-j+1] := p;
    konec;
konec.