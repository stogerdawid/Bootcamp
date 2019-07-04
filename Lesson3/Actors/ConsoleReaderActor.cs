using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson3.Messages;

namespace Lesson3.Actors
{
    public class ConsoleReaderActor : UntypedActor
    {
        protected readonly IActorRef _validatorActor;
        public ConsoleReaderActor(IActorRef writerActor)
        {
            _validatorActor = writerActor;
        }
        protected override void PreStart()
        {
            //Pass as an argument to constr
            // WriterActor = Context.ActorOf(Props.Create(() => new ConsoleWriterActor()), "Writer");
        }
        protected override void OnReceive(object message)
        {
            Console.WriteLine(" Received from: " + Context.Sender.Path.Name);
            if (message is StartMsg)
            {
                DoPrintInstructions();
            }


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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please provide a input");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                Context.System.Terminate();
                return;
            }

            _validatorActor.Tell(input);
        }
    }
}
