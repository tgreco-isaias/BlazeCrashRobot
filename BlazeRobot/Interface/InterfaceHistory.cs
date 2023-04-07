using BlazeRobot.Request;
using BlazeRobot.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Interface
{
    public class InterfaceHistory
    {
        private BaseRequest _baseRequest { get; set; }

        public InterfaceHistory(BaseRequest baseRequest)
        {
            _baseRequest = baseRequest;
        }

        /// <summary>
        /// /users/me
        /// </summary>
        public HistoryResult GetHistory(DateTime? dataInicio = null, DateTime? dataFim = null, int? page = 1)
        {
            if(!dataInicio.HasValue || !dataFim.HasValue)
            {
                dataInicio = DateTime.Now.AddMonths(-1);
                dataFim = DateTime.Now.AddHours(3);
            }

            return new HistoryRequest(_baseRequest).GetHistory(dataInicio.Value, dataFim.Value, page.Value);
        }
    }
}
