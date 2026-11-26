{ Do posl. B(n) první sudý prvek z každého sloupce,
  není-li pak -1 - v2 }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù 
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro j od 1 do n opakuj
  zaèátek
    i := 1;
    dokud i <= m and a[i, j] mod 2 <> 0 opakuj
      i := i + 1;
    jestliže i > m pak  
      b[j] := -1
    jinak  
      b[j] := a[i, j];
  konec;  
konec.