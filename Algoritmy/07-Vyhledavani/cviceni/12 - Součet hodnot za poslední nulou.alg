{ Souèet hodnot za poslední nulou }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;

  souèet := 0;
  i := n;
  dokud i >= 1 and a[i] <> 0 opakuj
  zaèátek
    souèet := souèet + a[i];
    i := i - 1;
  konec;
  
  jestliže i >= 1 pak
    napiš(souèet)
  jinak   
    napiš("v posloupnosti nebyla žádná nula");      
konec.