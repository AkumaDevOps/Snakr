using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Snakr.Models;

public partial class SnakrDbContext : DbContext
{
    public SnakrDbContext()
    {
    }

    public SnakrDbContext(DbContextOptions<SnakrDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Favouriteproduct> Favouriteproducts { get; set; }

    public virtual DbSet<Masterbranch> Masterbranches { get; set; }

    public virtual DbSet<Mastergroup> Mastergroups { get; set; }

    public virtual DbSet<Masterproduct> Masterproducts { get; set; }

    public virtual DbSet<Masterprovider> Masterproviders { get; set; }

    public virtual DbSet<Masteruser> Masterusers { get; set; }

    public virtual DbSet<Mastervendingmachine> Mastervendingmachines { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Usergrouppayment> Usergrouppayments { get; set; }

    public virtual DbSet<Usergrouppaymentproduct> Usergrouppaymentproducts { get; set; }

    public virtual DbSet<Usergroupsmachinesreservation> Usergroupsmachinesreservations { get; set; }

    public virtual DbSet<Vendingmachinesbranch> Vendingmachinesbranches { get; set; }

    public virtual DbSet<Vendingmachinesbranchesproduct> Vendingmachinesbranchesproducts { get; set; }

    public virtual DbSet<Vendingrefill> Vendingrefills { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Absence>(entity =>
        {
            entity.HasKey(e => new { e.IdMasterUsers, e.IdMasterGroups, e.IdUserGroupsMachinesReservations })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("absences");

            entity.HasIndex(e => e.IdMasterGroups, "IdMasterGroups_FK_idx");

            entity.HasIndex(e => e.IdUserGroupsMachinesReservations, "IdUserGroupsMachinesReservations_FK_idx");

            entity.Property(e => e.IdMasterUsers).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterGroups).HasColumnType("int(11)");
            entity.Property(e => e.IdUserGroupsMachinesReservations).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterGroupsNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdMasterGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Absences_IdMasterGroups_FK");

            entity.HasOne(d => d.IdMasterUsersNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdMasterUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Absences_idMasterUsers_FK");

            entity.HasOne(d => d.IdUserGroupsMachinesReservationsNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdUserGroupsMachinesReservations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Absences_IdUserGroupsMachinesReservations_FK");
        });

        modelBuilder.Entity<Favouriteproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("favouriteproducts");

            entity.HasIndex(e => e.IdMasterGroups, "IdMasterGroups_FK_idx");

            entity.HasIndex(e => e.IdMasterUsers, "IdMasterUsers_FK_idx");

            entity.HasIndex(e => e.IdMasterProducts, "IdProduct_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterGroups).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterProducts).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterUsers).HasColumnType("int(11)");
            entity.Property(e => e.OrderNumber)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SugarQuantity).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterGroupsNavigation).WithMany(p => p.Favouriteproducts)
                .HasForeignKey(d => d.IdMasterGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favouriteproducts_IdMasterGroups_FK");

            entity.HasOne(d => d.IdMasterProductsNavigation).WithMany(p => p.Favouriteproducts)
                .HasForeignKey(d => d.IdMasterProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favouriteproducts_IdMasterProducts_FK");

            entity.HasOne(d => d.IdMasterUsersNavigation).WithMany(p => p.Favouriteproducts)
                .HasForeignKey(d => d.IdMasterUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favouriteproducts_IdMasterUsers_FK");
        });

        modelBuilder.Entity<Masterbranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masterbranches");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BranchName).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Mastergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mastergroups");

            entity.HasIndex(e => e.IdMasterBranches, "MasterGroups_IdMasterBranch_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterBranches).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Masterproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masterproducts");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Brand).HasMaxLength(45);
            entity.Property(e => e.Description).HasMaxLength(45);
            entity.Property(e => e.Model).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Masterprovider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masterproviders");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyNameL).HasMaxLength(100);
            entity.Property(e => e.CompanyNameS).HasMaxLength(10);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.StreetAddress).HasMaxLength(100);
        });

        modelBuilder.Entity<Masteruser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masterusers");

            entity.HasIndex(e => e.IdMasterBranches, "MasterUsers_IdMasterBranch_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.IdMasterBranches).HasColumnType("int(11)");
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.UserName).HasMaxLength(45);

            entity.HasOne(d => d.IdMasterBranchesNavigation).WithMany(p => p.Masterusers)
                .HasForeignKey(d => d.IdMasterBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MasterUsers_IdMasterBranch_FK");

            entity.HasMany(d => d.IdMasterGroups).WithMany(p => p.IdMasterUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Usergroup",
                    r => r.HasOne<Mastergroup>().WithMany()
                        .HasForeignKey("IdMasterGroups")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("UsersGroups_IdMasterGroups_FK"),
                    l => l.HasOne<Masteruser>().WithMany()
                        .HasForeignKey("IdMasterUsers")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("UsersGroups_IdMasterUsers_FK"),
                    j =>
                    {
                        j.HasKey("IdMasterUsers", "IdMasterGroups")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("usergroups");
                        j.HasIndex(new[] { "IdMasterGroups" }, "UsersGroups_IdMasterGroups_FK_idx");
                        j.IndexerProperty<int>("IdMasterUsers").HasColumnType("int(11)");
                        j.IndexerProperty<int>("IdMasterGroups").HasColumnType("int(11)");
                    });
        });

        modelBuilder.Entity<Mastervendingmachine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mastervendingmachines");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Brand).HasMaxLength(45);
            entity.Property(e => e.Capacity).HasColumnType("int(11)");
            entity.Property(e => e.MachineName).HasMaxLength(45);
            entity.Property(e => e.Model).HasMaxLength(45);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("purchases");

            entity.HasIndex(e => e.IdMasterProvider, "Purchases_IdMasterProviders_FK_idx");

            entity.HasIndex(e => e.IdMasterProducts, "Purchases_IdProducts_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterProducts).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterProvider).HasColumnType("int(11)");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterProductsNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.IdMasterProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Purchases_IdMasterProducts_FK");

            entity.HasOne(d => d.IdMasterProviderNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.IdMasterProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Purchases_IdMasterProviders_FK");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.IdMasterProducts, "Requests_IdMasterProducts_FK_idx");

            entity.HasIndex(e => e.IdMasterUser, "Requests_IdMasterUser_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterProducts).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterUser).HasColumnType("int(11)");
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.SugarQuantity).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterProductsNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdMasterProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Requests_IdMasterProducts_FK");

            entity.HasOne(d => d.IdMasterUserNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdMasterUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Requests_IdMasterUser_FK");
        });

        modelBuilder.Entity<Usergrouppayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usergrouppayments");

            entity.HasIndex(e => e.IdMasterGroups, "UserGroupPayments_IdMasterGroups_FK_idx");

            entity.HasIndex(e => e.IdMasterUsers, "UserGroupPayments_IdMasterUsers_FK_idx");

            entity.HasIndex(e => e.IdVendingMachinesBranches, "UserGroupPayments_IdVendingMachinesBranches_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterGroups).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterUsers).HasColumnType("int(11)");
            entity.Property(e => e.IdVendingMachinesBranches).HasColumnType("int(11)");
            entity.Property(e => e.NumberProducts).HasColumnType("int(11)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdMasterGroupsNavigation).WithMany(p => p.Usergrouppayments)
                .HasForeignKey(d => d.IdMasterGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupPayments_IdMasterGroups_FK");

            entity.HasOne(d => d.IdMasterUsersNavigation).WithMany(p => p.Usergrouppayments)
                .HasForeignKey(d => d.IdMasterUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupPayments_IdMasterUsers_FK");

            entity.HasOne(d => d.IdVendingMachinesBranchesNavigation).WithMany(p => p.Usergrouppayments)
                .HasForeignKey(d => d.IdVendingMachinesBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupPayments_IdVendingMachinesBranches_FK");
        });

        modelBuilder.Entity<Usergrouppaymentproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usergrouppaymentproducts");

            entity.HasIndex(e => e.IdUserGroupPayments, "USerGroupPaymentProducts_IdUserGroupPayments_FK_idx");

            entity.HasIndex(e => e.IdMasterProducts, "UserGroupPaymentProducts_IdMasterProducts_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.IdMasterProducts).HasColumnType("int(11)");
            entity.Property(e => e.IdUserGroupPayments).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterProductsNavigation).WithMany(p => p.Usergrouppaymentproducts)
                .HasForeignKey(d => d.IdMasterProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupPaymentProducts_IdMasterProducts_FK");

            entity.HasOne(d => d.IdUserGroupPaymentsNavigation).WithMany(p => p.Usergrouppaymentproducts)
                .HasForeignKey(d => d.IdUserGroupPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupPaymentProducts_IdUserGroupPayments_FK");
        });

        modelBuilder.Entity<Usergroupsmachinesreservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usergroupsmachinesreservations");

            entity.HasIndex(e => e.IdMasterGroup, "UserGroupsMachinesReservations_IdMasterGroups_FK_idx");

            entity.HasIndex(e => e.IdVendingMachinesBranches, "UserGroupsMachinesReservations_IdVendingMachinesBranches_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterGroup).HasColumnType("int(11)");
            entity.Property(e => e.IdVendingMachinesBranches).HasColumnType("int(11)");
            entity.Property(e => e.Minutes).HasColumnType("int(11)");
            entity.Property(e => e.TimeReserve).HasColumnType("datetime");

            entity.HasOne(d => d.IdMasterGroupNavigation).WithMany(p => p.Usergroupsmachinesreservations)
                .HasForeignKey(d => d.IdMasterGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupsMachinesReservations_IdMasterGroups_FK");

            entity.HasOne(d => d.IdVendingMachinesBranchesNavigation).WithMany(p => p.Usergroupsmachinesreservations)
                .HasForeignKey(d => d.IdVendingMachinesBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserGroupsMachinesReservations_IdVendingMachinesBranches_FK");
        });

        modelBuilder.Entity<Vendingmachinesbranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vendingmachinesbranches");

            entity.HasIndex(e => e.IdMasterBranches, "VendingMachinesBranches_IdMasterBranches_idx");

            entity.HasIndex(e => e.IdMasterVendingMachines, "VendingMachinesBranches_IdMasterVendingMachines_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BuildingName).HasMaxLength(45);
            entity.Property(e => e.Floor).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterBranches).HasColumnType("int(11)");
            entity.Property(e => e.IdMasterVendingMachines).HasColumnType("int(11)");
            entity.Property(e => e.Notes).HasMaxLength(100);

            entity.HasOne(d => d.IdMasterBranchesNavigation).WithMany(p => p.Vendingmachinesbranches)
                .HasForeignKey(d => d.IdMasterBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingMachinesBranches_IdMasterBranches");

            entity.HasOne(d => d.IdMasterVendingMachinesNavigation).WithMany(p => p.Vendingmachinesbranches)
                .HasForeignKey(d => d.IdMasterVendingMachines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingMachinesBranches_IdMasterVendingMachines_FK");
        });

        modelBuilder.Entity<Vendingmachinesbranchesproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vendingmachinesbranchesproducts");

            entity.HasIndex(e => e.IdMasterProduct, "VendingMachinesBranchesProducts_IdMasterProduct_FK_idx");

            entity.HasIndex(e => e.IdVendingMachinesBranches, "VendingMachinesBranches_IdVendingMachinesBranches_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AsociatedNumber).HasColumnType("int(11)");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.IdMasterProduct).HasColumnType("int(11)");
            entity.Property(e => e.IdVendingMachinesBranches).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMasterProductNavigation).WithMany(p => p.Vendingmachinesbranchesproducts)
                .HasForeignKey(d => d.IdMasterProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingMachinesBranchesProducts_IdMasterProduct_FK");

            entity.HasOne(d => d.IdVendingMachinesBranchesNavigation).WithMany(p => p.Vendingmachinesbranchesproducts)
                .HasForeignKey(d => d.IdVendingMachinesBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingMachinesBranchesProducts_IdVendingMachinesBranches_FK");
        });

        modelBuilder.Entity<Vendingrefill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vendingrefills");

            entity.HasIndex(e => e.IdProduct, "IdProduct_FK_idx");

            entity.HasIndex(e => e.IdVendingMachinesBranches, "IdVendingMachinesBranches_FK_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodeNumberMachine).HasColumnType("int(11)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdEmployee).HasColumnType("int(11)");
            entity.Property(e => e.IdProduct).HasColumnType("int(11)");
            entity.Property(e => e.IdVendingMachinesBranches).HasColumnType("int(11)");
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("int(11)");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Vendingrefills)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingRefills_IdProduct_FK");

            entity.HasOne(d => d.IdVendingMachinesBranchesNavigation).WithMany(p => p.Vendingrefills)
                .HasForeignKey(d => d.IdVendingMachinesBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingRefills_IdVendingMachinesBranches_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
