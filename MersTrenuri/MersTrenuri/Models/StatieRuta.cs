using System;

namespace MersTrenuri.Models
{

    public class StatieRuta
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

/*
namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
*/