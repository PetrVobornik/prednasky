{ Prùmìr hodnot na r-tý øádku }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  èti(r);    
  souèet := 0;    
  pro j od 1 do n opakuj
    souèet := souèet + a[r, j];
  
  napiš("Prùmìr hodnot na ", r, ". øádku je ", 
        souèet / n);
konec.