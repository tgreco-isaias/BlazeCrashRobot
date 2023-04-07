using BlazeRobot.Request;
using BlazeRobot.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Interface
{
    public class InterfaceWallets
    {
        private BaseRequest _baseRequest { get; set; }

        public InterfaceWallets(BaseRequest baseRequest)
        {
            _baseRequest = baseRequest;
        }

        /// <summary>
        /// /users/me
        /// </summary>
        public WalletResult GetWallet()
        {
            return new WalletRequest(_baseRequest).GetWallet();
        }
    }
}
