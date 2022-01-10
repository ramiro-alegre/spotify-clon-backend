﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spotify_clone_backend.Models;

namespace spotify_clone_backend.Migrations
{
    [DbContext(typeof(SpotifyContext))]
    [Migration("20220110175933_DbInitializer")]
    partial class DbInitializer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("spotify_clone_backend.Models.Artist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("spotify_clone_backend.Models.Duration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Durations");
                });

            modelBuilder.Entity("spotify_clone_backend.Models.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Album")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DurationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("DurationId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("spotify_clone_backend.Models.Track", b =>
                {
                    b.HasOne("spotify_clone_backend.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("spotify_clone_backend.Models.Duration", "Duration")
                        .WithMany()
                        .HasForeignKey("DurationId");

                    b.Navigation("Artist");

                    b.Navigation("Duration");
                });
#pragma warning restore 612, 618
        }
    }
}
