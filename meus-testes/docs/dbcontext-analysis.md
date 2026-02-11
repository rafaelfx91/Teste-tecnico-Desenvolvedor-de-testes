# CONFIGURAÄ«O DO DBCONTEXT 
 
```csharp 
Ôªøusing Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Infrastructure.Data;

/// <summary>
/// Contexto de banco de dados para o sistema Minhas Finan√ßas.
/// </summary>
public class MinhasFinancasDbContext : DbContext
{
    /// <summary>
    /// Construtor do contexto.
    /// </summary>
    public MinhasFinancasDbContext(DbContextOptions<MinhasFinancasDbContext> options) : base(options) { }

    /// <summary>
    /// DbSet para Pessoas.
    /// </summary>
    public DbSet<Pessoa> Pessoas { get; set; } = null!;

    /// <summary>
    /// DbSet para Categorias.
    /// </summary>
    public DbSet<Categoria> Categorias { get; set; } = null!;

    /// <summary>
    /// DbSet para Transa√ß√µes.
    /// </summary>
    public DbSet<Transacao> Transacoes { get; set; } = null!;

    /// <summary>
    /// Configura√ß√µes do modelo.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura√ß√µes das entidades
        modelBuilder.Entity<Pessoa>().HasKey(p => p.Id);
        modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
        modelBuilder.Entity<Transacao>().HasKey(t => t.Id);

        // Indexes to improve query performance and avoid expensive scans
        modelBuilder.Entity<Transacao>().HasIndex(t => t.PessoaId);
        modelBuilder.Entity<Transacao>().HasIndex(t => t.CategoriaId);
        modelBuilder.Entity<Transacao>().HasIndex(t => t.Data);
        modelBuilder.Entity<Pessoa>().HasIndex(p => p.Nome);
        modelBuilder.Entity<Categoria>().HasIndex(c => c.Descricao);

        // Relacionamentos
        modelBuilder.Entity<Transacao>()
            .HasOne(t => t.Categoria)
            .WithMany()
            .HasForeignKey(t => t.CategoriaId);

        modelBuilder.Entity<Transacao>()
            .HasOne(t => t.Pessoa)
            .WithMany()
            .HasForeignKey(t => t.PessoaId);

        // Configurar propriedade Data da transa√ß√£o
        modelBuilder.Entity<Transacao>()
            .Property(t => t.Data)
            .IsRequired()
            .HasColumnType("date");
    }
}
``` 
 
## CONFIGURAÄÂES DE RELACIONAMENTO ENCONTRADAS 
 
 
## BUSCA EM TODA A INFRAESTRUTURA 
"Nenhuma configuraá∆o encontrada" 
