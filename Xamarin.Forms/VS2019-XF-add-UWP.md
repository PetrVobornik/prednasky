# Visual Studio 2019 - p�id�n� UWP projektu do XF �e�en�

V nov� verzi Visual Studio 2019 p�i zakl�d�n� nov�ho projektu typu Xamarin.Forms sch�z� volba pro automatick� vygenerov�n� projektu UWP (Universal Windows Platform).
Dle informac� na r�zn�ch f�rech se jedn� pouze o chybu, kter� se bohu�el dostala z Preview i do Release verze VS2019. 
Snad ji brzy vy�e��, nicm�n� zat�m lze UWP projekt p�idat do �e�en� i ru�n�, a to n�sleduj�c�m zp�sobem.

* Zalo�it nov� projekt (�e�en�) _Mobile App (Xamarin.Forms)_ - _Blank project_, kde chyb� UWP podprojekt
* P�idat do Solution nov� projekt UWP (_Blank App (Universal Windows)_) pojmenovan� jako �e�en� + _".UWP"_
* P�idat do UWP referenci na spole�n� (.NET Standard) projekt 
* Doinstalovat NuGet _Xamarin.Forms_ (a rovnou i _Xamarin.Essentials_)
* Do _App.xaml.cs_ p�idat do metody _OnLaunched_  
`Xamarin.Forms.Forms.Init(e);`  
mezi  
`rootFrame.NavigationFailed += OnNavigationFailed;`  
`// SEM to vlo�it`  
`if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)`
* V _MainPage.xaml_
  * P�idat definici  
`xmlns:forms="using:Xamarin.Forms.Platform.UWP"`
  * Zm�nit Root element z `Page` na `forms:WindowsPage`
* V _MainPage.xaml.cs_
  * Umazat b�zovou t��du "`: Page`"
  * P�idat do konstruktoru  
`LoadApplication(new Reflexe.App());`
