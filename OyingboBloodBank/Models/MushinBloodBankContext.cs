using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OyingboBloodBank.Models
{
    public partial class MushinBloodBankContext : DbContext
    {
        public MushinBloodBankContext()
        {
        }

        public MushinBloodBankContext(DbContextOptions<MushinBloodBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodGroup> BloodGroups { get; set; } = null!;
        public virtual DbSet<Donor> Donors { get; set; } = null!;
        public virtual DbSet<Recipient> Recipients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MushinBloodBank;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.HasKey(e => e.BloodTypeId);

                entity.ToTable("Blood Group");

                entity.Property(e => e.BloodTypeId).HasColumnName("Blood Type Id");

                entity.Property(e => e.BloodType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Blood Type");

                entity.Property(e => e.CanGiveTo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Can Give To");

                entity.Property(e => e.CanRecieveFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Can Recieve From");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.ToTable("Donor");

                entity.Property(e => e.DonorId).HasColumnName("Donor Id");

                entity.Property(e => e.BloodTypeId).HasColumnName("Blood Type Id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonationDate)
                    .HasColumnType("date")
                    .HasColumnName("Donation Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone Number");

                entity.HasOne(d => d.BloodType)
                    .WithMany(p => p.Donors)
                    .HasForeignKey(d => d.BloodTypeId)
                    .HasConstraintName("FK_Donor_Blood Group");
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.ToTable("Recipient");

                entity.Property(e => e.RecipientId).HasColumnName("Recipient Id");

                entity.Property(e => e.BloodComponent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Blood Component");

                entity.Property(e => e.BloodTypeId).HasColumnName("Blood Type Id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone Number");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("Request Date");

                entity.HasOne(d => d.BloodType)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.BloodTypeId)
                    .HasConstraintName("FK_Recipient_Blood Group");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
