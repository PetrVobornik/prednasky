{ Nalezení prvního maxima a jeho pozice }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1; 
    
  iMax := 1;
  pro i od 2 do n opakuj
    jestliže a[i] > a[iMax] pak
      iMax := i;
      
  napiš("maximum je ", a[iMax], 
        " poprvé je na pozici ", iMax);       
konec.     