{ Souèin P èísel }
zaèátek
  èti(p);
  
  souèin := 1;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    souèin := souèin * èíslo;
  konec;
  
  jestlie p = 0 pak
    napiš("nebyla zadána ádná hodnota")
  jinak  
    napiš("souèin = ", souèin);
konec.