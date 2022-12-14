// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OyingboBloodBank.Models;

#nullable disable

namespace OyingboBloodBank.Migrations
{
    [DbContext(typeof(MushinBloodBankContext))]
    partial class MushinBloodBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OyingboBloodBank.Models.BloodGroup", b =>
                {
                    b.Property<int>("BloodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Blood Type Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BloodTypeId"), 1L, 1);

                    b.Property<string>("BloodType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Blood Type");

                    b.Property<string>("CanGiveTo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Can Give To");

                    b.Property<string>("CanRecieveFrom")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Can Recieve From");

                    b.HasKey("BloodTypeId");

                    b.ToTable("Blood Group", (string)null);
                });

            modelBuilder.Entity("OyingboBloodBank.Models.Donor", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Donor Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorId"), 1L, 1);

                    b.Property<int?>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Blood Type Id");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DonationDate")
                        .HasColumnType("date")
                        .HasColumnName("Donation Date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Phone Number");

                    b.HasKey("DonorId");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("Donor", (string)null);
                });

            modelBuilder.Entity("OyingboBloodBank.Models.Recipient", b =>
                {
                    b.Property<int>("RecipientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Recipient Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipientId"), 1L, 1);

                    b.Property<string>("BloodComponent")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Blood Component");

                    b.Property<int?>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Blood Type Id");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Phone Number");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("date")
                        .HasColumnName("Request Date");

                    b.HasKey("RecipientId");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("Recipient", (string)null);
                });

            modelBuilder.Entity("OyingboBloodBank.Models.Donor", b =>
                {
                    b.HasOne("OyingboBloodBank.Models.BloodGroup", "BloodType")
                        .WithMany("Donors")
                        .HasForeignKey("BloodTypeId")
                        .HasConstraintName("FK_Donor_Blood Group");

                    b.Navigation("BloodType");
                });

            modelBuilder.Entity("OyingboBloodBank.Models.Recipient", b =>
                {
                    b.HasOne("OyingboBloodBank.Models.BloodGroup", "BloodType")
                        .WithMany("Recipients")
                        .HasForeignKey("BloodTypeId")
                        .HasConstraintName("FK_Recipient_Blood Group");

                    b.Navigation("BloodType");
                });

            modelBuilder.Entity("OyingboBloodBank.Models.BloodGroup", b =>
                {
                    b.Navigation("Donors");

                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
