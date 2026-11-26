{ Souèet hodnot mezi 20 a 50 }
zaèátek
  souèet := 0;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo >= 20 and èíslo <= 50 pak
      souèet := souèet + èíslo;
    èti(èíslo);
  konec;
  
  napiš(souèet);
konec.