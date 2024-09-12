namespace iTi_day_08
{
    internal class Program
    {
        class Calculation
        {
            #region Sum overloading
            public int sum(int x, int y) { return x + y; }
            public float sum(float x, float y) { return x + y; }
            public double sum(double x, double y) { return x + y; }
            #endregion

            #region Division overloading
            public int division(int x, int y) { return y > 0 ? (int)(x / y) : 0; }
            public float division(float x, float y) { return y > 0 ? (float)(x / y) : 0; }
            public double division(double x, double y) { return y > 0 ? (double)(x / y) : 0; }
            #endregion
        }

        class Student
        {
            #region Attributes
            int id;
            int age;
            string name;
            #endregion

            #region Constructors
            public Student(int id, int age, string name)
            {
                this.id = id;
                this.age = age;
                this.name = name;
            }

            public Student() : this(0, 0, "Default Name") { }
            public Student(int id) : this(id, 0, "Default Name") { }
            public Student(int id, int age) : this(id, age, "Default Name") { }
            #endregion

            #region Properties
            public int Id
            { 
                get { return id; }
                set { id = value; }
            }
            
            public int Age
            {
                get { return age; }
                set { age = value > 0 ? value : 0; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion

            #region Methods
            public void PrintStudent() { Console.WriteLine($"ID: {id} | Age: {age} | Name: {name}"); }
            #endregion

        }
        static void Main(string[] args)
        {
            #region First
            Calculation calculation = new Calculation();
            Console.WriteLine("-----------------------------First-----------------------------");
            Console.WriteLine($"Int sum: 5 + 13 = {calculation.sum(5, 13)}");
            Console.WriteLine($"Float sum: 5 + 13.7 = {calculation.sum(5.0f, 13.7f)}");
            Console.WriteLine($"Double sum: 5 + 13.7 = {calculation.sum(5.0, 13.7)}");
            #endregion

            #region Second
            Console.WriteLine("\n-----------------------------Second----------------------------");
            Student student01 = new Student();
            Student student02 = new Student(25);
            Student student03 = new Student(16, 21);
            Student student04 = new Student(17, 20, "Maryam");

            student01.PrintStudent();
            student02.PrintStudent();
            student03.PrintStudent();
            student04.PrintStudent();
            #endregion

            #region Third
            Console.WriteLine("\n-----------------------------Third-----------------------------");

            Console.Write("Please enter number of students: ");
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Student[] students = new Student[studentsNumber];

            Console.WriteLine("Please enter students data \n\n");
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();
                Console.Write($"Student {i + 1} ID: ");
                students[i].Id = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Student {i + 1} age: ");
                students[i].Age = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Student {i + 1} name: ");
                students[i].Name = Console.ReadLine();

                Console.WriteLine();
            }
            Console.WriteLine("\n-------------------------StudentsData--------------------------");

            for(int i = 0;i < students.Length;i++) { students[i].PrintStudent();}
            #endregion
        }
    }
}