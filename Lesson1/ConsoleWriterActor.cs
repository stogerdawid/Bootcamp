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
            Console.WriteLine(message);
        }
    }
}
