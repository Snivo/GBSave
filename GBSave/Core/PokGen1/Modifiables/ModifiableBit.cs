namespace GBSave.Core.PokGen1.Modifiables;

public class ModifiableBit : Modifiable
{
    private readonly int bit;

    public override object Read() => (data[offset] & (1 << bit)) != 0;

    public override void Write(object obj)
    {
        bool set = (bool)obj;
        
        data[offset] = (byte)(set ? (data[offset] | (1 << bit)) : (data[offset] & ~(1 << bit)));
    }

    public ModifiableBit(int offset, int bit, Save save) : base(offset, 1, save.Data)
    {
        this.bit = bit;
    }
}