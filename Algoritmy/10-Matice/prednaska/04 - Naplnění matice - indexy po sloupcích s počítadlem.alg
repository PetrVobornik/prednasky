{ Naplnìní matice - indexy po sloupcích s poèítadlem }
zaèátek
  m := 4; // poèet øádkù
  n := 5; // poèet sloupcù
  x := 1;
  pro j od 1 do n opakuj  // pro všechny sloupce
    pro i od 1 do m opakuj    // pro všechny øádky
    zaèátek
      a[i, j] := x;
      x := x + 1;
    konec;    
konec.