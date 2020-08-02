{ Cyklický posun ètyø promìnných vpøed (doleva) }
zaèátek
  a := 1;
  b := 2;
  c := 3;
  d := 4;
  
  // 1,2,3,4 => 2,3,4,1
  
  napiš(a, " - ", b, " - ", c, " - ", d); 
  
  p := a;
  a := b;
  b := c;
  c := d;
  d := p;
  
  napiš(a, " - ", b, " - ", c, " - ", d);  
konec.