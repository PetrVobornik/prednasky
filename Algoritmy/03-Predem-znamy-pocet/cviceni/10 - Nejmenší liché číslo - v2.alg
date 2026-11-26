{ Nejmenší liché èíslo - v1 }
zaèátek
  èti(p);
  
  min := 2;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo mod 2 = 1 and (min = 2 or èíslo < min) pak
      min := èíslo;
  konec;
  
  jestlie min = 2 pak
    napiš("nebyla zadána ádná lichá hodnota")
  jinak  
    napiš(min);
konec.