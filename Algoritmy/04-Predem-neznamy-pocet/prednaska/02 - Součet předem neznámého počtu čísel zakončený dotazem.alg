{ Souèet pøedem neznámého poètu èísel zakonèený dotazem }
zaèátek
  souèet := 0;
  
  èti(hotovo);
  dokud hotovo <> "ANO" opakuj
  zaèátek
    èti(èíslo);
    souèet := souèet + èíslo;
    èti(hotovo);
  konec;
  
  napiš(souèet);  
konec.