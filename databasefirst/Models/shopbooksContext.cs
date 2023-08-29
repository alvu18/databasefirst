using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace databasefirst.Models
{
    public partial class shopbooksContext : DbContext
    {
        public shopbooksContext()
        {
        }

        public shopbooksContext(DbContextOptions<shopbooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookShop> BookShops { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<EditorialOffice> EditorialOffices { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Ordelist> Ordelists { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;
        public virtual DbSet<ViewBasket> ViewBaskets { get; set; } = null!;
        public virtual DbSet<ViewBookinBasket> ViewBookinBaskets { get; set; } = null!;
        public virtual DbSet<ViewChart1> ViewChart1s { get; set; } = null!;
        public virtual DbSet<ViewChart2> ViewChart2s { get; set; } = null!;
        public virtual DbSet<ViewHistoryChart> ViewHistoryCharts { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8PNGDDU;Database=shopbooks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PK_Author_IdAuthor");

                entity.ToTable("Author");

                entity.HasIndex(e => e.NameAuthor, "IDX_Author_NameAuthor");

                entity.Property(e => e.FathernameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook)
                    .HasName("PK_Book_IdBook");

                entity.ToTable("Book");

                entity.HasIndex(e => e.NameBook, "IDX_Book_NameBook");

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_IdAuthor");

                entity.HasOne(d => d.IdEditorialOfficeNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdEditorialOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_IdEditorialOffice");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_IdGenre");
            });

            modelBuilder.Entity<BookShop>(entity =>
            {
                entity.HasKey(e => e.IdBookShop)
                    .HasName("PK_Book_Shop_id");

                entity.ToTable("Book_Shop");

                entity.Property(e => e.IdBookShop).HasColumnName("idBook_Shop");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookShops)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Shop_IdBook");

                entity.HasOne(d => d.IdShopNavigation)
                    .WithMany(p => p.BookShops)
                    .HasForeignKey(d => d.IdShop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Shop_IdShop");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK_Clients_IdClient");

                entity.ToTable("Client");

                entity.HasIndex(e => e.SurnameClient, "IDX_Client_SurnameClient");

                entity.Property(e => e.AdressClient)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EmailClient)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FathernameClient)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameClient)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberClient)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameClient)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EditorialOffice>(entity =>
            {
                entity.HasKey(e => e.IdEditorialOffice)
                    .HasName("PK_EditorialOffice_IdEditorialOffice");

                entity.ToTable("EditorialOffice");

                entity.HasIndex(e => e.NameEditorialOffice, "IDX_EditorialOffice_NameEditorialOffice");

                entity.Property(e => e.NameEditorialOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK_Genre_IdGenre");

                entity.ToTable("Genre");

                entity.HasIndex(e => e.NameGenre, "IDX_Genre_NameGenre");

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ordelist>(entity =>
            {
                entity.HasKey(e => e.IdOrderList)
                    .HasName("PK_Ordelist_IdOrderList");

                entity.ToTable("Ordelist");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Ordelists)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordelist_IdBook");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Ordelists)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordelist_IdOrder");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Order_IdOrder");

                entity.ToTable("Order");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Order_IdClient");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_IdWorker");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.IdShop)
                    .HasName("PK_Shop_IdShop");

                entity.ToTable("Shop");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.IdSupply)
                    .HasConstraintName("FK_Shop_IdSupply");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("PK_Supplier_IdSupplier");

                entity.ToTable("Supplier");

                entity.Property(e => e.AdressSupplier)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NameSupplier)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneSupplier)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.HasKey(e => e.IdSupply)
                    .HasName("PK_Supply_IdSupply");

                entity.ToTable("Supply");

                entity.Property(e => e.DateSupply).HasColumnType("datetime");

                entity.HasOne(d => d.IdSupplerNavigation)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.IdSuppler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supply_IdSuppler");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_Users_idUser");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdWorker).HasColumnName("idWorker");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("FK_Users_idWorker");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view1");

                entity.Property(e => e.FathernameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewBasket>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBasket");

                entity.Property(e => e.FullAuthorName)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewBookinBasket>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewBookinBasket ");

                entity.Property(e => e.FullNameAuthor)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewChart1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewChart1");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewChart2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewChart2");

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewHistoryChart>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewHistoryChart");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.Property(e => e.EmailClient)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NameBook)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEditorialOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkerFullName)
                    .HasMaxLength(101)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.IdWorker)
                    .HasName("PK_Worker_IdWorker");

                entity.ToTable("Worker");

                entity.Property(e => e.AdressWorker)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FathernameWorker)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameWorker)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberWorker)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameWorker)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
