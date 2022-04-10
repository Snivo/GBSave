namespace GBSave.Core.PokGen1.Modifiables;

class ModifiableByte : Modifiable
{ 
    public override object Read() => data[offset];

    public override void Write(object obj) => data[offset] = (byte)obj;

    public ModifiableByte(int offset, int length, Save save) : base(offset, length, save.Data)
    {
    }
}