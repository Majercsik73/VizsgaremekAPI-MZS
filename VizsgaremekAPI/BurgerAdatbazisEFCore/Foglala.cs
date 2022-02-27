using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Foglala
    {
        public Foglala()
        {
            Rendeles = new HashSet<Rendele>();
        }

        public int Fazon { get; set; }
        public int? Azon { get; set; }
        public int Szemelydb { get; set; }
        public DateTime Foglalasido { get; set; }
        public DateTime Leadva { get; set; }
        public bool Megjelent { get; set; }

        [NotMapped]
        public string FelhasznaloNev { get; set; }
        [JsonIgnore]
        public virtual Felhasznalo AzonNavigation { get; set; }
        public virtual ICollection<Rendele> Rendeles { get; set; }
    }
}
