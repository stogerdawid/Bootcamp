using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Lesson6.Actors;
using Lesson6.Messages;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInstructions();
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Lesson 6");

            using (var myActorSystem = ActorSystem.Create("MyActorSystem"))
            {

                //var consoleWriterActor = myActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()),"Writer");
                //var consoleReaderActor = myActorSystem.ActorOf(Props.Create(() => new ConsoleReaderActor(consoleWriterActor)), "Reader");

                Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
                IActorRef consoleWriterActor = myActorSystem.ActorOf(consoleWriterProps, "L6_Writer");

                //Props validationActorProps = Props.Create(() => new ValidationActor(consoleWriterActor));
                //IActorRef validationActor = myActorSystem.ActorOf(validationActorProps, "L4_Validator");

                Props tailCoordinatorProps = Props.Create(() => new TailCoordinatorActor());
                IActorRef tailCoordinatorActor = myActorSystem.ActorOf(tailCoordinatorProps, "tailCoordinatorActor");

                Props fileValidatorActorProps = Props.Create(() => new FileValidatorActor(consoleWriterActor));
                IActorRef fileValidatorActor = myActorSystem.ActorOf(fileValidatorActorProps, "validationActor");

                Props consoleReaderProps = Props.Create<ConsoleReaderActor>(/*fileValidatorActor*/);
                IActorRef consoleReaderActor = myActorSystem.ActorOf(consoleReaderProps, "L6_Reader");


                consoleReaderActor.Tell(new StartMsg());
                myActorSystem.WhenTerminated.Wait();
            }
            Console.ReadKey();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.Write("Some lines will appear as");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" red ");
            Console.ResetColor();
            Console.Write(" and others will appear as");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" green! ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }
    }
}
