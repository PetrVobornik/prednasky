{ Výpis matice do výstupu ve formátu 2D tabulky }
zaèátek
  m := 5; // øádkù
  n := 6; // sloupcù
  pro i od 1 do m opakuj
    pro j od 1 do n opakuj
      a[i, j] := random * 10 div 1;
      
  pro i od 1 do m opakuj
  zaèátek
    radek := "";
    pro j od 1 do n opakuj
      radek := radek + a[i, j] + ", ";
    napiš(radek);  
  konec;
konec.