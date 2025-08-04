import java.util.Scanner;

public class Program {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter a string:");
        String input = scanner.nextLine();
        
        boolean result = isPalindrome(input);
        System.out.println("Is the string a palindrome? " + result);
        
        scanner.close();
    }

    static boolean isPalindrome(String str) {
        String clean = str.replaceAll("[\\W_]", "").toLowerCase();
        String reversed = new StringBuilder(clean).reverse().toString();
        return clean.equals(reversed);
    }
}