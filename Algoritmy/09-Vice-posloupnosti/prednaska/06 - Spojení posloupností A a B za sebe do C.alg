{ Spojení posloupností A a B za sebe do C }
zaèátek
  nA := 6;  
  pro i od 1 do nA opakuj
    a[i] := random * 10 div 1;
  nB := 5;  
  pro i od 1 do nB opakuj
    b[i] := random * 10 div 1;

  nC := nA + nB; 
  pro i od 1 do nA opakuj
    c[i] := a[i];
  pro i od 1 do nB opakuj
    c[nA+i] := b[i];      
konec.