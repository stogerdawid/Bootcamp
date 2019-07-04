using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson2.Messages;

namespace Lesson2
{
    public class ConsoleReaderActor : UntypedActor
    {
        protected readonly IActorRef _writerActor;
        public ConsoleReaderActor(IActorRef writerActor)
        {
            _writerActor = writerActor;
        }
        protected override void PreStart()
        {
            //Pass as an argument to constr
           // WriterActor = Context.ActorOf(Props.Create(() => new ConsoleWriterActor()), "Writer");
        }
        protected override void OnReceive(object message)
        {
            if (message is StartMsg)
            {
                DoPrintInstructions();
            }
            else if (message is IErrorMsg)
            {
                _writerActor.Tell(message as IErrorMsg);
            }


            Console.WriteLine(" Received from: " + Context.Sender.Path.Name);
            //Received form DeadLetters

            GetAndValidateInput();
        }

        private static bool IsValid(string message)
        {
            var valid = message.Length % 2 == 0;
            return valid;
        }

        private void DoPrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.WriteLine("Some entries will pass validation, and some won't...\n\n");
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }

        private void GetAndValidateInput()
        {
            ResponseMsg responseMsg = null;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please provide a input");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                Context.System.Terminate();
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                responseMsg = new NullInputErrorMsg("empty input");
            }
            else if (!IsValid(input))
            {
                responseMsg = new ValidationErrorMsg("Invalid: input odd number of characters.");
            }
            else
            {
                responseMsg = new InputSuccessMsg("Thank You message Valid");
                _writerActor.Tell(responseMsg);
                Context.Self.Tell(new ContinueMsg());
                return;
            }
            Context.Self.Tell(responseMsg);
        }



        #region internal messages
        class ContinueMsg
        {
            public ContinueMsg()
            {
            }
        }
        #endregion
    }
}
