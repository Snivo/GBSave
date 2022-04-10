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


    }

    public override void Write(object val)
    {
        string value = (string)val;
    }

    public ModifiableString(int offset, int length, Save save) : base(offset, length, save.Data)
    {
        buffer = new byte[length + 1];
    }
}

