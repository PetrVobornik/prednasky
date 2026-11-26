{ Vypsat souèty hodnot sousedících párù (1 a 2, 3 a 4, 5 a 6 ...) - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;

  souèet := 0;
  pro i od 1 do n opakuj
  zaèátek
    souèet := souèet + a[i];
    jestliže i mod 2 = 0 pak
    zaèátek
      napiš(souèet);
      souèet := 0;
    konec;
  konec;    
konec.