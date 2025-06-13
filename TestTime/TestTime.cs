using System;

namespace TestTime
{
    public struct Time
    {
        private readonly int minutes;

        // Constructor with hours and minutes
        public Time(int hh, int mm)
        {
            this.minutes = 60 * hh + mm;
        }

        // Additional constructor that takes total minutes
        public Time(int totalMinutes)
        {
            // Ensure we wrap around for times exceeding 24 hours
            this.minutes = totalMinutes % (24 * 60);

            // Handle negative times by adding 24 hours until positive
            while (this.minutes < 0)
            {
                this.minutes += 24 * 60;
            }
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

        // Overload + operator to add two Time values
        public static Time operator +(Time t1, Time t2)
        {
            return new Time(t1.minutes + t2.minutes);
        }

        // Overload - operator to subtract two Time values
        public static Time operator -(Time t1, Time t2)
        {
            return new Time(t1.minutes - t2.minutes);
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
            Time midday = new Time(12, 0);     // 12:00
            Time evening = new Time(23, 45);   // 23:45

            // Print the Time values
            Console.WriteLine("Morning time: " + morning);
            Console.WriteLine("Midday time: " + midday);
            Console.WriteLine("Evening time: " + evening);

            // Use the overloaded + operator
            Time sum = morning + midday;
            Console.WriteLine($"{morning} + {midday} = {sum}");  // Should be 22:05

            // Use the overloaded - operator
            Time difference = evening - morning;
            Console.WriteLine($"{evening} - {morning} = {difference}");  // Should be 13:40

            // Demonstrate time wrapping around
            Time lateNight = new Time(23, 30);
            Time hourAndHalf = new Time(1, 30);
            Time wrappedTime = lateNight + hourAndHalf;
            Console.WriteLine($"{lateNight} + {hourAndHalf} = {wrappedTime}");  // Should be 01:00

            // Use the Time(int) constructor
            Time fromMinutes = new Time(505);  // 8:25
            Console.WriteLine("Time from 505 minutes: " + fromMinutes);

            // Demonstrate negative time handling
            Time negativeResult = morning - evening;
            Console.WriteLine($"{morning} - {evening} = {negativeResult}");  // Should wrap around
        }
    }

}