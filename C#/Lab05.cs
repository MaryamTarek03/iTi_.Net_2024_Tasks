namespace iTi_day_09_task
{
    #region Task 01: Question Abstract
    abstract class Question
    {
        public int mark { get; set; }
        public string? header { get; set; } = "No header";
        public string? content { get; set; } = "No content";

        public abstract void display();
    }

    class MCQ : Question
    {
        public override void display() 
            => Console.WriteLine($"This is an MCQ question: Header: {header}, Content: {content}, Mark: {mark}");
    }
    class TrueFalse : Question
    {
        public override void display() 
            => Console.WriteLine($"This is a true & false question: {header}, Content: {content}, Mark: {mark}");
    }
    class Complete : Question
    {
        public override void display() 
            => Console.WriteLine($"This is a complete question: {header}, Content: {content}, Mark: {mark}");
    }
    #endregion

    #region Task 2 Parent & Inheritance
    class Parent
    {
        public string? name { get; set; }
        public int age { get; set; }

        public void display() => Console.WriteLine($"This is the parent {name}");
        public virtual void smile() => Console.WriteLine("The parent is smiling");
    }

    class Child : Parent
    {
        public string? parentName { get; set; }

        public new void display() => Console.WriteLine($"This is the child {name} whose parent is {parentName}");
        public override void smile() => Console.WriteLine("The child is smiling");
    }

    class SubChild : Child
    {
        public new void display() => Console.WriteLine($"This is an abomination for the child {name} whose parent is {parentName}");
        public override void smile() => Console.WriteLine("The abomination is smiling");
    }
    #endregion

    #region Task 03: Static class Calculation
    static class Calculation
    {
        public static int sum(int x, int y) => x + y;
        public static int subtract(int  x, int y) => x - y;
        public static int multiply(int x, int y) => x * y;
        public static int division(int x, int y) => (y > 0) ? x / y : 0;
    }
    #endregion

    #region Task 04: Sealed class
    sealed class SealedClass
    {
        public int value { get; set; }
        public void display() => Console.WriteLine(value);
    }

    // cannot inherit
    // class SealedClassChild : SealedClass { }
    #endregion

    #region Task 05: Student class
    class Student
    {
        static int studentCount;
        public int studentID { get; set; }
        public string? name { get; set; } = "No name";
        public int age { get; set; }

        static Student() => studentCount = 0;

        public Student(string? name, int age)
        {
            studentCount++;
            studentID = studentCount;
            this.name = name;
            this.age = age;
        }
        public Student() : this("No name", 0) {}

        public void printData() => Console.WriteLine($"ID: {studentID}, Name: {name}, Age: {age}");
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 01
            MCQ mCQ = new MCQ();
            mCQ.header = "Choose the correct answer";
            mCQ.content = "Imagine a question";
            mCQ.mark = 5;
            mCQ.display();

            TrueFalse trueFalse = new TrueFalse();
            trueFalse.display();
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Task 02
            Console.WriteLine("Test 01: parent that has a parent reference (parent = new Parent())");
            Parent parent = new Parent();
            parent.display();
            parent.smile();
            Console.WriteLine();

            Console.WriteLine("Test 02: parent that has a child reference (parent = new Child())");
            Parent parent1 = new Child();
            parent1.display();
            parent1.smile();
            Console.WriteLine();

            Console.WriteLine("Test 03: parent that has a sub_child reference (parent = new SubChild())");
            Parent parent2 = new Child();
            parent2.display();
            parent2.smile(); // child smile
            Console.WriteLine();
            
            Console.WriteLine("Test 04: child that has a child reference (child = new Child())");
            Child child = new Child();
            child.display();
            child.smile(); // child smile
            Console.WriteLine();
            
            Console.WriteLine("Test 05: child that has a sub_child reference (child = new SubChild())");
            Child child1 = new SubChild();
            child1.display(); // child display
            child1.smile(); // sub_child smile
            Console.WriteLine();
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Task 03
            Console.WriteLine($"15 + 30 = {Calculation.sum(15, 30)}");
            Console.WriteLine($"15 - 30 = {Calculation.subtract(15, 30)}");
            Console.WriteLine($"15 x 30 = {Calculation.multiply(15, 30)}");
            Console.WriteLine($"30 / 15 = {Calculation.division(30, 15)}");
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Task 04
            SealedClass sealedClass = new SealedClass();
            sealedClass.value = 10;
            Console.WriteLine(sealedClass.value);
            #endregion

            Console.WriteLine("-------------------------------------------");

            #region Task 05
            Console.Write("Please enter number of students: ");
            int studentsNumber = Convert.ToInt32(Console.ReadLine());

            Student[] students = new Student[studentsNumber];

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();

                Console.Write("Please enter student name: ");
                students[i].name = Console.ReadLine();

                Console.Write("Please enter student age: ");
                students[i].age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }

            for (int i = 0; i < students.Length; i++) { students[i].printData(); }
            #endregion
        }
    }
}