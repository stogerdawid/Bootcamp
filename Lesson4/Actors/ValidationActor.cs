using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson4.Messages;

namespace Lesson4.Actors
{
    public class ValidationActor : UntypedActor
    {
        private readonly IActorRef _writerActor;

        public ValidationActor(IActorRef consoleWriterActor)
        {
            _writerActor = consoleWriterActor;
        }
        protected override void OnReceive(object message)
        {
            string input = message as string;
            ResponseMsg responseMsg = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                responseMsg = new NullInputErrorMsg("empty input");
            }
            else if (!IsValid(input))
            {
                responseMsg = new ValidationErrorMsg("Invalid: input odd number of characters.");
            }
            else
            {
                responseMsg = new InputSuccessMsg("Thank You message Valid", input);
            }
            _writerActor.Tell(responseMsg);
            Context.Sender.Tell(new ContinueMsg());
        }
        private static bool IsValid(string message)
        {
            var valid = message.Length % 2 == 0;
            return valid;
        }
        class ContinueMsg
        {
            public ContinueMsg()
            {
            }
        }
    }
}
