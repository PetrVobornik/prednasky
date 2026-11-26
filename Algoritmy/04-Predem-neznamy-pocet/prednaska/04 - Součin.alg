{ Souèin pøedem neznámého poètu èísel zakonèenı nulou }
zaèátek
  souèin := 1;
  zadáno := 0;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    souèin := souèin * èíslo;
    zadáno := 1;
    èti(èíslo);
  konec;
  
  jestlie zadáno = 0 pak
    napiš("nebyla zadána ádná hodnota")
  jinak  
    napiš(souèin);
konec.