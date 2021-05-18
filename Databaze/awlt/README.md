# AWLT

Ukázková databáze AdventureWorksLT (AWLT). Upraveno pro výukové účely z původního [zdroje](https://github.com/microsoft/sql-server-samples).


## Postup obnovy databáze AdventureWorksLT na SQL Serveru

### Lze ji buď obnovit ze zálohy 

* Stáhněte soubor [AdventureWorksLT.bak](https://github.com/PetrVobornik/prednasky/tree/master/Databaze/awlt/AdventureWorksLT.bak?raw=true) do na svůj počítač.
* Spusťte SSMS jako správce, připojte se k serveru, klikněte pravým tlačítkem na složku *Database*, a zvolte *Restore Database*.
* Zdroj (Source) zvolte *Device* a nalistujete (*Add*) uložený soubor *AdventureWorksLT.bak*.
* V *Destination* - *Database* zvolte název databáze, který tam zatím nemáte.
* Jedná-li se o opakovanou obnovu téže databáze, pak v položce *Files* změňte názvy nebo cesty k souborům na takové, které tam dosud nemáte.
* Klikněte na OK.

### nebo vytvořit SQL skriptem

* Stáhněte soubor [AdventureWorksLT.sql](https://github.com/PetrVobornik/prednasky/tree/master/Databaze/awlt/AdventureWorksLT.sql?raw=true).
* Spusťte SSMS jako správce, připojte se k serveru, a otevřete (Open file - Ctrl+O) stažený SQL soubor.
* Hned na začátku (řádky 7 a 9) je 2x *FILENAME = N'D:\awlt.mdf'* (podruhé je u soboru postfix '_log').
* Upravte cestu těchto dvou souborů do nějaké platné složky na vašem počítači, do které bude mít opravnění SQL Server zapisovat.
* Pokud již databázi s názvem 'awlt' máte vytvořenou, je třeba změnit název ve skriptu na jiný, dosud neexistující. Použijte funkci nahradit (Ctrl+H), jako hledaný text zadejte "[awlt]" (bez uvozovek, ale s hranatými závorkami), jako text pro nahrazení zadejte nový název (např. "[awlt_2]") a kliněte na nahradit vše (provede 38 nahrazení).
* Skript spusťte kliknutím na tlačítko *Execute*, okno se zprávami (*Messages*) by nemělo obsahovat žádná červená chybová hlášení.

 Otevřete nově vytvořenou databázi a prohlédněte si podrobně její tabulky.


---

[Zpět na přehled přednášek](https://github.com/PetrVobornik/prednasky)
