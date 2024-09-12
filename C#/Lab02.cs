public class Lab02
{
    public static void Main(string[] args)
    {
        // charToASCII----------------------------------
        Console.WriteLine("Please enter a character");
        char c = char.Parse(Console.ReadLine());
        int x = c;
        Console.WriteLine($"Here is your character's ASCII {x}\n");
        
        // ASCII ToChar---------------------------------
        Console.WriteLine("Please enter a number");
        int number = int.Parse(Console.ReadLine());
        char numCharacter = (char)number;
        Console.WriteLine($"Here is your ASCII character: {numCharacter}\n");
        
        // grades---------------------------------------
        Console.WriteLine("Please enter your grade");
        int grade = int.Parse(Console.ReadLine());
        if (grade > 100 || grade < 0) Console.WriteLine("Please enter valid grade");
        else 
        {
            Console.Write("Your grade is: ");
            if (grade >= 85) Console.WriteLine("Excellent\n");
            else if (grade >= 75) Console.WriteLine("Very Good\n");
            else if (grade >= 65) Console.WriteLine("Good\n");
            else if (grade >= 50) Console.WriteLine("Pass\n");
            else Console.WriteLine("Fail\n");
        }
        
        // multiplicationTable--------------------------
        for (int i = 0; i < 13; i++) 
        {
            for (int j = 0; j < 13 ; j++) 
            {
                int answer = i * j;
                if (answer >= 100)
                    Console.Write($"{answer} ");
                else if (answer >= 10)
                    Console.Write($" {answer} ");
                else Console.Write($"  {answer} ");
            }
            Console.WriteLine();
        }
    }
}