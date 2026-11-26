{ Souèin èlenù, jejichž index je sudý - v1 (takhle radìji ne) }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  
    
  souèin := 1;
  pro i od 1 do n opakuj
    jestliže i mod 2 = 0 pak
      souèin := souèin * a[i];
    
  napiš(souèin);    
konec.