{ Aritmetickı prùmìr z P èísel }
zaèátek
  èti(p);
  
  sum := 0;
  pro i od 1 do p opakuj
  zaèátek
    èti(èíslo);
    sum := sum + èíslo;
  konec;
  prùmìr := sum / p;
  
  napiš("prùmìr = ", prùmìr);
konec.