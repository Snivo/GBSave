namespace GBSave;

public abstract class Modifiable
{
    protected int offset;
    protected int length;

    protected byte[] data;

    public abstract void Write(object obj);
    public abstract object Read();

    public Modifiable(int offset, int length, byte[] data)
    {
        this.offset = offset;
        this.length = length;
        this.data = data;
    }
}
