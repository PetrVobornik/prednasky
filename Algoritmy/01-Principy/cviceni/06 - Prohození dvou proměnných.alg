{ Prohozen� dvou prom�nn�ch }
za��tek
  a := 1;
  b := 2;
  
  napi�(a, " - ", b);  // 1 - 2

  p := b; // Polo��m na st�l p�edm�t z prav� ruky
  b := a; // Z lev� do prav�
  a := p; // Zvednu ze stolu p�edm�t do lev� ruky

  napi�(a, " - ", b);  // 2 - 1
konec