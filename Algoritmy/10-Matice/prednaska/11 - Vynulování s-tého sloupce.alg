{ Vynulování s-tého sloupce }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  èti(s);    
  jestlie s >= 1 and s <= n pak
    pro i od 1 do m opakuj
      a[i, s] := 0
  jinak
    napiš(s, " není platnı index sloupce");    
konec.