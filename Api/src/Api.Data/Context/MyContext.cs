﻿using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "ronaldo@gmail.com",
                    CreateAt = DateTime.Now,
                }
            );
        }
    }
}
