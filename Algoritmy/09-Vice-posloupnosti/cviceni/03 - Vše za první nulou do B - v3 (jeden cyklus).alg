{ Vše za první nulou do B - v3 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  m := 0;  
  nalezen := false;
  pro i od 1 do n opakuj
    jestliže nalezen pak
    zaèátek
      m := m + 1;
      b[m] := a[i];
    konec jinak
      jestliže a[i] = 0 pak
        nalezen := true;   
   
  jestliže not nalezen or m = 0 pak
    napiš("Nula nenalezena nebo je poslední");
konec.