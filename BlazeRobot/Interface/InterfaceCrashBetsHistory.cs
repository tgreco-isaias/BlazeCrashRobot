using BlazeRobot.Request;
using BlazeRobot.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Interface
{
    public class InterfaceCrashBetsHistory
    {
        private BaseRequest _baseRequest { get; set; }

        public InterfaceCrashBetsHistory(BaseRequest baseRequest)
        {
            _baseRequest = baseRequest;
        }

        /// <summary>
        /// /crash_bets?page=1
        /// </summary>
        public CrashBetsResult GetHistory(int? page = 1)
        {
            return new CrashHistoryUserRequest(_baseRequest).GetHistory(page.Value);
        }
    }
}
