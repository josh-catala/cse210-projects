using System;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// Guides the user through slow, paced breathing.
    /// Exceeds requirements: instead of a plain countdown, the "Breathe in"
    /// message grows a line of dots that expands quickly at first and then
    /// slows down as the breath nears its end, giving a more natural feel
    /// to the pacing of each breath.
    /// </summary>
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in " +
            "and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            bool breatheIn = true;
            while (!DurationElapsed())
            {
                Console.WriteLine();
                Console.Write(breatheIn ? "Breathe in..." : "Breathe out...");
                AnimatedBreathPause(4);
                Console.WriteLine();
                breatheIn = !breatheIn;
            }
        }

        /// <summary>
        /// Grows a row of dots that appear quickly at first and then slow
        /// down, simulating the feeling of a breath filling or releasing.
        /// </summary>
        private void AnimatedBreathPause(int seconds)
        {
            int totalTicks = 8;
            for (int i = 0; i < totalTicks; i++)
            {
                Console.Write(".");
                // Delay grows longer each tick, so dots appear fast then slow.
                int delay = (int)(seconds * 1000.0 / totalTicks) + (i * 40);
                Thread.Sleep(delay);
            }
        }
    }
}
