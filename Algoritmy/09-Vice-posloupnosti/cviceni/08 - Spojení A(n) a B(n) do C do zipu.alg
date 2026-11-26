{ Spojení A(n) a B(n) do C do zipu (a1, b1, a2, b2, ...) }
zaèátek
  n := 6; 
  pro i od 1 do n opakuj
  zaèátek
    a[i] := "a" + i;
    b[i] := "b" + i;
  konec;  
    
  nC := 2*n;
  pro i od 1 do n opakuj
  zaèátek
    c[2*i-1] := a[i];
    c[2*i]   := b[i];
  konec;  
konec.