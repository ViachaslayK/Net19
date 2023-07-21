﻿// <auto-generated />
using System;
using Data.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Sql.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20230720160436_addTrueOrFalseAnswer")]
    partial class addTrueOrFalseAnswer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Interface.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Data.Interface.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreaterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreaterId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Data.Interface.Models.GameCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameCategories");
                });

            modelBuilder.Entity("Data.Interface.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsItTrueAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("NumberAnswer")
                        .HasColumnType("int");

                    b.Property<string>("OneAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.GamesQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameQuiz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GamesQuiz");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NubmerOfQuestion")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Data.Interface.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextReview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Data.Interface.Models.SimilarGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LinkForPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SimilarGames");
                });

            modelBuilder.Entity("Data.Interface.Models.StoreItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("Data.Interface.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiBlockComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BlockId");

                    b.ToTable("WikiBlockComments");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiBlockImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WikiBlockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WikiBlockId");

                    b.ToTable("WikiBlockImg");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiMc.WikiMcImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageUploaderId")
                        .HasColumnType("int");

                    b.Property<int>("ImgType")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageUploaderId");

                    b.ToTable("WikiMcImages");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiMc.WikiTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WikiTags");
                });

            modelBuilder.Entity("Data.Sql.Models.PageWikiBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("PageWikiBlocks");
                });

            modelBuilder.Entity("GameGameCategory", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("GameGameCategory");
                });

            modelBuilder.Entity("GameGameCategory1", b =>
                {
                    b.Property<int>("SecondaryGamesId")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryGenresId")
                        .HasColumnType("int");

                    b.HasKey("SecondaryGamesId", "SecondaryGenresId");

                    b.HasIndex("SecondaryGenresId");

                    b.ToTable("GameGameCategory1");
                });

            modelBuilder.Entity("StoreItemUser", b =>
                {
                    b.Property<int>("StoreItemsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("StoreItemsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("StoreItemUser");
                });

            modelBuilder.Entity("WikiMcImageWikiTags", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("ImagesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("WikiMcImageWikiTags");
                });

            modelBuilder.Entity("Data.Interface.Models.Cart", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "Customer")
                        .WithMany("Products")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Data.Interface.Models.Game", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "Creater")
                        .WithMany("CreatedGames")
                        .HasForeignKey("CreaterId");

                    b.Navigation("Creater");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.Answer", b =>
                {
                    b.HasOne("Data.Interface.Models.Quizes.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.Question", b =>
                {
                    b.HasOne("Data.Interface.Models.Quizes.GamesQuiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Data.Interface.Models.Review", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Interface.Models.StoreItem", b =>
                {
                    b.HasOne("Data.Interface.Models.Manufacturer", "Manufacturer")
                        .WithMany("StoreItems")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiBlockComment", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Sql.Models.PageWikiBlock", "Block")
                        .WithMany("Comment")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Block");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiBlockImg", b =>
                {
                    b.HasOne("Data.Sql.Models.PageWikiBlock", "WikiBlock")
                        .WithMany("UrlImg")
                        .HasForeignKey("WikiBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WikiBlock");
                });

            modelBuilder.Entity("Data.Interface.Models.WikiMc.WikiMcImage", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "ImageUploader")
                        .WithMany("UploadedImages")
                        .HasForeignKey("ImageUploaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ImageUploader");
                });

            modelBuilder.Entity("Data.Sql.Models.PageWikiBlock", b =>
                {
                    b.HasOne("Data.Interface.Models.User", "Author")
                        .WithMany("Blocks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("GameGameCategory", b =>
                {
                    b.HasOne("Data.Interface.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Interface.Models.GameCategory", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameGameCategory1", b =>
                {
                    b.HasOne("Data.Interface.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("SecondaryGamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Interface.Models.GameCategory", null)
                        .WithMany()
                        .HasForeignKey("SecondaryGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreItemUser", b =>
                {
                    b.HasOne("Data.Interface.Models.StoreItem", null)
                        .WithMany()
                        .HasForeignKey("StoreItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Interface.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiMcImageWikiTags", b =>
                {
                    b.HasOne("Data.Interface.Models.WikiMc.WikiMcImage", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Interface.Models.WikiMc.WikiTags", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Interface.Models.Manufacturer", b =>
                {
                    b.Navigation("StoreItems");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.GamesQuiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Data.Interface.Models.Quizes.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Data.Interface.Models.User", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Comments");

                    b.Navigation("CreatedGames");

                    b.Navigation("Products");

                    b.Navigation("Reviews");

                    b.Navigation("UploadedImages");
                });

            modelBuilder.Entity("Data.Sql.Models.PageWikiBlock", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("UrlImg");
                });
#pragma warning restore 612, 618
        }
    }
}
