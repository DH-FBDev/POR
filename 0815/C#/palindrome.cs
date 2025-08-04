using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        
        bool result = IsPalindrome(input);
        Console.WriteLine($"Is the string a palindrome? {result}");
    }

    static bool IsPalindrome(string str)
    {

        string clean = new string(str.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray()).ToLower();

        return clean == new string(clean.Reverse().ToArray());
    }
}