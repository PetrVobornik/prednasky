{ Do posl. B(m) maxima z každého øádku }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 1 do m opakuj
  zaèátek
    max := a[i, 1];
    pro j od 2 do n opakuj
      jestliže a[i, j] > max pak
        max := a[i, j];
    b[i] := max;  
  konec;
konec.