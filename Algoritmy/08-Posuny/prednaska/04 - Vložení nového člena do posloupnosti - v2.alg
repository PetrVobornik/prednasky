{ Vložení nového èlena do posloupnosti - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
    
  èti(h);  
  èti(k);
  i := n;
  n := n + 1;
  dokud i >= k opakuj
  zaèátek
    a[i+1] := a[i];
    i := i - 1;
  konec;
  a[k] := h;      
konec.