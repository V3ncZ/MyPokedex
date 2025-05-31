using System.Text.RegularExpressions;

namespace MyPokedex.Models
{
    public class PokemonListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(Url)) return 0;
                var match = Regex.Match(Url, @"/pokemon/(\d+)/$");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int id))
                {
                    return id;
                }
                return 0;
            }
        }

        // Propriedade calculada para a URL da sprite
        public string DefaultSpriteUrl => Id > 0 ? $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png" : "";
    }
}