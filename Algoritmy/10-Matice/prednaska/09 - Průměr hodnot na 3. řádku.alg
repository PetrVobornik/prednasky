{ Prùmìr hodnot na 3. øádku }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 
      
  souèet := 0;    
  pro j od 1 do n opakuj
    souèet := souèet + a[3, j];
  
  napiš(souèet / n);     
konec.