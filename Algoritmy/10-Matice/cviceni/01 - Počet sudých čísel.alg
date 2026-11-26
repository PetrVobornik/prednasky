{ Poèet sudých èísel }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  poèet := 0;
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      jestliže a[i, j] mod 2 = 0 pak
        poèet := poèet + 1;
        
   napiš(poèet);   
konec.