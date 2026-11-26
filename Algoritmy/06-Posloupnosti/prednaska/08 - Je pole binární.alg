{ Je pole binární? }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 2 div 1;  
  
  binarni := true;
  pro i od 1 do n opakuj
    jestliže a[i] <> 0 and a[i] <> 1 pak
       binarni := false;
       
  jestliže binarni pak
    napiš("ANO")
  jinak
    napiš("NE");       
konec.