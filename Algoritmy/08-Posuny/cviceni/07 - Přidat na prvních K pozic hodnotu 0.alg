{ Pøidat na prvních K pozic hodnotu 0 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i; //random * 10 div 1;

  èti(k);
  n := n + k;
  i := n;
  dokud i >= 1 opakuj
  zaèátek
    jestliže i > k pak
      a[i] := a[i-k]
    jinak
      a[i] := 0;  
    i := i - 1;
  konec;
konec.