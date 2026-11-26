{ Odebrání všech sudých èlenù - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;

  k := 0;
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 1 pak
    zaèátek
      k := k + 1;
      a[k] := a[i];
    konec;
  n := k;  
konec.