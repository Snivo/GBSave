namespace GBSave.Core.PokGen1;

using c = Char;

public class Save : ISaveGame
{
    static readonly char[] encodingTable = new char[]
    {
    //        0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f
    /*0*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*1*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*2*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*3*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*4*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*5*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*6*/    'A' , 'B' , 'C' , 'D' , 'E' , 'F' , 'G' , 'H' , 'I' , 'V' , 'S' , 'L' , 'M' , ':' , 'ぃ', 'ぅ',
    /*7*/    '‘' , '’' , '“' , '”' , '・',  '⋯', 'ぁ' , 'ぇ', 'ぉ', '\0' , '\0','\0', '\0', '\0', '\0', '\0',
    /*8*/    'A' , 'B' , 'C' , 'D' , 'E' , 'F' , 'G' , 'H' , 'I' , 'J' , 'K' , 'L' , 'M' , 'N' , 'O' , 'P' ,
    /*9*/    'Q' , 'R' , 'S' , 'T' , 'U' , 'V' , 'W' , 'X' , 'Y' , 'Z' , '(' , ')' , ':' , ';' , '[' , ']' ,
    /*a*/    'a' , 'b' , 'c' , 'd' , 'e' , 'f' , 'g' , 'h' , 'i' , 'j' , 'k' , 'l' , 'm' , 'n' , 'o' , 'p' ,
    /*b*/    'q' , 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x' , 'y' , 'z' , 'é' ,(c)1 , (c)2, (c)3, (c)4, (c)5,
    /*c*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*d*/    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0',
    /*e*/    '\'', (c)6, (c)7, '-' , (c)8, (c)9, '?' , '!' , '.' ,'ァ' , 'ゥ' , 'ェ',  '▷' , '▶' , '▼' , '♂',
    /*f*/    '$' , 'x' , '.' , '/' , ',' , '♀' , '0' , '1' , '2' , '3' , '4' , '5' , '6' , '7' , '8' , '9' ,
    };

    static readonly IReadOnlyDictionary<char, byte> encodingTableInvert;

    static Save()
    {
        Dictionary<char, byte> dict = new();
        byte idx = 0;

        foreach (char c in encodingTable)
            dict.Add(c, idx++);

        encodingTableInvert = dict;
    }

    public static string PKEncodeToString(byte[] bytes)
    {
        string ret = "";
        foreach (byte b in bytes)
            ret += encodingTable[b];

        return ret;
    }

    public static byte[] StringToPKEncode(string str)
    {
        byte[] ret = new byte[str.Length];
        int i = 0;

        foreach (char c in str)
            ret[i++] = encodingTableInvert[c];

        return ret;
    }

    private byte[] data;
    private string game;

    string ISaveGame.Game => game;
    byte[] ISaveGame.Data => data;

    #region GameData
    public string Name { get; set; }
    public string RivalName { get; set; }
    #endregion

    private void WriteByte(ushort addr, byte value) => data[addr] = value;
    private void WriteBytes(ushort addr, byte[] bytes)
    {
        for (int i = 0; i < bytes.Length; i++)
            data[addr + i] = bytes[i];
    }

    private byte ReadByte(ushort addr) => data[addr];
    private byte[] ReadBytes(ushort addr, int length) => data[(addr)..length];

    private void ApplyChanges()
    {

    }

    private void LoadData()
    {
        Name = PKEncodeToString(ReadBytes(0x25A3, 7));

        RivalName = PKEncodeToString(ReadBytes(0x25F6, 7));
    }

    public Save(byte[] data)
    {
        this.data = data;
        game = "Pokemon (Gen 1)";
        
        if (data.Length != 0x8000)
            return;

        LoadData();
    }
}