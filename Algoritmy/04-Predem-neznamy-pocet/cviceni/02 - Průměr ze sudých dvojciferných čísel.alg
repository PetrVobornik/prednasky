{ Prùmìr ze sudıch dvojcifernıch èísel }
zaèátek
  souèet := 0;
  poèet := 0;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo mod 2 = 0 and èíslo >= 10 and èíslo <= 99 pak
    zaèátek
      souèet := souèet + èíslo;
      poèet := poèet + 1;
    konec;
    èti(èíslo);
  konec;
  
  jestlie poèet = 0 pak
    napiš("nebylo zadáno ádné sudé dvojciferné èíslo")
  jinak  
    napiš(souèet / poèet);  
konec.