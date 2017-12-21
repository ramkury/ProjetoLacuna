using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoLacuna
{
    class Data
    {
        private static Regex regex = new Regex(@"x(\d+)y(\d+)");
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

        public bool HasCoordinates()
        {
            var m = regex.Match(Str);
            return m.Success;
        }

        public bool Equals(Data other)
        {
            return Str.Equals(other.Str);
        }
    }
}
