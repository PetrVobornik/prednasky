{ Odebrat prvních K èlenù }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;

  èti(k);
  pro i od k+1 do n opakuj
    a[i-k] := a[i];
  n := n - k;   
konec.