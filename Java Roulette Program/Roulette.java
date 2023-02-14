import java.util.*;


public class Roulette{
 
   public void betOnce(int number){
      //Initialization of variables
      int choice = 0;
      String result = "";
      boolean notValid = true;
      boolean keepGoing = true;
      Scanner console = new Scanner(System.in);
      
      while (keepGoing){
         System.out.println("Which do you want to bet on \n1)Low \n2)High");
      //Checks if user put a 1 or a 2
         notValid = true;
         while(notValid){
            choice = console.nextInt();
            if (choice == 1||choice ==2){
               notValid = false;
            }
            else {
               System.out.println("Sorry, " + choice + " is not a valid choice, please choose a 1 or a 2.");
            }
         }
      //tells user the number
         System.out.println("The number was "+ number);
      //checks if the number is low, high, or 0
         if (number == 0){
            result = "Lose";
         }      
         if (number <= 18 && number >=1){
            result = "Low";
         }
         if (number >= 19){
            result = "High";
         }
      //if the user choice is equal to the result, user wins
         if (choice == 1 && result.equals ("Low")|| choice == 2 && result.equals ("High")) {
            System.out.println("You win!");
         }
         //if user choice is not equal to the result, or the result was a 0, user loses
         else {
            System.out.println("You lose.");
         }
         System.out.println("\nWould you like to bet again? \n1)Yes \n2)No");
         choice = console.nextInt();
         if (choice == 2)
         keepGoing = false;

      }
   }

}