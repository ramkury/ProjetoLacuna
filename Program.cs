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
        static void Main(string[] args)
        {
            //byte[] response_data;
            //String response_str;
            //var socket = new EmpireSocket();
            //const String token = "1d0b1da2-0971-4236-9697-4f2a09588d6c";
            //Console.WriteLine("Sending token " + token + " to Empire server");
            //socket.SendMessage(token);
            //response_data = socket.ReadMessage(256);

            //while (true)
            //{
            //    Console.WriteLine("What message do you want to send?");
            //    var message = Console.ReadLine();
            //    socket.SendMessage(message);
            //    response_data = socket.ReadMessage(256);
            //    var str_response = Encoding.ASCII.GetString(response_data, 0, response_data.Length);
            //    Console.WriteLine(String.Format("Received (bytes) << {0}", BitConverter.ToString(response_data)));
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

            Data r = new Data("abc");
            Console.WriteLine(r.Str);
            Console.ReadKey();
        }
    }
}
