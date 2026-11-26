{ Souèty všech sloupcù - v2 }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  pro j od 1 do n opakuj 
  zaèátek
    b[j] := 0;
    pro i od 1 do m opakuj
      b[j] := b[j] + a[i, j];
  konec;       
konec.