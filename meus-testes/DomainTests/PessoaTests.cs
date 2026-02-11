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
            var pessoa = new Pessoa 
            { 
                DataNascimento = DateTime.Today.AddYears(-18) 
            }; 
 
            // Act 
            var resultado = pessoa.EhMaiorDeIdade(); 
 
            // Assert 
            Assert.True(resultado); 
        } 
    } 
} 
        [Fact] 
        public void EhMaiorDeIdade_PessoaCom17Anos_DeveRetornarFalse() 
        { 
            // Arrange 
            var pessoa = new Pessoa 
            { 
                DataNascimento = DateTime.Today.AddYears(-17).AddDays(-1) 
            }; 
 
            // Act 
            var resultado = pessoa.EhMaiorDeIdade(); 
 
            // Assert 
            Assert.False(resultado); 
        } 
 
        [Fact] 
        public void CalcularIdade_Corretamente() 
        { 
            // Arrange 
            var dataNascimento = new DateTime(2000, 6, 15); 
            var pessoa = new Pessoa { DataNascimento = dataNascimento }; 
 
            // Se hoje for 10/02/2026, a pessoa teria 25 anos 
            // Vamos testar a l¢gica 
            var idadeEsperada = DateTime.Today.Year - dataNascimento.Year; 
            if (dataNascimento.Date 
                idadeEsperada--; 
 
            // Assert 
            Assert.Equal(idadeEsperada, pessoa.Idade); 
        } 
