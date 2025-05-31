using System.Text.Json.Serialization;

namespace MyPokedex.Models
{
    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }
}
