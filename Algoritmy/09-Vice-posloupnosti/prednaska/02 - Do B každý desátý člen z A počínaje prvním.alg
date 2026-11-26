{ Do B každý desátý èlen z A poèínaje prvním }
zaèátek
  n := 42;  
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  m := 0;
  i := 1;
  dokud i <= n opakuj  
  zaèátek
    m := m + 1;
    b[m] := a[i];
    i := i + 10;
  konec;
konec.