{ Souèin prvkù na lichých øádcích
  a zároveò sudých sloupcích }
zaèátek
  m := 4;
  n := 5; 
  pro i od 1 do m opakuj   
    pro j od 1 do n opakuj 
      a[i, j] := random * 10 div 1; 

  souèin := 1;
  i := 1;
  dokud i <= m opakuj
  zaèátek
    j := 2;
    dokud j <= n opakuj
    zaèátek
      souèin := souèin * a[i, j];
      j := j + 2;
    konec;
    i := i + 2;
  konec;
  
  napiš(souèin); 
konec.