using System.Text.Json;
using MyPokedex.Models;

namespace MyPokedex.Services
{
    public class PokeApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://pokeapi.co/api/v2/";

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonModel> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}pokemon/{name}");

            response.EnsureSuccessStatusCode();

            // Le a resposta do json como uma string
            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemon = JsonSerializer.Deserialize<PokemonModel>(jsonString, options);


            return pokemon!;
        }

        public async Task<PokemonListResponse> GetPokemonListAsync(int page = 1, int pageSize = 50)
        {
            int offset = (page - 1) * pageSize;
            var url = $"{_baseUrl}pokemon?limit={pageSize}&offset={offset}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemonList = JsonSerializer.Deserialize<PokemonListResponse>(jsonString, options);

            return pokemonList!;
        }
    }
}
