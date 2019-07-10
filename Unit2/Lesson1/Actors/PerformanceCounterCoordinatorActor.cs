using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Akka.Actor;
using ChartApp.Messages;
using Lesson4.Messages;

namespace ChartApp.Actors
{
    public class PerformanceCounterCoordinatorActor : ReceiveActor
    {
        private static readonly Dictionary<CounterType, Func<PerformanceCounter>> CounterGenerators =
           new Dictionary<CounterType, Func<PerformanceCounter>>()
       {
            {CounterType.Cpu, () => new PerformanceCounter("Processor",
                "% Processor Time", "_Total", true)},
            {CounterType.Memory, () => new PerformanceCounter("Memory",
                "% Committed Bytes In Use", true)},
            {CounterType.Disk, () => new PerformanceCounter("LogicalDisk",
                "% Disk Time", "_Total", true)},
       };


        private static readonly Dictionary<CounterType, Func<Series>> CounterSeries =
       new Dictionary<CounterType, Func<Series>>()
   {
            {CounterType.Cpu, () =>
            new Series(CounterType.Cpu.ToString()){
                 ChartType = SeriesChartType.SplineArea,
                 Color = Color.DarkGreen}},
            {CounterType.Memory, () =>
            new Series(CounterType.Memory.ToString()){
                ChartType = SeriesChartType.FastLine,
                Color = Color.MediumBlue}},
            {CounterType.Disk, () =>
            new Series(CounterType.Disk.ToString()){
                ChartType = SeriesChartType.SplineArea,
                Color = Color.DarkRed}},
   };

        private Dictionary<CounterType, IActorRef> _counterActors;

        private IActorRef _chartingActor;
        public PerformanceCounterCoordinatorActor(IActorRef chartingActor) :
                  this(chartingActor, new Dictionary<CounterType, IActorRef>())
        {
        }
        public PerformanceCounterCoordinatorActor(IActorRef chartingActor,
            Dictionary<CounterType, IActorRef> counterActors)
        {
            _chartingActor = chartingActor;
            _counterActors = counterActors;


            /* Register receivers*/

            Receive<Watch>(watch =>
            {
                if (!_counterActors.ContainsKey(watch.Counter))
                {
                    var counterActor = Context.ActorOf(Props.Create(() =>
                        new PerformanceCounterActor(watch.Counter.ToString(),
                                CounterGenerators[watch.Counter])));

                    _counterActors[watch.Counter] = counterActor;
                }

                // register this series with the ChartingActor
                _chartingActor.Tell(new AddSeriesMsg(
                    CounterSeries[watch.Counter]()));

                // tell the counter actor to begin publishing its
                // statistics to the _chartingActor
                _counterActors[watch.Counter].Tell(new SubscribeCounter(watch.Counter,
                    _chartingActor));
            });


            Receive<Unwatch>(unwatch =>
            {
                if (!_counterActors.ContainsKey(unwatch.Counter))
                {
                    return; // noop
                }

                // unsubscribe the ChartingActor from receiving any more updates
                _counterActors[unwatch.Counter].Tell(new UnsubscribeCounter(
                    unwatch.Counter, _chartingActor));

                // remove this series from the ChartingActor
                _chartingActor.Tell(new RemoveSeries(
                    unwatch.Counter.ToString()));
            });






        }
    }
}
