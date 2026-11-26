{ Vypsat posloupnost v opaèném poøadí  }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;  

  // Verze 1 
  i := n;
  dokud i >= 1 opakuj
  zaèátek
    napiš(a[i]);
    i := i - 1;
  konec;
  napiš("");
  
  // Verze 2    
  pro i od 1 do n opakuj
    napiš(a[n-i+1]);
konec.