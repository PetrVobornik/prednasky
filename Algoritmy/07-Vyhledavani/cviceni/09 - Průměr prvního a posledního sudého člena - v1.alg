{ Prùmìr prvního a posledního sudého èlena - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
  
  sf := 1;
  sl := 1;   
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 0 pak
    zaèátek
      sl := a[i];
      jestliže sf = 1 pak
        sf := a[i];
    konec;   
  
  jestliže sf = 1 pak
    napiš("v posloupnosti není sudé èíslo")
  jinak   
    napiš((sf+sl)/2);      
konec.