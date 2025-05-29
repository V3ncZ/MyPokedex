
namespace MyPokedex.Models
{
    public class PokemonModel
    {
        public PokemonModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonAbilities> Abilities { get; set; }
        public List<PokemonSprites> Sprites { get; set; }

    }
}
