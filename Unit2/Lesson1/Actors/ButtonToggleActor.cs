using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Akka.Actor;
using ChartApp.Messages;

namespace ChartApp.Actors
{
    public class ButtonToggleActor : UntypedActor
    {

        private readonly CounterType _myCounterType;
        private bool _isToggledOn;
        private readonly Button _myButton;
        private readonly IActorRef _coordinatorActor;

        Dictionary<bool, Func<CounterType,WatchingMessage>> operation =
            new Dictionary<bool, Func<CounterType, WatchingMessage>>()
            {
                [false] = (counterType) => new Unwatch(counterType),
                [true] = (counterType) => new Watch(counterType),
            };
        public ButtonToggleActor(IActorRef coordinatorActor, Button myButton,
                CounterType myCounterType, bool isToggledOn = false)
        {
            _coordinatorActor = coordinatorActor;
            _myButton = myButton;
            _isToggledOn = isToggledOn;
            _myCounterType = myCounterType;
        }
        protected override void OnReceive(object message)
        {
           if(message is ToggleMessage)
            {


             var msg =    operation[_isToggledOn](_myCounterType);
            _coordinatorActor.Tell(msg);
                FlipToggle();
            }
            else
            {
                Unhandled(message);
            }
        }
        private void FlipToggle()
        {
            // flip the toggle
            _isToggledOn = !_isToggledOn;

            // change the text of the button
            _myButton.Text = string.Format("{0} ({1})",
                _myCounterType.ToString().ToUpperInvariant(),
                _isToggledOn ? "ON" : "OFF");
        }
    }
}
