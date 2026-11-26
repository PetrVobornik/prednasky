{ Poèet minim - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  min := a[1];
  poèet := 1;
  pro i od 2 do n opakuj
    jestliže a[i] < min pak
    zaèátek
      min := a[i];
      poèet := 1;
    konec
    jinak  
      jestliže a[i] = min pak
        poèet := poèet + 1;
  
  napiš("minimum je ", min, " a je tam ", 
        poèet, "x");      
konec.