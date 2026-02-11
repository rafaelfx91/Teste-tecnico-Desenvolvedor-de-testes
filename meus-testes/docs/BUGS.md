# BUGS ENCONTRADOS 
 
Data: 10/02/2026 15:57:44,52 
 
## BUG #001: Exclus∆o em cascata n∆o configurada 
 
**Status**: ?? POTENCIAL BUG (precisa confirmar) 
**Regra violada**: "Exclus∆o em cascata de transaá‰es ao excluir pessoa" 
**Localizaá∆o**: `MinhasFinancasDbContext.cs` - mÇtodo `OnModelCreating()` 
**Linha aproximada**: 45-50 
 
**Descriá∆o**: 
O DbContext n∆o possui configuraá∆o de `OnDelete(DeleteBehavior.Cascade)` 
para o relacionamento entre Pessoa e Transacao. 
 
**C¢digo atual**: 
```csharp 
    .HasOne(t =
    .WithMany() 
    .HasForeignKey(t =
// FALTA: .OnDelete(DeleteBehavior.Cascade); 
``` 
 
**Comportamento esperado**: 
Ao excluir uma pessoa, todas suas transaá‰es devem ser exclu°das automaticamente. 
 
**Comportamento atual (poss°vel)**: 
Transaá‰es podem ficar ¢rf∆s no banco de dados ou a exclus∆o pode falhar 
por violaá∆o de chave estrangeira. 
 
**Como testar**: 
1. Criar pessoa com transaá‰es 
2. Excluir pessoa 
3. Verificar se transaá‰es foram removidas 
``` 
## REPOSIT‡RIOS ENCONTRADOS 
 
CategoriaRepository.cs
PessoaRepository.cs
RepositoryBase.cs
TransacaoRepository.cs
 
## BUSCA POR SERVIÄOS DE PESSOA 
"N∆o encontrado" 
 
## MêTODOS DE EXCLUS«O ENCONTRADOS 
"N∆o encontrado" 
 
## BUG #002: Front-end n∆o valida data de nascimento 
 
**Status**: ?? BUG CR÷TICO (alta probabilidade) 
**Regra violada**: "Menor de idade n∆o pode ter receitas" 
**Localizaá∆o**: Front-end React (formul†rios de pessoa) 
 
**Descriá∆o**: 
An†lise do c¢digo front-end n∆o encontrou referàncias a "DataNascimento". 
Isso indica que o formul†rio de cadastro de pessoa pode n∆o coletar 
a data de nascimento, impossibilitando a validaá∆o da regra de idade. 
 
**Evidància**: 
1. Busca por "DataNascimento" em todos arquivos .tsx retornou vazia 
2. P†gina PessoasList.tsx n∆o parece coletar data de nascimento 
3. Nenhum componente espec°fico de formul†rio de pessoa encontrado 
 
**Impacto**: 
- Usu†rios podem cadastrar receitas para menores sem validaá∆o 
- Regra de neg¢cio violada no front-end 
- Sistema inconsistente (back-end valida, front-end n∆o) 
 
**Como testar**: 
1. Executar aplicaá∆o front-end 
2. Tentar cadastrar pessoa sem data de nascimento 
3. Tentar adicionar receita para pessoa sem idade definida 
