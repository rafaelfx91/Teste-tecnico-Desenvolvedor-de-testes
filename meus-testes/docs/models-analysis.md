# AN�LISE DOS MODELS (ENTIDADES) 
 
Data: 10/02/2026  9:59:13,16 
 
O arquivo Pessoa.cs EXISTE  
 
## ARQUIVOS NA PASTA ENTITIES 
Categoria.cs
EntityBase.cs
Pessoa.cs
Transacao.cs
 
## CONTE�DO DETALHADO DOS MODELS 
 
### 1. PESSOA.cs 
```csharp 
﻿using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Domain.Entities;

/// <summary>
/// Representa uma pessoa no sistema de controle de gastos.
/// </summary>
public class Pessoa : EntityBase
{
    /// <summary>
    /// Nome da pessoa.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Data de nascimento da pessoa.
    /// </summary>
    [Required]
    public DateTime DataNascimento { get; set; }

    /// <summary>
    /// Idade calculada da pessoa.
    /// </summary>
    public int Idade => CalcularIdade();

    /// <summary>
    /// Transações associadas à pessoa (propriedade de navegação).
    /// </summary>
    public ICollection<Transacao> Transacoes { get; } = new List<Transacao>();

    /// <summary>
    /// Calcula a idade baseada na data de nascimento.
    /// </summary>
    private int CalcularIdade()
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;
        if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
        return idade;
    }

    /// <summary>
    /// Verifica se a pessoa é maior de idade.
    /// </summary>
    public bool EhMaiorDeIdade()
    {
        return Idade >= 18;
    }
}
``` 
 
### 2. CATEGORIA.cs 
```csharp 
﻿using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Domain.Entities;

/// <summary>
/// Representa uma categoria de transação.
/// </summary>
public class Categoria : EntityBase
{
    /// <summary>
    /// Enum para a finalidade da categoria.
    /// </summary>
    public enum EFinalidade
    {
        Despesa,
        Receita,
        Ambas
    }

    /// <summary>
    /// Descrição da categoria.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Finalidade da categoria (Despesa, Receita ou Ambas).
    /// </summary>
    [Required]
    public EFinalidade Finalidade { get; set; }

    /// <summary>
    /// Transações associadas à categoria (propriedade de navegação).
    /// </summary>
    public ICollection<Transacao> Transacoes { get; } = new List<Transacao>();

    /// <summary>
    /// Valida se a categoria permite o tipo de transação especificado.
    /// </summary>
    public bool PermiteTipo(Transacao.ETipo tipo)
    {
        return Finalidade switch
        {
            EFinalidade.Despesa => tipo == Transacao.ETipo.Despesa,
            EFinalidade.Receita => tipo == Transacao.ETipo.Receita,
            EFinalidade.Ambas => true,
            _ => false
        };
    }
}
``` 
 
### 3. TRANSACAO.cs 
```csharp 
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Domain.Entities;

/// <summary>
/// Representa uma transação financeira.
/// </summary>
public class Transacao : EntityBase
{
    /// <summary>
    /// Enum para o tipo de transação.
    /// </summary>
    public enum ETipo
    {
        Despesa,
        Receita
    }

    /// <summary>
    /// Descrição da transação.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Valor da transação (deve ser positivo).
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Valor { get; set; }

    /// <summary>
    /// Tipo da transação (Despesa ou Receita).
    /// </summary>
    [Required]
    public ETipo Tipo { get; set; }

    /// <summary>
    /// Identificador da categoria associada.
    /// </summary>
    [Required]
    public Guid CategoriaId { get; private set; }

    /// <summary>
    /// Identificador da pessoa associada.
    /// </summary>
    [Required]
    public Guid PessoaId { get; private set; }

    /// <summary>
    /// Data em que a transação ocorreu.
    /// </summary>
    [Required]
    public DateTime Data { get; set; } = DateTime.Today;
    /// <summary>
    /// Categoria associada (propriedade de navegação).
    /// </summary>
    public Categoria? Categoria
    {
        get => _categoria;
        internal set
        {
            _categoria = value;
            if (value != null)
            {
                CategoriaId = value.Id;
                if (!value.PermiteTipo(Tipo))
                {
                    throw new InvalidOperationException(
                        Tipo == ETipo.Despesa
                            ? "Não é possível registrar despesa em categoria de receita."
                            : "Não é possível registrar receita em categoria de despesa.");
                }
            }
        }
    }

    private Categoria? _categoria;

    /// <summary>
    /// Pessoa associada (propriedade de navegação).
    /// </summary>
    public Pessoa? Pessoa
    {
        get => _pessoa;
        internal set
        {
            _pessoa = value;
            if (value != null)
            {
                PessoaId = value.Id;
                if (Tipo == ETipo.Receita && !value.EhMaiorDeIdade())
                {
                    throw new InvalidOperationException("Menores de 18 anos não podem registrar receitas.");
                }
            }
        }
    }

    private Pessoa? _pessoa;
}
``` 
 
### 4. ENTITYBASE.cs 
```csharp 
namespace MinhasFinancas.Domain.Entities;

/// <summary>
/// Classe base para todas as entidades do domínio.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Identificador único da entidade.
    /// </summary>
    public Guid Id { get; set; } = Guid.CreateVersion7();
}``` 
 
## ENUMS E VALOREOBJECTS ENCONTRADOS 
 
## BUSCA POR ENUMS NO C�DIGO 
"Nenhum enum encontrado com essa busca" 
