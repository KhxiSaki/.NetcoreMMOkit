using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMO.Interfaces;

namespace MMO.Data
{


    public class DatabaseContext : DbContext
    {

        //dbset and table name defitinions here//
        //ideal for converting for old to new//

        public DbSet<SimpleValues> SimpleValues { get; set; }

        public DbSet<ActiveLogin> ActiveLogin { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Quest> Quest { get; set; }
        public DbSet<User> User { get; set; }

        public DatabaseContext()
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("SharedSettings.json")
           .Build();

            string connectionstring = configuration.GetConnectionString("DefaultConnection");


            optionsBuilder.UseSqlServer(connectionstring);
            //Server=myServerAddress\myServerInstance;Database=myDataBase;User Id=myUsername;Password = myPassword;
            //Server=.\LAPTOP-MGD888H3;Database=MMO_v1;Trusted_Connection=True;User Id= sa;Password=007007;



        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tag>()
            //    .Property(p => p.ID)
            //    .ValueGeneratedOnAdd();


        }
    }
}
