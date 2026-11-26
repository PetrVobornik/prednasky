{ Naplnìní matice - indexy po øádcích }
zaèátek
  m := 4; // poèet øádkù
  n := 5; // poèet sloupcù
  pro i od 1 do m opakuj    // pro všechny øádky
    pro j od 1 do n opakuj  // pro všechny sloupce
      a[i, j] := j + (i-1) * n;
konec.