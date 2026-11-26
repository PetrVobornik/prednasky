{ Poslední lichý èlen - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  nalezen := false;
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 1 pak  
    zaèátek
      pl := a[i];
      nalezen := true;
    konec;
  
  jestliže nalezen pak
    napiš(pl)
  jinak
    napiš("nebyla nalezena žádná lichá hodnota");        
konec.