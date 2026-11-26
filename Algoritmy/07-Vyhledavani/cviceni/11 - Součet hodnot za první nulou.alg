{ Souèet hodnot za první nulou }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
  
  nula := false;
  souèet := 0;
  pro i od 1 do n opakuj
    jestliže nula pak
      souèet := souèet + a[i]
    jinak
      jestliže a[i] = 0 pak
        nula := true;
  
  jestliže nula pak
    napiš(souèet)
  jinak   
    napiš("v posloupnosti nebyla žádná nula");      
konec.