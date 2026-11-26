{ Souèty všech sloupcù - v1 }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  pro j od 1 do n opakuj 
  zaèátek
    souèet := 0;
    pro i od 1 do m opakuj
      souèet := souèet + a[i, j];
    b[j] := souèet;  
  konec;       
konec.