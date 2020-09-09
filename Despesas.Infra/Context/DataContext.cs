using Despesas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Despesas.Infra.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Despesa> Despesas { get; set;}
        public DbSet<MembroFamiliar> MembroFamiliars { get; set;}
        public DbSet<Pagamento> Pagamentos{ get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesa>().ToTable("Despesa");

            modelBuilder.Entity<Despesa>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Despesa>()
                        .Property(x => x.Nome)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();
            
            modelBuilder.Entity<Despesa>()
                        .Property(x => x.Descricao)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

            modelBuilder.Entity<Despesa>()
                        .Property(x => x.Valor)
                        .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Despesa>()
                        .Property(x => x.DataCriacao)
                        .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Despesa>()
                        .Property(x => x.TipoDepesa)
                        .HasConversion<int>();

            modelBuilder.Entity<Despesa>()
                        .HasOne<Pagamento>(x => x.Pagamento);

            modelBuilder.Entity<Despesa>()
                        .HasOne<MembroFamiliar>(x => x.MembroFamiliar);

            //Membro Familiar

            modelBuilder.Entity<MembroFamiliar>().ToTable("MembroFamiliar");

            modelBuilder.Entity<MembroFamiliar>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MembroFamiliar>()
                        .OwnsOne(x => x.Nome)
                        .Property(x => x.NomeSocial)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();
            
            modelBuilder.Entity<MembroFamiliar>()
                        .OwnsOne(x => x.Nome)
                        .Property(x => x.Sobrenome)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();

            modelBuilder.Entity<MembroFamiliar>()
                        .OwnsOne(x => x.Email)
                        .Property(x => x.Address)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();

            modelBuilder.Entity<MembroFamiliar>()
                        .Property(x => x.DataNascimento);

            modelBuilder.Entity<MembroFamiliar>()
                        .HasIndex(x => x.ChaveDeAcesso);
            
            //Pagamento

            modelBuilder.Entity<Pagamento>().ToTable("Pagamento");

            modelBuilder.Entity<Pagamento>()
                        .HasIndex(x => x.Id);

            modelBuilder.Entity<Pagamento>()
                        .Property(x => x.Valor)
                        .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Pagamento>()
                        .Property(x => x.DataPagamento);
            
            modelBuilder.Entity<Pagamento>()
                        .Property(x => x.Pago)
                        .HasColumnType("bit");

            modelBuilder.Entity<Pagamento>()
                        .Property(x => x.FormaPagamento)
                        .HasConversion<int>(); 
        }
    }
}