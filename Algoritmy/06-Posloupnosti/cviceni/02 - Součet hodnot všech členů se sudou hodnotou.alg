{ Souèet hodnot všech èlenù se sudou hodnotou }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  
    
  souèet := 0;
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 0 pak
      souèet := souèet + a[i];
    
  napiš(souèet);    
konec.