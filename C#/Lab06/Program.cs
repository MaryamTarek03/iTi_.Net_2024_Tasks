namespace iTi_day_10_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time time;
            Time time1 = new Time(10, 15, 31);
            Time time2 = new Time(1, 20, 12);
            GenericClass<int> genericInt = new(5);
            GenericClass<string> genericString = new("Hello");
            InterfaceChild interfaceChild = new InterfaceChild();

            #region task 01
            Console.Write($"Time 01: ");
            time1.printTime(); 
            Console.Write($"Time 02: ");
            time2.printTime();
            Console.WriteLine();
            Console.WriteLine("Arithmetic");
            Console.WriteLine();
            Console.Write("Plus: ");
            time = time1 + time2;
            time.printTime();
            Console.Write("Minus: ");
            time = time1 - time2;
            time.printTime();
            Console.Write("Increment: ");
            time = time1++;
            time.printTime();
            Console.WriteLine();
            Console.WriteLine("Comparators");
            Console.WriteLine();
            Console.Write("More than? " + (time1 > time2));
            Console.WriteLine();
            Console.Write("Less than? " + (time1 < time2));
            Console.WriteLine();
            Console.Write("More than or equal? " + (time1 >= time2));
            Console.WriteLine();
            Console.Write("Less than or equal? " + (time1 <= time2));
            #endregion

            Console.WriteLine("\n------------------------------------------\n");

            #region task 02
            genericInt.Setter(15);
            Console.WriteLine($"Int Generic {genericInt.Getter()}");
            Console.WriteLine($"String Generic {genericString.Getter()}");
            #endregion

            Console.WriteLine("\n------------------------------------------\n");

            #region task 03
            interfaceChild.Interact();
            interfaceChild.Pick();
            Console.WriteLine();
            interfaceChild.SayHello();
            interfaceChild.SayBye();
            #endregion

        }
    }
}