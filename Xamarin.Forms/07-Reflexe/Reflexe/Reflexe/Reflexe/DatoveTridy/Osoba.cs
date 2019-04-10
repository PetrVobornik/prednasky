using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflexe
{
    [Table("Osoby")]
    public class Osoba : IData
    {
        [PrimaryKey, AutoIncrement, SkrytVeFormu]
        public int Id { get; set; }

        public string Jmeno { get; set; }

        public string Prijmeni { get; set; }

        public DateTime DatumNarozeni { get; set; }

        public int Vyska { get; set; }

        public override string ToString() => $"{Prijmeni} {Jmeno} ({DatumNarozeni:yyyy})";
    }
}
