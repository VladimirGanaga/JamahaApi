using System;
using System.Collections.Generic;
using JamahaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JamahaApi;

public partial class YamahaContext : DbContext
{
    public YamahaContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=WIN10\\SQLEXPRESS;Database=Yamaha;Trusted_Connection=True;TrustServerCertificate=true;");
    }

    public DbSet<Modeldatacollection> Modeldatacollection { get; set; }
    public DbSet<Partsdatacollection> Partsdatacollection { get; set; } = null!;
}
