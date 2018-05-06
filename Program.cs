using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
           // SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();
            
            var initialGenres = new List<Genre>()
            {
                new Genre { Name = "Romance"},
                new Genre { Name = "Thriller"},
                new Genre { Name = "Horror"},
                new Genre { Name = "Fantasy"},
                new Genre { Name = "Crime"}
            };
            db.Genres.AddRange(initialGenres);
            db.SaveChanges();
        }
    }
}
