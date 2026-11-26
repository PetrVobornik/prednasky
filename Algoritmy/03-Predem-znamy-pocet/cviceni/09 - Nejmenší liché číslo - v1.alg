{ Nejmenší liché èíslo - v2 }
zaèátek
  èti(p);
  
  min := 2;
  nalezen := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo mod 2 = 1 and (nalezen = 0 or èíslo < min) pak
    zaèátek
      min := èíslo;
      nalezen := 1;
    konec;  
  konec;
  
  jestlie nalezen = 0 pak
    napiš("nebyla zadána ádná lichá hodnota")
  jinak  
    napiš(min);
konec.