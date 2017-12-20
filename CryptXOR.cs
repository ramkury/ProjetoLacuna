using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLacuna
{
    static class CryptXOR
    {
        public static byte FindKey(byte[] common, byte[] encrypted_message)
        {
            for (int i = 0; i <= encrypted_message.Length - common.Length; i++)
            {
                var i_message = encrypted_message.Skip(i);
                var key = common[0] ^ i_message.ElementAt(0);
                if (CheckKey(common, i_message, key))
                {
                    return (byte)key;
                }
            }
            return 0;
        }


        private static bool CheckKey(byte[] common, IEnumerable<byte> encrypted_message, int key)
        {
            for (int i = 1; i < common.Length; i++)
            {
                if ((common[i] ^ encrypted_message.ElementAt(i)) != key)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
