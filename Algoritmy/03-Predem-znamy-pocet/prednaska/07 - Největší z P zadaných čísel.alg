{ Nejvìtší z P (P > 0) zadaných èísel }
zaèátek
  èti(p);
  
  èti(èíslo);
  max := èíslo;
  pro i od 2 do p opakuj
  zaèátek
    èti(èíslo);
    jestliže èíslo > max pak
      max := èíslo;
  konec;  
  
  napiš(max);
konec