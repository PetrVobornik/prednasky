{ Seèíst èleny na stejných indexech rùznì dlouhých posl. 
  c(n) = a(n) + b(m), m < n, pøesahující èást A jen pøepsat }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
  m := 6;
  pro i od 1 do m opakuj
    b[i] := random * 10 div 1;

  pro i od 1 do m opakuj
    c[i] := a[i] + b[i];
  pro i od m+1 do n opakuj
    c[i] := a[i];     
  
  
  s := "";
  pro i od 1 do n opakuj
    s := s + " " + a[i] + ", ";
  napiš(s);    

  s := "";
  pro i od 1 do m opakuj
    s := s + " " + b[i] + ", ";
  napiš(s);      

  s := "";
  pro i od 1 do n opakuj
    jestliže c[i] < 10 pak
      s := s + " " + c[i] + ", "
    jinak  
      s := s + c[i] + ", ";
  napiš(s);    
konec.