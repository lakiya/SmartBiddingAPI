﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartBiddingDLL.Data;

#nullable disable

namespace SmartBiddingDLL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230415055953_1.0.0.0")]
    partial class _1000
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.BidOrder", b =>
                {
                    b.Property<Guid>("BidOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BidOrderId")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("BasePrice")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BidChairsAllowed")
                        .HasColumnType("int");

                    b.Property<DateTime>("BidEndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("BidStartTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("IncrimentPricePerBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BidOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("BidsOrder");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.BidderBidRegistration", b =>
                {
                    b.Property<Guid>("BidderRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BidderRegistrationId")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("BidOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("SystemUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemUserUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BidderRegistrationId");

                    b.HasIndex("BidOrderId");

                    b.HasIndex("SystemUserUserId");

                    b.ToTable("BidderBidRegistrations");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.ProductCategory", b =>
                {
                    b.Property<Guid>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductCategoryId")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.SystemUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("JoinDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("CK_SystemUser_EmailAddress");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.BidOrder", b =>
                {
                    b.HasOne("SmartBiddingCommon.SqlDbModel.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.BidderBidRegistration", b =>
                {
                    b.HasOne("SmartBiddingCommon.SqlDbModel.BidOrder", "BidOrder")
                        .WithMany()
                        .HasForeignKey("BidOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartBiddingCommon.SqlDbModel.SystemUser", "SystemUser")
                        .WithMany()
                        .HasForeignKey("SystemUserUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BidOrder");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.Product", b =>
                {
                    b.HasOne("SmartBiddingCommon.SqlDbModel.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SmartBiddingCommon.SqlDbModel.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
