using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoLacuna
{
    static class CryptXOR
    {
        public static byte FindKey(byte[] common, byte[] encrypted_data)
        {
            for (int i = 0; i <= encrypted_data.Length - common.Length; i++)
            {
                var i_message = encrypted_data.Skip(i);
                var key = common[0] ^ i_message.ElementAt(0);
                if (CheckKey(common, i_message, key))
                {
                    return (byte)key;
                }
            }
            return 0;
        }

        public static byte FindKey(Data common, Data encrypted_data)
        {
            return FindKey(common.Bytes, encrypted_data.Bytes);
        }

        public static void ToggleEncryption(byte[] data, byte key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ key);
            }
        }

        private static bool CheckKey(byte[] common, IEnumerable<byte> encrypted_data, int key)
        {
            for (int i = 1; i < common.Length; i++)
            {
                if ((common[i] ^ encrypted_data.ElementAt(i)) != key)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
