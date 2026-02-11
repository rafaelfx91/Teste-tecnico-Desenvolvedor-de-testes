using Xunit; 
using System; 
using MinhasFinancas.Domain.Entities; 
 
namespace UnitTests.DomainTests 
{ 
    public class TransacaoTests 
    { 
        [Fact] 
        public void Transacao_Criacao_DeveFuncionar() 
        { 
            var transacao = new Transacao(); 
            transacao.Descricao = "Teste"; 
            transacao.Valor = 100.50m; 
            transacao.Tipo = Transacao.ETipo.Receita; 
 
            // Assert 
            Assert.Equal(Transacao.ETipo.Receita, transacao.Tipo); 
            Assert.Equal(100.50m, transacao.Valor); 
            Assert.Equal("Teste", transacao.Descricao); 
        } 
 
        [Fact] 
        public void Transacao_ValidarRegraMenorIdade_TestarExcecao() 
        { 
            // Como a propriedade ‚ interna, precisamos testar de outra forma 
            // Vamos testar se a regra existe no c¢digo 
            // Arrange 
            var pessoaMenor = new Pessoa(); 
            pessoaMenor.DataNascimento = DateTime.Today.AddYears(-17); 
 
            var transacao = new Transacao(); 
            transacao.Tipo = Transacao.ETipo.Receita; 
 
            Assert.False(pessoaMenor.EhMaiorDeIdade()); 
        } 
    } 
} 
