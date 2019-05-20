# Aplikace Kreslení

Tentokrát si vyzkoušíme vytvořit ucelenou apalikaci a to jednoduchý kreslící editor vektorových výkresů.

[Projekt Aplikace Kreslení](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/08-Kresleni/Kresleni)

[Ikony použité v aplikaci Kreslení](https://github.com/PetrVobornik/prednasky/raw/master/Xamarin.Forms/08-Kresleni/kresleni-ikony.zip) (vytvořeny v [Android Asset Studio](https://romannurik.github.io/AndroidAssetStudio/))

Přidané balíčky NuGet: [SkiaSharp](https://www.nuget.org/packages/SkiaSharp/), [SkiaSharp.Views.Forms](https://www.nuget.org/packages/SkiaSharp.Views.Forms/), [ColorPicker](https://www.nuget.org/packages/Amporis.Xamarin.Forms.ColorPicker/)


## Videozáznamy z přednášky Aplikace Kreslení

### Aplikace Kreslení 1/5 - Obrazce

V prvním díle video-tutoriálu s ukázkou vytvoření ucelené cross-platform aplikace Kreslení, si nejprve předvedeme, jak aplikace bude vypadat, až bude hotová, a pak začneme od začátku s jejím vývojem. Založíme nový Xamrin.Forms projekt ve Visual Studiu 2019 a připravíme základní třídy pro kreslení obrazců - bázovou třídu Obrazec a z ní odvozené podtřídy Obdelnik a Elipsa.

[![Aplikace Kreslení 1/5 - Obrazce](https://img.youtube.com/vi/gGIWSDz1i8E/0.jpg)](https://www.youtube.com/watch?v=gGIWSDz1i8E)

* 00:00 - Ukázka výsledné aplikace
* 01:38 - Založení projektu
* 05:10 - Bázová abstraktní třída Obrazec
* 11:28 - Obdélník
* 13:29 - Elipsa


### Aplikace Kreslení 2/5 - Ovládání

Ve druhém díle připravíme prvky pro ovládání aplikace Kreslení, naučíme ji přidat jeden zvolený obrazec a umožníme nastavení jeho pozice a rozměrů.

[![Aplikace Kreslení 2/5 - Ovládání](https://img.youtube.com/vi/ticE5EtMgcI/0.jpg)](https://www.youtube.com/watch?v=ticE5EtMgcI)

* 00:00 - Obsah hlavní stránky aplikace
* 06:29 - Dostupnost ikon podle stavu aplikace
* 10:12 - Přidávání obrazce do výkresu
* 13:45 - Reflexí generovaný seznam typů obrazců, které aplikace podporuje
* 16:13 - Vkládání vybraného obrazce na plochu výkresu
* 20:08 - Možnost úpravy pozice obrazce
* 23:39 - Možnost úpravy rozměrů obrazce


### Aplikace Kreslení 3/5 - Výkres

Ve třetím díle přidáme možnost vkládat do výkresu více různých obrazců, zobrazíme jejich seznam a s jeho pomocí umožníme jejich zpětnou editaci. Rozšíříme také možnosti nastavení obrazců, konkrétně o tloušťku čáry jejich obrysu a barvu výplně obrazce i jeho obrysu.

[![Aplikace Kreslení 3/5 - Výkres](https://img.youtube.com/vi/SFkRf4V09Xg/0.jpg)](https://www.youtube.com/watch?v=SFkRf4V09Xg)

* 00:00 - Dokončení úprav vloženého obrazce a přidávání dalších
* 03:53 - Přehled se seznamem obrazců
* 06:53 - Zpětná editace po kliknutí na obrazec v seznamu
* 11:13 - Úpravy vlastností obrazců
* 11:22 - Tloušťka čáry obrysu
* 14:07 - Barva obrysu
* 18:36 - Barva výplně


### Aplikace Kreslení 4/5 - Výkres

Čtvrtý díl bude věnován ukládání výkresu do souboru a možnosti jej později znovu načíst. Za tímto účelem obrazce naučíme serializovat a deserializovat se do/z XML elementu a to samozřejmě univerzálně s pomocí reflexe.

[![Aplikace Kreslení 4/5 - Výkres](https://img.youtube.com/vi/861Dipi8wg8/0.jpg)](https://www.youtube.com/watch?v=861Dipi8wg8)

* 00:00 - Složka pro ukládání souborů s výkresy
* 02:01 - Název souboru s aktuálním výkresem
* 03:17 - Nový výkres
* 05:45 - Tlačítko Uložit
* 06:01 - ToXml - serializace obrazce do XElementu
* 09:59 - FromXml - deserializace obrazce z XElementu
* 13:23 - Ukládání výkresu do XML souboru
* 18:22 - Ukázka obsahu uloženého XML souboru
* 19:34 - Načítání výkresu z XML souboru
* 25:24 - Kopie výkresu
* 26:35 - Tlačítko Zrušit v input dialogu


### Aplikace Kreslení 5/5 - Android

Závěrečný pátý díl shrne veškerou dosavadní práci, ukáže jak výtvor doposud testovaný pouze jako UWP aplikace funguje na Andoridu a jeho univerzálnost stvrdí přidání třídy s novým obrazcem (čárou, resp. úsečkou), která okamžitě začne fungovat na všech úrovních bez nutnosti jakékoli další úpravy kódu aplikace.

[![Aplikace Kreslení 5/5 - Android](https://img.youtube.com/vi/SquFQt_S8kg/0.jpg)](https://www.youtube.com/watch?v=SquFQt_S8kg)

* 00:00 - Android
* 02:29 - Zúžení pruhu se seznamem obrazců na užších displejích
* 05:41 - Další obrazec: Čára
* 08:53 - Shrnutí
* 15:47 - Název a ikony aplikace

---

[Další přednáška - Hra Asteroidy](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/09-Hra)
