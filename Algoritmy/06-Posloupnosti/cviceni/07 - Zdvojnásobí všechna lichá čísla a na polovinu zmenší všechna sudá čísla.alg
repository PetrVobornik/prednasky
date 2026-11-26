{ Zdvojnásobí všechna lichá èísla a na polovinu zmenší všechna sudá èísla }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  

  pro i od 1 do n opakuj
    napiš(i, ". ", a[i]);  
    
  pro i od 1 do n opakuj
  zaèátek
    jestliže a[i] mod 2 = 0 pak
      a[i] := a[i] / 2
    jinak 
      a[i] := a[i] * 2;
  konec;    
     
  pro i od 1 do n opakuj
    napiš(i, ". ", a[i]);  
konec.