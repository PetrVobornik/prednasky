{ Aritmetická posloupnost: a[n] = a[n-1] + d }
zaèátek
  èti(a1);
  èti(d);
  èti(n);
  
  an := a1;
  pro i od 1 do n opakuj
  zaèátek
    napiš(i, ". ", an);
    an := an + d;
  konec;
konec.