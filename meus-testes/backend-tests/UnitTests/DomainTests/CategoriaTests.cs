using Xunit; 
using MinhasFinancas.Domain.Entities; 
 
namespace UnitTests.DomainTests 
{ 
    public class CategoriaTests 
    { 
        [Fact] 
        public void Categoria_PermiteTipo_DespesaComDespesa_DevePermitir() 
        { 
            // Arrange 
            var categoria = new Categoria(); 
            categoria.Finalidade = Categoria.EFinalidade.Despesa; 
 
            // Act 
            var resultado = categoria.PermiteTipo(Transacao.ETipo.Despesa); 
 
            // Assert 
            Assert.True(resultado); 
        } 
 
        [Fact] 
        public void Categoria_PermiteTipo_DespesaComReceita_NaoDevePermitir() 
        { 
            // Arrange 
            var categoria = new Categoria(); 
            categoria.Finalidade = Categoria.EFinalidade.Despesa; 
 
            // Act 
            var resultado = categoria.PermiteTipo(Transacao.ETipo.Receita); 
 
            // Assert 
            Assert.False(resultado); 
        } 
 
        [Fact] 
        public void Categoria_PermiteTipo_AmbasComQualquerTipo_DevePermitir() 
        { 
            // Arrange 
            var categoria = new Categoria(); 
            categoria.Finalidade = Categoria.EFinalidade.Ambas; 
 
            Assert.True(categoria.PermiteTipo(Transacao.ETipo.Receita)); 
            Assert.True(categoria.PermiteTipo(Transacao.ETipo.Despesa)); 
        } 
    } 
} 
