{ Souèin èlenù, jejichž index je sudý - v2 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1;  
    
  souèin := 1;
  i := 2;
  dokud i <= n opakuj
  zaèátek
    souèin := souèin * a[i];
    i := i + 2;  
  konec;    
    
  napiš(souèin);    
konec.