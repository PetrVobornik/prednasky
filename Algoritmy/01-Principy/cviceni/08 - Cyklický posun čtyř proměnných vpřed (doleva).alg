{ Cyklick� posun �ty� prom�nn�ch vp�ed (doleva) }
za��tek
  a := 1;
  b := 2;
  c := 3;
  d := 4;
  
  // 1,2,3,4 => 2,3,4,1
  
  napi�(a, " - ", b, " - ", c, " - ", d); 
  
  p := a;
  a := b;
  b := c;
  c := d;
  d := p;
  
  napi�(a, " - ", b, " - ", c, " - ", d);  
konec.