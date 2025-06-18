using DAL;
using Eventary_API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntergrationTests
{
    //WebApplicationFactory .NET hulpklas voor integratietests
    public class EventaryWebApplicationFactory : WebApplicationFactory<Program>
    {
        // Deze klasse configureert de testomgeving voor integratietests
        // ConfigureWebHost roept .NET als de applicatie start
        // IWebHostBuilder is een interface die alle instellingen verzamelt
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // Voor ik mijn app opstart in de testomgeving maak ik een lijst
            // Services met type DbContextOptions<AppDbContext>
            // en services die AppDbContext bevatten
            builder.ConfigureServices(services =>
            {
                var descriptorsToRemove = services
                    .Where(d =>
                        d.ServiceType == typeof(DbContextOptions<AppDbContext>) ||
                        d.ServiceType.FullName!.Contains("AppDbContext"))
                    .ToList();

                //Voor elke descriptor in die lijst verwijder ik deze uit de services
                foreach (var descriptor in descriptorsToRemove)
                {
                    services.Remove(descriptor);
                }

                // Nu voeg ik een nieuwe DbContext toe met een InMemoryDatabase
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDatabase");
                });

                // Hier voeg ik de overige services toe die nodig zijn voor de applicatie
                // Bouw een object dat services kan leveren
                var sp = services.BuildServiceProvider();

                // Scope is een tijdelijke werkruimte, gebruikt de serviceprovider
                using var scope = sp.CreateScope();
                // Haal de database uit de lijst van services
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                // Maakt de database aan als deze nog niet bestaat
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Testdata toevoegen voor categorie en bedrijf
                db.category.Add(new CORE.Models.Category { Id = 1, Name = "Test Category" });
                db.company.Add(new CORE.Models.Company { Id = 1, Name = "Test Company" });
                db.SaveChanges();
            });
        }
    }
}
