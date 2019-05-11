using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Data.Entity;
using MersTrenuri.Models;


namespace MersTrenuri.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            
            var trenuri = new List<Tren>{
                //new Tren{ID=1, Rang="IR"},
                //new Tren{ID=2, Rang="R"}
                new Tren{ID=1001, Rang="IR"},
                new Tren{ID=1002, Rang="IR"},
                new Tren{ID=1011, Rang="IR"},
                new Tren{ID=1012, Rang="IR"},
                new Tren{ID=1021, Rang="IR"},
                new Tren{ID=1022, Rang="IR"},
                new Tren{ID=1031, Rang="IR"},
                new Tren{ID=1032, Rang="IR"},
                new Tren{ID=1041, Rang="IR"},
                new Tren{ID=1042, Rang="IR"},
                new Tren{ID=1051, Rang="IR"},
                new Tren{ID=1052, Rang="IR"},
                new Tren{ID=1061, Rang="IR"},
                new Tren{ID=1062, Rang="IR"},
            };
            trenuri.ForEach(s => context.Trenuri.Add(s));
            context.SaveChanges();
            
            var gari = new List<Gara> {
                //new Gara{ ID=1, Nume= "Pitesti"},//new Gara{ ID=2, Nume= "Pitesti Nord"},//new Gara{ ID=3, Nume= "Bucuresti Nord"},//new Gara{ ID=4, Nume= "Bucuresti Basarab"},

                new Gara{ ID=2001, Nume="Timisoara"},
                new Gara{ ID=2002, Nume="Craiova"},
                new Gara{ ID=2003, Nume="Pitesti"},
                new Gara{ ID=2004, Nume="Bucuresti"},
                new Gara{ ID=2005, Nume="Constanta"},
                new Gara{ ID=2006, Nume="Arad"},
                new Gara{ ID=2007, Nume="Sibiu"},
                new Gara{ ID=2008, Nume="Brasov"},
                new Gara{ ID=2009, Nume="Ploiesti"},
                new Gara{ ID=2010, Nume="Cluj-Napoca"},
                new Gara{ ID=2011, Nume="Targu Mures"},
                new Gara{ ID=2012, Nume="Bacau"},
                new Gara{ ID=2013, Nume="Satu Mare"},
                new Gara{ ID=2014, Nume="Iasi"},
                new Gara{ ID=2015, Nume="Baia Mare"},
                new Gara{ ID=2016, Nume="Suceava"},
            };
            gari.ForEach(s => context.Gari.Add(s));
            context.SaveChanges();
           
            var statiiTren = new List<StatieTren> {
                //new StatieTren{ TrenID = 1001, GaraID =2006, OraSosire= DateTime.Parse("2005-09-01"), OraPlecare=DateTime.Parse("2005-09-02")},

                //Tren 1 dus :

                new StatieTren{ TrenID = 1001, GaraID =2006, OraSosire= DateTime.Parse("08:00"), OraPlecare=DateTime.Parse("08:05")},
                new StatieTren{ TrenID = 1001, GaraID =2001, OraSosire= DateTime.Parse("09:00"), OraPlecare=DateTime.Parse("09:05")},
                new StatieTren{ TrenID = 1001, GaraID =2002, OraSosire= DateTime.Parse("11:00"), OraPlecare=DateTime.Parse("11:05")},
                new StatieTren{ TrenID = 1001, GaraID =2003, OraSosire= DateTime.Parse("13:00"), OraPlecare=DateTime.Parse("13:05")},
                new StatieTren{ TrenID = 1001, GaraID =2004, OraSosire= DateTime.Parse("15:00"), OraPlecare=DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1001, GaraID =2005, OraSosire= DateTime.Parse("21:00"), OraPlecare=DateTime.Parse("21:05")},


                //Tren 1 intors :


                new StatieTren{ TrenID = 1002, GaraID =2006, OraSosire= DateTime.Parse("11:00"), OraPlecare= DateTime.Parse("08:00")},
                new StatieTren{ TrenID = 1002, GaraID =2001, OraSosire= DateTime.Parse("10:00"), OraPlecare= DateTime.Parse("10:05")},
                new StatieTren{ TrenID = 1002, GaraID =2002, OraSosire= DateTime.Parse("08:00"), OraPlecare= DateTime.Parse("08:05")},
                new StatieTren{ TrenID = 1002, GaraID =2003, OraSosire= DateTime.Parse("06:00"), OraPlecare= DateTime.Parse("06:05")},
                new StatieTren{ TrenID = 1002, GaraID =2004, OraSosire= DateTime.Parse("04:00"), OraPlecare= DateTime.Parse("04:05")},
                new StatieTren{ TrenID = 1002, GaraID =2005, OraSosire= DateTime.Parse("22:00"), OraPlecare= DateTime.Parse("22:05")},


                //Tren 2 dus :


                new StatieTren{ TrenID = 1011, GaraID =2015, OraSosire= DateTime.Parse("10:00"), OraPlecare= DateTime.Parse("10:05")},
                new StatieTren{ TrenID = 1011, GaraID =2013, OraSosire= DateTime.Parse("12:00"), OraPlecare= DateTime.Parse("12:05")},
                new StatieTren{ TrenID = 1011, GaraID =2010, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1011, GaraID =2011, OraSosire= DateTime.Parse("17:00"), OraPlecare= DateTime.Parse("17:05")},
                new StatieTren{ TrenID = 1011, GaraID =2007, OraSosire= DateTime.Parse("19:00"), OraPlecare= DateTime.Parse("19:05")},
                new StatieTren{ TrenID = 1011, GaraID =2008, OraSosire= DateTime.Parse("21:00"), OraPlecare= DateTime.Parse("21:05")},
                new StatieTren{ TrenID = 1011, GaraID =2004, OraSosire= DateTime.Parse("23:00"), OraPlecare= DateTime.Parse("23:05")},


                //Tren 2 intors :


                new StatieTren{ TrenID = 1012, GaraID =2015, OraSosire= DateTime.Parse("14:00"), OraPlecare= DateTime.Parse("10:00")},
                new StatieTren{ TrenID = 1012, GaraID =2013, OraSosire= DateTime.Parse("12:00"), OraPlecare= DateTime.Parse("12:05")},
                new StatieTren{ TrenID = 1012, GaraID =2010, OraSosire= DateTime.Parse("09:00"), OraPlecare= DateTime.Parse("09:05")},
                new StatieTren{ TrenID = 1012, GaraID =2011, OraSosire= DateTime.Parse("07:00"), OraPlecare= DateTime.Parse("07:05")},
                new StatieTren{ TrenID = 1012, GaraID =2007, OraSosire= DateTime.Parse("05:00"), OraPlecare= DateTime.Parse("05:05")},
                new StatieTren{ TrenID = 1012, GaraID =2008, OraSosire= DateTime.Parse("03:00"), OraPlecare= DateTime.Parse("03:05")},
                new StatieTren{ TrenID = 1012, GaraID =2004, OraSosire= DateTime.Parse("01:00"), OraPlecare= DateTime.Parse("01:05")},


                //Tren 3 dus :


                new StatieTren{ TrenID = 1021, GaraID =2004, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1021, GaraID =2009, OraSosire= DateTime.Parse("16:00"), OraPlecare= DateTime.Parse("16:05")},
                new StatieTren{ TrenID = 1021, GaraID =2012, OraSosire= DateTime.Parse("18:00"), OraPlecare= DateTime.Parse("18:05")},
                new StatieTren{ TrenID = 1021, GaraID =2014, OraSosire= DateTime.Parse("20:00"), OraPlecare= DateTime.Parse("20:05")},
                new StatieTren{ TrenID = 1021, GaraID =2016, OraSosire= DateTime.Parse("22:00"), OraPlecare= DateTime.Parse("22:05")},


                //Tren 3 intors :


                new StatieTren{ TrenID = 1022, GaraID =2004, OraSosire= DateTime.Parse("06:00"), OraPlecare= DateTime.Parse("15:00")},
                new StatieTren{ TrenID = 1022, GaraID =2009, OraSosire= DateTime.Parse("05:00"), OraPlecare= DateTime.Parse("05:05")},
                new StatieTren{ TrenID = 1022, GaraID =2012, OraSosire= DateTime.Parse("03:00"), OraPlecare= DateTime.Parse("03:05")},
                new StatieTren{ TrenID = 1022, GaraID =2014, OraSosire= DateTime.Parse("01:00"), OraPlecare= DateTime.Parse("01:05")},
                new StatieTren{ TrenID = 1022, GaraID =2016, OraSosire= DateTime.Parse("23:00"), OraPlecare= DateTime.Parse("23:05")},


                //Tren 4 dus :


                new StatieTren{ TrenID = 1031, GaraID =2015, OraSosire= DateTime.Parse("06:00"), OraPlecare= DateTime.Parse("06:05")},
                new StatieTren{ TrenID = 1031, GaraID =2014, OraSosire= DateTime.Parse("14:00"), OraPlecare= DateTime.Parse("14:05")},
                new StatieTren{ TrenID = 1031, GaraID =2005, OraSosire= DateTime.Parse("22:00"), OraPlecare= DateTime.Parse("22:05")},


                //Tren 4 intors :


                new StatieTren{ TrenID = 1032, GaraID =2015, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("06:00")},
                new StatieTren{ TrenID = 1032, GaraID =2014, OraSosire= DateTime.Parse("07:00"), OraPlecare= DateTime.Parse("07:05")},
                new StatieTren{ TrenID = 1032, GaraID =2005, OraSosire= DateTime.Parse("23:00"), OraPlecare= DateTime.Parse("23:05")},


                //Tren 5 dus :


                new StatieTren{ TrenID = 1041, GaraID =2006, OraSosire= DateTime.Parse("07:00"), OraPlecare= DateTime.Parse("07:05")},
                new StatieTren{ TrenID = 1041, GaraID =2007, OraSosire= DateTime.Parse("12:00"), OraPlecare= DateTime.Parse("12:05")},
                new StatieTren{ TrenID = 1041, GaraID =2008, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1041, GaraID =2009, OraSosire= DateTime.Parse("17:00"), OraPlecare= DateTime.Parse("17:05")},
                new StatieTren{ TrenID = 1041, GaraID =2004, OraSosire= DateTime.Parse("20:00"), OraPlecare= DateTime.Parse("20:05")},


                //Tren 5 intors :


                new StatieTren{ TrenID = 1042, GaraID =2006, OraSosire= DateTime.Parse("10:00"), OraPlecare= DateTime.Parse("07:00")},
                new StatieTren{ TrenID = 1042, GaraID =2007, OraSosire= DateTime.Parse("05:00"), OraPlecare= DateTime.Parse("05:05")},
                new StatieTren{ TrenID = 1042, GaraID =2008, OraSosire= DateTime.Parse("02:00"), OraPlecare= DateTime.Parse("02:05")},
                new StatieTren{ TrenID = 1042, GaraID =2009, OraSosire= DateTime.Parse("00:00"), OraPlecare= DateTime.Parse("00:05")},
                new StatieTren{ TrenID = 1042, GaraID =2004, OraSosire= DateTime.Parse("21:00"), OraPlecare= DateTime.Parse("21:05")},


                //Tren 6 dus :

                new StatieTren{ TrenID = 1051, GaraID =2010, OraSosire= DateTime.Parse("11:00"), OraPlecare= DateTime.Parse("11:05")},
                new StatieTren{ TrenID = 1051, GaraID =2011, OraSosire= DateTime.Parse("13:00"), OraPlecare= DateTime.Parse("13:05")},
                new StatieTren{ TrenID = 1051, GaraID =2012, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1051, GaraID =2005, OraSosire= DateTime.Parse("21:00"), OraPlecare= DateTime.Parse("21:05")},


                //Tren 6 intors :

                new StatieTren{ TrenID = 1052, GaraID =2010, OraSosire= DateTime.Parse("08:00"), OraPlecare= DateTime.Parse("11:00")},
                new StatieTren{ TrenID = 1052, GaraID =2011, OraSosire= DateTime.Parse("06:00"), OraPlecare= DateTime.Parse("06:05")},
                new StatieTren{ TrenID = 1052, GaraID =2012, OraSosire= DateTime.Parse("04:00"), OraPlecare= DateTime.Parse("04:05")},
                new StatieTren{ TrenID = 1052, GaraID =2005, OraSosire= DateTime.Parse("22:00"), OraPlecare= DateTime.Parse("22:05")},


                //Tren 7 dus :


                new StatieTren{ TrenID = 1061, GaraID =2006, OraSosire= DateTime.Parse("00:00"), OraPlecare= DateTime.Parse("00:05")},
                new StatieTren{ TrenID = 1061, GaraID =2013, OraSosire= DateTime.Parse("03:00"), OraPlecare= DateTime.Parse("03:05")},
                new StatieTren{ TrenID = 1061, GaraID =2010, OraSosire= DateTime.Parse("05:00"), OraPlecare= DateTime.Parse("05:05")},
                new StatieTren{ TrenID = 1061, GaraID =2011, OraSosire= DateTime.Parse("07:00"), OraPlecare= DateTime.Parse("07:05")},
                new StatieTren{ TrenID = 1061, GaraID =2008, OraSosire= DateTime.Parse("09:00"), OraPlecare= DateTime.Parse("09:05")},
                new StatieTren{ TrenID = 1061, GaraID =2004, OraSosire= DateTime.Parse("11:00"), OraPlecare= DateTime.Parse("11:05")},
                new StatieTren{ TrenID = 1061, GaraID =2009, OraSosire= DateTime.Parse("13:00"), OraPlecare= DateTime.Parse("13:05")},
                new StatieTren{ TrenID = 1061, GaraID =2012, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("15:05")},
                new StatieTren{ TrenID = 1061, GaraID =2014, OraSosire= DateTime.Parse("17:00"), OraPlecare= DateTime.Parse("17:05")},
                new StatieTren{ TrenID = 1061, GaraID =2005, OraSosire= DateTime.Parse("19:00"), OraPlecare= DateTime.Parse("19:05")},


                //Tren 7 intors :


                new StatieTren{ TrenID = 1062, GaraID =2006, OraSosire= DateTime.Parse("15:00"), OraPlecare= DateTime.Parse("00:00")},
                new StatieTren{ TrenID = 1062, GaraID =2013, OraSosire= DateTime.Parse("12:00"), OraPlecare= DateTime.Parse("12:05")},
                new StatieTren{ TrenID = 1062, GaraID =2010, OraSosire= DateTime.Parse("10:00"), OraPlecare= DateTime.Parse("10:05")},
                new StatieTren{ TrenID = 1062, GaraID =2011, OraSosire= DateTime.Parse("08:00"), OraPlecare= DateTime.Parse("08:05")},
                new StatieTren{ TrenID = 1062, GaraID =2008, OraSosire= DateTime.Parse("06:00"), OraPlecare= DateTime.Parse("06:05")},
                new StatieTren{ TrenID = 1062, GaraID =2004, OraSosire= DateTime.Parse("04:00"), OraPlecare= DateTime.Parse("04:05")},
                new StatieTren{ TrenID = 1062, GaraID =2009, OraSosire= DateTime.Parse("02:00"), OraPlecare= DateTime.Parse("02:05")},
                new StatieTren{ TrenID = 1062, GaraID =2012, OraSosire= DateTime.Parse("00:00"), OraPlecare= DateTime.Parse("00:05")},
                new StatieTren{ TrenID = 1062, GaraID =2014, OraSosire= DateTime.Parse("22:00"), OraPlecare= DateTime.Parse("22:05")},
                new StatieTren{ TrenID = 1062, GaraID =2005, OraSosire= DateTime.Parse("20:00"), OraPlecare= DateTime.Parse("20:05")},

                //new StatieTren{ TrenID = 1, GaraID = 1, OraSosire= DateTime.Parse("7:50"), OraPlecare= DateTime.Parse("8:00") },
                //new StatieTren{ TrenID = 2, GaraID = 2, OraSosire= DateTime.Parse("8:50"), OraPlecare= DateTime.Parse("9:00") },
           };
            statiiTren.ForEach(s => context.StatiiTren.Add(s));
            context.SaveChanges();
            /**/
        }
    }
}

/*
using System;

using System.Linq;
using System.Web;
using System.Data.Entity;

*/

