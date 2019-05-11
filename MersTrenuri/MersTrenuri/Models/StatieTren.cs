using System;

namespace MersTrenuri.Models
{

    public class StatieTren
    {
        public int ID { get; set; }
        public int TrenID { get; set; } //FK
        public int GaraID { get; set; } //FK

        public DateTime OraSosire { get; set; }
        public DateTime OraPlecare { get; set; }


        public virtual Tren Tren { get; set; }

        public virtual Gara Gara { get; set; }
    }
}
