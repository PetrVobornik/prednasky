{ Hodnota prvního èísla dìlitelného 5 
  zadaného po prvním zadání hodnoty 10 }
zaèátek
  hodnota := 1;
  
  èti(èíslo);
  dokud èíslo <> 0 opakuj
  zaèátek
    jestlie hodnota = 2 and èíslo mod 5 = 0 pak
      hodnota := èíslo;
    jestlie hodnota = 1 and èíslo = 10 pak
      hodnota := 2;  
    èti(èíslo);
  konec;
  
  jestlie hodnota mod 5 <> 0 pak
    napiš("nebyla zadána ádná hodnota dìlitelná pìti po 10")
  jinak  
    napiš(hodnota);  
konec.