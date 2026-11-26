{ Prohození hodnot 1. a posledního sloupce }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  pro i od 1 do m opakuj
  zaèátek
    p := a[i, 1];
    a[i, 1] := a[i, n];
    a[i, n] := p;
  konec;  
konec.