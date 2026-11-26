{ Seøazení tøí rùzných hodnot sestupnì }
zaèátek
  èti(a);      
  èti(b);
  èti(c);      // 1, 2, 3 => 2, 1, 3 => 2, 3, 1 => 3, 2, 1

  jestliže a < b pak
  zaèátek
    p := a; a := b; b := p;  // a <=> b
  konec;
  jestliže b < c pak
  zaèátek
    p := b; b := c; c := p;  // b <=> c
  konec;
  jestliže a < b pak
  zaèátek
    p := a; a := b; b := p;  // a <=> b
  konec;
  
  napiš(a, ", ", b, ", ", c);  
konec.