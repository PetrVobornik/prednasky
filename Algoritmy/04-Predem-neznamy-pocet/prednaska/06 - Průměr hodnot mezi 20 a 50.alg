{ Prùmìr hodnot mezi 20 a 50 }
zaèátek
  souèet := 0;
  poèet := 0;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo >= 20 and èíslo <= 50 pak
    zaèátek
      souèet := souèet + èíslo;
      poèet := poèet + 1;
    konec;  
    èti(èíslo);
  konec;
  
  jestlie poèet > 0 pak
    napiš(souèet / poèet);
konec.