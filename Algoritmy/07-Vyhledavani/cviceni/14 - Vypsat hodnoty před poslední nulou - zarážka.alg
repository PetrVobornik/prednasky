{ Vypsat hodnoty pøed poslední nulou - zarážka }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  a[0] := 0; 
  ln := n;
  dokud a[ln] <> 0 opakuj
    ln := ln - 1;

  jestliže ln >= 1 pak
    pro i od 1 do ln-1 opakuj
      napiš(a[i]) 
  jinak          
    napiš("v posloupnosti nebyla žádná nula");
  
konec.