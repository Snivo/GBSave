namespace GBSave;

public interface ISaveGame
{
    public string Game { get; }
    public byte[] Data { get; }
}