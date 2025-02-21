﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLacuna
{
    class EmpireSocket
    {
        private const String address = "lacuna.ddns.net";
        private const Int32 port = 21820;
        public Int32 max_size;
        private TcpClient client;

        public EmpireSocket(Int32 max_message_size)
        {
            client = new TcpClient(address, port);
            max_size = max_message_size;
        }

        public void SendMessage(Data message)
        {
            var stream = client.GetStream();
            stream.Write(message.Bytes, 0, message.Length);
            Console.WriteLine("(Empire) << " + message.Str);
        }

        public Data ReadMessage()
        {
            Byte[] read_data = new Byte[max_size];
            var stream = client.GetStream();
            while (true)
            {
                int bytes_read = 0;
                // Read at least 2 bytes representing the message size
                while (bytes_read < 2)
                {
                    bytes_read += stream.Read(read_data, bytes_read, read_data.Length - bytes_read);
                }
                // This doesn't work reliably because of endianness
                //var payload_size = BitConverter.ToInt16(read_data, 0);
                int payload_size = (read_data[0] << 8) | (read_data[1]);
                while (bytes_read < payload_size + 2) // Payload size does not include the first 2 bytes, hence +2
                {
                    bytes_read += stream.Read(read_data, bytes_read, read_data.Length - bytes_read);
                }
                if (VerifyChecksum(read_data, bytes_read))
                {
                    var data = new Data(TrimToData(read_data, bytes_read));
                    Console.WriteLine("(Empire) >> " + BitConverter.ToString(data.Bytes));
                    return data;
                }
                else
                {
                    Console.WriteLine("Failed to verify checksum. Message corrupted.");
                    SendMessage(new Data("send again")); 
                }
            }
        }

        private bool VerifyChecksum(Byte[] data, int size)
        {
            byte checksum = data.Take(size - 1).Aggregate((x, y) => (byte)(x + y));
            return (checksum == data[size - 1]);
        }

        private byte[] TrimToData(byte[] data, int size)
        {
            return data.Skip(2).Take(size - 3).ToArray();
        }
    }
}
