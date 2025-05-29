
namespace MyPokedexWebTests
{
    public class APIConnectionTest
    {
        [Fact]
        public async Task Testing_The_Connection_With_The_APIAsync()
        {
            // Arrange
            using var client = new HttpClient();
            string pokemon = "charizard";

            // Act
            HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon}");

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se o status é 200-299
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);

            Assert.False(string.IsNullOrEmpty(responseBody)); // Garante que o corpo da resposta não é vazio
        }
    }
}