{ Maximum z lichých hodnot a jejich poèet (maxim) - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1; 
    
  max := 0; // je to jedno
  poèet := 0;
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 1 pak 
      jestliže a[i] > max or poèet = 0 pak
      zaèátek         
        max := a[i];
        poèet := 1;
      konec jinak
        jestliže a[i] = max and poèet > 0 pak
          poèet := poèet + 1;   
      
  jestliže poèet = 0 pak
    napiš("v posloupnosti není žádné liché èíslo")
  jinak      
    napiš("liché maximum je ", max, " a je tam ", 
          poèet, "x");       
konec.