{ Souèin první a poslední zadané hodnoty (P >= 2) - v1 }
zaèátek
   èti(p);
   
   pro i od 1 do p opakuj
   zaèátek
     èti(èíslo);
     jestlie i = 1 pak
       è1 := èíslo;
     jestlie i = p pak
       è2 := èíslo;
   konec;
   
   souèin := è1 * è2;
   
   napiš(souèin);
konec.