{ Vše za první nulou do B - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  i := 1;
  dokud i <= n and a[i] <> 0 opakuj
    i := i + 1;
  
  jestliže i >= n pak
    napiš("Nula nenalezena nebo je poslední")
  jinak zaèátek 
    pro y od i+1 do n opakuj
      b[y-i] := a[y];
    m := n-i;  
  konec;   
konec.