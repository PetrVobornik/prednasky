{ První lichý èlen - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  pl := 2;
  i := 1;
  dokud i <= n and pl = 2 opakuj
  zaèátek
    jestliže a[i] mod 2 = 1 pak  
      pl := a[i];
    i := i + 1;
  konec;  
  
  jestliže pl <> 2 pak
    napiš(pl)
  jinak
    napiš("nebyla nalezena žádná lichá hodnota");        
konec.