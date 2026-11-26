{ První lichá hodnota }
zaèátek
  plh := 2;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie plh = 2 and èíslo mod 2 = 1 pak
      plh := èíslo;
    èti(èíslo);
  konec;
  
  jestlie plh = 2 pak
    napiš("nebyla zadána ádná lichá hodnota")
  jinak  
    napiš(plh);  
konec.