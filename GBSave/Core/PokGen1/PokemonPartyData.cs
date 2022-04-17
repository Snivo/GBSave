namespace GBSave.Core.PokGen1;

class PokemonPartyData : PokemonPCData
{
    public ushort MaxHP { get; set; }
    public ushort Attack { get; set; }
    public ushort Defense { get; set; }
    public ushort Speed { get; set; }
    public ushort Special { get; set; }

    public new void GetBinaryData(ref byte[] data)
    {

    }
}