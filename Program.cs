using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjetoLacuna;

namespace ProjetoLacuna
{
    class Program
    {
        static int Main(string[] args)
        {
            Data empire_response, rebels_response;
            var socket = new EmpireSocket();
            const String token = "1d0b1da2-0971-4236-9697-4f2a09588d6c";
            Console.WriteLine("Sending token " + token + " to Empire server");
            socket.SendMessage(new Data(token));
            empire_response = socket.ReadMessage(256);
            if (!empire_response.Str.Equals("User accepted."))
            {
                Console.WriteLine("Failed to communicate with the Empire server");
                return -1; 
            }


            //while (true)
            //{
            //    Console.WriteLine("What message do you want to send?");
            //    var message = Console.ReadLine();
            //    socket.SendMessage(message);
            //    empire_response = socket.ReadMessage(256);
            //    var str_response = Encoding.ASCII.GetString(empire_response, 0, empire_response.Length);
            //    Console.WriteLine(String.Format("Received (bytes) << {0}", BitConverter.ToString(empire_response)));
            //    Console.WriteLine(String.Format("Received (string) << {0}", str_response));
            //}

            //byte[] vader = Encoding.ASCII.GetBytes("Vader");
            //byte[] message = Encoding.ASCII.GetBytes("Meu nome é Vader");
            //byte key = 10;
            //byte[] encrypted_message = message.Select(i => (byte)(i ^ key)).ToArray();
            //Console.WriteLine(CryptXOR.FindKey(vader, encrypted_message));
            //Console.ReadKey();

            //Regex regex = new Regex(@"x(\d+)y(\d+)");
            //var m = regex.Match("abcd batata xy5589");
            //Console.WriteLine(m.Success ? "Sucesso" : "Falha");
            //Console.ReadKey();
        }
    }
}
