{ Cyklický posun tøí promìnných vpøed (doleva) }
zaèátek
  a := 1;
  b := 2;
  c := 3;
  
  // 1,2,3 => 2,3,1
  
  napiš(a, " - ", b, " - ", c);  // 1 - 2 - 3
  
  p := a;
  a := b;
  b := c;
  c := p;
  
  napiš(a, " - ", b, " - ", c);  // 2 - 3 - 1
konec.