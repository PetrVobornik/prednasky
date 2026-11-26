{ Prohození prvního minima a posledního maxima }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;

  iMin := 1;
  iMax := 1;
  pro i od 2 do n opakuj
  zaèátek
    jestliže a[i] < a[iMin] pak
      iMin := i;
    jestliže a[i] >= a[iMax] pak
      iMax := i;
  konec;
  
  p := a[iMin];
  a[iMin] := a[iMax];
  a[iMax] := p;     
konec.