{ Seèíst èleny na stejných indexech c(n) = a(n) + b(n) }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
  zaèátek
    a[i] := random * 10 div 1;
    b[i] := random * 10 div 1;
  konec;  
    
  pro i od 1 do n opakuj
    c[i] := a[i] + b[i];  
  
  pro i od 1 do n opakuj
    napiš(c[i]);
konec.                   
