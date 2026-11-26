{ Nalezení minima a jeho pozice (indexu) - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  min := a[1];
  iMin := 1;
  pro i od 2 do n opakuj
    jestliže a[i] < min pak
    zaèátek
      min := a[i];
      iMin := i;
    konec;  
  
  napiš("a[", iMin, "] = ", min);      
konec.