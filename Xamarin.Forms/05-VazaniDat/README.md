# Vázání dat

Na několika názorných ukázkách si vysvětlíme a vyzkoušíme základní principy vázání dat neboli DataBindingu, při kterém se vlastnosti datových objektů provazují s vlastnostmi ovládacích prvků, umožňujících jejich přímou editaci bez nutnosti obslužného kódu na pozadí.

[![Vázání dat - záznam z přednášky](https://img.youtube.com/vi/VB3ZpOXpq40/0.jpg)](https://www.youtube.com/watch?v=VB3ZpOXpq40)

[Prezentace Vázání dat](https://github.com/PetrVobornik/prednasky/blob/master/Xamarin.Forms/05-VazaniDat/vazani-dat.ppsx?raw=true)

## Postupy při vázání dat
* Datové objekty implementují rozhraní INotifyPropertyChanged
* Ovládací prvky editovanou hodnotu provážou s vlastností objektu přes Binding
* Editovaný datový objekt se s editorem/y prováže přes BindingContext prvku či kontejneru
* Hodnotu lze během editace v ovládacím prvku konvertovat přes IValueConverter
* Vlastní ovládací prvky, potomky třídy BindableObject, mohou mít své "propojitelné" vlastnosti
