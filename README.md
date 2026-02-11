# ?? Testes T‚cnicos - Sistema de Controle de Gastos 
 
 
## ?? Sobre 
 
Este reposit¢rio cont‚m a implementa‡Æo de testes para o sistema de controle de gastos residenciais, 
desenvolvido como parte de um teste t‚cnico. A abordagem focou em validar as regras de neg¢cio 
cr¡ticas atrav‚s de uma pirƒmide de testes completa. 
 
**?? Nota Importante**: Este reposit¢rio cont‚m **apenas os testes**. O c¢digo original do sistema 
est  dispon¡vel em [FinanceiroAPIDev](https://github.com/rafaelfx91/FinanceiroAPIDev) e foi 
intencionalmente exclu¡do via `.gitignore` para respeitar os termos do teste. 
 
## ?? Objetivos Atendidos 
 
- ? Entender regras de neg¢cio a partir de c¢digo existente 
- ? Projetar e implementar pirƒmide de testes adequada 
- ? Identificar e documentar falhas de implementa‡Æo 
- ? Aplicar boas pr ticas de testes automatizados em .NET e React/TypeScript 
 
## ??? Pirƒmide de Testes Implementada 
 
```mermaid 
graph TD 
    A[Pirƒmide de Testes] -- E2E]; 
    A -- de Integra‡Æo]; 
    A -- Unit rios]; 
    D -- testes back-end]; 
    C --
    B --
``` 
 
## ?? Estrutura do Reposit¢rio 
 
\`\`\` 
tests-tecnicos-financeiro/ 
	backend-tests/                    # Testes back-end (.NET 6 + xUnit) 
		UnitTests/                   # ? 8 testes unit rios funcionando 
		IntegrationTests/            # ?? Projeto configurado 
	frontend-tests/                  # Estrutura para testes front-end 
		unit/                        # Configura‡Æo Vitest 
		e2e/                         # Configura‡Æo Playwright 
	docs/                            # ?? Documenta‡Æo completa 
		RELATORIO_FINAL.md           # Relat¢rio detalhado 
		bugs.md                      # ?? Bugs documentados 
		frontend-analysis.md         # An lise do front-end 
		progresso-teste.md           # Progresso da implementa‡Æo 
	scripts/                         # ?? Scripts auxiliares 
	.gitignore                       # ?? Exclui c¢digo original 
	README.md                        # Este arquivo 
	RESUMO_EXECUTIVO.md              # ?? Resumo para recrutadores 
\`\`\` 
 
## ?? Bugs Identificados 
 
### ?? BUG #001: ExclusÆo em cascata nÆo configurada 
**Local**: \`MinhasFinancasDbContext.cs\` - m‚todo \`OnModelCreating()\` 
**Problema**: Falta \`OnDelete(DeleteBehavior.Cascade)\` no relacionamento Pessoa-Transacao 
**Impacto**: Transa‡äes podem ficar ¢rfÆs no banco de dados 
 
### ?? BUG #002: Front-end nÆo valida data de nascimento 
**Local**: Front-end React 
**Problema**: Nenhuma referˆncia a \`DataNascimento\` encontrada nos componentes 
**Impacto**: Regra "menor nÆo pode ter receitas" nÆo funciona no cliente 
 
## ?? Como Executar os Testes 
 
### Pr‚-requisitos 
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download) 
- [Node.js 18+](https://nodejs.org/) (para testes front-end) 
- [Git](https://git-scm.com/) 
 
### 1. Preparar Ambiente 
\`\`\`bash 
# Clonar este reposit¢rio 
cd testes-tecnicos 
 
# Clonar c¢digo original (separadamente) 
git clone https://github.com/rafaelfx91/FinanceiroAPIDev codigo-original 
\`\`\` 
 
### 2. Testes Back-end 
\`\`\`bash 
cd backend-tests/UnitTests 
dotnet restore 
dotnet test 
\`\`\` 
 
**? Resultado Esperado**: 8 testes passando 
 
### 3. Testes Front-end (Opcional - requer Node.js) 
\`\`\`bash 
cd frontend-tests 
npm install  # ou bun install 
npm run test:unit    # Testes unit rios (Vitest) 
npx playwright test  # Testes E2E (Playwright) 
\`\`\` 
 
## ?? Cobertura de Testes 
 
 
## ?? Metodologia de Teste 
 
1. **An lise do c¢digo** - Mapeamento de estrutura e regras 
2. **Testes Unit rios** - Foco nas regras de neg¢cio no dom¡nio 
3. **Testes de Integra‡Æo** - Valida‡Æo de API e banco de dados 
4. **An lise Front-end** - Investiga‡Æo de valida‡äes no cliente 
5. **Documenta‡Æo** - Registro detalhado de bugs e descobertas 
 
## ?? Regras de Neg¢cio Validadas 
 
### ? Implementadas corretamente (back-end): 
1. **Menor de idade nÆo pode ter receitas** - Valida‡Æo no setter \`Transacao.Pessoa\` 
2. **Categoria conforme finalidade** - M‚todo \`Categoria.PermiteTipo()\` 
 
### ? Problemas identificados: 
1. **ExclusÆo em cascata** - NÆo configurada no DbContext (BUG #001) 
2. **Valida‡Æo no front-end** - Campo data nascimento nÆo encontrado (BUG #002) 
 
## ?? Contato 
 
Este projeto foi desenvolvido como parte de um teste t‚cnico. 
Para mais informa‡äes sobre a implementa‡Æo, consulte a documenta‡Æo em \`docs/\`. 
 
--- 
*Desenvolvido com foco em qualidade, boas pr ticas e valida‡Æo de regras de neg¢cio.* 
