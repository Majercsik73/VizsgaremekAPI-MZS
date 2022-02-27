using System;
using System.Collections.Generic;

#nullable disable

namespace VizsgaremekAPI.BurgerAdatbazisEFCore
{
    public partial class Felhasznalo
    {
        public Felhasznalo()
        {
            Foglalas = new HashSet<Foglala>();
        }

        public int Azon { get; set; }
        public string Nev { get; set; }
        public string Lak { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int Jog { get; set; }
        public string Pw { get; set; }

        public virtual ICollection<Foglala> Foglalas { get; set; }
    }
}
