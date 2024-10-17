using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HintServiceMeow.Core.Enum;
using HintServiceMeow.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using UnityEngine.Assertions.Must;

namespace ClassLibrary4.EventHandlers
{
    public static class Hints
    {

        internal static CoroutineHandle Coroutine;
        public static TimeSpan _oldRoundTime = Round.ElapsedTime;
        public static bool gecti;


        public static void SomeMethod()
        {
            Timing.RunCoroutine(MyCoroutine());
        }


        public static IEnumerator<float> MyCoroutine()
        {
            HintServiceMeow.Core.Models.Hints.Hint hint1 = new HintServiceMeow.Core.Models.Hints.Hint()
            {
                
            };
            hint1.YCoordinate = 20;
            hint1.Alignment = HintAlignment.Center;

            for (;;) 
            {

                foreach (Player player in Player.List)
                {
                    PlayerDisplay playerDisplay = PlayerDisplay.Get(player);
                    playerDisplay.AddHint(hint1);
                }

                    hint1.Text = FormatTime(Round.ElapsedTime);




                    yield return Timing.WaitForOneFrame;

            }


            
        }

        private static string FormatTime(TimeSpan time)
        {
            if (time.Minutes < 10 && time.Seconds < 10)
            {
                return $"0{time.Minutes}:0{time.Seconds}";
            }

            else if (time.Minutes < 10 && time.Seconds >= 10)
            {
                return $"0{time.Minutes}:{time.Seconds}";
            }

            else if (time.Minutes >= 10 && time.Seconds < 10)
            {
                return $"{time.Minutes}:0{time.Seconds}";
            }
            return $"{time.Minutes}:{time.Seconds}";

        }


    }
}
