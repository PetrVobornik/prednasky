{ A a B (seøazené vzestupnì) spojit do C taky seøazeného }
zaèátek
  nA := 6; nB := 7;
  a[1] := random * 3 div 1; 
  pro i od 2 do nA opakuj
    a[i] := a[i-1] + random * 3 div 1;
  b[1] := random * 3 div 1; 
  pro i od 2 do nB opakuj
    b[i] := b[i-1] + random * 4 div 1;
    
  iA := 1;
  iB := 1;
  a[nA+1] := a[nA] + b[nB];   // Zarážka v A
  b[nB+1] := a[nA] + b[nB];   // Zarážka v B
  pro iC od 1 do nA+nB opakuj
    jestliže a[iA] > b[iB] pak
    zaèátek
      c[iC] := b[iB];
      iB := iB + 1;
    konec jinak zaèátek
      c[iC] := a[iA];
      iA := iA + 1;
    konec;
  nC := nA + nB;  
konec.