{ Souèet sudıch èísel vìtších ne 10 }
zaèátek
  èti(p);
  
  souèet := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo > 10 and èíslo mod 2 = 0 pak
      souèet := souèet + èíslo;
  konec;
  
  napiš(souèet);
konec.