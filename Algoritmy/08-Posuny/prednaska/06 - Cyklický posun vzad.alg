{ Cyklický posun vzad (doprava/dolù)
  1,2,3,4,5 => 5,1,2,3,4 }
zaèátek
  n := 10;
  pro i od 1 do n opakuj
    a[i] := i;
  
  p := a[n];
  i := n;
  dokud i > 1 opakuj
  zaèátek
    a[i] := a[i-1];
    i := i - 1;
  konec;
// verze 2
{ 
  i := n-1;
  dokud i >= 1 opakuj
  zaèátek
    a[i+1] := a[i];
    i := i - 1;
  konec; 
}  
  a[1] := p;  
konec.