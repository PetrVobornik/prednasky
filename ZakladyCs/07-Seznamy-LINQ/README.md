# Seznamy a LINQ

## Seznamy

Posloupnosti a matice již známe perfektně, takže můžeme postoupit k dalším typům kolekcí, jako jsou seznamy (List) a slovníky (Dictionary). A přitom se podíváme ještě na metody rozšíření (extension methods), jak fungují, jak je používat a hlavně, jak vytvářet vlastní.

[Projekt Seznamy](https://github.com/PetrVobornik/prednasky/tree/master/ZakladyCs/07-Seznamy/Seznamy)


Seznamy (List)
* 00:00 - Úvod
* 00:28 - Deklarace
* 02:09 - Naplnění seznamu náhodnými hodnotami
* 04:12 - Vypsání seznamu - for
* 05:31 - Vkládání a odebírání prvků do/ze seznamu
* 07:31 - Vypsání seznamu - foreach
* 09:07 - Metoda Vypis - klasická verze

Metody rozšíření (extension methods)
* 11:19 - Metoda Vypis jako metoda rozšíření
* 14:47 - Další rozšiřující metody

Slovníky (Dictionary)
* 23:11 - Deklarace
* 23:46 - Plnění slovníku
* 26:27 - Čtení ze slovníku
* 26:58 - Ověření existence klíče
* 27:51 - Procházení slovníku přes položky
* 29:10 - Procházení slovníku přes klíče
* 30:22 - Seznam klíčů

Převody mezi seznamy různých typů
* 31:03 - Pole / Seznam
* 31:48 - Slovník ze seznamu
* 34:44 - Konec


## LINQ

Navážeme na předchozí téma o seznamech a vyzkoušíme si na nich různé LINQ funkce. Metody rozšíření, které LINQ poskytuje, nám umožní většinu algoritmů, které jsme doposud složitě dlouhým a kódem vytvářeli, zapsat do jediného krátkého řádku.

[Projekt LINQ](https://github.com/PetrVobornik/prednasky/tree/master/ZakladyCs/07-Seznamy/LINQ)


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

[Další přednáška - Soubory](https://github.com/PetrVobornik/prednasky/tree/master/ZakladyCs/09-Soubory)
