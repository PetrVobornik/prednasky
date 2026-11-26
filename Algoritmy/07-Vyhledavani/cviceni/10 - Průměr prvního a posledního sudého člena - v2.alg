{ Prùmìr prvního a posledního sudého èlena - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
  
  sf := 1;
  dokud sf <= n and a[sf] mod 2 = 1 opakuj
    sf := sf + 1;

  sl := n;
  dokud sl >= 1 and a[sl] mod 2 = 1 opakuj
    sl := sl - 1;
  
  jestliže sf > n pak
    napiš("v posloupnosti není sudé èíslo")
  jinak   
    napiš((a[sf] + a[sl]) / 2);      
konec.