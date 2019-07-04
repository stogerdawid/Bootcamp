using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Lesson1
{
    public class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var msg = message as string;
            if (msg != null)
            {

                var reverse = msg.Reverse().ToArray();
                var revertedMsg = new string(reverse);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(revertedMsg);
                Console.ResetColor();
            }
        }
    }
}
