# Hra Asteroidy

V prozatím závěrečné části trošku odbočíme od Xamarin.Forms a podíváme se na multiplatformní vývoj her přostřednictvím Monogame.

[Projekt Hra Asteroidy](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/09-Hra/Asteroids)

[Obsah (content) použitý ve hře Asteroidy](https://github.com/PetrVobornik/prednasky/raw/master/Xamarin.Forms/09-Hra/hra-content.zip)

Přidané balíčky NuGet: [MonoGame.Framework.WindowsUniversal](https://www.nuget.org/packages/MonoGame.Framework.WindowsUniversal/), [MonoGame.Framework.Android](https://www.nuget.org/packages/MonoGame.Framework.Android/)



## Videozáznamy z přednášky Hra Asteroidy

### Hra Asteroidy 1/8 - Zahájení projektu

V první části se nejprve podíváme, jak hra bude vypadat, až bude hotová, a pak začneme pěkně od začátku, založením nového projektu (ukážeme si variantu založení ze šablon ve VS2017 i založení z čistých projektů ve VS2019 jen s NuGet balíčky Monogame) zatím UWP + projektu sdíleného. Hru dotáhneme až do spustitelné fáze s herní smyčkou a základní černou obrazovkou.

[![Hra Asteroidy 1/8 - Zahájení projektu](https://img.youtube.com/vi/mQSTk_C2NZc/0.jpg)](https://www.youtube.com/watch?v=mQSTk_C2NZc)

* 00:00 - Ukázka kýženého výsledku hotové hry
* 01:07 - Představení Monogame
* 02:27 - Založení projektu ve Visual Studio 2019
* 05:32 - Úprava UWP kódu pro Monogame
* 06:34 - Sdílený (shared) projekt
* 07:42 - Založení třídy s hrou GameAsteroids
* 09:40 - Propojení hry s UWP projektem
* 11:22 - Vytvoření herní smyčky
* 14:52 - První spuštění


### Hra Asteroidy 2/8 - Obloha a město

Ve druhé části do projektu přidáme připravený Content (obsah) s obrázky, fonty, zvuky a hudbou, přičemž si také nastíníme, kde jej vzít a jak jej připravit (zkompilovat do XNB souborů). Dále vytvoříme základní třídy pro objekty na herní scéně a s její pomocí vykreslíme oblohu v pozadí a přes ni město v popředí, které ve hře bude mít hráč za úkol bránit před padajícími asteroidy.

[![Hra Asteroidy 2/8 - Obloha a město](https://img.youtube.com/vi/st8DyEHuS7g/0.jpg)](https://www.youtube.com/watch?v=st8DyEHuS7g)

* 00:00 - Přidání obsahu (content) do sdíleného projektu
* 03:32 - Grafika pro pozadí hry
* 04:00 - Základní třída pro všechny herní objekty (Sprite)
* 07:31 - Třída pro vykreslování prvků do zadaného obdélníka
* 09:43 - Vykresování oblohy
* 14:17 - Vykreslování města


### Hra Asteroidy 3/8 - Rutiny

Ve třetí části vytvoříme další pomocnou třídu pro sprity, která bude umět vše potřebné, aby se potomci této třídy mohli již rovnou používat pro jednotlivé objekty, jež budou následovat. Půjde například o nastavení pozice objektu na herní scéně, jeho otáčení, pohyb, rychlost, velikost, základ frame animace atd. Zkrátka rutina, která nám ušetří spoustu následné práce.

[![Hra Asteroidy 3/8 - Rutiny](https://img.youtube.com/vi/R03QswymEz4/0.jpg)](https://www.youtube.com/watch?v=R03QswymEz4)

* 00:00 - Základní třída pro všechny pohyblivé objekty (SpriteItem)
* 01:06 - Vlastnosti objektů
* 04:09 - Vlastnosti pro frame animace spritů
* 05:05 - Pomocné vypočítavané vlastnosti
* 06:57 - Konstruktor
* 08:25 - Pomocná metoda pro posun objektů pod určitým úhlem
* 09:42 - Výpočet výřezu grafiky z celkové textury objektu
* 11:57 - Pohyb objektů
* 12:49 - Otáčení objektů
* 13:37 - Odstraňování objektů které odletěly za okraj
* 16:12 - Vykreslování objektů


### Hra Asteroidy 4/8 - Asteroidy

Ve čtvrté části přidáme do hry konečně nějaké pohyblivé části a těmi budou asteroidy. Bude jich hodně, budou různé, budou rotovat, a především padat dolů na město.

[![Hra Asteroidy 4/8 - Asteroidy](https://img.youtube.com/vi/8rJOuH6dPDw/0.jpg)](https://www.youtube.com/watch?v=8rJOuH6dPDw)

* 00:00 - Třída pro objekty asteroidů (SpriteAsteroid)
* 05:38 - Metoda Update
* 06:34 - Padání asteroidů
* 07:34 - Přidávání nových asteroidů do herní scény
* 09:40 - Posun asteroidů
* 10:03 - Vykreslování asteroidů


### Hra Asteroidy 5/8 - Kanón

V páté části vytvoříme hráčem ovládaný obranný prvek - obrovský kanón uprostřed města. Tím bude možné otáčet jak klikáním myši, tak dotykem, přičemž ho naučíme i vystřelovat rakety proti padajícím asteroidům.

[![Hra Asteroidy 5/8 - Kanón](https://img.youtube.com/vi/87sDalPCRRM/0.jpg)](https://www.youtube.com/watch?v=87sDalPCRRM)

* 00:00 - Třída pro objekty asteroidů (SpriteAsteroid)
* 05:38 - Metoda Update
* 06:34 - Padání asteroidů
* 07:34 - Přidávání nových asteroidů do herní scény
* 09:40 - Posun asteroidů
* 10:03 - Vykreslování asteroidů


### Hra Asteroidy 6/8 - Zásah a dopad

V šesté části se zaměříme na kolize objektů na scéně. Konkrétně tedy raket a asteroidů, které pokud se setkají, tedy když raketa zasáhne nějaký asteroid, tak dojde k explozi a oba objekty zmizí ze scény. No a pak také vyřešíme dopad asteroidu na chodník města, k čemu když dojde, nastane jiná, tentokrát méně pozitivní exploze v místě dopadu.

[![Hra Asteroidy 6/8 - Zásah a dopad](https://img.youtube.com/vi/lXSi0ETPvK8/0.jpg)](https://www.youtube.com/watch?v=lXSi0ETPvK8)

* 00:00 - Detekce zásahu asteroidu raketou
* 02:42 - Podpora frame animace (ve SpriteItem)
* 04:40 - Třída pro explozi zásahu asteroidu raketou (SpriteExplosionHit)
* 06:53 - Třída pro explozi dopadu asteroidu na zem (SpriteExplosionImpact)
* 08:15 - Správa explozí ve hře
* 10:38 - Přidání exploze po dopadu asteroidu


### Hra Asteroidy 7/8 - Audio a skóre

V sedmé části budeme počítat… zásahy a dopady, tedy skóre body za každý zasažený asteroid a mínus život za každý asteroid, který jsme nechali dopadnout a pobořil nám město. Boření města také naznačíme změnou jeho odstínu, no a když dojdou životy, nastane "game over".

[![Hra Asteroidy 7/8 - Audio a skóre](https://img.youtube.com/vi/t5yYQwYyctY/0.jpg)](https://www.youtube.com/watch?v=t5yYQwYyctY)

* 00:00 - Vytvoření proměnných pro audio soubory
* 00:49 - Načítání audio souborů
* 01:47 - Spuštění přehrávání hudby na pozadí
* 02:18 - Spouštění zvukových efektů
* 03:36 - Proměnné pro font a počítání skóre a životů
* 04:07 - Načtení fontu
* 04:30 - Počítání skóre a životů
* 05:12 - Vypisování skóre a životů na obrazovku
* 07:28 - Vypsání nápisu  "Game Over", když dojdou životy
* 08:30 - Zablokování ovládání po skončení hry
* 08:58 - Rudnutí města a tmavnutí oblohy s ubývajícími životy
* 11:11 - Shrnutí


### Hra Asteroidy 8/8 - Verze pro Android

V závěrečné osmé části přidáme ještě projekt pro Android, přizpůsobíme ho nastavení Monogame a dodáme mu vlastní obsah (content). Za pár minut tak z hotové hry pro Windows uděláme i hru pro mobily se systémem Android. Že vše funguje, jak má si samozřejmě ověříme na Android emulátoru.

[![Hra Asteroidy 8/8 - Verze pro Android](https://img.youtube.com/vi/sZhdYyAX-m8/0.jpg)](https://www.youtube.com/watch?v=sZhdYyAX-m8)

* 00:00 - Přidání projektu "Aplikace pro Android (Xamarin)"
* 00:59 - Instalace NuGet balíčku
* 01:26 - Úpravy MainActivity pro prvotní build aplikace
* 02:17 - Konfigurace atributu hlavní aktivity
* 04:10 - Úprava OnCreate aktivity a připojení sdíleného projektu
* 05:50 - Oddělení Content jen pro UWP
* 06:50 - Content pro Android
* 08:13 - Spuštění hry na Android emulátoru


---

[Zpět na přehled přednášek](https://github.com/PetrVobornik/prednasky)
