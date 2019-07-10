using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartApp.Messages
{
    abstract public class WatchingMessage
    {
        public CounterType Counter { get; private set; }
        public WatchingMessage(CounterType counter)
        {
            Counter = counter;
        }
    }
    public class Watch : WatchingMessage
    {
        public Watch(CounterType counter) : base(counter) { }



    }

    public class Unwatch: WatchingMessage
    {
        public Unwatch(CounterType counter) : base(counter) { }
    }

}
