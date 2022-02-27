using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Burger
    {
        public Burger()
        {
            Tetels = new HashSet<Tetel>();
        }

        public int Bazon { get; set; }
        public string Bnev { get; set; }
        public int Bar { get; set; }
        public string Bleir { get; set; }
        public bool? Aktiv { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tetel> Tetels { get; set; }
    }
}
