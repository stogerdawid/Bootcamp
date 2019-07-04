using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Lesson1
{
    public class ConsoleReaderActor : UntypedActor
    {
        IActorRef WriterActor;
        protected override void PreStart()
        {
            WriterActor = Context.ActorOf(Props.Create(() => new ConsoleWriterActor()));
        }
        protected override void OnReceive(object message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please provide a input");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                Context.System.Terminate();
            }
            else if (message.Equals("Start") || message.Equals("Continue"))
            {
                WriterActor.Tell(input);
                Self.Tell("Continue");
            }
            Console.ResetColor();
        }
    }
}
