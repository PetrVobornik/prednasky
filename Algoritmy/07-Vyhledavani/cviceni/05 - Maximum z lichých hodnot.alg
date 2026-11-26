{ Maximum z lichých hodnot }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1; 
    
  max := 2;
  pro i od 1 do n opakuj
    jestliže a[i] mod 2 = 1 and 
             (a[i] > max or max = 2) pak
      max := a[i];   
      
  jestliže max = 2 pak
    napiš("v posloupnosti není žádné liché èíslo")
  jinak      
    napiš(max);       
konec.