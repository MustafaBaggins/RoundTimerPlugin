using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.Handlers;
using Exiled.API.Features;
using player = Exiled.Events.Handlers.Player;
using Exiled.Loader;
using MEC;
namespace ClassLibrary4
{
    public class Class1 : Plugin<Config>
    {
        public static Class1 Instance;



        public override string Name { get; } = "Round Timer";
        public override string Author { get; } = "haci33";

        public override void OnEnabled()
        {
            Instance = this;
            EventHandlers.Hints.Coroutine = Timing.RunCoroutine(EventHandlers.Hints.MyCoroutine());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            EventHandlers.Hints.Coroutine = Timing.RunCoroutine(EventHandlers.Hints.MyCoroutine());
            base.OnDisabled();
        }
    }
}
