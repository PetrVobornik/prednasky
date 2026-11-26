{ Nalezení minima }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  min := a[1];
  pro i od 2 do n opakuj
    jestliže a[i] < min pak
      min := a[i];
  
  napiš(min);      
konec.