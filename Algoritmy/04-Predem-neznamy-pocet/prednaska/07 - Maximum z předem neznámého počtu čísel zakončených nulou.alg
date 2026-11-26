{ Maximum z pøedem neznámého poètu èísel zakonèenıch nulou }
zaèátek
  èti(èíslo);
  max := èíslo;
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo > max pak
      max := èíslo; 
    èti(èíslo);
  konec;
  
  jestlie max = 0 pak
    napiš("nebyla zadáná ádná hodnota")
  jinak  
    napiš(max);
konec.