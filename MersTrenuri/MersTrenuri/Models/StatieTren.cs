using System;
using System.ComponentModel.DataAnnotations;

namespace MersTrenuri.Models
{

    public class StatieTren
    {
        public int ID { get; set; }

        public int TrenID { get; set; } //FK
        public int GaraID { get; set; } //FK

        public int NrSt { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime OraSosire { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime OraPlecare { get; set; }


        public virtual Tren Tren { get; set; }

        public virtual Gara Gara { get; set; }
    }
}
