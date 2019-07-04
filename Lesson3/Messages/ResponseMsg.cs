using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Messages
{
    public abstract class ResponseMsg
    {
        public ResponseMsg(string reason)
        {
            Reason = reason;
        }
        public string Reason { get; private set; }
    }
}
