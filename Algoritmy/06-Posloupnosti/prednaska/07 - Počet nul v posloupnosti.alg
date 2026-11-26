{ Poèet nul v posloupnosti }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  

  poèet := 0;
  pro i od 1 do n opakuj
    jestliže a[i] = 0 pak
      poèet := poèet + 1;
    
  napiš(poèet);  
konec.