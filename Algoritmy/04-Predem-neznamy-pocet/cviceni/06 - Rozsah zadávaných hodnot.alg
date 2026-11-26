{ Rozsah zadávanıch hodnot (max-min), 
  bude zadáno alespoò jedno nenulové èíslo }
zaèátek
  èti(èíslo);
  min := èíslo;
  max := èíslo;
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo < min pak
      min := èíslo;
    jestlie èíslo > max pak
      max := èíslo;  
    èti(èíslo);
  konec;
  
  napiš("Rozsah zadanıch èísel je ", max - min + 1);  
konec.