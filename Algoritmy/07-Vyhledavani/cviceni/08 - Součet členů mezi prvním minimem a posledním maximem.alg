{ Souèet èlenù mezi prvním minimem a posledním maximem }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1; 
    
  iMinF := 1;
  iMaxL := 1;
  pro i od 2 do n opakuj
  zaèátek
    jestliže a[i] <  a[iMinF] pak
      iMinF := i;
    jestliže a[i] >= a[iMaxL] pak
      iMaxL := i;
  konec;
  
  jestliže (iMaxL - iMinF) >= -1 and
           (iMaxL - iMinF) <= 1 pak
    napiš("extrémy jsou moc u sebe")
  jinak 
  zaèátek
    jestliže iMaxL < iMinF pak
    zaèátek
      p := iMaxL;
      iMaxL := iMinF;
      iMinF := p; 
    konec;
    
    souèet := 0;
    pro i od iMinF+1 do iMaxL-1 opakuj
      souèet := souèet + a[i];
  
    napiš(souèet);       
  konec;      
konec.