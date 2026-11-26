{ Prùmìr sudıch èísel vìtších ne 10 }
zaèátek
  èti(p);
  
  sum := 0;
  poèet := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    jestlie èíslo mod 2 = 0 and èíslo > 10 pak 
    zaèátek
      sum := sum + èíslo;
      poèet := poèet + 1;
    konec;  
  konec;
  
  jestlie poèet > 0 pak
    napiš("prùmìr sudıch èísel vìtších ne 10 je ", sum / poèet)
  jinak
    napiš("nebylo zadáno ádné planté èíslo");  
konec.