{ Souèin první a poslední zadané hodnoty (P >= 2) - v2 }
zaèátek
   èti(p);
   
   souèin := 1;
   pro i od 1 do p opakuj
   zaèátek
     èti(èíslo);
     jestlie i = 1 or i = p pak
       souèin := souèin * èíslo;
   konec;
   
   napiš(souèin);
konec.