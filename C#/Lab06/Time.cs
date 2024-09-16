using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_10_task
{
    internal class Time
    {
        #region Properties
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        #endregion

        #region Constructors
        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        #endregion

        #region Methods
        public void printTime()
            => Console.WriteLine($"Hours: {Hour} | Minutes: {Minute} | Seconds: {Second}");
        #endregion

        #region operator overload

        #region arthimitics
        public static Time operator + (Time t1, Time t2)
        {
            Time time = new Time();
            time.Hour = t1.Hour + t2.Hour;
            time.Minute = t1.Minute + t2.Minute;
            time.Second = t1.Second + t2.Second;
            return time;
        }
        public static Time operator - (Time t1, Time t2)
        {
            Time time = new Time();
            time.Hour = t1.Hour - t2.Hour;
            time.Minute = t1.Minute - t2.Minute;
            time.Second = t1.Second - t2.Second;
            return time;
        }
        public static Time operator ++ (Time time)
        {
            time.Hour++;
            time.Minute++;
            time.Second++;
            return time;
        }
        #endregion

        #region comparators
        public static bool operator > (Time t1, Time t2) => t1.Hour > t2.Hour;
        public static bool operator < (Time t1, Time t2) => t1.Hour < t2.Hour;
        public static bool operator >= (Time t1, Time t2) => t1.Hour >= t2.Hour;
        public static bool operator <= (Time t1, Time t2) => t1.Hour <= t2.Hour;
        #endregion

        #endregion

        #region casting
        public static explicit operator int(Time t) => t.Hour;
        public static implicit operator float(Time t) => t.Hour;
        public static implicit operator string(Time t) 
            => $"{t.Hour}:{t.Minute}:{t.Second}";
        #endregion
    }
}
