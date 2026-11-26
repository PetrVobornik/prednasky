{ Maximum a poèet jeho výskytù }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  max := a[1, 1]; 
  poèet := 0;
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      jestliže a[i, j] > max pak
      zaèátek
        max := a[i, j];
        poèet := 1;
      konec jinak
        jestliže a[i, j] = max pak
          poèet := poèet + 1;
        
   napiš("maximum je ", max, " a je tam ", poèet, "x");   
konec.