{ Cyklick� posun t�� prom�nn�ch vzad (doprava) }
za��tek
  a := 1;
  b := 2;
  c := 3;
  
  // 1,2,3 => 3,1,2
  
  napi�(a, " - ", b, " - ", c);  // 1 - 2 - 3
  
  p := c;
  c := b;
  b := a;
  a := p;
  
  napi�(a, " - ", b, " - ", c);  // 3 - 1 - 2
konec.