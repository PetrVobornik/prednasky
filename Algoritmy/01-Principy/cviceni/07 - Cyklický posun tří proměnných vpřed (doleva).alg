{ Cyklick� posun t�� prom�nn�ch vp�ed (doleva) }
za��tek
  a := 1;
  b := 2;
  c := 3;
  
  // 1,2,3 => 2,3,1
  
  napi�(a, " - ", b, " - ", c);  // 1 - 2 - 3
  
  p := a;
  a := b;
  b := c;
  c := p;
  
  napi�(a, " - ", b, " - ", c);  // 2 - 3 - 1
konec.