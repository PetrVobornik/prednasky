{ Souèty všech øádkù }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  pro i od 1 do m opakuj
  zaèátek
    souèet := 0;
    pro j od 1 do n opakuj 
      souèet := souèet + a[i, j];
    b[i] := souèet;  
  konec;       
konec.