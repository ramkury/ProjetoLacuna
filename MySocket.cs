using System;
using System.Collections.Generic;
using System.IO;
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
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public MySocket()
        {
            client = new TcpClient(address, port);
            streamReader = new StreamReader(client.GetStream());
            streamWriter = new StreamWriter(client.GetStream());
        }

        public void SendMessage(Byte[] message)
        {
            var stream = client.GetStream();
            stream.Write(message, 0, message.Length);
            Console.WriteLine(String.Format("Sent >> {0}", BitConverter.ToString(message)));
        }

        public int ReadMessage(Byte[] read_data)
        {
            int bytes_read = 0;
            var stream = client.GetStream();
            // Read at least 2 bytes representing the message size
            while (bytes_read < 2)
            {
                bytes_read += stream.Read(read_data, bytes_read, read_data.Length - bytes_read);
            }
            // This doesn't work reliably because of endianness
            //var payload_size = BitConverter.ToInt16(read_data, 0);
            int payload_size = (read_data[0] << 8) | (read_data[1]);
            while (bytes_read < payload_size)
            {
                bytes_read += stream.Read(read_data, bytes_read, read_data.Length - bytes_read);
            }
            return bytes_read;
        }
    }
}
