{ Odebrání èlena z posloupnosti - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
    
  èti(k);
  pro i od k do n-1 opakuj
    a[i] := a[i+1];
  n := n - 1;    
konec.