{ Seøazení dvou hodnot vzestupnì }
zaèátek
  èti(a);
  èti(b);

  jestliže a > b pak
  zaèátek
    p := a;
    a := b;
    b := p;
  konec;
  
  napiš(a, ", ", b);  
konec.