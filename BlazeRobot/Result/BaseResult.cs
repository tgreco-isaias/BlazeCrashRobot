using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Result
{
    public class BaseResult
    {
        /// <summary>
        /// Define se o Robo fez oque deveria, ou seja se não ocorreu nenhuma exceção de código o resultado deverá ser TRUE.
        /// </summary>
        public bool ProcessOK { get; set; }

        /// <summary>
        /// Exceção de código
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Mesagem de Erro do processo
        /// </summary>
        public string MsgErro { get; set; }
    }
}
