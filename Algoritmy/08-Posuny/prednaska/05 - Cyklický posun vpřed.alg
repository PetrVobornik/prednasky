{ Cyklický posun vpøed (doleva/nahoru)
  1,2,3,4,5 => 2,3,4,5,1 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
    
  p := a[1];
  pro i od 1 do n-1 opakuj
    a[i] := a[i+1];
//  verze 2
//  pro i od 2 do n opakuj
//    a[i-1] := a[i];
  a[n] := p;    
konec.