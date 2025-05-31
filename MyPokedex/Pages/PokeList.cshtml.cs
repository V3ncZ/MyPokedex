using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPokedex.Models;
using MyPokedex.Services;
using System.Collections.Generic; // Certifique-se de ter este using

namespace MyPokedex.Pages
{
    public class PokeListModel : PageModel
    {
        private readonly PokeApiService _pokeApiService;

        public List<PokemonListItem> PokemonListItems { get; set; } // O modelo da página é PokemonListItem
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public PokeListModel(PokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task OnGetAsync(int page = 1, int pageSize = 50)
        {
            try
            {
                var response = await _pokeApiService.GetPokemonListAsync(page, pageSize);
                PokemonListItems = response.Results; // Atribua a lista de PokemonListItem

                CurrentPage = page;
                TotalPages = (int)Math.Ceiling((double)response.Count / pageSize);

                ViewData["Page"] = CurrentPage;
                ViewData["TotalPages"] = TotalPages;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao buscar lista de Pokémon: {e.Message}");
                PokemonListItems = new List<PokemonListItem>();
                CurrentPage = page;
                TotalPages = 1;
            }
        }
    }
}