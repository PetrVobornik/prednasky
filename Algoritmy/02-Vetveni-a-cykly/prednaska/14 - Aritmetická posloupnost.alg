{ Aritmetick� posloupnost: a[n] = a[n-1] + d }
za��tek
  �ti(a1);
  �ti(d);
  �ti(n);
  
  an := a1;
  pro i od 1 do n opakuj
  za��tek
    napi�(i, ". ", an);
    an := an + d;
  konec;
konec.