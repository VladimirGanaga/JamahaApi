using System;
using System.Collections.Generic;
using JamahaApi.Models;
using Microsoft.EntityFrameworkCore;
using JamahaApi.Models;

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

    public DbSet<ModelsDB> ModelDB { get; set; }
    public DbSet<ChaptersDB> ChapterDB { get; set; } = null!;
    public DbSet<PartsDB> PartDB { get; set; } = null!;
}
