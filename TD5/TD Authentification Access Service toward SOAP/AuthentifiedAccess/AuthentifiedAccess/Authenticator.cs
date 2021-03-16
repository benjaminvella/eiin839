using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AuthentifiedAccess
{
    class Authenticator
    {
        private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        public Authenticator()
        {
            string[] logins = File.ReadAllLines(@"..\..\..\passwd.csv");
            foreach (string login in logins)
            {
                string[] parts = login.Split(';');
                Credentials.Add(parts[0].Trim(), parts[1].Trim());
            }
        }
        public bool ValidateCredentials(string username, string password)
        {
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
}
