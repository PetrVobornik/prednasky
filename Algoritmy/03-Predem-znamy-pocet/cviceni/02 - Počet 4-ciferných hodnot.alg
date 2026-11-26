{ Poèet 4-cifernıch hodnot }
zaèátek
  èti(p);
  
  poèet := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo >= 1000 and èíslo <= 9999 pak
      poèet := poèet + 1;
  konec;
  
  napiš(poèet);  
konec.