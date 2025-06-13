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

        // Read-only property Hour returning the number of hours
        public int Hour
        {
            get { return minutes / 60; }
        }

        // Read-only property Minute returning the number of minutes
        public int Minute
        {
            get { return minutes % 60; }
        }

        public override String ToString()
        {
            // Format as hh:mm with leading zeros using String.Format
            return String.Format("{0:D2}:{1:D2}", Hour, Minute);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables of type Time
            Time morning = new Time(10, 5);    // 10:05
            Time midnight = new Time(0, 45);   // 00:45
            Time evening = new Time(23, 45);   // 23:45

            // Print the Time values using the formatted ToString()
            Console.WriteLine("Morning time: " + morning);
            Console.WriteLine("Midnight time: " + midnight);
            Console.WriteLine("Evening time: " + evening);

            // Access and print Hour and Minute properties
            Console.WriteLine("Evening hour: " + evening.Hour);
            Console.WriteLine("Evening minute: " + evening.Minute);

            // Verify example from the requirements
            Console.WriteLine("For Time(23, 45), Minute is: " + evening.Minute);
        }

    }
}