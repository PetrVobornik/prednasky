{ Souèet hodnot v posloupnosti }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  

  souèet := 0;
  pro i od 1 do n opakuj
    souèet := souèet + a[i];
    
  napiš(souèet);  
konec.