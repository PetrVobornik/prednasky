# Ukládání dat

Představíme si tři základní varianty pro ukládání a načítání dat v aplikacích. Podle jejich typu půjde o základní hodnoty většinou používané pro nastavení aplikace, o celé soubory dat a v neposlední řadě o možnosti využití mobilního databázového systému.

[![Ukládání dat - záznam z přednášky](https://img.youtube.com/vi/mb8xvo9CBXM/0.jpg)](https://www.youtube.com/watch?v=mb8xvo9CBXM)

[Prezentace Ukládání dat](https://github.com/PetrVobornik/prednasky/blob/master/Xamarin.Forms/06-UkladaniDat/ukladani-dat.ppsx?raw=true)

## Možnosti ukládání dat
* Nastavení aplikace 
  * Preferences z Xamarin.Essentials
  * Ukázka - datový objekt automaticky ukládající změny v nastavení
  * Zabezpečená varianta - SecureStorage
  * Ukázka - uložení a načtení hesla
* Soubory v úložišti aplikace
  * FileSystem z Xamarin.Essentials
  * Třídy System.IO
  * Ukázka - správce textových souborů s možností editace
  * Získávání souborů ze zařízení, z jiných aplikací a internetu
  * Ukázka - stažení obrázku do pozadí aplikace přes WebView
* Mobilní databáze SQLite
  * Třídy definující tabulky
  * Připojení k databázi
  * Čtení a ukládání dat
  * Ukázka - databáze knih

---

[Další přednáška - Reflexe](https://github.com/PetrVobornik/prednasky/tree/master/Xamarin.Forms/07-Reflexe)
