{ Prùmìr sudých èlenù na lichých pozicích }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  
    
  souèet := 0;
  poèet := 0;
  i := 1;
  dokud i <= n opakuj
  zaèátek
    jestliže a[i] mod 2 = 0 pak
    zaèátek
      souèet := souèet + a[i];
      poèet := poèet + 1;
    konec;
    i := i + 2;  
  konec;    
    
  jestliže poèet > 0 pak  
    napiš(souèet / poèet)
  jinak
    napiš("nic nevyhovuje");      
konec.