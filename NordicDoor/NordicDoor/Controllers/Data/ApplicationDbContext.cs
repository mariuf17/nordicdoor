using System;
using Microsoft.EntityFrameworkCore;
using NordicDoor.Models;
using NordicDoor.Controllers.Data;

namespace NordicDoor.Controllers.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Bruker> Bruker { get; set; }

    public DbSet<Team> Team { get; set; }


}




