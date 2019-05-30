using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;


namespace MersTrenuri.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
		
		public int ID_t {get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Nr_telefon { get; set; }
		
    }
}