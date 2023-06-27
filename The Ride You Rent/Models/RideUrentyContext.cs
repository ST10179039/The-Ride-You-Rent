using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace The_Ride_You_Rent.models;

public partial class RideUrentyContext : DbContext
{
    public RideUrentyContext()
    {
    }

    public RideUrentyContext(DbContextOptions<RideUrentyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarBody> CarBodies { get; set; }

    public virtual DbSet<CarMake> CarMakes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Inspector> Inspectors { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Return1> Returns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnectionStringDev"));
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnectionStringAzure"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342E0C035EED");

            entity.ToTable("Car");

            entity.Property(e => e.CarId).ValueGeneratedNever();
            entity.Property(e => e.Availability)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("availability_");
            entity.Property(e => e.CDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("C_Description");
            entity.Property(e => e.CarBodyDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CarBody_Description");
            entity.Property(e => e.CarNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KmTravelled).HasColumnName("kmTravelled");
            entity.Property(e => e.VehicleModel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CarMake).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarMakeId)
                .HasConstraintName("FK__Car__CarMakeId__4D94879B");

            entity.HasOne(d => d.Carbody).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarbodyId)
                .HasConstraintName("FK__Car__CarbodyId__4E88ABD4");
        });

        modelBuilder.Entity<CarBody>(entity =>
        {
            entity.HasKey(e => e.CarbodyId).HasName("PK__CarBody__37316F808A0019E2");

            entity.ToTable("CarBody");

            entity.Property(e => e.CarbodyId).ValueGeneratedNever();
            entity.Property(e => e.CarBodyDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CarBody_Description");
        });

        modelBuilder.Entity<CarMake>(entity =>
        {
            entity.HasKey(e => e.CarMakeId).HasName("PK__Car_Make__A125EE7CBA71CC53");

            entity.ToTable("Car_Make");

            entity.Property(e => e.CarMakeId)
                .ValueGeneratedNever()
                .HasColumnName("CarMakeID");
            entity.Property(e => e.CDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("C_Description");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Driver__F1B1CD04E5D2E674");

            entity.ToTable("Driver");

            entity.Property(e => e.DriverId).ValueGeneratedNever();
            entity.Property(e => e.DAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("D_Address");
            entity.Property(e => e.DEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_Email");
            entity.Property(e => e.DMobile).HasColumnName("D_Mobile");
            entity.Property(e => e.DName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_Name");
        });

        modelBuilder.Entity<Inspector>(entity =>
        {
            entity.HasKey(e => e.InspectorId).HasName("PK__Inspecto__5FECC3DDD973FA4A");

            entity.ToTable("Inspector");

            entity.Property(e => e.InspectorId).ValueGeneratedNever();
            entity.Property(e => e.IEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("I_Email");
            entity.Property(e => e.IMobile).HasColumnName("I_Mobile");
            entity.Property(e => e.IName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("I_Name");
            entity.Property(e => e.InspectorNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inspector_No");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rentals__97005943E86F8167");

            entity.Property(e => e.RentalId).ValueGeneratedNever();
            entity.Property(e => e.CarNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_Name");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("I_Name");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Rentals__CarId__5535A963");

            entity.HasOne(d => d.Driver).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Rentals__DriverI__571DF1D5");

            entity.HasOne(d => d.Inspector).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.InspectorId)
                .HasConstraintName("FK__Rentals__Inspect__5629CD9C");
        });

        modelBuilder.Entity<Return1>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__Return___F445E9A8632F8B96");

            entity.ToTable("Return_");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.CarNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_Name");
            entity.Property(e => e.IName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("I_Name");
            entity.Property(e => e.RFine).HasColumnName("R_Fine");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.Returns)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Return___CarId__59FA5E80");

            entity.HasOne(d => d.Driver).WithMany(p => p.Returns)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Return___DriverI__5BE2A6F2");

            entity.HasOne(d => d.Inspector).WithMany(p => p.Returns)
                .HasForeignKey(d => d.InspectorId)
                .HasConstraintName("FK__Return___Inspect__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
