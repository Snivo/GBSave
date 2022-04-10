namespace GBSave.Core.PokGen1;


public class Save : ISaveGame
{
    #region DataOffsets
    const int PLAYER_NAME = 0x2598;
    const int RIVAL_NAME = 0x25F6;
    #endregion


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
        WriteBytes(PLAYER_NAME, Gen1Encoding.StringToPKEncode(Name));
        WriteBytes(RIVAL_NAME, Gen1Encoding.StringToPKEncode(RivalName));
    }

    private void LoadData()
    {
        Name = Gen1Encoding.PKEncodeToString(ReadBytes(PLAYER_NAME, 7));

        RivalName = Gen1Encoding.PKEncodeToString(ReadBytes(RIVAL_NAME, 7));
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