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
        private const int max_message_size = 512;

        static int Main(string[] args)
        {
            Data empire_response, rebels_response;
            var empireSocket = new EmpireSocket(0xFFFF);
            var rebelsSocket = new RebelsSocket(0xFFFF);
            var cryptBFF = new CryptBFF();
            const String token = "1d0b1da2-0971-4236-9697-4f2a09588d6c";
            Console.WriteLine("Sending token " + token + " to Empire server");
            empireSocket.SendMessage(new Data(token));
            empire_response = empireSocket.ReadMessage();
            if (!empire_response.Str.Equals("User accepted."))
            {
                Console.WriteLine("Failed to communicate with the Empire server");
                return -1;
            }
            Console.WriteLine("Sending token " + token + " to Rebels server");
            rebelsSocket.SendMessage(new Data(token));
            rebels_response = rebelsSocket.ReadMessage();
            var nums = rebels_response.Str.Split(' ');
            cryptBFF.exponent = Int32.Parse(nums[0]);
            cryptBFF.modulus = Int32.Parse(nums[1]);
            var send_more = new Data("tell me more");
            var ok = new Data("OK");

            rebels_response = ok;
            while (rebels_response.Equals(ok))
            {
                empireSocket.SendMessage(send_more);
                empire_response = empireSocket.ReadMessage();
                if (empire_response.DecryptEmpire().HasCoordinates())
                {
                    Console.WriteLine(empire_response.Str);
                    rebelsSocket.SendMessage(cryptBFF.Encrypt(empire_response));
                    rebels_response = rebelsSocket.ReadMessage();
                }
            }

            empireSocket.SendMessage(new Data("stop"));
            rebelsSocket.Disconnect();

            Console.Read();

            return 0;
        }
    }
}
