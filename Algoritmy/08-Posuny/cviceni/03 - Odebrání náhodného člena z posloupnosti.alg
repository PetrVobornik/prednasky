{ Odebrání náhodného èlena z posloupnosti }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;
    
  k := random * n div 1 + 1;
  pro i od k do n-1 opakuj
    a[i] := a[i+1];
  n := n - 1;    
konec.