using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLacuna;

namespace ProjetoLacuna
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new MySocket();
            var response = new Byte[256];
            while (true)
            {
                Console.WriteLine("What message do you want to send?");
                var message = Console.ReadLine();
                socket.SendMessage(Encoding.ASCII.GetBytes(message));
                var byte_count = socket.ReadMessage(response);
                var str_response = Encoding.ASCII.GetString(response, 0, byte_count);
                Console.WriteLine(String.Format("Received (bytes) << {0}", BitConverter.ToString(response)));
                Console.WriteLine(String.Format("Received (string) << {0}", str_response));
            }
            //Byte[] bytes = { 1, 2, 3 };
            //Console.WriteLine(BitConverter.ToString(bytes));
            //Console.Read();
        }
    }
}
