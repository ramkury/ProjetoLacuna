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
            //var socket = new EmpireSocket();
            //while (true)
            //{
            //    Console.WriteLine("What message do you want to send?");
            //    var message = Console.ReadLine();
            //    socket.SendMessage(message);
            //    var response_data = socket.ReadMessage(256);
            //    var str_response = Encoding.ASCII.GetString(response_data, 0, response_data.Length);
            //    Console.WriteLine(String.Format("Received (bytes) << {0}", BitConverter.ToString(response_data)));
            //    Console.WriteLine(String.Format("Received (string) << {0}", str_response));
            //}

            byte[] vader = Encoding.ASCII.GetBytes("Vader");
            byte[] message = Encoding.ASCII.GetBytes("Meu nome é Vader");
            byte key = 10;
            byte[] encrypted_message = message.Select(i => (byte)(i ^ key)).ToArray();
            Console.WriteLine(CryptXOR.FindKey(vader, encrypted_message));
            Console.ReadKey();
        }
    }
}
