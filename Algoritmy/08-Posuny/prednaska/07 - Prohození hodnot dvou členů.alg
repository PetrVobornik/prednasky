{ Prohození hodnot dvou èlenù }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
  
  èti(k1);
  èti(k2);
  jestliže k1 <> k2 pak
  zaèátek
    p := a[k1];
    a[k1] := a[k2];
    a[k2] := p;
  konec;
konec.