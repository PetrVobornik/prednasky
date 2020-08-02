{ Cyklický posun tøí promìnných vzad (doprava) }
zaèátek
  a := 1;
  b := 2;
  c := 3;
  
  // 1,2,3 => 3,1,2
  
  napiš(a, " - ", b, " - ", c);  // 1 - 2 - 3
  
  p := c;
  c := b;
  b := a;
  a := p;
  
  napiš(a, " - ", b, " - ", c);  // 3 - 1 - 2
konec.