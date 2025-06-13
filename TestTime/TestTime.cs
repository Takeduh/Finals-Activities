using System;

namespace TestTime
{
    public struct Time
    {
        private readonly int minutes;

        public Time(int hh, int mm)
        {
            this.minutes = 60 * hh + mm;
        }

        public override String ToString()
        {
            // Format as HH:MM
            int hours = minutes / 60;
            int mins = minutes % 60;
            return $"{hours:D2}:{mins:D2}";
        }
    }

    class TestTime
    {
        static void Main(string[] args)
        {
            // Declare variables of type Time
            Time morning = new Time(10, 5);    // 10:05
            Time midnight = new Time(0, 45);   // 00:45

            // Print the Time values
            Console.WriteLine("Morning time: " + morning);
            Console.WriteLine("Midnight time: " + midnight);

            // If you want to keep the original functionality from the exercise
            // that just returns minutes, you could use this alternative struct:

            // Using the original Time struct from the exercise
            OriginalTime originalMorning = new OriginalTime(10, 5);
            Console.WriteLine("Original format (minutes only): " + originalMorning);
        }
    }

    // This is the original struct from the exercise description
    public struct OriginalTime
    {
        private readonly int minutes;

        public OriginalTime(int hh, int mm)
        {
            this.minutes = 60 * hh + mm;
        }

        public override String ToString()
        {
            return minutes.ToString();
        }
    }
}