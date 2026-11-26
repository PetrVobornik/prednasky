{ Seøazení dvou hodnot sestupnì }
zaèátek
  èti(a);
  èti(b);

  jestliže b > a pak
  zaèátek
    p := a;
    a := b;
    b := p;
  konec;
  
  napiš(a, ", ", b);  
konec.