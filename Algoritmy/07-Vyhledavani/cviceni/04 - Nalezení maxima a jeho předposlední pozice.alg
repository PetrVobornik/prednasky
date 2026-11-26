{ Nalezení maxima a jeho pøedposlední pozice }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 5 div 1; 
    
  iMaxP  := 1;
  iMaxPp := 0;
  pro i od 2 do n opakuj
    jestliže a[i] > a[iMaxP] pak
    zaèátek
      iMaxP  := i;
      iMaxPp := 0;
    konec jinak
      jestliže a[i] = a[iMaxP] pak
      zaèátek
        iMaxPp := iMaxP;
        iMaxP  := i;
      konec;    
      
  jestliže iMaxPp = 0 pak
    napiš ("maximum ", a[iMaxP], " je jen jedno")
  jinak      
    napiš("maximum je ", a[iMaxP], 
      " a jeho pøedposlední pozice je ", iMaxPP);       
konec.