using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLacuna
{
    class RebelsSocket
    {
        private const String address = "lacuna.ddns.net";
        private const Int32 port = 31820;
        private TcpClient client;

        public RebelsSocket() => client = new TcpClient(address, port);

        public void SendMessage(Data message)
        {
            var stream = client.GetStream();
            stream.Write(message.Bytes, 0, message.Length);
            Console.WriteLine("(Rebels) << " + message);
        }

        public Data ReadMessage(int max_size)
        {
            Byte[] read_data = new Byte[max_size];
            var stream = client.GetStream();
            while (!stream.DataAvailable) ; // Wait until there is data available
            int bytes_read = stream.Read(read_data, 0, max_size);
            return new Data(read_data.Take(bytes_read).ToArray());
        }
    }
}
