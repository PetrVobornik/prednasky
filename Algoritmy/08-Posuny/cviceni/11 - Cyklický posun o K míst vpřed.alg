{ Cyklický posun o K míst vpøed }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; 

  èti(k);
  pro i od 1 do k opakuj
    a[n+i] := a[i];
  pro i od 1 do n opakuj
    a[i] := a[i+k];  
konec.