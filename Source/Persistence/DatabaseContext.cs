using Microsoft.EntityFrameworkCore;
using Source.Models;

namespace Source.Persistence;

public class DatabaseContext : DbContext
{
     public DbSet<Pessoa> Pessoas { get; set; }
     public DbSet<Contrato> Contratos { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pessoa>(tabela =>{
            tabela.HasKey(e => e.Id);
            tabela
            .HasMany(e => e.Contratos)
            .WithOne()
            .HasForeignKey(c => c.PessoaId);
        });

        builder.Entity<Contrato>(tabela =>{
            tabela.HasKey(e => e.Id);
        });
    }
}
