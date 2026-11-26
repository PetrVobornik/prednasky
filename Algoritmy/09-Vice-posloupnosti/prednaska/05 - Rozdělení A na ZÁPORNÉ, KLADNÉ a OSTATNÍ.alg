{ Rozdìlení A na ZÁPORNÉ, KLADNÉ a OSTATNÍ }
zaèátek
  n := 10;  
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1 - 5;
    
  nZ := 0;
  nK := 0;  
  nO := 0;  
  pro i od 1 do n opakuj
    jestlie a[i] > 0 pak
    zaèátek
      nK := nK + 1;
      kladné[nK] := a[i];
    konec jinak jestlie a[i] < 0 pak
    zaèátek
      nZ := nZ + 1;
      záporné[nZ] := a[i];
    konec jinak zaèátek
      nO := nO + 1;
      ostatní[nO] := a[i];
    konec;
konec.