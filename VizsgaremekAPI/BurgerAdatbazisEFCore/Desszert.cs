using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Desszert
    {
        public Desszert()
        {
            Tetels = new HashSet<Tetel>();
        }

        public int Dazon { get; set; }
        public string Dnev { get; set; }
        public int Dar { get; set; }
        public string Dleir { get; set; }
        public bool? Aktiv { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tetel> Tetels { get; set; }
    }
}
