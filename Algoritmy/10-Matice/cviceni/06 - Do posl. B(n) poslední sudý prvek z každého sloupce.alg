{ Do posl. B(n) poslední sudý prvek z každého sloupce,
  není-li pak -1 }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro j od 1 do n opakuj
  zaèátek
    b[j] := -1;
    pro i od 1 do m opakuj
      jestliže a[i, j] mod 2 = 0 pak
        b[j] := a[i, j];
  konec;
konec.