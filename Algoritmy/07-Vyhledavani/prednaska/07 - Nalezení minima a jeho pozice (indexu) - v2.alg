{ Nalezení minima a jeho pozice (indexu) - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  iMin := 1;
  pro i od 2 do n opakuj
    jestliže a[i] < a[iMin] pak  // < první, <= poslední 
      iMin := i;
  
  napiš("a[", iMin, "] = ", a[iMin]);      
konec.