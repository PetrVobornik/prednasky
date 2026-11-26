{ Do B každý èlen z A jejichž index je dìlitelný deseti }
zaèátek
  n := 42;  
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  m := 0;
  i := 10;
  dokud i <= n opakuj  
  zaèátek
    m := m + 1;
    b[m] := a[i];
    i := i + 10;
  konec;
  
  jestliže m = 0 pak
    napiš("Posloupnost má ménì než 10 èlenù");     
konec.