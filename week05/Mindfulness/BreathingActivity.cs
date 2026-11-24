
using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Stopwatch stopwatch = Stopwatch.StartNew();

        bool breathingIn = true;

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            if (breathingIn)
            {
                Console.WriteLine();
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Breathe out...");
            }

            int remaining = Duration -
                (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);

            int phaseDuration = Math.Min(4, remaining);

            ShowCountDown(phaseDuration);

            breathingIn = !breathingIn;
        }

        stopwatch.Stop();

        DisplayEndingMessage();
    }
}
