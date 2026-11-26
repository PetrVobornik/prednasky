{ D = A + B + C (spojit za sebe) }
zaèátek
  nA := 4; nB := 5; nC := 3;
  pro i od 1 do nA opakuj
    a[i] := random * 10 div 1;
  pro i od 1 do nB opakuj
    b[i] := random * 10 div 1;
  pro i od 1 do nC opakuj
    c[i] := random * 10 div 1;
    
  nD := nA + nB + nC;
  pro i od 1 do nA opakuj
    d[i] := a[i];
  pro i od 1 do nB opakuj
    d[i+nA] := b[i];
  pro i od 1 do nC opakuj
    d[i+nA+nB] := c[i];
konec.