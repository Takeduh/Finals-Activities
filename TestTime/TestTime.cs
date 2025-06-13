using System;
using TestTime;

namespace TestTime
{
    public struct Time
    {
        private readonly int minutes;

        public Time(int hh, int mm)
        {
            this.minutes = 60 * hh + mm;
        }
        
        public Time(int totalMinutes)
        {
            this.minutes = totalMinutes % (24 * 60);

            while (this.minutes < 0)
            {
                this.minutes += 24 * 60;
            }
        }

        public int Hour
        {
            get { return minutes / 60; }
        }

        public int Minute
        {
            get { return minutes % 60; }
        }

        public static Time operator +(Time t1, Time t2)
        {
            return new Time(t1.minutes + t2.minutes);
        }

        public static Time operator -(Time t1, Time t2)
        {
            return new Time(t1.minutes - t2.minutes);
        }

        // Implicit conversion from int (minutes since midnight) to Time
        public static implicit operator Time(int minutes)
        {
            return new Time(minutes);
        }

        // Explicit conversion from Time to int (minutes since midnight)
        public static explicit operator int(Time time)
        {
            return time.minutes;
        }

        public override String ToString()
        {
            return String.Format("{0:D2}:{1:D2}", Hour, Minute);
        }
    }
}


    class Program
{
    static void Main(string[] args)
    {
        Time morning = new Time(10, 5);
        Time midday = new Time(12, 0);
        Time evening = new Time(23, 45);

        Console.WriteLine("Morning time: " + morning);
        Console.WriteLine("Midday time: " + midday);
        Console.WriteLine("Evening time: " + evening);

        Time sum = morning + midday;
        Console.WriteLine($"{morning} + {midday} = {sum}");

        Time difference = evening - morning;
        Console.WriteLine($"{evening} - {morning} = {difference}");

        // Using the implicit conversion from int to Time
        int lunchTimeMinutes = 720;
        Time lunch = lunchTimeMinutes;
        Console.WriteLine($"Implicit conversion from {lunchTimeMinutes} minutes to Time: {lunch}");

        // Using the explicit conversion from Time to int
        int morningMinutes = (int)morning;
        Console.WriteLine($"Explicit conversion from Time {morning} to minutes: {morningMinutes}");

        // Using conversions in calculations
        Time breakTime = 570;
        int minutesWorked = (int)(morning - breakTime);
        Console.WriteLine($"Minutes worked from {breakTime} to {morning}: {minutesWorked}");

        Time t1 = 505;
        Console.WriteLine($"Time t1 from 505 minutes: {t1}");

        int t2Minutes = (int)t1;
        Console.WriteLine($"Minutes in t1: {t2Minutes}");
    }
}