{ Vložení nového èlena do posloupnosti }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;
    
  èti(h);  
  èti(k);
  n := n + 1;
  i := n;
  dokud i > k opakuj
  zaèátek
    a[i] := a[i-1];
    i := i - 1;
  konec;
  a[k] := h;
konec.