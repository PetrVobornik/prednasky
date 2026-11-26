{ Vložit náhodnou hodnotu na náhodnou pozici }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;
    
  h := random * 100 div 1;
  k := random * n div 1 + 1;
  n := n + 1;
  i := n;
  dokud i > k opakuj
  zaèátek
    a[i] := a[i-1];
    i := i - 1;
  konec;
  a[k] := h;    
konec.