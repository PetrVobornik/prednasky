{ Seøazení tøí rùznıch hodnot vzestupnì }
zaèátek
  èti(a);
  èti(b);
  èti(c);
  
  jestlie a > b pak
  zaèátek
    p := a; a := b;  b := p;  // a <=> b
  konec;
  jestlie b > c pak
  zaèátek
    p := b; b := c;  c := p;  // b <=> c
  konec;
  jestlie a > b pak
  zaèátek
    p := a; a := b;  b := p;  // a <=> b
  konec;
  
  napiš(a, ", ", b, ", ", c);
konec.