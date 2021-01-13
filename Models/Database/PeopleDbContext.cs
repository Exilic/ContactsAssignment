using System;
using Microsoft.EntityFrameworkCore;

namespace mvc_week4849.Models.Database
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> PersonList { get; set; }
        public DbSet<City> CitiesList { get; set; }
        public DbSet<Country> CountriesList { get; set; }
        public DbSet<Language> LanguagesList { get; set; }
        public DbSet<PersonLanguage> PersonLanguagesList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>()
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);
        }
    }
}
