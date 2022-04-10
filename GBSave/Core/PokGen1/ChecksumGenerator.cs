namespace GBSave.Core.PokGen1;

public static class ChecksumGenerator
{
    public static byte Generate(byte[] data, int start, int length)
    {
        /*
         *      Initialize the checksum to 255
         *      For every byte from 0x2598 to 0x3522, inclusive, subtract its value from the checksum
         *      $3522 is NOT a part of the checksum the wiki lies >:C
         */
        byte checksum = 0;

        for (int i = 0; i < length - 1; i++)
        {
            checksum += data[start + i];
        }

        checksum = (byte)~checksum;

        return checksum;
    }
}