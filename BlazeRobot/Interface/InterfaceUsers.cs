using BlazeRobot.Request;
using BlazeRobot.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Interface
{
    public class InterfaceUsers
    {
        private BaseRequest _baseRequest { get; set; }

        public InterfaceUsers(BaseRequest baseRequest)
        {
            _baseRequest = baseRequest;
        }

        /// <summary>
        /// /users/me
        /// </summary>
        public GetCurrentUserResult GetCurrentUser()
        {
            return new UsersRequest(_baseRequest).GetCurrentUser();
        }
    }
}
