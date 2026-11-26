{ Vše pøed první nulou do B za ní do C - v1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;
    
  i := 1;
  dokud i <= n and a[i] <> 0 opakuj
  zaèátek
    b[i] := a[i];
    i := i + 1;
  konec;
  m := i-1; 
  
  jestliže i >= n pak
    napiš("Nula nenalezena nebo je poslední")
  jinak zaèátek 
    pro y od i+1 do n opakuj
      c[y-i] := a[y];
    p := n-i;  
  konec;   
konec.