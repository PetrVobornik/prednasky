{ DIV a MOD - zpìtný výpoèet }
zaèátek
  èti(x);
  èti(y);
  
  d := x div y;
  m := x mod y;
  
  px := y * d + m;
  py := (x - m) / d;
konec