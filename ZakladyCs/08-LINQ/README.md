# LINQ

Navážeme na předchozí téma o seznamech a vyzkoušíme si na nich různé LINQ funkce. Metody rozšíření, které LINQ poskytuje, nám umožní většinu algoritmů, které jsme doposud složitě dlouhým a kódem vytvářeli, zapsat do jediného krátkého řádku.

[Projekt LINQ](https://github.com/PetrVobornik/prednasky/tree/master/ZakladyCs/08-LINQ/LINQ)

[![LINQ - záznam z přednášky](https://img.youtube.com/vi/FwqJ1mBLbu8/0.jpg)](https://youtu.be/FwqJ1mBLbu8)

[Videozáznam z přednášky LINQ](https://youtu.be/FwqJ1mBLbu8)


AGREGAČNÍ FUNKCE
* 00:00 - Úvod
* 00:47 - Součet (Sum), počet (Count), průměr (Average), Minimum a Maximum
* 02:20 - Podmíněný počet
* 03:32 - Podmíněný součet

Testy celého seznamu
* 04:23 - All - splňují všechny prvky podmínku?
* 05:08 - Any - splňuje alespoň jeden prvek podmínku?
* 05:28 - Contains - obsahuje seznam konkrétní prvek/hodnotu?

PODČÁSTI SEZNAMU
* 06:23 - Úvod
* 06:37 - Where - filtrování prvků
* 08:22 - Výsledek filtru jako základ pro další výpočty
* 09:12 - Distinct - vyřazení duplicit

Řazení
* 09:38 - OrderBy - vzestupné řazení
* 10:16 - OrderByDescending - sestupné řazení
* 10:34 - ThenBy, TenByDescending - víceúrovňové řazení

Práce se seznamem textových řetězců
* 11:56 - Vytvoření
* 12:41 - Statistiky pole textů
* 12:52 - Délka všech textů s mezerou mezi nimi
* 13:27 - Průměrná délka slova
* 13:54 - Délka nejdelšího slova

Podčásti seznamu textových řetězců
* 14:07 - Vypsání všech nejdelších slov
* 15:44 - Select (modifikace prvků seznamu) - slova v apostrofech
* 16:41 - Select - slova a jejich délky
* 17:04 - Řazení textových řetězců
* 17:44 - Vícestupňové řazení textů
* 18:21 - Reverse - obrácení seznamu

Podčásti podle pozice
* 18:55 - Úvod
* 19:04 - Take - podčást ze začátku seznamu
* 19:21 - První 3 prvky podle abecedy
* 19:44 - První prvek dle abecedy
* 20:05 - Skip - přeskočení části seznamu
* 20:24 - Skip+Take - podčást ze středu seznamu
* 20:48 - TakeWhile - podčást ze začátku až po první prvek s určitou vlastností
* 21:38 - SkipeWhile - podčást od prvního prvku s určitou vlastností

Jeden prvek seznamu
* 22:08 - First, Last - první/poslední prvek seznamu
* 23:24 - První/poslední prvek vyhovující zadané podmínce
* 24:23 - FirstOrDefault, LastOrDefault - první/poslední prvek s danou vlastností, nebo nic
* 25:19 - FirstOrDefault, LastOrDefault bez parametru - první/poslední prvek seznamu, nebo nic
* 25:37 - ElementAt, ElementAtOrDefault - prvek na určité pozici (indexu)

SPOJOVÁNÍ SEZNAMŮ
* 26:32 - Úvod
* 27:22 - Concat - spojení
* 27:49 - Union - sloučení
* 28:24 - Except - rozdíl
* 29:10 - Intersect - společné prvky

SESKUPOVÁNÍ A PLNÝ LINQ ZÁPIS
* 29:43 - Úvod
* 30:00 - GroupBy (vytvoření skupin podle klíče) - slova seskupená dle prvního znaku

Plný LINQ zápis vs. metody rozšíření s lambda výrazem
* 34:24 - Úvod
* 34:44 - Výpis sudých prvků - lambda zápis
* 35:24 - Výpis sudých prvků - plný LINQ zápis
* 37:02 - Přidání řazení do obou verzí
* 37:21 - Skupiny čísel podle zbytků po dělení 5 (seskupování pomocí plného LINQ zápisu)

ZÁVĚREČNÉ SHRNUTÍ
* 39:52 - Shrnutí celého projektu
* 44:05 - Závěr

---

[Další přednáška - Textové soubory](https://github.com/PetrVobornik/prednasky/tree/master/ZakladyCs/09-SouboryTextove)
