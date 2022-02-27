using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Rendele
    {
        public Rendele()
        {
            Tetels = new List<Tetel>();
        }

        public int Razon { get; set; }
        public int? Fazon { get; set; }
        public int Asztal { get; set; }
        public DateTime Ido { get; set; }
        public int Etelstatus { get; set; }
        public int Italstatus { get; set; }
        [JsonIgnore]
        public virtual Foglala FazonNavigation { get; set; }
        public virtual List<Tetel> Tetels { get; set; }
    }
}
