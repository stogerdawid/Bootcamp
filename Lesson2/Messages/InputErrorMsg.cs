using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Messages
{
    public interface IErrorMsg
    {
    }
    public class NullInputErrorMsg: ResponseMsg, IErrorMsg
    {
        public NullInputErrorMsg(string reason) : base(reason) { }
    }

    public class ValidationErrorMsg : ResponseMsg, IErrorMsg
    {
        public ValidationErrorMsg(string reason) : base(reason) { }
    }
}
