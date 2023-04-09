﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eCommerce.Console.Models;

namespace eCommerce.Console.Database
{
    public partial class eCommerceContext : DbContext
    {
        public eCommerceContext()
        {
        }

        public eCommerceContext(DbContextOptions<eCommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contato> Contatos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<EnderecosEntrega> EnderecosEntregas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=eCommerce;User ID=sa;Password=1q2w3e4r@#$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_Contatos_UsuarioId")
                    .IsUnique();

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Contato)
                    .HasForeignKey<Contato>(d => d.UsuarioId);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasMany(d => d.Usuarios)
                    .WithMany(p => p.Departamentos)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartamentoUsuario",
                        l => l.HasOne<Usuario>().WithMany().HasForeignKey("UsuariosId"),
                        r => r.HasOne<Departamento>().WithMany().HasForeignKey("DepartamentosId"),
                        j =>
                        {
                            j.HasKey("DepartamentosId", "UsuariosId");

                            j.ToTable("DepartamentoUsuario");

                            j.HasIndex(new[] { "UsuariosId" }, "IX_DepartamentoUsuario_UsuariosId");
                        });
            });

            modelBuilder.Entity<EnderecosEntrega>(entity =>
            {
                entity.ToTable("EnderecosEntrega");

                entity.HasIndex(e => e.UsuarioId, "IX_EnderecosEntrega_UsuarioId");

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.EnderecosEntregas)
                    .HasForeignKey(d => d.UsuarioId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
