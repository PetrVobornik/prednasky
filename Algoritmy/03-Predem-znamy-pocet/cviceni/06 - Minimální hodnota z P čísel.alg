{ Minimální hodnota z P èísel }
zaèátek
  èti(p);
  
  èti(èíslo);
  min := èíslo;
  pro i od 2 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo < min pak
      min := èíslo; 
  konec;
  
  napiš(min);
konec