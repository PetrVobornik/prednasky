{ Rozdìlení A na SUDÉ a LICHÉ }
zaèátek
  n := 10;  
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  nS := 0;   // Délka pole SUDÉ
  nL := 0;   // Délka pole LICHÉ  
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 0 pak
    zaèátek
      nS := nS + 1;
      sudé[nS] := a[i];
    konec
    jinak
    zaèátek
      nL := nL + 1;
      liché[nL] := a[i];
    konec;
konec.