using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson5.Messages;

namespace Lesson5.Actors
{
    public class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {


            if (message is NullInputErrorMsg nmsg)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(nmsg.Reason);
            }
            else if (message is ValidationErrorMsg vmsg)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(vmsg.Reason);
            }
            else if (message is InputSuccessMsg smsg)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(smsg.Reason);
                if (smsg.Message != null)
                {
                    var reverse = smsg.Message.ToString().Reverse().ToArray();
                    var revertedMsg = new string(reverse);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(revertedMsg);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" Received from: " + Context.Sender.Path.Name);
                    Console.WriteLine(" Received by: " + Context.Self.Path.Name);
                }
            }
            else if (message is string)
            {
                Console.WriteLine(message);
            }
            Console.ResetColor();

        }
    }
}
