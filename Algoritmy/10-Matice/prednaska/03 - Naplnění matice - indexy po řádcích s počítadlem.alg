{ Naplnìní matice - indexy po øádcích s poèítadlem }
zaèátek
  m := 4; // poèet øádkù
  n := 5; // poèet sloupcù
  x := 1;
  pro i od 1 do m opakuj    // pro všechny øádky
    pro j od 1 do n opakuj  // pro všechny sloupce
    zaèátek
      a[i, j] := x;
      x := x + 1;
    konec;    
konec.