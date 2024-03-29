﻿using System;
using System.Windows.Forms;
using Akka.Actor;
using Akka.Configuration;
using ChartApp.Actors;

namespace ChartApp
{
    static class Program
    {
        /// <summary>
        /// ActorSystem we'll be using to publish data to charts
        /// and subscribe from performance counters
        /// </summary>
        public static ActorSystem ChartActors;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var configuration = ConfigurationFactory.Load();


            ChartActors = ActorSystem.Create("ChartActors");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
