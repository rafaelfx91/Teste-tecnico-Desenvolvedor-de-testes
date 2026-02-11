using Xunit; 
 
namespace IntegrationTests.ControllersTests 
{ 
    public class SimpleTest 
    { 
        [Fact] 
        public void TesteSimples_DevePassar() 
        { 
            // Arrange 
            var expected = 4; 
 
            // Act 
            var result = 2 + 2; 
 
            // Assert 
            Assert.Equal(expected, result); 
        } 
    } 
} 
