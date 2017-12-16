using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLacuna
{
    class MySocket
    {
        private const String token = "1d0b1da2-0971-4236-9697-4f2a09588d6c";
        private const String address = "lacuna.ddns.net";
        private const Int32 port = 21820;
        private TcpClient client;
        public MySocket() => client = new TcpClient(address, port);

        public void SendMessage(Byte[] message)
        {
            var stream = client.GetStream();
            stream.Write(message, 0, message.Length);
            Console.WriteLine(String.Format("Sent >> {0}", BitConverter.ToString(message)));
        }

        public int ReadMessage(Byte[] read_data)
        {
            var stream = client.GetStream();
            return stream.Read(read_data, 0, read_data.Length);
        }
    }
}
