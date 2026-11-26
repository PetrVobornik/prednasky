{ Skalární souèin AxB }
zaèátek
  n := 8;
  pro i od 1 do n opakuj
  zaèátek
    a[i] := random * 10 div 1;
    b[i] := random * 10 div 1;
  konec;  
 
  ss := 0; 
  pro i od 1 do n opakuj
    ss := ss + a[i] * b[i];
    
  napiš(ss);   
konec.