namespace GBSave.Core.PokGen1;

public class Pokemon
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
        if (data == null || data.Length < 33)
            return false;

        return true;
    }

    public bool ToBoxData(ref byte[] data)
    {
        if (data == null || data.Length < 33)
            return false;

        return true;
    }
}