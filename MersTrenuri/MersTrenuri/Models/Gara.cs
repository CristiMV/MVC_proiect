using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MersTrenuri.Models
{
    public class Gara
    {
        ////[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Nume { get; set; }

        public virtual ICollection<StatieRuta> StatiiRuta{ get; set; }
    }
}



//using System.Collections.Generic;
/*
namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
*/