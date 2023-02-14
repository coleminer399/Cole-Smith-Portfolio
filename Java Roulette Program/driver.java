import java.util.*;

public class driver{
   public static void main(String[]args){
      Random r = new Random();
      int number = r.nextInt(37);
      Roulette g = new Roulette();
      g.betOnce(number);
   }
}