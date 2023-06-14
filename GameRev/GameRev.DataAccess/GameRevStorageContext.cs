﻿using GameRev.DataAccess.CQRS.Queries.Games;
using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess
{
    public class GameRevStorageContext : DbContext
    {
        public GameRevStorageContext(DbContextOptions<GameRevStorageContext> opt) : base(opt)
        {            
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>()
            //    .HasMany(e => e.Genres)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("GameGenre"));

            modelBuilder.Entity<Game>()
                .Property(x => x.Genres)
                .HasConversion(
                x => string.Join(',', x),
                x => x.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Enum.Parse<Genre>(x)).ToList());

            base.OnModelCreating(modelBuilder);
        }
    }
}
