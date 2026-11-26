{ Z posl. A(nA) vše za první nulou do B(nB) }
zaèátek
  nA := 10;
  pro i od 1 do nA opakuj
    a[i] := random * 10 div 1;

  a[nA+1] := 0;  
  i := 1;
  dokud a[i] <> 0 opakuj
    i := i + 1;
    
  jestliže i >= nA pak
    napiš("Nula nenalezena nebo je poslední")
  jinak
  zaèátek
    nB := nA - i;
    pro y od i+1 do nA opakuj
      b[y-i] := a[y];
  konec;      
konec.