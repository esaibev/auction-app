﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab2.Persistence;

#nullable disable

namespace lab2.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("lab2.Persistence.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Auctioneer")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int>("StartingPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AuctionDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Auctioneer = "Foo",
                            Description = "Test description",
                            EndDate = new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default title",
                            StartingPrice = 125
                        });
                });

            modelBuilder.Entity("lab2.Persistence.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuctionDbId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bidder")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuctionDbId");

                    b.ToTable("BidDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 150,
                            AuctionDbId = -1,
                            Bidder = "SampleBid1",
                            DateMade = new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -2,
                            Amount = 170,
                            AuctionDbId = -1,
                            Bidder = "SampleBid2",
                            DateMade = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("lab2.Persistence.BidDb", b =>
                {
                    b.HasOne("lab2.Persistence.AuctionDb", "AuctionDb")
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionDbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDb");
                });

            modelBuilder.Entity("lab2.Persistence.AuctionDb", b =>
                {
                    b.Navigation("BidDbs");
                });
#pragma warning restore 612, 618
        }
    }
}