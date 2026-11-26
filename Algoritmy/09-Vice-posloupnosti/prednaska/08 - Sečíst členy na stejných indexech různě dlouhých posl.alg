{ Seèíst èleny na stejných indexech rùznì dlouhých posl. 
  c(n) = a(n) + b(m), m < n, pøeènnívající èást A jen pøepsat }
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
  
  pro i od 1 do n opakuj
    napiš(c[i]);
konec.                   
