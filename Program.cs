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
            var empireSocket = new EmpireSocket();
            var rebelsSocket = new RebelsSocket();
            var cryptBFF = new CryptBFF();
            const String token = "1d0b1da2-0971-4236-9697-4f2a09588d6c";
            Console.WriteLine("Sending token " + token + " to Empire server");
            empireSocket.SendMessage(new Data(token));
            empire_response = empireSocket.ReadMessage(256);
            if (!empire_response.Str.Equals("User accepted."))
            {
                Console.WriteLine("Failed to communicate with the Empire server");
                return -1;
            }
            Console.WriteLine("Sending token " + token + " to Rebels server");
            rebelsSocket.SendMessage(new Data(token));
            rebels_response = rebelsSocket.ReadMessage(256);
            var nums = rebels_response.Str.Split(' ');
            cryptBFF.exponent = Int32.Parse(nums[0]);
            cryptBFF.modulus = Int32.Parse(nums[1]);

            return 0;

            //var data = new Data("Hi, my name is Vader");
            //CryptXOR.ToggleEncryption(data.Bytes, 30);
            //Console.WriteLine(data.Str);
            //Console.WriteLine(data.DecryptEmpire().Str);
            //Console.Read();
            //return 0;

            //var rebelsSocket = new RebelsSocket();

            //while (true)
            //{
            //    Console.WriteLine("What message do you want to send?");
            //    var message = Console.ReadLine();
            //    rebelsSocket.SendMessage(new Data(message));
            //    var response = rebelsSocket.ReadMessage(256);
            //    Console.WriteLine(String.Format("Received (bytes) << {0}", BitConverter.ToString(response.Bytes)));
            //    Console.WriteLine(String.Format("Received (string) << {0}", response.Str));
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
