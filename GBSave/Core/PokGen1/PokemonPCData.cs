namespace GBSave.Core.PokGen1;

public class PokemonPCData
{
    public Pokemon Pokemon
    {
        get
        {
            foreach (Pokemon pkmn in Pokemon.PokemonList)
                if (pkmn.Index == Species)
                    return pkmn;

            return default;
        }
    }

    public byte Species { get; set; }
    public ushort CurrentHP { get; set; }
    public byte Level { get; set; }
    public byte StatusCondition { get; set; }
    public byte Type1 { get; set; }
    public byte Type2 { get; set; }
    public byte CatchRate { get; set; }
    public byte Move1 { get; set; }
    public byte Move2 { get; set; }
    public byte Move3 { get; set; }
    public byte Move4 { get; set; }
    public ushort OTID { get; set; }
    private int exp;
    public int EXP { get => exp; set => exp = value & 0x00FFFFFF; } // 3 bytes
    public EVData EVData { get; set; }
    public IVData IVData { get; set; }
    public byte Move1PP { get; set; }
    public byte Move2PP { get; set; }
    public byte Move3PP { get; set; }
    public byte Move4PP { get; set; }

    public void GetBinaryData(ref byte[] data)
    {

    }
}

public struct IVData
{
    public ushort RawIV { get; set; }

    // Health IVs in gen 1 are defined by the first bit of every other IV //
    public int Health
    {
        get => (RawIV & 0x0001) | ((RawIV & 0x0010) >> 3) | ((RawIV & 0x0100) >> 6) | (RawIV & 0x1000 >> 9);
        set
        {
            RawIV &= 0xEEEE;
            RawIV |= (ushort)((value & 0b0001) | ((value & 0b0010) << 3) | ((value & 0b0100) << 6) | ((value & 0b1000) << 9));
        }
    }
    public int Attack
    {
        get => (RawIV & 0xF000) >> 12;
        set => RawIV = (ushort)((RawIV & 0x0FFF) | ((value & 0x0F) << 12));
    }
    public int Defense
    {
        get => (RawIV & 0x0F00) >> 8;
        set => RawIV = (ushort)((RawIV & 0xF0FF) | ((value & 0x0F) << 8));
    }
    public int Speed
    {
        get => (RawIV & 0x00F0) >> 4;
        set => RawIV = (ushort)((RawIV & 0xFF0F) | ((value & 0x0F) << 4));
    }
    public int Special
    {
        get => (RawIV & 0x000F);
        set => RawIV = (ushort)((RawIV & 0xFFF0) | (value & 0x0F));
    }
}

public struct EVData
{
    public ushort HP { get; set; }
    public ushort Attack { get; set; }
    public ushort Defense { get; set; }
    public ushort Speed { get; set; }
    public ushort Special { get; set; }
}