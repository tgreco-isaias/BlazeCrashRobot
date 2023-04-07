using BlazeRobot.Request;
using BlazeRobot.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Interface
{
    public class InterfaceRound
    {
        private BaseRequest _baseRequest { get; set; }

        public InterfaceRound(BaseRequest baseRequest)
        {
            _baseRequest = baseRequest;
        }

        /// <summary>
        /// /crash/round/enter
        /// </summary>
        public RoundEnterResult Entrar(RoundRequestModel aposta)
        {
            return new RoundRequest(_baseRequest).Enter(aposta);
        }
    }
}
