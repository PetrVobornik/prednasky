{ Aritmetickı prùmìr pøedem neznámého poètu èísel 
  zakonèenı nulou }
zaèátek
  souèet := 0;
  poèet := 0;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    souèet := souèet + èíslo;
    poèet := poèet + 1;
    èti(èíslo);
  konec;
  
  jestlie poèet = 0 pak
    napiš("nebyla zadána ádná hodnota")
  jinak  
    napiš(souèet / poèet);
konec.