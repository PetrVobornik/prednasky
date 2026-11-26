{ Do B všechny èleny z A, které jsou dìlitelné tøemi }
zaèátek
  n := 10;  // Délka pole A
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  m := 0;   // Délka pole B  
  pro i od 1 do n opakuj
    jestliže a[i] mod 3 = 0 pak
    zaèátek
      m := m + 1;
      b[m] := a[i];
    konec;

  jestliže m = 0 pak
    napiš("V posloupnosti nebyly žádné hodnoty dìlitelné tøemi");     
konec.