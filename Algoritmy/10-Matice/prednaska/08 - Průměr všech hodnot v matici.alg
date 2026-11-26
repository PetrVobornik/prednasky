{ Prùmìr všech hodnot v matici }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 
      
  souèet := 0;    
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj
      souèet := souèet + a[i, j];
  
  napiš(souèet / (m*n));     
konec.