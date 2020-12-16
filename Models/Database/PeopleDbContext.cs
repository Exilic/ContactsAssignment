using System;
using Microsoft.EntityFrameworkCore;

namespace mvc_week4849.Models.Database
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> PersonList { get; set; }
    }
}
