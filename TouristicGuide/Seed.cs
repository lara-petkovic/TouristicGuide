using System;
using System.Collections.Generic;
using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Models;

namespace TouristicGuide
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Tours.Any())
            {
                //var user = new User
                //{
                //        Id = 1,
                //        Username = "luka",
                //        Password = "luka",
                //        Name = "Luka",
                //        Surname = "Petronijevic"
                    
                //};



                //var tours = new List<Tour>
                //    {
                //        new Tour
                //        {
                //            Id = 1,
                //            LocationId = 1,
                //            Name = "Novi Sad City Tour",
                //            Description = "Explore the Petrovaradin Fortress"
                //        },
                //        new Tour
                //        {
                //            Id = 2,
                //            LocationId = 3,
                //            Name = "Nevesinje Tour",
                //            Description = "Experience the City of Sport"
                //        },
                //    };

                //    var appointments = new List<Appointment>
                //    {
                //        new Appointment
                //        {
                //            Tour = tours[0],
                //            DateTime = new DateTime(2025,10,22,10,30,0)
                //        },
                //        new Appointment
                //        {
                //            Tour = tours[1],
                //            DateTime = new DateTime(2024,1,22,11,00,0)
                //        },
                //    };

                //    dataContext.Users.Add(user);
                //    dataContext.Locations.AddRange(locations);
                //dataContext.Tours.Add(tours[0]);
                //    dataContext.Appointments.AddRange(appointments);

                //Location location = new Location
                //{
                //    City = "Nevesinje",
                //    Country = "Bosnia and Herzegovina"
                //};
                //  dataContext.Locations.Add(location);
                //dataContext.SaveChanges();
                //}
            }
        }
    }
}
