using System;
using System.Text;

namespace ProjetoLacuna
{
    class Data
    {
        public byte[] Bytes;
        public String Str
        {
            get { return Encoding.ASCII.GetString(Bytes); }
            set { Bytes = Encoding.ASCII.GetBytes(value); }
        }
        public int Length { get => Bytes.Length; }

        public Data(byte[] data) => Bytes = data;
        public Data(String data) => Str = data;

        public Data DecryptEmpire()
        {
            byte key = CryptXOR.FindKey(new Data("Vader"), this);
            CryptXOR.ToggleEncryption(Bytes, key);
            return this;
        }
    }
}
