# Reflexe a lokalizace

Programujete nějaký rozsáhlý informační systém se spoustou formulářů, přehledů, oken/stránek atd.? 
A nebaví vás je neustále vytvářet, nastavovat, upravovat, předělávat, spravovat, testovat apod.?
Ideální část naučit se pracovat s reflexí! A to nejen v Xamarin.Forms projektech ale kdekoli.
Naprogramujte každý typ okna jen jednou, ale pořádně a univerzálně, a pak už stačí jen deklarovat datové třídy či konfigurační soubory a zbytek se bude generovat automaticky...


[Prezentace Reflexe a lokalizace](https://github.com/PetrVobornik/prednasky/blob/master/Xamarin.Forms/07-Reflexe/reflexe.ppsx?raw=true)

[Projekt Reflexe a lokalizace](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/07-Reflexe/Reflexe)

Přidané balíčky NuGet: [SQLite](https://www.nuget.org/packages/sqlite-net-pcl/)

Video záznam z přednášky již brzy...


## Univerzální editor databáze (SQLite)
* Automaticky hledá datové třídy v projektu
* Automaticky pro ně vytváří a aktualizuje DB tabulky
* Pro každou datovou třídu načte a zobrazí přehled všech záznamů v tabulce
* Pro každý záznam automaticky vygeneruje editační formulář a umožní tak jeho editaci, či vkládání nových
* Mezi tabulkami bude možné definovat reference (vztahy přes cizí klíče)
* Záznamy je možné mazat, avšak pouze za předpokladu, že se na ně neodkazuje záznam z jiné tabulky
* Veškeré texty a popisky v aplikaci budou lokalizované do češtiny a alespoň jednoho dalšího jazyka
* Lokalizován bude i název aplikace (z pohledu Store a OS)

