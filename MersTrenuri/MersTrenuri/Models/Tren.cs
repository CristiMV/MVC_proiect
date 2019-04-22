
using System.Collections.Generic;

namespace MersTrenuri.Models
{
    public class Tren
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Rang { get; set; }

        public virtual ICollection<StatieRuta> StatiiRuta { get; set; }

    }
}


//namespace ContosoUniversity.Models
/*
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }

        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
*/