{ Odebrání všech sudých èlenù - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;

  m := n;
  i := 1;
  dokud i <= m opakuj
  zaèátek
    jestliže a[i] mod 2 = 0 pak
    zaèátek
      pro k od i do m-1 opakuj
        a[k] := a[k+1];
      m := m - 1;  
    konec;
    i := i + 1;
  konec;  
  n := m;      
konec.