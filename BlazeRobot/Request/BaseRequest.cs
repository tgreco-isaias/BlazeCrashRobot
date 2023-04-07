using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Request
{
    public class BaseRequest
    {
        /// <summary>
        /// Sessão do usúario
        /// </summary>
        internal CookieContainer _session { get; set; }

        /// <summary>
        /// Endereço Url do Legado
        /// </summary>
        internal string _urlBase { get; set; } = "https://blaze.com/api";

        internal string _sessionToken { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public BaseRequest()
        {
            AllowSecurityProtocol();
            _session = new CookieContainer();
        }

        /// <summary>
        /// Construtor que mantém sessão anterior
        /// </summary>
        public BaseRequest(BaseRequest requestBase)
        {
            AllowSecurityProtocol();

            //Sessão
            _session = requestBase._session;
            _sessionToken = requestBase._sessionToken;
            _urlBase = requestBase._urlBase;
        }

        /// <summary>
        /// Lê uma resposta e a transforma em uma string
        /// </summary>
        /// <param name="response">HttpResponse</param>
        /// <returns>Resposta no formato string</returns>
        internal string ReadResponse(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                Stream streamToRead = responseStream;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    if (streamToRead != null) streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    if (streamToRead != null) streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                }

                if (streamToRead != null)
                    using (StreamReader streamReader = new StreamReader(streamToRead, Encoding.UTF8))
                    {
                        return streamReader.ReadToEnd();
                    }
            }
            return null;
        }

        /// <summary>
        /// Aceita certificados e Protocolos de Segurança
        /// </summary>
        private void AllowSecurityProtocol()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            //Aceita certificados
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptCertificate;
        }

        /// <summary>
        /// Aceita certificados
        /// </summary>
        /// <returns></returns>
        private bool AcceptCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors err) { return true; }

    }

}
