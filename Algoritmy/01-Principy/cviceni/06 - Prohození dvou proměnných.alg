{ Prohození dvou promìnných }
zaèátek
  a := 1;
  b := 2;
  
  napiš(a, " - ", b);  // 1 - 2

  p := b; // Položím na stùl pøedmìt z pravé ruky
  b := a; // Z levé do pravé
  a := p; // Zvednu ze stolu pøedmìt do levé ruky

  napiš(a, " - ", b);  // 2 - 1
konec