using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflexe
{
    [Table("Auta")]
    public class Auto : IData
    {
        [PrimaryKey, AutoIncrement, SkrytVeFormu]
        public int Id { get; set; }

        public string SPZ { get; set; }

        public string Vyrobce { get; set; }

        public string Typ { get; set; }

        public DateTime DatumUvedeniDoProvozu { get; set; }

        public int Najeto { get; set; }

        [Reference(typeof(Osoba))]
        public int? Majitel { get; set; }

        public override string ToString() => $"{Vyrobce} {Typ} ({SPZ})";
    }
}
