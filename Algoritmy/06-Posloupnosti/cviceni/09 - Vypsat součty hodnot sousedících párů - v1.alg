{ Vypsat souèty hodnot sousedících párù (1 a 2, 3 a 4, 5 a 6 ...) - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;

  i := 1;
  dokud i <= n opakuj
  zaèátek
    napiš(a[i] + a[i+1]);
    i := i + 2;
  konec;    
konec.