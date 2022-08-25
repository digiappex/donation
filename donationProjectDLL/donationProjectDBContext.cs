using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using donationProjectDLL.Domains;
using donationProjectDLL.commonVariables;
using Pomelo.EntityFrameworkCore;

namespace donationProjectDLL.DomainContext{
    public class donationProjectDBContext:DbContext{
        //public donationProjectDBContext(){}
        public donationProjectDBContext(DbContextOptions options)
         :base(options)
        {
        }
            public DbSet<userType> userType{get;set;}
            public DbSet<userRecord> userRecord{get;set;}
            public DbSet<city> city{get;set;}
            public DbSet<cityArea> cityArea{get;set;}
            public DbSet<screenNameRecord> screenNameRecord {get;set;}
            public DbSet<organizationData> organizationData{get;set;}
            public DbSet<itemCategory> itemCategory{get;set;}
            public DbSet<itemDetails> itemDetails{get;set;}
            public DbSet<moneyDonation> moneyDonation{get;set;}
            public DbSet<itemDonation> itemDonation{get;set;}
           public DbSet<cnicPicRecord> cnicPicRecord{get;set;}
           public DbSet<familyMembersRecord> familyMembersRecords{get;set;}
        
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cnicPicRecord>()
                .HasOne(b => b.UserRecord)
                .WithOne(i => i.CnicPicRecord)
                .HasForeignKey<cnicPicRecord>(b =>b.userRecordId);
            
            modelBuilder.Entity<screenNameRecord>()
                .HasOne(b=>b.UserRecord)
                .WithOne(m=>m.ScreenNameRecord)
                .HasForeignKey<screenNameRecord>(b=>b.userRecordId);
            
            modelBuilder.Entity<familyMembersRecord>()
                .HasOne(b=>b.UserRecord)
                .WithOne(m=>m.FamilyMembersRecord)
                .HasForeignKey<familyMembersRecord>(b=>b.userRecordId);
            
            
        }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(commonVars.connectionString);
        }*/

    }
}
