using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentifiedAccess
{
    class Program
    {
        static private Authenticator auth = new Authenticator();
        static void Main(string[] args)
        {

            
            Console.WriteLine("Enter username : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();

            bool isvalid = auth.ValidateCredentials(username, password);
            if(isvalid)
            {
                Console.WriteLine("Your are authenticated!");
                Console.WriteLine("enter a city name:");
                string city = Console.ReadLine();
                ServiceAccess srv = new ServiceAccess();
                srv.Weather(city);

            } 
            else
                Console.WriteLine("Your are NOT authenticated!");
            Console.ReadLine();     
        }
    }
}
