sing System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first string:");
        string input1 = Console.ReadLine();
        
        Console.WriteLine("Enter the second string:");
        string input2 = Console.ReadLine();

        bool result = IsAnagram(input1, input2);
        Console.WriteLine($"Are the strings anagrams? {result}");
    }

    static bool IsAnagram(string str1, string str2)
    {
        // Clean and normalize both strings
        string cleanStr1 = new string(str1.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray()).ToLower();
        string cleanStr2 = new string(str2.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray()).ToLower();

        // Sort the characters and compare
        return cleanStr1.OrderBy(c => c).SequenceEqual(cleanStr2.OrderBy(c => c));
    }
}