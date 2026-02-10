# Teste tecnico Desenvolvedor de testes

CRONOGRAMA DETALHADO
FASE 1: PREPARAÇÃO (1 hora)

✅ Tarefas:
Criar repositório GitHub com estrutura de pastas
Configurar .gitignore para excluir código da aplicação
Criar README.md base
Configurar scripts básicos no package.json

📁 Estrutura inicial do repositório:
meu-repo-teste/
├── README.md
├── .gitignore
├── docs/
│   ├── BUGS.md
│   └── METODOLOGIA.md
└── scripts/
    └── setup-tests.sh

FASE 2: ANÁLISE DO CÓDIGO ORIGINAL (2-3 horas)
PASSO A PASSO DA ANÁLISE:
Clonar repositório original (read-only)

git clone [URL] codigo-original --depth 1


2-Mapear estrutura do projeto:
Back-end (.NET):
Controllers/ (API endpoints)
Services/ (regras de negócio)
Models/ (entidades)
Data/ (contexto EF)
Validators/ (validações)

Front-end (React):
src/components/ (componentes React)
src/services/ (chamadas API)
src/utils/ (funções auxiliares)
src/types/ (TypeScript types)


3-Identificar pontos críticos:
Onde a idade é validada?
Onde categorias são validadas?
Como a exclusão em cascata é implementada?
Quais são os endpoints da API?


4-Criar mapa mental das dependências
Relações entre entidades
Fluxo de validações
Pontos de falha potenciais

FASE 3: TESTES BACK-END (5-6 horas)
3.1 TESTES UNITÁRIOS (.NET/xUnit)

Foco: Regras de negócio nos Services

// EXEMPLO DE ESTRUTURA DE TESTE
public class PessoaServiceTests
{
    [Fact]
    public void AdicionarTransacao_MenorDeIdade_TentandoReceita_DeveFalhar()
    {
        // Arrange
        var pessoa = new Pessoa { DataNascimento = DateTime.Now.AddYears(-17) };
        var transacao = new Transacao { Tipo = TipoTransacao.Receita, Valor = 100 };
        
        // Act & Assert
        Assert.Throws<BusinessException>(() => 
            pessoaService.AdicionarTransacao(pessoa, transacao));
    }
    
    [Theory]
    [InlineData(TipoCategoria.Receita, TipoTransacao.Despesa, false)] // Deve falhar
    [InlineData(TipoCategoria.Despesa, TipoTransacao.Receita, false)] // Deve falhar
    [InlineData(TipoCategoria.Ambas, TipoTransacao.Receita, true)]   // Deve passar
    public void ValidarCategoria_PorTipoTransacao(
        TipoCategoria categoria, 
        TipoTransacao transacao, 
        bool esperadoSucesso)
    {
        // Testar todas combinações
    }
}


1-Validação de idade:
Pessoa 17 anos + receita = ERRO
Pessoa 18 anos + receita = OK
Pessoa 17 anos + despesa = OK
Pessoa 0 anos (data futura) = ERRO

2-Validação de categoria:
Categoria "Aluguel" (despesa) com receita = ERRO
Categoria "Salário" (receita) com despesa = ERRO
Categoria "Outros" (ambas) com qualquer tipo = OK

3-Exclusão em cascata:
Excluir pessoa → verificar se transações são excluídas
Excluir categoria em uso → comportamento?


3.2 TESTES DE INTEGRAÇÃO

Foco: API endpoints + banco de dados
public class PessoaControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    [Fact]
    public async Task POST_PessoaMenorDeIdade_ComReceita_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new 
        { 
            Nome = "João",
            DataNascimento = "2008-01-01",
            Transacoes = new[] 
            { 
                new { Tipo = "Receita", Valor = 100 } 
            }
        };
        
        // Act
        var response = await _client.PostAsJsonAsync("/api/pessoas", request);
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}


3.2-Endpoints a testar:
POST /api/pessoas (validação em tempo real)
PUT /api/pessoas/{id}/transacoes (adicionar transação)
DELETE /api/pessoas/{id} (exclusão cascata)
GET /api/pessoas/{id}/total (cálculo de totais)


ASE 4: TESTES FRONT-END (4-5 horas)
4.1 TESTES UNITÁRIOS (React/Vitest)

Foco: Componentes + lógica de validação
// EXEMPLO: Teste de componente de formulário
describe('PessoaForm', () => {
  test('deve mostrar erro ao adicionar receita para menor de idade', () => {
    // Renderizar componente com pessoa de 17 anos
    // Simular adição de receita
    // Verificar se mensagem de erro aparece
  });
  
  test('deve filtrar categorias conforme tipo de transação', () => {
    // Ao selecionar "Receita", mostrar apenas categorias do tipo Receita
    // Ao selecionar "Despesa", mostrar apenas categorias do tipo Despesa
  });
});


Componentes a testar:
Formulário de pessoa (validação de idade)
Formulário de transação (filtro de categorias)
Lista de transações (cálculos)
Modal de confirmação de exclusão


Foco: Fluxos completos do usuário
// Fluxo CRUD completo com validações
test.describe('Fluxo completo de pessoa', () => {
  test('cadastrar menor de idade não pode adicionar receita', async ({ page }) => {
    // 1. Acessar sistema
    await page.goto('/pessoas');
    
    // 2. Clicar em "Nova Pessoa"
    await page.click('button:has-text("Nova Pessoa")');
    
    // 3. Preencher dados (nome, data nascimento = 17 anos atrás)
    await page.fill('#nome', 'João Silva');
    await page.fill('#dataNascimento', '2007-01-01');
    
    // 4. Clicar em "Adicionar Transação"
    await page.click('button:has-text("Adicionar Transação")');
    
    // 5. Selecionar tipo "Receita"
    await page.selectOption('#tipoTransacao', 'Receita');
    
    // 6. Verificar que aparece mensagem de erro
    await expect(page.locator('.error-message'))
      .toContainText('Menor de idade não pode ter receitas');
    
    // 7. Tirar screenshot como evidência
    await page.screenshot({ path: 'bug-menor-idade-receita.png' });
  });
});


Fluxos E2E a testar:
Cadastro pessoa → adição transação → validação idade
Cadastro categoria → uso incorreto → validação
Exclusão pessoa → verificar transações removidas
Cálculo de totais por pessoa


FASE 5: DOCUMENTAÇÃO (1-2 horas)
## BUG #001: Menor de idade pode cadastrar receita

### Localização
- **Back-end**: `Services/PessoaService.cs`, método `AdicionarTransacao()`
- **Front-end**: `components/PessoaForm.vue`, validação no submit

### Como reproduzir
1. Acessar sistema
2. Cadastrar pessoa com data de nascimento: 01/01/2008
3. Adicionar transação do tipo "Receita"
4. Salvar

### Comportamento atual
- Sistema aceita e salva a transação
- Nenhuma validação é feita

### Comportamento esperado
- Sistema deve rejeitar com mensagem: "Menor de idade não pode ter receitas"
- Transação não deve ser salva

### Evidências
- Screenshot do teste falhando
- Log da requisição API
- Print do banco de dados mostrando registro incorreto

### Tags
- `regra-negocio` `alta-severidade` `validacao-idade`


5.2 CATEGORIAS DE BUGS A DOCUMENTAR
Crítico: Regra de negócio violada
Alta: Validação inconsistente
Média: UI/UX que permite ação incorreta
Baixa: Mensagens de erro pouco claras
	
	
FASE 6: CONFIGURAÇÃO CI (1 hora)	
6.1 GITHUB ACTIONS WORKFLOW	
name: Testes Automatizados

on: [push, pull_request]

jobs:
  backend-tests:
    runs-on: ubuntu-latest
    steps:
      - name: Clonar repositório original
        run: git clone ${{ secrets.ORIGINAL_REPO_URL }} codigo-fonte
      - name: Copiar testes
        run: cp -r nossos-testes/backend/ codigo-fonte/
      - name: Executar testes unitários
        run: cd codigo-fonte && dotnet test backend/UnitTests
      - name: Executar testes integração
        run: cd codigo-fonte && dotnet test backend/IntegrationTests
  
  frontend-tests:
    runs-on: ubuntu-latest
    steps:
      - name: Instalar dependências
        run: npm ci
      - name: Executar testes unitários
        run: npm run test:unit
      - name: Executar testes E2E
        run: npm run test:e2e	
	
	
METRICAS DE QUALIDADE
O que vou medir:
Cobertura das regras de negócio: 100% das regras testadas
Bugs encontrados: Documentar todos, classificar por severidade
Tempo de execução: Tests devem rodar em < 5 minutos
Legibilidade: Qualquer dev consegue entender os testes	
	
Checklist final:
Todos os testes compilando
Pipeline CI funcionando
README completo
Bugs documentados
Código organizado em pastas
Screenshots das falhas
Exemplos de como reproduzir bugs	
	
	
TEMPO TOTAL ESTIMADO
Total: 14-18 horas
Preparação: 1h
Análise: 3h
Back-end tests: 6h
Front-end tests: 5h
Documentação: 2h
CI: 1h


RISCOS E MITIGAÇÃO
Risco					Mitigação
Código complexo			Focar apenas nas regras de negócio mencionadas
Testes lentos			Usar banco em memória, mockar serviços externos
Dependências faltando	Criar mocks/stubs simplificados
Tempo insuficiente		Priorizar regras críticas primeiro


SUPORTE NECESSÁRIO
Acesso ao repositório original
Diagrama de entidades (se disponível)
Especificação de API (Swagger/Postman)
Dados de teste exemplo
















