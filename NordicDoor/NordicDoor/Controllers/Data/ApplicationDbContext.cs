using System;
using Microsoft.EntityFrameworkCore;
using NordicDoor.Models;
using NordicDoor.Controllers.Data;
using System.Collections.Generic;

namespace NordicDoor.Controllers.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Bruker> Bruker { get; set; }

    public DbSet<Roller> Roller { get; set; }

    public DbSet<Forslag> Forslag { get; set; }

    public DbSet<Team_Medlemmer> Team_Medlemmer { get; set; }

    public DbSet<Team> Team { get; set; }

}




