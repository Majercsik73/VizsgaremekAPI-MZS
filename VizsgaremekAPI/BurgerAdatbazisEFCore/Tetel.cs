using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Tetel
    {
        public int Tazon { get; set; }
        public int? Razon { get; set; }
        public int Bazon { get; set; }
        public int? Bdb { get; set; }
        public int Kazon { get; set; }
        public int? Kdb { get; set; }
        public int Dazon { get; set; }
        public int? Ddb { get; set; }
        public int Iazon { get; set; }
        public int? Idb { get; set; }
        public int Etelstatus { get; set; }
        public int Italstatus { get; set; }
        public string Megjegyzes { get; set; }

        public virtual Burger BazonNavigation { get; set; }
        public virtual Desszert DazonNavigation { get; set; }
        public virtual Ital IazonNavigation { get; set; }
        public virtual Koret KazonNavigation { get; set; }
        [JsonIgnore]
        public virtual Rendele RazonNavigation { get; set; }
    }
}
