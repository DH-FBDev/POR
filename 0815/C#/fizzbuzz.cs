using System;

public class Fizzbuzz
{
    public static void Main(string[] args)
    {
        for(int i = 1;i<=100;i++){
            
            if(i % 3 == 0.00 && i % 5 == 0.00) {
                Console.WriteLine("Fizzbuzz");
            }
            else if (i % 3 == 0.00){
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0.00){
                Console.WriteLine("buzz");
            }
            else {
                Console.WriteLine(i);
            }
        }
    }
}