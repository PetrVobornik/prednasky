{ Nalezení sudého maxima }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  max := 1;
  pro i od 1 do n opakuj
     jestliže (a[i] > max or max = 1) and a[i] mod 2 = 0 pak
       max := a[i];
      
  jestliže max <> 1 pak
    napiš(max)
  jinak
    napiš("nebyla nalezena žádná lichá hodnota");      
konec.