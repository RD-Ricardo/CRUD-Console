using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Crud_console.db
{
    public partial class db_crudContext : DbContext
    {
        public db_crudContext()
        {
        }

        public db_crudContext(DbContextOptions<db_crudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPessoa> TbPessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;User=root;Password=root;Database=db_crud;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbPessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.Property(e => e.NmCidadePessoa)
                    .HasColumnName("nm_cidade_pessoa")
                    .HasMaxLength(45);

                entity.Property(e => e.NmPessoa)
                    .HasColumnName("nm_pessoa")
                    .HasMaxLength(45);

                entity.Property(e => e.NrTelefonePessoa)
                    .HasColumnName("nr_telefone_pessoa")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
