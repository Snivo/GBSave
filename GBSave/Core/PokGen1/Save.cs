using GBSave.Core.PokGen1.Modifiables;

namespace GBSave.Core.PokGen1;


public class Save : ISaveGame
{
    public byte[] Data { get; private set; }
    public string Game { get; private set; }
    private string file;

    string ISaveGame.Game => Game;
    byte[] ISaveGame.Data => Data;

    private Dictionary<string, Modifiable> modifiables;

    private void VerifyChecksums()
    {
        WriteData("MainDataChecksum", ChecksumGenerator.Generate(Data, 0x2598, 0xF8B));
    }

    public void ConfirmChanges()
    {
        VerifyChecksums();
        File.WriteAllBytes(file, Data);
    }

    public T? ReadData<T>(string fieldName) 
    {
        if (modifiables.TryGetValue(fieldName, out Modifiable obj))
            return (T)obj.Read();

        return default;
    }

    public void WriteData(string fieldName, object value)
    {
        if (modifiables.TryGetValue(fieldName, out Modifiable obj))
            obj.Write(value);
    }

    public Save(string file)
    {
        Data = File.ReadAllBytes(file);
        this.file = file;

        Game = "Pokemon (Gen 1)";
        
        if (Data.Length != 0x8000)
            return;

        modifiables = new();
        modifiables.Add("PlayerName", new ModifiableString(0x2598, 0x0B, this));
        modifiables.Add("RivalName", new ModifiableString(0x25F6, 0x0B, this));

        // Gym badges //
        modifiables.Add("BoulderBadge", new ModifiableBit(0x2602, 0, this));
        modifiables.Add("CascadeBadge", new ModifiableBit(0x2602, 1, this));
        modifiables.Add("ThunderBadge", new ModifiableBit(0x2602, 2, this));
        modifiables.Add("RainbowBadge", new ModifiableBit(0x2602, 3, this));
        modifiables.Add("SoulBadge",    new ModifiableBit(0x2602, 4, this));
        modifiables.Add("MarshBadge",   new ModifiableBit(0x2602, 5, this));
        modifiables.Add("VolcanoBadge", new ModifiableBit(0x2602, 6, this));
        modifiables.Add("EarthBadge",   new ModifiableBit(0x2602, 7, this));

        // Checksums // 
        modifiables.Add("MainDataChecksum", new ModifiableByte(0x3523, this));
    }
}