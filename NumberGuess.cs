using System;

class NumberGuess {
  private int number;

  public void setNumber() {
    Console.WriteLine("Enter Your Number: ");
    number = int.Parse(Console.ReadLine());
  }

  public int getNumber() {
    
    return number;
  }

  public bool isValidNumber() {
    bool isValid = (getNumber() % 1) == 0;

    return isValid;
  }

}

public class Game {
  NumberGuess guessNumber = new NumberGuess();

   public static void Main() {
     new Game().playGame();
   }

   public void playGame() {
     guessNumber.setNumber();

     while(!guessNumber.isValidNumber()) {
       Console.WriteLine("Invalid number. Please enter a new number!");
       guessNumber.setNumber();
     }

     Console.WriteLine(makeGuess());
   }

   public String makeGuess() {
    int guess = 50;
    string response = "";
    bool validResponse = false;

    while(!validResponse) {
      Console.WriteLine("Is your number higher or lower than " + guess + "?");
      response = Console.ReadLine().ToLower();

      if(!response.Equals("higher") || !response.Equals("lower") || !response.Equals("correct")) {
        Console.WriteLine("Enter a valid response. (Higher/Lower/Correct)");
      } else {
        validResponse = true;
      }
    }

    return response;
    
   }

}