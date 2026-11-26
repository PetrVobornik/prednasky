{ Maximum v s-tém sloupci }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  èti(s);
  max := a[1, s];
  pro i od 2 do m opakuj
    jestliže a[i, s] > max pak
      max := a[i, s];
   
  napiš(max);    
konec.