using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Messages
{
    public class InputSuccessMsg : ResponseMsg
    {
        public InputSuccessMsg(string reason) : base(reason)
        {
        }
    }
}
