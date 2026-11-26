{ Poøadí prvního vıskytu minimální hodnoty z P èísel }
zaèátek
  èti(p);
  
  èti(èíslo);
  min := èíslo;
  poøadí := 1;
  pro i od 2 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo < min pak
    zaèátek
      min := èíslo;
      poøadí := i;
    konec;   
  konec;
  
  napiš("Nejmenší èíslo ", min, " bylo poprvé zadnáno jako ", 
        poøadí, ". v poøadí");
konec