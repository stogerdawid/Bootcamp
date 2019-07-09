using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson6.Messages;

namespace Lesson6.Actors
{
    public class ConsoleReaderActor : UntypedActor
    {
        //protected readonly IActorRef _validatorActor;
        //public ConsoleReaderActor(IActorRef validationActor)
        //{
        //    _validatorActor = validationActor;
        //}
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
            Console.WriteLine("Please provide the URI of a log file on disk.\n");
            string input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                Context.System.Terminate();
                return;
            }
            Context.ActorSelection("akka://MyActorSystem/user/validationActor").Tell(input);
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

         //   _validatorActor.Tell(input);
        }
    }
}
