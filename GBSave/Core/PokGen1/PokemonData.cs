namespace GBSave.Core.PokGen1;

public class PokemonData
{
    public byte Species { get; set; }
    public ushort HP { get; set; }
    public byte Level { get; set; }
    public StatusCondition StatusCondition { get; set; }
    public byte Type1 { get; private set; }
    public byte Type2 { get; private set; }
    public byte CatchRate { get; set; }
    public byte Move1 { get; set; }
    public byte Move2 { get; set; }
    public byte Move3 { get; set; }
    public byte Move4 { get; set; }
    public ushort OTID { get; set; }
    private int exp;
    public int EXP { get => exp; set => exp = Math.Min(0x00FFFFFF, value); }
    public ushort HPEV { get; set; }
    public ushort AtkEV { get; set; }
    public ushort DefEV { get; set; }
    public ushort SpdEV { get; set; }
    public ushort SpeEV { get; set; }
    private ushort ivData;
    public byte HPIV
    {
        /*
         * In Gen 1 the HP IV was the LSB of the other 4 IVs 
         *  Atk Def Spd Spe
         *  b3  b2  b1  b0
         *  It's weird, I know.
         */
        get => (byte)(((AtkIV & 0b1) << 4) | ((DefIV & 0b1) << 3) | ((SpdIV & 0b1) << 2) | (SpeIV & 0b1));
        set
        {
            AtkIV = (byte)((AtkIV & 0b0111) | (value & 0b1000));
            DefIV = (byte)((DefIV & 0b1011) | (value & 0b0100));
            SpdIV = (byte)((SpdIV & 0b1101) | (value & 0b0010));
            SpeIV = (byte)((SpeIV & 0b1110) | (value & 0b0001));
        }
    }
    /* THESE ARE ASSUMED BIT ORDERS!!! */
    public byte AtkIV { get => (byte)(ivData >> 12); set => ivData = (ushort)((ivData & 0x0FFF) | (Math.Min((byte)15, value) << 12)); }
    public byte DefIV { get => (byte)((ivData >> 8) & 0xF); set => ivData = (ushort)((ivData & 0xF0FF) | (Math.Min((byte)15, value) << 8)); }
    public byte SpdIV { get => (byte)((ivData >> 4) & 0xF); set => ivData = (ushort)((ivData & 0xFF0F) | (Math.Min((byte)15, value) << 4)); }
    public byte SpeIV { get => (byte)((ivData) & 0xF); set => ivData = (ushort)((ivData & 0xFFF0) | (Math.Min((byte)15, value))); }
    public byte Move1PP { get; set; }
    public byte Move2PP { get; set; }
    public byte Move3PP { get; set; }
    public byte Move4PP { get; set; }
    public ushort MaxHP { get; set; }
    public ushort Attack { get; set; }
    public ushort Defense { get; set; }
    public ushort Speed { get; set; }
    public ushort Special { get; set; }

    public bool ToPartyData(ref byte[] data)
    {
        if (data == null || data.Length < 44)
            return false;

        if (!ToBoxData(ref data))
            return false;

        data[0x21] = Level;
        data[0x22] = (byte)(MaxHP >> 8);
        data[0x23] = (byte)MaxHP;
        data[0x24] = (byte)(Attack >> 8);
        data[0x25] = (byte)Attack;
        data[0x26] = (byte)(Defense >> 8);
        data[0x27] = (byte)Defense;
        data[0x28] = (byte)(Speed >> 8);
        data[0x29] = (byte)Speed;
        data[0x2A] = (byte)(Special >> 8);
        data[0x2B] = (byte)Special;

        return true;
    }

    public bool ToBoxData(ref byte[] data)
    {
        if (data == null || data.Length < 33)
            return false;

        data[0x00] = Species;
        data[0x01] = (byte)(HP >> 8);
        data[0x02] = (byte)HP;
        data[0x03] = Level;
        data[0x04] = (byte)StatusCondition;
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
        data[0x11] = (byte)(HPEV >> 8);
        data[0x12] = (byte)HPEV;
        data[0x13] = (byte)(AtkEV >> 8);
        data[0x14] = (byte)AtkEV;
        data[0x15] = (byte)(DefEV >> 8);
        data[0x16] = (byte)DefEV;
        data[0x17] = (byte)(SpdEV >> 8);
        data[0x18] = (byte)SpdEV;
        data[0x19] = (byte)(SpeEV >> 8);
        data[0x1A] = (byte)SpeEV;
        data[0x1B] = (byte)(ivData >> 8);
        data[0x1C] = (byte)ivData;
        data[0x1D] = Move1PP;
        data[0x1E] = Move2PP;
        data[0x1F] = Move3PP;
        data[0x20] = Move4PP;

        return true;
    }

    public PokemonData(byte[] data)
    {
        if (data.Length < 0x21)
            return;

        Species = data[0];
        HP = (ushort)((data[1] << 8) | data[2]);
        Level = data[0x03];
        StatusCondition = (StatusCondition)data[0x04];
        Type1 = data[0x05];
        Type2 = data[0x06];
        CatchRate = data[0x07];
        Move1 = data[0x08];
        Move2 = data[0x09];
        Move3 = data[0x0A];
        Move4 = data[0x0B];
        OTID = (ushort)((data[0x0C] << 8) | data[0x0D]);
        EXP = (data[0x0E] << 16) | data[0x0F] << 8 | data[0x10];
        HPEV = (ushort)((data[0x11] << 8) | data[0x12]);
        AtkEV = (ushort)((data[0x13] << 8) | data[0x14]);
        DefEV = (ushort)((data[0x15] << 8) | data[0x16]);
        SpdEV = (ushort)((data[0x17] << 8) | data[0x18]);
        SpeEV = (ushort)((data[0x19] << 8) | data[0x1A]);
        ivData = (ushort)((data[0x1B] << 8) | data[0x1C]);
        Move1 = data[0x1D];
        Move2 = data[0x1E];
        Move3 = data[0x1F];
        Move4 = data[0x20];

        if (data.Length > 0x2B)
        {
            MaxHP = (ushort)((data[0x22] << 8) | data[0x23]);
            Attack = (ushort)((data[0x24] << 8) | data[0x25]);
            Defense = (ushort)((data[0x26] << 8) | data[0x27]);
            Speed = (ushort)((data[0x28] << 8) | data[0x29]);
            Special = (ushort)((data[0x2A] << 8) | data[0x2B]);
        }
        else
        {
            /* TODO: CALCULATE THE VALUES */
        }
    }
}