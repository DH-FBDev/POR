import java.util.Scanner;

class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        try {
            
            int input = Integer.parseInt(scanner.nextLine()); // Convert input to int
            
            if(input % 3 == 0 && input % 5 == 0){
                System.out.println("Fizzbuzz"); // Output the input
            }
            else if(input % 3 == 0){
                System.out.println("Fizz"); // Output the input
            }
            else if(input % 5 == 0){
                System.out.println("buzz"); // Output the input
            }
            else{
                System.out.println(input); // Output the input
            }
        } catch (NumberFormatException e) {
            System.out.println("Invalid input. Please enter a valid number."); // Handle invalid input
        } finally {
            scanner.close(); // Close the scanner (optional)
        }
    }
}