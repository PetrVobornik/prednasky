using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UkladaniDat
{
    [Table("Knihy")]
    public class Kniha
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), NotNull]
        public string Nazev { get; set; }

        [MaxLength(100)]
        public string Autor { get; set; }

        public int Rok { get; set; }

        public bool Precteno { get; set; }

        [Ignore]
        public string CelyNazev { get => $"{Nazev} ({Rok})"; }

    }
}
