{ Nalezení maxima }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1; 
    
  max := a[1];
  pro i od 2 do n opakuj
    jestliže a[i] > max pak
      max := a[i];
      
  napiš(max);       
konec.