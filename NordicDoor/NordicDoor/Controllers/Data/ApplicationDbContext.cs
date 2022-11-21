using Microsoft.EntityFrameworkCore;
using NordicDoor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NordicDoor.Entities;


namespace NordicDoor.Controllers.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<Bruker> Bruker { get; set; }

    public DbSet<Roller> Roller { get; set; }

    public DbSet<Forslag> Forslag { get; set; }

    public DbSet<Team_Medlemmer> Team_Medlemmer { get; set; }

    public DbSet<Team> Team { get; set; }

    public DbSet<Forslag_Status> Forslag_Status { get; set; }

    }





