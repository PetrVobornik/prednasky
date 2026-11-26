{ První lichý èlen - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  nalezen := false;
  i := 1;
  dokud i <= n and not nalezen opakuj
  zaèátek
    jestliže a[i] mod 2 = 1 pak  
    zaèátek
      pl := a[i];
      nalezen := true;
    konec;
    i := i + 1;
  konec;  
  
  jestliže nalezen pak
    napiš(pl)
  jinak
    napiš("nebyla nalezena žádná lichá hodnota");        
konec.