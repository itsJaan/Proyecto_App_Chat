using BackEnd.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEnd.Data
{

    public class BackEndDataContext: DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Channel> Channel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source= C:\\Users\\ItsJaan\\Desktop\\Proyecto_AppVAnguardia_2020\\BackEnd\\BackEnd.Data\\Database.db");
    }

}

