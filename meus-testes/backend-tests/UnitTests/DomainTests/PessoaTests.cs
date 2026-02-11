using Xunit; 
using System; 
using MinhasFinancas.Domain.Entities; 
 
namespace UnitTests.DomainTests 
{ 
    public class PessoaTests 
    { 
        [Fact] 
        public void EhMaiorDeIdade_PessoaCom18Anos_DeveRetornarTrue() 
        { 
            // Arrange 
            var pessoa = new Pessoa(); 
            pessoa.DataNascimento = DateTime.Today.AddYears(-18); 
 
            // Act 
            var resultado = pessoa.EhMaiorDeIdade(); 
 
            // Assert 
            Assert.True(resultado); 
        } 
 
        [Fact] 
        public void EhMaiorDeIdade_PessoaCom17Anos_DeveRetornarFalse() 
        { 
            // Arrange 
            var pessoa = new Pessoa(); 
            pessoa.DataNascimento = DateTime.Today.AddYears(-17).AddDays(-1); 
 
            // Act 
            var resultado = pessoa.EhMaiorDeIdade(); 
 
            // Assert 
            Assert.False(resultado); 
        } 
    } 
} 
