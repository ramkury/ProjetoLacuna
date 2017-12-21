using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLacuna
{
    class CryptBFF
    {
        public int exponent;
        public int modulus;

        public Data Encrypt(Data data)
        {
            var sz = data.Length;
            byte[] encrypted = new byte[sz + 2];
            encrypted[0] = (byte)(sz & 0xFF00);
            encrypted[1] = (byte)(sz & 0x00FF);
            for (int i = 0; i < sz; i++)
            {
                encrypted[i + 2] = CypherByte(data.Bytes[i]);
            }
            return new Data(encrypted);
        }

        private byte CypherByte(byte b)
        {
            int res = 1;
            for (int i = exponent; i > 0; i--)
            {
                res = (res * b) % modulus;
            }
            return (byte)(res & 0xFF);
        }
    }
}
