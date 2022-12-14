// <auto-generated />
using System;
using AspApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221123164706_changedPrimaryKey")]
    partial class changedPrimaryKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspApp.Models.Client", b =>
                {
                    b.Property<string>("key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LinkedContacts")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("key");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AspApp.Models.Contact", b =>
                {
                    b.Property<string>("key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LinkedClients")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("key");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AspApp.Models.LinkdContacts", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClientId", "ContactId");

                    b.ToTable("LinkdContacts");
                });

            modelBuilder.Entity("AspApp.Models.LinkedClients", b =>
                {
                    b.Property<string>("ContactId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactId", "ClientId");

                    b.ToTable("LinkedClients");
                });
#pragma warning restore 612, 618
        }
    }
}
