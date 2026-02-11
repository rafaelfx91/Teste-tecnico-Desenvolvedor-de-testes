# RESUMO DAS REGRAS DE NEG‡CIO ENCONTRADAS 
 
Data: 10/02/2026 15:51:04,07 
 

 
## REGRA 1: Menor de idade n∆o pode ter receitas 
 
**Status**: ? IMPLEMENTADA 
**Localizaá∆o**: `Transacao.cs` (linhas 62-65) 
**MÇtodo**: Validaá∆o no setter da propriedade `Pessoa` 
**Exceá∆o**: `InvalidOperationException` com mensagem espec°fica 
 
**C¢digo encontrado**: 
```csharp 
{ 
    throw new InvalidOperationException("Menores de 18 anos n∆o podem registrar receitas."); 
} 
``` 
 
## REGRA 2: Categoria conforme finalidade 
 
**Status**: ? IMPLEMENTADA 
**Localizaá∆o**: 
- `Categoria.cs` - MÇtodo `PermiteTipo()` 
- `Transacao.cs` - Validaá∆o no setter da propriedade `Categoria` 
 
**C¢digo encontrado**: 
```csharp 
// Em Categoria.cs 
public bool PermiteTipo(Transacao.ETipo tipo) 
{ 
    return Finalidade switch 
    { 
        EFinalidade.Despesa = == Transacao.ETipo.Despesa, 
        EFinalidade.Receita = == Transacao.ETipo.Receita, 
        EFinalidade.Ambas =
        _ =
    }; 
} 
 
// Em Transacao.cs 
if (!value.PermiteTipo(Tipo)) 
{ 
    throw new InvalidOperationException( 
        Tipo == ETipo.Despesa 
            ? "N∆o Ç poss°vel registrar despesa em categoria de receita." 
            : "N∆o Ç poss°vel registrar receita em categoria de despesa."); 
} 
``` 
## REGRA 3: Exclus∆o em cascata de transaá‰es ao excluir pessoa 
 
**Status**: ?? PRECISA INVESTIGAR 
**Onde verificar**: 
1. Configuraá∆o do DbContext 
2. Configuraá‰es do Entity Framework 
3. Reposit¢rios ou Services de exclus∆o 
