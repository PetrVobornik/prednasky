{ Naplnìní matice - náhodné }
zaèátek
  m := 4; // poèet øádkù
  n := 5; // poèet sloupcù
  pro i od 1 do m opakuj    // pro všechny øádky
    pro j od 1 do n opakuj  // pro všechny sloupce
      a[i, j] := random * 10 div 1; 
konec.