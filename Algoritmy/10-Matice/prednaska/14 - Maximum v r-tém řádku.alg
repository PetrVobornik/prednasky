{ Maximum v r-tém øádku }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  èti(r);
  max := a[r, 1];
  pro j od 2 do n opakuj
    jestliže a[r, j] > max pak
      max := a[r, j];
   
  napiš(max);    
konec.