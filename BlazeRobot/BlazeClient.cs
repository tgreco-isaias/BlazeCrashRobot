using BlazeRobot.Interface;
using BlazeRobot.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot
{
    public class BlazeClient
    {
        private BaseRequest _baseRequest { get; set; }
        public InterfaceUsers Users { get; set; }
        public InterfaceWallets Wallets { get; set; }
        public InterfaceRound Round { get; set; }
        public InterfaceHistory History { get; set; }
        public InterfaceCrashBetsHistory UserHistory { get; set; }

        public BlazeClient(string acessToken)
        {
            _baseRequest = new BaseRequest()
            {
                _sessionToken = acessToken
            };

            Users = new InterfaceUsers(_baseRequest);
            Wallets = new InterfaceWallets(_baseRequest);
            Round = new InterfaceRound(_baseRequest);
            History = new InterfaceHistory(_baseRequest);
            UserHistory = new InterfaceCrashBetsHistory(_baseRequest);
        }

    }
}
