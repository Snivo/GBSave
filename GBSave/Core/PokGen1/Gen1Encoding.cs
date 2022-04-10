﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBSave.Core.PokGen1;

public class Gen1Encoding
{
    public static readonly byte[] encode2str = new byte[]
    {
        //      -0    -1    -2    -3    -4    -5    -6    -7    -8    -9    -A    -B    -C    -D    -E    -F
        /*0-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*1-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*2-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*3-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*4-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*5-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*6-*/ 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x56, 0x53, 0x4C, 0x4D, 0x3A, 0x43, 0x45,
        /*7-*/ 0x18, 0x19, 0x1C, 0x1D, 0xFB, 0xEF, 0x41, 0x47, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20,
        /*8-*/ 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50,
        /*9-*/ 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x28, 0x29, 0x3A, 0x3B, 0x5B, 0x5D,
        /*A-*/ 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F, 0x70,
        /*B-*/ 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0xE9, 0x01, 0x02, 0x03, 0x04, 0x05,
        /*C-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*D-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*E-*/ 0x27, 0x06, 0x07, 0x2D, 0x08, 0x09, 0x3F, 0x21, 0x2E, 0xA1, 0xA5, 0xA7, 0xB7, 0xB6, 0xBC, 0x42,
        /*F-*/ 0x24, 0x78, 0x2E, 0x2F, 0x2C, 0x40, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39,
    };

    public static readonly byte[] str2encode = new byte[]
    {
        //      -0    -1    -2    -3    -4    -5    -6    -7    -8    -9    -A    -B    -C    -D    -E    -F
        /*0-*/ 0x00, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF, 0xE1, 0xE2, 0xE4, 0xE5, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*1-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x71, 0x00, 0x00, 0x72, 0x73, 0x00, 0x00,
        /*2-*/ 0x7F, 0xE7, 0x00, 0x00, 0xF0, 0x00, 0x00, 0xE0, 0x9A, 0x9B, 0x00, 0x00, 0xF4, 0xE3, 0xE8, 0xF3,
        /*3-*/ 0xF6, 0xF7, 0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF, 0x6D, 0x9D, 0x00, 0x00, 0x00, 0xE6,
        /*4-*/ 0xF5, 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x89, 0x8A, 0x6B, 0x6C, 0x8D, 0x8E,
        /*5-*/ 0x8F, 0x90, 0x91, 0x6A, 0x93, 0x94, 0x69, 0x96, 0x97, 0x98, 0x99, 0x9E, 0x00, 0x9F, 0x00, 0x00,
        /*6-*/ 0x00, 0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7, 0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE,
        /*7-*/ 0xAF, 0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7, 0xB8, 0xB9, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*8-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*9-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*A-*/ 0x00, 0xE9, 0x00, 0x00, 0x00, 0xEA, 0x00, 0xEB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*B-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xED, 0xEC, 0x00, 0x00, 0x00, 0x00, 0xEE, 0x00, 0x00, 0x00,
        /*C-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*D-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        /*E-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xBA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x75,
        /*F-*/ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x74, 0x00, 0x00, 0x00, 0x00,
    };

    public static string Decode(byte[] bytes)
    {
        char[] str = new char[bytes.Length];
        int i = 0;
        foreach (byte b in bytes)
            str[i++] = (char)encode2str[b];

        return new string(str);
    }

    public static byte[] Encode(string str)
    {
        byte[] ret = new byte[str.Length];
        int i = 0;

        foreach (byte b in str)
            ret[i++] = str2encode[b];

        return ret;
    }
}