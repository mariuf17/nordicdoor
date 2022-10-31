using System;
using Microsoft.EntityFrameworkCore;
using NordicDoor.Models;

namespace NordicDoor.Controllers.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Bruker> Bruker { get; set; }




}




