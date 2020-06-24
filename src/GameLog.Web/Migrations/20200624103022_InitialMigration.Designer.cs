﻿// <auto-generated />
using System;
using GameLog.Web.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameLog.Web.Migrations
{
    [DbContext(typeof(GameLogContext))]
    [Migration("20200624103022_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("GameLog.Web.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GameLog.Web.Models.PlayedGame", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Replayed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PlayedGame");
                });

            modelBuilder.Entity("GameLog.Web.Models.PlayedGame", b =>
                {
                    b.HasOne("GameLog.Web.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
