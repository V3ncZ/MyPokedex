namespace MyPokedex.Models
{
    public class PokemonListResponse
    {
        public int Count { get; set; }
        public List<PokemonListItem> Results { get; set; }
    }
}
