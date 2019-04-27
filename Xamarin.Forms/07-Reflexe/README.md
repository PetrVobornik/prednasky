# Reflexe a lokalizace

Programujete nějaký rozsáhlý informační systém se spoustou formulářů, přehledů, oken/stránek atd.? 
A nebaví vás je neustále vytvářet, nastavovat, upravovat, předělávat, spravovat, testovat apod.?
Ideální část naučit se pracovat s reflexí! A to nejen v Xamarin.Forms projektech ale kdekoli.
Naprogramujte každý typ okna jen jednou, ale pořádně a univerzálně, a pak už stačí jen deklarovat datové třídy či konfigurační soubory a zbytek se bude generovat automaticky...

[Prezentace Reflexe a lokalizace](https://github.com/PetrVobornik/prednasky/blob/master/Xamarin.Forms/07-Reflexe/reflexe.ppsx?raw=true)


## Univerzální editor databáze (SQLite)

* Automaticky hledá datové třídy v projektu
* Automaticky pro ně vytváří a aktualizuje DB tabulky
* Pro každou datovou třídu načte a zobrazí přehled všech záznamů v tabulce
* Pro každý záznam automaticky vygeneruje editační formulář a umožní tak jeho editaci, či vkládání nových
* Mezi tabulkami bude možné definovat reference (vztahy přes cizí klíče)
* Záznamy je možné mazat, avšak pouze za předpokladu, že se na ně neodkazuje záznam z jiné tabulky
* Veškeré texty a popisky v aplikaci budou lokalizované do češtiny a alespoň jednoho dalšího jazyka
* Lokalizován bude i název aplikace (z pohledu Store a OS)


[Projekt Reflexe a lokalizace](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/07-Reflexe/Reflexe)

Přidané komponenty: [SQLite](https://www.nuget.org/packages/sqlite-net-pcl/), [LookupPicker](https://www.nuget.org/packages/Amporis.Xamarin.Forms.LookupPicker)


# Záznamy z přednášky Reflexe a lokalizace

## 1/5 - Trocha teorie na úvod

V první části přednášky o reflexi a lokalizaci si vysvětlíme základní teoretické pojmy a ukážeme konstrukce kódu nezbytné pro práci s reflexí. Za účelem následné praktické ukázky založíme nový Xamarin.Forms projekt ve Visual Studiu 2019 a vytvoříme první datovou třídu.

[![Reflexe a lokalizace 1/5 - Trocha teorie na úvod](https://img.youtube.com/vi/dDDKcubt_t4/0.jpg)](https://www.youtube.com/watch?v=dDDKcubt_t4)

* 00:00:00 - Úvod
* 00:01:36 - Metadata o třídě (Type)
* 00:03:51 - Metadata o vlastnostech (PropertyInfo)
* 00:05:32 - Metadata o metodách (MethodInfo)
* 00:07:55 - Assembly (projekt / knihovna / sestava)
* 00:09:28 - Založení nového projektu (VS2019)
* 00:13:10 - Připojení k DB (SQLite)
* 00:16:25 - Datová třída Osoba
* 00:19:56 - Atributy - použití a tvorba vlastních
* 00:21:08 - Atributy - zpracování pomocí reflexe
* 00:22:27 - Důležité jmenné prostory

## Reflexe a lokalizace 2/5 - Přehledy, aneb seznam tabulek (datových tříd) a univerzální výpis dat ze kterékoli z nich

Ve druhé části přednášky o reflexi a lokalizaci pomocí reflexe automatizujeme vytváření databázových tabulek v SQLite pro všechny stávající i budoucí datové třídy a vytvoříme univerzální stránku s přehledem pro záznamy libovolné tabulky (objekty datové třídy).

[![Reflexe a lokalizace 2/5 - Přehledy, aneb seznam tabulek (datových tříd) a univerzální výpis dat ze kterékoli z nich](https://img.youtube.com/vi/7MYsFQd4eyQ/0.jpg)](https://www.youtube.com/watch?v=7MYsFQd4eyQ)

* 00:00:00 - Automatizované generování DB tabulek na základě datových tříd v projektu
* 00:03:13 - Přehled datových tříd/tabulek (MainPage)
* 00:05:58 - Popisek - sjednocení přiřazování popisků položek do jediné metody
* 00:06:53 - Datová třída Auto
* 00:08:32 - IData - společné rozhraní pro všechny datové třídy
* 00:09:25 - Stránka s přehledem záznamů tabulky (PrehledPage)



