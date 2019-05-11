using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MersTrenuri.Models
{
    public class Tren
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Rang { get; set; }

        public virtual ICollection<StatieTren> StatiiTren { get; set; }

    }
}
