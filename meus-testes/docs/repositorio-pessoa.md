# REPOSIT�RIO PESSOA 
 
```csharp 
using System.Threading.Tasks;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces;
using MinhasFinancas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Infrastructure.Extensions;

namespace MinhasFinancas.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório de Pessoas.
/// </summary>
public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
{
    /// <summary>
    /// Construtor.
    /// </summary>
    public PessoaRepository(MinhasFinancasDbContext context) : base(context) { }
}``` 
