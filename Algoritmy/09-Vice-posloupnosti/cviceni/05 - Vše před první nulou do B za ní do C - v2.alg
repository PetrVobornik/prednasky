{ Vše pøed první nulou do B za ní do C - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  m := 0;  // délka B
  p := 0;  // délka C
  nalezen := false;
  pro i od 1 do n opakuj
    jestliže nalezen pak
    zaèátek
      p := p + 1;
      c[p] := a[i];
    konec jinak
      jestliže a[i] = 0 pak
        nalezen := true
      jinak zaèátek
        m := m + 1;
        b[m] := a[i]; 
      konec;     
konec.