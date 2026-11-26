{ Do C zkopírova A a za nìj obrácenì B }
zaèátek
  nA := 6; nB := 6; 
  pro i od 1 do nA opakuj
    a[i] := random * 10 div 1;
  pro i od 1 do nB opakuj
    b[i] := random * 10 div 1;
    
  nC := nA + nB;
  pro i od 1 do nA opakuj
    c[i] := a[i];
  pro i od 1 do nB opakuj
    c[i+nA] := b[nB-i+1];
konec.