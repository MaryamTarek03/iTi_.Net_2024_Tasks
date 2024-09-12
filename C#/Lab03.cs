internal class Program
    {
        public class Lab03
        {
            struct Time 
            {
                #region Attributes
                int hour;
                int minute;
                int second;
                #endregion

                #region Setters
                // Setters
                public void setHour(int h) 
                {
                    if (h < 0 || h >= 24) { hour = 0; }
                    else hour = h;
                }
                public void setMinute(int m) 
                {
                    if (m < 0 || m >= 60) { minute = 0; }
                    else minute = m;
                }
                public void setSecond(int s) 
                {
                    if (s < 0 || s >= 60) { second = 0; }
                    else second = s;
                }
                #endregion

                #region Getters
                // Getters
                public int getHour() { return hour; }
                public int getMinute() { return minute; }
                public int getSecond() { return second; }
                #endregion

                #region Properties
                // Properties
                public int Hour
                {
                    get { return hour; }
                    set 
                    {
                        if (value < 0 || value >= 24) { hour = 0; }
                        else hour = value; 
                    }
                }
                public int Minute
                {
                    get { return minute; }
                    set 
                    {
                        if (value < 0 || value >= 60) { minute = 0; }
                        else minute = value; 
                    }
                }
                public int Second
                {
                    get { return second; }
                    set 
                    {
                        if (value < 0 || value >= 60) { second = 0; }
                        else second = value; 
                    }
                }
                #endregion

                #region Constructors
                public Time()
                {
                    hour = 0;
                    minute = 0;
                    second = 0;
                }
                public Time (int hour, int minute, int second)
                {
                    this.hour = hour;
                    this.minute = minute;
                    this.second = second;
                }
                #endregion

                #region Methods
                public void printTime() 
                { Console.WriteLine($"Hours: {hour} | Minutes: {minute} | Seconds: {second}"); }
                #endregion
            }
            static void Main(string[] args)
            {

                #region Manual Time Object
                Time time = new Time();
                time.Hour = 15;
                time.Minute = 36;
                time.Second = 19;
                time.printTime();
                Console.WriteLine("-------------------------------------------\n");
                #endregion

                #region User Time array
                Console.Write("Please enter time array size: ");
                int numberOfTimes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Time[] times = new Time[numberOfTimes];
                for (int i = 0; i < times.Length; i++)
                {
                    Console.WriteLine($"Please enter time number {i + 1}: \n");

                    // input hours
                    Console.Write("Please enter number of hours: ");
                    int hours = Convert.ToInt32(Console.ReadLine());

                    // input minutes
                    Console.Write("Please enter number of minutes: ");
                    int minutes = Convert.ToInt32(Console.ReadLine());

                    // input seconds
                    Console.Write("Please enter number of seconds: ");
                    int seconds = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    // assign values
                    times[i].Hour = hours;
                    times[i].Minute = minutes;
                    times[i].Second = seconds;
                }

                Console.WriteLine("Time array items: \n");
                for (int i = 0; i < times.Length; i++) { times[i].printTime(); }
                #endregion
            }
        }
    }