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
        public Int32 max_size;
        private TcpClient client;

        public RebelsSocket(Int32 max_message_size)
        {
            client = new TcpClient(address, port);
            max_size = max_message_size;
        }

        public void SendMessage(Data message)
        {
            var stream = client.GetStream();
            stream.Write(message.Bytes, 0, message.Length);
            Console.WriteLine("(Rebels) << " + BitConverter.ToString(message.Bytes));
        }

        public Data ReadMessage()
        {
            Byte[] read_data = new Byte[max_size];
            var stream = client.GetStream();
            while (!stream.DataAvailable) ; // Wait until there is data available
            int bytes_read = stream.Read(read_data, 0, max_size);
            var data = new Data(read_data.Take(bytes_read).ToArray());
            Console.WriteLine("(Rebels) >> " + data.Str);
            return data;
        }

        public void Disconnect()
        {
            client.Close();
        }
    }
}
