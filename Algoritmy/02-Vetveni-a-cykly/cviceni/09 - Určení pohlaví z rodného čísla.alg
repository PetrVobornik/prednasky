{ Urèení pohlaví z rodného èísla }
zaèátek
  èti(rc);  // 920612 => muž,  925612 => žena
  
  x := rc div 1000 mod 10;
  
  jestliže x = 0 or x = 1 pak
    napiš("muž")
  jinak
    napiš("žena");  
konec.