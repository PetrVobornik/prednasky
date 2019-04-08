# Visual Studio 2019 - pøidání UWP projektu do XF øešení

V nové verzi Visual Studio 2019 pøi zakládání nového projektu typu Xamarin.Forms schází volba pro automatické vygenerování projektu UWP (Universal Windows Platform).
Dle informací na rùzných fórech se jedná pouze o chybu, která se bohužel dostala z Preview i do Release verze VS2019. 
Snad ji brzy vyøeší, nicménì zatím lze UWP projekt pøidat do øešení i ruènì, a to následujícím zpùsobem.

* Založit nový projekt (øešení) _Mobile App (Xamarin.Forms)_ - _Blank project_, kde chybí UWP podprojekt
* Pøidat do Solution nový projekt UWP (_Blank App (Universal Windows)_) pojmenovaný jako øešení + _".UWP"_
* Pøidat do UWP referenci na spoleèný (.NET Standard) projekt 
* Doinstalovat NuGet _Xamarin.Forms_ (a rovnou i _Xamarin.Essentials_)
* Do _App.xaml.cs_ pøidat do metody _OnLaunched_  
`Xamarin.Forms.Forms.Init(e);`  
mezi  
`rootFrame.NavigationFailed += OnNavigationFailed;`  
`// SEM to vložit`  
`if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)`
* V _MainPage.xaml_
  * Pøidat definici  
`xmlns:forms="using:Xamarin.Forms.Platform.UWP"`
  * Zmìnit Root element z `Page` na `forms:WindowsPage`
* V _MainPage.xaml.cs_
  * Umazat bázovou tøídu "`: Page`"
  * Pøidat do konstruktoru  
`LoadApplication(new Reflexe.App());`
