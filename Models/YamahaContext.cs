using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JamahaApi.Models;

public partial class YamahaContext : DbContext
{
    public YamahaContext()
    {
    }

    public YamahaContext(DbContextOptions<YamahaContext> options)
        : base(options)
    {
    }
   
    public virtual DbSet<Modeldatacollection> Modeldatacollections { get; set; }

    public virtual DbSet<Partsdatacollection> Partsdatacollections { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Data Source=WIN10\\SQLEXPRESS;Database=Yamaha;Trusted_Connection=True;TrustServerCertificate=true;");
    //    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Modeldatacollection>(entity =>
        {
            entity.ToTable("Modeldatacollection");

            entity.Property(e => e.CalledCode).HasColumnName("calledCode");
            entity.Property(e => e.ColorName).HasColumnName("colorName");
            entity.Property(e => e.ColorType).HasColumnName("colorType");
            entity.Property(e => e.ModelBaseCode).HasColumnName("modelBaseCode");
            entity.Property(e => e.ModelComment).HasColumnName("modelComment");
            entity.Property(e => e.ModelName).HasColumnName("modelName");
            entity.Property(e => e.ModelTypeCode).HasColumnName("modelTypeCode");
            entity.Property(e => e.ModelYear).HasColumnName("modelYear");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.ProdCategory).HasColumnName("prodCategory");
            entity.Property(e => e.ProdPictureFileUrl).HasColumnName("prodPictureFileURL");
            entity.Property(e => e.ProdPictureNo).HasColumnName("prodPictureNo");
            entity.Property(e => e.ProductNo).HasColumnName("productNo");
            entity.Property(e => e.ReleaseYymm).HasColumnName("releaseYymm");
            entity.Property(e => e.VinNoSearch).HasColumnName("vinNoSearch");
        });

        modelBuilder.Entity<Partsdatacollection>(entity =>
        {
            entity.ToTable("Partsdatacollection");

            entity.HasIndex(e => e.ModeldatacollectionId, "IX_Partsdatacollection_modeldatacollectionID");

            entity.Property(e => e.AppSerial).HasColumnName("appSerial");
            entity.Property(e => e.Chapter).HasColumnName("chapter");
            entity.Property(e => e.ModeldatacollectionId).HasColumnName("modeldatacollectionID");
            entity.Property(e => e.PartName).HasColumnName("partName");
            entity.Property(e => e.PartNewsFileUrl).HasColumnName("partNewsFileURL");
            entity.Property(e => e.PartNo).HasColumnName("partNo");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RefNo).HasColumnName("refNo");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.SelectableId).HasColumnName("selectableId");

            entity.HasOne(d => d.Modeldatacollection).WithMany(p => p.Partsdatacollections).HasForeignKey(d => d.ModeldatacollectionId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
