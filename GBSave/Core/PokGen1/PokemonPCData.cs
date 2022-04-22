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
        data[0x00] = Species;

        data[0x01] = (byte)(CurrentHP >> 8);
        data[0x02] = (byte)CurrentHP;

        data[0x03] = Level;

        data[0x04] = StatusCondition;

        data[0x05] = Type1;
        data[0x06] = Type2;

        data[0x07] = CatchRate;

        data[0x08] = Move1;
        data[0x09] = Move2;
        data[0x0A] = Move3;
        data[0x0B] = Move4;

        data[0x0C] = (byte)(OTID >> 8);
        data[0x0D] = (byte)OTID;

        data[0x0E] = (byte)(EXP >> 16);
        data[0x0F] = (byte)(EXP >> 8);
        data[0x10] = (byte)EXP;

        data[0x11] = (byte)(EVData.HP >> 8);
        data[0x12] = (byte)EVData.HP;

        data[0x13] = (byte)(EVData.Attack >> 8);
        data[0x14] = (byte)EVData.Attack;

        data[0x15] = (byte)(EVData.Defense >> 8);
        data[0x16] = (byte)EVData.Defense;

        data[0x17] = (byte)(EVData.Speed >> 8);
        data[0x18] = (byte)EVData.Speed;

        data[0x19] = (byte)(EVData.Special >> 8);
        data[0x1A] = (byte)EVData.Special;

        data[0x1B] = (byte)(IVData.RawIV >> 8);
        data[0x1C] = (byte)IVData.RawIV;

        data[0x1D] = Move1PP;
        data[0x1E] = Move2PP;
        data[0x1F] = Move3PP;
        data[0x20] = Move4PP;
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