using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GBSave.Core.PokGen1;

public struct Pokemon
{
    public string Name { get; init; }
    public int DexNum { get; init; }
    public int BaseHP { get; init; }
    public int BaseAttack { get; init; }
    public int BaseDefense { get; init; }
    public int BaseSpeed { get; init; }
    public int BaseSpecial { get; init; }
    public int Index { get; init; }

    /* 
     * Static Data 
     */

    public static readonly Pokemon[] PokemonList = new Pokemon[152];

    static Pokemon()
    {
        PokemonList = JsonConvert.DeserializeObject<List<Pokemon>>(File.ReadAllText(@"Core\PokGen1\pkmndata.json")).ToArray();
    }
}