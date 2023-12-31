﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _01_Intro_to_ef;

#nullable disable

namespace _01_Intro_to_ef.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230818135632_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("TracksId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsId", "TracksId");

                    b.HasIndex("TracksId");

                    b.ToTable("PlaylistTrack");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            GenreId = 1,
                            Name = "Album 1",
                            Year = 1965
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 2,
                            GenreId = 2,
                            Name = "Album 2",
                            Year = 1985
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 3,
                            GenreId = 3,
                            Name = "Album 3",
                            Year = 1967
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 4,
                            GenreId = 4,
                            Name = "Album 4",
                            Year = 1992
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 5,
                            GenreId = 5,
                            Name = "Album 5",
                            Year = 1989
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 6,
                            GenreId = 3,
                            Name = "Album 6",
                            Year = 1983
                        });
                });

            modelBuilder.Entity("_01_Intro_to_ef.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountrieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountrieId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountrieId = 1,
                            Name = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            CountrieId = 2,
                            Name = "Liam",
                            Surname = "Brown"
                        },
                        new
                        {
                            Id = 3,
                            CountrieId = 3,
                            Name = "Bread",
                            Surname = "Black"
                        },
                        new
                        {
                            Id = 4,
                            CountrieId = 2,
                            Name = "Antua",
                            Surname = "White"
                        },
                        new
                        {
                            Id = 5,
                            CountrieId = 4,
                            Name = "Helga",
                            Surname = "Green"
                        },
                        new
                        {
                            Id = 6,
                            CountrieId = 4,
                            Name = "Riam",
                            Surname = "Yellow"
                        });
                });

            modelBuilder.Entity("_01_Intro_to_ef.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Great Britain"
                        },
                        new
                        {
                            Id = 4,
                            Name = "France"
                        });
                });

            modelBuilder.Entity("_01_Intro_to_ef.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Metal"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hip-Hop"
                        });
                });

            modelBuilder.Entity("_01_Intro_to_ef.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.HasOne("_01_Intro_to_ef.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_Intro_to_ef.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_01_Intro_to_ef.Album", b =>
                {
                    b.HasOne("_01_Intro_to_ef.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_Intro_to_ef.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Artist", b =>
                {
                    b.HasOne("_01_Intro_to_ef.Country", "Countrie")
                        .WithMany("Artists")
                        .HasForeignKey("CountrieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countrie");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Playlist", b =>
                {
                    b.HasOne("_01_Intro_to_ef.Category", "Category")
                        .WithMany("Playlists")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Track", b =>
                {
                    b.HasOne("_01_Intro_to_ef.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Category", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Country", b =>
                {
                    b.Navigation("Artists");
                });

            modelBuilder.Entity("_01_Intro_to_ef.Genre", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
