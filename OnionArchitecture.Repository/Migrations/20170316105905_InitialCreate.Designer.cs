using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OnionArchitecture.Repository;

namespace OnionArchitecture.Repository.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170316105905_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnionArchitecture.Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsHero");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
        }
    }
}
