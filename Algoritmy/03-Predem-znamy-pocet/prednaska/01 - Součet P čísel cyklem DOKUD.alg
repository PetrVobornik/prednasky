{ Souèet P èísel cyklem DOKUD }
zaèátek
  èti(p);
  
  sum := 0;
  i := 1;
  dokud i <= p opakuj
  zaèátek
    èti(èíslo);
    sum := sum + èíslo;
    i := i + 1;
  konec;
  
  napiš("souèet = ", sum);
konec.