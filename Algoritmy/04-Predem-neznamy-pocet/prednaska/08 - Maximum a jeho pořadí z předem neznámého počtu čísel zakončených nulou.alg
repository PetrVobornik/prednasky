{ Maximum a jeho poøadí z pøedem neznámého poètu èísel zakonèenıch nulou }
zaèátek
  èti(èíslo);
  max := èíslo;
  i := 1;
  poøadí := 1;
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie èíslo > max pak
    zaèátek
      max := èíslo;
      poøadí := i;  
    konec;   
    èti(èíslo);
    i := i + 1;
  konec;
  
  jestlie max = 0 pak
    napiš("nebyla zadáná ádná hodnota")
  jinak  
    napiš("max = ", max, ", poøadí = ", poøadí);
konec.