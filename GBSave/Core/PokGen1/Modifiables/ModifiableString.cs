using GBSave;
using GBSave.Core.PokGen1;

namespace GBSave.Core.PokGen1.Modifiables;

public class ModifiableString : Modifiable
{
    byte[] buffer;

    public override string Read()
    {
        for (int i = 0; i < length; i++)
            buffer[i] = data[offset + i];

        return Gen1Encoding.Decode(buffer);
    }

    public override void Write(object val)
    {
        string? str = val as string;

        byte[] encStr = Gen1Encoding.Encode(str);

        int i = 0;
        int siz = Math.Min(length - 1, encStr.Length);
        for (; i < siz; i++)
            data[offset + i] = encStr[i];
        data[offset + i++] = 0x50;

        for (; i < length; i++)
            data[offset + i] = 0;
    }

    public ModifiableString(int offset, int length, Save save) : base(offset, length, save.Data)
    {
        buffer = new byte[length + 1];
    }
}

