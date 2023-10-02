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
                var users = new List<User>
                {
                    new User
                    {
                        Username = "lara",
                        Password = "lara",
                        Name = "Lara",
                        Surname = "Petkovic",
                        Appointments = new List<Appointment>()
                    },
                    new User
                    {
                        Username = "luka",
                        Password = "luka",
                        Name = "Luka",
                        Surname = "Petkovic",
                        Appointments = new List<Appointment>()
                    },
                };

                var locations = new List<Location>
                {
                    new Location
                    {
                        City = "Novi Sad",
                        Country = "Serbia"
                    },
                    new Location
                    {
                        City = "Paris",
                        Country = "France"
                    },
                };

                var tours = new List<Tour>
                {
                    new Tour
                    {
                        User = users[0],
                        Location = locations[0],
                        Name = "Novi Sad City Tour",
                        Description = "Explore the Petrovaradin Fortress",
                    },
                    new Tour
                    {
                        User = users[1],
                        Location = locations[1],
                        Name = "Paris City Tour",
                        Description = "Experience the City of Love",
                    },
                };

                var appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        Tour = tours[0],
                        DateTime = new DateTime(2025,10,22,10,30,0)
                    },
                    new Appointment
                    {
                        Tour = tours[1],
                        DateTime = new DateTime(2024,1,22,11,00,0)
                    },
                };

                dataContext.Users.AddRange(users);
                dataContext.Locations.AddRange(locations);
                dataContext.Tours.AddRange(tours);
                dataContext.Appointments.AddRange(appointments);
                dataContext.SaveChanges();
            }
        }
    }
}
