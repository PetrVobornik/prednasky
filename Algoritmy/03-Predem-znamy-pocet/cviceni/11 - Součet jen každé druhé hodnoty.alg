{ Souèet jen kadé druhé hodnoty }
zaèátek
  èti(p);
  
  souèet := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie i mod 2 = 0 pak
      souèet := souèet + èíslo;
  konec;
  
  napiš(souèet);
konec.