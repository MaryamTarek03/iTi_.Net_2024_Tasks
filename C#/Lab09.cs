namespace iTi_day_13_lab
{
    internal class Program
    {
        public static void Divider() 
            => Console.WriteLine("\n--------------------------------\n");
        class Subject
        {
            public int Code { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = "Default";
            public string LastName { get; set; } = "Default";
            public Subject[] Subjects { get; set; } = new Subject[0];
        }
        static void Main(string[] args)
        {
            #region task #1
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            var firstQuery = numbers.OrderBy(x => x).Distinct();
            foreach (var number in firstQuery) Console.WriteLine(number);
            Console.WriteLine();
            foreach (var number in firstQuery) 
                Console.WriteLine($"{number} x {number} = {number * number}");
            #endregion

            Divider();

            #region task #2
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            var secondQueryMethod = names.Where(name => name.Length == 3);
            var secondQueryQuery = from name in names
                                   where name.Length == 3
                                   select name;
            foreach (var name in secondQueryQuery) Console.WriteLine(name);
            Console.WriteLine();

            var secondQueryMethod2 
                = names.Where(name => name.ToLower().Contains("a")).OrderBy(name => name.Length);
            var secondQueryQuery2 = from name in names
                                    where name.ToLower().Contains("a")
                                    orderby name.Length
                                    select name;
            foreach (var name in secondQueryQuery2) Console.WriteLine(name);
            Console.WriteLine();

            var secondQueryMethod3 = names.Take(2);
            var secondQueryQuery3 = (from name in names
                                    select name).Take(2);
            foreach (var name in secondQueryQuery3) Console.WriteLine(name);
            Console.WriteLine();
            #endregion

            Divider();

            #region task #3
            List<Student> students = new List<Student>()
            {
                new Student()
                { 
                    Id=1, FirstName="Ali", LastName="Mohammed", 
                    Subjects = new Subject[] 
                    { 
                        new Subject(){ Code=22,Name="EF"}, 
                        new Subject(){ Code=33,Name="UML"},
                    }
                },
                new Student()
                { 
                    Id=2, FirstName="Mona", LastName="Gala", 
                    Subjects=new Subject[]
                    {
                        new Subject(){ Code=22,Name="EF"}, 
                        new Subject (){ Code=34,Name="XML"},
                        new Subject (){ Code=25, Name="JS"},
                    }
                }, 
                new Student()
                { 
                    Id=3, FirstName="Yara", LastName="Youssef", 
                    Subjects=new Subject []
                    {
                        new Subject (){ Code=22,Name="EF"}, 
                        new Subject (){ Code=25,Name="JS"},
                    }
                },
                new Student()
                {
                    Id=1, FirstName="Ali", LastName="Ali", 
                    Subjects=new Subject[]
                    {
                        new Subject (){ Code=33,Name="UML"},
                    }
                },
            };

            var thirdQuery = students.Select(
                student => new 
                {
                    FullName = $"{student.FirstName} {student.LastName}", NoOfSubjects = $"{student.Subjects.Length}"
                });
            foreach (var student in thirdQuery) Console.WriteLine(student);
            Console.WriteLine();

            var thirdQuery2
                = students
                .OrderBy(student => student.LastName)
                .OrderByDescending(student => student.FirstName)
                .Select(student => new {student.FirstName, student.LastName});
            foreach ( var student in thirdQuery2) Console.WriteLine($"{student.FirstName} {student.LastName}");
            Console.WriteLine();

            var thirdQuery3
                = students
                .SelectMany(
                    student => student.Subjects,
                    (student, subject) => new
                    {
                        StudentName = $"{student.FirstName} {student.LastName}",
                        SubjectName = $"{subject.Name}"
                    });
            foreach (var student in thirdQuery3) Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine();
            var thirdQuery4
                = students
                .SelectMany(
                    student => student.Subjects,
                    (student, subject) => new
                    {
                        StudentName = $"{student.FirstName} {student.LastName}",
                        SubjectName = $"{subject.Name}"
                    })
                .GroupBy(student => student.StudentName);
            foreach (var group in thirdQuery4)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group) Console.WriteLine(student.SubjectName);
                Console.WriteLine();
            }
            #endregion
        }
    }
}