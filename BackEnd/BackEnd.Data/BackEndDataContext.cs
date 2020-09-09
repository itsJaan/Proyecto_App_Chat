using BackEnd.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEnd.Data
{

    public class BackEndDataContext: DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Channel> Channel { get; set; }

        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source= Database.db");
    }
    //C:\\Users\\David\\Desktop\\Proyecto_App_Chat\\BackEnd\\BackEnd.Data\\
}

