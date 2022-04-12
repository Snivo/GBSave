namespace GBSave.Core.PokGen1.Modifiables;

class ModifiableByte : Modifiable
{ 
    public override object Read() => data[offset];

    public override void Write(object obj) => data[offset] = (byte)obj;

    public ModifiableByte(int offset, Save save) : base(offset, 1, save.Data)
    {
    }
}