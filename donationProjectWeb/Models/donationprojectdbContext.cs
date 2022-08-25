using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace donationProjectWeb.Models
{
    public partial class donationprojectdbContext : DbContext
    {
        public donationprojectdbContext()
        {
        }

        public donationprojectdbContext(DbContextOptions<donationprojectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Cityarea> Cityarea { get; set; }
        public virtual DbSet<Cnicpicrecord> Cnicpicrecord { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Familymembersrecords> Familymembersrecords { get; set; }
        public virtual DbSet<Itemcategory> Itemcategory { get; set; }
        public virtual DbSet<Itemdetails> Itemdetails { get; set; }
        public virtual DbSet<Itemdonation> Itemdonation { get; set; }
        public virtual DbSet<Moneydonation> Moneydonation { get; set; }
        public virtual DbSet<Organizationdata> Organizationdata { get; set; }
        public virtual DbSet<Screennamerecord> Screennamerecord { get; set; }
        public virtual DbSet<Userrecord> Userrecord { get; set; }
        public virtual DbSet<Usertype> Usertype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=p@k1staN1947.com;database=donationprojectdb", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cityarea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PRIMARY");

                entity.ToTable("cityarea");

                entity.HasIndex(e => e.CityId)
                    .HasName("IX_cityArea_cityId");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.AreaName)
                    .HasColumnName("areaName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Cityarea)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_cityArea_city_cityId");
            });

            modelBuilder.Entity<Cnicpicrecord>(entity =>
            {
                entity.ToTable("cnicpicrecord");

                entity.HasIndex(e => e.UserRecordId)
                    .HasName("IX_cnicPicRecord_userRecordId")
                    .IsUnique();

                entity.Property(e => e.CnicPicRecordId).HasColumnName("cnicPicRecordId");

                entity.Property(e => e.CnicBackPicPath)
                    .HasColumnName("cnicBackPicPath")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CnicFrontPicPath)
                    .HasColumnName("cnicFrontPicPath")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserGuid)
                    .HasColumnName("userGuid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserRecordId).HasColumnName("userRecordId");

                entity.HasOne(d => d.UserRecord)
                    .WithOne(p => p.Cnicpicrecord)
                    .HasForeignKey<Cnicpicrecord>(d => d.UserRecordId)
                    .HasConstraintName("FK_cnicPicRecord_userRecord_userRecordId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Familymembersrecords>(entity =>
            {
                entity.HasKey(e => e.FamilyMembersRecordId)
                    .HasName("PRIMARY");

                entity.ToTable("familymembersrecords");

                entity.HasIndex(e => e.UserRecordId)
                    .HasName("IX_familyMembersRecords_userRecordId")
                    .IsUnique();

                entity.Property(e => e.FamilyMembersRecordId).HasColumnName("familyMembersRecordId");

                entity.Property(e => e.NumberOfFamilyMembers)
                    .HasColumnName("numberOfFamilyMembers")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserRecordId).HasColumnName("userRecordId");

                entity.HasOne(d => d.UserRecord)
                    .WithOne(p => p.Familymembersrecords)
                    .HasForeignKey<Familymembersrecords>(d => d.UserRecordId)
                    .HasConstraintName("FK_familyMembersRecords_userRecord_userRecordId");
            });

            modelBuilder.Entity<Itemcategory>(entity =>
            {
                entity.ToTable("itemcategory");

                entity.Property(e => e.ItemCategoryId).HasColumnName("itemCategoryId");

                entity.Property(e => e.ItemCategoryName)
                    .HasColumnName("itemCategoryName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Itemdetails>(entity =>
            {
                entity.HasKey(e => e.ItemDetailId)
                    .HasName("PRIMARY");

                entity.ToTable("itemdetails");

                entity.HasIndex(e => e.ItemCategoryId)
                    .HasName("IX_itemDetails_itemCategoryId");

                entity.Property(e => e.ItemDetailId).HasColumnName("itemDetailId");

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ItemCategoryId).HasColumnName("itemCategoryId");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("itemDescription")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ItemName)
                    .HasColumnName("itemName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OwnerId).HasColumnName("ownerId");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Itemdetails)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_itemDetails_itemCategory_itemCategoryId");
            });

            modelBuilder.Entity<Itemdonation>(entity =>
            {
                entity.ToTable("itemdonation");

                entity.Property(e => e.ItemDonationId).HasColumnName("itemDonationId");

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DonationDate).HasColumnName("donationDate");

                entity.Property(e => e.DonationId).HasColumnName("donationId");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.ReceiverId).HasColumnName("receiverId");
            });

            modelBuilder.Entity<Moneydonation>(entity =>
            {
                entity.ToTable("moneydonation");

                entity.Property(e => e.MoneyDonationId).HasColumnName("moneyDonationId");

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DonationDate).HasColumnName("donationDate");

                entity.Property(e => e.DonationId).HasColumnName("donationId");

                entity.Property(e => e.ReceiverId).HasColumnName("receiverId");
            });

            modelBuilder.Entity<Organizationdata>(entity =>
            {
                entity.HasKey(e => e.OrganizationId)
                    .HasName("PRIMARY");

                entity.ToTable("organizationdata");

                entity.HasIndex(e => e.AreaId1)
                    .HasName("IX_organizationData_areaId1");

                entity.Property(e => e.OrganizationId).HasColumnName("organizationId");

                entity.Property(e => e.AboutOrganization)
                    .HasColumnName("aboutOrganization")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AreaId1).HasColumnName("areaId1");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LicenseNumber)
                    .HasColumnName("licenseNumber")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrganizationAddress)
                    .HasColumnName("organizationAddress")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrganizationName)
                    .HasColumnName("organizationName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserGuid)
                    .HasColumnName("userGuid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AreaId1Navigation)
                    .WithMany(p => p.Organizationdata)
                    .HasForeignKey(d => d.AreaId1)
                    .HasConstraintName("FK_organizationData_cityArea_areaId1");
            });

            modelBuilder.Entity<Screennamerecord>(entity =>
            {
                entity.ToTable("screennamerecord");

                entity.HasIndex(e => e.UserRecordId)
                    .HasName("IX_screenNameRecord_userRecordId")
                    .IsUnique();

                entity.Property(e => e.ScreenNameRecordId).HasColumnName("screenNameRecordId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UserGuid)
                    .HasColumnName("userGuid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserRecordId).HasColumnName("userRecordId");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.UserRecord)
                    .WithOne(p => p.Screennamerecord)
                    .HasForeignKey<Screennamerecord>(d => d.UserRecordId)
                    .HasConstraintName("FK_screenNameRecord_userRecord_userRecordId");
            });

            modelBuilder.Entity<Userrecord>(entity =>
            {
                entity.ToTable("userrecord");

                entity.HasIndex(e => e.AreaId1)
                    .HasName("IX_userRecord_areaId1");

                entity.HasIndex(e => e.UserTypeid)
                    .HasName("IX_userRecord_UserTypeid");

                entity.Property(e => e.UserRecordId).HasColumnName("userRecordId");

                entity.Property(e => e.AreaId1).HasColumnName("areaId1");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("emailAddress")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FamilyNumber)
                    .HasColumnName("familyNumber")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UserAddress)
                    .HasColumnName("userAddress")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserAddressPerCnic)
                    .HasColumnName("userAddressPerCNIC")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserCnic)
                    .HasColumnName("userCNIC")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserFirstName)
                    .HasColumnName("userFirstName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserGuid)
                    .HasColumnName("userGuid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserLastName)
                    .HasColumnName("userLastName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AreaId1Navigation)
                    .WithMany(p => p.Userrecord)
                    .HasForeignKey(d => d.AreaId1)
                    .HasConstraintName("FK_userRecord_cityArea_areaId1");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Userrecord)
                    .HasForeignKey(d => d.UserTypeid)
                    .HasConstraintName("FK_userRecord_userType_UserTypeid");
            });

            modelBuilder.Entity<Usertype>(entity =>
            {
                entity.ToTable("usertype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
