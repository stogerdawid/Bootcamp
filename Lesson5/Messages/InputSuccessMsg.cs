using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Messages
{
    public class InputSuccessMsg : ResponseMsg
    {
        public string Message { get; private set; }
        public InputSuccessMsg(string reason, string message) : base(reason)
        {
            Message = message;
        }

        public InputSuccessMsg(string reason) : base(reason)
        {
        }
    }
}
