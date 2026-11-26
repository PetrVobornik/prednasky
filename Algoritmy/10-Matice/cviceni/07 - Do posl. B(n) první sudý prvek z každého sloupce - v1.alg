{ Do posl. B(n) první sudý prvek z každého sloupce,
  není-li pak -1 - v1 }
zaèátek
  m := 4; // øádkù
  n := 6; // sloupcù 
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro j od 1 do n opakuj
  zaèátek
    b[j] := -1;
    pro i od 1 do m opakuj
      jestliže b[j] = -1 and a[i, j] mod 2 = 0 pak
        b[j] := a[i, j];
  konec;  
konec.