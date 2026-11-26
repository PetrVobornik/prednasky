{ Souèet kladnıch hodnot za prvním minimem
  (bude zadáno alespoò jedno nenulové èíslo) }
zaèátek
  
  èti(èíslo);
  min := èíslo;
  jestlie èíslo > 0 pak
    souèet := -èíslo
  jinak  
    souèet := 0;
  
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo > 0 pak
      souèet := souèet + èíslo;
    jestlie èíslo < min pak
    zaèátek
      min := èíslo;
      souèet := 0;
    konec;  
    èti(èíslo);
  konec;   

  napiš(souèet);
konec.