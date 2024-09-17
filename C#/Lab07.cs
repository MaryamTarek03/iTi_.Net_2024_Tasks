namespace iTi_day_11_task
{
    internal class Program
    {
        public delegate int UserDelegate(int i);
        public delegate void MultiDelegate(string s);
        public delegate RType GenericDelegate<RType, FirstType, SecondType>(FirstType x, SecondType y);

        delegate void ScoreDelegate(Player player);

        #region event
        class Player
        {
            public int id { get; set; }
            public int score { get; set; }
            public string name { get; set; }

            public Player (int id, int score, string name)
            {
                this.id = id;
                this.score = score;
                this.name = name;
            }

            public event ScoreDelegate? Score;
            public void OnScore() { if (Score != null) Score(this); }
        }

        class ScoreBoard
        {
            public int score { get; set; }
            public ScoreBoard (int score) => this.score = score;
            public void Score(Player player)
            {
                player.score++;
                Console.WriteLine($"The player {player.name} score is {player.score}");
            }  
        }
        #endregion

        static void Main(string[] args)
        {
            #region user-defined delegate
            UserDelegate userDelegate = (int i) => i * i;
            Console.WriteLine(userDelegate(5));
            #endregion

            Console.WriteLine("\n-------------------------------------------\n");

            #region generic delegate
            GenericDelegate<int, int, int> genericDelegate = (int x, int y)
                => x * y;
            GenericDelegate<string, string, string> genericDelegate1 = (string firstName, string lastName)
                => $"your name is: {firstName} {lastName}";

            Console.WriteLine($"The delegate of return type int");
            Console.WriteLine(genericDelegate(3, 5)); 
            Console.WriteLine($"The delegate of return type string");
            Console.WriteLine(genericDelegate1("Maryam", "Tarek"));
            #endregion

            Console.WriteLine("\n-------------------------------------------\n");

            #region multicast & anonymous delegate
            MultiDelegate multiDelegate = (string name) => Console.WriteLine($"Hello {name}");
            multiDelegate += (string name) => Console.WriteLine($"Goodbye {name}");

            multiDelegate("Maryam");
            #endregion

            Console.WriteLine("\n-------------------------------------------\n");

            #region built-in delegate
            Func<int, int, string> FuncDelegate = (int x, int y)
                => $"first number: {x} x second number: {y} = {x * y}";
            Console.WriteLine(FuncDelegate(5, 10));

            Console.WriteLine();

            Action<int, string> ActionDelegate = delegate (int x, string s)
                {
                    Console.WriteLine($"I will write {s} {x} time(s)");
                    for (int i = 0; i < x; i++) Console.Write($"{s} ");
                    Console.WriteLine();
                };
            ActionDelegate(5, "Hello");

            Console.WriteLine();

            Predicate<int> PredicateDelegate = (int x) => x >= 5;
            Console.Write("Please enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.Write($"The number {num} is ");
            if (PredicateDelegate(num)) Console.WriteLine("more than or equal to 5");
            else Console.WriteLine("less than 5");
            #endregion

            Console.WriteLine("\n-------------------------------------------\n");

            #region event
            Player player = new(12, 0, "Maryam");
            ScoreBoard scoreBoard = new(0);

            player.Score += scoreBoard.Score;
            player.OnScore();
            player.OnScore();
            player.OnScore();
            #endregion
        }
    }
}