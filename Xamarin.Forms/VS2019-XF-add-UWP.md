# Visual Studio 2019 - pøidání UWP projektu

V nové verzi Visual Studio 2019 pøi zakládání nového projektu typu Xamarin.Forms schází volba pro automatické vygenerování projektu UWP (Universal Windows Platform).
Dle informací na rùzných fórech se jedná pouze o chybu, která se bohužel dostala z Preview i do Release verze VS2019. 
Snad ji brzy vyøeší, nicménì zatím lze UWP projekt pøidat do øešení i ruènì, a to následujícím zpùsobem...

* Založit nový projekt (øešení) _Mobile App (Xamarin.Forms)_ - Blank project, kde chybí UWP podprojekt
* Pøidat do Solution nový projekt UWP (_Blank App (Universal Windows)_) pojmenovaný jako øešení + ".UWP"
* Pøidat do UWP referenci na spoleèný (.NET Standard) projekt 
* Doinstalovat NuGet _Xamarin.Forms_ (a rovnou i _Xamarin.Essentials_)
* Do _App.xaml.cs_ pøidat do metody _OnLaunched_
  *Xamarin.Forms.Forms.Init(e);<br/>
mezi<br/>
rootFrame.NavigationFailed += OnNavigationFailed;<br/>
// SEMto vložit<br/>
if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
* V _MainPage.xaml_
  * Pøidat definici<br/>xmlns:forms="using:Xamarin.Forms.Platform.UWP"
  * Zmìnit Root element z _Page_ na _forms:WindowsPage_
* V _MainPage.xaml.cs_
  * Umazat bázovou tøídu _": Page"_
  * Pøidat do konstruktoru<br/>_LoadApplication(new Reflexe.App());_
