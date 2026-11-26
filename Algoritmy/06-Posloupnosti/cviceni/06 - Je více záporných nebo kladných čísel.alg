{ Je více záporných nebo kladných èísel? }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := random * 10 div 1 - 5;  
    
  poèetK := 0;
  poèetZ := 0;
  pro i od 1 do n opakuj
  zaèátek
    jestliže a[i] < 0 pak
      poèetZ := poèetZ + 1;
    jestliže a[i] > 0 pak
      poèetK := poèetK + 1;
  konec;    
     
    
  jestliže poèetZ = poèetK pak  
    napiš("záporných je stejnì jako kladných")
  jinak jestliže poèetZ > poèetK pak  
    napiš("záporných je více")
  jinak
    napiš("kladných je více")
konec.