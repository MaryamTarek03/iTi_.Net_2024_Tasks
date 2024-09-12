public class Lab01
{
    public static void Main(string[] args)
    {
        // Variables
        int userId = 73;
        string userFullName = "Maryam Tarek Saeed Muhammed Ashour";
        float heightInMeters = 1.75f;
        double accountBalance = 1500.50;
        decimal annualSalary = 151534.0m;
        
        // Show data
        Console.WriteLine("ID: " + userId);
        Console.WriteLine("Full Name: " + userFullName);
        Console.WriteLine("Height(M): " + heightInMeters);
        Console.WriteLine("Balance: " + accountBalance);
        Console.WriteLine("Annual Salary: " + annualSalary);
        
        string firstName = "Maryam";
        string lastName = "Ashour";
        
        // WriteLine
        Console.WriteLine();
        Console.WriteLine("Hello World");
        Console.WriteLine(firstName);
        
        Console.WriteLine();
        // String holder
        Console.WriteLine("First Name: {0}, Last Name: {1}", firstName, lastName);
        
        // String interpolated
        Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}");
        
        // String Concatenation
        Console.WriteLine("First Name: " + firstName + ", Last Name: " + lastName);
        
        // Escape sequences
        Console.WriteLine();
        Console.WriteLine("This is a Tab \t!");
        Console.WriteLine(@"This is a not Tab \t!");
        Console.WriteLine();
        Console.WriteLine(@"D:\Projects\CSharp\lab01\");
        Console.WriteLine("D:\\Projects\\CSharp\\lab01\\");
    }
}