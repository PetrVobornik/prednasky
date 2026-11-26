{ Odebrání èlena z posloupnosti - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
    
  èti(k);
  pro i od k+1 do n opakuj
    a[i-1] := a[i];
  n := n - 1;    
konec.