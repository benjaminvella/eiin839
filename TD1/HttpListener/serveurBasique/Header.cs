using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace serveurBasique
{
    class Header
    {
        HttpListenerRequest request;
        public Header(HttpListenerRequest request)
        {
            this.request = request;
        }

        public string printUsefulHeaders()
        {
            string response = "MIME acceptés : "
                              + this.request.Headers[HttpRequestHeader.Accept.ToString()]
                              + "\nles jeux de caractères admis : "
                              + this.request.Headers[HttpRequestHeader.AcceptCharset.ToString()]
                              + "\nles encodages de contenu admis : "
                              + this.request.Headers[HttpRequestHeader.AcceptEncoding.ToString()]
                              + "\nles langages naturels préférés : "
                              + this.request.Headers[HttpRequestHeader.AcceptLanguage.ToString()]
                              + "\nle jeu de méthodes HTTP : "
                              + this.request.Headers[HttpRequestHeader.Allow.ToString()]
                              + "\nles informations d’identification que le client doit présenter pour s’authentifier auprès du serveur : "
                              + this.request.Headers[HttpRequestHeader.Authorization.ToString()]
                              + "\nles données de cookie présentées au serveur : "
                              + this.request.Headers[HttpRequestHeader.Cookie.ToString()]
                              + "\nl’adresse e-mail Internet pour l’utilisateur humain qui contrôle l’agent utilisateur demandeur : "
                              + this.request.Headers[HttpRequestHeader.From.ToString()]
                              + "\nles informations relatives à l’agent client : "
                              + this.request.Headers[HttpRequestHeader.UserAgent.ToString()]+"\n";

            return response;
        }
    }
}
