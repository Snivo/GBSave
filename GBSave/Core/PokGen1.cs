namespace GBSave.Core;

public class PokGen1Save : ISaveGame
{
    static readonly string[] encodingTable = new string[]
    {
    //        0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f
    /*0*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*1*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*2*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*3*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*4*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*5*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*6*/    "A" , "B" , "C" , "D" , "E" , "F" , "G" , "H" , "I" , "V" , "S" , "L" , "M" , ":" , "ぃ", "ぅ" ,
    /*7*/    "‘" , "’" , "“" , "”" , "・",  "⋯", "ぁ" , "ぇ", "ぉ", ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*8*/    "A" , "B" , "C" , "D" , "E" , "F" , "G" , "H" , "I" , "J" , "K" , "L" , "M" , "N" , "O" , "P" ,
    /*9*/    "Q" , "R" , "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z" , "(" , ")" , ":" , ";" , "[" , "]" ,
    /*a*/    "a" , "b" , "c" , "d" , "e" , "f" , "g" , "h" , "i" , "j" , "k" , "l" , "m" , "n" , "o" , "p" ,
    /*b*/    "q" , "r" , "s" , "t" , "u" , "v" , "w" , "x" , "y" , "z" , "é" , "'d", "'l","'s" ,"'t" , "'v",
    /*c*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*d*/    ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  , ""  ,
    /*e*/    "'" , "%p", "%m", "-" ,"'r" , "'m", "?" , "!" , "." ,"ァ" , "ゥ","ェ" ,  "▷" , "▶" , "▼" , "♂" ,
    /*f*/    "$" , "x" , "." , "/" , "," , "♀" , "0" , "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" ,
    };

    static readonly IReadOnlyDictionary<char, byte> encodingTableInvert;

    static PokGen1Save()
    {
        Dictionary<string, byte> dict = new();
        byte idx = 0;

        foreach (string str in encodingTable)
            dict.Add(str, idx++);

        encodingTableInvert = (IReadOnlyDictionary<char, byte>)dict;
    }

    private byte[] data;
    private string game;

    string ISaveGame.Game => game;
    byte[] ISaveGame.Data => data;

    public string Name { get; set; }

    private void WriteByte(ushort addr, int bank, byte value) => data[addr * bank] = value;
    private void WriteBytes(ushort addr, int bank, byte[] bytes)
    {
        for (int i = 0; i < bytes.Length; i++)
            data[addr * bank + i] = bytes[i];
    }

    private byte ReadByte(ushort addr, int bank) => data[addr * bank];
    private byte[] ReadBytes(ushort addr, int bank, int length) => data[(addr * bank)..length];

    private void ApplyChanges()
    {

    }

    public PokGen1Save(byte[] data)
    {
        this.data = data;
        game = "Pokemon (Gen 1)";
        
        if (data.Length != 0x8000)
            return;


    }
}