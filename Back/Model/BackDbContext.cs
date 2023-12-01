using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Model;

public partial class BackDbContext : DbContext
{
    public BackDbContext()
    {
    }

    public BackDbContext(DbContextOptions<BackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoProduto> PedidoProdutos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Promocao> Promocaos { get; set; }

    public virtual DbSet<PromocaoProduto> PromocaoProdutos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SJP-C-00003\\SQLEXPRESS;Initial Catalog=BackDB;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagem__3214EC2755ACB886");

            entity.ToTable("Imagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Foto).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC27DE40FE6E");

            entity.ToTable("Pedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataPedido).HasColumnType("date");
            entity.Property(e => e.Idpromocao).HasColumnName("IDPromocao");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdpromocaoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idpromocao)
                .HasConstraintName("FK__Pedido__IDPromoc__3F466844");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Pedido__IDUsuari__3E52440B");
        });

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoPr__3214EC27667BFFA5");

            entity.ToTable("PedidoProduto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.Idproduto).HasColumnName("IDProduto");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("FK__PedidoPro__IDPed__44FF419A");

            entity.HasOne(d => d.IdprodutoNavigation).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.Idproduto)
                .HasConstraintName("FK__PedidoPro__IDPro__45F365D3");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC27C824CBCC");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Idimagem).HasColumnName("IDImagem");
            entity.Property(e => e.Ingredientes)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdimagemNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.Idimagem)
                .HasConstraintName("FK__Produto__IDImage__4222D4EF");
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocao__3214EC2788CA6F2E");

            entity.ToTable("Promocao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Idimagem).HasColumnName("IDImagem");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdimagemNavigation).WithMany(p => p.Promocaos)
                .HasForeignKey(d => d.Idimagem)
                .HasConstraintName("FK__Promocao__IDImag__3B75D760");
        });

        modelBuilder.Entity<PromocaoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocao__3214EC27D546BC85");

            entity.ToTable("PromocaoProduto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.Idpromocao).HasColumnName("IDPromocao");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.PromocaoProdutos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("FK__PromocaoP__IDPed__48CFD27E");

            entity.HasOne(d => d.IdpromocaoNavigation).WithMany(p => p.PromocaoProdutos)
                .HasForeignKey(d => d.Idpromocao)
                .HasConstraintName("FK__PromocaoP__IDPro__49C3F6B7");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC27DC0B8AC3");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsRequired()
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
